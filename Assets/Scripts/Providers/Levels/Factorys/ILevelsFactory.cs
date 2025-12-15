using Assets.Scripts.Providers.Levels.Common;

namespace Assets.Scripts.Providers.Levels.Factorys {
	public interface ILevelsFactory {
		LevelData GetInstance(int index);
	}
}