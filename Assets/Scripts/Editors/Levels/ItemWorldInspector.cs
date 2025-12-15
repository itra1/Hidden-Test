using Assets.Scripts.Providers.InteractionsItems.Common;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editors.Levels
{
	[CustomEditor(typeof(InteractionItemWorld))]
	public class ItemWorldInspector : Editor
	{
		private InteractionItemWorld _script;

		private void OnEnable()
		{
			_script = (InteractionItemWorld) target;
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			GUILayout.Label($"Uuid {_script.Uuid}");
		}
	}
}
