using Assets.Scripts.Common;
using Assets.Scripts.Game.Handlers.Tap;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Assets.Scripts.Providers.Ui.Components {
	public class TouchListener :MonoBehaviour, IPointerClickHandler, IInjection {
		private ITapHandler _tapHandler;

		[Inject]
		public void Constructor(ITapHandler tapHandler) {
			_tapHandler = tapHandler;
		}

		public void OnPointerClick(PointerEventData eventData) {
			_tapHandler.ScreenTap(eventData.position);
		}
	}
}
