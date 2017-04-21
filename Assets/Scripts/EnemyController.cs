using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyController : MonoBehaviour
    {
        private const int Movespeed = 200;
        private Rigidbody2D _rb;
        private Transform _playerTransform;

        // Use this for initialization
        public void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _playerTransform = GameObject.FindWithTag("Player").transform;
        }

        // Update is called once per frame
        public void Update()
        {
            transform.up = Vector2.Lerp(transform.up, _playerTransform.position - transform.position, .15f * Time.deltaTime);
        }

        public void FixedUpdate()
        {
            _rb.AddRelativeForce(Vector2.up * Movespeed * Time.fixedDeltaTime);
        }
    }
}
