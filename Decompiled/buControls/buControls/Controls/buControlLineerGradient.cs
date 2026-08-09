using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns23;

namespace buControls.Controls;

[TypeConverter(typeof(Class91))]
public class buControlLineerGradient
{
	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private Color color_0 = Color.WhiteSmoke;

	private Color color_1 = Color.DarkGray;

	private float float_0 = 90f;

	public Control Parent = null;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(90f)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public float GradientAngle
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			OnChanged();
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "WhiteSmoke")]
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
	[DefaultValue(typeof(Color), "DarkGray")]
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

	public buControlLineerGradient()
	{
	}

	public buControlLineerGradient(Color firstcolor, Color secondcolor, float angle)
	{
		FirstColor = firstcolor;
		SecondColor = secondcolor;
		GradientAngle = angle;
	}

	public buControlLineerGradient(buControlLineerGradient gradient)
	{
		FirstColor = gradient.FirstColor;
		SecondColor = gradient.SecondColor;
		GradientAngle = gradient.GradientAngle;
		Parent = gradient.Parent;
	}

	public static void Copy(buControlLineerGradient Source, ref buControlLineerGradient Target)
	{
		Target.FirstColor = Source.FirstColor;
		Target.SecondColor = Source.SecondColor;
		Target.GradientAngle = Source.GradientAngle;
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
		if (FirstColor.IsKnownColor)
		{
			text = FirstColor.ToKnownColor().ToString();
		}
		if (SecondColor.IsKnownColor)
		{
			text2 = SecondColor.ToKnownColor().ToString();
		}
		return text + " , " + text2 + " , " + GradientAngle;
	}
}
