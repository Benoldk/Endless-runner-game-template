using game.package.gameplay.infinitetrail;
using game.package.gameplay.resourceloader;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace game.package.gameplay.services
{
    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager instance;

        private List<Trail> trails = new List<Trail>();
        private GameObjectPool gameObjectPool;
        private AssetManager assetManager;

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        private void Start()
        {
            assetManager = GameObject.Find("AssetManager").GetComponent<AssetManager>();
            gameObjectPool = GameObjectPool.instance;
            gameObjectPool.AddPool(typeof(Trail));

            var levelAssets = assetManager.LoadLevelAssets();
            trails.AddRange(levelAssets.Select(l => l.GetComponent<Trail>()));
            gameObjectPool.RegisterGameObjects<Trail>(levelAssets);
            CreateRoad(0, Vector3.zero);
            CreatePlayer();
        }

        public void CreateRoad(int index, Vector3 position)
        {
            int rand = Random.Range(0, trails.Count);
            var randRoad = trails[rand];
            var road = gameObjectPool.GetRandomObject<Trail>(randRoad.gameObject).GetComponent<Trail>();
            road.name = $"Trail-{index}";
            road.index = index;
            road.transform.position = position;
            road.transform.parent = transform;
            road.gameObject.SetActive(true);
        }

        private void CreatePlayer()
        {
            var player = assetManager.LoadPlayer();
            if (player)
            {
                var inGamePlayer = Instantiate(player);
                inGamePlayer.GetComponent<PlayerInitializer>().Initialize();
            }
        }

        public void DestroyRoad(string name)
        {
            var road = GameObject.Find(name);
            if(road != null)
                road.SetActive(false);
        }
    }
}