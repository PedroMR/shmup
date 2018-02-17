using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.pedromr.games.shmup
{
	public class SpawnCenter : MonoBehaviour
	{
		private bool spawned = false;

		private EnemySpawn[] spawnChildren;


		public void Start() {
			spawnChildren = GetComponentsInChildren<EnemySpawn>();
			Debug.Log("Squad online, children: "+spawnChildren.Length);
		}

		public void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			//if (!DrawEditorMeshForObject()) 
			{
				Gizmos.DrawWireSphere(transform.position, 1);
			}
			//DrawEnemyParams(enemyParams);
		}


		private void OnTriggerEnter(Collider other)
		{
			spawnChildren = GetComponentsInChildren<EnemySpawn>();
			if (!spawned && other.gameObject.CompareTag("GameController")) {
				Debug.Log("Spawning squadron, children: "+spawnChildren.Length);
				foreach (var spawnee in spawnChildren) {
					spawnee.Spawn();
				}
				Debug.Log("Spawning squadron: Done");
			}
		}


	}
}