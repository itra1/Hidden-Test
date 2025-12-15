using Assets.Scripts.Installers.Components;
using Assets.Scripts.Providers.InteractionsItems.Settings;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers {
	[CreateAssetMenu(fileName = "GameSettingsScriptableInstaller", menuName = "App/Installers/GameSettingsScriptableInstaller")]
	public class GameSettingsScriptableInstaller :ScriptableObjectInstaller {
		[SerializeField] private InteractableItemsSettings _interactableItemsSettings;
		[SerializeField] private PrefabLibrary _prefabs;

		public override void InstallBindings() {
			_ = Container.Bind<InteractableItemsSettings>().FromInstance(_interactableItemsSettings).AsSingle().NonLazy();

			_ = Container.Bind<PrefabLibrary>().FromInstance(_prefabs).AsSingle().NonLazy();
		}

	}
}
