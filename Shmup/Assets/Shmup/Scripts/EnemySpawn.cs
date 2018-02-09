using UnityEngine;
using System.Collections;

namespace com.pedromr.games.shmup
{
	public class EnemySpawn : MonoBehaviour
	{
		public GameObject enemyType;

		public void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			if (!DrawEditorMeshForObject())
			{
				Gizmos.DrawWireSphere(transform.position, 1);
			}
		}

		private bool DrawEditorMeshForObject()
		{
			Mesh mesh = null;
			if (enemyType != null)
			{
				var meshFilter = enemyType.GetComponentInChildren<MeshFilter>();
				if (meshFilter != null)
				{
					mesh = meshFilter.sharedMesh;
					if (mesh != null)
					{
						Gizmos.DrawWireMesh(mesh, transform.position, meshFilter.transform.rotation * transform.rotation);
					}
				}
			}

			return mesh;
		}

		private void OnTriggerEnter(Collider other)
		{
			Debug.Log("OnTriggerEnter");
			if(other.gameObject.CompareTag("GameController")) {
				Debug.Log("Instantiating enemy");
				Object.Instantiate(enemyType, transform.position, transform.rotation);
				Destroy(gameObject);
			}
		}
	}
}
