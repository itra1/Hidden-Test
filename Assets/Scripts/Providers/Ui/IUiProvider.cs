namespace Assets.Scripts.Providers.Ui {
	public interface IUiProvider {
		T GetController<T>();
	}
}