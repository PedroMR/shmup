using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.pedromr.games.shmup {
	public class PathCenter : MonoBehaviour {

		[SerializeField]
		private float speed;

		public Boundary shipBounds;

		void Start () {
			
		}
		
		void FixedUpdate () {
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}

		public void OnDrawGizmos()
		{
			Gizmos.color = Color.blue;

			var leftBack = transform.TransformPoint(shipBounds.xMin, 0, shipBounds.zMin);
			var leftFore = transform.TransformPoint(shipBounds.xMin, 0, shipBounds.zMax);
			var rightBack = transform.TransformPoint(shipBounds.xMax, 0, shipBounds.zMin);
			var rightFore = transform.TransformPoint(shipBounds.xMax, 0, shipBounds.zMax);

			Gizmos.DrawLine(leftBack, leftFore);
			Gizmos.DrawLine(leftFore, rightFore);
			Gizmos.DrawLine(rightFore, rightBack);
			Gizmos.DrawLine(rightBack, leftBack);
		}
	}
}
