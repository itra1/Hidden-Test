using UnityEngine;

namespace Assets.Scripts.Providers.Levels.Settings
{
	[System.Serializable]
	public struct TimerData
	{
		[SerializeField] private bool _isEnable;
		[SerializeField][Tooltip("In seconds")] private int _value;

		public readonly bool IsEnable => _isEnable;
		public readonly int Value => _value;
	}
}
