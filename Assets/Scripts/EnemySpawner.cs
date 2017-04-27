using UnityEngine;

namespace Assets.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
		private float _timer = 3f;

		/// <summary>
		/// Update is called every frame, if the MonoBehaviour is enabled.
		/// </summary>
		public void Update()
		{
			_timer -= Time.deltaTime;
			if (_timer <= 0)
			{
				Instantiate(Resources.Load("Enemy"), Vector3.zero, transform.rotation);
				_timer = 3f;
			}
		}
    }
}
