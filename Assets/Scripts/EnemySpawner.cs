using UnityEngine;

namespace Assets.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        public PlayerController _playerHealth;       
        public GameObject _enemy;                
        public float _spawnTime = 6f;            
        public Transform[] _spawnPoints;

        void Start()
        {
            InvokeRepeating("Spawn", _spawnTime, _spawnTime);
        }
        
        void Spawn()
        {
            if (_playerHealth.GetHealth() <= 0)
            {
                return;
            }

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, _spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(_enemy, _spawnPoints[spawnPointIndex].position, _spawnPoints[spawnPointIndex].rotation);
        }
    }
}
