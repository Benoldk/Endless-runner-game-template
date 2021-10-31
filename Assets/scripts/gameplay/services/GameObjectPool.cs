using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace game.package.gameplay.services
{
    public class GameObjectPool : ObjectPool
    {
        public static GameObjectPool instance;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
        }

        public override void AddPool(Type type)
        {
            if (!gameObectPools.ContainsKey(type))
                gameObectPools.Add(type, new List<GameObject>());
        }

        public override void AddGameObject(Type type, GameObject prefab, int count = 1)
        {
            if (prefab != null)
            {
                if (!gameObectPools.ContainsKey(type))
                    AddPool(type);
                for (int i = 0; i < count; i++)
                {
                    var obj = Instantiate(prefab);
                    obj.gameObject.SetActive(false);
                    gameObectPools[type].Add(obj);
                }
            }
        }

        public void RegisterGameObjects<T>(List<GameObject> assets)
        {
            foreach(var asset in assets)
            {
                AddGameObject(typeof(T), asset);
            }
        }

        public override GameObject GetRandomObject<T>(GameObject prefab)
        {
            Type type = typeof(T);
            if (!gameObectPools.ContainsKey(type))
                AddPool(type);
            GameObject obj = gameObectPools[type].FirstOrDefault(g => !g.activeSelf && g.name.Contains(prefab.name));
            if (obj == null)
            {
                AddGameObject(type, prefab);
                obj = gameObectPools[type].FirstOrDefault(g => !g.activeSelf && g.name.Contains(prefab.name));
            }
            return obj;
        }
    }
}