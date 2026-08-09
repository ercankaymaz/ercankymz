#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawMenuColorBlock : ViewLeaf
{
	private IContextMenuProvider _provider;

	private KryptonContextMenuColorColumns _colorColumns;

	private Color _color;

	private Size _blockSize;

	private bool _first;

	private bool _last;

	private bool _enabled;

	public bool ItemEnabled => _enabled;

	public KryptonContextMenuColorColumns KryptonContextMenuColorColumns => _colorColumns;

	public bool CanCloseMenu => _provider.ProviderCanCloseMenu;

	public Color Color => _color;

	public ViewDrawMenuColorBlock(IContextMenuProvider provider, KryptonContextMenuColorColumns colorColumns, Color color, bool first, bool last, bool enabled)
	{
		_provider = provider;
		_colorColumns = colorColumns;
		_color = color;
		_first = first;
		_last = last;
		_enabled = enabled;
		_blockSize = colorColumns.BlockSize;
		MenuColorBlockController menuColorBlockController = new MenuColorBlockController(provider.ProviderViewManager, this, this, provider.ProviderNeedPaintDelegate);
		menuColorBlockController.Click += OnClick;
		MouseController = menuColorBlockController;
		KeyController = menuColorBlockController;
	}

	public override string ToString()
	{
		return "ViewDrawMenuColorBlock:" + base.Id;
	}

	public void Closing(CancelEventArgs cea)
	{
		_provider.OnClosing(cea);
	}

	public void Close(CloseReasonEventArgs e)
	{
		_provider.OnClose(e);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		return _blockSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ClientRectangle = context.DisplayRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		Rectangle clientRectangle = ClientRectangle;
		clientRectangle.X++;
		clientRectangle.Width -= 2;
		if (_first)
		{
			clientRectangle.Y++;
			clientRectangle.Height--;
		}
		if (_last)
		{
			clientRectangle.Height--;
		}
		using SolidBrush brush = new SolidBrush(_color);
		context.Graphics.FillRectangle(brush, clientRectangle);
	}

	public override void RenderAfter(RenderContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		Color color = Color.Empty;
		Color color2 = Color.Empty;
		_ = _colorColumns.SelectedColor;
		bool flag = _colorColumns.SelectedColor.Equals(_color);
		switch (ElementState)
		{
		case PaletteState.Tracking:
			if (_enabled)
			{
				color = _provider.ProviderStateChecked.ItemImage.Border.GetBorderColor1(PaletteState.CheckedNormal);
				color2 = _provider.ProviderStateChecked.ItemImage.Back.GetBackColor1(PaletteState.CheckedNormal);
			}
			else
			{
				color = _provider.ProviderStateHighlight.ItemHighlight.Border.GetBorderColor1(PaletteState.Disabled);
				color2 = _provider.ProviderStateHighlight.ItemHighlight.Back.GetBackColor1(PaletteState.Disabled);
			}
			break;
		case PaletteState.Normal:
		case PaletteState.Pressed:
			if (flag || ElementState == PaletteState.Pressed)
			{
				color = _provider.ProviderStateChecked.ItemImage.Border.GetBorderColor1(PaletteState.CheckedNormal);
				color2 = _provider.ProviderStateChecked.ItemImage.Back.GetBackColor1(PaletteState.CheckedNormal);
			}
			break;
		}
		if (color.IsEmpty || color2.IsEmpty)
		{
			return;
		}
		using Pen pen = new Pen(color);
		using Pen pen2 = new Pen(color2);
		context.Graphics.DrawRectangle(pen, ClientLocation.X, ClientLocation.Y, ClientWidth - 1, ClientHeight - 1);
		context.Graphics.DrawRectangle(pen2, ClientLocation.X + 1, ClientLocation.Y + 1, ClientWidth - 3, ClientHeight - 3);
	}

	private void OnClick(object sender, EventArgs e)
	{
		_colorColumns.SelectedColor = _color;
	}
}
