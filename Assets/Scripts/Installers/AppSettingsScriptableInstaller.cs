using Assets.Scripts.Settings;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers {
	[CreateAssetMenu(fileName = "AppSettingsScriptableInstaller", menuName = "App/Installers/AppSettingsScriptableInstaller")]
	public class AppSettingsScriptableInstaller :ScriptableObjectInstaller {
		[SerializeField] private AppSettings _appSettings;
		public override void InstallBindings() {
			_ = Container.BindInterfacesAndSelfTo<AppSettings>().FromScriptableObject(_appSettings).AsSingle().NonLazy();
		}
	}
}
