using UnityEngine;
using System.Collections;

namespace com.pedromr.games.shmup
{
	public class DestroyOnTerrainContact : MonoBehaviour
	{
		public bool FromPlayer;
		public bool CollideWithTerrain;

		public GameObject TerrainCollisionEffect;

		private void OnCollisionEnter(Collision collision)
		{
			Debug.Log("Terrain layer "+UnityEngine.LayerMask.NameToLayer("Terrain"));
			Debug.Log("Collided w "+collision.gameObject.layer);
			if (CollideWithTerrain && collision.gameObject.layer == UnityEngine.LayerMask.NameToLayer("Terrain"))
			{
				if (TerrainCollisionEffect != null)
				{
					Instantiate(TerrainCollisionEffect, transform.position, transform.rotation, transform.parent);
				}
				Destroy(gameObject);
			}
		}
	}
}