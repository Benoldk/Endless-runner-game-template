using UnityEngine;

namespace game.package.camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float followSpeed = 0.5f;

        private Vector3 velocity = Vector3.zero;

        void Start()
        {
            PositionCamera();
        }

        void LateUpdate()
        {
            PositionCamera();
        }

        protected virtual void PositionCamera()
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, followSpeed);
            //transform.LookAt(target);
        }
    }
}