#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal abstract class ViewLayoutRibbonQATContents : ViewComposite
{
	private class QATButtonToView : Dictionary<IQuickAccessToolbarButton, ViewDrawRibbonQATButton>
	{
	}

	private KryptonRibbon _ribbon;

	private NeedPaintHandler _needPaint;

	private QATButtonToView _qatButtonToView;

	private ViewDrawRibbonQATExtraButton _extraButton;

	private bool _overflow;

	public KryptonRibbon Ribbon => _ribbon;

	public bool Overflow => _overflow;

	public abstract IQuickAccessToolbarButton[] QATButtons { get; }

	public virtual Control ParentControl => _ribbon;

	public ViewLayoutRibbonQATContents(KryptonRibbon ribbon, NeedPaintHandler needPaint, bool showExtraButton)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_needPaint = needPaint;
		_qatButtonToView = new QATButtonToView();
		if (showExtraButton)
		{
			_extraButton = new ViewDrawRibbonQATExtraButton(ribbon, needPaint);
			_extraButton.ClickAndFinish += OnExtraButtonClick;
		}
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonQATContents:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			Clear();
			foreach (ViewDrawRibbonQATButton value in _qatButtonToView.Values)
			{
				value.Dispose();
			}
			_qatButtonToView.Clear();
			if (_extraButton != null)
			{
				_extraButton.ClickAndFinish -= OnExtraButtonClick;
				_extraButton = null;
			}
		}
		base.Dispose(disposing);
	}

	public KeyTipInfo[] GetQATKeyTips(KryptonForm ownerForm)
	{
		Stack<string> stack = new Stack<string>();
		for (int num = 25; num >= 0; num--)
		{
			stack.Push("0" + (char)(65 + num));
		}
		for (int i = 1; i <= 9; i++)
		{
			stack.Push("0" + i);
		}
		for (int num2 = 9; num2 >= 1; num2--)
		{
			stack.Push(num2.ToString());
		}
		Padding padding = Padding.Empty;
		if (ownerForm != null && !ownerForm.ApplyComposition)
		{
			padding = ownerForm.RealWindowBorders;
		}
		KeyTipInfoList keyTipInfoList = new KeyTipInfoList();
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current.Visible && stack.Count > 0 && current is ViewDrawRibbonQATButton)
				{
					ViewDrawRibbonQATButton viewDrawRibbonQATButton = (ViewDrawRibbonQATButton)current;
					Rectangle rectangle = ParentControl.RectangleToScreen(viewDrawRibbonQATButton.ClientRectangle);
					keyTipInfoList.Add(new KeyTipInfo(screenPt: new Point(rectangle.Left + rectangle.Width / 2 - padding.Left, rectangle.Bottom - 2 - padding.Top), enabled: viewDrawRibbonQATButton.Enabled, keyString: stack.Pop(), clientRect: viewDrawRibbonQATButton.ClientRectangle, target: viewDrawRibbonQATButton.KeyTipTarget));
				}
			}
		}
		if (_extraButton != null && _extraButton.Overflow)
		{
			Rectangle rectangle2 = ParentControl.RectangleToScreen(_extraButton.ClientRectangle);
			Point screenPt = new Point(rectangle2.Left + rectangle2.Width / 2 - padding.Left, rectangle2.Bottom - 2 - padding.Top);
			keyTipInfoList.Add(new KeyTipInfo(enabled: true, "00", screenPt, _extraButton.ClientRectangle, _extraButton.KeyTipTarget));
		}
		return keyTipInfoList.ToArray();
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		SyncChildren(layout: false);
		Size empty = Size.Empty;
		for (int i = 0; i < Count; i++)
		{
			ViewBase viewBase = this[i];
			if (viewBase == _extraButton)
			{
				continue;
			}
			ViewDrawRibbonQATButton viewDrawRibbonQATButton = (ViewDrawRibbonQATButton)viewBase;
			if (viewDrawRibbonQATButton.QATButton.GetVisible() || _ribbon.InDesignHelperMode)
			{
				Size preferredSize = viewBase.GetPreferredSize(context);
				if (preferredSize.Width > 0)
				{
					empty.Width += preferredSize.Width;
					empty.Height = Math.Max(empty.Height, preferredSize.Height);
				}
			}
		}
		if (_extraButton != null)
		{
			Size preferredSize2 = _extraButton.GetPreferredSize(context);
			if (preferredSize2.Width > 0)
			{
				empty.Width += preferredSize2.Width;
				empty.Height = Math.Max(empty.Height, preferredSize2.Height);
			}
		}
		return empty;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		SyncChildren(layout: true);
		ClientRectangle = context.DisplayRectangle;
		int num = ClientLocation.X;
		int num2 = ClientRectangle.Right;
		if (_extraButton != null)
		{
			num2 -= _extraButton.GetPreferredSize(context).Width;
		}
		int y = ClientLocation.Y;
		int clientHeight = ClientHeight;
		_overflow = false;
		if (Count > 0)
		{
			for (int i = 0; i < Count; i++)
			{
				ViewBase viewBase = this[i];
				if (viewBase == _extraButton)
				{
					continue;
				}
				if (viewBase.Visible)
				{
					Size preferredSize = this[i].GetPreferredSize(context);
					if (preferredSize.Width + num <= num2)
					{
						context.DisplayRectangle = new Rectangle(num, y, preferredSize.Width, clientHeight);
						this[i].Layout(context);
						num += preferredSize.Width;
					}
					else
					{
						viewBase.Visible = false;
						_overflow = true;
					}
				}
				else
				{
					ViewDrawRibbonQATButton viewDrawRibbonQATButton = (ViewDrawRibbonQATButton)viewBase;
					if (viewDrawRibbonQATButton.QATButton.GetVisible() || _ribbon.InDesignHelperMode)
					{
						_overflow = true;
					}
				}
			}
		}
		if (_extraButton != null)
		{
			Size preferredSize2 = _extraButton.GetPreferredSize(context);
			if (preferredSize2.Width + num <= ClientRectangle.Right)
			{
				context.DisplayRectangle = new Rectangle(num, y, preferredSize2.Width, clientHeight);
				_extraButton.Layout(context);
				num += preferredSize2.Width;
			}
			_extraButton.Overflow = _overflow;
		}
		ClientRectangle = new Rectangle(ClientLocation, new Size(num - ClientLocation.X, ClientHeight));
		context.DisplayRectangle = new Rectangle(ClientLocation, new Size(num - ClientLocation.X, ClientHeight));
	}

	public ViewBase ViewForButton(IQuickAccessToolbarButton qatButton)
	{
		if (_qatButtonToView.ContainsKey(qatButton))
		{
			return _qatButtonToView[qatButton];
		}
		return null;
	}

	public ViewBase GetFirstQATView()
	{
		foreach (ViewDrawRibbonQATButton value in _qatButtonToView.Values)
		{
			if (value.Visible && value.Enabled)
			{
				return value;
			}
		}
		if (_extraButton != null)
		{
			return _extraButton;
		}
		return null;
	}

	public ViewBase GetLastQATView()
	{
		if (_extraButton != null)
		{
			return _extraButton;
		}
		ViewDrawRibbonQATButton[] array = new ViewDrawRibbonQATButton[_qatButtonToView.Count];
		_qatButtonToView.Values.CopyTo(array, 0);
		for (int num = array.Length - 1; num >= 0; num--)
		{
			ViewDrawRibbonQATButton viewDrawRibbonQATButton = array[num];
			if (viewDrawRibbonQATButton.Visible && viewDrawRibbonQATButton.Enabled)
			{
				return viewDrawRibbonQATButton;
			}
		}
		return null;
	}

	public ViewBase GetNextQATView(ViewBase qatButton)
	{
		bool flag = false;
		foreach (ViewDrawRibbonQATButton value in _qatButtonToView.Values)
		{
			if (!flag)
			{
				flag = value == qatButton;
			}
			else if (value.Visible && value.Enabled)
			{
				return value;
			}
		}
		if (qatButton != _extraButton && _extraButton != null)
		{
			return _extraButton;
		}
		return null;
	}

	public ViewBase GetPreviousQATView(ViewBase qatButton)
	{
		bool flag = qatButton != null && qatButton == _extraButton;
		ViewDrawRibbonQATButton[] array = new ViewDrawRibbonQATButton[_qatButtonToView.Count];
		_qatButtonToView.Values.CopyTo(array, 0);
		for (int num = array.Length - 1; num >= 0; num--)
		{
			ViewDrawRibbonQATButton viewDrawRibbonQATButton = array[num];
			if (!flag)
			{
				flag = viewDrawRibbonQATButton == qatButton;
			}
			else if (viewDrawRibbonQATButton.Visible && viewDrawRibbonQATButton.Enabled)
			{
				return viewDrawRibbonQATButton;
			}
		}
		return null;
	}

	private void SyncChildren(bool layout)
	{
		Clear();
		QATButtonToView qATButtonToView = new QATButtonToView();
		IQuickAccessToolbarButton[] qATButtons = QATButtons;
		IQuickAccessToolbarButton[] array = qATButtons;
		foreach (IQuickAccessToolbarButton quickAccessToolbarButton in array)
		{
			ViewDrawRibbonQATButton viewDrawRibbonQATButton = null;
			if (_qatButtonToView.ContainsKey(quickAccessToolbarButton))
			{
				viewDrawRibbonQATButton = _qatButtonToView[quickAccessToolbarButton];
			}
			if (viewDrawRibbonQATButton == null)
			{
				viewDrawRibbonQATButton = new ViewDrawRibbonQATButton(_ribbon, quickAccessToolbarButton, _needPaint);
			}
			qATButtonToView.Add(quickAccessToolbarButton, viewDrawRibbonQATButton);
		}
		foreach (IQuickAccessToolbarButton quickAccessToolbarButton2 in qATButtons)
		{
			if (layout)
			{
				qATButtonToView[quickAccessToolbarButton2].Enabled = _ribbon.InDesignHelperMode || quickAccessToolbarButton2.GetEnabled();
				qATButtonToView[quickAccessToolbarButton2].Visible = _ribbon.InDesignHelperMode || quickAccessToolbarButton2.GetVisible();
			}
			Add(qATButtonToView[quickAccessToolbarButton2]);
			if (_qatButtonToView.ContainsKey(quickAccessToolbarButton2))
			{
				_qatButtonToView.Remove(quickAccessToolbarButton2);
			}
		}
		foreach (ViewDrawRibbonQATButton value in _qatButtonToView.Values)
		{
			value.Dispose();
		}
		_qatButtonToView = qATButtonToView;
		if (_extraButton != null)
		{
			Add(_extraButton);
		}
	}

	private void OnExtraButtonClick(object sender, EventHandler finishDelegate)
	{
		ViewDrawRibbonQATExtraButton viewDrawRibbonQATExtraButton = (ViewDrawRibbonQATExtraButton)sender;
		Rectangle screenRectangle = ParentControl.RectangleToScreen(viewDrawRibbonQATExtraButton.ClientRectangle);
		if (_extraButton.Overflow)
		{
			_ribbon.DisplayQATOverflowMenu(screenRectangle, this, finishDelegate);
		}
		else
		{
			_ribbon.DisplayQATCustomizeMenu(screenRectangle, this, finishDelegate);
		}
	}
}
