using UnityEngine;
using System.Collections;
using DG.Tweening.Core;
using System;

namespace com.pedromr.games.shmup
{
	public class EnemySpawn : MonoBehaviour
	{
		public GameObject enemyType;

		public EnemyParameters enemyParams;

		public bool flipOnX;

		private bool spawned = false;

		public void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			if (!DrawEditorMeshForObject())
			{
				Gizmos.DrawWireSphere(transform.position, 1);
			}
			DrawEnemyParams(enemyParams);
		}

		private void DrawEnemyParams(EnemyParameters enemyParams)
		{
			if (enemyParams == null) return;

			if (enemyParams.waypoints != null) {
				var lastPoint = transform.position;

				foreach (var waypoint in enemyParams.waypoints) {
					var localPoint = flipOnX ? new Vector3(-waypoint.x, waypoint.y, waypoint.z) : waypoint;
					var thisPoint = transform.TransformPoint(localPoint);

					Gizmos.DrawWireSphere(thisPoint, 0.5f);
					Gizmos.DrawLine(lastPoint, thisPoint);

					lastPoint = thisPoint;
				}
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
			if(!spawned && other.gameObject.CompareTag("GameController")) {
				Debug.Log("Instantiating enemy");
				var container = new GameObject(this.name + " Inst");
				var levelData = gameObject.GetComponentInParent<LevelData>();
				var enemyContainer = levelData.enemyContainer;

				container.transform.parent = enemyContainer.transform;
				container.transform.SetPositionAndRotation(transform.position, transform.rotation);
				var newEnemy = Instantiate(enemyType,transform.position, transform.rotation, container.transform);
				//newEnemy.transform.parent = container.transform;
				if (enemyParams != null) 
				{
					enemyParams.Initialize(newEnemy, this);
				}
				//Destroy(gameObject);
				spawned = true;
			}
		}
	}
}
