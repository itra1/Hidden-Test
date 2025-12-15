using Assets.Scripts.Providers.Levels.Common;
using Assets.Scripts.Providers.Levels.Settings;

namespace Assets.Scripts.Providers.Levels.Factorys {
	public class LevelsFactory :ILevelsFactory {
		private readonly ILevelListSettings _settings;

		public LevelsFactory(ILevelListSettings settings) {
			_settings = settings;
		}

		public LevelData GetInstance(int index) {
			return _settings.Levels[index];
		}
	}
}
