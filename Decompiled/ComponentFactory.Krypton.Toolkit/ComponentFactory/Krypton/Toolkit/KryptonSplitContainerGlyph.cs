#define DEBUG
using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonSplitContainerGlyph : Glyph
{
	private KryptonSplitContainer _splitContainer;

	private ISelectionService _selectionService;

	private BehaviorService _behaviorService;

	private Adorner _adorner;

	public override Rectangle Bounds
	{
		get
		{
			if (_splitContainer != null)
			{
				Point location = _behaviorService.ControlToAdornerWindow(_splitContainer);
				return new Rectangle(location, _splitContainer.Size);
			}
			return Rectangle.Empty;
		}
	}

	public KryptonSplitContainerGlyph(ISelectionService selectionService, BehaviorService behaviorService, Adorner adorner, IDesigner relatedDesigner)
		: base(new KryptonSplitContainerBehavior(relatedDesigner))
	{
		Debug.Assert(selectionService != null);
		Debug.Assert(behaviorService != null);
		Debug.Assert(adorner != null);
		Debug.Assert(relatedDesigner != null);
		_selectionService = selectionService;
		_behaviorService = behaviorService;
		_adorner = adorner;
		_splitContainer = relatedDesigner.Component as KryptonSplitContainer;
		_selectionService.SelectionChanged += OnSelectionChanged;
	}

	public override Cursor GetHitTest(Point pt)
	{
		if (_splitContainer != null)
		{
			Rectangle bounds = Bounds;
			if (bounds.Contains(pt))
			{
				Point pt2 = new Point(pt.X - bounds.X, pt.Y - bounds.Y);
				return _splitContainer.DesignGetHitTest(pt2);
			}
		}
		return null;
	}

	public override void Paint(PaintEventArgs e)
	{
	}

	private void OnSelectionChanged(object sender, EventArgs e)
	{
		if (_splitContainer != null)
		{
			_splitContainer.DesignAbortMoving();
			if (_selectionService.PrimarySelection == _splitContainer)
			{
				_adorner.Enabled = true;
			}
			else
			{
				_adorner.Enabled = false;
			}
		}
	}
}
