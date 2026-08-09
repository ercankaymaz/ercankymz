#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonQATMini : ViewLayoutDocker
{
	private static readonly int SEP_GAP = 2;

	private KryptonRibbon _ribbon;

	private ViewDrawRibbonQATBorder _border;

	private ViewLayoutRibbonQATFromRibbon _borderContents;

	private ViewDrawRibbonQATExtraButtonMini _extraButton;

	private ViewLayoutSeparator _extraSeparator;

	public KryptonForm OwnerForm
	{
		get
		{
			return _border.OwnerForm;
		}
		set
		{
			_border.OwnerForm = value;
		}
	}

	public override bool Visible
	{
		get
		{
			return _ribbon.Visible && base.Visible;
		}
		set
		{
			base.Visible = value;
		}
	}

	public bool OverlapAppButton
	{
		get
		{
			return _border.OverlapAppButton;
		}
		set
		{
			_border.OverlapAppButton = value;
		}
	}

	public ViewLayoutRibbonQATMini(KryptonRibbon ribbon, NeedPaintHandler needPaintDelegate)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
		_border = new ViewDrawRibbonQATBorder(ribbon, needPaintDelegate, minibar: true);
		_borderContents = new ViewLayoutRibbonQATFromRibbon(ribbon, needPaintDelegate, showExtraButton: false);
		_border.Add(_borderContents);
		_extraSeparator = new ViewLayoutSeparator(SEP_GAP);
		_extraButton = new ViewDrawRibbonQATExtraButtonMini(ribbon, needPaintDelegate);
		_extraButton.ClickAndFinish += OnExtraButtonClick;
		Add(_border, ViewDockStyle.Fill);
		Add(_extraSeparator, ViewDockStyle.Right);
		Add(_extraButton, ViewDockStyle.Right);
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonQATMini:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_extraButton.ClickAndFinish -= OnExtraButtonClick;
		}
		base.Dispose(disposing);
	}

	public KeyTipInfo[] GetQATKeyTips()
	{
		KeyTipInfoList keyTipInfoList = new KeyTipInfoList();
		keyTipInfoList.AddRange(_borderContents.GetQATKeyTips(OwnerForm));
		if (_extraButton.Overflow)
		{
			Padding padding = Padding.Empty;
			if (OwnerForm != null && !OwnerForm.ApplyComposition)
			{
				padding = OwnerForm.RealWindowBorders;
			}
			Rectangle rectangle = _borderContents.ParentControl.RectangleToScreen(_extraButton.ClientRectangle);
			Point screenPt = new Point(rectangle.Left + rectangle.Width / 2 - padding.Left, rectangle.Bottom - 2 - padding.Top);
			keyTipInfoList.Add(new KeyTipInfo(enabled: true, "00", screenPt, _extraButton.ClientRectangle, _extraButton.KeyTipTarget));
		}
		return keyTipInfoList.ToArray();
	}

	public ViewBase GetFirstQATView()
	{
		ViewBase viewBase = _borderContents.GetFirstQATView();
		if (viewBase == null)
		{
			viewBase = _extraButton;
		}
		return viewBase;
	}

	public ViewBase GetLastQATView()
	{
		if (_extraButton != null)
		{
			return _extraButton;
		}
		return _borderContents.GetLastQATView();
	}

	public ViewBase GetNextQATView(ViewBase qatButton)
	{
		ViewBase viewBase = _borderContents.GetNextQATView(qatButton);
		if (viewBase == null && _extraButton != qatButton)
		{
			viewBase = _extraButton;
		}
		return viewBase;
	}

	public ViewBase GetPreviousQATView(ViewBase qatButton)
	{
		if (qatButton == _extraButton)
		{
			return _borderContents.GetLastQATView();
		}
		return _borderContents.GetPreviousQATView(qatButton);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		bool flag = false;
		foreach (IQuickAccessToolbarButton qATButton in _ribbon.QATButtons)
		{
			if (qATButton.GetVisible())
			{
				flag = true;
				break;
			}
		}
		_border.Visible = flag;
		if (!flag)
		{
			_extraButton.Overflow = false;
		}
		return base.GetPreferredSize(context);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Rectangle displayRectangle = context.DisplayRectangle;
		if (OwnerForm == null)
		{
			int val = _ribbon.Width - displayRectangle.X;
			displayRectangle.Width = Math.Min(displayRectangle.Width, val);
		}
		context.DisplayRectangle = displayRectangle;
		base.Layout(context);
		if (_border.Visible)
		{
			_extraButton.Overflow = _borderContents.Overflow;
		}
		else
		{
			_extraButton.Overflow = false;
		}
	}

	private void OnExtraButtonClick(object sender, EventHandler finishDelegate)
	{
		ViewDrawRibbonQATExtraButton viewDrawRibbonQATExtraButton = (ViewDrawRibbonQATExtraButton)sender;
		Rectangle screenRectangle = _ribbon.RectangleToScreen(viewDrawRibbonQATExtraButton.ClientRectangle);
		if (OwnerForm != null && !OwnerForm.ApplyComposition)
		{
			Padding realWindowBorders = OwnerForm.RealWindowBorders;
			screenRectangle.X -= realWindowBorders.Left;
			screenRectangle.Y -= realWindowBorders.Top;
		}
		if (_extraButton.Overflow)
		{
			_ribbon.DisplayQATOverflowMenu(screenRectangle, _borderContents, finishDelegate);
		}
		else
		{
			_ribbon.DisplayQATCustomizeMenu(screenRectangle, _borderContents, finishDelegate);
		}
	}
}
