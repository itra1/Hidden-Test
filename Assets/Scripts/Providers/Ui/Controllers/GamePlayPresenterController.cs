using Assets.Scripts.Providers.Ui.Base;
using Assets.Scripts.Providers.Ui.Controllers.Attributes;
using Assets.Scripts.Providers.Ui.Controllers.Base;
using Assets.Scripts.Providers.Ui.Presenters;

namespace Assets.Scripts.Providers.Ui.Controllers
{
	[UiController(WindowPresenterType.Window, WindowPresenterNames.GamePlay)]
	public class GamePlayPresenterController : WindowPresenterController<GamePlayPresenter>
	{
	}
}
