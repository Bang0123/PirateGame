using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        private const int Movespeed = 300;
        private const int BoostedMovespeed = 500;
        private const int Bulletspeed = 500;

        private int _turnRate = -30;
        private int _movespeed = 300;
        private int _currentGold;
        private Rigidbody2D _rb;
        private Transform _starboard;
        private Transform _port;

        // Use this for initialization
        public void Start()
        {
            _currentGold = 0;
            _rb = GetComponent<Rigidbody2D>();
            _starboard = transform.FindChild("Starboard");
            _port = transform.FindChild("Port");
        }

        // Update is called once per frame
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) _movespeed = BoostedMovespeed;
            if (Input.GetKeyUp(KeyCode.Space)) _movespeed = Movespeed;
            if (Input.GetKeyDown(KeyCode.B))
            {
                var ball = (GameObject)Instantiate(Resources.Load("Ball"), _starboard.position, transform.rotation);
                ball.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * Bulletspeed);
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                var ball = (GameObject)Instantiate(Resources.Load("Ball"), _port.position, transform.rotation);
                ball.GetComponent<BallController>().Parent = this;
                ball.GetComponent<Rigidbody2D>().AddRelativeForce(-Vector2.right * Bulletspeed);
            }
        }

        public void FixedUpdate()
        {
            if (Math.Abs(Input.GetAxisRaw("Horizontal")) > 0)
            {
                _rb.AddTorque(_turnRate * Input.GetAxis("Horizontal") * Time.fixedDeltaTime);
                _rb.AddRelativeForce(Vector2.up * Mathf.Abs(Input.GetAxis("Horizontal")) * _movespeed *
                                     Time.fixedDeltaTime);
            }
            else
            {
                _rb.AddRelativeForce(Vector2.up * Input.GetAxis("Vertical") * _movespeed * Time.fixedDeltaTime);
            }
        }

        public void AddGold(int amount)
        {
            _currentGold += amount;
        }

        public void RemoveGold(int amount)
        {
            _currentGold -= amount;
        }
        public void UpdateGoldCounter()
        {
            GameObject.FindGameObjectWithTag("Gold").GetComponent<Text>().text = "" + _currentGold;
        }
    }
}