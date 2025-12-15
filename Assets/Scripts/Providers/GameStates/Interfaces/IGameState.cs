using UnityEngine.Events;

namespace Assets.Scripts.Providers.GameStates.Interfaces {
	public interface IGameState {
		string State { get; }
		UnityEvent<string, string> OnStateChange { get; set; }
		string OldState { get; }
	}
}
