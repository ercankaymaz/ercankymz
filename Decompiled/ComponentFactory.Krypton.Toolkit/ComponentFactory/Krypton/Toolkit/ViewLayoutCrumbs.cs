#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutCrumbs : ViewComposite, IContentValues
{
	private class CrumbToButton : Dictionary<KryptonBreadCrumbItem, ViewDrawButton>
	{
	}

	private class ButtonToCrumb : Dictionary<ViewDrawButton, KryptonBreadCrumbItem>
	{
	}

	private class MenuItemToCrumb : Dictionary<KryptonContextMenuItem, KryptonBreadCrumbItem>
	{
	}

	private KryptonBreadCrumb _kryptonBreadCrumb;

	private NeedPaintHandler _needPaintDelegate;

	private ButtonController _pressedButtonController;

	private CrumbToButton _crumbToButton;

	private ButtonToCrumb _buttonToCrumb;

	private MenuItemToCrumb _menuItemToCrumb;

	private ViewDrawButton _overflowButton;

	private bool _showingContextMenu;

	public ViewLayoutCrumbs(KryptonBreadCrumb kryptonBreadCrumb, NeedPaintHandler needPaintDelegate)
	{
		_kryptonBreadCrumb = kryptonBreadCrumb;
		_needPaintDelegate = needPaintDelegate;
		_crumbToButton = new CrumbToButton();
		_buttonToCrumb = new ButtonToCrumb();
		_showingContextMenu = false;
		CreateOverflowButton();
	}

	protected override void Dispose(bool disposing)
	{
		Clear();
		foreach (ViewDrawButton value in _crumbToButton.Values)
		{
			value.Dispose();
		}
		_crumbToButton.Clear();
		_buttonToCrumb.Clear();
	}

	public override string ToString()
	{
		return "ViewLayoutCrumbs:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		SyncBreadCrumbs();
		PaletteRedirectBreadCrumb paletteRedirectBreadCrumb = _kryptonBreadCrumb.GetRedirector() as PaletteRedirectBreadCrumb;
		Size empty = Size.Empty;
		for (int i = 1; i < Count; i++)
		{
			paletteRedirectBreadCrumb.Left = i == 0;
			Size preferredSize = this[i].GetPreferredSize(context);
			empty.Width += preferredSize.Width;
			empty.Height = Math.Max(empty.Height, preferredSize.Height);
		}
		empty.Width += _kryptonBreadCrumb.Padding.Horizontal;
		empty.Height += _kryptonBreadCrumb.Padding.Vertical;
		return empty;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		PaletteRedirectBreadCrumb paletteRedirectBreadCrumb = _kryptonBreadCrumb.GetRedirector() as PaletteRedirectBreadCrumb;
		ClientRectangle = context.DisplayRectangle;
		SyncBreadCrumbs();
		Rectangle rectangle = new Rectangle(ClientLocation.X + _kryptonBreadCrumb.Padding.Left, ClientLocation.Y + _kryptonBreadCrumb.Padding.Top, ClientWidth - _kryptonBreadCrumb.Padding.Horizontal, ClientHeight - _kryptonBreadCrumb.Padding.Vertical);
		int num = rectangle.X;
		for (int i = 1; i < Count; i++)
		{
			paletteRedirectBreadCrumb.Left = i == 1;
			Size preferredSize = this[i].GetPreferredSize(context);
			context.DisplayRectangle = new Rectangle(num, rectangle.Y, preferredSize.Width, rectangle.Height);
			this[i].Layout(context);
			this[i].Visible = true;
			num += preferredSize.Width;
		}
		if (num > ClientWidth)
		{
			this[0].Visible = true;
			int num2 = num - ClientWidth;
			num = rectangle.X;
			for (int j = 0; j < Count; j++)
			{
				if (j > 0)
				{
					this[j].Visible = num2 <= 0;
				}
				if (this[j].Visible)
				{
					paletteRedirectBreadCrumb.Left = j == 0;
					Size preferredSize2 = this[j].GetPreferredSize(context);
					context.DisplayRectangle = new Rectangle(num, rectangle.Y, preferredSize2.Width, rectangle.Height);
					this[j].Layout(context);
					num += preferredSize2.Width;
				}
				num2 = ((j == 0) ? (num2 + this[j].ClientWidth) : (num2 - this[j].ClientWidth));
			}
		}
		else
		{
			this[0].Visible = false;
		}
		context.DisplayRectangle = ClientRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (!(current is ViewDrawButton))
				{
					continue;
				}
				ViewDrawButton viewDrawButton = current as ViewDrawButton;
				if (_buttonToCrumb.TryGetValue(viewDrawButton, out var _))
				{
					if (viewDrawButton.ElementState == PaletteState.Pressed)
					{
						viewDrawButton.DropDownOrientation = VisualOrientation.Top;
					}
					else
					{
						viewDrawButton.DropDownOrientation = VisualOrientation.Left;
					}
				}
			}
		}
		base.RenderBefore(context);
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		RenderBefore(context);
		PaletteRedirectBreadCrumb paletteRedirectBreadCrumb = _kryptonBreadCrumb.GetRedirector() as PaletteRedirectBreadCrumb;
		bool flag = true;
		for (int i = 0; i < Count; i++)
		{
			if (this[i].Visible)
			{
				if (flag)
				{
					paletteRedirectBreadCrumb.Left = true;
					flag = false;
				}
				else
				{
					paletteRedirectBreadCrumb.Left = false;
				}
				this[i].Render(context);
			}
		}
		RenderAfter(context);
	}

	public Image GetImage(PaletteState state)
	{
		return _kryptonBreadCrumb.GetRedirector().GetButtonSpecImage(PaletteButtonSpecStyle.ArrowLeft, state);
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return _kryptonBreadCrumb.GetRedirector().GetButtonSpecImageTransparentColor(PaletteButtonSpecStyle.ArrowLeft);
	}

	public string GetShortText()
	{
		return string.Empty;
	}

	public string GetLongText()
	{
		return string.Empty;
	}

	private void CreateOverflowButton()
	{
		_overflowButton = new ViewDrawButton(_kryptonBreadCrumb.StateDisabled.BreadCrumb, _kryptonBreadCrumb.StateNormal.BreadCrumb, _kryptonBreadCrumb.StateTracking.BreadCrumb, _kryptonBreadCrumb.StatePressed.BreadCrumb, _kryptonBreadCrumb.GetStateCommon(), this, VisualOrientation.Top, useMnemonic: false);
		_overflowButton.Splitter = true;
		_overflowButton.TestForFocusCues = true;
		_overflowButton.DropDownPalette = _kryptonBreadCrumb.GetRedirector();
		ButtonController buttonController = new ButtonController(_overflowButton, _needPaintDelegate);
		buttonController.Tag = this;
		buttonController.BecomesFixed = true;
		buttonController.Click += OnOverflowButtonClick;
		_overflowButton.MouseController = buttonController;
	}

	private void SyncBreadCrumbs()
	{
		Clear();
		for (KryptonBreadCrumbItem kryptonBreadCrumbItem = _kryptonBreadCrumb.SelectedItem; kryptonBreadCrumbItem != null; kryptonBreadCrumbItem = kryptonBreadCrumbItem.Parent)
		{
			if (!_crumbToButton.TryGetValue(kryptonBreadCrumbItem, out var value))
			{
				value = new ViewDrawButton(_kryptonBreadCrumb.StateDisabled.BreadCrumb, _kryptonBreadCrumb.StateNormal.BreadCrumb, _kryptonBreadCrumb.StateTracking.BreadCrumb, _kryptonBreadCrumb.StatePressed.BreadCrumb, _kryptonBreadCrumb.GetStateCommon(), kryptonBreadCrumbItem, VisualOrientation.Top, useMnemonic: false);
				value.Splitter = true;
				value.TestForFocusCues = true;
				value.DropDownPalette = _kryptonBreadCrumb.GetRedirector();
				ButtonController buttonController = new ButtonController(value, _needPaintDelegate);
				buttonController.Tag = kryptonBreadCrumbItem;
				buttonController.BecomesFixed = true;
				buttonController.Click += OnButtonClick;
				value.MouseController = buttonController;
				_crumbToButton.Add(kryptonBreadCrumbItem, value);
				_buttonToCrumb.Add(value, kryptonBreadCrumbItem);
			}
			value.DropDown = _kryptonBreadCrumb.DropDownNavigation && kryptonBreadCrumbItem.Items.Count > 0;
			Insert(0, value);
		}
		Insert(0, _overflowButton);
	}

	private void OnButtonClick(object sender, MouseEventArgs e)
	{
		if (_showingContextMenu)
		{
			return;
		}
		ViewDrawButton viewDrawButton = sender as ViewDrawButton;
		ButtonController buttonController = viewDrawButton.MouseController as ButtonController;
		KryptonBreadCrumbItem kryptonBreadCrumbItem = buttonController.Tag as KryptonBreadCrumbItem;
		if (viewDrawButton.DropDown && viewDrawButton.SplitRectangle.Contains(e.Location))
		{
			KryptonContextMenu kryptonContextMenu = new KryptonContextMenu();
			kryptonContextMenu.Palette = _kryptonBreadCrumb.Palette;
			if (kryptonContextMenu.Palette == null)
			{
				kryptonContextMenu.PaletteMode = _kryptonBreadCrumb.PaletteMode;
			}
			KryptonContextMenuItems kryptonContextMenuItems = new KryptonContextMenuItems();
			kryptonContextMenu.Items.Add(kryptonContextMenuItems);
			_menuItemToCrumb = new MenuItemToCrumb();
			foreach (KryptonBreadCrumbItem item in kryptonBreadCrumbItem.Items)
			{
				KryptonContextMenuItem kryptonContextMenuItem = new KryptonContextMenuItem();
				_menuItemToCrumb.Add(kryptonContextMenuItem, item);
				kryptonContextMenuItem.Text = item.ShortText;
				kryptonContextMenuItem.ExtraText = item.LongText;
				kryptonContextMenuItem.Image = item.Image;
				kryptonContextMenuItem.ImageTransparentColor = item.ImageTransparentColor;
				kryptonContextMenuItem.Click += OnChildCrumbClick;
				kryptonContextMenuItems.Items.Add(kryptonContextMenuItem);
			}
			BreadCrumbMenuArgs breadCrumbMenuArgs = new BreadCrumbMenuArgs(kryptonBreadCrumbItem, kryptonContextMenu, KryptonContextMenuPositionH.Left, KryptonContextMenuPositionV.Below);
			_kryptonBreadCrumb.OnCrumbDropDown(breadCrumbMenuArgs);
			if (!breadCrumbMenuArgs.Cancel && breadCrumbMenuArgs.KryptonContextMenu != null && CommonHelper.ValidKryptonContextMenu(breadCrumbMenuArgs.KryptonContextMenu))
			{
				_pressedButtonController = buttonController;
				breadCrumbMenuArgs.KryptonContextMenu.Closed += OnKryptonContextMenuClosed;
				breadCrumbMenuArgs.KryptonContextMenu.Show(_kryptonBreadCrumb, _kryptonBreadCrumb.RectangleToScreen(new Rectangle(viewDrawButton.SplitRectangle.X - viewDrawButton.SplitRectangle.Width, viewDrawButton.SplitRectangle.Y, viewDrawButton.SplitRectangle.Width * 2, viewDrawButton.SplitRectangle.Height)), breadCrumbMenuArgs.PositionH, breadCrumbMenuArgs.PositionV);
				_showingContextMenu = true;
			}
			else
			{
				buttonController.RemoveFixed();
			}
		}
		else
		{
			buttonController.RemoveFixed();
			_kryptonBreadCrumb.SelectedItem = kryptonBreadCrumbItem;
		}
	}

	private void OnKryptonContextMenuClosed(object sender, EventArgs e)
	{
		KryptonContextMenu kryptonContextMenu = (KryptonContextMenu)sender;
		kryptonContextMenu.Closed -= OnKryptonContextMenuClosed;
		kryptonContextMenu.Dispose();
		_pressedButtonController.RemoveFixed();
		_pressedButtonController = null;
		_showingContextMenu = false;
	}

	private void OnChildCrumbClick(object sender, EventArgs e)
	{
		KryptonContextMenuItem key = sender as KryptonContextMenuItem;
		_kryptonBreadCrumb.SelectedItem = _menuItemToCrumb[key];
	}

	private void OnOverflowButtonClick(object sender, MouseEventArgs e)
	{
		if (_showingContextMenu)
		{
			return;
		}
		ViewDrawButton viewDrawButton = sender as ViewDrawButton;
		ButtonController buttonController = viewDrawButton.MouseController as ButtonController;
		KryptonContextMenu kryptonContextMenu = new KryptonContextMenu();
		kryptonContextMenu.Palette = _kryptonBreadCrumb.Palette;
		if (kryptonContextMenu.Palette == null)
		{
			kryptonContextMenu.PaletteMode = _kryptonBreadCrumb.PaletteMode;
		}
		KryptonContextMenuItems kryptonContextMenuItems = new KryptonContextMenuItems();
		kryptonContextMenu.Items.Add(kryptonContextMenuItems);
		_menuItemToCrumb = new MenuItemToCrumb();
		for (int i = 3; i < Count; i++)
		{
			if (!this[i].Visible)
			{
				KryptonBreadCrumbItem kryptonBreadCrumbItem = _buttonToCrumb[(ViewDrawButton)this[i]];
				KryptonContextMenuItem kryptonContextMenuItem = new KryptonContextMenuItem();
				_menuItemToCrumb.Add(kryptonContextMenuItem, kryptonBreadCrumbItem);
				kryptonContextMenuItem.Text = kryptonBreadCrumbItem.ShortText;
				kryptonContextMenuItem.ExtraText = kryptonBreadCrumbItem.LongText;
				kryptonContextMenuItem.Image = kryptonBreadCrumbItem.Image;
				kryptonContextMenuItem.ImageTransparentColor = kryptonBreadCrumbItem.ImageTransparentColor;
				kryptonContextMenuItem.Click += OnChildCrumbClick;
				kryptonContextMenuItems.Items.Add(kryptonContextMenuItem);
			}
		}
		bool flag = true;
		foreach (KryptonBreadCrumbItem item in _kryptonBreadCrumb.RootItem.Items)
		{
			if (flag)
			{
				if (kryptonContextMenuItems.Items.Count > 0)
				{
					kryptonContextMenuItems.Items.Add(new KryptonContextMenuSeparator());
				}
				flag = false;
			}
			KryptonContextMenuItem kryptonContextMenuItem2 = new KryptonContextMenuItem();
			_menuItemToCrumb.Add(kryptonContextMenuItem2, item);
			kryptonContextMenuItem2.Text = item.ShortText;
			kryptonContextMenuItem2.ExtraText = item.LongText;
			kryptonContextMenuItem2.Image = item.Image;
			kryptonContextMenuItem2.ImageTransparentColor = item.ImageTransparentColor;
			kryptonContextMenuItem2.Click += OnChildCrumbClick;
			kryptonContextMenuItems.Items.Add(kryptonContextMenuItem2);
		}
		ContextPositionMenuArgs contextPositionMenuArgs = new ContextPositionMenuArgs(kryptonContextMenu, KryptonContextMenuPositionH.Left, KryptonContextMenuPositionV.Below);
		_kryptonBreadCrumb.OnOverflowDropDown(contextPositionMenuArgs);
		if (!contextPositionMenuArgs.Cancel && contextPositionMenuArgs.KryptonContextMenu != null && CommonHelper.ValidKryptonContextMenu(contextPositionMenuArgs.KryptonContextMenu))
		{
			_pressedButtonController = buttonController;
			contextPositionMenuArgs.KryptonContextMenu.Closed += OnKryptonContextMenuClosed;
			contextPositionMenuArgs.KryptonContextMenu.Show(_kryptonBreadCrumb, _kryptonBreadCrumb.RectangleToScreen(new Rectangle(viewDrawButton.ClientRectangle.X, viewDrawButton.ClientRectangle.Y, viewDrawButton.ClientRectangle.Width * 2, viewDrawButton.ClientRectangle.Height)), contextPositionMenuArgs.PositionH, contextPositionMenuArgs.PositionV);
			_showingContextMenu = true;
		}
		else
		{
			buttonController.RemoveFixed();
			_kryptonBreadCrumb.SelectedItem = _kryptonBreadCrumb.RootItem;
		}
	}
}
