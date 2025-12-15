using System.Collections.Generic;
using Assets.Scripts.Providers.InteractionsItems.Common;
using Assets.Scripts.Providers.Levels.Common;
using Assets.Scripts.Providers.Levels.Settings;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Editors.Levels {
	[CustomEditor(typeof(LevelWorld))]
	public class LevelWorldInspector :Editor {
		private LevelWorld _script;
		private ILevelsSettings _settings;

		private ILevelsSettings Settings
		=> _settings ?? StaticContext.Container.Resolve<ILevelsSettings>();

		private void OnEnable() {
			_script = (LevelWorld)target;
		}

		public override void OnInspectorGUI() {
			base.OnInspectorGUI();

			if (GUILayout.Button(("Save level"))) {
				SaveLevel();
			}
		}

		public void SaveLevel() {
			if (PrefabUtility.IsPartOfAnyPrefab(_script.gameObject)) {
				PrefabUtility.UnpackPrefabInstance(_script.gameObject, PrefabUnpackMode.OutermostRoot, InteractionMode.AutomatedAction);
			}

			var levelParent = _script.gameObject.transform.parent;
			List<InteractionItemData> childList = ReadChildItems();
			var prefab = CreatePrefabFromObject(_script.gameObject, _script.gameObject.name);
			Object.DestroyImmediate(_script.gameObject);

			var newInstLevel = (GameObject)PrefabUtility.InstantiatePrefab(prefab, levelParent);
			Selection.activeObject = newInstLevel;

			CreateScriptableObject(prefab, childList);
		}

		private List<InteractionItemData> ReadChildItems() {
			List<InteractionItemData> itemsChildren = new();

			for (int i = 0; i < _script.ItemsParent.childCount; i++) {
				var child = _script.ItemsParent.GetChild(i);

				if (child.TryGetComponent<IInteractionItemWorld>(out IInteractionItemWorld childData)) {
					if (string.IsNullOrEmpty(childData.Uuid))
						childData.UuidSet(System.Guid.NewGuid().ToString());

					InteractionItemData newElement = new();
					newElement.Copy(childData);
					itemsChildren.Add(newElement);
				}
			}
			return itemsChildren;
		}

		private GameObject CreatePrefabFromObject(GameObject obj, string name) {
			string pathPrefab = $"Assets/{Settings.LevelsPrefabsPath}{name}.prefab";

			GameObject prefab = PrefabUtility.SaveAsPrefabAsset(obj, pathPrefab);
			AssetDatabase.Refresh();
			Debug.Log("Префаб создан: " + pathPrefab);
			return prefab;
		}

		private void CreateScriptableObject(GameObject prefab, List<InteractionItemData> childList) {
			string pathPrefab = $"Assets/{Settings.LevelsPath}{prefab.name}.asset";

			var levelData = ScriptableObject.CreateInstance<LevelData>();

			levelData.InteractiveItemsSet(childList);
			levelData.LevelPrefabSet(prefab);
			levelData.TimerSet(Settings.DefaultTimer);
			levelData.VisibleListSet(Settings.DefaultVisibleItemList);

			AssetDatabase.CreateAsset(levelData, pathPrefab);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}

	}
}
