using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyController : MonoBehaviour
    {
        private const int Movespeed = 200;
        private const int Bulletspeed = 500;

        private int health = 5;
        private float fireInterval = 2f;
        private Rigidbody2D _rb;
        private Transform _starboard;
        private Transform _port;
        private Transform _playerTransform;

        // Use this for initialization
        public void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _starboard = transform.FindChild("Starboard");
            _port = transform.FindChild("Port");
            _playerTransform = GameObject.FindWithTag("Player").transform;
        }

        // Update is called once per frame
        public void Update()
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }

            // Shoot cannonballs every 2 seconds.
            fireInterval -= Time.deltaTime;
            if (fireInterval <= 0)
            {
                var ball1 = (GameObject)Instantiate(Resources.Load("EnemyBall"), _starboard.position, transform.rotation);
                ball1.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * Bulletspeed);
                var ball2 = (GameObject)Instantiate(Resources.Load("EnemyBall"), _port.position, transform.rotation);
                ball2.GetComponent<Rigidbody2D>().AddRelativeForce(-Vector2.right * Bulletspeed);
                fireInterval = 2f;
            }

            // Turn towards the player.
            transform.up = Vector2.Lerp(transform.up, _playerTransform.position - transform.position, .15f * Time.deltaTime);
        }

        public void FixedUpdate()
        {
            _rb.AddRelativeForce(Vector2.up * Movespeed * Time.fixedDeltaTime);
        }

        /// <summary>
        /// Sent when an incoming collider makes contact with this object's
        /// collider (2D physics only).
        /// </summary>
        /// <param name="other">The Collision2D data associated with this collision.</param>
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("PlayerBall"))
            {
                health--;
                Destroy(other.gameObject);
            }
        }
    }
}
