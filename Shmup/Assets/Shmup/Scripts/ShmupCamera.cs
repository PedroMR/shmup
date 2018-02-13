using UnityEngine;

namespace com.pedromr.games.shmup
{
	public class ShmupCamera : MonoBehaviour
	{

		// The target we are following
		[SerializeField]
		private Transform target;
		// The distance in the x-z plane to the target
		//[SerializeField]
		//private float distance = 10.0f;
		// the height we want the camera to be above the target
		//[SerializeField]
		//private float height = 10.0f;

		[SerializeField]
		private float positionDamping;

		private Vector3 originalDelta;

		private Vector3 velocity = Vector3.zero;

		// Use this for initialization
		void Start() {
			originalDelta = this.transform.position - target.transform.position;
		}

		// Update is called once per frame
		void FixedUpdate()
		{
			// Early out if we don't have a target
			if (!target)
				return;

			var wantedPosition = target.transform.position + originalDelta;
			wantedPosition.x = 0;
			//this.transform.position = Vector3.Lerp(wantedPosition, transform.position, positionDamping * (1 - Mathf.Exp(-20 * Time.deltaTime)));


			//transform.Translate(velocity * Time.deltaTime);
			//var vel = wantedPosition - this.transform.position;
			transform.position = Vector3.SmoothDamp(transform.position, wantedPosition, ref velocity, positionDamping);
			//transform.Translate(vel * Time.deltaTime);
		}
	}
}