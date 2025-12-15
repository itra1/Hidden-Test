using Assets.Scripts.Providers.Ui.Base;
using Assets.Scripts.Providers.Ui.Controllers.Attributes;
using Assets.Scripts.Providers.Ui.Controllers.Base;
using Assets.Scripts.Providers.Ui.Presenters;

namespace Assets.Scripts.Providers.Ui.Controllers
{
	[UiController(WindowPresenterType.Splash, WindowPresenterNames.Loader)]
	public class LoaderPresenterController : WindowPresenterController<LoaderPresenter>
	{
	}
}
