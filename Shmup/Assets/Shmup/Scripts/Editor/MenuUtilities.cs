using System;
using UnityEngine;
using UnityEditor;

namespace com.pedromr.games.shmup {
	
	public class MenuUtilities
	{
		[MenuItem("PedroMR/Scenes/Game")] public static void SceneGame() { CheckAndLoad("Game"); }
		[MenuItem("PedroMR/Scenes/Level 1")] public static void SceneLevel1() { CheckAndLoad("Level 1"); }
		[MenuItem("PedroMR/Scenes/Level 2")] public static void SceneLevel2() { CheckAndLoad("Level 2"); }

		public static void CheckAndLoad(string name)
		{
			if (UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
				UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets/Shmup/Scenes/"+name+".unity");
		}
	}

}
