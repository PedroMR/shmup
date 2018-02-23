using System.Collections;

namespace com.pedromr.games.shmup
{
	public interface ILoot
	{
		int GetAmount();
		string GetName(); // loc'ed
		string GetId(); // for persistence
		void AddToPlayerState(PlayerState playerState);
	}
}
