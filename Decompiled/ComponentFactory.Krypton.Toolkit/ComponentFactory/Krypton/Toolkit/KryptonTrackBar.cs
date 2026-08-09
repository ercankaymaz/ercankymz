using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonTrackBar), "ToolboxBitmaps.KryptonTrackBar.bmp")]
[DefaultEvent("ValueChanged")]
[DefaultProperty("Value")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonTrackBarDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Allow user to scroll between a range of values.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonTrackBar : VisualSimpleBase
{
	private ViewDrawTrackBar _drawTrackBar;

	private PaletteTrackBarRedirect _stateCommon;

	private PaletteTrackBarRedirect _stateFocus;

	private PaletteTrackBarStates _stateDisabled;

	private PaletteTrackBarStates _stateNormal;

	private PaletteTrackBarPositionStates _stateTracking;

	private PaletteTrackBarPositionStates _statePressed;

	private PaletteTrackBarStatesOverride _overrideNormal;

	private PaletteTrackBarPositionStatesOverride _overrideTracking;

	private PaletteTrackBarPositionStatesOverride _overridePressed;

	private bool _autoSize;

	private bool _inRibbonDesignMode;

	private int _requestedDim;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new ImeMode ImeMode
	{
		get
		{
			return base.ImeMode;
		}
		set
		{
			base.ImeMode = value;
		}
	}

	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[DefaultValue(true)]
	public override bool AutoSize
	{
		get
		{
			return _autoSize;
		}
		set
		{
			if (value != _autoSize)
			{
				_autoSize = value;
				if (Orientation == Orientation.Horizontal)
				{
					SetStyle(ControlStyles.FixedHeight, _autoSize);
					SetStyle(ControlStyles.FixedWidth, value: false);
				}
				else
				{
					SetStyle(ControlStyles.FixedWidth, _autoSize);
					SetStyle(ControlStyles.FixedHeight, value: false);
				}
				AdjustSize();
				OnAutoSizeChanged(EventArgs.Empty);
			}
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
			base.AutoSizeMode = value;
		}
	}

	[DefaultValue(typeof(Padding), "0,0,0,0")]
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

	[Category("Visuals")]
	[Description("Background style.")]
	public PaletteBackStyle BackStyle
	{
		get
		{
			return _stateFocus.BackStyle;
		}
		set
		{
			if (_stateFocus.BackStyle != value)
			{
				_stateFocus.BackStyle = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining track bar appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTrackBarRedirect OverrideFocus => _stateFocus;

	[Category("Visuals")]
	[Description("Overrides for defining common trackbar appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTrackBarRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled trackbar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTrackBarStates StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal trackbar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTrackBarStates StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Overrides for defining tracking trackbar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTrackBarPositionStates StateTracking => _stateTracking;

	[Category("Visuals")]
	[Description("Overrides for defining pressed trackbar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTrackBarPositionStates StatePressed => _statePressed;

	[Category("Appearance")]
	[Description("Determines if the control display like a volume control.")]
	[DefaultValue(false)]
	public bool VolumeControl
	{
		get
		{
			return _drawTrackBar.VolumeControl;
		}
		set
		{
			if (value != _drawTrackBar.VolumeControl)
			{
				_drawTrackBar.VolumeControl = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Appearance")]
	[Description("Determines size of the track bar elements.")]
	[DefaultValue(typeof(PaletteTrackBarSize), "Medium")]
	public PaletteTrackBarSize TrackBarSize
	{
		get
		{
			return _drawTrackBar.TrackBarSize;
		}
		set
		{
			if (value != _drawTrackBar.TrackBarSize)
			{
				_drawTrackBar.TrackBarSize = value;
				AdjustSize();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Appearance")]
	[Description("Determines where tick marks are displayed.")]
	[DefaultValue(typeof(TickStyle), "BottomRight")]
	[RefreshProperties(RefreshProperties.All)]
	public TickStyle TickStyle
	{
		get
		{
			return _drawTrackBar.TickStyle;
		}
		set
		{
			if (value != _drawTrackBar.TickStyle)
			{
				_drawTrackBar.TickStyle = value;
				AdjustSize();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Appearance")]
	[Description("Determines the frequency of tick marks.")]
	[DefaultValue(1)]
	public int TickFrequency
	{
		get
		{
			return _drawTrackBar.TickFrequency;
		}
		set
		{
			if (value != _drawTrackBar.TickFrequency)
			{
				_drawTrackBar.TickFrequency = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Appearance")]
	[Description("Background style.")]
	[DefaultValue(typeof(Orientation), "Horizontal")]
	public Orientation Orientation
	{
		get
		{
			return _drawTrackBar.Orientation;
		}
		set
		{
			if (value != _drawTrackBar.Orientation)
			{
				_drawTrackBar.Orientation = value;
				if (Orientation == Orientation.Horizontal)
				{
					SetStyle(ControlStyles.FixedHeight, _autoSize);
					SetStyle(ControlStyles.FixedWidth, value: false);
					base.Width = base.Height;
				}
				else
				{
					SetStyle(ControlStyles.FixedHeight, value: false);
					SetStyle(ControlStyles.FixedWidth, _autoSize);
					base.Height = base.Width;
				}
				if (base.IsHandleCreated)
				{
					AdjustSize();
				}
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Behavior")]
	[Description("Upper limit of the trackbar range.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(10)]
	public int Maximum
	{
		get
		{
			return _drawTrackBar.Maximum;
		}
		set
		{
			if (value != _drawTrackBar.Maximum)
			{
				_drawTrackBar.Maximum = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Behavior")]
	[Description("Lower limit of the trackbar range.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(0)]
	public int Minimum
	{
		get
		{
			return _drawTrackBar.Minimum;
		}
		set
		{
			if (value != _drawTrackBar.Minimum)
			{
				_drawTrackBar.Minimum = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Behavior")]
	[Description("Current position of the indicator within the trackbar.")]
	[DefaultValue(0)]
	public int Value
	{
		get
		{
			return _drawTrackBar.Value;
		}
		set
		{
			if (value != _drawTrackBar.Value)
			{
				_drawTrackBar.Value = value;
			}
		}
	}

	[Category("Behavior")]
	[Description("Change to apply when a small change occurs.")]
	[DefaultValue(1)]
	public int SmallChange
	{
		get
		{
			return _drawTrackBar.SmallChange;
		}
		set
		{
			_drawTrackBar.SmallChange = value;
		}
	}

	[Category("Behavior")]
	[Description("Change to apply when a large change occurs.")]
	[DefaultValue(5)]
	public int LargeChange
	{
		get
		{
			return _drawTrackBar.LargeChange;
		}
		set
		{
			_drawTrackBar.LargeChange = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public bool DrawBackground
	{
		get
		{
			return !_drawTrackBar.IgnoreRender;
		}
		set
		{
			_drawTrackBar.IgnoreRender = !value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public bool InRibbonDesignMode
	{
		get
		{
			return _inRibbonDesignMode;
		}
		set
		{
			_inRibbonDesignMode = value;
		}
	}

	protected override Size DefaultSize => new Size(150, 35);

	internal bool InTransparentDesignMode => InRibbonDesignMode;

	[Category("Action")]
	[Description("Occurs when the value of the Value property changes.")]
	public event EventHandler ValueChanged;

	[Category("Behavior")]
	[Description("Occurs when either a mouse or keyboard action moves the scroll box.")]
	public event EventHandler Scroll;

	public KryptonTrackBar()
	{
		_autoSize = true;
		_requestedDim = 0;
		_stateCommon = new PaletteTrackBarRedirect(base.Redirector, base.NeedPaintDelegate);
		_stateFocus = new PaletteTrackBarRedirect(base.Redirector, base.NeedPaintDelegate);
		_stateDisabled = new PaletteTrackBarStates(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteTrackBarStates(_stateCommon, base.NeedPaintDelegate);
		_stateTracking = new PaletteTrackBarPositionStates(_stateCommon, base.NeedPaintDelegate);
		_statePressed = new PaletteTrackBarPositionStates(_stateCommon, base.NeedPaintDelegate);
		_overrideNormal = new PaletteTrackBarStatesOverride(_stateFocus, _stateNormal, PaletteState.FocusOverride);
		_overrideTracking = new PaletteTrackBarPositionStatesOverride(_stateFocus, _stateTracking, PaletteState.FocusOverride);
		_overridePressed = new PaletteTrackBarPositionStatesOverride(_stateFocus, _statePressed, PaletteState.FocusOverride);
		_drawTrackBar = new ViewDrawTrackBar(_overrideNormal, _stateDisabled, _overrideTracking, _overridePressed, base.NeedPaintDelegate);
		_drawTrackBar.ValueChanged += OnDrawValueChanged;
		_drawTrackBar.Scroll += OnDrawScroll;
		_drawTrackBar.RightToLeft = RightToLeft;
		base.ViewManager = new ViewManager(this, _drawTrackBar);
	}

	private bool ShouldSerializeBackStyle()
	{
		return BackStyle != PaletteBackStyle.PanelClient;
	}

	private void ResetBackStyle()
	{
		BackStyle = PaletteBackStyle.PanelClient;
	}

	private bool ShouldSerializeOverrideFocus()
	{
		return !_stateFocus.IsDefault;
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

	public void SetRange(int minValue, int maxValue)
	{
		if (Minimum != minValue || Maximum != maxValue)
		{
			_drawTrackBar.SetRange(minValue, maxValue);
			PerformNeedPaint(needLayout: true);
		}
	}

	public virtual void SetFixedState(PaletteState state)
	{
		_drawTrackBar.SetFixedState(state);
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		AdjustSize();
	}

	protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
	{
		_requestedDim = ((Orientation == Orientation.Horizontal) ? height : width);
		if (_autoSize)
		{
			if (Orientation == Orientation.Horizontal)
			{
				if ((specified & BoundsSpecified.Height) != BoundsSpecified.None)
				{
					height = GetPreferredSize(Size.Empty).Height;
				}
			}
			else if ((specified & BoundsSpecified.Width) != BoundsSpecified.None)
			{
				width = GetPreferredSize(Size.Empty).Width;
			}
		}
		base.SetBoundsCore(x, y, width, height, specified);
	}

	protected override bool IsInputKey(Keys keyData)
	{
		Keys keys = keyData & ~Keys.Shift;
		Keys keys2 = keys;
		if ((uint)(keys2 - 33) <= 7u)
		{
			return true;
		}
		return base.IsInputKey(keyData);
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		_drawTrackBar.OnMouseWheel(e);
		base.OnMouseWheel(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (base.CanFocus)
		{
			Focus();
		}
		base.OnMouseDown(e);
	}

	protected override void OnGotFocus(EventArgs e)
	{
		if (!_drawTrackBar.TrackPosition.IsFixed)
		{
			_overrideNormal.Apply = true;
			_overrideTracking.Apply = true;
			_overridePressed.Apply = true;
			PerformNeedPaint(needLayout: true);
		}
		base.OnGotFocus(e);
	}

	protected override void OnLostFocus(EventArgs e)
	{
		if (!_drawTrackBar.TrackPosition.IsFixed)
		{
			_overrideNormal.Apply = false;
			_overrideTracking.Apply = false;
			_overridePressed.Apply = false;
			PerformNeedPaint(needLayout: false);
		}
		base.OnLostFocus(e);
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		_drawTrackBar.Enabled = base.Enabled;
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
	}

	protected override void OnPaddingChanged(EventArgs e)
	{
		_drawTrackBar.Padding = Padding;
		AdjustSize();
		PerformNeedPaint(needLayout: true);
		base.OnPaddingChanged(e);
	}

	protected virtual void OnValueChanged(EventArgs e)
	{
		PerformNeedPaint(needLayout: true);
		if (this.ValueChanged != null)
		{
			this.ValueChanged(this, e);
		}
	}

	protected virtual void OnScroll(EventArgs e)
	{
		if (this.Scroll != null)
		{
			this.Scroll(this, e);
		}
	}

	protected override void OnRightToLeftChanged(EventArgs e)
	{
		_drawTrackBar.RightToLeft = RightToLeft;
		PerformNeedPaint(needLayout: true);
		base.OnRightToLeftChanged(e);
	}

	protected override void WndProc(ref Message m)
	{
		int msg = m.Msg;
		int num = msg;
		if (num == 132)
		{
			if (InTransparentDesignMode)
			{
				m.Result = (IntPtr)(-1);
			}
			else
			{
				base.WndProc(ref m);
			}
		}
		else
		{
			base.WndProc(ref m);
		}
	}

	protected override bool EvalTransparentPaint()
	{
		return !DrawBackground;
	}

	private void AdjustSize()
	{
		if (!base.IsHandleCreated)
		{
			return;
		}
		int requestedDim = _requestedDim;
		try
		{
			if (Orientation == Orientation.Horizontal)
			{
				base.Height = (_autoSize ? GetPreferredSize(Size.Empty).Height : requestedDim);
			}
			else
			{
				base.Width = (_autoSize ? GetPreferredSize(Size.Empty).Width : requestedDim);
			}
		}
		finally
		{
			_requestedDim = requestedDim;
		}
	}

	private void OnDrawValueChanged(object sender, EventArgs e)
	{
		OnValueChanged(e);
	}

	private void OnDrawScroll(object sender, EventArgs e)
	{
		OnScroll(e);
	}
}
