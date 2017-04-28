using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ScoreController : MonoBehaviour
    {
		private Text _scoreText;

		/// <summary>
		/// Start is called on the frame when a script is enabled just before
		/// any of the Update methods is called the first time.
		/// </summary>
		public void Start()
		{
			_scoreText = gameObject.GetComponent<Text>();
		}

		/// <summary>
		/// Update is called every frame, if the MonoBehaviour is enabled.
		/// </summary>
		public void Update()
		{
			_scoreText.text = GameObject.FindWithTag("Player").GetComponent<PlayerController>().ScoreTime.ToString();
		}
    }
}
