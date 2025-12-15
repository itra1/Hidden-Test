using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Providers.InteractionsItems.Common;
using UnityEngine;

namespace Assets.Scripts.Providers.Levels.Common {
	public class LevelWorld :MonoBehaviour, ILevelWorld {
		[SerializeField] private SpriteRenderer _background;
		[SerializeField] private Transform _itemsParent;
		[SerializeField][HideInInspector] private string _uuid;

		private List<InteractionItemWorld> _interactionItems;
		private LevelData _levelData;

		public string Uuid { get => _uuid; set => _uuid = value; }
		public Transform ItemsParent => _itemsParent;
		public SpriteRenderer Background => _background;
		public List<InteractionItemWorld> InteractionItems => _interactionItems;

		public void UuidSet(string value) => _uuid = value;
		public void InitInGame(LevelData levelData) {
			_levelData = levelData;
			UpdateInteractionItems();
		}

		private void UpdateInteractionItems() {
			_interactionItems = GetComponentsInChildren<InteractionItemWorld>().ToList();

			foreach (var item in _interactionItems) {
				var itemWord = _levelData.Items.Find(x => x.Uuid == item.Uuid);

				item.InitData();
			}
		}
	}
}
