using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[DesignerCategory("code")]
[ToolboxBitmap(typeof(KryptonGroupPanel), "ToolboxBitmaps.KryptonGroupPanel.bmp")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonGroupPanelDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[Description("Enables you to group collections of controls.")]
[Docking(DockingBehavior.Never)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public sealed class KryptonGroupPanel : KryptonPanel
{
	private PaletteBackInheritForced _forcedDisabled;

	private PaletteBackInheritForced _forcedNormal;

	private NeedPaintHandler _layoutHandler;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override AnchorStyles Anchor
	{
		get
		{
			return base.Anchor;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override bool AutoSize
	{
		get
		{
			return base.AutoSize;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override AutoSizeMode AutoSizeMode
	{
		get
		{
			return base.AutoSizeMode;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new BorderStyle BorderStyle
	{
		get
		{
			return base.BorderStyle;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override DockStyle Dock
	{
		get
		{
			return base.Dock;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DockPaddingEdges DockPadding => base.DockPadding;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new int Height
	{
		get
		{
			return base.Height;
		}
		set
		{
			base.Height = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Point Location
	{
		get
		{
			return base.Location;
		}
		set
		{
			base.Location = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new string Name
	{
		get
		{
			return base.Name;
		}
		set
		{
			base.Name = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Control Parent
	{
		get
		{
			return base.Parent;
		}
		set
		{
			base.Parent = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Size Size
	{
		get
		{
			return base.Size;
		}
		set
		{
			base.Size = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new int TabIndex
	{
		get
		{
			return base.TabIndex;
		}
		set
		{
			base.TabIndex = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new bool TabStop
	{
		get
		{
			return base.TabStop;
		}
		set
		{
			base.TabStop = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new bool Visible
	{
		get
		{
			return base.Visible;
		}
		set
		{
			base.Visible = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new int Width
	{
		get
		{
			return base.Width;
		}
		set
		{
			base.Width = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new PaletteMode PaletteMode
	{
		get
		{
			return base.PaletteMode;
		}
		set
		{
			base.PaletteMode = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new IPalette Palette
	{
		get
		{
			return base.Palette;
		}
		set
		{
			base.Palette = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new PaletteBackStyle PanelBackStyle
	{
		get
		{
			return base.PanelBackStyle;
		}
		set
		{
			base.PanelBackStyle = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new PaletteBack StateCommon => base.StateCommon;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new PaletteBack StateDisabled => base.StateDisabled;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new PaletteBack StateNormal => base.StateNormal;

	protected override Padding DefaultMargin => new Padding(0, 0, 0, 0);

	protected override Control TransparentParent
	{
		get
		{
			if (Parent == null)
			{
				return null;
			}
			if (Parent.Parent == null)
			{
				return Parent;
			}
			return Parent.Parent;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event EventHandler AutoSizeChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event EventHandler DockChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event EventHandler LocationChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event EventHandler TabIndexChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event EventHandler TabStopChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event EventHandler VisibleChanged;

	public KryptonGroupPanel(Control alignControl, PaletteDoubleRedirect stateCommon, PaletteDouble stateDisabled, PaletteDouble stateNormal, NeedPaintHandler layoutHandler)
		: base(stateCommon, stateDisabled, stateNormal)
	{
		_layoutHandler = layoutHandler;
		_forcedDisabled = new PaletteBackInheritForced(stateDisabled.Back);
		_forcedNormal = new PaletteBackInheritForced(stateNormal.Back);
		_forcedDisabled.ForceGraphicsHint = PaletteGraphicsHint.None;
		_forcedNormal.ForceGraphicsHint = PaletteGraphicsHint.None;
		base.ViewDrawPanel.SetPalettes(base.Enabled ? _forcedNormal : _forcedDisabled);
		base.ViewManager.AlignControl = alignControl;
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		if (_layoutHandler != null)
		{
			_layoutHandler(this, new NeedLayoutEventArgs(needLayout: true));
		}
		base.OnLayout(levent);
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		base.OnEnabledChanged(e);
		base.ViewDrawPanel.SetPalettes(base.Enabled ? _forcedNormal : _forcedDisabled);
	}

	protected override void OnAutoSizeChanged(EventArgs e)
	{
		if (this.AutoSizeChanged != null)
		{
			this.AutoSizeChanged(this, e);
		}
		base.OnAutoSizeChanged(e);
	}

	protected override void OnDockChanged(EventArgs e)
	{
		if (this.DockChanged != null)
		{
			this.DockChanged(this, e);
		}
		base.OnDockChanged(e);
	}

	protected override void OnLocationChanged(EventArgs e)
	{
		if (this.LocationChanged != null)
		{
			this.LocationChanged(this, e);
		}
		base.OnLocationChanged(e);
	}

	protected override void OnTabIndexChanged(EventArgs e)
	{
		if (this.TabIndexChanged != null)
		{
			this.TabIndexChanged(this, e);
		}
		base.OnTabIndexChanged(e);
	}

	protected override void OnTabStopChanged(EventArgs e)
	{
		if (this.TabStopChanged != null)
		{
			this.TabStopChanged(this, e);
		}
		base.OnTabStopChanged(e);
	}

	protected override void OnVisibleChanged(EventArgs e)
	{
		if (this.VisibleChanged != null)
		{
			this.VisibleChanged(this, e);
		}
		base.OnVisibleChanged(e);
	}
}
