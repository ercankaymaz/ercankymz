using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonSplitContainerBehavior : Behavior
{
	private KryptonSplitContainer _splitContainer;

	public KryptonSplitContainerBehavior(IDesigner relatedDesigner)
	{
		_splitContainer = relatedDesigner.Component as KryptonSplitContainer;
	}

	public override bool OnMouseEnter(Glyph g)
	{
		if (_splitContainer != null)
		{
			_splitContainer.DesignMouseEnter();
		}
		return base.OnMouseEnter(g);
	}

	public override bool OnMouseDown(Glyph g, MouseButtons button, Point pt)
	{
		if (_splitContainer != null)
		{
			Point pt2 = PointToSplitContainer(g, pt);
			if (_splitContainer.DesignMouseDown(pt2, button))
			{
				_splitContainer.Capture = true;
			}
		}
		return base.OnMouseDown(g, button, pt);
	}

	public override bool OnMouseMove(Glyph g, MouseButtons button, Point pt)
	{
		if (_splitContainer != null)
		{
			Point pt2 = PointToSplitContainer(g, pt);
			_splitContainer.DesignMouseMove(pt2);
		}
		return base.OnMouseMove(g, button, pt);
	}

	public override bool OnMouseUp(Glyph g, MouseButtons button)
	{
		if (_splitContainer != null)
		{
			_splitContainer.DesignMouseUp(button);
		}
		return base.OnMouseUp(g, button);
	}

	public override bool OnMouseLeave(Glyph g)
	{
		if (_splitContainer != null)
		{
			_splitContainer.DesignMouseLeave();
		}
		return base.OnMouseLeave(g);
	}

	private static Point PointToSplitContainer(Glyph g, Point pt)
	{
		KryptonSplitContainerGlyph kryptonSplitContainerGlyph = (KryptonSplitContainerGlyph)g;
		Rectangle bounds = kryptonSplitContainerGlyph.Bounds;
		return new Point(pt.X - bounds.X, pt.Y - bounds.Y);
	}
}
