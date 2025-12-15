using UnityEngine;


public static class GameObjectExtension
{
	public static T GetOrAddComponent<T>(this GameObject obj) where T : Component
	{
		if (!obj.TryGetComponent<T>(out var component))
			component = obj.AddComponent<T>();

		return component;
	}
}
