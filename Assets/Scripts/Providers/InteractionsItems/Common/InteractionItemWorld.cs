using Assets.Scripts.Game.Handlers.Tap;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Providers.InteractionsItems.Common {
	[RequireComponent(typeof(SpriteRenderer))]
	public class InteractionItemWorld :MonoBehaviour, IInteractionItemWorld, IInteractionData, ITapItem {
		[SerializeField] private string _title;
		[SerializeField][HideInInspector] private string _uuid;

		private SpriteRenderer _render;
		private Collider2D _collider;

		private SpriteRenderer Renderer => _render == null
			? _render = GetComponent<SpriteRenderer>()
			: _render;

		private Collider2D Collider => _collider == null
			? _collider = GetComponent<Collider2D>()
			: _collider;

		public string Uuid { get => _uuid; set => _uuid = value; }
		public string Title => _title;
		public Sprite Icone => Renderer.sprite;
		public void UuidSet(string value) => _uuid = value;

		public void InitData() {
			Collider.enabled = false;
			var color = Renderer.color;
			color.a = 1;
			Renderer.color = color;
		}

		public void Remove() {
			Collider.enabled = false;
			var color = _render.color;
			var colorTransparent = color;
			colorTransparent.a = 0;

			_ = DOTween.To(() => _render.color, (x) => _render.color = x, colorTransparent, 1);
		}

		public void ReadyTap() {
			Collider.enabled = true;
		}
	}
}
