using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	void Start()
	{
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "PlayerWeapon")
		{
			// Destroyed!
			if (explosion != null)
			{
				Instantiate(explosion, transform.position, transform.rotation);
			}
			Destroy(gameObject);
			//gameController.AddScore(scoreValue);
		}

		if (other.tag == "Player")
		{
			Destroy(other.gameObject);
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			//gameController.GameOver();
		}
	}
}
