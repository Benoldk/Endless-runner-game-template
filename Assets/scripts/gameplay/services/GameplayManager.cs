using game.package.gameplay.infinitetrail;
using UnityEngine;

namespace game.package.gameplay.services
{
    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager instance;

        public Trail[] trails;

        private GameObjectPool gameObjectPool;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        private void Start()
        {
            gameObjectPool = GameObjectPool.instance;
            gameObjectPool.AddPool(typeof(Trail));
            foreach (var road in trails)
            {
                gameObjectPool.AddGameObject(typeof(Trail), road, 2);
            }
        }

        public void CreateRoad(int index, Vector3 position)
        {
            var randRoad = trails[Random.Range(0, trails.Length)];
            var road = (Trail)gameObjectPool.GetGameObject(typeof(Trail), randRoad);
            road.name = $"Trail-{index}";
            road.index = index;
            road.transform.position = position;
            road.transform.parent = transform;
            road.gameObject.SetActive(true);
        }

        public void DestroyRoad(int index)
        {
            var road = GameObject.Find($"Trail-{index}");
            road.SetActive(false);
        }
    }
}