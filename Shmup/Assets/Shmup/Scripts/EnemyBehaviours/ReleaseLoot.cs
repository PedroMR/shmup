using UnityEngine;
using System.Collections;

namespace com.pedromr.games.shmup
{
	public class ReleaseLoot : MonoBehaviour
	{
		public int whenKilled;
		private GameObject scrapPrefab;
	
	// Use this for initialization
		void Start()
		{
			scrapPrefab = GameManager.Instance.GetLootPrefab();
		}

		public void OnKill()
		{
			float explosionForce = 1;
			const int explosionRadius = 1;
			for(int i=0; i < whenKilled; i++) {
				var offset = UnityEngine.Random.insideUnitCircle;
				var go = Instantiate(scrapPrefab, transform.position + new Vector3(offset.x, 0, offset.y), transform.rotation);
				go.transform.parent = transform.parent;
				var rb = go.GetComponent<Rigidbody>();
				rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, 0, ForceMode.Force);
			}
		}
	}
}