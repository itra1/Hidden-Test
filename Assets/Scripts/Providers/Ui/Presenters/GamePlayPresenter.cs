using Assets.Scripts.Providers.Ui.Components;
using Assets.Scripts.Providers.Ui.Presenters.Base;
using UnityEngine;

namespace Assets.Scripts.Providers.Ui.Presenters
{
	public class GamePlayPresenter : WindowPresenter
	{
		[SerializeField] private TouchListener _touchListener;
		[SerializeField] private RectTransform _lastParent;

	}
}
