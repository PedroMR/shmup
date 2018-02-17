using UnityEngine;
using System.Collections;

namespace com.pedromr.games.shmup
{
	public class DestroyByContactWithPlayer : MonoBehaviour
	{
		public GameObject explosion;
		public GameObject playerExplosion;
		public int scoreValue;
		private Done_GameController gameController;

		void Start()
		{
		}

		void OnTriggerEnter(Collider other)
		{

			if (other.tag == "PlayerWeapon")
			{
				// Destroyed!
				if (explosion != null)
				{
					Instantiate(explosion, transform.position, transform.rotation);
					var loot = GetComponent<ReleaseLoot>();
					if (loot != null) loot.OnKill();
				}
				Destroy(gameObject);
				//gameController.AddScore(scoreValue);
			}

			if (other.tag == "Player")
			{
				Destroy(other.gameObject);
				Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
				//gameController.GameOver();
			}
		}
	}
}