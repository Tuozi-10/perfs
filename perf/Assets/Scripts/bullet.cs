using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class bullet : MonoBehaviour
    {
        private List<string> m_stringsSpells = new List<string>(50);
        private List<string> m_stringsStats = new List<string>(150);
        private List<string> m_stringsEnemies = new List<string>(10);
        private int hp;
        private int hp2;

        private float spawnTime;
        
        public void Reset()
        {
            m_stringsSpells.Clear();
            m_stringsStats.Clear();
            m_stringsEnemies.Clear();
            hp = 0;
            hp2 = 0;
            gameObject.SetActive(true);
            spawnTime = 2f; 
        }
        
        void Update()
        {
            spawnTime -= Time.deltaTime;

            if (spawnTime < 0)
            {
                PoolManager.AddToPool(this);
            }
        }
    }
}