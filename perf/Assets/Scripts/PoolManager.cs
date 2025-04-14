using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] private bullet prefab;
        public static Queue<bullet> pool = new ();
        [SerializeField] private int poolStartCount = 10;

        private static PoolManager instance;
        
        private void Awake()
        {
            instance = this;
            PrePool();
        }

        public  void PrePool()
        {
            for (int i = 0; i < poolStartCount; i++)
            {
                AddToPool(Instantiate(instance.prefab));
            }
        }

        public static void AddToPool(bullet toPool)
        {
            toPool.gameObject.SetActive(false);
            pool.Enqueue(toPool);
        }
        
        public static bullet GetOrCreate()
        {
            if (pool.Count > 0)
            {
                bullet dequeued = pool.Dequeue();
                dequeued.Reset();
                return dequeued;
            }

            return Instantiate(instance.prefab);
        }

        
    }
}