using System;

namespace Assets.Scripts.Providers.Ui.Controllers.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class UiControllerAttribute : Attribute, IUiControllerAttribute
	{
		public string PresenterName { get; private set; }
		public string PresenterType { get; private set; }
		public UiControllerAttribute(string type, string presenterName)
		{
			PresenterName = presenterName;
			PresenterType = type;
		}
	}
}
