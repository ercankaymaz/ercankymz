#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonComposition : ViewLeaf, IKryptonComposition
{
	private static readonly int CONSTANT_COMPOSITION_HEIGHT = 30;

	private KryptonRibbon _ribbon;

	private VisualForm _ownerForm;

	private NeedPaintHandler _needPaint;

	private ViewDrawRibbonCompoRightBorder _compRightBorder;

	private Blend _compBlend;

	public int CompHeight
	{
		get
		{
			if (_ribbon.RibbonShape == PaletteRibbonShape.Office2010 && _ribbon.MainPanel.Visible)
			{
				return _ribbon.TabsArea.ClientHeight + CONSTANT_COMPOSITION_HEIGHT;
			}
			return CONSTANT_COMPOSITION_HEIGHT;
		}
	}

	public ViewDrawRibbonCompoRightBorder CompRightBorder
	{
		get
		{
			return _compRightBorder;
		}
		set
		{
			_compRightBorder = value;
		}
	}

	public IntPtr CompHandle => _ribbon.Handle;

	public bool CompVisible
	{
		get
		{
			return Visible;
		}
		set
		{
			Visible = value;
		}
	}

	public VisualForm CompOwnerForm
	{
		get
		{
			return _ownerForm;
		}
		set
		{
			_ownerForm = value;
			_compRightBorder.CompOwnerForm = value;
		}
	}

	public ViewDrawRibbonComposition(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_needPaint = needPaint;
		_compBlend = new Blend();
		_compBlend.Positions = new float[3] { 0f, 0.25f, 1f };
		_compBlend.Factors = new float[3] { 0f, 0f, 0.4f };
	}

	public override string ToString()
	{
		return "ViewDrawRibbonComposition:" + base.Id;
	}

	public void CompNeedPaint(bool needLayout)
	{
		_needPaint(this, new NeedLayoutEventArgs(needLayout));
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return new Size(0, CONSTANT_COMPOSITION_HEIGHT);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		Rectangle clientRectangle = ClientRectangle;
		clientRectangle.Height = context.TopControl.Height;
		Padding realWindowBorders = _ownerForm.RealWindowBorders;
		clientRectangle.X -= realWindowBorders.Left;
		clientRectangle.Width += realWindowBorders.Horizontal;
		context.DisplayRectangle = clientRectangle;
		_ownerForm.WindowChromeCompositionLayout(context, ClientRectangle);
		context.DisplayRectangle = ClientRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		Debug.Assert(_ownerForm != null);
		_ownerForm.WindowChromeCompositionPaint(context);
	}
}
