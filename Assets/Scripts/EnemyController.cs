using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyController : MonoBehaviour
    {
        private const int Movespeed = 200;
        private const int Bulletspeed = 500;

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
            Debug.Log(fireInterval);
            fireInterval -= Time.deltaTime;
            if (fireInterval <= 0)
            {
                var ball1 = (GameObject)Instantiate(Resources.Load("Ball"), _starboard.position, transform.rotation);
                ball1.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * Bulletspeed);
                var ball2 = (GameObject)Instantiate(Resources.Load("Ball"), _port.position, transform.rotation);
                ball2.GetComponent<Rigidbody2D>().AddRelativeForce(-Vector2.right * Bulletspeed);
                fireInterval = 2f;
            }
            transform.up = Vector2.Lerp(transform.up, _playerTransform.position - transform.position, .15f * Time.deltaTime);
        }

        public void FixedUpdate()
        {
            _rb.AddRelativeForce(Vector2.up * Movespeed * Time.fixedDeltaTime);
        }
    }
}
