using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonSeparator), "ToolboxBitmaps.KryptonSeparator.bmp")]
[DefaultEvent("SplitterMoved")]
[DefaultProperty("Orientation")]
[DesignerCategory("code")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonSeparatorDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[Description("Display a separator generated events to operation.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonSeparator : VisualControl, ISeparatorSource
{
	private SeparatorStyle _style;

	private ViewDrawDocker _drawDocker;

	private ViewDrawSeparator _drawSeparator;

	private SeparatorController _separatorController;

	private PaletteSplitContainerRedirect _stateCommon;

	private PaletteSplitContainer _stateDisabled;

	private PaletteSplitContainer _stateNormal;

	private PaletteSeparatorPadding _stateTracking;

	private PaletteSeparatorPadding _statePressed;

	private Orientation _orientation;

	private Timer _redrawTimer;

	private Point _designLastPt;

	private int _splitterWidth;

	private int _splitterIncrements;

	private bool _allowMove;

	[Browsable(false)]
	[Bindable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	public override Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
			base.BackColor = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			base.Font = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	public override Color ForeColor
	{
		get
		{
			return base.ForeColor;
		}
		set
		{
			base.ForeColor = value;
		}
	}

	[Category("Visuals")]
	[Description("Separator background style.")]
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
				_stateCommon.Separator.SetStyles(_style);
				_drawSeparator.MetricPadding = CommonHelper.SeparatorStyleToMetricPadding(_style);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining common separator appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteSplitContainerRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled separator appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteSplitContainer StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal separator appearance.")]
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
				UpdateSize();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Layout")]
	[Description("Determines the increment used for moving.")]
	[DefaultValue(typeof(int), "1")]
	public int SplitterIncrements
	{
		get
		{
			return _splitterIncrements;
		}
		set
		{
			_splitterIncrements = value;
		}
	}

	[Category("Layout")]
	[Description("Determines if the separator is vertical or horizontal.")]
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
			if (_orientation != value)
			{
				_orientation = value;
				_drawSeparator.Orientation = _orientation;
				UpdateSize();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Behavior")]
	[Description("Determines if the separator is allowed to notify a move.")]
	[DefaultValue(true)]
	public bool AllowMove
	{
		get
		{
			return _allowMove;
		}
		set
		{
			_allowMove = value;
		}
	}

	[Category("Appearance")]
	[Description("Determines if the move indicator is drawn when moving the separator.")]
	[DefaultValue(true)]
	public bool DrawMoveIndicator
	{
		get
		{
			return _separatorController.DrawMoveIndicator;
		}
		set
		{
			_separatorController.DrawMoveIndicator = value;
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
	public bool SeparatorCanMove => AllowMove;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SeparatorIncrements => SplitterIncrements;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle SeparatorMoveBox
	{
		get
		{
			SplitterMoveRectMenuArgs splitterMoveRectMenuArgs = new SplitterMoveRectMenuArgs(Rectangle.Empty);
			OnSplitterMoveRect(splitterMoveRectMenuArgs);
			if (Orientation == Orientation.Horizontal)
			{
				return new Rectangle(0, splitterMoveRectMenuArgs.MoveRect.Y, 0, splitterMoveRectMenuArgs.MoveRect.Height);
			}
			return new Rectangle(splitterMoveRectMenuArgs.MoveRect.X, 0, splitterMoveRectMenuArgs.MoveRect.Width, 0);
		}
	}

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

	protected override Size DefaultSize => new Size(5, 5);

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
	[Description("Occurs when the separator is about to be moved and requests the rectangle of allowed movement.")]
	public event EventHandler<SplitterMoveRectMenuArgs> SplitterMoveRect;

	[Category("Behavior")]
	[Description("Occurs when the separator move finishes and a move has occured.")]
	public event SplitterEventHandler SplitterMoved;

	[Category("Behavior")]
	[Description("Occurs when the separator move finishes and a move has not occured.")]
	public event EventHandler SplitterNotMoved;

	[Category("Behavior")]
	[Description("Occurs when the separator is currently in the process of moving.")]
	public event SplitterCancelEventHandler SplitterMoving;

	public KryptonSeparator()
	{
		SetStyle(ControlStyles.Selectable, value: false);
		_stateCommon = new PaletteSplitContainerRedirect(base.Redirector, PaletteBackStyle.PanelClient, PaletteBorderStyle.ControlClient, PaletteBackStyle.SeparatorHighProfile, PaletteBorderStyle.SeparatorHighProfile, base.NeedPaintDelegate);
		_stateCommon.BorderRedirect.OverrideBorderToFalse = true;
		_stateDisabled = new PaletteSplitContainer(_stateCommon, _stateCommon.Separator, _stateCommon.Separator, base.NeedPaintDelegate);
		_stateNormal = new PaletteSplitContainer(_stateCommon, _stateCommon.Separator, _stateCommon.Separator, base.NeedPaintDelegate);
		_stateTracking = new PaletteSeparatorPadding(_stateCommon.Separator, _stateCommon.Separator, base.NeedPaintDelegate);
		_statePressed = new PaletteSeparatorPadding(_stateCommon.Separator, _stateCommon.Separator, base.NeedPaintDelegate);
		_drawSeparator = new ViewDrawSeparator(_stateDisabled.Separator, _stateNormal.Separator, _stateTracking, _statePressed, _stateDisabled.Separator, _stateNormal.Separator, _stateTracking, _statePressed, PaletteMetricPadding.SeparatorPaddingLowProfile, Orientation.Vertical);
		_drawDocker = new ViewDrawDocker(_stateNormal.Back, _stateNormal.Border);
		_drawDocker.IgnoreAllBorderAndPadding = true;
		_drawDocker.Add(_drawSeparator, ViewDockStyle.Fill);
		_separatorController = new SeparatorController(this, _drawSeparator, splitCursors: true, drawIndicator: true, base.NeedPaintDelegate);
		_drawSeparator.MouseController = _separatorController;
		_drawSeparator.KeyController = _separatorController;
		_drawSeparator.SourceController = _separatorController;
		base.ViewManager = new ViewManager(this, _drawDocker);
		_redrawTimer = new Timer();
		_redrawTimer.Interval = 1;
		_redrawTimer.Tick += OnRedrawTick;
		_style = SeparatorStyle.HighProfile;
		_orientation = Orientation.Vertical;
		_allowMove = true;
		_splitterIncrements = 1;
		_splitterWidth = 5;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (_redrawTimer != null)
			{
				_redrawTimer.Stop();
				_redrawTimer.Dispose();
				_redrawTimer = null;
			}
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
		return SeparatorStyle != SeparatorStyle.HighProfile;
	}

	private void ResetSeparatorStyle()
	{
		SeparatorStyle = SeparatorStyle.HighProfile;
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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool SeparatorMoving(Point mouse, Point splitter)
	{
		SplitterCancelEventArgs e = new SplitterCancelEventArgs(mouse.X, mouse.Y, splitter.X, splitter.Y);
		OnSplitterMoving(e);
		return e.Cancel;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void SeparatorMoved(Point mouse, Point splitter)
	{
		SplitterEventArgs e = new SplitterEventArgs(mouse.X, mouse.Y, splitter.X, splitter.Y);
		OnSplitterMoved(e);
		if (_redrawTimer != null)
		{
			_redrawTimer.Start();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void SeparatorNotMoved()
	{
		OnSplitterNotMoved(EventArgs.Empty);
		if (_redrawTimer != null)
		{
			_redrawTimer.Start();
		}
	}

	protected virtual void OnSplitterMoveRect(SplitterMoveRectMenuArgs e)
	{
		if (this.SplitterMoveRect != null)
		{
			this.SplitterMoveRect(this, e);
		}
	}

	protected virtual void OnSplitterMoved(SplitterEventArgs e)
	{
		if (this.SplitterMoved != null)
		{
			this.SplitterMoved(this, e);
		}
	}

	protected virtual void OnSplitterNotMoved(EventArgs e)
	{
		if (this.SplitterNotMoved != null)
		{
			this.SplitterNotMoved(this, e);
		}
	}

	protected virtual void OnSplitterMoving(SplitterCancelEventArgs e)
	{
		if (this.SplitterMoving != null)
		{
			this.SplitterMoving(this, e);
		}
	}

	protected override void OnInitialized(EventArgs e)
	{
		base.OnInitialized(e);
		PerformNeedPaint(needLayout: true);
	}

	protected override void OnDockChanged(EventArgs e)
	{
		UpdateSize();
		base.OnDockChanged(e);
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		if (base.Enabled)
		{
			_drawDocker.SetPalettes(_stateNormal.Back, _stateNormal.Border);
		}
		else
		{
			_drawDocker.SetPalettes(_stateDisabled.Back, _stateDisabled.Border);
		}
		_drawDocker.Enabled = base.Enabled;
		_drawSeparator.Enabled = base.Enabled;
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
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

	internal Cursor DesignGetHitTest(Point pt)
	{
		if (_drawSeparator.ClientRectangle.Contains(pt) || _separatorController.IsMoving)
		{
			if (Orientation == Orientation.Vertical)
			{
				return Cursors.VSplit;
			}
			return Cursors.HSplit;
		}
		return null;
	}

	internal void DesignMouseEnter()
	{
		_separatorController.MouseEnter(this);
	}

	internal bool DesignMouseDown(Point pt, MouseButtons button)
	{
		_designLastPt = pt;
		return _separatorController.MouseDown(this, pt, button);
	}

	internal void DesignMouseMove(Point pt)
	{
		_designLastPt = pt;
		_separatorController.MouseMove(this, pt);
	}

	internal void DesignMouseUp(MouseButtons button)
	{
		_separatorController.MouseUp(this, _designLastPt, button);
	}

	internal void DesignMouseLeave()
	{
		_separatorController.MouseLeave(this, null);
	}

	internal void DesignAbortMoving()
	{
		_separatorController.AbortMoving();
	}

	private void UpdateSize()
	{
		if (Dock != DockStyle.None && Dock != DockStyle.Fill)
		{
			if (Orientation == Orientation.Vertical)
			{
				base.Size = new Size(base.Width, _splitterWidth);
			}
			else
			{
				base.Size = new Size(_splitterWidth, base.Height);
			}
		}
	}

	private void OnRedrawTick(object sender, EventArgs e)
	{
		if (_redrawTimer != null)
		{
			_redrawTimer.Stop();
		}
		Refresh();
	}
}
