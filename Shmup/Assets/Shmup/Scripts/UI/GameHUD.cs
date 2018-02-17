using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace com.pedromr.games.shmup
{
	public class GameHUD : MonoBehaviour
	{
		int displayedScrap;
		[SerializeField] private Text scrapAmountLabel;

		// Use this for initialization
		void Start()
		{

		}

		public void UpdateScrap(int newValue)
		{
			displayedScrap = newValue;
			scrapAmountLabel.text = newValue.ToString();
		}
	}
}