using System.Collections.Generic;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonTitle : ViewLayoutDocker
{
	private int _vertOffset;

	public int VertOffset
	{
		get
		{
			return _vertOffset;
		}
		set
		{
			_vertOffset = value;
		}
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonTitle:" + base.Id;
	}

	public override void Layout(ViewLayoutContext context)
	{
		base.Layout(context);
		Rectangle displayRectangle = context.DisplayRectangle;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (GetDock(current) == ViewDockStyle.Bottom)
				{
					Rectangle clientRectangle = current.ClientRectangle;
					clientRectangle.Y += VertOffset;
					context.DisplayRectangle = clientRectangle;
					current.Layout(context);
				}
			}
		}
		context.DisplayRectangle = displayRectangle;
	}
}
