using Cysharp.Threading.Tasks;

namespace Assets.Scripts.Providers.GameStates.Interfaces {
	public interface IGameStateSet {
		UniTask StateGame();
		UniTask StateLoss();
		UniTask StateNone();
		UniTask StateWin();
	}
}
