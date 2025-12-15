using System.Collections.Generic;
using Assets.Scripts.Providers.Levels.Common;
using Assets.Scripts.Providers.Levels.Settings;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	[CreateAssetMenu(fileName = "LevelListSettings", menuName = "App/Settings/Levels/LevelListSettings")]
	public class LevelListSettings : ScriptableObject, ILevelListSettings
	{
		[SerializeField] private List<LevelData> _levels;

		public List<LevelData> Levels => _levels;

	}
}
