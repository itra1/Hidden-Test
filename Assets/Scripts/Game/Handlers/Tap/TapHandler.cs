using Assets.Scripts.Providers.InteractionsItems.Handlers;
using Assets.Scripts.Scene.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Game.Handlers.Tap {
	public class TapHandler :ITapHandler {
		private readonly IScene _scene;
		private readonly IGameInteractionItemsTap _itemsTapHandler;

		public TapHandler(IScene scene, IGameInteractionItemsTap itemsTapHandler) {
			_scene = scene;
			_itemsTapHandler = itemsTapHandler;
		}

		public void ScreenTap(Vector2 point) {

			Vector2 worldPos = Camera.main.ScreenToWorldPoint(point);

			RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

			if (hit.collider != null && hit.collider.TryGetComponent<ITapItem>(out var tapItem)) {
				_itemsTapHandler.TapItem(tapItem);
			}
		}
	}
}
