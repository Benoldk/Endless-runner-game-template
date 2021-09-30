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
            var enumerables = gameObectPools[type].Where(g => !g.gameObject.activeSelf);
            MonoBehaviour obj = null;
            if (enumerables.Count() > 0)
            {
                int rand = UnityEngine.Random.Range(0, enumerables.Count());
                obj = enumerables.ToList()[rand];
            }
            if (obj == null)
            {
                AddGameObject(type, prefab);
                obj = gameObectPools[type].FirstOrDefault(g => !g.gameObject.activeSelf);
            }
            return obj;
        }
    }
}