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
			var position = transform.position;
			var rotation = transform.rotation;
			DrawGizmosForSpawn(position, rotation);
		}

		public void DrawGizmosForSpawn(Vector3 position, Quaternion rotation)
		{
			Gizmos.color = Color.yellow;
			if (!DrawEditorMeshForObject()) {
				Gizmos.DrawWireSphere(position, 1);
			}
			DrawEnemyParams(enemyParams, position, rotation);
		}

		private void DrawEnemyParams(EnemyParameters enemyParams, Vector3 position, Quaternion rotation)
		{
			if (enemyParams == null) return;

			if (enemyParams.waypoints != null) {
				var lastPoint = position;

				foreach (var waypoint in enemyParams.waypoints) {
					var localPoint = flipOnX ? new Vector3(-waypoint.x, waypoint.y, waypoint.z) : waypoint;
					var thisPoint =  transform.TransformPoint(localPoint);

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
				Spawn();
			}
		}

		public void Spawn()
		{
			if (spawned) return;

			Debug.Log("Spawning enemy");
			var container = new GameObject(this.name + " Inst");
			var levelData = gameObject.GetComponentInParent<LevelData>();
			var enemyContainer = levelData.enemyContainer;

			container.transform.parent = enemyContainer.transform;
			container.transform.SetPositionAndRotation(transform.position, transform.rotation);
			var newEnemy = Instantiate(enemyType, transform.position, transform.rotation, container.transform);
			//newEnemy.transform.parent = container.transform;
			if (enemyParams != null) {
				enemyParams.Initialize(newEnemy, this, container);
			}
			//Destroy(gameObject);
			spawned = true;
		}
	}
}
