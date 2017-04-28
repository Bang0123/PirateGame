using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyController : Ship
    {
        private PlayerController _playerController;
        private Transform _playerTransform;
        
        // Use this for initialization
        public new void Start()
        {
            base.Start();
            _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            _playerTransform = GameObject.FindWithTag("Player").transform;
            _health = 3;
            Destroy(gameObject, _playerController.EnemyLifetime);
        }

        // Update is called once per frame
        public new void Update()
        {
            base.Update();
            FireCannonballs();
            TurnToPlayer();
        }

        /// <summary>
        /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
        /// </summary>
        public void FixedUpdate()
        {
            _rb.AddRelativeForce(Vector2.up * _currentMovespeed * Time.fixedDeltaTime);
        }

        /// <summary>
        /// Sent when an incoming collider makes contact with this object's
        /// collider (2D physics only).
        /// </summary>
        /// <param name="other">The Collision2D data associated with this collision.</param>
        public void OnCollisionEnter2D(Collision2D other)
        {
            if (TakeDamage<PlayerController>(other.gameObject)) _playerController.AddGold(2);
        }

        private void FireCannonballs()
        {
            _currentFireInterval -= Time.deltaTime;
            if (_currentFireInterval <= 0)
            {
                FireCannonball(_starboard.position, Vector2.right);
                FireCannonball(_port.position, Vector2.left);
                _currentFireInterval = 2f;
            }
        }

        private void TurnToPlayer()
        {
            transform.up = Vector2.Lerp(transform.up, _playerTransform.position - transform.position, .15f * Time.deltaTime);
        }
    }
}