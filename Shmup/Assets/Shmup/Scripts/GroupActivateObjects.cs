using UnityEngine;
using System.Collections;

namespace com.pedromr.games.shmup
{
	public class GroupActivateObjects : MonoBehaviour
	{
		public GameObject[] objectList;

		public bool defaultActive;

		// Use this for initialization
		void Start()
		{
			SetAllActive(defaultActive);
		}

		public void SetAllActive(bool activate)
		{
			foreach (var go in objectList)
			{
				go.SetActive(activate);
			}
		}
	}
}
