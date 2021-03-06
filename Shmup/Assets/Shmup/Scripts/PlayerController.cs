﻿using UnityEngine;
using System.Collections;
using System;
using DG.Tweening;

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
		//public Boundary boundary;
		public PathCenter pathCenter;

		public GameObject shot;
		public Transform shotSpawn;
		public float fireRate;

		[SerializeField]
		private GameObject removalEffect;

		private float nextFire;

		void Start()
		{
			if (pathCenter == null) pathCenter = transform.GetComponentInParent<PathCenter>();
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
			{
				Die();
			}
		}

		public void Die()
		{
			if (removalEffect != null) {
				Instantiate(removalEffect, transform.position, transform.rotation);
			}
			Destroy(this.gameObject);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Obstacles"))
				Die();

		}

		public void Flying(bool active)
		{
			var groupActivate = GetComponent<GroupActivateObjects>();
			if (groupActivate != null) groupActivate.SetAllActive(active);
		}

		public void StartFlying()
		{
			Flying(true);
			pathCenter.running = true;
		}

		void FixedUpdate()
		{
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
			var velocity = movement * speed * Time.deltaTime;
			transform.localPosition += velocity;
			//rb.velocity = velocity;

			transform.localPosition = new Vector3
			(
					Mathf.Clamp(transform.localPosition.x, pathCenter.shipBounds.xMin, pathCenter.shipBounds.xMax),
					0.0f,
					Mathf.Clamp(transform.localPosition.z, pathCenter.shipBounds.zMin, pathCenter.shipBounds.zMax)
			);

			transform.rotation = Quaternion.Euler(0.0f, 0.0f, movement.x * -tilt);
		}

		internal void WarpInAndFly()
		{
			var sequence = DOTween.Sequence();
			var tweenIn = transform.DOScale(0.1f, 0.5f).SetEase(Ease.InCirc).From();

			sequence.Append(tweenIn).AppendInterval(0.4f).AppendCallback(StartFlying).Play();
		}

		internal void WarpOut()
		{
			Flying(false);
			transform.DOLocalMoveZ(6, 1f);
			var tweenOut = transform.DOScale(0.1f, 0.6f).SetDelay(0.5f).SetEase(Ease.OutCirc).OnComplete(HideShip);
		}

		internal void HideShip()
		{
			gameObject.SetActive(false);
		}
	}
}