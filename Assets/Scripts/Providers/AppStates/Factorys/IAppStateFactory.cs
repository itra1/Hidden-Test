using Assets.Scripts.Providers.AppStates.Common;

namespace Assets.Scripts.Providers.AppStates.Factorys
{
	public interface IAppStateFactory
	{
		AppState GetInstance(string stateName);
		T GetInstance<T>() where T : AppState;
	}
}