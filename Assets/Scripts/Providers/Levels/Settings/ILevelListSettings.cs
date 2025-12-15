using System.Collections.Generic;
using Assets.Scripts.Providers.Levels.Common;

namespace Assets.Scripts.Providers.Levels.Settings
{
	public interface ILevelListSettings
	{
		List<LevelData> Levels { get; }
	}
}
