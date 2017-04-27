using UnityEngine;

namespace Assets.Scripts
{
    public class BallController : MonoBehaviour
    {
        public Ship Parent { get; set; }

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            Destroy(gameObject, 1);
        }
    }
}
