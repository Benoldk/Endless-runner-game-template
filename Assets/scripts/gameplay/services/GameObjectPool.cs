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
                gameObectPools.Add(type, new List<MonoBehaviour>());
        }

        public override void AddGameObject(Type type, MonoBehaviour prefab, int count = 1)
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

        public override MonoBehaviour GetRandomObject<T>(MonoBehaviour prefab)
        {
            Type type = typeof(T);
            if (!gameObectPools.ContainsKey(type))
                AddPool(type);
            MonoBehaviour obj = gameObectPools[type].FirstOrDefault(g => !g.gameObject.activeSelf && g.name == prefab.name);
            if (obj == null)
            {
                AddGameObject(type, prefab);
                obj = gameObectPools[type].FirstOrDefault(g => !g.gameObject.activeSelf && g.name == prefab.name);
            }
            return obj;
        }
    }
}