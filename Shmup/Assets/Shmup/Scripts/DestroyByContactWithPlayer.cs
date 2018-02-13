using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private Done_GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
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