using Assets.Scripts.App;
using Assets.Scripts.Game;
using Assets.Scripts.Game.Handlers.Inputs;
using Assets.Scripts.Game.Handlers.Tap;
using Assets.Scripts.Game.Handlers.Timers;
using Assets.Scripts.Game.Handlers.Worlds;
using Assets.Scripts.Providers.AppStates;
using Assets.Scripts.Providers.AppStates.Factorys;
using Assets.Scripts.Providers.GameStates;
using Assets.Scripts.Providers.GameStates.Factorys;
using Assets.Scripts.Providers.InteractionsItems.Factorys;
using Assets.Scripts.Providers.InteractionsItems.Handlers;
using Assets.Scripts.Providers.Levels;
using Assets.Scripts.Providers.Levels.Factorys;
using Zenject;

namespace Assets.Scripts.Installers {
	public class GameInstaller :MonoInstaller {
		public override void InstallBindings() {
			_ = Container.BindInterfacesTo<GameBehaviourEventsHandler>().AsSingle().NonLazy();
			_ = Container.BindInterfacesTo<InteractionItemPresenterFactory>().AsSingle().NonLazy();
			_ = Container.BindInterfacesTo<GameInteractableItemsControlEventsHandler>().AsSingle().NonLazy();
			_ = Container.BindInterfacesTo<LevelWorldHandler>().AsSingle().NonLazy();
			_ = Container.BindInterfacesTo<GameInteractionItemsHandler>().AsSingle().NonLazy();
			_ = Container.BindInterfacesTo<TapHandler>().AsSingle().NonLazy();
			_ = Container.BindInterfacesTo<InputsHandler>().AsSingle().NonLazy();

			_ = Container.BindInterfacesTo<LevelsFactory>().AsSingle().NonLazy();
			_ = Container.BindInterfacesTo<LevelsProvider>().AsSingle().NonLazy();

			_ = Container.BindInterfacesTo<GameStateFactory>().AsSingle().NonLazy();
			_ = Container.BindInterfacesTo<GameStateProvider>().AsSingle().NonLazy();
			_ = Container.BindInterfacesTo<GameStateHandler>().AsSingle().NonLazy();

			_ = Container.BindInterfacesTo<AppStateFactory>().AsSingle().NonLazy();
			_ = Container.BindInterfacesTo<AppStateProvider>().AsSingle().NonLazy();
			_ = Container.BindInterfacesTo<AppStateHandler>().AsSingle().NonLazy();

			_ = Container.BindInterfacesTo<GameBehaviour>().AsSingle().NonLazy();
			_ = Container.BindInterfacesTo<GameTimerHandler>().AsSingle().NonLazy();

			_ = Container.BindInterfacesAndSelfTo<AppLoad>().AsSingle().NonLazy();
		}
	}
}
