using System.Collections.Generic;
using Assets.Scripts.Game.Handlers.Tap;
using Assets.Scripts.Providers.InteractionsItems.Common;
using Assets.Scripts.Providers.Levels.Common;

namespace Assets.Scripts.Providers.InteractionsItems.Handlers {
	public class GameInteractionItemsHandler :IGameInteractionItemsHandler, IGameInteractionItemsHandlerSet, IGameInteractionItemsTap {

		private readonly ILevelWorldItems _worldItems;
		private readonly IGameInteractableItemsControlEventsHandler _itemsControllHandler;
		private List<InteractionItemData> _itemsInWorld = new();
		private List<InteractionItemData> _interactionItems = new();
		private int _nextWorldItemIndex = 0;

		public GameInteractionItemsHandler(ILevelWorldItems worldItems, IGameInteractableItemsControlEventsHandler itemsControllHandler) {
			_worldItems = worldItems;
			_itemsControllHandler = itemsControllHandler;
		}

		public void StartLevel(List<InteractionItemData> items) {
			_nextWorldItemIndex = 0;
			_interactionItems.Clear();
			_itemsInWorld.Clear();
			_itemsInWorld.AddRange(items);

			FirstItemsInit();
			_itemsControllHandler.EmitReadyItemsChange(_interactionItems);
		}

		private void FirstItemsInit() {
			while (_interactionItems.Count < 3) {

				if (_nextWorldItemIndex >= _itemsInWorld.Count)
					return;

				var item = _itemsInWorld[_nextWorldItemIndex];

				if (item.IsEnable) {
					_interactionItems.Add(item);
				}
				_nextWorldItemIndex++;
			}
		}

		private void NextItem() {
			while (_nextWorldItemIndex < _itemsInWorld.Count) {

				var item = _itemsInWorld[_nextWorldItemIndex];

				if (item.IsEnable) {
					_interactionItems.Add(item);
					_nextWorldItemIndex++;
					return;
				}
				_nextWorldItemIndex++;
			}
		}

		public void TapItem(ITapItem item) {
			var itemRemove = _interactionItems.Find(x => x.Uuid == item.Uuid);
			_itemsControllHandler.EmitRemoveItem(itemRemove);
			_ = _interactionItems.Remove(itemRemove);

			NextItem();

			_itemsControllHandler.EmitReadyItemsChange(_interactionItems);
			if (_interactionItems.Count <= 0) {
				_itemsControllHandler.EmitItemsComplete();
			}
		}
	}
}
