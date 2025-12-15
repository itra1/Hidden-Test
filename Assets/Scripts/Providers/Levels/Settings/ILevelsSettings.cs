namespace Assets.Scripts.Providers.Levels.Settings
{
	public interface ILevelsSettings
	{
		string LevelsPath { get; }
		string LevelsPrefabsPath { get; }
		TimerData DefaultTimer { get; }
		string DefaultVisibleItemList { get; }
	}
}
