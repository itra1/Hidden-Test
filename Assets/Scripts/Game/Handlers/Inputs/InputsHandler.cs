using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Game.Handlers.Inputs {
	public class InputsHandler :IInputsHandler {

		public InputsHandler() {

			var exitAction = InputSystem.actions.FindAction("Exit");
			exitAction.started += OnExitAction;
		}

		private void OnExitAction(InputAction.CallbackContext context) {
#if UNITY_EDITOR
			Debug.Log("app quit");
#else
			Application.Quit();
#endif
		}
	}
}
