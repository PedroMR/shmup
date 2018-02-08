using UnityEngine;
using System.Collections;

namespace com.pedromr.games.shmup
{
	[System.Serializable]
	public class Boundary
	{
		public float xMin, xMax, zMin, zMax;
	}

	
	public class PlayerController : MonoBehaviour
	{
		public float forwardSpeed;
		public float speed;
		public float tilt;
		public Boundary boundary;

		public GameObject shot;
		public Transform shotSpawn;
		public float fireRate;

		private float nextFire;

		private Rigidbody rb;

		void Start()
		{
			this.rb = GetComponent<Rigidbody>();
		}

		void Update()
		{
			if (Input.GetButton("Fire1") && Time.time > nextFire)
			{
				nextFire = Time.time + fireRate;
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				GetComponent<AudioSource>().Play();
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.CompareTag("Obstacles"))
				Destroy(this.gameObject);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Obstacles"))
				Destroy(this.gameObject);

		}

		void FixedUpdate()
		{
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
			rb.velocity = movement * speed;

			rb.position = new Vector3
			(
				Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
				0.0f,
					rb.position.z
				//Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
			);

			rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

			rb.velocity = movement * speed + forwardSpeed * Vector3.forward;
		}
	}
}