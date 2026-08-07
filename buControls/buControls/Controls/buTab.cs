// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buTab
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

public class buTab : TabControl
{
  private ThemeType themeType_0 = ThemeType.Standart;
  public List<bool> TabPageVisible = new List<bool>();
  private buControlDisplay buControlDisplay_0 = new buControlDisplay();
  private buControlGeometry buControlGeometry_0 = new buControlGeometry();
  private buControlLanguage buControlLanguage_0 = new buControlLanguage();
  private buControlTab buControlTab_0 = new buControlTab();
  private buControlTheme buControlTheme_0 = new buControlTheme();
  private Color color_0 = Color.LightGray;

  public buTab()
  {
    this.Tabs.Parent = (Control) this;
    this.Display.Parent = (Control) this;
    this.Tabs.Header.Parent = (Control) this;
    this.Tabs.HeaderSelected.Parent = (Control) this;
    this.Geometry.Parent = (Control) this;
    this.Theme.Parent = (Control) this;
    this.Language.Parent = (Control) this;
    if (this.Parent != null)
      this.BackColor = this.Parent.BackColor;
    this.SetStyle(ControlStyles.Selectable, false);
    this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    this.Tabs.HeaderSelected.BackColor = Color.DarkGray;
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlTheme Theme
  {
    get => this.buControlTheme_0;
    set
    {
      this.buControlTheme_0 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay Display
  {
    get => this.buControlDisplay_0;
    set
    {
      this.buControlDisplay_0 = value;
      if (this.Parent == null)
      {
        int num = (int) MessageBox.Show("2122");
      }
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlGeometry Geometry
  {
    get => this.buControlGeometry_0;
    set
    {
      this.buControlGeometry_0 = value;
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
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlTab Tabs
  {
    get => this.buControlTab_0;
    set
    {
      this.buControlTab_0 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "LightGray")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public override Color BackColor
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  protected override void CreateHandle()
  {
    try
    {
      base.CreateHandle();
    }
    catch (Exception ex)
    {
    }
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    Graphics graphics = e.Graphics;
    Rectangle rectangle = new Rectangle();
    graphics.Clear(this.Display.BackColor);
    if (this.Alignment == TabAlignment.Top)
    {
      int width = this.Width;
      ControlGeometry.drawGeometry(new RectangleF(0.0f, (float) (this.ItemSize.Height - 1), (float) (this.Width - 1), (float) (this.Height - this.ItemSize.Height)), this.Geometry, this.Display, RoundRectangleType.RoundRectAll, ref graphics);
      for (int index = 0; index <= this.TabCount - 1; ++index)
      {
        bool flag = true;
        if (index <= this.TabPageVisible.Count - 1)
          flag = this.TabPageVisible[index];
        if (flag)
        {
          Rectangle tabRect = this.GetTabRect(index);
          if (index == this.SelectedIndex)
          {
            RoundRectangleType RoundRectangleType = RoundRectangleType.RoundRectNone;
            if (index == 0)
              RoundRectangleType = RoundRectangleType.RoundRectLeftUp;
            if (index == this.TabCount - 1)
              RoundRectangleType = RoundRectangleType.RoundRectRightUp;
            ControlGeometry.drawGeometry(new RectangleF((float) (tabRect.X + this.Tabs.HeaderXOffset), (float) (tabRect.Y - 2), (float) tabRect.Width, (float) tabRect.Height), this.Geometry, this.Tabs.HeaderSelected, RoundRectangleType, ref graphics);
            try
            {
              Point location = new Point(this.GetTabRect(index).Location.X + this.Tabs.HeaderXOffset, this.GetTabRect(index).Location.Y);
              graphics.DrawString(this.TabPages[index].Text, this.Tabs.HeaderSelected.Fonts.Font, (Brush) new SolidBrush(this.Tabs.HeaderSelected.Fonts.ForeColor), (RectangleF) new Rectangle(location, this.GetTabRect(index).Size), ControlGeometry.AlignmentToStringFormat(this.Tabs.HeaderSelected.Fonts.Alignment));
              this.TabPages[index].BackColor = this.Tabs.TabPageColor;
            }
            catch
            {
            }
          }
          else
          {
            RoundRectangleType RoundRectangleType = RoundRectangleType.RoundRectNone;
            if (index == 0)
              RoundRectangleType = RoundRectangleType.RoundRectLeftUp;
            if (index == this.TabCount - 1)
              RoundRectangleType = RoundRectangleType.RoundRectRightUp;
            ControlGeometry.drawGeometry(new RectangleF((float) (tabRect.X + this.Tabs.HeaderXOffset), (float) (tabRect.Y - 2), (float) tabRect.Width, (float) tabRect.Height), this.Geometry.ArcDiameter, this.Geometry.ShapeMode, this.Tabs.Header, RoundRectangleType, ref graphics);
            try
            {
              Point location = new Point(this.GetTabRect(index).Location.X + this.Tabs.HeaderXOffset, this.GetTabRect(index).Location.Y);
              graphics.DrawString(this.TabPages[index].Text, this.Tabs.Header.Fonts.Font, (Brush) new SolidBrush(this.Tabs.Header.Fonts.ForeColor), (RectangleF) new Rectangle(location, this.GetTabRect(index).Size), ControlGeometry.AlignmentToStringFormat(this.Tabs.Header.Fonts.Alignment));
              this.TabPages[index].BackColor = this.Tabs.TabPageColor;
            }
            catch
            {
            }
          }
        }
      }
    }
    else if (this.Alignment == TabAlignment.Right)
    {
      ControlGeometry.drawGeometry(new RectangleF(0.0f, 0.0f, (float) (this.Width - this.ItemSize.Height - 1), (float) (this.Height - 1)), this.Geometry, this.Display, RoundRectangleType.RoundRectAll, ref graphics);
      for (int index = 0; index <= this.TabCount - 1; ++index)
      {
        bool flag = true;
        if (index <= this.TabPageVisible.Count - 1)
          flag = this.TabPageVisible[index];
        if (flag)
        {
          Rectangle tabRect = this.GetTabRect(index);
          if (index == this.SelectedIndex)
          {
            RoundRectangleType RoundRectangleType = RoundRectangleType.RoundRectNone;
            if (index == 0)
              RoundRectangleType = RoundRectangleType.RoundRectRightUp;
            if (index == this.TabCount - 1)
              RoundRectangleType = RoundRectangleType.RoundRectRightDown;
            RectangleF rect = new RectangleF((float) tabRect.X, (float) (tabRect.Y - 2), (float) tabRect.Width, (float) tabRect.Height);
            ControlGeometry.drawGeometry(rect, this.Geometry, this.Tabs.HeaderSelected, RoundRectangleType, ref graphics);
            try
            {
              graphics.TranslateTransform(rect.X + rect.Width / 2f, rect.Y + rect.Height / 2f);
              graphics.RotateTransform(90f);
              graphics.DrawString(this.TabPages[index].Text, this.Tabs.HeaderSelected.Fonts.Font, (Brush) new SolidBrush(this.Tabs.HeaderSelected.Fonts.ForeColor), 0.0f, 0.0f, ControlGeometry.AlignmentToStringFormat(this.Tabs.HeaderSelected.Fonts.Alignment));
              graphics.ResetTransform();
              this.TabPages[index].BackColor = this.Tabs.TabPageColor;
            }
            catch
            {
            }
          }
          else
          {
            RoundRectangleType RoundRectangleType = RoundRectangleType.RoundRectNone;
            if (index == 0)
              RoundRectangleType = RoundRectangleType.RoundRectRightUp;
            if (index == this.TabCount - 1)
              RoundRectangleType = RoundRectangleType.RoundRectRightDown;
            RectangleF rect = new RectangleF((float) (tabRect.X + this.Tabs.HeaderXOffset), (float) (tabRect.Y - 2), (float) tabRect.Width, (float) tabRect.Height);
            ControlGeometry.drawGeometry(rect, this.Geometry.ArcDiameter, this.Geometry.ShapeMode, this.Tabs.Header, RoundRectangleType, ref graphics);
            try
            {
              graphics.TranslateTransform(rect.X + rect.Width / 2f, rect.Y + rect.Height / 2f);
              graphics.RotateTransform(90f);
              graphics.DrawString(this.TabPages[index].Text, this.Tabs.Header.Fonts.Font, (Brush) new SolidBrush(this.Tabs.Header.Fonts.ForeColor), 0.0f, 0.0f, ControlGeometry.AlignmentToStringFormat(this.Tabs.Header.Fonts.Alignment));
              graphics.ResetTransform();
              this.TabPages[index].BackColor = this.Tabs.TabPageColor;
            }
            catch
            {
            }
          }
        }
      }
    }
    else if (this.Alignment == TabAlignment.Left)
    {
      RectangleF rect1;
      ref RectangleF local = ref rect1;
      Size itemSize = this.ItemSize;
      double height1 = (double) itemSize.Height;
      int width1 = this.Width;
      itemSize = this.ItemSize;
      int height2 = itemSize.Height;
      double width2 = (double) (width1 - height2 - 1);
      double height3 = (double) (this.Height - 1);
      local = new RectangleF((float) height1, 0.0f, (float) width2, (float) height3);
      ControlGeometry.drawGeometry(rect1, this.Geometry, this.Display, RoundRectangleType.RoundRectAll, ref graphics);
      for (int index = 0; index <= this.TabCount - 1; ++index)
      {
        bool flag = true;
        if (index <= this.TabPageVisible.Count - 1)
          flag = this.TabPageVisible[index];
        if (flag)
        {
          Rectangle tabRect = this.GetTabRect(index);
          if (index == this.SelectedIndex)
          {
            RoundRectangleType RoundRectangleType = RoundRectangleType.RoundRectNone;
            if (index == 0)
              RoundRectangleType = RoundRectangleType.RoundRectLeftUp;
            if (index == this.TabCount - 1)
              RoundRectangleType = RoundRectangleType.RoundRectLeftDown;
            RectangleF rect2 = new RectangleF((float) tabRect.X, (float) (tabRect.Y - 2), (float) tabRect.Width, (float) tabRect.Height);
            ControlGeometry.drawGeometry(rect2, this.Geometry, this.Tabs.HeaderSelected, RoundRectangleType, ref graphics);
            try
            {
              graphics.TranslateTransform(rect2.X + rect2.Width / 2f, rect2.Y + rect2.Height / 2f);
              graphics.RotateTransform(-90f);
              graphics.DrawString(this.TabPages[index].Text, this.Tabs.HeaderSelected.Fonts.Font, (Brush) new SolidBrush(this.Tabs.HeaderSelected.Fonts.ForeColor), 0.0f, 0.0f, ControlGeometry.AlignmentToStringFormat(this.Tabs.HeaderSelected.Fonts.Alignment));
              graphics.ResetTransform();
              this.TabPages[index].BackColor = this.Tabs.TabPageColor;
            }
            catch
            {
            }
          }
          else
          {
            RoundRectangleType RoundRectangleType = RoundRectangleType.RoundRectNone;
            if (index == 0)
              RoundRectangleType = RoundRectangleType.RoundRectLeftUp;
            if (index == this.TabCount - 1)
              RoundRectangleType = RoundRectangleType.RoundRectLeftDown;
            RectangleF rect3 = new RectangleF((float) (tabRect.X + this.Tabs.HeaderXOffset), (float) (tabRect.Y - 2), (float) tabRect.Width, (float) tabRect.Height);
            ControlGeometry.drawGeometry(rect3, this.Geometry.ArcDiameter, this.Geometry.ShapeMode, this.Tabs.Header, RoundRectangleType, ref graphics);
            try
            {
              graphics.TranslateTransform(rect3.X + rect3.Width / 2f, rect3.Y + rect3.Height / 2f);
              graphics.RotateTransform(-90f);
              graphics.DrawString(this.TabPages[index].Text, this.Tabs.Header.Fonts.Font, (Brush) new SolidBrush(this.Tabs.Header.Fonts.ForeColor), 0.0f, 0.0f, ControlGeometry.AlignmentToStringFormat(this.Tabs.Header.Fonts.Alignment));
              graphics.ResetTransform();
              this.TabPages[index].BackColor = this.Tabs.TabPageColor;
            }
            catch
            {
            }
          }
        }
      }
    }
    else if (this.Alignment == TabAlignment.Bottom)
    {
      ControlGeometry.drawGeometry(new RectangleF(0.0f, 0.0f, (float) (this.Width - 1), (float) (this.Height - this.ItemSize.Height - 2)), this.Geometry, this.Display, RoundRectangleType.RoundRectAll, ref graphics);
      for (int index = 0; index <= this.TabCount - 1; ++index)
      {
        bool flag = true;
        if (index <= this.TabPageVisible.Count - 1)
          flag = this.TabPageVisible[index];
        if (flag)
        {
          Rectangle tabRect = this.GetTabRect(index);
          if (index == this.SelectedIndex)
          {
            RoundRectangleType RoundRectangleType = RoundRectangleType.RoundRectNone;
            if (index == 0)
              RoundRectangleType = RoundRectangleType.RoundRectLeftDown;
            if (index == this.TabCount - 1)
              RoundRectangleType = RoundRectangleType.RoundRectRightDown;
            RectangleF rect = new RectangleF((float) tabRect.X, (float) (tabRect.Y - 2), (float) tabRect.Width, (float) tabRect.Height);
            ControlGeometry.drawGeometry(rect, this.Geometry, this.Tabs.HeaderSelected, RoundRectangleType, ref graphics);
            try
            {
              graphics.TranslateTransform(rect.X + rect.Width / 2f, rect.Y + rect.Height / 2f);
              graphics.RotateTransform(0.0f);
              graphics.DrawString(this.TabPages[index].Text, this.Tabs.HeaderSelected.Fonts.Font, (Brush) new SolidBrush(this.Tabs.HeaderSelected.Fonts.ForeColor), 0.0f, 0.0f, ControlGeometry.AlignmentToStringFormat(this.Tabs.HeaderSelected.Fonts.Alignment));
              graphics.ResetTransform();
              this.TabPages[index].BackColor = this.Tabs.TabPageColor;
            }
            catch
            {
            }
          }
          else
          {
            RoundRectangleType RoundRectangleType = RoundRectangleType.RoundRectNone;
            if (index == 0)
              RoundRectangleType = RoundRectangleType.RoundRectLeftDown;
            if (index == this.TabCount - 1)
              RoundRectangleType = RoundRectangleType.RoundRectRightDown;
            RectangleF rect = new RectangleF((float) (tabRect.X + this.Tabs.HeaderXOffset), (float) (tabRect.Y - 2), (float) tabRect.Width, (float) tabRect.Height);
            ControlGeometry.drawGeometry(rect, this.Geometry.ArcDiameter, this.Geometry.ShapeMode, this.Tabs.Header, RoundRectangleType, ref graphics);
            try
            {
              graphics.TranslateTransform(rect.X + rect.Width / 2f, rect.Y + rect.Height / 2f);
              graphics.RotateTransform(0.0f);
              graphics.DrawString(this.TabPages[index].Text, this.Tabs.Header.Fonts.Font, (Brush) new SolidBrush(this.Tabs.Header.Fonts.ForeColor), 0.0f, 0.0f, ControlGeometry.AlignmentToStringFormat(this.Tabs.Header.Fonts.Alignment));
              graphics.ResetTransform();
              this.TabPages[index].BackColor = this.Tabs.TabPageColor;
            }
            catch
            {
            }
          }
        }
      }
    }
    this.themeType_0 = this.Theme.Type;
    base.OnPaint(e);
  }

  public void PropertiesValueChanged() => this.Invalidate();
}
