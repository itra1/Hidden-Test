using Assets.Scripts.Common;
using Assets.Scripts.Providers.InteractionsItems.Common;
using Assets.Scripts.Providers.Levels.Base;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Providers.Ui.Components {
	public class InteractionItemPresenter :MonoBehaviour, IInjection {
		[SerializeField] private CanvasGroup _cg;
		[SerializeField] private Image _iconeImage;
		[SerializeField] private TMP_Text _titleLabel;

		private InteractionItemData _data;

		public InteractionItemData Data => _data;
		public RectTransform RectTransform => transform as RectTransform;

		public void SetData(InteractionItemData data, string visibleType) {
			_data = data;
			_iconeImage.sprite = _data.Icone;
			_titleLabel.text = _data.Title;

			_iconeImage.enabled = visibleType == ItemsVisibleList.Pictyres;
			_titleLabel.enabled = visibleType == ItemsVisibleList.List;
			_cg.alpha = 1;
		}

		public async UniTask Remove() {
			await DOTween.To(() => _cg.alpha, (x) => _cg.alpha = x, 0, 0.2f).ToUniTask();
			gameObject.SetActive(false);
		}

		public async UniTask Show() {
			_cg.alpha = 0;
			await DOTween.To(() => _cg.alpha, (x) => _cg.alpha = x, 1, 0.2f).ToUniTask();
		}
	}
}
