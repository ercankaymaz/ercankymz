// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buScrollBar
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

public class buScrollBar : buControl
{
  private double double_0;
  private MouseState mouseState_0;
  private MouseState mouseState_1;
  private ThemeType themeType_0 = ThemeType.Standart;
  private bool bool_0 = false;
  private buControlDisplay buControlDisplay_1 = new buControlDisplay();
  private buControlDisplay buControlDisplay_2 = new buControlDisplay();
  private buControlDisplay buControlDisplay_3 = new buControlDisplay();
  private buControlDisplay buControlDisplay_4 = new buControlDisplay();
  private buControlDisplay buControlDisplay_5 = new buControlDisplay();
  private buControlDisplay buControlDisplay_6 = new buControlDisplay();
  private buControlDisplay buControlDisplay_7 = new buControlDisplay();
  private ScrollBarType scrollBarType_0 = ScrollBarType.Vertical;
  private float float_0 = 20f;
  private float float_1 = 20f;
  private float float_2 = 1f;
  private int int_3 = 0;
  private int int_4 = 10;
  private double double_1 = 0.0;
  private double double_2 = 0.0;
  private string string_1 = "+";
  private string string_2 = "-";
  public double OldValue = 0.0;

  public event buControlEvents.buButtonPlusMinusMouseEventHandler MouseDownScrollBar;

  public event buControlEvents.buButtonPlusMinusMouseEventHandler MouseUpScrollBar;

  public event buControlEvents.buButtonPlusMinusMouseEventHandler MouseMoveScrollBar;

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay ButtonPlusOverDisplay
  {
    get => this.buControlDisplay_1;
    set
    {
      this.buControlDisplay_1 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay ButtonPlusNormalDisplay
  {
    get => this.buControlDisplay_2;
    set
    {
      this.buControlDisplay_2 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay ButtonPlusDownDisplay
  {
    get => this.buControlDisplay_3;
    set
    {
      this.buControlDisplay_3 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay ButtonMinusOverDisplay
  {
    get => this.buControlDisplay_4;
    set
    {
      this.buControlDisplay_4 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay ButtonMinusNormalDisplay
  {
    get => this.buControlDisplay_5;
    set
    {
      this.buControlDisplay_5 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay ButtonMinusDownDisplay
  {
    get => this.buControlDisplay_6;
    set
    {
      this.buControlDisplay_6 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DefaultValue(1f)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public float Increament
  {
    get => this.float_2;
    set
    {
      this.float_2 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(20f)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public float ButtonSize
  {
    get => this.float_0;
    set
    {
      this.float_0 = value;
      this.Invalidate();
    }
  }

  [DefaultValue("+")]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string PlusString
  {
    get => this.string_1;
    set
    {
      this.string_1 = value;
      this.Invalidate();
    }
  }

  [DefaultValue("-")]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string MinusString
  {
    get => this.string_2;
    set
    {
      this.string_2 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(0.0f)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public double Value
  {
    get => this.double_1;
    set
    {
      this.OldValue = this.double_1;
      this.double_1 = value;
      if (this.valueChangedEvent_0 != null && this.OldValue != this.double_1)
        this.valueChangedEvent_0(this.double_1, this.OldValue);
      this.Invalidate();
    }
  }

  [DefaultValue(20f)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public float ScrollWidth
  {
    get => this.float_1;
    set
    {
      this.float_1 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(0)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int MinimumValue
  {
    get => this.int_3;
    set
    {
      if (value >= this.int_4)
        value = this.int_4;
      if (this.double_1 < (double) value)
        this.double_1 = (double) value;
      this.int_3 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(10)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int MaximumValue
  {
    get => this.int_4;
    set
    {
      if (value <= this.int_3)
        value = this.int_3;
      if (this.double_1 > (double) value)
        this.double_1 = (double) value;
      this.int_4 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(ScrollBarType.Vertical)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public ScrollBarType ScrollPositionStyle
  {
    get => this.scrollBarType_0;
    set
    {
      this.scrollBarType_0 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(1)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public double Direction
  {
    get => this.double_2;
    set
    {
      this.double_2 = value;
      this.Invalidate();
    }
  }

  protected override void OnMouseUp(MouseEventArgs e)
  {
    try
    {
      this.bool_0 = false;
      this.mouseState_0 = MouseState.None;
      this.mouseState_1 = MouseState.None;
      if (this.ScrollPositionStyle == ScrollBarType.Vertical)
      {
        if (e.Y < Convert.ToInt32((float) this.Height / 2f))
        {
          // ISSUE: reference to a compiler-generated field
          if (this.buButtonPlusMinusMouseEventHandler_1 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.buButtonPlusMinusMouseEventHandler_1((object) this, e, 1);
          }
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          if (this.buButtonPlusMinusMouseEventHandler_1 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.buButtonPlusMinusMouseEventHandler_1((object) this, e, -1);
          }
        }
      }
      if (this.ScrollPositionStyle == ScrollBarType.Horizontal)
      {
        if (e.X < Convert.ToInt32((float) this.Width / 2f))
        {
          // ISSUE: reference to a compiler-generated field
          if (this.buButtonPlusMinusMouseEventHandler_1 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.buButtonPlusMinusMouseEventHandler_1((object) this, e, -1);
          }
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          if (this.buButtonPlusMinusMouseEventHandler_1 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.buButtonPlusMinusMouseEventHandler_1((object) this, e, 1);
          }
        }
      }
      this.Invalidate();
      base.OnMouseUp(e);
    }
    catch (Exception ex)
    {
    }
  }

  protected override void OnMouseDown(MouseEventArgs e)
  {
    try
    {
      this.bool_0 = true;
      if (this.ScrollPositionStyle == ScrollBarType.Vertical)
      {
        if (e.Y < Convert.ToInt32(this.ButtonSize))
        {
          this.mouseState_0 = MouseState.Down;
          this.mouseState_1 = MouseState.None;
          this.Value += (double) this.Increament * this.Direction;
          if (this.Value > (double) this.MaximumValue)
            this.Value = (double) this.MaximumValue;
          if (this.Value < (double) this.MinimumValue)
            this.Value = (double) this.MinimumValue;
          // ISSUE: reference to a compiler-generated field
          if (this.buButtonPlusMinusMouseEventHandler_0 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.buButtonPlusMinusMouseEventHandler_0((object) this, e, 1);
          }
        }
        else if (e.Y > this.Height - Convert.ToInt32(this.ButtonSize))
        {
          this.mouseState_1 = MouseState.Down;
          this.mouseState_0 = MouseState.None;
          this.Value -= (double) this.Increament * this.Direction;
          if (this.Value > (double) this.MaximumValue)
            this.Value = (double) this.MaximumValue;
          if (this.Value < (double) this.MinimumValue)
            this.Value = (double) this.MinimumValue;
          // ISSUE: reference to a compiler-generated field
          if (this.buButtonPlusMinusMouseEventHandler_0 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.buButtonPlusMinusMouseEventHandler_0((object) this, e, -1);
          }
        }
        else
        {
          float num1 = this.ButtonSize + 4f;
          float num2 = (float) ((double) this.Height - (double) this.ButtonSize * 1.0 - 4.0);
          float num3 = (num2 - num1) / (float) (this.MaximumValue - this.MinimumValue);
          this.Value = (double) Convert.ToInt32((float) this.MaximumValue - (num2 - (float) e.Y) / num3);
          this.Value = ((double) num2 - (double) e.Y) / (double) num3;
          if (this.Value > (double) this.MaximumValue)
            this.Value = (double) this.MaximumValue;
          if (this.Value < (double) this.MinimumValue)
            this.Value = (double) this.MinimumValue;
          this.mouseState_1 = MouseState.None;
          this.mouseState_0 = MouseState.None;
        }
      }
      if (this.ScrollPositionStyle == ScrollBarType.Horizontal)
      {
        if (e.X < Convert.ToInt32(this.ButtonSize))
        {
          this.mouseState_1 = MouseState.Down;
          this.mouseState_0 = MouseState.None;
          this.Value -= (double) this.Increament * this.Direction;
          if (this.Value > (double) this.MaximumValue)
            this.Value = (double) this.MaximumValue;
          if (this.Value < (double) this.MinimumValue)
            this.Value = (double) this.MinimumValue;
          // ISSUE: reference to a compiler-generated field
          if (this.buButtonPlusMinusMouseEventHandler_0 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.buButtonPlusMinusMouseEventHandler_0((object) this, e, -1);
          }
        }
        else if (e.X > this.Width - Convert.ToInt32(this.ButtonSize))
        {
          this.mouseState_1 = MouseState.None;
          this.mouseState_0 = MouseState.Down;
          this.Value += (double) this.Increament * this.Direction;
          if (this.Value > (double) this.MaximumValue)
            this.Value = (double) this.MaximumValue;
          if (this.Value < (double) this.MinimumValue)
            this.Value = (double) this.MinimumValue;
          // ISSUE: reference to a compiler-generated field
          if (this.buButtonPlusMinusMouseEventHandler_0 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.buButtonPlusMinusMouseEventHandler_0((object) this, e, 1);
          }
        }
        else
        {
          float num4 = this.ButtonSize + 4f;
          float num5 = (float) ((double) this.Width - (double) this.ButtonSize * 1.0 - 4.0);
          float num6 = (num5 - num4) / (float) (this.MaximumValue - this.MinimumValue);
          this.Value = (double) Convert.ToInt32((float) this.MaximumValue - (num5 - (float) e.X) / num6);
          if (this.Value > (double) this.MaximumValue)
            this.Value = (double) this.MaximumValue;
          if (this.Value < (double) this.MinimumValue)
            this.Value = (double) this.MinimumValue;
          this.mouseState_1 = MouseState.None;
          this.mouseState_0 = MouseState.None;
        }
      }
      this.Invalidate();
      base.OnMouseDown(e);
    }
    catch (Exception ex)
    {
    }
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    try
    {
      if (this.ScrollPositionStyle == ScrollBarType.Vertical)
      {
        if (e.Y < Convert.ToInt32(this.ButtonSize))
        {
          this.mouseState_0 = MouseState.Move;
          this.mouseState_1 = MouseState.None;
          // ISSUE: reference to a compiler-generated field
          if (this.buButtonPlusMinusMouseEventHandler_2 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.buButtonPlusMinusMouseEventHandler_0((object) this, e, 1);
          }
        }
        else if (e.Y > this.Height - Convert.ToInt32(this.ButtonSize))
        {
          this.mouseState_1 = MouseState.Move;
          this.mouseState_0 = MouseState.None;
          // ISSUE: reference to a compiler-generated field
          if (this.buButtonPlusMinusMouseEventHandler_2 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.buButtonPlusMinusMouseEventHandler_0((object) this, e, -1);
          }
        }
        else
        {
          if (this.bool_0)
          {
            float num1 = this.ButtonSize + 4f;
            float num2 = (float) ((double) this.Height - (double) this.ButtonSize * 1.0 - 4.0);
            float num3 = (num2 - num1) / (float) (this.MaximumValue - this.MinimumValue);
            this.Value = (double) (Convert.ToInt32((float) this.MaximumValue - (num2 - (float) e.Y) / num3) * -1);
            this.Value = ((double) num2 - (double) e.Y) / (double) num3;
            if (this.Value > (double) this.MaximumValue)
              this.Value = (double) this.MaximumValue;
            if (this.Value < (double) this.MinimumValue)
              this.Value = (double) this.MinimumValue;
          }
          this.mouseState_1 = MouseState.None;
          this.mouseState_0 = MouseState.None;
        }
      }
      if (this.ScrollPositionStyle == ScrollBarType.Horizontal)
      {
        if (e.X < Convert.ToInt32(this.ButtonSize))
        {
          this.mouseState_1 = MouseState.Move;
          this.mouseState_0 = MouseState.None;
          // ISSUE: reference to a compiler-generated field
          if (this.buButtonPlusMinusMouseEventHandler_2 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.buButtonPlusMinusMouseEventHandler_0((object) this, e, -1);
          }
        }
        else if (e.X > this.Width - Convert.ToInt32(this.ButtonSize))
        {
          this.mouseState_1 = MouseState.None;
          this.mouseState_0 = MouseState.Move;
          // ISSUE: reference to a compiler-generated field
          if (this.buButtonPlusMinusMouseEventHandler_2 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.buButtonPlusMinusMouseEventHandler_0((object) this, e, 1);
          }
        }
        else
        {
          if (this.bool_0)
          {
            float num4 = this.ButtonSize + 4f;
            float num5 = (float) ((double) this.Width - (double) this.ButtonSize * 1.0 - 4.0);
            float num6 = (num5 - num4) / (float) (this.MaximumValue - this.MinimumValue);
            this.Value = (double) Convert.ToInt32((float) this.MaximumValue - (num5 - (float) e.X) / num6);
            if (this.Value > (double) this.MaximumValue)
              this.Value = (double) this.MaximumValue;
            if (this.Value < (double) this.MinimumValue)
              this.Value = (double) this.MinimumValue;
          }
          this.mouseState_1 = MouseState.None;
          this.mouseState_0 = MouseState.None;
        }
      }
      this.Invalidate();
      base.OnMouseMove(e);
    }
    catch (Exception ex)
    {
    }
  }

  protected override void OnMouseLeave(EventArgs e)
  {
    try
    {
      this.mouseState_0 = MouseState.None;
      this.mouseState_1 = MouseState.None;
      this.Invalidate();
      base.OnMouseLeave(e);
    }
    catch (Exception ex)
    {
    }
  }

  protected override void OnTextChanged(EventArgs e)
  {
    try
    {
      this.Invalidate();
      base.OnTextChanged(e);
    }
    catch (Exception ex)
    {
    }
  }

  public event buScrollBar.ValueChangedEvent ValueChanged;

  public buScrollBar()
  {
    try
    {
      this.Display.Parent = (Control) this;
      this.Display.Parent = (Control) this;
      this.ButtonPlusDownDisplay.Parent = (Control) this;
      this.ButtonPlusNormalDisplay.Parent = (Control) this;
      this.ButtonPlusOverDisplay.Parent = (Control) this;
      this.ButtonMinusDownDisplay.Parent = (Control) this;
      this.ButtonMinusNormalDisplay.Parent = (Control) this;
      this.ButtonMinusOverDisplay.Parent = (Control) this;
      this.Display.Parent = (Control) this;
      this.ButtonPlusDownDisplay.BackColor = Color.DimGray;
      this.ButtonPlusNormalDisplay.BackColor = Color.LightGray;
      this.ButtonPlusOverDisplay.BackColor = Color.Gray;
      this.ButtonMinusDownDisplay.BackColor = Color.DimGray;
      this.ButtonMinusNormalDisplay.BackColor = Color.LightGray;
      this.ButtonMinusOverDisplay.BackColor = Color.Gray;
      this.buControlDisplay_7.BackColor = Color.DimGray;
      this.buControlDisplay_7.Parent = (Control) this;
      this.Geometry.Parent = (Control) this;
      this.Language.Parent = (Control) this;
      this.Theme.Parent = (Control) this;
      Class39.smethod_14();
      this.SetStyle(ControlStyles.Selectable, false);
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
      this.DoubleBuffered = true;
      this.Size = new Size(166, 40);
    }
    catch (Exception ex)
    {
    }
  }

  protected override void OnResize(EventArgs e)
  {
    try
    {
      this.Invalidate();
      base.OnResize(e);
    }
    catch (Exception ex)
    {
    }
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    try
    {
      RectangleF rect1;
      ref RectangleF local1 = ref rect1;
      Rectangle clientRectangle1 = this.ClientRectangle;
      double left1 = (double) clientRectangle1.Left;
      clientRectangle1 = this.ClientRectangle;
      double top1 = (double) clientRectangle1.Top;
      clientRectangle1 = this.ClientRectangle;
      double width1 = (double) clientRectangle1.Width;
      clientRectangle1 = this.ClientRectangle;
      double height1 = (double) clientRectangle1.Height;
      local1 = new RectangleF((float) left1, (float) top1, (float) width1, (float) height1);
      RectangleF rect2;
      ref RectangleF local2 = ref rect2;
      Rectangle clientRectangle2 = this.ClientRectangle;
      double left2 = (double) clientRectangle2.Left;
      clientRectangle2 = this.ClientRectangle;
      double top2 = (double) clientRectangle2.Top;
      clientRectangle2 = this.ClientRectangle;
      double width2 = (double) clientRectangle2.Width;
      clientRectangle2 = this.ClientRectangle;
      double height2 = (double) clientRectangle2.Height;
      local2 = new RectangleF((float) left2, (float) top2, (float) width2, (float) height2);
      RectangleF rect3 = new RectangleF();
      Graphics graphics = e.Graphics;
      if (this.Theme.Type != this.themeType_0)
      {
        buControlThemeVars Vars = new buControlThemeVars();
        buControlTheme.UpdateTheme(this.Theme.Type, ref Vars);
        this.Geometry = new buControlGeometry(Vars.Geometry);
        this.Display = new buControlDisplay(Vars.Display);
        this.ButtonPlusDownDisplay = new buControlDisplay(Vars.DisplayButtonDown);
        this.ButtonPlusNormalDisplay = new buControlDisplay(Vars.DisplayButtonNormal);
        this.ButtonPlusOverDisplay = new buControlDisplay(Vars.DisplayButtonOver);
        this.ButtonMinusDownDisplay = new buControlDisplay(Vars.DisplayButton2Down);
        this.ButtonMinusNormalDisplay = new buControlDisplay(Vars.DisplayButton2Normal);
        this.ButtonMinusOverDisplay = new buControlDisplay(Vars.DisplayButton2Over);
        this.Display.Parent = (Control) this;
        this.ButtonPlusDownDisplay.Parent = (Control) this;
        this.ButtonPlusNormalDisplay.Parent = (Control) this;
        this.ButtonPlusOverDisplay.Parent = (Control) this;
        this.ButtonMinusDownDisplay.Parent = (Control) this;
        this.ButtonMinusNormalDisplay.Parent = (Control) this;
        this.ButtonMinusOverDisplay.Parent = (Control) this;
      }
      if (this.Width > 0 & this.Height > 0)
      {
        if (this.ScrollPositionStyle == ScrollBarType.Horizontal)
        {
          ref RectangleF local3 = ref rect2;
          Rectangle clientRectangle3 = this.ClientRectangle;
          double left3 = (double) clientRectangle3.Left;
          clientRectangle3 = this.ClientRectangle;
          double top3 = (double) clientRectangle3.Top;
          double buttonSize1 = (double) this.ButtonSize;
          clientRectangle3 = this.ClientRectangle;
          double height3 = (double) clientRectangle3.Height;
          local3 = new RectangleF((float) left3, (float) top3, (float) buttonSize1, (float) height3);
          ref RectangleF local4 = ref rect1;
          clientRectangle3 = this.ClientRectangle;
          double x = (double) clientRectangle3.Width - (double) this.ButtonSize;
          clientRectangle3 = this.ClientRectangle;
          double top4 = (double) clientRectangle3.Top;
          double buttonSize2 = (double) this.ButtonSize;
          clientRectangle3 = this.ClientRectangle;
          double height4 = (double) clientRectangle3.Height;
          local4 = new RectangleF((float) x, (float) top4, (float) buttonSize2, (float) height4);
          float num1 = this.ButtonSize + 4f;
          float num2 = (float) ((double) this.Width - (double) this.ButtonSize * 1.0 - 4.0);
          try
          {
            float num3 = (num2 - num1) / (float) (this.MaximumValue - this.MinimumValue);
            this.double_0 = (double) num2 - (double) num3 * ((double) this.MaximumValue - this.Value) - ((double) this.MinimumValue - this.Value) / (double) (this.MinimumValue - this.MaximumValue) * (double) this.ButtonSize;
          }
          catch (Exception ex)
          {
          }
          rect3 = new RectangleF((float) this.double_0, this.Geometry.Space, this.ScrollWidth, (float) this.Height - this.Geometry.Space * 2f);
        }
        if (this.ScrollPositionStyle == ScrollBarType.Vertical)
        {
          ref RectangleF local5 = ref rect2;
          Rectangle clientRectangle4 = this.ClientRectangle;
          double left4 = (double) clientRectangle4.Left;
          clientRectangle4 = this.ClientRectangle;
          double y = (double) clientRectangle4.Height - (double) this.ButtonSize;
          clientRectangle4 = this.ClientRectangle;
          double width3 = (double) clientRectangle4.Width;
          double buttonSize = (double) this.ButtonSize;
          local5 = new RectangleF((float) left4, (float) y, (float) width3, (float) buttonSize);
          rect1 = new RectangleF((float) this.ClientRectangle.Left, (float) this.ClientRectangle.Top, (float) this.ClientRectangle.Width, this.ButtonSize);
          float num4 = (float) ((double) this.ButtonSize * 1.0 + 4.0);
          float num5 = (float) ((double) this.Height - (double) this.ButtonSize * 1.0 - 4.0);
          try
          {
            float num6 = (num5 - num4) / (float) (this.MinimumValue - this.MaximumValue);
            this.double_0 = (double) num5 - (double) num6 * ((double) this.MinimumValue - this.Value) - ((double) this.MaximumValue - this.Value) / (double) (this.MaximumValue - this.MinimumValue) * (double) this.ButtonSize;
          }
          catch (Exception ex)
          {
          }
          rect3 = new RectangleF(this.Geometry.Space, (float) this.double_0, (float) this.Width - this.Geometry.Space * 2f, this.ScrollWidth);
        }
        buControlDisplay Display1 = new buControlDisplay(this.ButtonPlusNormalDisplay);
        if (this.mouseState_0 == MouseState.Move)
          Display1 = new buControlDisplay(this.ButtonPlusOverDisplay);
        if (this.mouseState_0 == MouseState.Down)
          Display1 = new buControlDisplay(this.ButtonPlusDownDisplay);
        buControlDisplay Display2 = new buControlDisplay(this.ButtonMinusNormalDisplay);
        if (this.mouseState_1 == MouseState.Move)
          Display2 = new buControlDisplay(this.ButtonMinusOverDisplay);
        if (this.mouseState_1 == MouseState.Down)
          Display2 = new buControlDisplay(this.ButtonMinusDownDisplay);
        if (this.Enabled)
        {
          ControlGeometry.drawGeometry((RectangleF) this.ClientRectangle, this.Geometry, this.Display, RoundRectangleType.RoundRectAll, ref graphics);
          ControlGeometry.drawGeometry(rect1, this.Geometry, Display1, RoundRectangleType.RoundRectAll, ref graphics);
          ControlGeometry.drawString(rect1, this.PlusString, Display1, ref graphics);
          ControlGeometry.drawGeometry(rect2, this.Geometry, Display2, RoundRectangleType.RoundRectAll, ref graphics);
          ControlGeometry.drawString(rect2, this.MinusString, Display2, ref graphics);
          if ((double) rect3.Width > 0.0 & (double) rect3.Height > 0.0)
          {
            ControlGeometry.drawGeometry(rect3, this.Geometry, this.buControlDisplay_7, RoundRectangleType.RoundRectAll, ref graphics);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
          }
        }
      }
      this.themeType_0 = this.Theme.Type;
      base.OnPaint(e);
    }
    catch (Exception ex)
    {
    }
  }

  public void PropertiesValueChanged() => this.Invalidate();

  public delegate void ValueChangedEvent(double NewValue, double OldValue);
}
