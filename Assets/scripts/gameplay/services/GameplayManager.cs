using UnityEngine;

namespace game.package.gameplay.services
{
    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager instance;

        public Road[] roads;

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

            gameObjectPool.AddPool(typeof(Road));
            foreach (var road in roads)
            {
                gameObjectPool.AddGameObject(typeof(Road), road, 2);
            }
        }

        public void CreateRoad(int index, Vector3 position)
        {
            var randRoad = roads[Random.Range(0, roads.Length)];
            var road = (Road)gameObjectPool.GetGameObject(typeof(Road), randRoad);
            road.name = $"Road-{index}";
            road.index = index;
            road.transform.position = position;
            road.transform.parent = transform;
            road.gameObject.SetActive(true);
        }

        public void DestroyRoad(int index)
        {
            var road = GameObject.Find($"Road-{index}");
            road.SetActive(false);
        }
    }
}