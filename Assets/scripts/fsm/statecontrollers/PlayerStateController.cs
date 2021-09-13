using game.package.gameplay;
using game.package.gameplay.services;
using UnityEngine;

namespace game.package.fsm
{
    public class PlayerStateController : StateController
    {
        private Ray collisionRay;
        private Rigidbody rigidBod;
        [SerializeField] private int scoreValue = 5;
        [Range(0.5f, 2f)]
        [SerializeField] private float scoreUpdateInterval = 1f;
        private float elapsedTime;

        protected override void Initialize()
        {
            base.Initialize();
            rigidBod = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            UpdateState();
            HandleCustomCollision();
            UpdateScore();
        }

        void HandleCustomCollision()
        {
            Vector3 position = transform.position;
            position.y = GetComponent<BoxCollider>().center.y;
            collisionRay = new Ray(position, transform.forward.normalized);
            if(Physics.Raycast(collisionRay, out RaycastHit hitInfo, 0.5f, LayerMask.GetMask("Obstacle", "Pickup")))
            {
                hitInfo.collider.gameObject.GetComponent<CollidableGameObject>().HandleCollision(rigidBod);
            }
        }

        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.green;
        //    Gizmos.DrawRay(collisionRay.origin, collisionRay.direction.normalized * 0.5f);
        //}

        private void UpdateScore()
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime > scoreUpdateInterval)
            {
                elapsedTime = 0;
                GameEvents.OnUIAddToScore?.Invoke(scoreValue);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            isGrounded = collision.collider != null 
                        && collision.collider.tag.CompareTo("Ground") == 0;
        }
    }
}