using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawTrackBar : ViewDrawPanel
{
	private static readonly Size _positionSizeSmallH = new Size(11, 15);

	private static readonly Size _positionSizeSmallV = new Size(15, 11);

	private static readonly Size _positionSizeMediumH = new Size(13, 21);

	private static readonly Size _positionSizeMediumV = new Size(21, 13);

	private static readonly Size _positionSizeLargeH = new Size(17, 27);

	private static readonly Size _positionSizeLargeV = new Size(27, 17);

	private static readonly Size _trackSizeSmall = new Size(2, 2);

	private static readonly Size _trackSizeSmallV = new Size(6, 6);

	private static readonly Size _trackSizeMedium = new Size(4, 4);

	private static readonly Size _trackSizeMediumV = new Size(11, 11);

	private static readonly Size _trackSizeLarge = new Size(5, 5);

	private static readonly Size _trackSizeLargeV = new Size(16, 16);

	private static readonly Size _tickSizeSmall = new Size(5, 5);

	private static readonly Size _tickSizeMedium = new Size(6, 6);

	private static readonly Size _tickSizeLarge = new Size(7, 7);

	private PaletteTrackBarStates _stateDisabled;

	private PaletteTrackBarStatesOverride _stateNormal;

	private PaletteTrackBarPositionStatesOverride _stateTracking;

	private PaletteTrackBarPositionStatesOverride _statePressed;

	private Padding _padding;

	private Orientation _orientation;

	private TickStyle _tickStyle;

	private int _tickFreq;

	private int _value;

	private int _minimum;

	private int _maximum;

	private int _smallChange;

	private int _largeChange;

	private bool _volumeControl;

	private ViewLayoutDocker _layoutTop;

	private ViewDrawTP _trackPosition;

	private ViewDrawTrackTicks _ticksTop;

	private ViewDrawTrackTicks _ticksBottom;

	private RightToLeft _rightToLeft;

	private PaletteTrackBarSize _trackBarSize;

	private NeedPaintHandler _needPaint;

	public ViewDrawTP TrackPosition => _trackPosition;

	public PaletteTrackBarSize TrackBarSize
	{
		get
		{
			return _trackBarSize;
		}
		set
		{
			_trackBarSize = value;
		}
	}

	public bool VolumeControl
	{
		get
		{
			return _volumeControl;
		}
		set
		{
			_volumeControl = value;
		}
	}

	public Padding Padding
	{
		get
		{
			return _padding;
		}
		set
		{
			_padding = value;
		}
	}

	public RightToLeft RightToLeft
	{
		get
		{
			return _rightToLeft;
		}
		set
		{
			_rightToLeft = value;
		}
	}

	public TickStyle TickStyle
	{
		get
		{
			return _tickStyle;
		}
		set
		{
			if (value != _tickStyle)
			{
				_tickStyle = value;
				bool visible = false;
				bool visible2 = false;
				switch (_tickStyle)
				{
				case TickStyle.TopLeft:
					visible = true;
					break;
				case TickStyle.BottomRight:
					visible2 = true;
					break;
				case TickStyle.Both:
					visible = true;
					visible2 = true;
					break;
				}
				_ticksTop.Visible = visible;
				_ticksBottom.Visible = visible2;
			}
		}
	}

	public int TickFrequency
	{
		get
		{
			return _tickFreq;
		}
		set
		{
			if (value != _tickFreq)
			{
				_tickFreq = value;
			}
		}
	}

	public Orientation Orientation
	{
		get
		{
			return _orientation;
		}
		set
		{
			if (value != _orientation)
			{
				_orientation = value;
				VisualOrientation orientation = ((_orientation != Orientation.Horizontal) ? VisualOrientation.Right : VisualOrientation.Top);
				_layoutTop.Orientation = orientation;
			}
		}
	}

	public int Maximum
	{
		get
		{
			return _maximum;
		}
		set
		{
			if (value != _maximum)
			{
				if (value < _minimum)
				{
					_minimum = value;
				}
				SetRange(Minimum, value);
			}
		}
	}

	public int Minimum
	{
		get
		{
			return _minimum;
		}
		set
		{
			if (value != _minimum)
			{
				if (value > _maximum)
				{
					_maximum = value;
				}
				SetRange(value, Maximum);
			}
		}
	}

	public int Value
	{
		get
		{
			return _value;
		}
		set
		{
			if (value != _value)
			{
				if (value < Minimum || value > Maximum)
				{
					throw new ArgumentOutOfRangeException("Value", "Provided value is out of the Minimum to Maximum range of values.");
				}
				_value = value;
				OnValueChanged(EventArgs.Empty);
			}
		}
	}

	public int ScrollValue
	{
		set
		{
			if (value != _value)
			{
				if (value < Minimum || value > Maximum)
				{
					throw new ArgumentOutOfRangeException("Value", "Provided value is out of the Minimum to Maximum range of values.");
				}
				_value = value;
				OnScroll(EventArgs.Empty);
				OnValueChanged(EventArgs.Empty);
			}
		}
	}

	public int SmallChange
	{
		get
		{
			return _smallChange;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("SmallChange", "SmallChange cannot be less than zero.");
			}
			_smallChange = value;
		}
	}

	public int LargeChange
	{
		get
		{
			return _largeChange;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("LargeChange", "LargeChange cannot be less than zero.");
			}
			_largeChange = value;
		}
	}

	public override bool Enabled
	{
		get
		{
			return base.Enabled;
		}
		set
		{
			base.Enabled = value;
			_layoutTop.Enabled = value;
			_trackPosition.Enabled = value;
			_ticksTop.Enabled = value;
			_ticksBottom.Enabled = value;
		}
	}

	public Size PositionSize => _trackBarSize switch
	{
		PaletteTrackBarSize.Small => (_orientation == Orientation.Horizontal) ? _positionSizeSmallH : _positionSizeSmallV, 
		PaletteTrackBarSize.Large => (_orientation == Orientation.Horizontal) ? _positionSizeLargeH : _positionSizeLargeV, 
		_ => (_orientation == Orientation.Horizontal) ? _positionSizeMediumH : _positionSizeMediumV, 
	};

	public Size TrackSize => _trackBarSize switch
	{
		PaletteTrackBarSize.Small => VolumeControl ? _trackSizeSmallV : _trackSizeSmall, 
		PaletteTrackBarSize.Large => VolumeControl ? _trackSizeLargeV : _trackSizeLarge, 
		_ => VolumeControl ? _trackSizeMediumV : _trackSizeMedium, 
	};

	public Size TickSize => _trackBarSize switch
	{
		PaletteTrackBarSize.Small => _tickSizeSmall, 
		PaletteTrackBarSize.Large => _tickSizeLarge, 
		_ => _tickSizeMedium, 
	};

	public PaletteTrackBarStatesOverride StateNormal => _stateNormal;

	public PaletteTrackBarStates StateDisabled => _stateDisabled;

	public PaletteTrackBarPositionStatesOverride StateTracking => _stateTracking;

	public PaletteTrackBarPositionStatesOverride StatePressed => _statePressed;

	public event EventHandler ValueChanged;

	public event EventHandler Scroll;

	public ViewDrawTrackBar(PaletteTrackBarStatesOverride stateNormal, PaletteTrackBarStates stateDisabled, PaletteTrackBarPositionStatesOverride stateTracking, PaletteTrackBarPositionStatesOverride statePressed, NeedPaintHandler needPaint)
		: base(stateNormal.Back)
	{
		_stateNormal = stateNormal;
		_stateDisabled = stateDisabled;
		_stateTracking = stateTracking;
		_statePressed = statePressed;
		_padding = Padding.Empty;
		_orientation = Orientation.Horizontal;
		_value = 0;
		_minimum = 0;
		_maximum = 10;
		_smallChange = 1;
		_largeChange = 5;
		_tickFreq = 1;
		_tickStyle = TickStyle.BottomRight;
		_trackBarSize = PaletteTrackBarSize.Medium;
		_volumeControl = false;
		_needPaint = needPaint;
		_trackPosition = new ViewDrawTP(this);
		_ticksTop = new ViewDrawTrackTicks(this, topRight: true);
		_ticksBottom = new ViewDrawTrackTicks(this, topRight: false);
		_ticksTop.Visible = false;
		_ticksBottom.Visible = true;
		_layoutTop = new ViewLayoutDocker();
		_layoutTop.Add(_ticksTop, ViewDockStyle.Top);
		_layoutTop.Add(_trackPosition, ViewDockStyle.Top);
		_layoutTop.Add(_ticksBottom, ViewDockStyle.Top);
		_layoutTop.Padding = Padding;
		Add(_layoutTop);
	}

	public override string ToString()
	{
		return "ViewDrawTrackBar:" + base.Id;
	}

	public void SetRange(int minValue, int maxValue)
	{
		if (Minimum != minValue || Maximum != maxValue)
		{
			if (minValue > maxValue)
			{
				minValue = maxValue;
			}
			_minimum = minValue;
			_maximum = maxValue;
			int value = _value;
			if (_value < _minimum)
			{
				_value = _minimum;
			}
			if (_value > _maximum)
			{
				_value = _maximum;
			}
			if (value != _value)
			{
				OnValueChanged(EventArgs.Empty);
			}
		}
	}

	public virtual void SetFixedState(PaletteState state)
	{
		if (state == PaletteState.Normal || state == PaletteState.Disabled)
		{
			_ticksTop.FixedState = state;
			_ticksBottom.FixedState = state;
		}
		_trackPosition.SetFixedState(state);
	}

	public void OnMouseWheel(MouseEventArgs e)
	{
		int num = ((e.Delta > 0) ? (-SmallChange) : SmallChange);
		int num2 = Math.Abs(e.Delta) / SystemInformation.MouseWheelScrollDelta;
		for (int i = 0; i < num2; i++)
		{
			ScrollValue = Math.Max(Minimum, Math.Min(Value - num, Maximum));
		}
	}

	public void PerformNeedPaint(bool needLayout)
	{
		if (_needPaint != null)
		{
			_needPaint(this, new NeedLayoutEventArgs(needLayout));
		}
	}

	protected virtual void OnValueChanged(EventArgs e)
	{
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
}
