using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PlayerController : Ship
    {
        private int _currentGold;

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        public new void Start()
        {
            base.Start();
            _currentGold = 0;
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
        }

        /// <summary>
        /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
        /// </summary>
        public void FixedUpdate()
        {
            MovementControls();
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
    }
}