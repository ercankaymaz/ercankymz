using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns27;

namespace SourceGrid;

[ToolboxItem(false)]
public abstract class CustomScrollControl : Panel
{
	internal HScrollBar hscrollBar_0 = new HScrollBar();

	internal VScrollBar vscrollBar_0 = new VScrollBar();

	private Panel panel_0 = new Panel();

	private Panel panel_1 = new Panel();

	private int int_0 = 0;

	private int int_1 = 0;

	private int int_2 = 0;

	private int int_3 = 0;

	private int int_4 = 0;

	[CompilerGenerated]
	private ScrollPositionChangedEventHandler scrollPositionChangedEventHandler_0;

	[CompilerGenerated]
	private ScrollPositionChangedEventHandler scrollPositionChangedEventHandler_1;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DefaultValue(false)]
	public override bool AutoScroll
	{
		get
		{
			return false;
		}
		set
		{
			if (value)
			{
				throw new SourceGridException("Auto Scroll not supported in this control");
			}
			base.AutoScroll = false;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public VScrollBar VScrollBar => vscrollBar_0;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public HScrollBar HScrollBar => hscrollBar_0;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Panel BottomRightPanel => panel_0;

	[Browsable(false)]
	public bool HScrollBarVisible => hscrollBar_0.Height != 0;

	[Browsable(false)]
	public bool VScrollBarVisible => vscrollBar_0.Width != 0;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected internal int HorizontalPage => int_0;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected internal int VerticalPage => int_1;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Point CustomScrollPosition
	{
		get
		{
			int num = 0;
			if (HScrollBarVisible)
			{
				num = hscrollBar_0.Value;
			}
			int num2 = 0;
			if (VScrollBarVisible)
			{
				num2 = vscrollBar_0.Value;
			}
			return new Point(num, num2);
		}
		set
		{
			if (HScrollBarVisible)
			{
				if (value.X <= 0)
				{
					hscrollBar_0.Value = 0;
				}
				else
				{
					hscrollBar_0.Value = value.X;
				}
			}
			if (VScrollBarVisible && vscrollBar_0.Maximum >= value.Y)
			{
				if (value.Y <= 0)
				{
					vscrollBar_0.Value = 0;
				}
				else
				{
					vscrollBar_0.Value = value.Y;
				}
			}
		}
	}

	public new Rectangle DisplayRectangle
	{
		get
		{
			int num = 0;
			if (HScrollBarVisible)
			{
				num = hscrollBar_0.Height;
			}
			int num2 = 0;
			if (VScrollBarVisible)
			{
				num2 = vscrollBar_0.Width;
			}
			Rectangle displayRectangle = base.DisplayRectangle;
			return new Rectangle(displayRectangle.X, displayRectangle.Y, displayRectangle.Width - num2, displayRectangle.Height - num);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected internal int MaximumVScroll
	{
		get
		{
			if (!VScrollBarVisible)
			{
				return 0;
			}
			return vscrollBar_0.Maximum - (vscrollBar_0.LargeChange - 1);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected int MinimumVScroll => 0;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected int MinimumHScroll => 0;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected internal int MaximumHScroll
	{
		get
		{
			if (!HScrollBarVisible)
			{
				return 0;
			}
			return hscrollBar_0.Maximum - (hscrollBar_0.LargeChange - 1);
		}
	}

	public event ScrollPositionChangedEventHandler VScrollPositionChanged
	{
		[CompilerGenerated]
		add
		{
			ScrollPositionChangedEventHandler scrollPositionChangedEventHandler = scrollPositionChangedEventHandler_0;
			ScrollPositionChangedEventHandler scrollPositionChangedEventHandler2;
			do
			{
				scrollPositionChangedEventHandler2 = scrollPositionChangedEventHandler;
				ScrollPositionChangedEventHandler value2 = (ScrollPositionChangedEventHandler)Delegate.Combine(scrollPositionChangedEventHandler2, value);
				scrollPositionChangedEventHandler = Interlocked.CompareExchange(ref scrollPositionChangedEventHandler_0, value2, scrollPositionChangedEventHandler2);
			}
			while ((object)scrollPositionChangedEventHandler != scrollPositionChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ScrollPositionChangedEventHandler scrollPositionChangedEventHandler = scrollPositionChangedEventHandler_0;
			ScrollPositionChangedEventHandler scrollPositionChangedEventHandler2;
			do
			{
				scrollPositionChangedEventHandler2 = scrollPositionChangedEventHandler;
				ScrollPositionChangedEventHandler value2 = (ScrollPositionChangedEventHandler)Delegate.Remove(scrollPositionChangedEventHandler2, value);
				scrollPositionChangedEventHandler = Interlocked.CompareExchange(ref scrollPositionChangedEventHandler_0, value2, scrollPositionChangedEventHandler2);
			}
			while ((object)scrollPositionChangedEventHandler != scrollPositionChangedEventHandler2);
		}
	}

	public event ScrollPositionChangedEventHandler HScrollPositionChanged
	{
		[CompilerGenerated]
		add
		{
			ScrollPositionChangedEventHandler scrollPositionChangedEventHandler = scrollPositionChangedEventHandler_1;
			ScrollPositionChangedEventHandler scrollPositionChangedEventHandler2;
			do
			{
				scrollPositionChangedEventHandler2 = scrollPositionChangedEventHandler;
				ScrollPositionChangedEventHandler value2 = (ScrollPositionChangedEventHandler)Delegate.Combine(scrollPositionChangedEventHandler2, value);
				scrollPositionChangedEventHandler = Interlocked.CompareExchange(ref scrollPositionChangedEventHandler_1, value2, scrollPositionChangedEventHandler2);
			}
			while ((object)scrollPositionChangedEventHandler != scrollPositionChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ScrollPositionChangedEventHandler scrollPositionChangedEventHandler = scrollPositionChangedEventHandler_1;
			ScrollPositionChangedEventHandler scrollPositionChangedEventHandler2;
			do
			{
				scrollPositionChangedEventHandler2 = scrollPositionChangedEventHandler;
				ScrollPositionChangedEventHandler value2 = (ScrollPositionChangedEventHandler)Delegate.Remove(scrollPositionChangedEventHandler2, value);
				scrollPositionChangedEventHandler = Interlocked.CompareExchange(ref scrollPositionChangedEventHandler_1, value2, scrollPositionChangedEventHandler2);
			}
			while ((object)scrollPositionChangedEventHandler != scrollPositionChangedEventHandler2);
		}
	}

	public CustomScrollControl()
	{
		SuspendLayout();
		base.Name = "CustomScrollControl";
		base.AutoScroll = false;
		SetStyle(ControlStyles.UserPaint, value: true);
		SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
		CreateDockControls();
		ResumeLayout(performLayout: false);
	}

	protected virtual void CreateDockControls()
	{
		panel_1.SuspendLayout();
		panel_1.Controls.Add(hscrollBar_0);
		panel_1.Controls.Add(panel_0);
		panel_1.Dock = DockStyle.Bottom;
		panel_0.Dock = DockStyle.Right;
		hscrollBar_0.Dock = DockStyle.Fill;
		vscrollBar_0.Dock = DockStyle.Right;
		base.Controls.Add(vscrollBar_0);
		base.Controls.Add(panel_1);
		hscrollBar_0.ValueChanged += hscrollBar_0_ValueChanged;
		vscrollBar_0.ValueChanged += vscrollBar_0_ValueChanged;
		vscrollBar_0.TabStop = false;
		hscrollBar_0.TabStop = false;
		panel_0.TabStop = false;
		panel_1.TabStop = false;
		panel_1.TabIndex = 1;
		panel_0.TabIndex = 2;
		vscrollBar_0.TabIndex = 3;
		hscrollBar_0.TabIndex = 4;
		panel_0.BackColor = Color.FromKnownColor(KnownColor.Control);
		PrepareScrollBars(showHScroll: false, showVScroll: false);
		panel_1.ResumeLayout(performLayout: false);
	}

	protected abstract void InvalidateScrollableArea();

	protected virtual void PrepareScrollBars(bool showHScroll, bool showVScroll)
	{
		if (showHScroll != HScrollBarVisible)
		{
			if (!showHScroll)
			{
				panel_1.Height = 0;
				SetHScrollBarVisible(value: false);
			}
			else
			{
				panel_1.Height = SystemInformation.HorizontalScrollBarHeight;
				SetHScrollBarVisible(value: true);
			}
		}
		if (showVScroll != VScrollBarVisible)
		{
			if (!showVScroll)
			{
				SetVScrollBarVisible(value: false);
				panel_0.Width = 0;
			}
			else
			{
				SetVScrollBarVisible(value: true);
				panel_0.Width = vscrollBar_0.Width;
			}
		}
	}

	protected void SetHScrollBarVisible(bool value)
	{
		if (!value)
		{
			hscrollBar_0.Height = 0;
		}
		else
		{
			hscrollBar_0.Height = SystemInformation.HorizontalScrollBarHeight;
		}
	}

	protected void SetVScrollBarVisible(bool value)
	{
		if (!value)
		{
			vscrollBar_0.Width = 0;
		}
		else
		{
			vscrollBar_0.Width = SystemInformation.VerticalScrollBarWidth;
		}
	}

	protected internal void LoadScrollArea(int verticalPage, int horizontalPage)
	{
		if (verticalPage >= 0)
		{
			int_1 = verticalPage;
			if (horizontalPage < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			int_0 = horizontalPage;
			RecalcCustomScrollBars();
			return;
		}
		throw new ArgumentOutOfRangeException();
	}

	public void RecalcCustomScrollBars()
	{
		SuspendLayout();
		int scrollRows = GetScrollRows(base.DisplayRectangle.Height);
		int scrollColumns = GetScrollColumns(base.DisplayRectangle.Width);
		PrepareScrollBars(scrollColumns > 0, scrollRows > 0);
		if (scrollRows > 0)
		{
			scrollRows = GetScrollRows(DisplayRectangle.Height);
		}
		if (scrollColumns > 0)
		{
			scrollColumns = GetScrollColumns(DisplayRectangle.Width);
		}
		scrollRows -= GetActualFixedRows();
		Class76.smethod_71(scrollRows, this);
		Class76.smethod_516(this, scrollColumns);
		InvalidateScrollableArea();
		ResumeLayout(performLayout: true);
	}

	protected abstract int GetScrollRows(int displayHeight);

	protected abstract int GetActualFixedRows();

	protected abstract int GetScrollColumns(int displayWidth);

	protected override void OnLayout(LayoutEventArgs levent)
	{
		if (levent.AffectedControl == this)
		{
			RecalcCustomScrollBars();
			base.OnLayout(levent);
		}
		else
		{
			base.OnLayout(levent);
		}
	}

	public new void SuspendLayout()
	{
		base.SuspendLayout();
		int_2++;
	}

	public new void ResumeLayout()
	{
		base.ResumeLayout();
		if (int_2 > 0)
		{
			int_2--;
		}
	}

	public new void ResumeLayout(bool performLayout)
	{
		base.ResumeLayout(performLayout);
		if (int_2 > 0)
		{
			int_2--;
		}
	}

	public new void PerformLayout()
	{
		PerformLayout(this, null);
	}

	public new void PerformLayout(Control affectedControl, string affectedProperty)
	{
		base.PerformLayout(affectedControl, affectedProperty);
	}

	public bool IsSuspended()
	{
		return int_2 > 0;
	}

	private void vscrollBar_0_ValueChanged(object sender, EventArgs e)
	{
		OnVScrollPositionChanged(new ScrollPositionChangedEventArgs(-vscrollBar_0.Value, -int_3));
		InvalidateScrollableArea();
		int_3 = vscrollBar_0.Value;
	}

	private void hscrollBar_0_ValueChanged(object sender, EventArgs e)
	{
		OnHScrollPositionChanged(new ScrollPositionChangedEventArgs(-hscrollBar_0.Value, -int_4));
		InvalidateScrollableArea();
		int_4 = hscrollBar_0.Value;
	}

	protected virtual void OnVScrollPositionChanged(ScrollPositionChangedEventArgs e)
	{
		if (scrollPositionChangedEventHandler_0 != null)
		{
			scrollPositionChangedEventHandler_0(this, e);
		}
	}

	protected virtual void OnHScrollPositionChanged(ScrollPositionChangedEventArgs e)
	{
		if (scrollPositionChangedEventHandler_1 != null)
		{
			scrollPositionChangedEventHandler_1(this, e);
		}
	}

	public virtual void CustomScrollPageDown()
	{
		if (VScrollBarVisible)
		{
			vscrollBar_0.Value = Math.Min(vscrollBar_0.Value + vscrollBar_0.LargeChange, vscrollBar_0.Maximum - vscrollBar_0.LargeChange);
		}
	}

	public virtual void CustomScrollPageToLine(int line)
	{
		if (VScrollBarVisible && vscrollBar_0.Value != line)
		{
			vscrollBar_0.Value = Math.Min(line, vscrollBar_0.Maximum);
		}
	}

	public virtual bool IsMaxPage()
	{
		return vscrollBar_0.Value == vscrollBar_0.Maximum;
	}

	public virtual void CustomScrollPageUp()
	{
		if (VScrollBarVisible)
		{
			vscrollBar_0.Value = Math.Max(vscrollBar_0.Value - vscrollBar_0.LargeChange, vscrollBar_0.Minimum);
		}
	}

	public virtual void CustomScrollPageRight()
	{
		if (HScrollBarVisible)
		{
			hscrollBar_0.Value = Math.Min(hscrollBar_0.Value + hscrollBar_0.LargeChange, hscrollBar_0.Maximum - hscrollBar_0.LargeChange);
		}
	}

	public virtual void CustomScrollPageLeft()
	{
		if (HScrollBarVisible)
		{
			hscrollBar_0.Value = Math.Max(hscrollBar_0.Value - hscrollBar_0.LargeChange, hscrollBar_0.Minimum);
		}
	}

	public virtual void CustomScrollWheel(int rotationDelta)
	{
		if ((rotationDelta >= 120 || rotationDelta <= -120) && VScrollBarVisible)
		{
			Point customScrollPosition = CustomScrollPosition;
			int num = customScrollPosition.Y + SystemInformation.MouseWheelScrollLines * VScrollBar.SmallChange * -Math.Sign(rotationDelta);
			if (num < 0)
			{
				num = 0;
			}
			if (num > MaximumVScroll)
			{
				num = MaximumVScroll;
			}
			CustomScrollPosition = new Point(customScrollPosition.X, num);
		}
	}

	public virtual void CustomScrollLineDown()
	{
		if (VScrollBarVisible)
		{
			vscrollBar_0.Value = Math.Min(vscrollBar_0.Value + vscrollBar_0.SmallChange, vscrollBar_0.Maximum);
		}
	}

	public virtual void CustomScrollLineUp()
	{
		if (VScrollBarVisible)
		{
			vscrollBar_0.Value = Math.Max(vscrollBar_0.Value - vscrollBar_0.SmallChange, vscrollBar_0.Minimum);
		}
	}

	public virtual void CustomScrollLineRight()
	{
		if (HScrollBarVisible)
		{
			hscrollBar_0.Value = Math.Min(hscrollBar_0.Value + hscrollBar_0.SmallChange, hscrollBar_0.Maximum);
		}
	}

	public virtual void CustomScrollLineLeft()
	{
		if (HScrollBarVisible)
		{
			hscrollBar_0.Value = Math.Max(hscrollBar_0.Value - hscrollBar_0.SmallChange, hscrollBar_0.Minimum);
		}
	}
}
