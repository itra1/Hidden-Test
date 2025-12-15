using System.Collections.Generic;
using Assets.Scripts.Providers.InteractionsItems.Common;
using UnityEngine.Events;

namespace Assets.Scripts.Providers.InteractionsItems.Handlers {
	public class GameInteractableItemsControlEventsHandler :IGameInteractableItemsControlEventsHandler {

		public UnityEvent<List<InteractionItemData>> OnReadyItemsChange { get; set; } = new();
		public UnityEvent<InteractionItemData> OnRemoveItem { get; set; } = new();
		public UnityAction OnItemsComplete { get; set; }

		public void EmitReadyItemsChange(List<InteractionItemData> items) {
			OnReadyItemsChange?.Invoke(items);
		}
		public void EmitRemoveItem(InteractionItemData item) {
			OnRemoveItem?.Invoke(item);
		}
		public void EmitItemsComplete() {
			OnItemsComplete?.Invoke();
		}
	}
}
