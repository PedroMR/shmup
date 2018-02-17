using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

namespace com.pedromr.games.shmup
{
	public class GameManager : MonoBehaviour
	{
		private static GameManager _instance;
		private LevelData runningLevel;

		[SerializeField]
		private GameObject playerPrefab;

		private PlayerState playerState;

		private GameHUD hud;

		public static GameManager Instance
		{
			get
			{
				if (_instance == null) {
					var go = new GameObject("GameManager_jit");
					_instance = go.AddComponent<GameManager>();
				}
				return _instance;
			}
		}

		// Use this for initialization
		void Awake()
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
			hud = GetComponentInChildren<GameHUD>();
			LoadPlayerState();
			hud.UpdateScrap(playerState.scrap);
		}

		private void LoadPlayerState()
		{
			playerState = ScriptableObject.CreateInstance<PlayerState>();
			
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void OnLevelButtonPressed(int number)
		{
			LoadLevel("Level "+number);
		}

		void LoadLevel(string levelName, string sceneFile = null)
		{
			StartCoroutine(AsyncLoadLevel(levelName, sceneFile));
		}


		IEnumerator AsyncLoadLevel(string levelName, string sceneFile = null)
		{
			if (string.IsNullOrEmpty(sceneFile))
				sceneFile = "Shmup/Scenes/"+levelName ;//+ ".scene";

			yield return null;

			AsyncOperation ao = SceneManager.LoadSceneAsync(sceneFile);
			while (!ao.isDone) {
				yield return null;

			}

			yield return null;

			PrepareLevel(levelName);

			yield return null;
		}

		void PrepareLevel(string levelName)
		{
			var scene = SceneManager.GetActiveScene();
			var rootObjects = scene.GetRootGameObjects();
			GameObject levelDataRoot = null;
			foreach(var root in rootObjects) {
				Debug.Log("root object "+root.name);
				if (root.name == "Level Data")
				{
					levelDataRoot = root;
					break;
				}
			}
			if (levelDataRoot == null) {
				Debug.LogError("Couldn't find 'Level Data' object for level "+levelName);
			}
			var levelData = levelDataRoot.GetComponentsInChildren<LevelData>(true);

			LevelData theLevel = null;

			foreach(var level in levelData) {
				Debug.Log("Checking level "+level.name+" in "+level.gameObject.name);
				level.gameObject.SetActive(false);
				if (levelName.Equals(level.gameObject.name)) {
					Debug.Log("Found level '"+level.name+"'");
					if (theLevel != null) {
						Debug.LogError("Duplicate level found!");
					}
					theLevel = level;
				}
			}
			if (theLevel == null) {
				Debug.LogError("Couldn't find level '"+levelName+"'");
			} else {
				StartLevel(theLevel);
			}
		}

		internal void OnEndReached()
		{
			Debug.Log("It's over");
			SceneManager.LoadScene("Game");
		}

		internal GameObject CreatePlayer()
		{
			var playerGO = Instantiate(playerPrefab);
			return playerGO;
		}

		void StartLevel(LevelData level)
		{
			StopRunningLevel();
			runningLevel = level;
			runningLevel.gameObject.SetActive(true);

			var shmupCamera = level.GetComponentInChildren<ShmupCamera>();
			shmupCamera.OnLevelLoaded();

			var pathCenter = level.GetComponentInChildren<PathCenter>();
			pathCenter.OnLevelLoaded();
		}

		private void StopRunningLevel()
		{
			if (runningLevel != null)
			{
				runningLevel.gameObject.SetActive(false);
				Destroy(runningLevel.gameObject);
				runningLevel = null;
			}
		}
	}
}