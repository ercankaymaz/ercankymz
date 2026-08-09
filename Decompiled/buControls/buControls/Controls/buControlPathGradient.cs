using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns23;

namespace buControls.Controls;

[TypeConverter(typeof(Class92))]
public class buControlPathGradient
{
	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private Color color_0 = Color.LightGray;

	private Color color_1 = Color.Gray;

	public Control Parent = null;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "LightGray")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color CenterColor
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
	public Color SurroundColor
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

	public buControlPathGradient()
	{
	}

	public buControlPathGradient(Color centercolor, Color surroundcolor)
	{
		CenterColor = centercolor;
		SurroundColor = surroundcolor;
	}

	public buControlPathGradient(buControlPathGradient gradient)
	{
		CenterColor = gradient.CenterColor;
		SurroundColor = gradient.SurroundColor;
		Parent = gradient.Parent;
	}

	public static void Copy(buControlPathGradient Source, ref buControlPathGradient Target)
	{
		Target.CenterColor = Source.CenterColor;
		Target.SurroundColor = Source.SurroundColor;
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
		string text = CenterColor.ToString();
		string text2 = SurroundColor.ToString();
		if (CenterColor.IsKnownColor)
		{
			text = CenterColor.ToKnownColor().ToString();
		}
		if (SurroundColor.IsKnownColor)
		{
			text2 = SurroundColor.ToKnownColor().ToString();
		}
		return text + " , " + text2;
	}
}
