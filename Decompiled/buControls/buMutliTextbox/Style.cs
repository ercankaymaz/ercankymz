using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;

namespace buMutliTextbox;

public abstract class Style : IDisposable
{
	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private EventHandler<VisualMarkerEventArgs> eventHandler_0;

	public virtual bool IsExportable
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public event EventHandler<VisualMarkerEventArgs> VisualMarkerClick
	{
		[CompilerGenerated]
		add
		{
			EventHandler<VisualMarkerEventArgs> eventHandler = eventHandler_0;
			EventHandler<VisualMarkerEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<VisualMarkerEventArgs> value2 = (EventHandler<VisualMarkerEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<VisualMarkerEventArgs> eventHandler = eventHandler_0;
			EventHandler<VisualMarkerEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<VisualMarkerEventArgs> value2 = (EventHandler<VisualMarkerEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public Style()
	{
		IsExportable = true;
	}

	public abstract void Draw(Graphics gr, Point position, Range range);

	public virtual void OnVisualMarkerClick(buMultiTextBox tb, VisualMarkerEventArgs args)
	{
		if (eventHandler_0 != null)
		{
			eventHandler_0(tb, args);
		}
	}

	protected virtual void AddVisualMarker(buMultiTextBox tb, StyleVisualMarker marker)
	{
		tb.AddVisualMarker(marker);
	}

	public static Size GetSizeOfRange(Range range)
	{
		return new Size((range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
	}

	public static GraphicsPath GetRoundedRectangle(Rectangle rect, int d)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddArc(rect.X, rect.Y, d, d, 180f, 90f);
		graphicsPath.AddArc(rect.X + rect.Width - d, rect.Y, d, d, 270f, 90f);
		graphicsPath.AddArc(rect.X + rect.Width - d, rect.Y + rect.Height - d, d, d, 0f, 90f);
		graphicsPath.AddArc(rect.X, rect.Y + rect.Height - d, d, d, 90f, 90f);
		graphicsPath.AddLine(rect.X, rect.Y + rect.Height - d, rect.X, rect.Y + d / 2);
		return graphicsPath;
	}

	public virtual void Dispose()
	{
	}

	public virtual string GetCSS()
	{
		return "";
	}

	public virtual RTFStyleDescriptor GetRTF()
	{
		return new RTFStyleDescriptor();
	}
}
