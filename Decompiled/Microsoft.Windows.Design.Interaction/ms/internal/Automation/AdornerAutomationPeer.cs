using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;

namespace MS.Internal.Automation;

internal class AdornerAutomationPeer : UIElementAutomationPeer
{
	private UIElement _adorner;

	public AdornerAutomationPeer(UIElement adorner)
		: base(adorner)
	{
		_adorner = adorner;
	}

	protected override string GetAutomationIdCore()
	{
		string text = null;
		text = AutomationProperties.GetAutomationId((DependencyObject)(object)_adorner);
		if (string.IsNullOrEmpty(text))
		{
			text = ((object)_adorner).GetType().Name;
		}
		return text;
	}

	protected override string GetNameCore()
	{
		return ((AutomationPeer)this).GetAutomationIdCore();
	}

	protected override string GetItemTypeCore()
	{
		return ((AutomationPeer)this).GetAutomationIdCore();
	}

	protected override string GetClassNameCore()
	{
		return ((object)_adorner).GetType().Name;
	}

	protected override bool IsContentElementCore()
	{
		return false;
	}

	protected override bool IsControlElementCore()
	{
		return false;
	}

	protected override Point GetClickablePointCore()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		AutomationPeer val = UIElementAutomationPeer.CreatePeerForElement(_adorner);
		if (val != null)
		{
			return val.GetClickablePoint();
		}
		return ((UIElementAutomationPeer)this).GetClickablePointCore();
	}

	protected override Rect GetBoundingRectangleCore()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		AutomationPeer val = UIElementAutomationPeer.CreatePeerForElement(_adorner);
		if (val != null)
		{
			return val.GetBoundingRectangle();
		}
		return ((UIElementAutomationPeer)this).GetBoundingRectangleCore();
	}
}
