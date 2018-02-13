using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;

	public static GameManager Instance {
		get {
			return _instance;
		}
	}

	// Use this for initialization
	void Awake()
	{
		_instance = this;
		DontDestroyOnLoad(gameObject);
	}

	// Update is called once per frame
	void Update()
	{
			
	}
}
