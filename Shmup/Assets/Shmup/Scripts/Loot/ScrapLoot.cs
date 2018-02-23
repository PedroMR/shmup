using UnityEngine;
using System.Collections;

namespace com.pedromr.games.shmup
{
	public class ScrapLoot : ILoot
	{
		private int amount;

		public ScrapLoot(int amount) {
			this.amount = amount;
		}

		public string GetName() {
			return "Scrap"; //TODO loc eventually
		}

		public string GetId() {
			return "scrap";
		}

		public int GetAmount() {
			return amount;
		}

		public void AddToPlayerState(PlayerState playerState) {
			playerState.scrap += amount;
		}
	}
}