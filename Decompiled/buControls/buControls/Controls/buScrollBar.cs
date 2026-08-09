using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns27;

namespace buControls.Controls;

public class buScrollBar : buControl
{
	public delegate void ValueChangedEvent(double NewValue, double OldValue);

	[CompilerGenerated]
	private buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler_0;

	[CompilerGenerated]
	private buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler_1;

	[CompilerGenerated]
	private buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler_2;

	private double double_0;

	private MouseState mouseState_0;

	private MouseState mouseState_1;

	private ThemeType themeType_0 = ThemeType.Standart;

	private bool bool_0 = false;

	private buControlDisplay buControlDisplay_1 = new buControlDisplay();

	private buControlDisplay buControlDisplay_2 = new buControlDisplay();

	private buControlDisplay buControlDisplay_3 = new buControlDisplay();

	private buControlDisplay buControlDisplay_4 = new buControlDisplay();

	private buControlDisplay buControlDisplay_5 = new buControlDisplay();

	private buControlDisplay buControlDisplay_6 = new buControlDisplay();

	private buControlDisplay buControlDisplay_7 = new buControlDisplay();

	private ScrollBarType scrollBarType_0 = ScrollBarType.Vertical;

	private float float_0 = 20f;

	private float float_1 = 20f;

	private float float_2 = 1f;

	private int int_3 = 0;

	private int int_4 = 10;

	private double double_1 = 0.0;

	private double double_2 = 0.0;

	private string string_1 = "+";

	private string string_2 = "-";

	public double OldValue = 0.0;

	[CompilerGenerated]
	private ValueChangedEvent valueChangedEvent_0;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay ButtonPlusOverDisplay
	{
		get
		{
			return buControlDisplay_1;
		}
		set
		{
			buControlDisplay_1 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay ButtonPlusNormalDisplay
	{
		get
		{
			return buControlDisplay_2;
		}
		set
		{
			buControlDisplay_2 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay ButtonPlusDownDisplay
	{
		get
		{
			return buControlDisplay_3;
		}
		set
		{
			buControlDisplay_3 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay ButtonMinusOverDisplay
	{
		get
		{
			return buControlDisplay_4;
		}
		set
		{
			buControlDisplay_4 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay ButtonMinusNormalDisplay
	{
		get
		{
			return buControlDisplay_5;
		}
		set
		{
			buControlDisplay_5 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay ButtonMinusDownDisplay
	{
		get
		{
			return buControlDisplay_6;
		}
		set
		{
			buControlDisplay_6 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DefaultValue(1f)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public float Increament
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
			Invalidate();
		}
	}

	[DefaultValue(20f)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public float ButtonSize
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			Invalidate();
		}
	}

	[DefaultValue("+")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string PlusString
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
			Invalidate();
		}
	}

	[DefaultValue("-")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string MinusString
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
			Invalidate();
		}
	}

	[DefaultValue(0f)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public double Value
	{
		get
		{
			return double_1;
		}
		set
		{
			OldValue = double_1;
			double_1 = value;
			if (valueChangedEvent_0 != null && OldValue != double_1)
			{
				valueChangedEvent_0(double_1, OldValue);
			}
			Invalidate();
		}
	}

	[DefaultValue(20f)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public float ScrollWidth
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
			Invalidate();
		}
	}

	[DefaultValue(0)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int MinimumValue
	{
		get
		{
			return int_3;
		}
		set
		{
			if (value >= int_4)
			{
				value = int_4;
			}
			if (double_1 < (double)value)
			{
				double_1 = value;
			}
			int_3 = value;
			Invalidate();
		}
	}

	[DefaultValue(10)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int MaximumValue
	{
		get
		{
			return int_4;
		}
		set
		{
			if (value <= int_3)
			{
				value = int_3;
			}
			if (double_1 > (double)value)
			{
				double_1 = value;
			}
			int_4 = value;
			Invalidate();
		}
	}

	[DefaultValue(ScrollBarType.Vertical)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public ScrollBarType ScrollPositionStyle
	{
		get
		{
			return scrollBarType_0;
		}
		set
		{
			scrollBarType_0 = value;
			Invalidate();
		}
	}

	[DefaultValue(1)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public double Direction
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
			Invalidate();
		}
	}

	public event buControlEvents.buButtonPlusMinusMouseEventHandler MouseDownScrollBar
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler = buButtonPlusMinusMouseEventHandler_0;
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler2;
			do
			{
				buButtonPlusMinusMouseEventHandler2 = buButtonPlusMinusMouseEventHandler;
				buControlEvents.buButtonPlusMinusMouseEventHandler value2 = (buControlEvents.buButtonPlusMinusMouseEventHandler)Delegate.Combine(buButtonPlusMinusMouseEventHandler2, value);
				buButtonPlusMinusMouseEventHandler = Interlocked.CompareExchange(ref buButtonPlusMinusMouseEventHandler_0, value2, buButtonPlusMinusMouseEventHandler2);
			}
			while ((object)buButtonPlusMinusMouseEventHandler != buButtonPlusMinusMouseEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler = buButtonPlusMinusMouseEventHandler_0;
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler2;
			do
			{
				buButtonPlusMinusMouseEventHandler2 = buButtonPlusMinusMouseEventHandler;
				buControlEvents.buButtonPlusMinusMouseEventHandler value2 = (buControlEvents.buButtonPlusMinusMouseEventHandler)Delegate.Remove(buButtonPlusMinusMouseEventHandler2, value);
				buButtonPlusMinusMouseEventHandler = Interlocked.CompareExchange(ref buButtonPlusMinusMouseEventHandler_0, value2, buButtonPlusMinusMouseEventHandler2);
			}
			while ((object)buButtonPlusMinusMouseEventHandler != buButtonPlusMinusMouseEventHandler2);
		}
	}

	public event buControlEvents.buButtonPlusMinusMouseEventHandler MouseUpScrollBar
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler = buButtonPlusMinusMouseEventHandler_1;
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler2;
			do
			{
				buButtonPlusMinusMouseEventHandler2 = buButtonPlusMinusMouseEventHandler;
				buControlEvents.buButtonPlusMinusMouseEventHandler value2 = (buControlEvents.buButtonPlusMinusMouseEventHandler)Delegate.Combine(buButtonPlusMinusMouseEventHandler2, value);
				buButtonPlusMinusMouseEventHandler = Interlocked.CompareExchange(ref buButtonPlusMinusMouseEventHandler_1, value2, buButtonPlusMinusMouseEventHandler2);
			}
			while ((object)buButtonPlusMinusMouseEventHandler != buButtonPlusMinusMouseEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler = buButtonPlusMinusMouseEventHandler_1;
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler2;
			do
			{
				buButtonPlusMinusMouseEventHandler2 = buButtonPlusMinusMouseEventHandler;
				buControlEvents.buButtonPlusMinusMouseEventHandler value2 = (buControlEvents.buButtonPlusMinusMouseEventHandler)Delegate.Remove(buButtonPlusMinusMouseEventHandler2, value);
				buButtonPlusMinusMouseEventHandler = Interlocked.CompareExchange(ref buButtonPlusMinusMouseEventHandler_1, value2, buButtonPlusMinusMouseEventHandler2);
			}
			while ((object)buButtonPlusMinusMouseEventHandler != buButtonPlusMinusMouseEventHandler2);
		}
	}

	public event buControlEvents.buButtonPlusMinusMouseEventHandler MouseMoveScrollBar
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler = buButtonPlusMinusMouseEventHandler_2;
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler2;
			do
			{
				buButtonPlusMinusMouseEventHandler2 = buButtonPlusMinusMouseEventHandler;
				buControlEvents.buButtonPlusMinusMouseEventHandler value2 = (buControlEvents.buButtonPlusMinusMouseEventHandler)Delegate.Combine(buButtonPlusMinusMouseEventHandler2, value);
				buButtonPlusMinusMouseEventHandler = Interlocked.CompareExchange(ref buButtonPlusMinusMouseEventHandler_2, value2, buButtonPlusMinusMouseEventHandler2);
			}
			while ((object)buButtonPlusMinusMouseEventHandler != buButtonPlusMinusMouseEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler = buButtonPlusMinusMouseEventHandler_2;
			buControlEvents.buButtonPlusMinusMouseEventHandler buButtonPlusMinusMouseEventHandler2;
			do
			{
				buButtonPlusMinusMouseEventHandler2 = buButtonPlusMinusMouseEventHandler;
				buControlEvents.buButtonPlusMinusMouseEventHandler value2 = (buControlEvents.buButtonPlusMinusMouseEventHandler)Delegate.Remove(buButtonPlusMinusMouseEventHandler2, value);
				buButtonPlusMinusMouseEventHandler = Interlocked.CompareExchange(ref buButtonPlusMinusMouseEventHandler_2, value2, buButtonPlusMinusMouseEventHandler2);
			}
			while ((object)buButtonPlusMinusMouseEventHandler != buButtonPlusMinusMouseEventHandler2);
		}
	}

	public event ValueChangedEvent ValueChanged
	{
		[CompilerGenerated]
		add
		{
			ValueChangedEvent valueChangedEvent = valueChangedEvent_0;
			ValueChangedEvent valueChangedEvent2;
			do
			{
				valueChangedEvent2 = valueChangedEvent;
				ValueChangedEvent value2 = (ValueChangedEvent)Delegate.Combine(valueChangedEvent2, value);
				valueChangedEvent = Interlocked.CompareExchange(ref valueChangedEvent_0, value2, valueChangedEvent2);
			}
			while ((object)valueChangedEvent != valueChangedEvent2);
		}
		[CompilerGenerated]
		remove
		{
			ValueChangedEvent valueChangedEvent = valueChangedEvent_0;
			ValueChangedEvent valueChangedEvent2;
			do
			{
				valueChangedEvent2 = valueChangedEvent;
				ValueChangedEvent value2 = (ValueChangedEvent)Delegate.Remove(valueChangedEvent2, value);
				valueChangedEvent = Interlocked.CompareExchange(ref valueChangedEvent_0, value2, valueChangedEvent2);
			}
			while ((object)valueChangedEvent != valueChangedEvent2);
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		try
		{
			bool_0 = false;
			mouseState_0 = MouseState.None;
			mouseState_1 = MouseState.None;
			if (ScrollPositionStyle == ScrollBarType.Vertical)
			{
				if (e.Y >= Convert.ToInt32((float)base.Height / 2f))
				{
					if (buButtonPlusMinusMouseEventHandler_1 != null)
					{
						buButtonPlusMinusMouseEventHandler_1(this, e, -1);
					}
				}
				else if (buButtonPlusMinusMouseEventHandler_1 != null)
				{
					buButtonPlusMinusMouseEventHandler_1(this, e, 1);
				}
			}
			if (ScrollPositionStyle == ScrollBarType.Horizontal)
			{
				if (e.X >= Convert.ToInt32((float)base.Width / 2f))
				{
					if (buButtonPlusMinusMouseEventHandler_1 != null)
					{
						buButtonPlusMinusMouseEventHandler_1(this, e, 1);
					}
				}
				else if (buButtonPlusMinusMouseEventHandler_1 != null)
				{
					buButtonPlusMinusMouseEventHandler_1(this, e, -1);
				}
			}
			Invalidate();
			base.OnMouseUp(e);
		}
		catch (Exception)
		{
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		try
		{
			bool_0 = true;
			if (ScrollPositionStyle == ScrollBarType.Vertical)
			{
				if (e.Y >= Convert.ToInt32(ButtonSize))
				{
					if (e.Y <= base.Height - Convert.ToInt32(ButtonSize))
					{
						float num = ButtonSize + 4f;
						float num2 = (float)base.Height - ButtonSize * 1f - 4f;
						float num3 = (num2 - num) / (float)(MaximumValue - MinimumValue);
						Value = Convert.ToInt32((float)MaximumValue - (num2 - (float)e.Y) / num3);
						Value = (num2 - (float)e.Y) / num3;
						if (Value > (double)MaximumValue)
						{
							Value = MaximumValue;
						}
						if (Value < (double)MinimumValue)
						{
							Value = MinimumValue;
						}
						mouseState_1 = MouseState.None;
						mouseState_0 = MouseState.None;
					}
					else
					{
						mouseState_1 = MouseState.Down;
						mouseState_0 = MouseState.None;
						Value -= (double)Increament * Direction;
						if (Value > (double)MaximumValue)
						{
							Value = MaximumValue;
						}
						if (Value < (double)MinimumValue)
						{
							Value = MinimumValue;
						}
						if (buButtonPlusMinusMouseEventHandler_0 != null)
						{
							buButtonPlusMinusMouseEventHandler_0(this, e, -1);
						}
					}
				}
				else
				{
					mouseState_0 = MouseState.Down;
					mouseState_1 = MouseState.None;
					Value += (double)Increament * Direction;
					if (Value > (double)MaximumValue)
					{
						Value = MaximumValue;
					}
					if (Value < (double)MinimumValue)
					{
						Value = MinimumValue;
					}
					if (buButtonPlusMinusMouseEventHandler_0 != null)
					{
						buButtonPlusMinusMouseEventHandler_0(this, e, 1);
					}
				}
			}
			if (ScrollPositionStyle == ScrollBarType.Horizontal)
			{
				if (e.X >= Convert.ToInt32(ButtonSize))
				{
					if (e.X <= base.Width - Convert.ToInt32(ButtonSize))
					{
						float num4 = ButtonSize + 4f;
						float num5 = (float)base.Width - ButtonSize * 1f - 4f;
						float num6 = (num5 - num4) / (float)(MaximumValue - MinimumValue);
						Value = Convert.ToInt32((float)MaximumValue - (num5 - (float)e.X) / num6);
						if (Value > (double)MaximumValue)
						{
							Value = MaximumValue;
						}
						if (Value < (double)MinimumValue)
						{
							Value = MinimumValue;
						}
						mouseState_1 = MouseState.None;
						mouseState_0 = MouseState.None;
					}
					else
					{
						mouseState_1 = MouseState.None;
						mouseState_0 = MouseState.Down;
						Value += (double)Increament * Direction;
						if (Value > (double)MaximumValue)
						{
							Value = MaximumValue;
						}
						if (Value < (double)MinimumValue)
						{
							Value = MinimumValue;
						}
						if (buButtonPlusMinusMouseEventHandler_0 != null)
						{
							buButtonPlusMinusMouseEventHandler_0(this, e, 1);
						}
					}
				}
				else
				{
					mouseState_1 = MouseState.Down;
					mouseState_0 = MouseState.None;
					Value -= (double)Increament * Direction;
					if (Value > (double)MaximumValue)
					{
						Value = MaximumValue;
					}
					if (Value < (double)MinimumValue)
					{
						Value = MinimumValue;
					}
					if (buButtonPlusMinusMouseEventHandler_0 != null)
					{
						buButtonPlusMinusMouseEventHandler_0(this, e, -1);
					}
				}
			}
			Invalidate();
			base.OnMouseDown(e);
		}
		catch (Exception)
		{
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		try
		{
			if (ScrollPositionStyle == ScrollBarType.Vertical)
			{
				if (e.Y >= Convert.ToInt32(ButtonSize))
				{
					if (e.Y <= base.Height - Convert.ToInt32(ButtonSize))
					{
						if (bool_0)
						{
							float num = ButtonSize + 4f;
							float num2 = (float)base.Height - ButtonSize * 1f - 4f;
							float num3 = (num2 - num) / (float)(MaximumValue - MinimumValue);
							Value = Convert.ToInt32((float)MaximumValue - (num2 - (float)e.Y) / num3) * -1;
							Value = (num2 - (float)e.Y) / num3;
							if (Value > (double)MaximumValue)
							{
								Value = MaximumValue;
							}
							if (Value < (double)MinimumValue)
							{
								Value = MinimumValue;
							}
						}
						mouseState_1 = MouseState.None;
						mouseState_0 = MouseState.None;
					}
					else
					{
						mouseState_1 = MouseState.Move;
						mouseState_0 = MouseState.None;
						if (buButtonPlusMinusMouseEventHandler_2 != null)
						{
							buButtonPlusMinusMouseEventHandler_0(this, e, -1);
						}
					}
				}
				else
				{
					mouseState_0 = MouseState.Move;
					mouseState_1 = MouseState.None;
					if (buButtonPlusMinusMouseEventHandler_2 != null)
					{
						buButtonPlusMinusMouseEventHandler_0(this, e, 1);
					}
				}
			}
			if (ScrollPositionStyle == ScrollBarType.Horizontal)
			{
				if (e.X >= Convert.ToInt32(ButtonSize))
				{
					if (e.X <= base.Width - Convert.ToInt32(ButtonSize))
					{
						if (bool_0)
						{
							float num4 = ButtonSize + 4f;
							float num5 = (float)base.Width - ButtonSize * 1f - 4f;
							float num6 = (num5 - num4) / (float)(MaximumValue - MinimumValue);
							Value = Convert.ToInt32((float)MaximumValue - (num5 - (float)e.X) / num6);
							if (Value > (double)MaximumValue)
							{
								Value = MaximumValue;
							}
							if (Value < (double)MinimumValue)
							{
								Value = MinimumValue;
							}
						}
						mouseState_1 = MouseState.None;
						mouseState_0 = MouseState.None;
					}
					else
					{
						mouseState_1 = MouseState.None;
						mouseState_0 = MouseState.Move;
						if (buButtonPlusMinusMouseEventHandler_2 != null)
						{
							buButtonPlusMinusMouseEventHandler_0(this, e, 1);
						}
					}
				}
				else
				{
					mouseState_1 = MouseState.Move;
					mouseState_0 = MouseState.None;
					if (buButtonPlusMinusMouseEventHandler_2 != null)
					{
						buButtonPlusMinusMouseEventHandler_0(this, e, -1);
					}
				}
			}
			Invalidate();
			base.OnMouseMove(e);
		}
		catch (Exception)
		{
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		try
		{
			mouseState_0 = MouseState.None;
			mouseState_1 = MouseState.None;
			Invalidate();
			base.OnMouseLeave(e);
		}
		catch (Exception)
		{
		}
	}

	protected override void OnTextChanged(EventArgs e)
	{
		try
		{
			Invalidate();
			base.OnTextChanged(e);
		}
		catch (Exception)
		{
		}
	}

	public buScrollBar()
	{
		try
		{
			base.Display.Parent = this;
			base.Display.Parent = this;
			ButtonPlusDownDisplay.Parent = this;
			ButtonPlusNormalDisplay.Parent = this;
			ButtonPlusOverDisplay.Parent = this;
			ButtonMinusDownDisplay.Parent = this;
			ButtonMinusNormalDisplay.Parent = this;
			ButtonMinusOverDisplay.Parent = this;
			base.Display.Parent = this;
			ButtonPlusDownDisplay.BackColor = Color.DimGray;
			ButtonPlusNormalDisplay.BackColor = Color.LightGray;
			ButtonPlusOverDisplay.BackColor = Color.Gray;
			ButtonMinusDownDisplay.BackColor = Color.DimGray;
			ButtonMinusNormalDisplay.BackColor = Color.LightGray;
			ButtonMinusOverDisplay.BackColor = Color.Gray;
			buControlDisplay_7.BackColor = Color.DimGray;
			buControlDisplay_7.Parent = this;
			base.Geometry.Parent = this;
			base.Language.Parent = this;
			base.Theme.Parent = this;
			Class76.smethod_14();
			SetStyle(ControlStyles.Selectable, value: false);
			SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			DoubleBuffered = true;
			base.Size = new Size(166, 40);
		}
		catch (Exception)
		{
		}
	}

	protected override void OnResize(EventArgs e)
	{
		try
		{
			Invalidate();
			base.OnResize(e);
		}
		catch (Exception)
		{
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		try
		{
			RectangleF rect = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
			RectangleF rect2 = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
			RectangleF rect3 = default(RectangleF);
			Graphics Grph = e.Graphics;
			if (base.Theme.Type != themeType_0)
			{
				buControlThemeVars Vars = new buControlThemeVars();
				buControlTheme.UpdateTheme(base.Theme.Type, ref Vars);
				base.Geometry = new buControlGeometry(Vars.Geometry);
				base.Display = new buControlDisplay(Vars.Display);
				ButtonPlusDownDisplay = new buControlDisplay(Vars.DisplayButtonDown);
				ButtonPlusNormalDisplay = new buControlDisplay(Vars.DisplayButtonNormal);
				ButtonPlusOverDisplay = new buControlDisplay(Vars.DisplayButtonOver);
				ButtonMinusDownDisplay = new buControlDisplay(Vars.DisplayButton2Down);
				ButtonMinusNormalDisplay = new buControlDisplay(Vars.DisplayButton2Normal);
				ButtonMinusOverDisplay = new buControlDisplay(Vars.DisplayButton2Over);
				base.Display.Parent = this;
				ButtonPlusDownDisplay.Parent = this;
				ButtonPlusNormalDisplay.Parent = this;
				ButtonPlusOverDisplay.Parent = this;
				ButtonMinusDownDisplay.Parent = this;
				ButtonMinusNormalDisplay.Parent = this;
				ButtonMinusOverDisplay.Parent = this;
			}
			if ((base.Width > 0) & (base.Height > 0))
			{
				if (ScrollPositionStyle == ScrollBarType.Horizontal)
				{
					rect2 = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, ButtonSize, base.ClientRectangle.Height);
					rect = new RectangleF((float)base.ClientRectangle.Width - ButtonSize, base.ClientRectangle.Top, ButtonSize, base.ClientRectangle.Height);
					float num = ButtonSize + 4f;
					float num2 = (float)base.Width - ButtonSize * 1f - 4f;
					try
					{
						float num3 = (num2 - num) / (float)(MaximumValue - MinimumValue);
						double_0 = (double)num2 - (double)num3 * ((double)MaximumValue - Value) - ((double)MinimumValue - Value) / (double)(MinimumValue - MaximumValue) * (double)ButtonSize;
					}
					catch (Exception)
					{
					}
					rect3 = new RectangleF((float)double_0, base.Geometry.Space, ScrollWidth, (float)base.Height - base.Geometry.Space * 2f);
				}
				if (ScrollPositionStyle == ScrollBarType.Vertical)
				{
					rect2 = new RectangleF(base.ClientRectangle.Left, (float)base.ClientRectangle.Height - ButtonSize, base.ClientRectangle.Width, ButtonSize);
					rect = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, ButtonSize);
					float num4 = ButtonSize * 1f + 4f;
					float num5 = (float)base.Height - ButtonSize * 1f - 4f;
					try
					{
						float num6 = (num5 - num4) / (float)(MinimumValue - MaximumValue);
						double_0 = (double)num5 - (double)num6 * ((double)MinimumValue - Value) - ((double)MaximumValue - Value) / (double)(MaximumValue - MinimumValue) * (double)ButtonSize;
					}
					catch (Exception)
					{
					}
					rect3 = new RectangleF(base.Geometry.Space, (float)double_0, (float)base.Width - base.Geometry.Space * 2f, ScrollWidth);
				}
				buControlDisplay display = new buControlDisplay(ButtonPlusNormalDisplay);
				if (mouseState_0 == MouseState.Move)
				{
					display = new buControlDisplay(ButtonPlusOverDisplay);
				}
				if (mouseState_0 == MouseState.Down)
				{
					display = new buControlDisplay(ButtonPlusDownDisplay);
				}
				buControlDisplay display2 = new buControlDisplay(ButtonMinusNormalDisplay);
				if (mouseState_1 == MouseState.Move)
				{
					display2 = new buControlDisplay(ButtonMinusOverDisplay);
				}
				if (mouseState_1 == MouseState.Down)
				{
					display2 = new buControlDisplay(ButtonMinusDownDisplay);
				}
				if (base.Enabled)
				{
					ControlGeometry.drawGeometry(base.ClientRectangle, base.Geometry, base.Display, RoundRectangleType.RoundRectAll, ref Grph);
					ControlGeometry.drawGeometry(rect, base.Geometry, display, RoundRectangleType.RoundRectAll, ref Grph);
					ControlGeometry.drawString(rect, PlusString, display, ref Grph);
					ControlGeometry.drawGeometry(rect2, base.Geometry, display2, RoundRectangleType.RoundRectAll, ref Grph);
					ControlGeometry.drawString(rect2, MinusString, display2, ref Grph);
					if ((rect3.Width > 0f) & (rect3.Height > 0f))
					{
						ControlGeometry.drawGeometry(rect3, base.Geometry, buControlDisplay_7, RoundRectangleType.RoundRectAll, ref Grph);
						Grph.SmoothingMode = SmoothingMode.AntiAlias;
					}
				}
			}
			themeType_0 = base.Theme.Type;
			base.OnPaint(e);
		}
		catch (Exception)
		{
		}
	}

	public void PropertiesValueChanged()
	{
		Invalidate();
	}
}
