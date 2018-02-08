using UnityEngine;

namespace com.pedromr.games.shmup
{
	[ExecuteInEditMode]
	public class LevelData : MonoBehaviour
	{
		public GameObject playerSpawn;
		public PathCenter pathCenter;

		public void OnDrawGizmos()
		{

			var forward = playerSpawn.transform.TransformVector(Vector3.forward);
			var right = playerSpawn.transform.TransformVector(Vector3.right);

			var laneLength = 1000f; //TODO determine end point

			Vector3 startPos = playerSpawn.transform.position + pathCenter.shipBounds.zMin * forward;

			Gizmos.DrawWireSphere(startPos, 1);

			var rightMostStart = right * pathCenter.shipBounds.xMax + startPos;
			var leftMostStart = right * pathCenter.shipBounds.xMin + startPos;

			var endPos = startPos + (laneLength + pathCenter.shipBounds.zMax) * forward;
			var rightMostEnd = right * pathCenter.shipBounds.xMax + endPos;
			var leftMostEnd = right * pathCenter.shipBounds.xMin + endPos;

			Gizmos.color = Color.magenta;
			Gizmos.DrawLine(leftMostStart, rightMostStart);
			Gizmos.DrawLine(leftMostEnd, rightMostEnd);
			Gizmos.DrawLine(leftMostStart, leftMostEnd);
			Gizmos.DrawLine(rightMostStart, rightMostEnd);

			var tickWidth = 2f; //TODO constant?
			var tickDistance = 50;
			for (var tickInterval = tickDistance; tickInterval < laneLength; tickInterval += tickDistance)
			{
				var tickCenter = startPos + tickDistance * forward;
				Gizmos.DrawLine(tickCenter - right * tickWidth, tickCenter + right * tickWidth);
			}


			//TODO non-straight lanes
		}

	}

}