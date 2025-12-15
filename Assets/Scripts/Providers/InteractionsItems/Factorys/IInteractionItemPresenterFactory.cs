using Assets.Scripts.Providers.Ui.Components;

namespace Assets.Scripts.Providers.InteractionsItems.Factorys {
	public interface IInteractionItemPresenterFactory {
		InteractionItemPresenter GetInstance();
	}
}