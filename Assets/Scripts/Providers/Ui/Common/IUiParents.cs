using UnityEngine;

namespace Assets.Scripts.Providers.Ui.Common
{
	public interface IUiParents
	{
		RectTransform Windows { get; }
		RectTransform Popups { get; }
		RectTransform Splash { get; }
	}
}
