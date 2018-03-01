using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.pedromr.games.shmup
{
	public class Turret : MonoBehaviour
	{
		public GameObject RotatingPart;
		public bool FacePlayer;
		public float MaxRotationSpeed;

		// Use this for initialization
		void Start()
		{
			
		}

		// Update is called once per frame
		void FixedUpdate()
		{
			var playerGO = GameManager.Instance.PlayerGO;

			if (FacePlayer && playerGO != null) {
				var rotateThis = (RotatingPart==null) ? transform : RotatingPart.transform;
				Debug.Log("Looking at "+playerGO.transform.position);
				//Quaternion.RotateTowards();
				if (MaxRotationSpeed <= 0)
				{
					rotateThis.LookAt(playerGO.transform);
				} else {
					var currentRotation = rotateThis.rotation;
					var desiredRotation = Quaternion.LookRotation(playerGO.transform.position - rotateThis.position);
					
					rotateThis.rotation = Quaternion.RotateTowards(currentRotation, desiredRotation, MaxRotationSpeed*Time.deltaTime);
				}
			}
		}
	}

}