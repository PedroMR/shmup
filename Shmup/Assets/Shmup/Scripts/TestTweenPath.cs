using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TestTweenPath : MonoBehaviour
{
	public Vector3[] waypoints;
	public float speed;

	//public PathManager path;

	// Use this for initialization
	void Start()
	{
/*		if (path != null) {
			// firstPoint is our starting position
			var firstPoint = path.GetWaypoint(0).localPosition;

			// we don't need to go to the starting point
			waypoints = new Vector3[path.GetWaypointCount()-1];

			for (var i = 0; i < path.GetWaypointCount()-1; i++) {
				// correct all waypoints based on start position
				waypoints[i] = path.GetWaypoint(i+1).localPosition - firstPoint;
			}
		}
		*/
		transform.DOLocalPath(waypoints, speed, PathType.CatmullRom, PathMode.Full3D)
		         .SetEase(Ease.Linear).SetLoops(0).SetOptions(false).SetLookAt(0.1f).SetSpeedBased();


	}

	void OnDrawGizmos()
	{
		/*// Surprisingly, this worked, but throws weird exceptions
		var oldPosition = path.transform.position;
		path.transform.position = transform.position;
		path.SendMessage("OnDrawGizmos");
		path.transform.position = oldPosition;
		*/
	}
}
