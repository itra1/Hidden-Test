using System.Collections.Generic;
using Assets.Scripts.Common;
using Assets.Scripts.Providers.InteractionsItems.Common;
using Assets.Scripts.Providers.Levels.Base;
using Assets.Scripts.Providers.Levels.Settings;
using StringDrop;
using UnityEngine;

namespace Assets.Scripts.Providers.Levels.Common {
	[CreateAssetMenu(fileName = "LevelData", menuName = "App/Game/Levels/LevelData")]
	public class LevelData :ScriptableObject, IUuid {
		[SerializeField] private string _uuid;
		[SerializeField] private GameObject _levelPrefab;
		[SerializeField] private TimerData _timer;
		[SerializeField][StringDropList(typeof(ItemsVisibleList), notEmpty: true)] private string _itemSelectList;
		[SerializeField] private List<InteractionItemData> _items;

		public string Uuid => _uuid;
		public List<InteractionItemData> Items => _items;
		public GameObject LevelPrefab => _levelPrefab;
		public string ItemSelectList => _itemSelectList;
		public TimerData Timer => _timer;

		public LevelData() {
			_uuid = System.Guid.NewGuid().ToString();
		}

		public void InteractiveItemsSet(List<InteractionItemData> itemsList)
		=> _items = itemsList;

		public void LevelPrefabSet(GameObject prefab)
		=> _levelPrefab = prefab;

		public void TimerSet(TimerData timer)
		=> _timer = timer;

		public void VisibleListSet(string value)
		=> _itemSelectList = value;

		public void UuidSet(string value) => _uuid = value;
	}
}
