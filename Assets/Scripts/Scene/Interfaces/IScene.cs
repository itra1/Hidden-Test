using UnityEngine;

namespace Assets.Scripts.Scene.Interfaces
{
	public interface IScene
	{
		public Transform World { get; }
		Camera GameGamera { get; }
	}
}
