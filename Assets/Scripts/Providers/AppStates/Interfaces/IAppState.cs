using UnityEngine.Events;

namespace Assets.Scripts.Providers.AppStates.Interfaces
{
	public interface IAppState
	{
		UnityEvent<string, string> OnStateChange { get; set; }
		string State { get; }
		string OldState { get; }
	}
}