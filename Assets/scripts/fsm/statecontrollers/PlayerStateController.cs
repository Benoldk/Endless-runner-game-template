﻿using game.package.fsm.stats;
using UnityEngine;

namespace game.package.fsm
{
    public class PlayerStateController : MonoBehaviour
    {
        public State currentState;
        public State remainState;
        public LocalCharacterStats localStats;
        public Animator animator;
        [SerializeField] private CharacterStats characterStats;

        public RunStateAction runAction;
        public HorizontalMovementStateAction horizontalMovementAction;
        public SimpleStateAction jumpAction;
        public SimpleStateAction slideAction;
        public SimpleStateAction stumbleAction;
        
        [HideInInspector] public Rigidbody rigidBody;
        [HideInInspector] public Vector3 nextPoint;
        [HideInInspector] public bool isDead;

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            UpdateState();
            HandleCustomCollision();
        }

        protected void Initialize()
        {
            localStats = new LocalCharacterStats(characterStats);
            rigidBody = GetComponent<Rigidbody>();
            transform.position = Vector3.zero;
            isDead = false;
        }

        protected virtual void UpdateState()
        {
            currentState.UpdateState(this);
        }

        void HandleCustomCollision()
        {
        }

        public virtual void TransitionToState(State nextState)
        {
            if (nextState != remainState)
            {
                currentState = nextState;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.CompareTo("Obstacle") == 0)
            {
                stumbleAction.isActive = true;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            jumpAction.isActive = !(collision.collider.tag.CompareTo("Ground") == 0);

            if (collision.gameObject.tag.CompareTo("Obstacle") == 0)
            {
                localStats.Health = 0;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            jumpAction.isActive = collision.collider.tag.CompareTo("Ground") == 0;
        }
    }
}