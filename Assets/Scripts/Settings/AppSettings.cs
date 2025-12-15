using Assets.Scripts.Providers.Levels.Base;
using Assets.Scripts.Providers.Levels.Settings;
using Assets.Scripts.Providers.Ui.Presenters.Settings;
using StringDrop;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	[CreateAssetMenu(fileName = "AppSettings", menuName = "App/Settings/AppSettings")]
	public class AppSettings : ScriptableObject, ILevelsSettings, IPresentersSettings
	{
		[SerializeField] private string _levelsPath;
		[SerializeField] private string _levelsPrefabsPath;

		[SerializeField] private string _uiPresenters;
		[SerializeField] private TimerData _defaultTimeValue;
		[SerializeField][StringDropList(typeof(ItemsVisibleList), notEmpty: true)] private string _defaultVisibleItemList;

		public string LevelsPath => _levelsPath;
		public string LevelsPrefabsPath => _levelsPrefabsPath;
		public string UiPresenters => _uiPresenters;

		public TimerData DefaultTimer => _defaultTimeValue;
		public string DefaultVisibleItemList => _defaultVisibleItemList;
	}
}
