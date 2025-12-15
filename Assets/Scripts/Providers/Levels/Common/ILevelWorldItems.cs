using System.Collections.Generic;
using Assets.Scripts.Providers.InteractionsItems.Common;

namespace Assets.Scripts.Providers.Levels.Common {
	public interface ILevelWorldItems {
		List<InteractionItemWorld> InteractionItems { get; }
	}
}