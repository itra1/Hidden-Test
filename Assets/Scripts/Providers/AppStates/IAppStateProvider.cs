using Assets.Scripts.Providers.AppStates.Common;
using Cysharp.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts.Providers.AppStates {
	public interface IAppStateProvider {
		UnityAction OnStateChangeAction { get; set; }
		AppState CurrentState { get; }
		AppState OldState { get; }

		string CurrentStateName { get; }
		string OldStateName { get; }

		UniTask SetState(string stateName);
	}
}