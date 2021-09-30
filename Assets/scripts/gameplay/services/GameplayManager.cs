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
            foreach (var trail in trails)
            {
                gameObjectPool.AddGameObject(typeof(Trail), trail, 1);
            }

            CreateRoad(0, Vector3.zero);
        }

        public void CreateRoad(int index, Vector3 position)
        {
            int rand = Random.Range(0, trails.Length);
            var randRoad = trails[rand];
            var road = (Trail)gameObjectPool.GetRandomObject<Trail>(randRoad);
            road.name = $"Trail-{index}";
            road.index = index;
            road.transform.position = position;
            road.transform.parent = transform;
            road.gameObject.SetActive(true);
        }

        public void DestroyRoad(string name)
        {
            var road = GameObject.Find(name);
            if(road != null)
                road.SetActive(false);
        }
    }
}