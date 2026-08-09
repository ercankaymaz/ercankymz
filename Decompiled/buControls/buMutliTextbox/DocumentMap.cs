using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ns27;

namespace buMutliTextbox;

public class DocumentMap : Control
{
	public EventHandler TargetChanged;

	internal buMultiTextBox buMultiTextBox_0;

	private float float_0 = 0.3f;

	private bool bool_0 = true;

	internal Place place_0 = Place.Empty;

	private bool bool_1 = true;

	[Description("Target FastColoredTextBox")]
	public buMultiTextBox Target
	{
		get
		{
			return buMultiTextBox_0;
		}
		set
		{
			if (buMultiTextBox_0 != null)
			{
				UnSubscribe(buMultiTextBox_0);
			}
			buMultiTextBox_0 = value;
			if (value != null)
			{
				Subscribe(buMultiTextBox_0);
			}
			OnTargetChanged();
		}
	}

	[Description("Scale")]
	[DefaultValue(0.3f)]
	public new float Scale
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			NeedRepaint();
		}
	}

	[Description("Scrollbar visibility")]
	[DefaultValue(true)]
	public bool ScrollbarVisible
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			NeedRepaint();
		}
	}

	public DocumentMap()
	{
		ForeColor = Color.Maroon;
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		Application.Idle += method_0;
	}

	private void method_0(object sender, EventArgs e)
	{
		if (bool_0)
		{
			Invalidate();
		}
	}

	protected virtual void OnTargetChanged()
	{
		NeedRepaint();
		if (TargetChanged != null)
		{
			TargetChanged(this, EventArgs.Empty);
		}
	}

	protected virtual void UnSubscribe(buMultiTextBox target)
	{
		target.Scroll -= Target_Scroll;
		target.SelectionChangedDelayed -= Target_SelectionChanged;
		target.VisibleRangeChanged -= Target_VisibleRangeChanged;
	}

	protected virtual void Subscribe(buMultiTextBox target)
	{
		target.Scroll += Target_Scroll;
		target.SelectionChangedDelayed += Target_SelectionChanged;
		target.VisibleRangeChanged += Target_VisibleRangeChanged;
	}

	protected virtual void Target_VisibleRangeChanged(object sender, EventArgs e)
	{
		NeedRepaint();
	}

	protected virtual void Target_SelectionChanged(object sender, EventArgs e)
	{
		NeedRepaint();
	}

	protected virtual void Target_Scroll(object sender, ScrollEventArgs e)
	{
		NeedRepaint();
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		NeedRepaint();
	}

	public void NeedRepaint()
	{
		bool_0 = true;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (buMultiTextBox_0 == null)
		{
			return;
		}
		float num = Scale * 100f / (float)buMultiTextBox_0.Zoom;
		if (num <= float.Epsilon)
		{
			return;
		}
		Range visibleRange = buMultiTextBox_0.VisibleRange;
		if (place_0.iLine <= visibleRange.Start.iLine)
		{
			Point point = buMultiTextBox_0.PlaceToPoint(visibleRange.End);
			point.Offset(0, -(int)((float)base.ClientSize.Height / num) + buMultiTextBox_0.CharHeight);
			Place place = buMultiTextBox_0.PointToPlace(point);
			if (place.iLine > place_0.iLine)
			{
				place_0.iLine = place.iLine;
			}
		}
		else
		{
			place_0.iLine = visibleRange.Start.iLine;
		}
		place_0.iChar = 0;
		int count = buMultiTextBox_0.Lines.Count;
		float num2 = (float)visibleRange.Start.iLine / (float)count;
		float num3 = (float)visibleRange.End.iLine / (float)count;
		e.Graphics.ScaleTransform(num, num);
		SizeF sizeF = new SizeF((float)base.ClientSize.Width / num, (float)base.ClientSize.Height / num);
		buMultiTextBox_0.DrawText(e.Graphics, place_0, sizeF.ToSize());
		Point point2 = buMultiTextBox_0.PlaceToPoint(place_0);
		Point point3 = buMultiTextBox_0.PlaceToPoint(visibleRange.Start);
		Point point4 = buMultiTextBox_0.PlaceToPoint(visibleRange.End);
		int num4 = point3.Y - point2.Y;
		int num5 = point4.Y + buMultiTextBox_0.CharHeight - point2.Y;
		e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
		using (SolidBrush brush = new SolidBrush(Color.FromArgb(50, ForeColor)))
		{
			using Pen pen = new Pen(brush, 1f / num);
			Rectangle rect = new Rectangle(0, num4, (int)((float)(base.ClientSize.Width - 1) / num), num5 - num4);
			e.Graphics.FillRectangle(brush, rect);
			e.Graphics.DrawRectangle(pen, rect);
		}
		if (bool_1)
		{
			e.Graphics.ResetTransform();
			e.Graphics.SmoothingMode = SmoothingMode.None;
			using SolidBrush brush2 = new SolidBrush(Color.FromArgb(200, ForeColor));
			RectangleF rect2 = new RectangleF(base.ClientSize.Width - 3, (float)base.ClientSize.Height * num2, 2f, (float)base.ClientSize.Height * (num3 - num2));
			e.Graphics.FillRectangle(brush2, rect2);
		}
		bool_0 = false;
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			Class76.smethod_593(e.Location, this);
		}
		base.OnMouseDown(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			Class76.smethod_593(e.Location, this);
		}
		base.OnMouseMove(e);
	}

	internal void method_1()
	{
		Refresh();
		buMultiTextBox_0.Refresh();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			Application.Idle -= method_0;
			if (buMultiTextBox_0 != null)
			{
				UnSubscribe(buMultiTextBox_0);
			}
		}
		base.Dispose(disposing);
	}
}
