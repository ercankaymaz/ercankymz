using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation.Peers;
using MS.Internal.Properties;

namespace MS.Internal.Automation;

internal class AdornerNodeAutomationPeer : AutomationPeer
{
	private List<UIElement> _list;

	public AdornerNodeAutomationPeer(List<UIElement> list)
	{
		_list = list;
	}

	protected override string GetAcceleratorKeyCore()
	{
		return string.Empty;
	}

	protected override string GetAccessKeyCore()
	{
		return string.Empty;
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return (AutomationControlType)25;
	}

	protected override string GetAutomationIdCore()
	{
		return "Adorners";
	}

	protected override Rect GetBoundingRectangleCore()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Rect);
	}

	protected override List<AutomationPeer> GetChildrenCore()
	{
		List<AutomationPeer> list = new List<AutomationPeer>();
		if (_list != null)
		{
			foreach (UIElement item in _list)
			{
				AddAdornerAutomationPeer(list, item);
			}
		}
		return list;
	}

	private static void AddAdornerAutomationPeer(List<AutomationPeer> list, UIElement adorner)
	{
		list.Add((AutomationPeer)(object)AutomationPeerCache.Create<AdornerAutomationPeer>(adorner, new object[0]));
	}

	protected override string GetClassNameCore()
	{
		return "Adorners";
	}

	protected override Point GetClickablePointCore()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Point);
	}

	protected override string GetHelpTextCore()
	{
		return MS.Internal.Properties.Resources.AdornerNodeAutomationPeer_HelpText;
	}

	protected override string GetItemStatusCore()
	{
		return string.Empty;
	}

	protected override string GetItemTypeCore()
	{
		return MS.Internal.Properties.Resources.AdornerNodeAutomationPeer_ItemType;
	}

	protected override AutomationPeer GetLabeledByCore()
	{
		return null;
	}

	protected override string GetNameCore()
	{
		return MS.Internal.Properties.Resources.AdornerNodeAutomationPeer_Name;
	}

	protected override AutomationOrientation GetOrientationCore()
	{
		return (AutomationOrientation)0;
	}

	public override object GetPattern(PatternInterface patternInterface)
	{
		return null;
	}

	protected override bool HasKeyboardFocusCore()
	{
		return false;
	}

	protected override bool IsContentElementCore()
	{
		return false;
	}

	protected override bool IsControlElementCore()
	{
		return false;
	}

	protected override bool IsEnabledCore()
	{
		return true;
	}

	protected override bool IsKeyboardFocusableCore()
	{
		return false;
	}

	protected override bool IsOffscreenCore()
	{
		return false;
	}

	protected override bool IsPasswordCore()
	{
		return false;
	}

	protected override bool IsRequiredForFormCore()
	{
		return false;
	}

	protected override void SetFocusCore()
	{
	}
}
