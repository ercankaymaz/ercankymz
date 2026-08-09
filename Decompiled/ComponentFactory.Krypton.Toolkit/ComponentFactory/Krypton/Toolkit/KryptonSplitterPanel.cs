#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[DesignerCategory("code")]
[ToolboxBitmap(typeof(KryptonSplitterPanel), "ToolboxBitmaps.KryptonGroupPanel.bmp")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonSplitterPanelDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[Description("Enables you to group collections of controls.")]
[Docking(DockingBehavior.Never)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public sealed class KryptonSplitterPanel : KryptonPanel
{
	private bool _collapsed;

	private KryptonSplitContainer _container;

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
			if (Collapsed)
			{
				return 0;
			}
			return base.Height;
		}
		set
		{
			throw new NotSupportedException("Cannot set the Height of a KryptonSplitterPanel");
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
	public override Size MaximumSize
	{
		get
		{
			return base.MaximumSize;
		}
		set
		{
			base.MaximumSize = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Size MinimumSize
	{
		get
		{
			return base.MinimumSize;
		}
		set
		{
			base.MinimumSize = value;
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
			if (Collapsed)
			{
				return Size.Empty;
			}
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
			if (Collapsed)
			{
				return 0;
			}
			return base.Width;
		}
		set
		{
			throw new NotSupportedException("Cannot set the Width of a KryptonSplitterPanel");
		}
	}

	protected override Padding DefaultMargin => new Padding(0, 0, 0, 0);

	internal KryptonSplitContainer Owner => _container;

	internal bool Collapsed
	{
		get
		{
			return _collapsed;
		}
		set
		{
			_collapsed = value;
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

	public KryptonSplitterPanel(KryptonSplitContainer container)
	{
		Debug.Assert(container != null);
		_container = container;
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
