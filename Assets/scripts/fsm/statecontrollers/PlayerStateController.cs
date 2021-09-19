using game.package.fsm.stats;
using game.package.gameplay;
using game.package.gameplay.services;
using UnityEngine;

namespace game.package.fsm
{
    public class PlayerStateController : MonoBehaviour
    {
        public State currentState;
        public State remainState;
        public LocalCharacterStats localStats;
        public Animator animator;
        public float laneOffset = 2.5f;
        public int minLaneIndex = 0;
        public int maxLaneIndex = 2;
        public int targetLane = 1;
        public float targetLanePosition;
        public float targetDistanceThreshold = 0.25f;

        public float jumpForce = 2f;
        public float runAnimationMultiplier = 0.6f;
        public float runAnimationAccel = 0.001f;
        public float runAnimMaxMultiplier = 1;
        public float slideDuration = 0.5f;
        public float stumbleDuration = 0.5f;

        [SerializeField] protected CharacterStats characterStats;

        [HideInInspector] public Rigidbody rigidBody;
        [HideInInspector] public Vector3 nextPoint;
        [HideInInspector] public bool isMovingHorizontally;
        [HideInInspector] public bool isJumping;
        [HideInInspector] public bool isSliding;
        [HideInInspector] public bool isStumbling;
        [HideInInspector] public bool isDead;

        public Vector3 targetPosition;
        public Vector3 direction;
        private Ray collisionRay;

        [SerializeField] private int scoreValue = 5;
        [Range(0.5f, 2f)]
        [SerializeField] private float scoreUpdateInterval = 1f;
        private float elapsedTime;

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            UpdateState();
            HandleCustomCollision();
            UpdateUI();
        }

        protected void Initialize()
        {
            localStats = new LocalCharacterStats(characterStats);
            rigidBody = GetComponent<Rigidbody>();
            transform.position = Vector3.zero;
            isMovingHorizontally = false;
            isJumping = false;
            isSliding = false;
            isDead = false;
        }

        protected virtual void UpdateState()
        {
            currentState.UpdateState(this);
        }

        void HandleCustomCollision()
        {
            Vector3 position = transform.position;
            position.y = GetComponent<BoxCollider>().center.y;
            collisionRay = new Ray(position, transform.forward.normalized);
            if(Physics.Raycast(collisionRay, out RaycastHit hitInfo, 0.5f, LayerMask.GetMask("Obstacle", "Pickup")))
            {
                hitInfo.collider.gameObject.GetComponent<CollidableGameObject>().HandleCollision(gameObject);
            }
        }

        private void UpdateUI()
        {
            UpdateScore();
            HUDEvents.OnUpdateHP?.Invoke(localStats.Health);
        }

        private void UpdateScore()
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime > scoreUpdateInterval)
            {
                elapsedTime = 0;
                HUDEvents.OnUIAddToScore?.Invoke(scoreValue);
            }
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
                isStumbling = true;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            isJumping = !(collision.collider.tag.CompareTo("Ground") == 0);

            if (collision.gameObject.tag.CompareTo("Obstacle") == 0)
            {
                localStats.Health = 0;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            isJumping = collision.collider.tag.CompareTo("Ground") == 0;
        }
    }
}