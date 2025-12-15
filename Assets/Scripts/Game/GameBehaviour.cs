using Assets.Scripts.Game.Handlers.Timers;
using Assets.Scripts.Game.Handlers.Worlds;
using Assets.Scripts.Providers.GameStates.Interfaces;
using Assets.Scripts.Providers.InteractionsItems.Handlers;
using Assets.Scripts.Providers.Levels;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game {
	public class GameBehaviour :IGameBehaviour {
		private readonly DiContainer _diContainer;
		private readonly ILevelsProvider _levelProvider;
		private readonly ILevelWorldHandler _levelWorldCreator;
		private readonly IGameTimerHandlerSet _gameTimerSet;
		private readonly IGameBehaviourEventsHandler _gameBehaviourEventsHandler;
		private readonly IGameInteractionItemsHandlerSet _interactionItemsHandlerSet;
		private readonly IGameInteractableItemsControlEventsHandler _interactableItemsControl;
		private IGameStateSet _gameStateSet;

		public GameBehaviour(DiContainer diContainer,
			ILevelsProvider levelProvider,
			ILevelWorldHandler levelMaker,
			IGameTimerHandlerSet gameTimerSet,
			IGameInteractionItemsHandlerSet interactionItemsHandlerSet,
			IGameInteractableItemsControlEventsHandler interactableItemsControl,
			IGameBehaviourEventsHandler gameBehaviourEventsHandler) {
			_diContainer = diContainer;
			_levelProvider = levelProvider;
			_levelWorldCreator = levelMaker;
			_gameTimerSet = gameTimerSet;
			_gameBehaviourEventsHandler = gameBehaviourEventsHandler;

			_interactionItemsHandlerSet = interactionItemsHandlerSet;
			_interactableItemsControl = interactableItemsControl;
			_interactableItemsControl.OnItemsComplete = AllItemsCompleteListener;
		}

		private void AllItemsCompleteListener() {
			Debug.Log("AllItemsCompleteListener");
			_gameTimerSet.StopTimer();
			_ = GameWin();
		}

		private void OnTimerCompleteListener() {
			_gameTimerSet.StopTimer();
			GameLoss();
		}

		public void SetLevel(int levelIndex) {
			var level = _levelProvider.GetLevel(levelIndex);
			_gameBehaviourEventsHandler.EmitSetLevelData(level);
			_levelWorldCreator.SetLevel(level);

			_gameTimerSet.SetTimer(level.Timer, OnTimerCompleteListener);
			_interactionItemsHandlerSet.StartLevel(level.Items);
		}

		private void GameLoss() {
			_gameStateSet ??= _diContainer.Resolve<IGameStateSet>();
			_ = _gameStateSet.StateLoss();
		}

		private async UniTask GameWin() {
			await UniTask.Delay(500);
			_gameStateSet ??= _diContainer.Resolve<IGameStateSet>();
			_ = _gameStateSet.StateWin();
		}
	}
}
