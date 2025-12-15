using Assets.Scripts.Providers.Levels.Common;
using Assets.Scripts.Providers.Levels.Factorys;

namespace Assets.Scripts.Providers.Levels {
	public class LevelsProvider :ILevelsProvider {
		private readonly ILevelsFactory _factory;

		public LevelsProvider(ILevelsFactory factory) {
			_factory = factory;
		}

		public LevelData GetLevel(int index) {
			return _factory.GetInstance(index);
		}
	}
}
