using Cysharp.Threading.Tasks;

namespace Assets.Scripts.Providers.AppStates.Interfaces {
	public interface IAppStateSet {
		UniTask StateGame();
		UniTask StateLoading();
		UniTask StateMenu();
	}
}
