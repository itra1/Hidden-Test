using Cysharp.Threading.Tasks;

namespace Assets.Scripts.Providers.Ui.Presenters.Base
{
	public interface IWindowPresenter
	{
		bool IsVisible { get; }
		UniTask<bool> Initialize();
	}
}