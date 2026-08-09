using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns39;

namespace buControls.Controls;

[TypeConverter(typeof(Class88))]
public class buControlSeparator
{
	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private bool bool_0 = true;

	private Color color_0 = Color.Black;

	private float float_0 = 1f;

	public Control Parent = null;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(true)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool Visible
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			OnChanged();
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(1f)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public float Thickness
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
	[DefaultValue(typeof(Color), "Black")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color Color
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

	public buControlSeparator()
	{
	}

	public buControlSeparator(Color color, float thickness, bool visible)
	{
		Color = color;
		Thickness = thickness;
		Visible = visible;
	}

	public buControlSeparator(buControlSeparator separator)
	{
		Color = separator.Color;
		Thickness = separator.Thickness;
		Visible = separator.Visible;
	}

	public static void Copy(buControlSeparator Source, ref buControlSeparator Target)
	{
		Target.Color = Source.Color;
		Target.Thickness = Source.Thickness;
		Target.Visible = Source.Visible;
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
		string text = Color.ToString();
		if (Color.IsKnownColor)
		{
			text = Color.ToKnownColor().ToString();
		}
		return Visible + " , " + Thickness + " , " + text;
	}
}
