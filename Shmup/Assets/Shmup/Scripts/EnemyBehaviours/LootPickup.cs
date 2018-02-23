using UnityEngine;
using System.Collections;

namespace com.pedromr.games.shmup
{
	public class LootPickup : MonoBehaviour
	{
		public static readonly ScrapLoot SCRAP_1 = new ScrapLoot(1);

		private GameObject playerGO;
		public float pickupRadius = 3;
		public float implosionForce = -1;
		private Rigidbody rb;

		private void Start()
		{
			playerGO = GameManager.Instance.PlayerGO;
			rb = GetComponent<Rigidbody>();
		}

		void FixedUpdate()
		{
			if (playerGO != null)
			{
				var playerPos = playerGO.transform.position;
				rb.AddExplosionForce(implosionForce,playerPos,pickupRadius);
				//if (Vector3.Distance(playerPos, transform.position) < pickupRadius)
				//{

				//}
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player")) {
				GameManager.Instance.AddLoot(SCRAP_1);
				Destroy(gameObject);
			}
		}
	}
}
