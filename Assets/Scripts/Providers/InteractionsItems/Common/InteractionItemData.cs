using Unity.Collections;
using UnityEngine;

namespace Assets.Scripts.Providers.InteractionsItems.Common {
	[System.Serializable]
	public struct InteractionItemData :IInteractionData {
		[SerializeField] private string _title;
		[SerializeField][ReadOnly] private string _uuid;
		[SerializeField] private bool _isEnable;
		[SerializeField] private Sprite _icone;

		public readonly string Uuid => _uuid;
		public readonly string Title => _title;
		public readonly bool IsEnable => _isEnable;
		public readonly Sprite Icone => _icone;

		public void Copy(IInteractionData source) {
			_isEnable = true;
			_uuid = source.Uuid;
			_title = source.Title;
			_icone = source.Icone;
		}

		public void UuidSet(string value) => _uuid = value;
	}
}
