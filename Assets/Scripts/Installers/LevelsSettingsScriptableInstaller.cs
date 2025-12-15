using Assets.Scripts.Settings;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers {
	[CreateAssetMenu(fileName = "LevelsSettingsScriptableInstaller", menuName = "App/Installers/LevelsSettingsScriptableInstaller")]
	public class LevelsSettingsScriptableInstaller :ScriptableObjectInstaller {
		[SerializeField] private LevelListSettings _levelListSettings;
		public override void InstallBindings() {
			_ = Container.BindInterfacesTo<LevelListSettings>().FromScriptableObject(_levelListSettings).AsSingle().NonLazy();
		}
	}
}
