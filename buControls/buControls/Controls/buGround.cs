// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buGround
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

public class buGround : buContainerControl
{
  protected MouseState State;
  private ThemeType themeType_0 = ThemeType.Standart;
  private Point point_0 = new Point(0, 0);
  private bool bool_0 = false;
  public bool HasShown;
  private bool bool_1;
  private bool bool_2;
  private bool bool_3;
  private bool bool_4;
  private bool bool_5;
  private bool bool_6;
  private bool bool_7;
  private bool bool_8;
  internal bool bool_9;
  internal bool bool_10;
  internal bool bool_11;
  internal bool bool_12;
  internal bool bool_13;
  internal bool bool_14;
  internal bool bool_15;
  internal bool bool_16;
  private buControlDisplay buControlDisplay_1 = new buControlDisplay();
  private buControlDisplay buControlDisplay_2 = new buControlDisplay();
  private buControlGround buControlGround_0 = new buControlGround();
  private buControlLanguage buControlLanguage_0 = new buControlLanguage();
  private bool bool_17 = true;
  private string string_1;
  private bool bool_18 = true;
  private bool bool_19 = false;
  private bool bool_20;
  private FormStartPosition formStartPosition_0;

  public buGround()
  {
    try
    {
      Class39.smethod_749();
      this.TextAlign = ContentAlignment.MiddleCenter;
      this.ImageAlign = ContentAlignment.MiddleLeft;
      this.Ground.Parent = (Control) this;
      this.Display.Parent = (Control) this;
      this.DisplayBottom.Parent = (Control) this;
      this.DisplayTop.Parent = (Control) this;
      this.Theme.Parent = (Control) this;
      this.Language.Parent = (Control) this;
      this.DisplayTop.BackColor = Color.Gray;
      this.DisplayBottom.BackColor = Color.Gray;
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.BackColor = Color.Transparent;
      this.DoubleBuffered = true;
    }
    catch (Exception ex)
    {
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue("")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string AuxInfo
  {
    get => this.string_1;
    set
    {
      this.string_1 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlLanguage Language
  {
    get => this.buControlLanguage_0;
    set
    {
      this.buControlLanguage_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay DisplayTop
  {
    get => this.buControlDisplay_1;
    set
    {
      this.buControlDisplay_1 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay DisplayBottom
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
  public buControlGround Ground
  {
    get => this.buControlGround_0;
    set
    {
      this.buControlGround_0 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [SettingsBindable(true)]
  public override string Text
  {
    get => base.Text;
    set
    {
      base.Text = value;
      this.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(false)]
  public bool Sizable
  {
    get => this.bool_17;
    set => this.bool_17 = value;
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(false)]
  public bool SmartBounds
  {
    get => this.bool_18;
    set => this.bool_18 = value;
  }

  protected bool IsParentForm => this.bool_19;

  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(false)]
  protected bool IsParentMdi => this.Parent != null && this.Parent.Parent != null;

  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(false)]
  protected bool ControlMode
  {
    get => this.bool_20;
    set
    {
      this.bool_20 = value;
      this.Invalidate();
    }
  }

  public FormStartPosition StartPosition
  {
    get
    {
      return (!this.bool_19 ? 0 : (!this.bool_20 ? 1 : 0)) == 0 ? this.formStartPosition_0 : this.ParentForm.StartPosition;
    }
    set
    {
      this.formStartPosition_0 = value;
      if ((!this.bool_19 ? 0 : (!this.bool_20 ? 1 : 0)) == 0)
        return;
      this.ParentForm.StartPosition = value;
    }
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    this.Cursor = Cursors.Default;
    if (this.bool_0)
      this.ParentForm.Location = new Point(Control.MousePosition.X - this.point_0.X, Control.MousePosition.Y - this.point_0.Y);
    Point point = Cursor.Position;
    int x1 = point.X;
    point = Cursor.Position;
    int y1 = point.Y;
    Class39.smethod_562(this);
    point = Cursor.Position;
    int x2 = point.X;
    point = this.ParentForm.Location;
    int num1 = point.X + this.ParentForm.Width - 3;
    int num2 = x2 > num1 ? 1 : 0;
    point = Cursor.Position;
    int y2 = point.Y;
    point = this.ParentForm.Location;
    int num3 = point.Y + 3;
    int num4 = y2 > num3 ? 1 : 0;
    int num5 = num2 & num4;
    point = Cursor.Position;
    int y3 = point.Y;
    point = this.ParentForm.Location;
    int num6 = point.Y + this.ParentForm.Height - 3;
    int num7 = y3 < num6 ? 1 : 0;
    if ((num5 & num7) != 0)
    {
      if (!(!this.bool_0 & this.ParentForm.WindowState != FormWindowState.Maximized & this.ParentForm.WindowState != FormWindowState.Minimized))
        ;
    }
    else
    {
      point = Cursor.Position;
      int x3 = point.X;
      point = this.ParentForm.Location;
      int num8 = point.X + 3;
      int num9 = x3 < num8 ? 1 : 0;
      point = Cursor.Position;
      int y4 = point.Y;
      point = this.ParentForm.Location;
      int num10 = point.Y + 3;
      int num11 = y4 > num10 ? 1 : 0;
      int num12 = num9 & num11;
      point = Cursor.Position;
      int y5 = point.Y;
      point = this.ParentForm.Location;
      int num13 = point.Y + this.ParentForm.Height - 3;
      int num14 = y5 < num13 ? 1 : 0;
      if ((num12 & num14) != 0)
      {
        if (!(!this.bool_0 & this.ParentForm.WindowState != FormWindowState.Maximized & this.ParentForm.WindowState != FormWindowState.Minimized))
          ;
      }
      else
      {
        point = Cursor.Position;
        int y6 = point.Y;
        point = this.ParentForm.Location;
        int num15 = point.Y + 3;
        int num16 = y6 < num15 ? 1 : 0;
        point = Cursor.Position;
        int x4 = point.X;
        point = this.ParentForm.Location;
        int num17 = point.X + 3;
        int num18 = x4 > num17 ? 1 : 0;
        int num19 = num16 & num18;
        point = Cursor.Position;
        int x5 = point.X;
        point = this.ParentForm.Location;
        int num20 = point.X + this.ParentForm.Width - 3;
        int num21 = x5 < num20 ? 1 : 0;
        if ((num19 & num21) != 0)
        {
          if (!(!this.bool_0 & this.ParentForm.WindowState != FormWindowState.Maximized & this.ParentForm.WindowState != FormWindowState.Minimized))
            ;
        }
        else
        {
          point = Cursor.Position;
          int y7 = point.Y;
          point = this.ParentForm.Location;
          int num22 = point.Y + this.ParentForm.Height - 3;
          int num23 = y7 > num22 ? 1 : 0;
          point = Cursor.Position;
          int x6 = point.X;
          point = this.ParentForm.Location;
          int num24 = point.X + 3;
          int num25 = x6 > num24 ? 1 : 0;
          int num26 = num23 & num25;
          point = Cursor.Position;
          int x7 = point.X;
          point = this.ParentForm.Location;
          int num27 = point.X + this.ParentForm.Width - 3;
          int num28 = x7 < num27 ? 1 : 0;
          if ((num26 & num28) != 0)
          {
            if (!(!this.bool_0 & this.ParentForm.WindowState != FormWindowState.Maximized & this.ParentForm.WindowState != FormWindowState.Minimized))
              ;
          }
          else
          {
            int num29 = x1;
            point = this.ParentForm.Location;
            int num30 = point.X + this.ParentForm.Width - 3;
            int num31 = num29 >= num30 ? 1 : 0;
            int num32 = y1;
            point = this.ParentForm.Location;
            int num33 = point.Y + 3;
            int num34 = num32 <= num33 ? 1 : 0;
            if ((num31 & num34) != 0)
            {
              if (!this.bool_0 & this.ParentForm.WindowState != FormWindowState.Maximized & this.ParentForm.WindowState != FormWindowState.Minimized)
              {
                this.Cursor = Cursors.SizeNESW;
                this.bool_5 = true;
              }
            }
            else
            {
              int num35 = x1;
              point = this.ParentForm.Location;
              int num36 = point.X + 3;
              int num37 = num35 <= num36 ? 1 : 0;
              int num38 = y1;
              point = this.ParentForm.Location;
              int num39 = point.Y + 3;
              int num40 = num38 <= num39 ? 1 : 0;
              if ((num37 & num40) != 0)
              {
                if (!this.bool_0 & this.ParentForm.WindowState != FormWindowState.Maximized & this.ParentForm.WindowState != FormWindowState.Minimized)
                {
                  this.Cursor = Cursors.SizeNWSE;
                  this.bool_6 = true;
                }
              }
              else
              {
                int num41 = x1;
                point = this.ParentForm.Location;
                int num42 = point.X + this.ParentForm.Width - 3;
                int num43 = num41 >= num42 ? 1 : 0;
                int num44 = y1;
                point = this.ParentForm.Location;
                int num45 = point.Y + this.ParentForm.Height - 3;
                int num46 = num44 >= num45 ? 1 : 0;
                if ((num43 & num46) != 0)
                {
                  if (!this.bool_0 & this.ParentForm.WindowState != FormWindowState.Maximized & this.ParentForm.WindowState != FormWindowState.Minimized)
                  {
                    this.Cursor = Cursors.SizeNWSE;
                    this.bool_7 = true;
                  }
                }
                else
                {
                  int num47 = x1;
                  point = this.ParentForm.Location;
                  int num48 = point.X + 3;
                  int num49 = num47 <= num48 ? 1 : 0;
                  int num50 = y1;
                  point = this.ParentForm.Location;
                  int num51 = point.Y + this.ParentForm.Height - 3;
                  int num52 = num50 >= num51 ? 1 : 0;
                  if ((num49 & num52) != 0)
                  {
                    if (!this.bool_0 & this.ParentForm.WindowState != FormWindowState.Maximized & this.ParentForm.WindowState != FormWindowState.Minimized)
                    {
                      this.Cursor = Cursors.SizeNESW;
                      this.bool_8 = true;
                    }
                  }
                  else
                  {
                    this.bool_1 = false;
                    this.bool_2 = false;
                    this.bool_3 = false;
                    this.bool_4 = false;
                    this.bool_5 = false;
                    this.bool_6 = false;
                    this.bool_7 = false;
                    this.bool_8 = false;
                    this.Cursor = Cursors.Default;
                  }
                }
              }
            }
          }
        }
      }
    }
    base.OnMouseMove(e);
  }

  protected override void OnMouseUp(MouseEventArgs e)
  {
    Class39.smethod_583(this);
    this.Cursor = Cursors.Default;
    this.bool_0 = false;
    this.Invalidate();
    base.OnMouseMove(e);
  }

  protected override void OnMouseDown(MouseEventArgs e)
  {
    this.point_0.X = e.X;
    this.point_0.Y = e.Y;
    this.Cursor = Cursors.Default;
    this.bool_0 = e.Y >= 0 & e.Y <= this.Ground.TopHeight;
    if (e.Button == MouseButtons.Left)
    {
      this.bool_9 = this.bool_1;
      this.bool_10 = this.bool_2;
      this.bool_11 = this.bool_3;
      this.bool_12 = this.bool_4;
      this.bool_13 = this.bool_5;
      this.bool_14 = this.bool_6;
      this.bool_15 = this.bool_7;
      this.bool_16 = this.bool_8;
    }
    this.Invalidate();
    base.OnMouseMove(e);
  }

  protected override void OnResize(EventArgs e)
  {
    try
    {
      base.OnResize(e);
      this.Invalidate();
    }
    catch (Exception ex)
    {
    }
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    try
    {
      string text = this.Text;
      RectangleF rectangleF;
      ref RectangleF local1 = ref rectangleF;
      Rectangle clientRectangle1 = this.ClientRectangle;
      double left1 = (double) clientRectangle1.Left;
      clientRectangle1 = this.ClientRectangle;
      double top1 = (double) clientRectangle1.Top;
      clientRectangle1 = this.ClientRectangle;
      double width1 = (double) clientRectangle1.Width;
      clientRectangle1 = this.ClientRectangle;
      double height = (double) clientRectangle1.Height;
      local1 = new RectangleF((float) left1, (float) top1, (float) width1, (float) height);
      RectangleF rect1;
      ref RectangleF local2 = ref rect1;
      Rectangle clientRectangle2 = this.ClientRectangle;
      double left2 = (double) clientRectangle2.Left;
      clientRectangle2 = this.ClientRectangle;
      double top2 = (double) clientRectangle2.Top;
      clientRectangle2 = this.ClientRectangle;
      double width2 = (double) clientRectangle2.Width;
      double topHeight1 = (double) this.Ground.TopHeight;
      local2 = new RectangleF((float) left2, (float) top2, (float) width2, (float) topHeight1);
      RectangleF rect2;
      ref RectangleF local3 = ref rect2;
      Rectangle clientRectangle3 = this.ClientRectangle;
      double left3 = (double) clientRectangle3.Left;
      double y = (double) (this.Height - this.Ground.BottomHeight);
      clientRectangle3 = this.ClientRectangle;
      double width3 = (double) clientRectangle3.Width;
      double bottomHeight = (double) this.Ground.BottomHeight;
      local3 = new RectangleF((float) left3, (float) y, (float) width3, (float) bottomHeight);
      Rectangle clientRectangle4 = this.ClientRectangle;
      double left4 = (double) clientRectangle4.Left;
      clientRectangle4 = this.ClientRectangle;
      double top3 = (double) clientRectangle4.Top;
      clientRectangle4 = this.ClientRectangle;
      double width4 = (double) clientRectangle4.Width;
      double topHeight2 = (double) this.Ground.TopHeight;
      rectDraw rectDraw = new rectDraw(new RectangleF((float) left4, (float) top3, (float) width4, (float) topHeight2), RoundRectangleType.RoundRectAll);
      Graphics graphics1 = e.Graphics;
      if (this.Theme.Type != this.themeType_0)
      {
        buControlThemeVars Vars = new buControlThemeVars();
        buControlTheme.UpdateTheme(this.Theme.Type, ref Vars);
        this.Geometry = new buControlGeometry(Vars.Geometry);
        this.Display = new buControlDisplay(Vars.Display);
        this.DisplayTop = new buControlDisplay(Vars.DisplayGroundTop);
        this.DisplayBottom = new buControlDisplay(Vars.DisplayGroundButtom);
        this.Ground = new buControlGround(Vars.Ground);
        this.Display.Parent = (Control) this;
        this.DisplayTop.Parent = (Control) this;
        this.DisplayBottom.Parent = (Control) this;
        this.Ground.Parent = (Control) this;
      }
      string Text = ControlGeometry.LanguageSelect(this.Language, text);
      if (this.Width > 0 & this.Height > 0)
      {
        if (this.Image != null)
          rectDraw.rectText = ControlGeometry.GetTextRectangleFromImage(this.Image, this.ImageAlign, rectDraw.rectText, this.Geometry, this.ImageBorderOffset);
        if (this.Enabled)
        {
          ControlGeometry.drawGeometry((RectangleF) this.ClientRectangle, this.Geometry, this.Display, RoundRectangleType.RoundRectAll, ref graphics1);
          ControlGeometry.drawGeometry(rect1, this.Geometry, this.DisplayTop, RoundRectangleType.RoundRectUp, ref graphics1);
          ControlGeometry.drawGeometry(rect2, this.Geometry, this.DisplayBottom, RoundRectangleType.RoundRectDown, ref graphics1);
          ControlGeometry.drawString(rectDraw.rectText, Text, this.DisplayTop, ref graphics1);
        }
        else
          ControlPaint.DrawStringDisabled(e.Graphics, this.Text, this.Display.Fonts.Font, this.Display.BackColor, rectDraw.rect, ControlGeometry.AlignmentToStringFormat(this.Display.Fonts.Alignment));
        Graphics graphics2 = e.Graphics;
        Image image = this.Image;
        clientRectangle4 = this.ClientRectangle;
        int left5 = clientRectangle4.Left;
        clientRectangle4 = this.ClientRectangle;
        int top4 = clientRectangle4.Top;
        clientRectangle4 = this.ClientRectangle;
        int width5 = clientRectangle4.Width;
        int topHeight3 = this.Ground.TopHeight;
        Rectangle r = new Rectangle(left5, top4, width5, topHeight3);
        int imageAlign = (int) this.ImageAlign;
        this.DrawImage(graphics2, image, r, (ContentAlignment) imageAlign);
        this.themeType_0 = this.Theme.Type;
      }
      base.OnPaint(e);
    }
    catch (Exception ex)
    {
    }
  }

  public static buGround CopyVisual(buGround refGround, buGround copyGround)
  {
    copyGround.Display = buControlDisplay.Copy(refGround.Display, copyGround.Display);
    copyGround.DisplayTop = buControlDisplay.Copy(refGround.DisplayTop, copyGround.DisplayTop);
    copyGround.DisplayBottom = buControlDisplay.Copy(refGround.DisplayBottom, copyGround.DisplayBottom);
    copyGround.Geometry.Space = refGround.Geometry.Space;
    copyGround.Geometry.ArcDiameter = refGround.Geometry.ArcDiameter;
    copyGround.Geometry.ShapeMode = refGround.Geometry.ShapeMode;
    copyGround.Ground.TopHeight = refGround.Ground.TopHeight;
    copyGround.Ground.BottomHeight = refGround.Ground.BottomHeight;
    copyGround.ImageAlign = refGround.ImageAlign;
    return copyGround;
  }
}
