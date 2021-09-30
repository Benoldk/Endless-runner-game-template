using UnityEngine;
using System.Collections.Generic;
using System;

namespace game.package.gameplay
{
    public abstract class ObjectPool : MonoBehaviour
    {
        protected Dictionary<Type, List<MonoBehaviour>> gameObectPools = new Dictionary<Type, List<MonoBehaviour>>();

        public abstract void AddPool(Type type);

        public abstract void AddGameObject(Type type, MonoBehaviour prefab, int count = 1);

        public abstract MonoBehaviour GetRandomObject<T>(MonoBehaviour prefab);
    }
}