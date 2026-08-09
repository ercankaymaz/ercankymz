using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns38;

namespace buControls.Controls;

[TypeConverter(typeof(Class87))]
public class buControlFont
{
	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private Color color_0 = Color.Black;

	private Font font_0 = new Font("Tahoma", 12f);

	private ContentAlignment contentAlignment_0 = ContentAlignment.MiddleCenter;

	public Control Parent = null;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Font), "Tahoma, 12")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Font Font
	{
		get
		{
			return font_0;
		}
		set
		{
			font_0 = value;
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
	public Color ForeColor
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
	[DefaultValue(ContentAlignment.MiddleCenter)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public ContentAlignment Alignment
	{
		get
		{
			return contentAlignment_0;
		}
		set
		{
			contentAlignment_0 = value;
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

	public buControlFont()
	{
	}

	public buControlFont(Color forecolor, Font fnt)
	{
		ForeColor = forecolor;
		Font = fnt;
	}

	public buControlFont(buControlFont font)
	{
		Font = font.Font;
		ForeColor = font.ForeColor;
		Alignment = font.Alignment;
	}

	public static void Copy(buControlFont Source, ref buControlFont Target)
	{
		Target.Font = Source.Font;
		Target.ForeColor = Source.ForeColor;
		Target.Alignment = Source.Alignment;
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
		string text = ForeColor.ToString();
		if (ForeColor.IsKnownColor)
		{
			text = ForeColor.ToKnownColor().ToString();
		}
		return text + " , " + Font.Name + " , " + Font.Size;
	}
}
