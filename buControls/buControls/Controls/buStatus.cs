// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buStatus
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[DefaultProperty("Status")]
[DefaultEvent("Click")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class buStatus : buControl
{
  private Timer timer_0 = new Timer();
  private Timer timer_1 = new Timer();
  private ThemeType themeType_0 = ThemeType.Standart;
  private buControlStatus buControlStatus_0 = new buControlStatus();

  public buStatus()
  {
    try
    {
      Class39.smethod_747();
      this.Display.Parent = (Control) this;
      this.Geometry.Parent = (Control) this;
      this.Status.Parent = (Control) this;
      this.Status.Alarm.Parent = (Control) this;
      this.Status.Warning.Parent = (Control) this;
      this.Status.Information.Parent = (Control) this;
      this.Status.Status.Parent = (Control) this;
      this.Theme.Parent = (Control) this;
      this.Status.Alarm.BackColor = Color.Red;
      this.Status.Alarm.Fonts.Alignment = ContentAlignment.MiddleCenter;
      this.Status.Warning.BackColor = Color.Gold;
      this.Status.Warning.Fonts.Alignment = ContentAlignment.MiddleCenter;
      this.Status.Information.BackColor = Color.Blue;
      this.Status.Information.Fonts.Alignment = ContentAlignment.MiddleCenter;
      this.Status.Status.BackColor = Color.LightGray;
      this.Status.Status.Fonts.Alignment = ContentAlignment.MiddleCenter;
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
      this.timer_1.Tick += new EventHandler(this.timer_1_Tick);
      this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
      this.timer_0.Interval = 2000;
      this.DoubleBuffered = true;
      this.Size = new Size(166, 40);
    }
    catch (Exception ex)
    {
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlStatus Status
  {
    get => this.buControlStatus_0;
    set
    {
      this.buControlStatus_0 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  public void ShowWarning(string WarningText)
  {
    this.Status.WarningText = WarningText;
    this.Status.ShowWarning = true;
    this.Invalidate();
  }

  public void ShowInfo(string InfoText)
  {
    this.Status.InformationText = InfoText;
    this.Status.ShowInformation = true;
    this.Invalidate();
  }

  public void ShowInfo(string InfoText, bool TimeEnable)
  {
    this.Status.InformationText = InfoText;
    this.Status.ShowInformation = true;
    this.timer_1.Interval = this.Status.InformationTime;
    this.timer_1.Enabled = TimeEnable;
    this.Invalidate();
  }

  public void HideInfo()
  {
    this.Status.ShowInformation = false;
    this.timer_1.Enabled = false;
    this.Invalidate();
  }

  public void HideWarning()
  {
    this.Status.ShowWarning = false;
    this.Invalidate();
  }

  public void HideAlarm()
  {
    this.Status.ShowAlarm = false;
    this.Invalidate();
  }

  public void ShowAlarm(string AlarmText)
  {
    this.Status.AlarmText = AlarmText;
    this.Status.ShowAlarm = true;
    this.Status.ShowInformation = false;
    this.Invalidate();
  }

  private void timer_0_Tick(object sender, EventArgs e)
  {
    this.Status.ShowWarning = false;
    this.timer_0.Enabled = false;
    this.Invalidate();
  }

  private void timer_1_Tick(object sender, EventArgs e)
  {
    this.Status.ShowInformation = false;
    this.timer_1.Enabled = false;
    this.Invalidate();
  }

  protected override void OnMouseUp(MouseEventArgs e)
  {
    this.Invalidate();
    base.OnMouseUp(e);
  }

  protected override void OnMouseDown(MouseEventArgs e)
  {
    this.Invalidate();
    base.OnMouseDown(e);
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    this.Cursor = Cursors.Default;
    this.Invalidate();
    base.OnMouseMove(e);
  }

  protected override void OnMouseLeave(EventArgs e)
  {
    this.Invalidate();
    base.OnMouseLeave(e);
  }

  protected override void OnTextChanged(EventArgs e)
  {
    this.Invalidate();
    base.OnTextChanged(e);
  }

  protected override void OnResize(EventArgs e)
  {
    this.Invalidate();
    base.OnResize(e);
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    try
    {
      Graphics graphics = e.Graphics;
      if (this.Theme.Type != this.themeType_0)
      {
        buControlThemeVars Vars = new buControlThemeVars();
        buControlTheme.UpdateTheme(this.Theme.Type, ref Vars);
        this.Geometry = new buControlGeometry(Vars.Geometry);
        this.Display = new buControlDisplay(Vars.Display);
        this.Status.Alarm = new buControlDisplay(Vars.Status.Alarm);
        this.Status.Warning = new buControlDisplay(Vars.Status.Warning);
        this.Status.Information = new buControlDisplay(Vars.Status.Information);
        this.Status.Status = new buControlDisplay(Vars.Status.Status);
        this.Display.Parent = (Control) this;
        this.Status.Alarm.Parent = (Control) this;
        this.Status.Warning.Parent = (Control) this;
        this.Status.Information.Parent = (Control) this;
        this.Status.Status.Parent = (Control) this;
        this.Status.Parent = (Control) this;
      }
      if ((this.Width <= 0 ? 0 : (this.Height > 0 ? 1 : 0)) != 0)
      {
        RectangleF rect;
        ref RectangleF local = ref rect;
        Rectangle clientRectangle = this.ClientRectangle;
        double left = (double) clientRectangle.Left;
        clientRectangle = this.ClientRectangle;
        double top = (double) clientRectangle.Top;
        double width = (double) this.ClientRectangle.Width;
        double height = (double) this.ClientRectangle.Height;
        local = new RectangleF((float) left, (float) top, (float) width, (float) height);
        if (!this.Status.ShowWarning & !this.Status.ShowInformation & !this.Status.ShowAlarm)
        {
          ControlGeometry.drawGeometry(rect, this.Geometry, this.Status.Status, RoundRectangleType.RoundRectAll, ref graphics);
          ControlGeometry.drawString(rect, this.Status.StatusText, this.Status.Status, ref graphics);
        }
        if (this.Status.ShowInformation)
        {
          ControlGeometry.drawGeometry(rect, this.Geometry, this.Status.Information, RoundRectangleType.RoundRectAll, ref graphics);
          ControlGeometry.drawString(rect, this.Status.InformationText, this.Status.Information, ref graphics);
        }
        if (this.Status.ShowAlarm)
        {
          ControlGeometry.drawGeometry(rect, this.Geometry, this.Status.Alarm, RoundRectangleType.RoundRectAll, ref graphics);
          ControlGeometry.drawString(rect, this.Status.AlarmText, this.Status.Alarm, ref graphics);
        }
        if (this.Status.ShowWarning)
        {
          ControlGeometry.drawGeometry(rect, this.Geometry, this.Status.Warning, RoundRectangleType.RoundRectAll, ref graphics);
          ControlGeometry.drawString(rect, this.Status.WarningText, this.Status.Warning, ref graphics);
        }
      }
      this.themeType_0 = this.Theme.Type;
      base.OnPaint(e);
    }
    catch (Exception ex)
    {
    }
  }
}
