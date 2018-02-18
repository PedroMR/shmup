using UnityEngine;
using System.Collections;

namespace com.pedromr.games.shmup
{
	public class LootPickup : MonoBehaviour
	{
		// Use this for initialization
		void Start()
		{

		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player")) {
				GameManager.Instance.AddLoot(1);
				Destroy(gameObject);
			}
		}
	}
}
