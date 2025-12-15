using UnityEngine;

namespace Assets.Scripts.Providers.InteractionsItems.Settings
{
	[CreateAssetMenu(fileName = "InteractableItemsSettings", menuName = "App/InteractionItema/InteractableItemsSettings")]
	public class InteractableItemsSettings : ScriptableObject
	{
		[SerializeField] private GameObject _ItemPresenterPrefab;

		public GameObject ViewPresenterPrefab => _ItemPresenterPrefab;
	}
}
