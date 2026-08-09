using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buCore;
using ns27;

namespace buControls.Controls;

[TypeConverter(typeof(Class85))]
public class buControlDisplay : buSerilization
{
	private Control control_0 = null;

	public Color OldColor = Color.LightGray;

	private Color color_0 = Color.LightGray;

	private Color color_1 = Color.DarkOrange;

	private Color color_2 = Color.Gray;

	private Color color_3 = Color.Black;

	private GradientMode gradientMode_0 = GradientMode.Solid;

	private buControlLineerGradient buControlLineerGradient_0 = null;

	private buControlPathGradient buControlPathGradient_0 = null;

	private buControlInterpolatedGradient buControlInterpolatedGradient_0 = null;

	private buControlBorder buControlBorder_0 = null;

	private buControlFont buControlFont_0 = null;

	private buControlSeparator buControlSeparator_0 = null;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	public Control Parent
	{
		get
		{
			return control_0;
		}
		set
		{
			control_0 = value;
			if (Parent != null)
			{
				Border.Parent = Parent;
				Separator.Parent = Parent;
				LineerGradient.Parent = Parent;
				PathGradient.Parent = Parent;
				PathInterpolatedGradient.Parent = Parent;
				Fonts.Parent = Parent;
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlSeparator Separator
	{
		get
		{
			return buControlSeparator_0;
		}
		set
		{
			buControlSeparator_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlBorder Border
	{
		get
		{
			return buControlBorder_0;
		}
		set
		{
			buControlBorder_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlFont Fonts
	{
		get
		{
			return buControlFont_0;
		}
		set
		{
			buControlFont_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlLineerGradient LineerGradient
	{
		get
		{
			return buControlLineerGradient_0;
		}
		set
		{
			buControlLineerGradient_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlPathGradient PathGradient
	{
		get
		{
			return buControlPathGradient_0;
		}
		set
		{
			buControlPathGradient_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlInterpolatedGradient PathInterpolatedGradient
	{
		get
		{
			return buControlInterpolatedGradient_0;
		}
		set
		{
			buControlInterpolatedGradient_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(GradientMode.Solid)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public GradientMode GradientType
	{
		get
		{
			return gradientMode_0;
		}
		set
		{
			gradientMode_0 = value;
			OnChanged();
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "LightGray")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color BackColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			OnChanged();
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "Gray")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color DisableColor
	{
		get
		{
			return color_2;
		}
		set
		{
			color_2 = value;
			OnChanged();
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "DarkOrange")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color SelectionColor
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
			OnChanged();
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "Black")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color TitleForeColor
	{
		get
		{
			return color_3;
		}
		set
		{
			color_3 = value;
			OnChanged();
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	public event EventHandler Changed
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public buControlDisplay()
	{
		buControlLineerGradient_0 = new buControlLineerGradient();
		buControlLineerGradient_0.Changed += DisplayChanged;
		buControlPathGradient_0 = new buControlPathGradient();
		buControlPathGradient_0.Changed += DisplayChanged;
		buControlInterpolatedGradient_0 = new buControlInterpolatedGradient();
		buControlInterpolatedGradient_0.Changed += DisplayChanged;
		buControlSeparator_0 = new buControlSeparator();
		buControlSeparator_0.Changed += DisplayChanged;
		buControlBorder_0 = new buControlBorder();
		buControlBorder_0.Changed += DisplayChanged;
		buControlFont_0 = new buControlFont();
		buControlFont_0.Changed += DisplayChanged;
	}

	public buControlDisplay(buControlDisplay display)
	{
		BackColor = display.BackColor;
		SelectionColor = display.SelectionColor;
		TitleForeColor = display.TitleForeColor;
		DisableColor = display.DisableColor;
		GradientType = display.GradientType;
		Fonts = new buControlFont(display.Fonts);
		Fonts.Changed += DisplayChanged;
		Border = new buControlBorder(display.Border);
		Border.Changed += DisplayChanged;
		LineerGradient = new buControlLineerGradient(display.LineerGradient);
		LineerGradient.Changed += DisplayChanged;
		PathGradient = new buControlPathGradient(display.PathGradient);
		PathGradient.Changed += DisplayChanged;
		PathInterpolatedGradient = new buControlInterpolatedGradient(display.PathInterpolatedGradient);
		PathInterpolatedGradient.Changed += DisplayChanged;
		Separator = new buControlSeparator(display.Separator);
		Separator.Changed += DisplayChanged;
		Parent = display.Parent;
	}

	public static buControlDisplay Copy(buControlDisplay Source, buControlDisplay Target, bool FontsAlignment = true)
	{
		Copy(Source, ref Target, 1.0, FontsAlignment);
		return Target;
	}

	public static buControlDisplay Copy(buControlDisplay Source, buControlDisplay Target, double ToneChange, bool FontsAlignment = true)
	{
		Copy(Source, ref Target, ToneChange, FontsAlignment);
		return Target;
	}

	public static void Copy(buControlDisplay Source, ref buControlDisplay Target, double ToneChange, bool FontsAlignment = true)
	{
		if (ToneChange != 1.0)
		{
			Target.BackColor = buImage.ColorToneChange(Source.BackColor, ToneChange);
			Target.SelectionColor = buImage.ColorToneChange(Source.SelectionColor, ToneChange);
			Target.TitleForeColor = buImage.ColorToneChange(Source.TitleForeColor, ToneChange);
			Target.DisableColor = buImage.ColorToneChange(Source.DisableColor, ToneChange);
			Target.LineerGradient.FirstColor = buImage.ColorToneChange(Source.LineerGradient.FirstColor, ToneChange);
			Target.LineerGradient.SecondColor = buImage.ColorToneChange(Source.LineerGradient.SecondColor, ToneChange);
			Target.PathGradient.CenterColor = buImage.ColorToneChange(Source.PathGradient.CenterColor, ToneChange);
			Target.PathGradient.SurroundColor = buImage.ColorToneChange(Source.PathGradient.SurroundColor, ToneChange);
			Target.PathInterpolatedGradient.FirstColor = buImage.ColorToneChange(Source.PathInterpolatedGradient.FirstColor, ToneChange);
			Target.PathInterpolatedGradient.SecondColor = buImage.ColorToneChange(Source.PathInterpolatedGradient.SecondColor, ToneChange);
			Target.PathInterpolatedGradient.ThirdColor = buImage.ColorToneChange(Source.PathInterpolatedGradient.ThirdColor, ToneChange);
			Target.PathInterpolatedGradient.FourthColor = buImage.ColorToneChange(Source.PathInterpolatedGradient.FourthColor, ToneChange);
			Target.Separator.Color = buImage.ColorToneChange(Source.Separator.Color, ToneChange);
			Target.Border.Color = buImage.ColorToneChange(Source.Border.Color, ToneChange);
			Target.Fonts.ForeColor = buImage.ColorToneChange(Source.Fonts.ForeColor, ToneChange);
		}
		else
		{
			Target.BackColor = Source.BackColor;
			Target.SelectionColor = Source.SelectionColor;
			Target.TitleForeColor = Source.TitleForeColor;
			Target.DisableColor = Source.DisableColor;
			Target.LineerGradient.FirstColor = Source.LineerGradient.FirstColor;
			Target.LineerGradient.SecondColor = Source.LineerGradient.SecondColor;
			Target.PathGradient.CenterColor = Source.PathGradient.CenterColor;
			Target.PathGradient.SurroundColor = Source.PathGradient.SurroundColor;
			Target.PathInterpolatedGradient.FirstColor = Source.PathInterpolatedGradient.FirstColor;
			Target.PathInterpolatedGradient.SecondColor = Source.PathInterpolatedGradient.SecondColor;
			Target.PathInterpolatedGradient.ThirdColor = Source.PathInterpolatedGradient.ThirdColor;
			Target.PathInterpolatedGradient.FourthColor = Source.PathInterpolatedGradient.FourthColor;
			Target.Separator.Color = Source.Separator.Color;
			Target.Border.Color = Source.Border.Color;
			Target.Fonts.ForeColor = Source.Fonts.ForeColor;
		}
		Target.GradientType = Source.GradientType;
		Target.LineerGradient.GradientAngle = Source.LineerGradient.GradientAngle;
		Target.PathInterpolatedGradient.ColorCount = Source.PathInterpolatedGradient.ColorCount;
		Target.Border.Thickness = Source.Border.Thickness;
		Target.Border.Visible = Source.Border.Visible;
		Target.Separator.Thickness = Source.Separator.Thickness;
		Target.Separator.Visible = Source.Separator.Visible;
		Target.Fonts.Font = new Font(Source.Fonts.Font.Name, Source.Fonts.Font.Size, Source.Fonts.Font.Style);
		if (FontsAlignment)
		{
			Target.Fonts.Alignment = Source.Fonts.Alignment;
		}
	}

	protected void DisplayChanged(object sender, EventArgs e)
	{
		OnChanged();
	}

	protected void OnChanged()
	{
		if (eventHandler_0 != null)
		{
			eventHandler_0?.Invoke(this, EventArgs.Empty);
		}
	}

	public override string ToString()
	{
		return GradientType.ToString();
	}
}
