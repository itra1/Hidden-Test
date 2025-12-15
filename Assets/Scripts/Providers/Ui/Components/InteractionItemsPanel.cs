using System.Collections.Generic;
using Assets.Scripts.Common;
using Assets.Scripts.Game;
using Assets.Scripts.Providers.InteractionsItems.Common;
using Assets.Scripts.Providers.InteractionsItems.Factorys;
using Assets.Scripts.Providers.InteractionsItems.Handlers;
using Assets.Scripts.Providers.Levels.Common;
using Assets.Scripts.Providers.Ui.Presenters.Interfaces;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Providers.Ui.Components {
	public class InteractionItemsPanel :MonoBehaviour, IInjection, IUiVisibleHandler {

		[SerializeField] private RectTransform[] _itemsPositions;

		private List<InteractionItemPresenter> _uiItems = new();

		private IGameInteractableItemsControlEventsHandler _itemsControlHandler;
		private IInteractionItemPresenterFactory _factory;
		private IGameBehaviourEventsHandler _gameBehaviourEventsHandler;
		private RectTransform _rectTransform;
		private int _itemDistance = 200;
		private LevelData _levelData;
		private bool _isFirst = true;

		private RectTransform RT => _rectTransform == null
		? _rectTransform = GetComponent<RectTransform>()
		: _rectTransform;

		[Inject]
		private void Constructor(
			IGameInteractableItemsControlEventsHandler itemsControlHandler,
			IInteractionItemPresenterFactory factory, IGameBehaviourEventsHandler gameBehaviourEventsHandler) {

			_itemsControlHandler = itemsControlHandler;
			_factory = factory;
			_gameBehaviourEventsHandler = gameBehaviourEventsHandler;
		}

		public void Show() {
			_isFirst = true;
			SubscribeEvents();
		}
		public void Hide() {
			UnSubscribeEvents();
		}

		private void SubscribeEvents() {
			_itemsControlHandler.OnReadyItemsChange.AddListener(ReadyItemsChangeListener);
			_gameBehaviourEventsHandler.OnSetLevelData.AddListener(SetLevelDataListener);
		}

		private void UnSubscribeEvents() {
			_itemsControlHandler.OnReadyItemsChange.RemoveListener(ReadyItemsChangeListener);
			_gameBehaviourEventsHandler.OnSetLevelData.RemoveListener(SetLevelDataListener);
		}

		private void SetLevelDataListener(LevelData levelData) {
			foreach (var el in _uiItems)
				Object.Destroy(el.gameObject);
			_uiItems.Clear();
			_isFirst = true;
			_levelData = levelData;
		}

		private void ReadyItemsChangeListener(List<InteractionItemData> readyItems) {
			if (_isFirst) {
				FirstItemList(readyItems);
			} else {
				_ = UpdatItemsList(readyItems);
			}
		}

		private void FirstItemList(List<InteractionItemData> readyItems) {
			_isFirst = false;

			var allCount = readyItems.Count;
			float allWidth = (allCount - 1) * _itemDistance;
			float startX = 0;

			if (allCount > 1)
				startX = -allWidth / 2;
			for (int i = 0; i < allCount; i++) {

				InteractionItemPresenter instance = _factory.GetInstance();
				instance.SetData(readyItems[i], _levelData.ItemSelectList);
				var rectTransform = instance.RectTransform;
				rectTransform.SetParent(transform);
				rectTransform.localScale = Vector2.one;
				rectTransform.anchoredPosition = new Vector3(startX + (_itemDistance * i), 0, 0);
				_uiItems.Add(instance);
			}
		}

		private async UniTask UpdatItemsList(List<InteractionItemData> readyItems) {

			List<InteractionItemPresenter> forRemove = new();
			List<UniTask> removeActions = new();
			//Удаление ранее
			foreach (InteractionItemPresenter item in _uiItems) {
				if (!readyItems.Contains(item.Data)) {
					removeActions.Add(item.Remove());
					forRemove.Add(item);
				}
			}
			foreach (var item in forRemove) {
				_ = _uiItems.Remove(item);
			}
			await UniTask.WhenAll(removeActions);

			// перепозиционируем

			int allCount = readyItems.Count;

			float allWidth = (allCount - 1) * _itemDistance;
			float startX = 0;

			if (allCount > 1)
				startX = -allWidth / 2;

			int itemIndex = 0;

			foreach (var item in _uiItems) {
				var sourceAnchor = item.RectTransform.anchoredPosition;
				_ = DOTween.To(() => item.RectTransform.anchoredPosition,
				(x) => item.RectTransform.anchoredPosition = x,
				new Vector2(startX + (itemIndex * _itemDistance), sourceAnchor.y), 0.2f);
				itemIndex++;
			}
			await UniTask.Delay(200);

			foreach (var elem in readyItems) {
				if (_uiItems.Find(x => x.Data.Uuid == elem.Uuid) != null)
					continue;

				InteractionItemPresenter instance = _factory.GetInstance();
				instance.SetData(elem, _levelData.ItemSelectList);
				var rectTransform = instance.RectTransform;
				rectTransform.SetParent(transform);
				rectTransform.localScale = Vector2.one;
				rectTransform.anchoredPosition = new Vector3(startX + (_itemDistance * itemIndex), 0, 0);
				_uiItems.Add(instance);
				_ = instance.Show();
				itemIndex++;
			}
		}
	}
}
