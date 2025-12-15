using Assets.Scripts.Scene;
using Zenject;

namespace Assets.Scripts.Installers {
	public class CoreInstaller :MonoInstaller {
		public override void InstallBindings() {
			var sceneStructure = FindFirstObjectByType<SceneStructure>()
			?? throw new System.NullReferenceException("No sxists SceneStructure object in scene");

			_ = Container.BindInterfacesTo<SceneStructure>().FromInstance(sceneStructure).AsSingle().NonLazy();

		}
	}
}
