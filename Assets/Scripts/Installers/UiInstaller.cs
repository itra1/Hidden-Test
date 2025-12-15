using Assets.Scripts.Providers.Ui;
using Assets.Scripts.Providers.Ui.Controllers.Factorys;
using Assets.Scripts.Providers.Ui.Presenters.Factorys;
using Zenject;

namespace Assets.Scripts.Installers {
	public class UiInstaller :MonoInstaller {
		public override void InstallBindings() {
			_ = Container.BindInterfacesTo<WindowPresenterControllerFactory>().AsSingle().NonLazy();
			_ = Container.BindInterfacesTo<WindowPresenterFactory>().AsSingle().NonLazy();

			_ = Container.BindInterfacesTo<UiProvider>().AsSingle().NonLazy();
		}
	}
}
