using Assets.Scripts.Providers.Levels.Settings;
using Assets.Scripts.Settings;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Editors.Installer
{
	[InitializeOnLoad]
	public class EditorInstaller : EditorStaticInstaller<EditorInstaller>
	{
		private string AppSettingsPath => "Settings/AppSettings";

		static EditorInstaller()
		{
			EditorApplication.QueuePlayerLoopUpdate();
			Install();
		}

		public override void InstallBindings()
		{
			var appSettings = Resources.Load<AppSettings>(AppSettingsPath);
			_ = Container.BindInterfacesTo<AppSettings>()
				.FromScriptableObject(appSettings)
				.AsSingle().NonLazy();

			ResolveAll();
		}

		private void ResolveAll()
		{
			_ = Container.Resolve<ILevelsSettings>();
		}
	}
}