using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

namespace com.pedromr.games.shmup
{
	[CreateAssetMenu]
	public class EnemyParameters : ScriptableObject
	{
		public float speed;
		public Vector3[] waypoints;
		public bool flipX;
		public float lookAt;
		public float tiltX;

		public void Initialize(GameObject newEnemy, EnemySpawn spawnObject)
		{
			if (waypoints != null) {
				var worldWaypoints = new Vector3[waypoints.Length];

				for (var i = 0; i < waypoints.Length; i++) {
					var localWaypoint = waypoints[i];

					worldWaypoints[i] = new Vector3(spawnObject.flipOnX ? -localWaypoint.x : localWaypoint.x,
					//worldWaypoints[i] = newEnemy.transform.TransformPoint(spawnObject.flipOnX ? -localWaypoint.x : localWaypoint.x,
																		  localWaypoint.y, localWaypoint.z);
				}

				newEnemy.transform.DOLocalPath(worldWaypoints, speed, PathType.CatmullRom, PathMode.Full3D, 30)
					 //newEnemy.transform.DOLocalPath(theWaypoints, speed, PathType.CatmullRom, PathMode.TopDown2D)
				        .SetSpeedBased().SetEase(Ease.Linear).SetLoops(0).SetOptions(false)
				        .SetLookAt(lookAt,-Vector3.forward)
				        ;

			}
		}
	}
}
