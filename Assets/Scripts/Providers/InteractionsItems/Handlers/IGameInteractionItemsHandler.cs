using System.Collections.Generic;
using Assets.Scripts.Providers.InteractionsItems.Common;

namespace Assets.Scripts.Providers.InteractionsItems.Handlers {
	public interface IGameInteractionItemsHandler {
		void StartLevel(List<InteractionItemData> items);
	}
}