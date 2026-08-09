#define DEBUG
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutPile : ViewComposite
{
	public override string ToString()
	{
		return "ViewLayoutPile:" + base.Id;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		base.Layout(context);
	}
}
