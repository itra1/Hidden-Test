namespace Assets.Scripts.Providers.Ui.Presenters.Factorys {
	public interface IWindowPresenterFactory {
		T GetInstance<T>();
	}
}