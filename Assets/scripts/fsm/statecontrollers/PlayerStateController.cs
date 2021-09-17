using game.package.gameplay;
using game.package.gameplay.services;
using UnityEngine;

namespace game.package.fsm
{
    public class PlayerStateController : StateController
    {
        private Ray collisionRay;
        [SerializeField] private int scoreValue = 5;
        [Range(0.5f, 2f)]
        [SerializeField] private float scoreUpdateInterval = 1f;
        private float elapsedTime;

        protected override void Initialize()
        {
            base.Initialize();
        }

        private void Update()
        {
            UpdateState();
            HandleCustomCollision();
            UpdateUI();
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

        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.green;
        //    Gizmos.DrawRay(collisionRay.origin, collisionRay.direction.normalized * 0.5f);
        //}

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