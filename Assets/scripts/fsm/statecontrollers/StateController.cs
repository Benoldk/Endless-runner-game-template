using game.package.fsm.stats;
using UnityEngine;

namespace game.package.fsm
{
    public class StateController : MonoBehaviour
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
        public bool isSliding;
        public float slideDuration = 0.5f;

        [SerializeField] protected CharacterStats characterStats;

        [HideInInspector] public Vector3 nextPoint;
        [HideInInspector] public bool isMovingHorizontally;
        [HideInInspector] public bool isJumping;
        [HideInInspector] public Rigidbody rigidBody;


        public Vector3 targetPosition;
        internal Vector3 direction;

        private void Start()
        {
            Initialize();
        }

        private void Awake()
        {
        }

        private void Update()
        {
            UpdateState();
        }

        protected virtual void UpdateState()
        {
            currentState.UpdateState(this);
        }

        protected virtual void Initialize()
        {
            localStats = new LocalCharacterStats(characterStats);
            rigidBody = GetComponent<Rigidbody>();
            transform.position = Vector3.zero;
            isMovingHorizontally = false;
            isJumping = false;
            isSliding = false;
        }

        public virtual void TransitionToState(State nextState)
        {
            if (nextState != remainState)
            {
                currentState = nextState;
            }
        }
    }
}