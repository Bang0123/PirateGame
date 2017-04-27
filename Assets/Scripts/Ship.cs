using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Ship : MonoBehaviour
    {
        protected int _health = 10;
        protected int _movespeed = 300;
        protected int _boostedMovespeed = 500;
        protected int _currentMovespeed = 0;
        protected int _turnRate = -30;
        protected float _fireInterval = 2f;
        protected float _currentFireInterval = 0f;
        protected int _bulletspeed = 500;
        protected Rigidbody2D _rb;
        protected Transform _starboard;
        protected Transform _port;

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        public void Start()
        {
            _currentMovespeed = _movespeed;
            _currentFireInterval = _fireInterval;
            _rb = GetComponent<Rigidbody2D>();
            _starboard = transform.FindChild("Starboard");
            _port = transform.FindChild("Port");
        }

        protected void Die()
        {
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        protected void FireCannonball(Vector3 position, Vector2 direction)
        {
            var ball = (GameObject)Instantiate(Resources.Load("Cannonball"), position, transform.rotation);
            ball.GetComponent<BallController>().Parent = this;
            ball.GetComponent<Rigidbody2D>().AddRelativeForce(direction * _bulletspeed);
        }

        protected void TakeDamage<T>(GameObject obj)
        {
            if (obj.CompareTag("Cannonball") && obj.GetComponent<BallController>().Parent is T)
            {
                _health--;
                Destroy(obj);
            }
        }
    }
}