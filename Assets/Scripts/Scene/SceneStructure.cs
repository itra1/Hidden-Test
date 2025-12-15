using Assets.Scripts.Providers.Ui.Common;
using Assets.Scripts.Scene.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Scene
{
	public class SceneStructure : MonoBehaviour, IUiParents, IScene
	{
		[Header("Scene")]
		[SerializeField] private Camera _gameGamera;
		[SerializeField] private Transform _world;

		[Header("Ui")]
		[SerializeField] private RectTransform _windows;
		[SerializeField] private RectTransform _popups;
		[SerializeField] private RectTransform _splash;

		public Transform World => _world;

		public RectTransform Windows => _windows;
		public RectTransform Popups => _popups;
		public RectTransform Splash => _splash;

		public Camera GameGamera  => _gameGamera;
	}
}
