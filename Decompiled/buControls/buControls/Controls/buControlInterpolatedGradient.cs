using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns31;

namespace buControls.Controls;

[TypeConverter(typeof(Class93))]
public class buControlInterpolatedGradient
{
	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private Color color_0 = Color.LightGray;

	private Color color_1 = Color.Gray;

	private Color color_2 = Color.DimGray;

	private Color color_3 = Color.Black;

	private int int_0 = 3;

	public Control Parent = null;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(3)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int ColorCount
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
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
	public Color FirstColor
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
	public Color SecondColor
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
	[DefaultValue(typeof(Color), "DimGray")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color ThirdColor
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
	[DefaultValue(typeof(Color), "Black")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color FourthColor
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

	public buControlInterpolatedGradient()
	{
	}

	public buControlInterpolatedGradient(Color firstcolor, Color secondcolor, Color thirdcolor, Color fourthcolor, int colorcount)
	{
		FirstColor = firstcolor;
		SecondColor = secondcolor;
		ThirdColor = thirdcolor;
		FourthColor = fourthcolor;
		ColorCount = colorcount;
	}

	public buControlInterpolatedGradient(buControlInterpolatedGradient gradient)
	{
		FirstColor = gradient.FirstColor;
		SecondColor = gradient.SecondColor;
		ThirdColor = gradient.ThirdColor;
		FourthColor = gradient.FourthColor;
		ColorCount = gradient.ColorCount;
		Parent = gradient.Parent;
	}

	public static void Copy(buControlInterpolatedGradient Source, ref buControlInterpolatedGradient Target)
	{
		Target.FirstColor = Source.FirstColor;
		Target.SecondColor = Source.SecondColor;
		Target.ThirdColor = Source.ThirdColor;
		Target.FourthColor = Source.FourthColor;
		Target.ColorCount = Source.ColorCount;
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
		string text = FirstColor.ToString();
		string text2 = SecondColor.ToString();
		string text3 = ThirdColor.ToString();
		string text4 = FourthColor.ToString();
		if (FirstColor.IsKnownColor)
		{
			text = FirstColor.ToKnownColor().ToString();
		}
		if (SecondColor.IsKnownColor)
		{
			text2 = SecondColor.ToKnownColor().ToString();
		}
		if (ThirdColor.IsKnownColor)
		{
			text3 = ThirdColor.ToKnownColor().ToString();
		}
		if (FourthColor.IsKnownColor)
		{
			text4 = FourthColor.ToKnownColor().ToString();
		}
		return text + " , " + text2 + " , " + text3 + " , " + text4;
	}
}
