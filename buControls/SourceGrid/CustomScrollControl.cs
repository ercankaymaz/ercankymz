// Decompiled with JetBrains decompiler
// Type: SourceGrid.CustomScrollControl
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
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

  public CustomScrollControl()
  {
    this.SuspendLayout();
    this.Name = nameof (CustomScrollControl);
    base.AutoScroll = false;
    this.SetStyle(ControlStyles.UserPaint, true);
    this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    this.CreateDockControls();
    this.ResumeLayout(false);
  }

  protected virtual void CreateDockControls()
  {
    this.panel_1.SuspendLayout();
    this.panel_1.Controls.Add((Control) this.hscrollBar_0);
    this.panel_1.Controls.Add((Control) this.panel_0);
    this.panel_1.Dock = DockStyle.Bottom;
    this.panel_0.Dock = DockStyle.Right;
    this.hscrollBar_0.Dock = DockStyle.Fill;
    this.vscrollBar_0.Dock = DockStyle.Right;
    this.Controls.Add((Control) this.vscrollBar_0);
    this.Controls.Add((Control) this.panel_1);
    this.hscrollBar_0.ValueChanged += new EventHandler(this.hscrollBar_0_ValueChanged);
    this.vscrollBar_0.ValueChanged += new EventHandler(this.vscrollBar_0_ValueChanged);
    this.vscrollBar_0.TabStop = false;
    this.hscrollBar_0.TabStop = false;
    this.panel_0.TabStop = false;
    this.panel_1.TabStop = false;
    this.panel_1.TabIndex = 1;
    this.panel_0.TabIndex = 2;
    this.vscrollBar_0.TabIndex = 3;
    this.hscrollBar_0.TabIndex = 4;
    this.panel_0.BackColor = Color.FromKnownColor(KnownColor.Control);
    this.PrepareScrollBars(false, false);
    this.panel_1.ResumeLayout(false);
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [DefaultValue(false)]
  public override bool AutoScroll
  {
    get => false;
    set
    {
      if (value)
        throw new SourceGridException("Auto Scroll not supported in this control");
      base.AutoScroll = false;
    }
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public VScrollBar VScrollBar => this.vscrollBar_0;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public HScrollBar HScrollBar => this.hscrollBar_0;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Panel BottomRightPanel => this.panel_0;

  protected abstract void InvalidateScrollableArea();

  protected virtual void PrepareScrollBars(bool showHScroll, bool showVScroll)
  {
    if (showHScroll != this.HScrollBarVisible)
    {
      if (showHScroll)
      {
        this.panel_1.Height = SystemInformation.HorizontalScrollBarHeight;
        this.SetHScrollBarVisible(true);
      }
      else
      {
        this.panel_1.Height = 0;
        this.SetHScrollBarVisible(false);
      }
    }
    if (showVScroll == this.VScrollBarVisible)
      return;
    if (showVScroll)
    {
      this.SetVScrollBarVisible(true);
      this.panel_0.Width = this.vscrollBar_0.Width;
    }
    else
    {
      this.SetVScrollBarVisible(false);
      this.panel_0.Width = 0;
    }
  }

  protected void SetHScrollBarVisible(bool value)
  {
    if (value)
      this.hscrollBar_0.Height = SystemInformation.HorizontalScrollBarHeight;
    else
      this.hscrollBar_0.Height = 0;
  }

  [Browsable(false)]
  public bool HScrollBarVisible => this.hscrollBar_0.Height != 0;

  protected void SetVScrollBarVisible(bool value)
  {
    if (value)
      this.vscrollBar_0.Width = SystemInformation.VerticalScrollBarWidth;
    else
      this.vscrollBar_0.Width = 0;
  }

  [Browsable(false)]
  public bool VScrollBarVisible => this.vscrollBar_0.Width != 0;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  protected internal int HorizontalPage => this.int_0;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  protected internal int VerticalPage => this.int_1;

  protected internal void LoadScrollArea(int verticalPage, int horizontalPage)
  {
    this.int_1 = verticalPage >= 0 ? verticalPage : throw new ArgumentOutOfRangeException();
    this.int_0 = horizontalPage >= 0 ? horizontalPage : throw new ArgumentOutOfRangeException();
    this.RecalcCustomScrollBars();
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public virtual Point CustomScrollPosition
  {
    get
    {
      int x = 0;
      if (this.HScrollBarVisible)
        x = this.hscrollBar_0.Value;
      int y = 0;
      if (this.VScrollBarVisible)
        y = this.vscrollBar_0.Value;
      return new Point(x, y);
    }
    set
    {
      if (this.HScrollBarVisible)
      {
        if (value.X > 0)
          this.hscrollBar_0.Value = value.X;
        else
          this.hscrollBar_0.Value = 0;
      }
      if (!this.VScrollBarVisible || this.vscrollBar_0.Maximum < value.Y)
        return;
      if (value.Y > 0)
        this.vscrollBar_0.Value = value.Y;
      else
        this.vscrollBar_0.Value = 0;
    }
  }

  public new Rectangle DisplayRectangle
  {
    get
    {
      int num1 = 0;
      if (this.HScrollBarVisible)
        num1 = this.hscrollBar_0.Height;
      int num2 = 0;
      if (this.VScrollBarVisible)
        num2 = this.vscrollBar_0.Width;
      Rectangle displayRectangle = base.DisplayRectangle;
      return new Rectangle(displayRectangle.X, displayRectangle.Y, displayRectangle.Width - num2, displayRectangle.Height - num1);
    }
  }

  public void RecalcCustomScrollBars()
  {
    this.SuspendLayout();
    int scrollRows = this.GetScrollRows(base.DisplayRectangle.Height);
    int scrollColumns = this.GetScrollColumns(base.DisplayRectangle.Width);
    this.PrepareScrollBars(scrollColumns > 0, scrollRows > 0);
    if (scrollRows > 0)
      scrollRows = this.GetScrollRows(this.DisplayRectangle.Height);
    if (scrollColumns > 0)
      scrollColumns = this.GetScrollColumns(this.DisplayRectangle.Width);
    Class39.smethod_71(scrollRows - this.GetActualFixedRows(), this);
    Class39.smethod_516(this, scrollColumns);
    this.InvalidateScrollableArea();
    this.ResumeLayout(true);
  }

  protected abstract int GetScrollRows(int displayHeight);

  protected abstract int GetActualFixedRows();

  protected abstract int GetScrollColumns(int displayWidth);

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  protected internal int MaximumVScroll
  {
    get
    {
      return !this.VScrollBarVisible ? 0 : this.vscrollBar_0.Maximum - (this.vscrollBar_0.LargeChange - 1);
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
      return !this.HScrollBarVisible ? 0 : this.hscrollBar_0.Maximum - (this.hscrollBar_0.LargeChange - 1);
    }
  }

  protected override void OnLayout(LayoutEventArgs levent)
  {
    if (levent.AffectedControl != this)
    {
      base.OnLayout(levent);
    }
    else
    {
      this.RecalcCustomScrollBars();
      base.OnLayout(levent);
    }
  }

  public new void SuspendLayout()
  {
    base.SuspendLayout();
    ++this.int_2;
  }

  public new void ResumeLayout()
  {
    base.ResumeLayout();
    if (this.int_2 <= 0)
      return;
    --this.int_2;
  }

  public new void ResumeLayout(bool performLayout)
  {
    base.ResumeLayout(performLayout);
    if (this.int_2 <= 0)
      return;
    --this.int_2;
  }

  public new void PerformLayout() => this.PerformLayout((Control) this, (string) null);

  public new void PerformLayout(Control affectedControl, string affectedProperty)
  {
    base.PerformLayout(affectedControl, affectedProperty);
  }

  public bool IsSuspended() => this.int_2 > 0;

  private void vscrollBar_0_ValueChanged(object sender, EventArgs e)
  {
    this.OnVScrollPositionChanged(new ScrollPositionChangedEventArgs(-this.vscrollBar_0.Value, -this.int_3));
    this.InvalidateScrollableArea();
    this.int_3 = this.vscrollBar_0.Value;
  }

  private void hscrollBar_0_ValueChanged(object sender, EventArgs e)
  {
    this.OnHScrollPositionChanged(new ScrollPositionChangedEventArgs(-this.hscrollBar_0.Value, -this.int_4));
    this.InvalidateScrollableArea();
    this.int_4 = this.hscrollBar_0.Value;
  }

  public event ScrollPositionChangedEventHandler VScrollPositionChanged;

  protected virtual void OnVScrollPositionChanged(ScrollPositionChangedEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.scrollPositionChangedEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.scrollPositionChangedEventHandler_0((object) this, e);
  }

  public event ScrollPositionChangedEventHandler HScrollPositionChanged;

  protected virtual void OnHScrollPositionChanged(ScrollPositionChangedEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.scrollPositionChangedEventHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.scrollPositionChangedEventHandler_1((object) this, e);
  }

  public virtual void CustomScrollPageDown()
  {
    if (!this.VScrollBarVisible)
      return;
    this.vscrollBar_0.Value = Math.Min(this.vscrollBar_0.Value + this.vscrollBar_0.LargeChange, this.vscrollBar_0.Maximum - this.vscrollBar_0.LargeChange);
  }

  public virtual void CustomScrollPageToLine(int line)
  {
    if (!this.VScrollBarVisible || this.vscrollBar_0.Value == line)
      return;
    this.vscrollBar_0.Value = Math.Min(line, this.vscrollBar_0.Maximum);
  }

  public virtual bool IsMaxPage() => this.vscrollBar_0.Value == this.vscrollBar_0.Maximum;

  public virtual void CustomScrollPageUp()
  {
    if (!this.VScrollBarVisible)
      return;
    this.vscrollBar_0.Value = Math.Max(this.vscrollBar_0.Value - this.vscrollBar_0.LargeChange, this.vscrollBar_0.Minimum);
  }

  public virtual void CustomScrollPageRight()
  {
    if (!this.HScrollBarVisible)
      return;
    this.hscrollBar_0.Value = Math.Min(this.hscrollBar_0.Value + this.hscrollBar_0.LargeChange, this.hscrollBar_0.Maximum - this.hscrollBar_0.LargeChange);
  }

  public virtual void CustomScrollPageLeft()
  {
    if (!this.HScrollBarVisible)
      return;
    this.hscrollBar_0.Value = Math.Max(this.hscrollBar_0.Value - this.hscrollBar_0.LargeChange, this.hscrollBar_0.Minimum);
  }

  public virtual void CustomScrollWheel(int rotationDelta)
  {
    if ((rotationDelta >= 120 ? 1 : (rotationDelta <= -120 ? 1 : 0)) == 0 || !this.VScrollBarVisible)
      return;
    Point customScrollPosition = this.CustomScrollPosition;
    int y = customScrollPosition.Y + SystemInformation.MouseWheelScrollLines * this.VScrollBar.SmallChange * -Math.Sign(rotationDelta);
    if (y < 0)
      y = 0;
    if (y > this.MaximumVScroll)
      y = this.MaximumVScroll;
    this.CustomScrollPosition = new Point(customScrollPosition.X, y);
  }

  public virtual void CustomScrollLineDown()
  {
    if (!this.VScrollBarVisible)
      return;
    this.vscrollBar_0.Value = Math.Min(this.vscrollBar_0.Value + this.vscrollBar_0.SmallChange, this.vscrollBar_0.Maximum);
  }

  public virtual void CustomScrollLineUp()
  {
    if (!this.VScrollBarVisible)
      return;
    this.vscrollBar_0.Value = Math.Max(this.vscrollBar_0.Value - this.vscrollBar_0.SmallChange, this.vscrollBar_0.Minimum);
  }

  public virtual void CustomScrollLineRight()
  {
    if (!this.HScrollBarVisible)
      return;
    this.hscrollBar_0.Value = Math.Min(this.hscrollBar_0.Value + this.hscrollBar_0.SmallChange, this.hscrollBar_0.Maximum);
  }

  public virtual void CustomScrollLineLeft()
  {
    if (!this.HScrollBarVisible)
      return;
    this.hscrollBar_0.Value = Math.Max(this.hscrollBar_0.Value - this.hscrollBar_0.SmallChange, this.hscrollBar_0.Minimum);
  }
}
