using System;
using System.Windows;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Panels;

internal static class ScrollHelper
{
	public static bool ScrollLeastAmount(Rect physViewRect, Rect itemRect, out Vector newPhysOffset)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		newPhysOffset = default(Vector);
		if (!((Rect)(ref physViewRect)).Contains(itemRect))
		{
			if ((((Rect)(ref itemRect)).Left > ((Rect)(ref physViewRect)).Left && ((Rect)(ref itemRect)).Right < ((Rect)(ref physViewRect)).Right) || DoubleHelper.AreVirtuallyEqual(((Rect)(ref itemRect)).Left, ((Rect)(ref physViewRect)).Left))
			{
				((Vector)(ref newPhysOffset)).X = ((Rect)(ref itemRect)).Left;
			}
			else if (((Rect)(ref itemRect)).Left < ((Rect)(ref physViewRect)).Left || ((Rect)(ref itemRect)).Width > ((Rect)(ref physViewRect)).Width)
			{
				((Vector)(ref newPhysOffset)).X = ((Rect)(ref itemRect)).Left;
			}
			else
			{
				((Vector)(ref newPhysOffset)).X = Math.Max(0.0, ((Rect)(ref physViewRect)).Left + (((Rect)(ref itemRect)).Right - ((Rect)(ref physViewRect)).Right));
			}
			if ((((Rect)(ref itemRect)).Top > ((Rect)(ref physViewRect)).Top && ((Rect)(ref itemRect)).Bottom < ((Rect)(ref physViewRect)).Bottom) || DoubleHelper.AreVirtuallyEqual(((Rect)(ref itemRect)).Top, ((Rect)(ref physViewRect)).Top))
			{
				((Vector)(ref newPhysOffset)).Y = ((Rect)(ref itemRect)).Top;
			}
			else if (((Rect)(ref itemRect)).Top < ((Rect)(ref physViewRect)).Top || ((Rect)(ref itemRect)).Height > ((Rect)(ref physViewRect)).Height)
			{
				((Vector)(ref newPhysOffset)).Y = ((Rect)(ref itemRect)).Top;
			}
			else
			{
				((Vector)(ref newPhysOffset)).Y = Math.Max(0.0, ((Rect)(ref physViewRect)).Top + (((Rect)(ref itemRect)).Bottom - ((Rect)(ref physViewRect)).Bottom));
			}
			result = true;
		}
		return result;
	}
}
