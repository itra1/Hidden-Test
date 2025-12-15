using System.Collections.Generic;
using Assets.Scripts.Providers.InteractionsItems.Common;
using UnityEngine.Events;

namespace Assets.Scripts.Providers.InteractionsItems.Handlers {
	public interface IGameInteractableItemsControlEventsHandler {
		UnityEvent<List<InteractionItemData>> OnReadyItemsChange { get; set; }
		UnityEvent<InteractionItemData> OnRemoveItem { get; set; }
		UnityAction OnItemsComplete { get; set; }

		void EmitItemsComplete();
		void EmitReadyItemsChange(List<InteractionItemData> items);
		void EmitRemoveItem(InteractionItemData item);
	}
}