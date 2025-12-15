using System.Collections.Generic;
using Assets.Scripts.Common;
using Assets.Scripts.Providers.InteractionsItems.Common;
using UnityEngine;

namespace Assets.Scripts.Providers.Levels.Common {
	public interface ILevelWorld :IUuid {
		Transform ItemsParent { get; }
		SpriteRenderer Background { get; }
		List<InteractionItemWorld> InteractionItems { get; }

		void InitInGame(LevelData levelData);
	}
}