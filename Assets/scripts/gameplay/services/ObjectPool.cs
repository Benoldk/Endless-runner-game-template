using UnityEngine;
using System.Collections.Generic;
using System;

namespace game.package.gameplay
{
    public abstract class ObjectPool : MonoBehaviour
    {
        protected Dictionary<Type, List<GameObject>> gameObectPools = new Dictionary<Type, List<GameObject>>();

        public abstract void AddPool(Type type);

        public abstract void AddGameObject(Type type, GameObject prefab, int count = 1);

        public abstract GameObject GetRandomObject<T>(GameObject prefab);
    }
}