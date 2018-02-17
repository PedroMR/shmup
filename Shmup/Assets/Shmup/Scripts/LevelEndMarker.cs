using UnityEngine;
using System.Collections;

namespace com.pedromr.games.shmup
{
	public class LevelEndMarker : MonoBehaviour
	{
		private LevelData levelData;

		// Use this for initialization
		void Start()
		{
			levelData = GetComponentInParent<LevelData>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("GameController")) {
				levelData.OnEndReached(this);
			}
		}

	}
}