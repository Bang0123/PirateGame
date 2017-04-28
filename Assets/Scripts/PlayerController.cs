using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PlayerController : Ship
    {
        public float ScoreTime = 0f;
        public int EnemyLifetime = 10;

        private int _currentGold;
        private Text _goldText;

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        public new void Start()
        {
            base.Start();
            _currentGold = 0;
            _health = 3;
            _goldText = GameObject.FindGameObjectWithTag("Gold").GetComponent<Text>();
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        public void Update()
        {
            // Speed boost.
            if (Input.GetKeyDown(KeyCode.Space)) _currentMovespeed = _boostedMovespeed;
            if (Input.GetKeyUp(KeyCode.Space)) _currentMovespeed = _movespeed;
            Fire();
            Die();
            ScoreTime += Time.deltaTime;
        }

        /// <summary>
        /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
        /// </summary>
        public void FixedUpdate()
        {
            MovementControls();
        }

        /// <summary>
        /// Sent when an incoming collider makes contact with this object's
        /// collider (2D physics only).
        /// </summary>
        /// <param name="other">The Collision2D data associated with this collision.</param>
        void OnCollisionEnter2D(Collision2D other)
        {
            TakeDamage<EnemyController>(other.gameObject);
        }

        /// <summary>
        /// This function is called when the MonoBehaviour will be destroyed.
        /// </summary>
        void OnDestroy()
        {
            SceneManager.LoadScene("MainMenuScene");
        }

        public void AddGold(int amount)
        {
            _currentGold += amount;
            UpdateGoldCounter();
        }

        public void RemoveGold(int amount)
        {
            _currentGold -= amount;
            UpdateGoldCounter();
        }
        private void UpdateGoldCounter()
        {
            _goldText.text = "" + _currentGold;
        }

        private void MovementControls()
        {
            if (Math.Abs(Input.GetAxisRaw("Horizontal")) > 0)
            {
                _rb.AddTorque(_turnRate * Input.GetAxis("Horizontal") * Time.fixedDeltaTime);
                _rb.AddRelativeForce(Vector2.up * Mathf.Abs(Input.GetAxis("Horizontal")) * _currentMovespeed * Time.fixedDeltaTime);
            }
            else
            {
                _rb.AddRelativeForce(Vector2.up * Input.GetAxis("Vertical") * _currentMovespeed * Time.fixedDeltaTime);
            }
        }

        private void Fire()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                FireCannonball(_starboard.position, Vector2.right);
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                FireCannonball(_port.position, Vector2.left);
            }
        }

        // used by the enemy spawner to stop spawning at some point
        public int GetHealth()
        {
            return _health;
        }
    }
}