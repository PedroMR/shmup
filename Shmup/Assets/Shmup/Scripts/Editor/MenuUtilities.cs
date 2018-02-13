using System;
using UnityEngine;
using UnityEditor;

namespace com.pedromr.games.shmup {
	
	public class MenuUtilities
	{
		[MenuItem("PedroMR/Scenes/Game")]
		public static void SceneGame()
		{
			if (UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
				UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Assets/Shmup/Scenes/Game.unity");
		}
	}

}
