namespace Assets.Scripts.Providers.Ui.Controllers.Factorys {
	public interface IWindowPresenterControllerFactory {
		T GetInstance<T>();
	}
}