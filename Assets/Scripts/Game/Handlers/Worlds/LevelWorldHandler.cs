using System.Collections.Generic;
using Assets.Scripts.Providers.InteractionsItems.Common;
using Assets.Scripts.Providers.InteractionsItems.Handlers;
using Assets.Scripts.Providers.Levels.Common;
using Assets.Scripts.Scene.Interfaces;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game.Handlers.Worlds {
	public class LevelWorldHandler :ILevelWorldHandler, ILevelWorldItems {
		private readonly DiContainer _diContainer;
		private readonly IScene _scene;
		private readonly IGameInteractableItemsControlEventsHandler _itemsControlHandler;
		private LevelData _currentLevel;
		private LevelWorld _wordObject;

		public List<InteractionItemWorld> InteractionItems => _wordObject != null ? _wordObject.InteractionItems : new();

		public LevelWorldHandler(DiContainer diContainer, IScene scene, IGameInteractableItemsControlEventsHandler itemsControlHandler) {
			_diContainer = diContainer;
			_scene = scene;
			_itemsControlHandler = itemsControlHandler;

			_itemsControlHandler.OnRemoveItem.AddListener(GameItemRemoveListener);
			_itemsControlHandler.OnReadyItemsChange.AddListener(ReadyChangeItemsListener);
		}

		private void ReadyChangeItemsListener(List<InteractionItemData> readyItems) {
			foreach (var item in readyItems) {
				var interactItem = _wordObject.InteractionItems.Find(x => x.Uuid == item.Uuid);

				if (interactItem != null) {
					interactItem.ReadyTap();
				}
			}
		}

		private void GameItemRemoveListener(InteractionItemData removeItem) {
			if (_wordObject == null)
				return;

			var interactItem = _wordObject.InteractionItems.Find(x => x.Uuid == removeItem.Uuid);

			if (interactItem != null) {
				interactItem.Remove();
			}
		}

		public void SetLevel(LevelData level) {
			_currentLevel = level;
			ClearIfNeed();
			CreateLevel();
		}

		private void ClearIfNeed() {
			if (_wordObject != null) {
				Object.Destroy(_wordObject.gameObject);
			}
		}

		private void CreateLevel() {

			_wordObject = Object.Instantiate(_currentLevel.LevelPrefab, _scene.World).GetComponent<LevelWorld>();

			if (!_wordObject.TryGetComponent<ILevelWorld>(out var world)) {
				throw new System.NullReferenceException("No exists level ILevelWorld component");
			}

			_diContainer.Inject(world);

			world.InitInGame(_currentLevel);
		}
	}
}
