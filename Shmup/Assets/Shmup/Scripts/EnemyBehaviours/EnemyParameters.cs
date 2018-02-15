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
		public float lookAhead;
		public float tiltX;

		private const int tweenPathResolution = 30;

		public void Initialize(GameObject newEnemy, EnemySpawn spawnObject, GameObject container)
		{
			if (waypoints != null) {
				var worldWaypoints = new Vector3[waypoints.Length];

				for (var i = 0; i < waypoints.Length; i++) {
					var localWaypoint = waypoints[i];

					worldWaypoints[i] = new Vector3(spawnObject.flipOnX ? -localWaypoint.x : localWaypoint.x,
					//worldWaypoints[i] = newEnemy.transform.TransformPoint(spawnObject.flipOnX ? -localWaypoint.x : localWaypoint.x,
																		  localWaypoint.y, localWaypoint.z);
				}

				var tweenCompletion = container.AddComponent<DisappearWhenTweenComplete>();

				var tweenParams = new TweenParams();
				tweenParams.SetSpeedBased(true).SetEase(Ease.Linear).SetLoops(0).SetAutoKill(true);
				if (tweenCompletion != null) {
					tweenParams.OnComplete(tweenCompletion.OnTweenComplete);
				}

				var tween = newEnemy.transform.DOLocalPath(worldWaypoints, speed, PathType.CatmullRom, PathMode.Full3D, tweenPathResolution)
					 //newEnemy.transform.DOLocalPath(theWaypoints, speed, PathType.CatmullRom, PathMode.TopDown2D)
				                    .SetAs(tweenParams).SetOptions(false).SetLookAt(lookAhead, -Vector3.forward)
				        ;

			}
		}
	}
}
