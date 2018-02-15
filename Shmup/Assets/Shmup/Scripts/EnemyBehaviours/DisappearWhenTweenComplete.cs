using UnityEngine;
using System.Collections;

namespace com.pedromr.games.shmup
{
	public class DisappearWhenTweenComplete : MonoBehaviour
	{
		public void OnTweenComplete()
		{
			Destroy(gameObject);
		}
	}
}