using UnityEngine;

namespace Assets.Scripts.Installers.Components {
	[System.Serializable]
	public struct PrefabLibrary {
		[SerializeField] private GameObject _interactionItemUiPrefab;

		public GameObject InteractionItemUiPrefab => _interactionItemUiPrefab;
	}
}
