// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buNavigationPanel
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

public class buNavigationPanel : buContainerControl
{
  private MouseState mouseState_0;
  private bool bool_0 = false;
  private int int_2 = 100;
  private int int_3 = 100;
  private int int_4 = 0;
  private int int_5 = 0;
  private ThemeType themeType_0 = ThemeType.Standart;
  internal HotkeyPrefix hotkeyPrefix_0 = HotkeyPrefix.None;
  private buControlDisplay buControlDisplay_1 = new buControlDisplay();
  private buControlNavigationPanel buControlNavigationPanel_0 = new buControlNavigationPanel();
  private NavigationDockPositionType navigationDockPositionType_0 = NavigationDockPositionType.Left;
  private buControlLanguage buControlLanguage_0 = new buControlLanguage();
  private int int_6 = 25;
  private int int_7 = 50;
  private bool bool_1;
  private string string_1 = "";

  public buNavigationPanel()
  {
    try
    {
      Class39.smethod_602();
      this.Display.Parent = (Control) this;
      this.Geometry.Parent = (Control) this;
      this.Theme.Parent = (Control) this;
      this.Navigation.Parent = (Control) this;
      this.TitleDisplay.Parent = (Control) this;
      this.Navigation.ButtonDisplay.Parent = (Control) this;
      this.Image = (Image) null;
      this.bool_1 = true;
      Class39.smethod_700(this, this.bool_1);
      this.ImageList = (ImageList) null;
      this.TextAlign = ContentAlignment.MiddleCenter;
      this.ImageAlign = ContentAlignment.MiddleLeft;
      this.Navigation.ButtonDisplay.BackColor = Color.Gray;
      this.SetStyle(ControlStyles.Selectable, false);
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
      this.int_2 = this.Width;
      this.int_3 = this.Height;
      this.int_4 = this.Left;
      this.int_5 = this.Top;
    }
    catch (Exception ex)
    {
    }
  }

  [DefaultValue(true)]
  public bool UseMnemonic
  {
    get => this.bool_1;
    set
    {
      if (this.bool_1 == value)
        return;
      this.bool_1 = value;
      Class39.smethod_700(this, this.bool_1);
      this.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay TitleDisplay
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
  public buControlNavigationPanel Navigation
  {
    get => this.buControlNavigationPanel_0;
    set
    {
      this.buControlNavigationPanel_0 = value;
      this.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(25)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int TitleHeight
  {
    get => this.int_6;
    set
    {
      this.int_6 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(NavigationDockPositionType.Left)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public NavigationDockPositionType Position
  {
    get => this.navigationDockPositionType_0;
    set
    {
      this.navigationDockPositionType_0 = value;
      this.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(50)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int MinimizedLength
  {
    get => this.int_7;
    set
    {
      this.int_7 = value;
      this.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue("")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public override string Text
  {
    get => this.string_1;
    set
    {
      this.string_1 = value;
      this.Invalidate();
    }
  }

  public void SetMinimized(bool bMinimized)
  {
    this.bool_0 = !bMinimized;
    if (this.Position == NavigationDockPositionType.Left)
    {
      if (!this.bool_0)
      {
        this.bool_0 = true;
        this.int_2 = this.Width;
        if (this.MinimizedLength < this.Navigation.ButtonSize)
          this.Width = this.MinimizedLength;
        else
          this.Width = this.Navigation.ButtonSize + 5;
        for (int index = 0; index <= this.Controls.Count - 1; ++index)
          this.Controls[index].Visible = false;
      }
      else
      {
        this.bool_0 = false;
        this.Width = this.int_2;
        for (int index = 0; index <= this.Controls.Count - 1; ++index)
          this.Controls[index].Visible = true;
      }
      // ISSUE: reference to a compiler-generated field
      if (this.navigasyonChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.navigasyonChangedEventHandler_0(this.bool_0);
      }
    }
    if (this.Position == NavigationDockPositionType.Right)
    {
      if (!this.bool_0)
      {
        this.bool_0 = true;
        this.int_2 = this.Width;
        this.int_4 = this.Left;
        if (this.MinimizedLength < this.Navigation.ButtonSize)
        {
          this.Left = this.Left + this.Width - this.MinimizedLength - 2;
          this.Width = this.MinimizedLength - 2;
        }
        else
        {
          this.Left = this.Left + this.Width - this.Navigation.ButtonSize - 5;
          this.Width = this.Navigation.ButtonSize + 5;
        }
        for (int index = 0; index <= this.Controls.Count - 1; ++index)
          this.Controls[index].Visible = false;
      }
      else
      {
        this.bool_0 = false;
        this.Left = this.int_4;
        this.Width = this.int_2;
        for (int index = 0; index <= this.Controls.Count - 1; ++index)
          this.Controls[index].Visible = true;
      }
      // ISSUE: reference to a compiler-generated field
      if (this.navigasyonChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.navigasyonChangedEventHandler_0(this.bool_0);
      }
    }
    if (this.Position == NavigationDockPositionType.Down)
    {
      if (!this.bool_0)
      {
        this.bool_0 = true;
        this.int_3 = this.Height;
        this.int_5 = this.Top;
        this.Top += this.Height - this.MinimizedLength;
        this.Height = this.MinimizedLength;
        for (int index = 0; index <= this.Controls.Count - 1; ++index)
          this.Controls[index].Visible = false;
      }
      else
      {
        this.bool_0 = false;
        this.Top = this.int_5;
        this.Height = this.int_3;
        for (int index = 0; index <= this.Controls.Count - 1; ++index)
          this.Controls[index].Visible = true;
      }
      // ISSUE: reference to a compiler-generated field
      if (this.navigasyonChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.navigasyonChangedEventHandler_0(this.bool_0);
      }
    }
    if (this.Position != NavigationDockPositionType.Up)
      return;
    if (!this.bool_0)
    {
      this.bool_0 = true;
      this.int_3 = this.Height;
      this.Height = this.MinimizedLength;
      for (int index = 0; index <= this.Controls.Count - 1; ++index)
        this.Controls[index].Visible = false;
    }
    else
    {
      this.bool_0 = false;
      this.Height = this.int_3;
      for (int index = 0; index <= this.Controls.Count - 1; ++index)
        this.Controls[index].Visible = true;
    }
    // ISSUE: reference to a compiler-generated field
    if (this.navigasyonChangedEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.navigasyonChangedEventHandler_0(this.bool_0);
  }

  protected override void OnResize(EventArgs e)
  {
    try
    {
      base.OnResize(e);
      if (this.DesignMode)
      {
        this.int_2 = this.Width;
        this.int_3 = this.Height;
        this.int_4 = this.Left;
        this.int_5 = this.Top;
      }
      this.Invalidate();
    }
    catch (Exception ex)
    {
    }
  }

  protected override void OnMouseUp(MouseEventArgs e)
  {
    try
    {
      this.mouseState_0 = MouseState.None;
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
      if (this.Position == NavigationDockPositionType.Left)
      {
        if (e.Y < Convert.ToInt32(this.Navigation.ButtonSize))
        {
          if (e.X > 0 & e.X < this.Navigation.ButtonSize)
          {
            this.mouseState_0 = MouseState.Down;
            if (!this.bool_0)
            {
              this.bool_0 = true;
              this.int_2 = this.Width;
              if (this.MinimizedLength < this.Navigation.ButtonSize)
                this.Width = this.MinimizedLength;
              else
                this.Width = this.Navigation.ButtonSize + 5;
              for (int index = 0; index <= this.Controls.Count - 1; ++index)
                this.Controls[index].Visible = false;
            }
            else
            {
              this.bool_0 = false;
              this.Width = this.int_2;
              for (int index = 0; index <= this.Controls.Count - 1; ++index)
                this.Controls[index].Visible = true;
            }
            // ISSUE: reference to a compiler-generated field
            if (this.navigasyonChangedEventHandler_0 != null)
            {
              // ISSUE: reference to a compiler-generated field
              this.navigasyonChangedEventHandler_0(this.bool_0);
            }
          }
          else
            this.mouseState_0 = MouseState.None;
        }
        else
          this.mouseState_0 = MouseState.None;
      }
      if (this.Position == NavigationDockPositionType.Right)
      {
        if (e.Y < Convert.ToInt32(this.Navigation.ButtonSize))
        {
          if (e.X > this.Width - this.Navigation.ButtonSize & e.X < this.Width)
          {
            this.mouseState_0 = MouseState.Down;
            if (!this.bool_0)
            {
              this.bool_0 = true;
              this.int_2 = this.Width;
              this.int_4 = this.Left;
              if (this.MinimizedLength < this.Navigation.ButtonSize)
              {
                this.Left = this.Left + this.Width - this.MinimizedLength - 2;
                this.Width = this.MinimizedLength - 2;
              }
              else
              {
                this.Left = this.Left + this.Width - this.Navigation.ButtonSize - 5;
                this.Width = this.Navigation.ButtonSize + 5;
              }
              for (int index = 0; index <= this.Controls.Count - 1; ++index)
                this.Controls[index].Visible = false;
            }
            else
            {
              this.bool_0 = false;
              this.Left = this.int_4;
              this.Width = this.int_2;
              for (int index = 0; index <= this.Controls.Count - 1; ++index)
                this.Controls[index].Visible = true;
            }
            // ISSUE: reference to a compiler-generated field
            if (this.navigasyonChangedEventHandler_0 != null)
            {
              // ISSUE: reference to a compiler-generated field
              this.navigasyonChangedEventHandler_0(this.bool_0);
            }
          }
          else
            this.mouseState_0 = MouseState.None;
        }
        else
          this.mouseState_0 = MouseState.None;
      }
      if (this.Position == NavigationDockPositionType.Down)
      {
        if (this.Height - this.Navigation.ButtonSize < e.Y & e.Y < this.Height)
        {
          if (e.X > 0 & e.X < this.Navigation.ButtonSize)
          {
            this.mouseState_0 = MouseState.Down;
            if (!this.bool_0)
            {
              this.bool_0 = true;
              this.int_3 = this.Height;
              this.int_5 = this.Top;
              this.Top += this.Height - this.MinimizedLength;
              this.Height = this.MinimizedLength;
              for (int index = 0; index <= this.Controls.Count - 1; ++index)
                this.Controls[index].Visible = false;
            }
            else
            {
              this.bool_0 = false;
              this.Top = this.int_5;
              this.Height = this.int_3;
              for (int index = 0; index <= this.Controls.Count - 1; ++index)
                this.Controls[index].Visible = true;
            }
            // ISSUE: reference to a compiler-generated field
            if (this.navigasyonChangedEventHandler_0 != null)
            {
              // ISSUE: reference to a compiler-generated field
              this.navigasyonChangedEventHandler_0(this.bool_0);
            }
          }
          else
            this.mouseState_0 = MouseState.None;
        }
        else
          this.mouseState_0 = MouseState.None;
      }
      if (this.Position == NavigationDockPositionType.Up)
      {
        if (e.Y > 0 & e.Y < Convert.ToInt32(this.Navigation.ButtonSize))
        {
          if (e.X > 0 & e.X < this.Navigation.ButtonSize)
          {
            this.mouseState_0 = MouseState.Down;
            if (!this.bool_0)
            {
              this.bool_0 = true;
              this.int_3 = this.Height;
              this.Height = this.MinimizedLength;
              for (int index = 0; index <= this.Controls.Count - 1; ++index)
                this.Controls[index].Visible = false;
            }
            else
            {
              this.bool_0 = false;
              this.Height = this.int_3;
              for (int index = 0; index <= this.Controls.Count - 1; ++index)
                this.Controls[index].Visible = true;
            }
            // ISSUE: reference to a compiler-generated field
            if (this.navigasyonChangedEventHandler_0 != null)
            {
              // ISSUE: reference to a compiler-generated field
              this.navigasyonChangedEventHandler_0(this.bool_0);
            }
          }
          else
            this.mouseState_0 = MouseState.None;
        }
        else
          this.mouseState_0 = MouseState.None;
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
      if (this.Position == NavigationDockPositionType.Left)
        this.mouseState_0 = e.Y >= Convert.ToInt32(this.Navigation.ButtonSize) ? MouseState.None : (!(e.X > this.Width - this.Navigation.ButtonSize & e.X < this.Width) ? MouseState.None : MouseState.Move);
      if (this.Position == NavigationDockPositionType.Right | this.Position == NavigationDockPositionType.Down)
        this.mouseState_0 = e.Y >= Convert.ToInt32(this.Navigation.ButtonSize) ? MouseState.None : (!(e.X > 0 & e.X < this.Navigation.ButtonSize) ? MouseState.None : MouseState.Move);
      if (this.Position == NavigationDockPositionType.Up)
        this.mouseState_0 = !(e.Y > Convert.ToInt32(this.Height - this.Navigation.ButtonSize) & e.Y < Convert.ToInt32(this.Height)) ? MouseState.None : (!(e.X > 0 & e.X < this.Navigation.ButtonSize) ? MouseState.None : MouseState.Move);
      this.Cursor = Cursors.Default;
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
      this.Invalidate();
      if (this.mouseState_0 == MouseState.None)
        ;
      base.OnMouseLeave(e);
    }
    catch (Exception ex)
    {
    }
  }

  public event buNavigationPanel.NavigasyonChangedEventHandler StateChanged;

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
      double height1 = (double) clientRectangle1.Height;
      local1 = new RectangleF((float) left1, (float) top1, (float) width1, (float) height1);
      Rectangle clientRectangle2 = this.ClientRectangle;
      double left2 = (double) clientRectangle2.Left;
      clientRectangle2 = this.ClientRectangle;
      double top2 = (double) clientRectangle2.Top;
      clientRectangle2 = this.ClientRectangle;
      double width2 = (double) clientRectangle2.Width;
      double titleHeight1 = (double) this.TitleHeight;
      rectDraw rectDraw1 = new rectDraw(new RectangleF((float) left2, (float) top2, (float) width2, (float) titleHeight1), RoundRectangleType.RoundRectAll);
      RectangleF rect = new RectangleF();
      Graphics graphics1 = e.Graphics;
      if (this.Theme.Type != this.themeType_0)
      {
        buControlThemeVars Vars = new buControlThemeVars();
        buControlTheme.UpdateTheme(this.Theme.Type, ref Vars);
        this.Geometry = new buControlGeometry(Vars.Geometry);
        this.Display = new buControlDisplay(Vars.Display);
        this.TitleDisplay = new buControlDisplay(Vars.DisplayGroupTitle);
        this.Navigation.ButtonDisplay = new buControlDisplay(Vars.DisplayButtonNormal);
        this.Navigation.Parent = (Control) this;
        this.Navigation.ButtonDisplay.Parent = (Control) this;
        this.Display.Parent = (Control) this;
        this.Geometry.Parent = (Control) this;
        this.Theme.Parent = (Control) this;
        this.TitleDisplay.Parent = (Control) this;
      }
      string Text = ControlGeometry.LanguageSelect(this.Language, text);
      if (this.Width > 0 & this.Height > 0)
      {
        ControlGeometry.drawGeometry((RectangleF) this.ClientRectangle, this.Geometry, this.Display, RoundRectangleType.RoundRectAll, ref graphics1);
        if (this.Position == NavigationDockPositionType.Left)
        {
          clientRectangle2 = this.ClientRectangle;
          double left3 = (double) clientRectangle2.Left;
          clientRectangle2 = this.ClientRectangle;
          double top3 = (double) clientRectangle2.Top;
          double titleHeight2 = (double) this.TitleHeight;
          double height2 = (double) this.Height;
          rectDraw rectDraw2 = new rectDraw(new RectangleF((float) left3, (float) top3, (float) titleHeight2, (float) height2), RoundRectangleType.RoundRectAll);
          ref RectangleF local2 = ref rect;
          clientRectangle2 = this.ClientRectangle;
          double left4 = (double) clientRectangle2.Left;
          clientRectangle2 = this.ClientRectangle;
          double top4 = (double) clientRectangle2.Top;
          double titleHeight3 = (double) this.TitleHeight;
          double buttonSize = (double) this.Navigation.ButtonSize;
          local2 = new RectangleF((float) left4, (float) top4, (float) titleHeight3, (float) buttonSize);
          ControlGeometry.drawGeometry(rectDraw2.rect, this.Geometry, this.TitleDisplay, RoundRectangleType.RoundRectDown, ref graphics1);
          ControlGeometry.drawGeometry(rect, this.Geometry, this.Navigation.ButtonDisplay, RoundRectangleType.RoundRectDown, ref graphics1);
          if (this.Image != null)
            rectDraw2.rectText = ControlGeometry.GetTextRectangleFromImage(this.Image, this.ImageAlign, rectDraw2.rectText, this.Geometry, this.ImageBorderOffset);
          ControlGeometry.drawString(rect, "↔", 0.0f, this.Navigation.ButtonDisplay, this.hotkeyPrefix_0, ref graphics1);
          if (!this.bool_0)
            ControlGeometry.drawString(rectDraw2.rectText, Text, -90f, this.TitleDisplay, this.hotkeyPrefix_0, ref graphics1);
          else
            ControlGeometry.drawString(rectDraw2.rectText, Text, -90f, this.TitleDisplay, this.hotkeyPrefix_0, ref graphics1);
          Graphics graphics2 = e.Graphics;
          Image image = this.Image;
          clientRectangle2 = this.ClientRectangle;
          int left5 = clientRectangle2.Left;
          clientRectangle2 = this.ClientRectangle;
          int top5 = clientRectangle2.Top;
          clientRectangle2 = this.ClientRectangle;
          int width3 = clientRectangle2.Width;
          int titleHeight4 = this.TitleHeight;
          Rectangle r = new Rectangle(left5, top5, width3, titleHeight4);
          int imageAlign = (int) this.ImageAlign;
          this.DrawImage(graphics2, image, r, (ContentAlignment) imageAlign);
        }
        if (this.Position == NavigationDockPositionType.Right)
        {
          clientRectangle2 = this.ClientRectangle;
          double x1 = (double) (clientRectangle2.Width - this.TitleHeight);
          clientRectangle2 = this.ClientRectangle;
          double top6 = (double) clientRectangle2.Top;
          double titleHeight5 = (double) this.TitleHeight;
          double height3 = (double) this.Height;
          rectDraw rectDraw3 = new rectDraw(new RectangleF((float) x1, (float) top6, (float) titleHeight5, (float) height3), RoundRectangleType.RoundRectAll);
          ref RectangleF local3 = ref rect;
          clientRectangle2 = this.ClientRectangle;
          double x2 = (double) (clientRectangle2.Width - this.TitleHeight);
          clientRectangle2 = this.ClientRectangle;
          double top7 = (double) clientRectangle2.Top;
          double titleHeight6 = (double) this.TitleHeight;
          double buttonSize = (double) this.Navigation.ButtonSize;
          local3 = new RectangleF((float) x2, (float) top7, (float) titleHeight6, (float) buttonSize);
          ControlGeometry.drawGeometry(rectDraw3.rect, this.Geometry, this.TitleDisplay, RoundRectangleType.RoundRectDown, ref graphics1);
          ControlGeometry.drawGeometry(rect, this.Geometry, this.Navigation.ButtonDisplay, RoundRectangleType.RoundRectDown, ref graphics1);
          if (this.Image != null)
            rectDraw3.rectText = ControlGeometry.GetTextRectangleFromImage(this.Image, this.ImageAlign, rectDraw3.rectText, this.Geometry, this.ImageBorderOffset);
          ControlGeometry.drawString(rect, "↔", 0.0f, this.Navigation.ButtonDisplay, this.hotkeyPrefix_0, ref graphics1);
          if (!this.bool_0)
            ControlGeometry.drawString(rectDraw3.rectText, Text, -90f, this.TitleDisplay, this.hotkeyPrefix_0, ref graphics1);
          else
            ControlGeometry.drawString(rectDraw3.rectText, Text, -90f, this.TitleDisplay, this.hotkeyPrefix_0, ref graphics1);
          Graphics graphics3 = e.Graphics;
          Image image = this.Image;
          clientRectangle2 = this.ClientRectangle;
          int left6 = clientRectangle2.Left;
          clientRectangle2 = this.ClientRectangle;
          int top8 = clientRectangle2.Top;
          clientRectangle2 = this.ClientRectangle;
          int width4 = clientRectangle2.Width;
          int titleHeight7 = this.TitleHeight;
          Rectangle r = new Rectangle(left6, top8, width4, titleHeight7);
          int imageAlign = (int) this.ImageAlign;
          this.DrawImage(graphics3, image, r, (ContentAlignment) imageAlign);
        }
        if (this.Position == NavigationDockPositionType.Up)
        {
          clientRectangle2 = this.ClientRectangle;
          double left7 = (double) clientRectangle2.Left;
          clientRectangle2 = this.ClientRectangle;
          double top9 = (double) clientRectangle2.Top;
          clientRectangle2 = this.ClientRectangle;
          double width5 = (double) clientRectangle2.Width;
          double titleHeight8 = (double) this.TitleHeight;
          rectDraw rectDraw4 = new rectDraw(new RectangleF((float) left7, (float) top9, (float) width5, (float) titleHeight8), RoundRectangleType.RoundRectAll);
          ref RectangleF local4 = ref rect;
          clientRectangle2 = this.ClientRectangle;
          double left8 = (double) clientRectangle2.Left;
          clientRectangle2 = this.ClientRectangle;
          double top10 = (double) clientRectangle2.Top;
          double buttonSize = (double) this.Navigation.ButtonSize;
          double titleHeight9 = (double) this.TitleHeight;
          local4 = new RectangleF((float) left8, (float) top10, (float) buttonSize, (float) titleHeight9);
          ControlGeometry.drawGeometry(rectDraw4.rect, this.Geometry, this.TitleDisplay, RoundRectangleType.RoundRectDown, ref graphics1);
          ControlGeometry.drawGeometry(rect, this.Geometry, this.Navigation.ButtonDisplay, RoundRectangleType.RoundRectDown, ref graphics1);
          if (this.Image != null)
            rectDraw4.rectText = ControlGeometry.GetTextRectangleFromImage(this.Image, this.ImageAlign, rectDraw4.rectText, this.Geometry, this.ImageBorderOffset);
          ControlGeometry.drawString(rect, "↨", 0.0f, this.Navigation.ButtonDisplay, this.hotkeyPrefix_0, ref graphics1);
          if (!this.bool_0)
            ControlGeometry.drawString(rectDraw4.rectText, Text, this.TitleDisplay, this.hotkeyPrefix_0, ref graphics1);
          else
            ControlGeometry.drawString(rectDraw4.rectText, Text, this.TitleDisplay, this.hotkeyPrefix_0, ref graphics1);
          Graphics graphics4 = e.Graphics;
          Image image = this.Image;
          clientRectangle2 = this.ClientRectangle;
          int left9 = clientRectangle2.Left;
          clientRectangle2 = this.ClientRectangle;
          int top11 = clientRectangle2.Top;
          clientRectangle2 = this.ClientRectangle;
          int width6 = clientRectangle2.Width;
          int titleHeight10 = this.TitleHeight;
          Rectangle r = new Rectangle(left9, top11, width6, titleHeight10);
          int imageAlign = (int) this.ImageAlign;
          this.DrawImage(graphics4, image, r, (ContentAlignment) imageAlign);
        }
        if (this.Position == NavigationDockPositionType.Down)
        {
          clientRectangle2 = this.ClientRectangle;
          double left10 = (double) clientRectangle2.Left;
          double y1 = (double) (this.Height - this.TitleHeight);
          clientRectangle2 = this.ClientRectangle;
          double width7 = (double) clientRectangle2.Width;
          double titleHeight11 = (double) this.TitleHeight;
          rectDraw rectDraw5 = new rectDraw(new RectangleF((float) left10, (float) y1, (float) width7, (float) titleHeight11), RoundRectangleType.RoundRectAll);
          ref RectangleF local5 = ref rect;
          clientRectangle2 = this.ClientRectangle;
          double left11 = (double) clientRectangle2.Left;
          clientRectangle2 = this.ClientRectangle;
          double y2 = (double) (clientRectangle2.Height - this.TitleHeight);
          double buttonSize = (double) this.Navigation.ButtonSize;
          double titleHeight12 = (double) this.TitleHeight;
          local5 = new RectangleF((float) left11, (float) y2, (float) buttonSize, (float) titleHeight12);
          ControlGeometry.drawGeometry(rectDraw5.rect, this.Geometry, this.TitleDisplay, RoundRectangleType.RoundRectDown, ref graphics1);
          ControlGeometry.drawGeometry(rect, this.Geometry, this.Navigation.ButtonDisplay, RoundRectangleType.RoundRectDown, ref graphics1);
          if (this.Image != null)
            rectDraw5.rectText = ControlGeometry.GetTextRectangleFromImage(this.Image, this.ImageAlign, rectDraw5.rectText, this.Geometry, this.ImageBorderOffset);
          ControlGeometry.drawString(rect, "↨", 0.0f, this.Navigation.ButtonDisplay, this.hotkeyPrefix_0, ref graphics1);
          if (!this.bool_0)
            ControlGeometry.drawString(rectDraw5.rectText, Text, this.TitleDisplay, this.hotkeyPrefix_0, ref graphics1);
          else
            ControlGeometry.drawString(rectDraw5.rectText, Text, this.TitleDisplay, this.hotkeyPrefix_0, ref graphics1);
          Graphics graphics5 = e.Graphics;
          Image image = this.Image;
          clientRectangle2 = this.ClientRectangle;
          int left12 = clientRectangle2.Left;
          clientRectangle2 = this.ClientRectangle;
          int top12 = clientRectangle2.Top;
          clientRectangle2 = this.ClientRectangle;
          int width8 = clientRectangle2.Width;
          int titleHeight13 = this.TitleHeight;
          Rectangle r = new Rectangle(left12, top12, width8, titleHeight13);
          int imageAlign = (int) this.ImageAlign;
          this.DrawImage(graphics5, image, r, (ContentAlignment) imageAlign);
        }
      }
      this.themeType_0 = this.Theme.Type;
      base.OnPaint(e);
    }
    catch (Exception ex)
    {
    }
  }

  public delegate void NavigasyonChangedEventHandler(bool Minimized);
}
