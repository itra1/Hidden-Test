using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Providers.InteractionsItems.Common
{
	public interface IInteractionData : IUuid
	{
		public string Title { get; }
		public Sprite Icone { get; }
	}
}