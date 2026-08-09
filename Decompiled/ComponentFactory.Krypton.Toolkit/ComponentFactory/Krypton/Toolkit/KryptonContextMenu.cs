#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonContextMenu), "ToolboxBitmaps.KryptonContextMenu.bmp")]
[DefaultEvent("Opening")]
[DefaultProperty("PaletteMode")]
[DesignerCategory("code")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonContextMenuDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[Description("Displays a shortcut menu in popup window.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonContextMenu : Component
{
	private IPalette _localPalette;

	private PaletteMode _paletteMode;

	private VisualContextMenu _contextMenu;

	private PaletteContextMenuRedirect _stateCommon;

	private PaletteContextMenuItemState _stateNormal;

	private PaletteContextMenuItemState _stateDisabled;

	private PaletteContextMenuItemStateHighlight _stateHighlight;

	private PaletteContextMenuItemStateChecked _stateChecked;

	private PaletteRedirectContextMenu _redirectorImages;

	private PaletteRedirect _redirector;

	private NeedPaintHandler _needPaintDelegate;

	private KryptonContextMenuCollection _items;

	private ToolStripDropDownCloseReason _closeReason;

	private ContextMenuImages _images;

	private bool _enabled;

	private object _caller;

	private object _tag;

	[Category("Visuals")]
	[Description("Image value overrides.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public ContextMenuImages Images => _images;

	[Category("Visuals")]
	[Description("Overrides for defining common context menu appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContextMenuRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining context menu disabled appearance values.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContextMenuItemState StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for context menu item normal appearance values.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContextMenuItemState StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Overrides for defining context menu checked appearance values.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContextMenuItemStateChecked StateChecked => _stateChecked;

	[Category("Visuals")]
	[Description("Overrides for defining context menu highlight appearance values.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContextMenuItemStateHighlight StateHighlight => _stateHighlight;

	[Category("Data")]
	[Description("Collection of menu items.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonContextMenuCollection Items => _items;

	[Category("Data")]
	[Description("User-defined data associated with the object.")]
	[TypeConverter(typeof(StringConverter))]
	[Bindable(true)]
	public object Tag
	{
		get
		{
			return _tag;
		}
		set
		{
			_tag = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether the context menu is enabled.")]
	[DefaultValue(true)]
	[Bindable(true)]
	public bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			_enabled = value;
		}
	}

	[Category("Visuals")]
	[Description("Palette applied to drawing.")]
	public PaletteMode PaletteMode
	{
		[DebuggerStepThrough]
		get
		{
			return _paletteMode;
		}
		set
		{
			_paletteMode = value;
		}
	}

	[Category("Visuals")]
	[Description("Custom palette applied to drawing.")]
	[DefaultValue(null)]
	public IPalette Palette
	{
		[DebuggerStepThrough]
		get
		{
			return _localPalette;
		}
		set
		{
			_localPalette = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public object Caller => _caller;

	internal ToolStripDropDownCloseReason CloseReason
	{
		get
		{
			return _closeReason;
		}
		set
		{
			_closeReason = value;
		}
	}

	internal VisualContextMenu VisualContextMenu => _contextMenu;

	[Category("Action")]
	[Description("Occurs when context menu is opening but not displayed as yet.")]
	public event CancelEventHandler Opening;

	[Category("Action")]
	[Description("Occurs when the context menu is fully opened for display.")]
	public event EventHandler Opened;

	[Category("Action")]
	[Description("Occurs when the context menu is about to close.")]
	public event CancelEventHandler Closing;

	[Category("Action")]
	[Description("Occurs when the context menu has been closed.")]
	public event ToolStripDropDownClosedEventHandler Closed;

	public KryptonContextMenu()
	{
		_needPaintDelegate = OnNeedPaint;
		_localPalette = null;
		_paletteMode = PaletteMode.Global;
		_images = new ContextMenuImages(_needPaintDelegate);
		_redirector = new PaletteRedirect(null);
		_redirectorImages = new PaletteRedirectContextMenu(_redirector, _images);
		_enabled = true;
		_stateCommon = new PaletteContextMenuRedirect(_redirector, _needPaintDelegate);
		_stateNormal = new PaletteContextMenuItemState(_stateCommon);
		_stateDisabled = new PaletteContextMenuItemState(_stateCommon);
		_stateHighlight = new PaletteContextMenuItemStateHighlight(_stateCommon);
		_stateChecked = new PaletteContextMenuItemStateChecked(_stateCommon);
		_items = new KryptonContextMenuCollection();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			Close();
		}
		base.Dispose(disposing);
	}

	private bool ShouldSerializeImages()
	{
		return !_images.IsDefault;
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateDisabled()
	{
		return !_stateDisabled.IsDefault;
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}

	private bool ShouldSerializeStateChecked()
	{
		return !_stateChecked.IsDefault;
	}

	private bool ShouldSerializeStateHighlight()
	{
		return !_stateHighlight.IsDefault;
	}

	private void ResetTag()
	{
		Tag = null;
	}

	private bool ShouldSerializeTag()
	{
		return Tag != null;
	}

	private bool ShouldSerializePaletteMode()
	{
		return PaletteMode != PaletteMode.Global;
	}

	public void ResetPaletteMode()
	{
		PaletteMode = PaletteMode.Global;
	}

	public void ResetPalette()
	{
		PaletteMode = PaletteMode.Global;
	}

	public bool Show(object caller)
	{
		return Show(caller, Control.MousePosition);
	}

	public bool Show(object caller, KryptonContextMenuPositionH horz, KryptonContextMenuPositionV vert)
	{
		return Show(caller, Control.MousePosition, horz, vert);
	}

	public bool Show(object caller, Point screenPt)
	{
		return Show(caller, new Rectangle(screenPt, Size.Empty));
	}

	public bool Show(object caller, Rectangle screenRect)
	{
		return Show(caller, screenRect, KryptonContextMenuPositionH.Left, KryptonContextMenuPositionV.Below);
	}

	public bool Show(object caller, Point screenPt, KryptonContextMenuPositionH horz, KryptonContextMenuPositionV vert)
	{
		return Show(caller, new Rectangle(screenPt, Size.Empty), horz, vert);
	}

	public bool Show(object caller, Rectangle screenRect, KryptonContextMenuPositionH horz, KryptonContextMenuPositionV vert)
	{
		return Show(caller, screenRect, horz, vert, keyboardActivated: false, constrain: true);
	}

	public bool Show(object caller, Rectangle screenRect, KryptonContextMenuPositionH horz, KryptonContextMenuPositionV vert, bool keyboardActivated, bool constrain)
	{
		bool result = false;
		if (_contextMenu == null)
		{
			_caller = caller;
			CancelEventArgs e = new CancelEventArgs();
			OnOpening(e);
			if (!e.Cancel)
			{
				_closeReason = ToolStripDropDownCloseReason.AppFocusChange;
				_contextMenu = CreateContextMenu(this, _localPalette, _paletteMode, _redirector, _redirectorImages, Items, Enabled, keyboardActivated);
				_contextMenu.Disposed += OnContextMenuDisposed;
				_contextMenu.Show(screenRect, horz, vert, bounce: false, constrain);
				_contextMenu.ShowHorz = KryptonContextMenuPositionH.After;
				_contextMenu.ShowVert = KryptonContextMenuPositionV.Top;
				OnOpened(EventArgs.Empty);
				result = true;
			}
		}
		return result;
	}

	public void Close()
	{
		Close(ToolStripDropDownCloseReason.CloseCalled);
	}

	public void Close(ToolStripDropDownCloseReason reason)
	{
		if (_contextMenu != null)
		{
			_closeReason = reason;
			VisualPopupManager.Singleton.EndPopupTracking(_contextMenu);
		}
	}

	public bool ProcessShortcut(Keys keyData)
	{
		return Items.ProcessShortcut(keyData);
	}

	protected virtual VisualContextMenu CreateContextMenu(KryptonContextMenu kcm, IPalette palette, PaletteMode paletteMode, PaletteRedirect redirector, PaletteRedirectContextMenu redirectorImages, KryptonContextMenuCollection items, bool enabled, bool keyboardActivated)
	{
		return new VisualContextMenu(kcm, palette, paletteMode, redirector, redirectorImages, items, enabled, keyboardActivated);
	}

	protected virtual void OnOpening(CancelEventArgs e)
	{
		if (this.Opening != null)
		{
			this.Opening(this, e);
		}
	}

	protected virtual void OnOpened(EventArgs e)
	{
		if (this.Opened != null)
		{
			this.Opened(this, e);
		}
	}

	protected internal virtual void OnClosing(CancelEventArgs e)
	{
		if (this.Closing != null)
		{
			this.Closing(this, e);
		}
	}

	protected virtual void OnClosed(ToolStripDropDownClosedEventArgs e)
	{
		if (this.Closed != null)
		{
			this.Closed(this, e);
		}
	}

	private void PerformNeedPaint(bool needLayout)
	{
		OnNeedPaint(this, new NeedLayoutEventArgs(needLayout));
	}

	private void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		if (_contextMenu != null)
		{
			_contextMenu.PerformNeedPaint(e.NeedLayout);
		}
	}

	private void OnContextMenuDisposed(object sender, EventArgs e)
	{
		if (_contextMenu != null)
		{
			_contextMenu.Disposed -= OnContextMenuDisposed;
			if (_contextMenu.CloseReason.HasValue)
			{
				CloseReason = _contextMenu.CloseReason.Value;
			}
			_contextMenu = null;
			OnClosed(new ToolStripDropDownClosedEventArgs(CloseReason));
		}
	}
}
