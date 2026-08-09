using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonSplitContainer), "ToolboxBitmaps.KryptonSplitContainer.bmp")]
[DefaultEvent("SplitterMoved")]
[DefaultProperty("Orientation")]
[DesignerCategory("code")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonSplitContainerDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[Description("Divide the container inside two resizable panels.")]
[Docking(DockingBehavior.AutoDock)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonSplitContainer : VisualControlContainment, ISeparatorSource
{
	private SeparatorStyle _style;

	private ViewDrawPanel _drawPanel;

	private ViewDrawSeparator _drawSeparator;

	private SeparatorController _separatorController;

	private PaletteSplitContainerRedirect _stateCommon;

	private PaletteSplitContainer _stateDisabled;

	private PaletteSplitContainer _stateNormal;

	private PaletteSeparatorPadding _stateTracking;

	private PaletteSeparatorPadding _statePressed;

	private KryptonSplitterPanel _panel1;

	private KryptonSplitterPanel _panel2;

	private Orientation _orientation;

	private FixedPanel _fixedPanel;

	private Point _designLastPt;

	private double _splitterPercent;

	private int _splitterDistance;

	private int _splitterIncrement;

	private int _splitterWidth;

	private int _panel1MinSize;

	private int _panel2MinSize;

	private int _fixedDistance;

	private bool _forcedLayout;

	private bool _resizing;

	private bool _fixed;

	[Browsable(false)]
	public new string Name
	{
		get
		{
			return base.Name;
		}
		set
		{
			base.Name = value;
			_panel1.Name = value + ".Panel1";
			_panel2.Name = value + ".Panel2";
		}
	}

	[Category("Visuals")]
	[Description("Container background style.")]
	public PaletteBackStyle ContainerBackStyle
	{
		get
		{
			return _stateCommon.BackStyle;
		}
		set
		{
			if (_stateCommon.BackStyle != value)
			{
				_stateCommon.BackStyle = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Separator style.")]
	public SeparatorStyle SeparatorStyle
	{
		get
		{
			return _style;
		}
		set
		{
			if (_style != value)
			{
				_style = value;
				SetStyles(_style);
				_drawSeparator.MetricPadding = CommonHelper.SeparatorStyleToMetricPadding(_style);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining common split container appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteSplitContainerRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled split container appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteSplitContainer StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal split container appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteSplitContainer StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Overrides for defining hot tracking separator appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteSeparatorPadding StateTracking => _stateTracking;

	[Category("Visuals")]
	[Description("Overrides for defining pressed separator appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteSeparatorPadding StatePressed => _statePressed;

	[Localizable(false)]
	[Category("Appearance")]
	[Description("The Left or Top panel in the KryptonSplitContainer.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonSplitterPanel Panel1 => _panel1;

	[Category("Layout")]
	[Description("Determines the minimum distance of pixels of the splitter from the left or top edge of Panel1.")]
	[Localizable(true)]
	[DefaultValue(typeof(int), "25")]
	public int Panel1MinSize
	{
		get
		{
			return _panel1MinSize;
		}
		set
		{
			if (_panel1MinSize != value)
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Panel1MinSize", "Value cannot be less than zero");
				}
				_panel1MinSize = value;
				if (base.IsInitialized)
				{
					PerformLayout();
					Invalidate();
				}
				else
				{
					ForceControlLayout();
				}
			}
		}
	}

	[Category("Layout")]
	[Description("Determines if Panel1 is collapsed.")]
	[DefaultValue(false)]
	public bool Panel1Collapsed
	{
		get
		{
			return Panel1.Collapsed;
		}
		set
		{
			if (_panel1.Collapsed == value)
			{
				return;
			}
			if (value && _panel2.Collapsed)
			{
				Panel2.Collapsed = false;
				Panel2.Visible = true;
			}
			Panel1.Collapsed = value;
			Panel1.Visible = !value;
			if (!Panel1Collapsed && !Panel2Collapsed)
			{
				if (_orientation == Orientation.Vertical)
				{
					_splitterDistance = (int)((double)base.Width * _splitterPercent);
				}
				else
				{
					_splitterDistance = (int)((double)base.Height * _splitterPercent);
				}
			}
			if (base.IsInitialized)
			{
				PerformLayout();
				Invalidate();
			}
			else
			{
				ForceControlLayout();
			}
		}
	}

	[Localizable(false)]
	[Category("Appearance")]
	[Description("The Right or Bottom panel in the KryptonSplitContainer.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonSplitterPanel Panel2 => _panel2;

	[Category("Layout")]
	[Description("Determines the minimum distance of pixels of the splitter from the right or bottom edge of Panel2.")]
	[Localizable(true)]
	[DefaultValue(typeof(int), "25")]
	public int Panel2MinSize
	{
		get
		{
			return _panel2MinSize;
		}
		set
		{
			if (_panel2MinSize != value)
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Panel2MinSize", "Value cannot be less than zero");
				}
				_panel2MinSize = value;
				if (base.IsInitialized)
				{
					PerformLayout();
					Invalidate();
				}
				else
				{
					ForceControlLayout();
				}
			}
		}
	}

	[Category("Layout")]
	[Description("Determines if Panel2 is collapsed.")]
	[DefaultValue(false)]
	public bool Panel2Collapsed
	{
		get
		{
			return _panel2.Collapsed;
		}
		set
		{
			if (Panel2.Collapsed == value)
			{
				return;
			}
			if (value && _panel1.Collapsed)
			{
				Panel1.Collapsed = false;
				Panel1.Visible = true;
			}
			Panel2.Collapsed = value;
			Panel2.Visible = !value;
			if (!Panel1Collapsed && !Panel2Collapsed)
			{
				if (_orientation == Orientation.Vertical)
				{
					_splitterDistance = (int)((double)base.Width * _splitterPercent);
				}
				else
				{
					_splitterDistance = (int)((double)base.Height * _splitterPercent);
				}
			}
			if (base.IsInitialized)
			{
				PerformLayout();
				Invalidate();
			}
			else
			{
				ForceControlLayout();
			}
		}
	}

	[Category("Layout")]
	[Description("Determines if the splitter is fixed.")]
	[Localizable(true)]
	[DefaultValue(false)]
	public bool IsSplitterFixed
	{
		get
		{
			return _fixed;
		}
		set
		{
			_fixed = value;
		}
	}

	[Category("Layout")]
	[Description("Indicates the panel to keep the same size when resizing.")]
	[DefaultValue(typeof(FixedPanel), "None")]
	[Localizable(true)]
	public FixedPanel FixedPanel
	{
		get
		{
			return _fixedPanel;
		}
		set
		{
			if (_fixedPanel == value)
			{
				return;
			}
			_fixedPanel = value;
			if (Orientation == Orientation.Vertical)
			{
				if (_fixedPanel == FixedPanel.Panel1)
				{
					_fixedDistance = Panel1.Width;
				}
				else if (_fixedPanel == FixedPanel.Panel2)
				{
					_fixedDistance = Panel2.Width;
				}
			}
			else if (_fixedPanel == FixedPanel.Panel1)
			{
				_fixedDistance = Panel1.Height;
			}
			else if (_fixedPanel == FixedPanel.Panel2)
			{
				_fixedDistance = Panel2.Height;
			}
		}
	}

	[Category("Layout")]
	[Description("Determines pixel distance of the splitter from the left or top edge.")]
	[Localizable(true)]
	[SettingsBindable(true)]
	[DefaultValue(typeof(int), "50")]
	public int SplitterDistance
	{
		get
		{
			return _splitterDistance;
		}
		set
		{
			if (_splitterDistance == value)
			{
				return;
			}
			if (value < 0)
			{
				value = 0;
			}
			if (value < Panel1MinSize)
			{
				value = Panel1MinSize;
			}
			if (Orientation == Orientation.Vertical)
			{
				if (value + SplitterWidth > base.Width - Panel2MinSize)
				{
					value = base.Width - Panel2MinSize - SplitterWidth;
				}
				if (value < 0)
				{
					value = 0;
				}
			}
			else
			{
				if (value + SplitterWidth > base.Height - Panel2MinSize)
				{
					value = base.Height - Panel2MinSize - SplitterWidth;
				}
				if (value < 0)
				{
					value = 0;
				}
			}
			_splitterDistance = value;
			if (FixedPanel == FixedPanel.Panel2)
			{
				if (Orientation == Orientation.Vertical)
				{
					_fixedDistance = base.Width - value - SplitterWidth;
				}
				else
				{
					_fixedDistance = base.Height - value - SplitterWidth;
				}
			}
			else
			{
				_fixedDistance = value;
			}
			if (base.IsInitialized)
			{
				PerformLayout();
				Invalidate();
			}
			else
			{
				ForceControlLayout();
			}
		}
	}

	[Category("Layout")]
	[Description("Determines the thickness of the splitter.")]
	[Localizable(true)]
	[DefaultValue(typeof(int), "5")]
	public int SplitterWidth
	{
		get
		{
			return _splitterWidth;
		}
		set
		{
			if (_splitterWidth != value)
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("SplitterWidth", "Value cannot be less than zero");
				}
				_splitterWidth = value;
				if (base.IsInitialized)
				{
					PerformLayout();
					Invalidate();
				}
				else
				{
					ForceControlLayout();
				}
			}
		}
	}

	[Category("Layout")]
	[Description("Determines the number of pixels the splitter moves in increments.")]
	[Localizable(true)]
	[DefaultValue(typeof(int), "1")]
	public int SplitterIncrement
	{
		get
		{
			return _splitterIncrement;
		}
		set
		{
			if (_splitterIncrement != value)
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("SplitterIncrement", "Value cannot be less than one");
				}
				_splitterIncrement = value;
			}
		}
	}

	[Category("Behavior")]
	[Description("Determines if the splitter is vertical or horizontal.")]
	[Localizable(true)]
	[DefaultValue(typeof(Orientation), "Vertical")]
	public Orientation Orientation
	{
		get
		{
			return _orientation;
		}
		set
		{
			if (_orientation == value)
			{
				return;
			}
			if (!Collapsed)
			{
				if (_orientation == Orientation.Vertical)
				{
					_splitterDistance = (int)((double)base.Width * _splitterPercent);
				}
				else
				{
					_splitterDistance = (int)((double)base.Height * _splitterPercent);
				}
			}
			_orientation = value;
			_drawSeparator.Orientation = _orientation;
			if (base.IsInitialized)
			{
				PerformLayout();
				Invalidate();
			}
			else
			{
				ForceControlLayout();
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Control SeparatorControl => this;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Orientation SeparatorOrientation => Orientation;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool SeparatorCanMove => !IsSplitterFixed && !Collapsed;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SeparatorIncrements => SplitterIncrement;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle SeparatorMoveBox
	{
		get
		{
			Rectangle clientRectangle = base.ClientRectangle;
			int val;
			int num;
			if (CommonHelper.GetRightToLeftLayout(this) && RightToLeft == RightToLeft.Yes)
			{
				val = Panel2MinSize;
				num = Panel1MinSize;
			}
			else
			{
				val = Panel1MinSize;
				num = Panel2MinSize;
			}
			if (Orientation == Orientation.Vertical)
			{
				int num2 = Math.Min(val, clientRectangle.Width);
				int val2 = Math.Max(clientRectangle.Right - num, 0);
				val2 = Math.Max(num2, val2);
				clientRectangle.X = num2;
				clientRectangle.Width = val2 - num2;
			}
			else
			{
				int num3 = Math.Min(val, clientRectangle.Height);
				int val3 = Math.Max(clientRectangle.Bottom - num, 0);
				val3 = Math.Max(num3, val3);
				clientRectangle.Y = num3;
				clientRectangle.Height = val3 - num3;
			}
			return clientRectangle;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new ControlCollection Controls => base.Controls;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Padding Padding
	{
		get
		{
			return base.Padding;
		}
		set
		{
			base.Padding = value;
		}
	}

	protected override Size DefaultSize => new Size(150, 150);

	private bool Collapsed => Panel1.Collapsed || Panel2.Collapsed;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event EventHandler AutoSizeChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event EventHandler BackgroundImageChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event EventHandler BackgroundImageLayoutChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event ControlEventHandler ControlAdded;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event ControlEventHandler ControlRemoved;

	[Category("Behavior")]
	[Description("Occurs when the splitter is done being moved.")]
	public event SplitterEventHandler SplitterMoved;

	[Category("Behavior")]
	[Description("Occurs when the splitter is being moved.")]
	public event SplitterCancelEventHandler SplitterMoving;

	public KryptonSplitContainer()
	{
		_stateCommon = new PaletteSplitContainerRedirect(base.Redirector, PaletteBackStyle.PanelClient, PaletteBorderStyle.ControlClient, PaletteBackStyle.SeparatorLowProfile, PaletteBorderStyle.SeparatorLowProfile, base.NeedPaintDelegate);
		_stateDisabled = new PaletteSplitContainer(_stateCommon, _stateCommon.Separator, _stateCommon.Separator, base.NeedPaintDelegate);
		_stateNormal = new PaletteSplitContainer(_stateCommon, _stateCommon.Separator, _stateCommon.Separator, base.NeedPaintDelegate);
		_stateTracking = new PaletteSeparatorPadding(_stateCommon.Separator, _stateCommon.Separator, base.NeedPaintDelegate);
		_statePressed = new PaletteSeparatorPadding(_stateCommon.Separator, _stateCommon.Separator, base.NeedPaintDelegate);
		_drawSeparator = new ViewDrawSeparator(_stateDisabled.Separator, _stateNormal.Separator, _stateTracking, _statePressed, _stateDisabled.Separator, _stateNormal.Separator, _stateTracking, _statePressed, PaletteMetricPadding.SeparatorPaddingLowProfile, Orientation.Vertical);
		_drawPanel = new ViewDrawPanel(_stateNormal.Back);
		_drawPanel.Add(_drawSeparator);
		_separatorController = new SeparatorController(this, _drawSeparator, splitCursors: true, drawIndicator: true, base.NeedPaintDelegate);
		_drawSeparator.MouseController = _separatorController;
		_drawSeparator.KeyController = _separatorController;
		_drawSeparator.SourceController = _separatorController;
		base.ViewManager = new ViewManager(this, _drawPanel);
		_splitterDistance = 50;
		_splitterPercent = 0.3333333432674408;
		_splitterIncrement = 1;
		_panel1MinSize = 25;
		_panel2MinSize = 25;
		_splitterWidth = 5;
		_fixedDistance = 50;
		_fixedPanel = FixedPanel.None;
		_orientation = Orientation.Vertical;
		_panel1 = new KryptonSplitterPanel(this);
		_panel2 = new KryptonSplitterPanel(this);
		((KryptonReadOnlyControls)Controls).AddInternal(_panel1);
		((KryptonReadOnlyControls)Controls).AddInternal(_panel2);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_separatorController.Dispose();
		}
		base.Dispose(disposing);
	}

	private bool ShouldSerializeContainerBackStyle()
	{
		return ContainerBackStyle != PaletteBackStyle.PanelClient;
	}

	private void ResetContainerBackStyle()
	{
		ContainerBackStyle = PaletteBackStyle.PanelClient;
	}

	private bool ShouldSerializeSeparatorStyle()
	{
		return SeparatorStyle != SeparatorStyle.LowProfile;
	}

	private void ResetSeparatorStyle()
	{
		SeparatorStyle = SeparatorStyle.LowProfile;
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

	private bool ShouldSerializeStateTracking()
	{
		return !_stateTracking.IsDefault;
	}

	private bool ShouldSerializeStatePressed()
	{
		return !_statePressed.IsDefault;
	}

	public virtual void SetFixedState(PaletteState stateSplit, PaletteState stateSeparator)
	{
		_drawPanel.FixedState = stateSplit;
		_drawSeparator.FixedState = stateSeparator;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool SeparatorMoving(Point mouse, Point splitter)
	{
		if (Orientation == Orientation.Vertical)
		{
			splitter.Y = 0;
		}
		else
		{
			splitter.X = 0;
		}
		SplitterCancelEventArgs e = new SplitterCancelEventArgs(mouse.X, mouse.Y, splitter.X, splitter.Y);
		OnSplitterMoving(e);
		return e.Cancel;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void SeparatorMoved(Point mouse, Point splitter)
	{
		if (CommonHelper.GetRightToLeftLayout(this) && RightToLeft == RightToLeft.Yes)
		{
			if (Orientation == Orientation.Vertical)
			{
				SplitterDistance = base.Width - splitter.X;
			}
			else
			{
				SplitterDistance = base.Height - splitter.Y;
			}
		}
		else if (Orientation == Orientation.Vertical)
		{
			SplitterDistance = splitter.X;
		}
		else
		{
			SplitterDistance = splitter.Y;
		}
		SplitterEventArgs e = new SplitterEventArgs(mouse.X, mouse.Y, splitter.X, splitter.Y);
		OnSplitterMoved(e);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void SeparatorNotMoved()
	{
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public Cursor DesignGetHitTest(Point pt)
	{
		if ((_drawSeparator.ClientRectangle.Contains(pt) || _separatorController.IsMoving) && !Collapsed)
		{
			if (Orientation == Orientation.Vertical)
			{
				return Cursors.VSplit;
			}
			return Cursors.HSplit;
		}
		return null;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void DesignMouseEnter()
	{
		_separatorController.MouseEnter(this);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool DesignMouseDown(Point pt, MouseButtons button)
	{
		_designLastPt = pt;
		return _separatorController.MouseDown(this, pt, button);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void DesignMouseMove(Point pt)
	{
		_designLastPt = pt;
		_separatorController.MouseMove(this, pt);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void DesignMouseUp(MouseButtons button)
	{
		_separatorController.MouseUp(this, _designLastPt, button);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void DesignMouseLeave()
	{
		_separatorController.MouseLeave(this, null);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void DesignAbortMoving()
	{
		_separatorController.AbortMoving();
	}

	protected virtual void OnSplitterMoved(SplitterEventArgs e)
	{
		if (this.SplitterMoved != null)
		{
			this.SplitterMoved(this, e);
		}
	}

	protected virtual void OnSplitterMoving(SplitterCancelEventArgs e)
	{
		if (this.SplitterMoving != null)
		{
			this.SplitterMoving(this, e);
		}
	}

	protected void ForceControlLayout()
	{
		if (!base.IsInitialized)
		{
			_forcedLayout = true;
			OnLayout(new LayoutEventArgs(null, null));
			_forcedLayout = true;
		}
	}

	protected override void OnInitialized(EventArgs e)
	{
		base.OnInitialized(e);
		OnLayout(new LayoutEventArgs(null, null));
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		if (base.Enabled)
		{
			_drawPanel.SetPalettes(_stateNormal.Back);
		}
		else
		{
			_drawPanel.SetPalettes(_stateDisabled.Back);
		}
		_drawPanel.Enabled = base.Enabled;
		_drawSeparator.Enabled = base.Enabled;
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
	}

	protected override void OnResize(EventArgs e)
	{
		if (!base.IsInitializing)
		{
			if (Orientation == Orientation.Vertical)
			{
				_splitterDistance = (int)((double)base.Width * _splitterPercent);
			}
			else
			{
				_splitterDistance = (int)((double)base.Height * _splitterPercent);
			}
		}
		_resizing = true;
		base.OnResize(e);
		_resizing = false;
		ForceControlLayout();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (base.ViewManager != null && !base.IsInitialized)
		{
			BeginInit();
			EndInit();
			PerformLayout();
		}
		base.OnPaint(e);
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		Rectangle clientRectangle = Rectangle.Empty;
		if (base.IsInitialized || _forcedLayout || (base.DesignMode && _drawSeparator != null))
		{
			bool flag = CommonHelper.GetRightToLeftLayout(this) && RightToLeft == RightToLeft.Yes;
			if (base.Width == 0)
			{
				Panel1.Size = new Size(0, base.Height);
				Panel2.Size = new Size(0, base.Height);
			}
			else if (base.Height == 0)
			{
				Panel1.Size = new Size(base.Width, 0);
				Panel2.Size = new Size(base.Width, 0);
			}
			else if (!Collapsed)
			{
				if (Orientation == Orientation.Vertical)
				{
					if (FixedPanel == FixedPanel.Panel1)
					{
						Panel1.Size = new Size(_fixedDistance, base.Height);
						Panel2.Size = new Size(Math.Max(base.Width - SplitterWidth - _fixedDistance, Panel2MinSize), base.Height);
						if (flag)
						{
							Panel1.Location = new Point(Panel2.Width + SplitterWidth, 0);
							Panel2.Location = Point.Empty;
						}
						else
						{
							Panel1.Location = Point.Empty;
							Panel2.Location = new Point(Panel1.Width + SplitterWidth, 0);
						}
						_splitterDistance = Panel1.Width;
						_splitterPercent = (double)Panel1.Width / (double)base.Width;
					}
					else if (FixedPanel == FixedPanel.Panel2)
					{
						Panel2.Size = new Size(_fixedDistance, base.Height);
						Panel1.Size = new Size(Math.Max(base.Width - SplitterWidth - _fixedDistance, Panel1MinSize), base.Height);
						if (flag)
						{
							Panel1.Location = new Point(Panel2.Width + SplitterWidth, 0);
							Panel2.Location = Point.Empty;
						}
						else
						{
							Panel1.Location = Point.Empty;
							Panel2.Location = new Point(Panel1.Width + SplitterWidth, 0);
						}
						_splitterDistance = Panel1.Width;
						_splitterPercent = (double)Panel1.Width / (double)base.Width;
					}
					else
					{
						int val = base.Width - SplitterWidth;
						int val2 = Math.Min(SplitterDistance, val);
						val2 = Math.Max(Panel1MinSize, val2);
						Panel1.Size = new Size(val2, base.Height);
						Panel2.Size = new Size(base.Width - val2 - SplitterWidth, base.Height);
						if (flag)
						{
							Panel1.Location = new Point(base.Width - val2, 0);
							Panel2.Location = Point.Empty;
						}
						else
						{
							Panel1.Location = Point.Empty;
							Panel2.Location = new Point(val2 + SplitterWidth, 0);
						}
						if (!_resizing)
						{
							_splitterPercent = (double)val2 / (double)base.Width;
						}
					}
					clientRectangle = ((!flag) ? new Rectangle(Panel1.Right, 0, SplitterWidth, base.Height) : new Rectangle(Panel2.Right, 0, SplitterWidth, base.Height));
				}
				else
				{
					if (FixedPanel == FixedPanel.Panel1)
					{
						Panel1.Size = new Size(base.Width, _fixedDistance);
						Panel2.Size = new Size(base.Width, Math.Max(base.Height - SplitterWidth - _fixedDistance, Panel2MinSize));
						Panel1.Location = Point.Empty;
						Panel2.Location = new Point(0, Panel1.Height + SplitterWidth);
						_splitterDistance = Panel1.Height;
						_splitterPercent = (double)Panel1.Height / (double)base.Height;
					}
					else if (FixedPanel == FixedPanel.Panel2)
					{
						Panel2.Size = new Size(base.Width, _fixedDistance);
						Panel1.Size = new Size(base.Width, Math.Max(base.Height - SplitterWidth - _fixedDistance, Panel1MinSize));
						Panel1.Location = Point.Empty;
						Panel2.Location = new Point(0, Panel1.Height + SplitterWidth);
						_splitterDistance = Panel1.Height;
						_splitterPercent = (double)Panel1.Height / (double)base.Height;
					}
					else
					{
						int val3 = base.Height - SplitterWidth;
						int val4 = Math.Min(SplitterDistance, val3);
						val4 = Math.Max(Panel1MinSize, val4);
						Panel1.Size = new Size(base.Width, val4);
						Panel2.Size = new Size(base.Width, base.Height - val4 - SplitterWidth);
						Panel1.Location = Point.Empty;
						Panel2.Location = new Point(0, val4 + SplitterWidth);
						if (!_resizing)
						{
							_splitterPercent = (double)val4 / (double)base.Height;
						}
					}
					clientRectangle = new Rectangle(0, Panel1.Bottom, base.Width, SplitterWidth);
				}
			}
			else if (Panel1Collapsed)
			{
				Panel2.Size = base.Size;
				Panel2.Location = Point.Empty;
			}
			else if (Panel2Collapsed)
			{
				Panel1.Size = base.Size;
				Panel1.Location = Point.Empty;
			}
		}
		base.OnLayout(levent);
		if (_drawSeparator != null)
		{
			_drawSeparator.ClientRectangle = clientRectangle;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected override ControlCollection CreateControlsInstance()
	{
		return new KryptonReadOnlyControls(this);
	}

	protected override void OnAutoSizeChanged(EventArgs e)
	{
		if (this.AutoSizeChanged != null)
		{
			this.AutoSizeChanged(this, e);
		}
	}

	protected override void OnBackgroundImageChanged(EventArgs e)
	{
		if (this.BackgroundImageChanged != null)
		{
			this.BackgroundImageChanged(this, e);
		}
	}

	protected override void OnBackgroundImageLayoutChanged(EventArgs e)
	{
		if (this.BackgroundImageLayoutChanged != null)
		{
			this.BackgroundImageLayoutChanged(this, e);
		}
	}

	protected override void OnControlAdded(ControlEventArgs e)
	{
		if (this.ControlAdded != null)
		{
			this.ControlAdded(this, e);
		}
	}

	protected override void OnControlRemoved(ControlEventArgs e)
	{
		if (this.ControlRemoved != null)
		{
			this.ControlRemoved(this, e);
		}
	}

	private void SetStyles(SeparatorStyle separatorStyle)
	{
		_stateCommon.Separator.SetStyles(separatorStyle);
	}
}
