using Assets.Scripts.Providers.GameStates.Common;

namespace Assets.Scripts.Providers.GameStates.Factorys {
	public interface IGameStateFactory {
		T GetInstance<T>() where T : GameState;
		GameState GetInstance(string stateName);
	}
}