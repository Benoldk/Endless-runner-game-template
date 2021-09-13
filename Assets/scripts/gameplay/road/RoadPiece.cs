using UnityEngine;

namespace game.package.gameplay
{
    public class RoadPiece : MonoBehaviour
    {
        [SerializeField] GameObject leftLane;
        [SerializeField] GameObject middleLane;
        [SerializeField] GameObject rightLane;

        private Obstacle obstacle;

        private void PlaceObstacle(Obstacle obstacle)
        {
            if (obstacle.tag.CompareTo("Large-barrier") == 0)
            {
                obstacle.transform.position = middleLane.transform.position;
            }
            else
            {
                int randLane = UnityEngine.Random.Range(1, 4);
                if(randLane == 1)
                    obstacle.transform.position = leftLane.transform.position;
                else if(randLane == 2)
                    obstacle.transform.position = middleLane.transform.position;
                else
                    obstacle.transform.position = rightLane.transform.position;
            }
        }
    }
}