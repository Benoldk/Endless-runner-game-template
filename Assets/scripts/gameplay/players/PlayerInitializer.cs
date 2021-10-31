using game.package.camera;
using UnityEngine;

namespace game.package.gameplay
{
    public class PlayerInitializer : MonoBehaviour
    {
        public void Initialize()
        {
            CameraFollow cam = Camera.main.GetComponent<CameraFollow>();
            cam.target = transform;
            cam.PositionCamera();
        }
    }
}