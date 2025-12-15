using Assets.Scripts.Providers.GameStates.Common;
using Cysharp.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts.Providers.GameStates {
	public interface IGameStateProvider {
		UnityAction OnStateChangeAction { get; set; }
		GameState CurrentState { get; }
		GameState OldState { get; }

		string CurrentStateName { get; }
		string OldStateName { get; }

		UniTask SetState(string stateName);
	}
}