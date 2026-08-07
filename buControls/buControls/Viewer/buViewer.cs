// Decompiled with JetBrains decompiler
// Type: buControls.Viewer.buViewer
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Viewer;

public class buViewer : UserControl
{
  private static string string_0 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";
  private static string string_1 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";
  private static string string_2 = "";
  private static string string_3 = "";
  private static double double_0 = 0.0;
  private static double double_1 = 0.0;
  public Bitmap Bmp = (Bitmap) null;
  private bool bool_0 = false;
  public List<eEntities> Entities = new List<eEntities>();
  public List<eEntities> CamEntities = new List<eEntities>();
  public List<eEntities> MaterialEntities = new List<eEntities>();
  public List<eEntities> DimensionEntities = new List<eEntities>();
  public List<eEntities> ArrowEntities = new List<eEntities>();
  public List<Pnt3D> RunTimeDrawingPoints = new List<Pnt3D>();
  public List<eText> Texts = new List<eText>();
  public Image BackImage = (Image) null;
  public ProjectionModeType viewProjectionMode = ProjectionModeType.Orthographic;
  public Camera viewCamera = new Camera();
  public AngleVector viewAngle = new AngleVector(0.0, 0.0, 0.0);
  public Pnt3D viewRotateCenter = new Pnt3D();
  public bool ShowMouseCoordinateOnScreen = false;
  public bool ShowContentMenu = false;
  public ContentAlignment TextsAlignment = ContentAlignment.MiddleCenter;
  public bool TextDynamicalHeight = true;
  public int ExecutedLineIndex = -1;
  public double ScreenWidth = 100.0;
  public double ScreenHeight = 100.0;
  public double ScreenTop = 100.0;
  public double ScreenLeft = 0.0;
  public int ClientWidth = 0;
  public int ClientHeight = 0;
  public Image ImageDraw = (Image) null;
  public Color ExecutedEntityColor = Color.DarkOrange;
  public Color SelectedEntityColor = Color.Yellow;
  public Color CamEntitiesColor = Color.Red;
  public Color RuntimeDrawingColor = Color.LimeGreen;
  public double SelectedEntityThickness = 1.0;
  public bool MirrorDraw = false;
  public bool Only2D = true;
  public bool DisableMouseWheel = false;
  public double ViewLeft = 0.0;
  public double ViewRight = 0.0;
  public double ViewTop = 0.0;
  public double ViewBottom = 0.0;
  public BoxSize BoxSizeOfEntities = new BoxSize();
  public double AspectRatio = 1.0;
  public Pnt3D ScreenCoordinate = new Pnt3D();
  public SimulationTool SimTool = new SimulationTool();
  private bool bool_1 = false;
  private Pnt3D pnt3D_0 = new Pnt3D();
  private Color color_0 = Color.WhiteSmoke;
  private Pnt3D pnt3D_1 = new Pnt3D(1.0, 1.0, 1.0);
  internal IContainer icontainer_0 = (IContainer) null;
  internal PictureBox pictureBox_0;
  internal ContextMenuStrip contextMenuStrip_0;
  internal ToolStripMenuItem toolStripMenuItem_0;

  public buViewer()
  {
    Class39.smethod_811(this);
    this.pictureBox_0.MouseWheel += new MouseEventHandler(this.pictureBox_0_MouseWheel);
  }

  public event EventHandler Selected;

  public event EventHandler DoubleClickSelect;

  public event buMouseMoveEventHandler MouseMovePosition;

  public event buMouseMoveEventHandler MouseDownPosition;

  public event buMouseMoveEventHandler MouseUpPosition;

  [DefaultValue(typeof (Color), "WhiteSmoke")]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public override Color BackColor
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      this.DrawEntities();
      this.Invalidate();
    }
  }

  internal void method_0(object sender, EventArgs e)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, e);
    }
    catch (Exception ex)
    {
    }
  }

  internal void method_1(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_1((object) this, e);
  }

  private void pictureBox_0_MouseWheel(object sender, MouseEventArgs e)
  {
    if (this.DisableMouseWheel)
      return;
    if (e.Delta > 0)
      this.ZoomIn();
    else
      this.ZoomOut();
  }

  internal void method_2(object sender, MouseEventArgs e)
  {
    if (e.Button == MouseButtons.Left)
    {
      this.bool_1 = true;
      this.pnt3D_0 = new Pnt3D(this.PTUx(e.X), this.PTUy(e.Y));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.buMouseMoveEventHandler_1 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.buMouseMoveEventHandler_1((object) this, e, this.pnt3D_0);
    }
    this.pictureBox_0.Focus();
  }

  internal void method_3(object sender, MouseEventArgs e)
  {
    Pnt3D pnt3D = new Pnt3D(this.PTUx(e.X), this.PTUy(e.Y));
    this.ScreenCoordinate = new Pnt3D(this.PTUx(e.X), this.PTUy(e.Y));
    this.ScreenCoordinate.X -= this.viewRotateCenter.X;
    this.ScreenCoordinate.Y -= this.viewRotateCenter.Y;
    if (this.bool_1)
      this.Pan(this.pnt3D_0.X - pnt3D.X, this.pnt3D_0.Y - pnt3D.Y);
    // ISSUE: reference to a compiler-generated field
    if (this.buMouseMoveEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.buMouseMoveEventHandler_0((object) this, e, this.pnt3D_0);
    }
    if (!this.ShowMouseCoordinateOnScreen)
      return;
    this.Redraw();
  }

  internal void method_4(object sender, MouseEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.buMouseMoveEventHandler_2 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.buMouseMoveEventHandler_2((object) this, e, this.pnt3D_0);
    }
    this.bool_1 = false;
  }

  internal void method_5(object sender, EventArgs e)
  {
    if (!this.pictureBox_0.Focused)
      ;
  }

  public void Init()
  {
    if (!buControlCommands.smethod_0("buViewerBrooOpen"))
      throw new RegisterException(nameof (buViewer));
    this.Bmp = new Bitmap(this.pictureBox_0.Width, this.pictureBox_0.Height);
    this.bool_0 = true;
  }

  public void Redraw()
  {
    try
    {
      this.ScreenHeight = this.ViewTop - this.ViewBottom;
      this.ScreenWidth = this.ViewRight - this.ViewLeft;
      this.ScreenLeft = this.ViewLeft;
      this.ScreenTop = this.ViewTop;
      this.DrawEntities();
      this.ImageDraw = this.pictureBox_0.Image;
    }
    catch (Exception ex)
    {
    }
  }

  public void ZoomFit()
  {
    try
    {
      if (this.Entities.Count == 0 & this.MaterialEntities.Count == 0 & this.DimensionEntities.Count == 0 & this.ArrowEntities.Count == 0)
        return;
      this.AspectRatio = Convert.ToDouble(this.pictureBox_0.Width) / Convert.ToDouble(this.pictureBox_0.Height);
      if (this.BoxSizeOfEntities.Delta.Y > this.BoxSizeOfEntities.Delta.X)
      {
        if ((this.BoxSizeOfEntities.MaxPoint.X - this.BoxSizeOfEntities.MinPoint.X) * 1.0 / (this.BoxSizeOfEntities.MaxPoint.Y - this.BoxSizeOfEntities.MinPoint.Y) >= 1.0)
        {
          this.ViewRight = this.BoxSizeOfEntities.MaxPoint.X + this.BoxSizeOfEntities.Delta.X * 0.01;
          this.ViewLeft = this.BoxSizeOfEntities.MinPoint.X - this.BoxSizeOfEntities.Delta.X * 0.01;
          double num = ((this.ViewRight - this.ViewLeft) / this.AspectRatio - (this.BoxSizeOfEntities.MaxPoint.Y - this.BoxSizeOfEntities.MinPoint.Y)) / 2.0;
          this.ViewTop = this.BoxSizeOfEntities.MaxPoint.Y + num;
          this.ViewBottom = this.BoxSizeOfEntities.MinPoint.Y - num;
        }
        else
        {
          this.ViewBottom = this.BoxSizeOfEntities.MinPoint.Y - this.BoxSizeOfEntities.Delta.Y * 0.01;
          this.ViewTop = this.BoxSizeOfEntities.MaxPoint.Y + this.BoxSizeOfEntities.Delta.Y * 0.01;
          double num = (this.ViewTop - this.ViewBottom) * this.AspectRatio;
          this.ViewLeft = this.BoxSizeOfEntities.MinPoint.X - (num - (this.BoxSizeOfEntities.MaxPoint.X - this.BoxSizeOfEntities.MinPoint.X)) / 2.0;
          this.ViewRight = this.ViewLeft + num;
        }
      }
      else if (this.BoxSizeOfEntities.Delta.X / this.BoxSizeOfEntities.Delta.Y / this.AspectRatio >= 1.0)
      {
        this.ViewRight = this.BoxSizeOfEntities.MinPoint.X + this.BoxSizeOfEntities.Delta.X + 5.0;
        this.ViewLeft = this.BoxSizeOfEntities.MinPoint.X - 5.0;
        this.ViewTop = (this.ViewRight - this.ViewLeft) / this.AspectRatio;
        this.ViewBottom = 0.0;
        double num1 = (this.BoxSizeOfEntities.MinPoint.Y + this.BoxSizeOfEntities.MaxPoint.Y) / 2.0;
        double num2 = (this.ViewTop - this.ViewBottom) / 2.0;
        this.ViewTop += num1 - num2;
        this.ViewBottom += num1 - num2;
      }
      else
      {
        this.ViewBottom = this.BoxSizeOfEntities.MinPoint.Y - this.BoxSizeOfEntities.Delta.Y * 0.01;
        this.ViewTop = this.BoxSizeOfEntities.MinPoint.Y + this.BoxSizeOfEntities.Delta.Y + this.BoxSizeOfEntities.Delta.Y * 0.01;
        double num = (this.ViewTop - this.ViewBottom) * this.AspectRatio;
        this.ViewLeft = this.BoxSizeOfEntities.MinPoint.X - (num - (this.BoxSizeOfEntities.Delta.X - 0.0)) / 2.0;
        this.ViewRight = this.ViewLeft + num;
      }
      this.Redraw();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void ZoomOut()
  {
    try
    {
      double num1 = (this.ViewRight - this.ViewLeft) * 0.10000000149011612;
      this.ViewRight += num1;
      this.ViewLeft -= num1;
      double num2 = (this.ViewRight - this.ViewLeft) / this.AspectRatio / 2.0;
      double num3 = this.ViewBottom + (this.ViewTop - this.ViewBottom) / 2.0;
      this.ViewTop = num3 + num2;
      this.ViewBottom = num3 - num2;
      this.Redraw();
    }
    catch (Exception ex)
    {
    }
  }

  public void ZoomIn()
  {
    try
    {
      double num1 = (this.ViewRight - this.ViewLeft) * 0.10000000149011612;
      this.ViewRight -= num1;
      this.ViewLeft += num1;
      double num2 = (this.ViewRight - this.ViewLeft) / this.AspectRatio / 2.0;
      double num3 = this.ViewBottom + (this.ViewTop - this.ViewBottom) / 2.0;
      this.ViewTop = num3 + num2;
      this.ViewBottom = num3 - num2;
      this.Redraw();
    }
    catch (Exception ex)
    {
    }
  }

  public void Pan(double X, double Y)
  {
    this.ViewRight += X;
    this.ViewLeft += X;
    this.ViewTop += Y;
    this.ViewBottom += Y;
    this.Redraw();
  }

  public void setView(ViewportViewType type)
  {
    if (type == ViewportViewType.Top)
    {
      this.viewAngle.X = 180.0;
      this.viewAngle.Y = 180.0;
      this.viewAngle.Z = 0.0;
    }
    if (type == ViewportViewType.Bottom)
    {
      this.viewAngle.X = 180.0;
      this.viewAngle.Y = 0.0;
      this.viewAngle.Z = 0.0;
    }
    if (type == ViewportViewType.Front)
    {
      this.viewAngle.X = 90.0;
      this.viewAngle.Y = 0.0;
      this.viewAngle.Z = 0.0;
    }
    if (type == ViewportViewType.Back)
    {
      this.viewAngle.X = -90.0;
      this.viewAngle.Y = 0.0;
      this.viewAngle.Z = 0.0;
    }
    if (type == ViewportViewType.Left)
    {
      this.viewAngle.X = 90.0;
      this.viewAngle.Y = 90.0;
      this.viewAngle.Z = 0.0;
    }
    if (type == ViewportViewType.Right)
    {
      this.viewAngle.X = 90.0;
      this.viewAngle.Y = -90.0;
      this.viewAngle.Z = 0.0;
    }
    if (type == ViewportViewType.Isometric)
    {
      this.viewAngle.X = 225.0;
      this.viewAngle.Y = 225.0;
      this.viewAngle.Z = 20.0;
    }
    this.DrawEntities();
  }

  public void DrawEntities()
  {
    try
    {
      if (!this.bool_0)
        this.Init();
      this.contextMenuStrip_0.Enabled = this.ShowContentMenu;
      this.ClientHeight = this.pictureBox_0.Height;
      this.ClientWidth = this.pictureBox_0.Width;
      List<eEntities> Entities1 = new List<eEntities>();
      List<eEntities> Entities2 = new List<eEntities>();
      List<eEntities> Entities3 = new List<eEntities>();
      double num1 = 1.0;
      if (this.MirrorDraw)
      {
        eEntities.CopyEntities(this.Entities, ref Entities1);
        buControlCoreClass.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref Entities1);
        buGeneral.CopyLists(this.DimensionEntities, ref Entities2);
        buControlCoreClass.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref Entities2);
        buGeneral.CopyLists(this.ArrowEntities, ref Entities3);
        buControlCoreClass.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref Entities3);
        num1 = -1.0;
      }
      else
      {
        eEntities.CopyEntities(this.Entities, ref Entities1);
        buGeneral.CopyLists(this.DimensionEntities, ref Entities2);
        buGeneral.CopyLists(this.ArrowEntities, ref Entities3);
      }
      if (this.pictureBox_0.Width == 0 | this.pictureBox_0.Height == 0)
      {
        Entities1.Clear();
      }
      else
      {
        if (this.BackImage != null)
        {
          this.Bmp = new Bitmap(this.BackImage);
          this.pictureBox_0.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        Graphics graphics = Graphics.FromImage((Image) this.Bmp);
        if (this.BackImage == null)
          graphics.Clear(this.BackColor);
        Color color1 = new Color();
        Pnt3D MinPoint1 = new Pnt3D();
        Pnt3D MaxPoint1 = new Pnt3D();
        Pnt3D MinPoint2 = new Pnt3D();
        Pnt3D MaxPoint2 = new Pnt3D();
        List<Pnt3D> Points = new List<Pnt3D>();
        if (Entities1.Count > 0)
        {
          buControlCoreClass.cVector.BoxSizeCalculate(Entities1, ref MinPoint1, ref MaxPoint1);
          Points.Add(MinPoint1);
          Points.Add(MaxPoint1);
        }
        if (Entities2.Count > 0)
        {
          buControlCoreClass.cVector.BoxSizeCalculate(Entities2, ref MinPoint1, ref MaxPoint1);
          Points.Add(MinPoint1);
          Points.Add(MaxPoint1);
        }
        if (Entities3.Count > 0)
        {
          buControlCoreClass.cVector.BoxSizeCalculate(Entities3, ref MinPoint1, ref MaxPoint1);
          Points.Add(MinPoint1);
          Points.Add(MaxPoint1);
        }
        if (this.MaterialEntities.Count > 0)
        {
          buControlCoreClass.cVector.BoxSizeCalculate(this.MaterialEntities, ref MinPoint1, ref MaxPoint1);
          Points.Add(MinPoint1);
          Points.Add(MaxPoint1);
        }
        buControlCoreClass.cVector.BoxSizeCalculate(Points, ref MinPoint2, ref MaxPoint2);
        this.BoxSizeOfEntities = new BoxSize(MinPoint2, MaxPoint2);
        this.BoxSizeOfEntities.Delta = new Vec3D(MaxPoint2.X - MinPoint2.X, MaxPoint2.Y - MinPoint2.Y, MaxPoint2.Z - MinPoint2.Z);
        this.viewRotateCenter = new Pnt3D();
        if (!this.Only2D)
          this.viewRotateCenter = new Pnt3D(buControlCoreClass.cVector.MiddlePointOfLine(this.BoxSizeOfEntities.MaxPoint, this.BoxSizeOfEntities.MinPoint));
        this.pnt3D_1 = new Pnt3D(buControlCoreClass.cVector.MiddlePointOfLine(this.BoxSizeOfEntities.MaxPoint, this.BoxSizeOfEntities.MinPoint));
        this.viewCamera.Location = new Pnt3D(this.pnt3D_1);
        for (int index1 = 0; index1 <= this.MaterialEntities.Count - 1; ++index1)
        {
          if (this.MaterialEntities[index1].bVisible)
          {
            Color color2 = this.MaterialEntities[index1].dispColor;
            if (color2.A == (byte) 0 & color2.B == (byte) 0 & color2.G == (byte) 0 & color2.R == (byte) 0)
              color2 = Color.Black;
            float width = this.MaterialEntities[index1].dispThickness;
            if (this.MaterialEntities[index1].bSelected)
            {
              color2 = this.SelectedEntityColor;
              width = (float) this.SelectedEntityThickness;
            }
            for (int index2 = 1; index2 <= this.MaterialEntities[index1].Vertice.Count - 1; ++index2)
            {
              Pnt3D refPoint1 = new Pnt3D(this.MaterialEntities[index1].Vertice[index2 - 1]);
              Pnt3D refPoint2 = new Pnt3D(this.MaterialEntities[index1].Vertice[index2]);
              refPoint1.Z *= -1.0;
              refPoint2.Z *= -1.0;
              PointF pointF1 = new PointF();
              PointF pointF2 = new PointF();
              PointF pointF3 = this.ViewportUpdate(refPoint1);
              PointF pointF4 = this.ViewportUpdate(refPoint2);
              graphics.DrawLine(new Pen(color2, width), this.UTPx((double) pointF3.X), this.UTPy((double) pointF3.Y), this.UTPx((double) pointF4.X), this.UTPy((double) pointF4.Y));
            }
            if (this.MaterialEntities[index1].Vertice.Count == 1)
              graphics.DrawArc(new Pen(color2, width), this.UTPx(this.MaterialEntities[index1].Vertice[0].X), this.UTPy(this.MaterialEntities[index1].Vertice[0].Y), 2, 2, 0, 360);
          }
        }
        Color color3;
        for (int index3 = 0; index3 <= Entities1.Count - 1; ++index3)
        {
          if (Entities1[index3] != null && Entities1[index3].bVisible)
          {
            color3 = Entities1[index3].dispColor;
            if (color3.A == (byte) 0 & color3.B == (byte) 0 & color3.G == (byte) 0 & color3.R == (byte) 0)
              color3 = Color.Black;
            float width = Entities1[index3].dispThickness;
            if (Entities1[index3].bSelected)
            {
              color3 = this.SelectedEntityColor;
              width = (float) this.SelectedEntityThickness;
            }
            if (this.ExecutedLineIndex >= 1 & index3 <= this.ExecutedLineIndex)
              color3 = this.ExecutedEntityColor;
            for (int index4 = 1; index4 <= Entities1[index3].Vertice.Count - 1; ++index4)
            {
              Pnt3D refPoint3 = new Pnt3D(Entities1[index3].Vertice[index4 - 1]);
              Pnt3D refPoint4 = new Pnt3D(Entities1[index3].Vertice[index4]);
              refPoint3.Z *= -1.0;
              refPoint4.Z *= -1.0;
              PointF pointF5 = new PointF();
              PointF pointF6 = new PointF();
              pointF5 = this.ViewportUpdate(refPoint3);
              PointF pointF7 = this.ViewportUpdate(refPoint4);
              graphics.DrawLine(new Pen(color3, width), this.UTPx((double) pointF5.X), this.UTPy((double) pointF5.Y), this.UTPx((double) pointF7.X), this.UTPy((double) pointF7.Y));
            }
            if (Entities1[index3].Vertice.Count == 1)
              graphics.DrawArc(new Pen(color3, width), this.UTPx(Entities1[index3].Vertice[0].X), this.UTPy(Entities1[index3].Vertice[0].Y), 2, 2, 0, 360);
          }
        }
        if (this.RunTimeDrawingPoints.Count > 1)
        {
          for (int index = 1; index <= this.RunTimeDrawingPoints.Count - 1; ++index)
          {
            color3 = this.RuntimeDrawingColor;
            if (color3.A == (byte) 0 & color3.B == (byte) 0 & color3.G == (byte) 0 & color3.R == (byte) 0)
              color3 = Color.Black;
            float width = 1f;
            Pnt3D refPoint5 = new Pnt3D(this.RunTimeDrawingPoints[index - 1]);
            Pnt3D refPoint6 = new Pnt3D(this.RunTimeDrawingPoints[index]);
            refPoint5.Z *= -1.0;
            refPoint6.Z *= -1.0;
            PointF pointF8 = new PointF();
            PointF pointF9 = new PointF();
            PointF pointF10 = this.ViewportUpdate(refPoint5);
            PointF pointF11 = this.ViewportUpdate(refPoint6);
            graphics.DrawLine(new Pen(color3, width), this.UTPx((double) pointF10.X), this.UTPy((double) pointF10.Y), this.UTPx((double) pointF11.X), this.UTPy((double) pointF11.Y));
          }
        }
        if (this.ShowMouseCoordinateOnScreen)
          graphics.DrawString($"X: {this.ScreenCoordinate.X.ToString("f2")} , Y: {this.ScreenCoordinate.Y.ToString("f2")}", new Font("Arial", 8f), (Brush) new SolidBrush(Color.Black), new PointF(10f, 10f));
        for (int index5 = 0; index5 <= this.CamEntities.Count - 1; ++index5)
        {
          if (this.CamEntities[index5].bVisible)
          {
            color3 = this.CamEntities[index5].dispColor;
            color3 = this.CamEntitiesColor;
            if (color3.A == (byte) 0 & color3.B == (byte) 0 & color3.G == (byte) 0 & color3.R == (byte) 0)
              color3 = Color.Black;
            float width = this.CamEntities[index5].dispThickness + 2f;
            if (this.CamEntities[index5].bSelected)
            {
              color3 = this.SelectedEntityColor;
              width = (float) this.SelectedEntityThickness;
            }
            for (int index6 = 1; index6 <= this.CamEntities[index5].Vertice.Count - 1; ++index6)
            {
              Pnt3D refPoint7 = new Pnt3D(this.CamEntities[index5].Vertice[index6 - 1]);
              Pnt3D refPoint8 = new Pnt3D(this.CamEntities[index5].Vertice[index6]);
              PointF pointF12 = new PointF();
              PointF pointF13 = new PointF();
              pointF12 = this.ViewportUpdate(refPoint7);
              pointF13 = this.ViewportUpdate(refPoint8);
              graphics.DrawLine(new Pen(color3, width), this.UTPx((double) pointF12.X), this.UTPy((double) pointF12.Y), this.UTPx((double) pointF13.X), this.UTPy((double) pointF13.Y));
            }
            if (this.CamEntities[index5].Vertice.Count == 1)
              ;
          }
        }
        if (this.viewAngle.X == 0.0 & this.viewAngle.Y == 0.0 & this.viewAngle.Z == 0.0)
        {
          for (int index7 = 0; index7 <= Entities2.Count - 1; ++index7)
          {
            color3 = Entities2[index7].dispColor;
            if (color3.A == (byte) 0 & color3.B == (byte) 0 & color3.G == (byte) 0 & color3.R == (byte) 0)
              color3 = Color.Black;
            float dispThickness = Entities2[index7].dispThickness;
            for (int index8 = 1; index8 <= Entities2[index7].Vertice.Count - 1; ++index8)
            {
              Pnt3D refPoint9 = new Pnt3D(Entities2[index7].Vertice[index8 - 1]);
              Pnt3D refPoint10 = new Pnt3D(Entities2[index7].Vertice[index8]);
              PointF pointF14 = new PointF();
              PointF pointF15 = new PointF();
              PointF pointF16 = this.ViewportUpdate(refPoint9);
              PointF pointF17 = this.ViewportUpdate(refPoint10);
              graphics.DrawLine(new Pen(color3, dispThickness), this.UTPx((double) pointF16.X), this.UTPy((double) pointF16.Y), this.UTPx((double) pointF17.X), this.UTPy((double) pointF17.Y));
            }
            Pnt3D pnt3D = buControlCoreClass.cVector.MiddlePointOfLine(Entities2[index7].Vertice[0], Entities2[index7].Vertice[1]);
            graphics.DrawString(Entities2[index7].auxText, new Font("Arial", 12f), (Brush) new SolidBrush(color3), new PointF((float) this.UTPx(pnt3D.X), (float) this.UTPy(pnt3D.Y)));
            List<Pnt3D> TriangleVertice1 = new List<Pnt3D>();
            double TriangleLength = this.BoxSizeOfEntities.Delta.X * 0.05000000074505806;
            if (TriangleLength < 5.0)
              TriangleLength = 5.0;
            double num2 = buControlCoreClass.cVector.Length3D(Entities2[index7].Vertice[0], Entities2[index7].Vertice[1]);
            bool Reverse1 = false;
            if (num2 < 100.0)
              Reverse1 = true;
            buControlCoreClass.cVector.TriangleAtPointByLineRef(Entities2[index7].Vertice[0], Entities2[index7].Vertice[1], 10.0, TriangleLength, new WorkPlane(), Reverse1, false, ref TriangleVertice1);
            Point[] points1 = new Point[TriangleVertice1.Count];
            for (int index9 = 0; index9 <= TriangleVertice1.Count - 1; ++index9)
            {
              Pnt3D refPoint = new Pnt3D(TriangleVertice1[index9]);
              PointF pointF18 = new PointF();
              PointF pointF19 = this.ViewportUpdate(refPoint);
              points1[index9] = new Point(this.UTPx((double) pointF19.X), this.UTPy((double) pointF19.Y));
            }
            graphics.FillPolygon((Brush) new SolidBrush(color3), points1);
            List<Pnt3D> TriangleVertice2 = new List<Pnt3D>();
            double num3 = buControlCoreClass.cVector.Length3D(Entities2[index7].Vertice[0], Entities2[index7].Vertice[1]);
            bool Reverse2 = false;
            if (num3 < 100.0)
              Reverse2 = true;
            buControlCoreClass.cVector.TriangleAtPointByLineRef(Entities2[index7].Vertice[1], Entities2[index7].Vertice[0], 10.0, TriangleLength, new WorkPlane(), Reverse2, false, ref TriangleVertice2);
            Point[] points2 = new Point[TriangleVertice2.Count];
            for (int index10 = 0; index10 <= TriangleVertice2.Count - 1; ++index10)
            {
              Pnt3D refPoint = new Pnt3D(TriangleVertice2[index10]);
              PointF pointF20 = new PointF();
              PointF pointF21 = this.ViewportUpdate(refPoint);
              points2[index10] = new Point(this.UTPx((double) pointF21.X), this.UTPy((double) pointF21.Y));
            }
            graphics.FillPolygon((Brush) new SolidBrush(color3), points2);
          }
          for (int index = 0; index <= this.Texts.Count - 1; ++index)
          {
            color3 = this.Texts[index].dispColor;
            if (color3.A == (byte) 0 & color3.B == (byte) 0 & color3.G == (byte) 0 & color3.R == (byte) 0)
              color3 = Color.Black;
            double num4 = (double) this.pictureBox_0.Width / 2.0;
            double num5 = (double) this.pictureBox_0.Height / 2.0;
            graphics.ResetTransform();
            SizeF sizeF = new SizeF();
            sizeF = graphics.MeasureString(this.Texts[index].TextString, this.Texts[index].TextFont);
            float num6 = sizeF.Width / 2f;
            float num7 = sizeF.Height / 2f;
            if (this.TextsAlignment == ContentAlignment.BottomLeft | this.TextsAlignment == ContentAlignment.MiddleLeft | this.TextsAlignment == ContentAlignment.TopLeft)
              num6 = 0.0f;
            if (this.Texts[index].Angle != 0.0)
            {
              num6 = sizeF.Height / 2f;
              num7 = sizeF.Width / -2f;
            }
            graphics.TranslateTransform((float) this.UTPx(this.Texts[index].StartPoint.X * num1) - num6, (float) this.UTPy(this.Texts[index].StartPoint.Y) - num7);
            graphics.RotateTransform((float) this.Texts[index].Angle * (float) num1);
            graphics.DrawString(this.Texts[index].TextString, this.Texts[index].TextFont, (Brush) new SolidBrush(color3), new PointF(0.0f, 0.0f));
          }
          if (this.Text.Length > 0)
            graphics.DrawString(this.Text, this.Font, (Brush) new SolidBrush(this.ForeColor), new PointF(1f, 1f));
        }
        if (this.viewAngle.X == 0.0 & this.viewAngle.Y == 0.0 & this.viewAngle.Z == 0.0)
        {
          for (int index11 = 0; index11 <= Entities3.Count - 1; ++index11)
          {
            color3 = Entities3[index11].dispColor;
            if (color3.A == (byte) 0 & color3.B == (byte) 0 & color3.G == (byte) 0 & color3.R == (byte) 0)
              color3 = Color.Black;
            float dispThickness = Entities3[index11].dispThickness;
            for (int index12 = 1; index12 <= Entities3[index11].Vertice.Count - 1; ++index12)
            {
              Pnt3D refPoint11 = new Pnt3D(Entities3[index11].Vertice[index12 - 1]);
              Pnt3D refPoint12 = new Pnt3D(Entities3[index11].Vertice[index12]);
              PointF pointF22 = new PointF();
              PointF pointF23 = new PointF();
              PointF pointF24 = this.ViewportUpdate(refPoint11);
              PointF pointF25 = this.ViewportUpdate(refPoint12);
              graphics.DrawLine(new Pen(color3, dispThickness), this.UTPx((double) pointF24.X), this.UTPy((double) pointF24.Y), this.UTPx((double) pointF25.X), this.UTPy((double) pointF25.Y));
            }
            buControlCoreClass.cVector.MiddlePointOfLine(Entities3[index11].Vertice[0], Entities3[index11].Vertice[1]);
            if (Entities3[index11].auxText == null || Entities3[index11].auxText.Length > 0)
              ;
            List<Pnt3D> pnt3DList = new List<Pnt3D>();
            double TriangleLength = this.BoxSizeOfEntities.Delta.X * 0.15 * ((this.ViewRight - this.ViewLeft) / 1000.0);
            if (TriangleLength < 5.0)
              TriangleLength = 5.0;
            List<Pnt3D> TriangleVertice = new List<Pnt3D>();
            buControlCoreClass.cVector.TriangleAtPointByLineRef(Entities3[index11].Vertice[1], Entities3[index11].Vertice[0], 10.0, TriangleLength, new WorkPlane(), false, false, ref TriangleVertice);
            Point[] points = new Point[TriangleVertice.Count];
            for (int index13 = 0; index13 <= TriangleVertice.Count - 1; ++index13)
            {
              Pnt3D refPoint = new Pnt3D(TriangleVertice[index13]);
              PointF pointF26 = new PointF();
              PointF pointF27 = this.ViewportUpdate(refPoint);
              points[index13] = new Point(this.UTPx((double) pointF27.X), this.UTPy((double) pointF27.Y));
            }
            graphics.FillPolygon((Brush) new SolidBrush(color3), points);
          }
        }
        if (this.SimTool.Visible & this.SimTool.Diameter > 0.0)
        {
          List<Pnt3D> pnt3DList1 = new List<Pnt3D>();
          List<Pnt3D> pnt3DList2 = new List<Pnt3D>();
          if (this.SimTool.Type == SimulationToolType.Milling)
          {
            buControlCoreClass.cVector.PolygonCenter(this.SimTool.Coordinate, this.SimTool.Diameter / 2.0, 16 /*0x10*/, new WorkPlane(), ref pnt3DList1);
            buControlCoreClass.cVector.PolygonCenter(new Pnt3D(this.SimTool.Coordinate.X, this.SimTool.Coordinate.Y, this.SimTool.Coordinate.Z + this.SimTool.Length), this.SimTool.Diameter / 2.0, 16 /*0x10*/, new WorkPlane(), ref pnt3DList2);
            Point[] points3 = new Point[pnt3DList1.Count];
            Point[] points4 = new Point[pnt3DList2.Count];
            for (int index = 0; index <= pnt3DList1.Count - 1; ++index)
            {
              Pnt3D refPoint = new Pnt3D(pnt3DList1[index]);
              refPoint.Z *= -1.0;
              PointF pointF28 = new PointF();
              PointF pointF29 = this.ViewportUpdate(refPoint);
              points3[index] = new Point(this.UTPx((double) pointF29.X), this.UTPy((double) pointF29.Y));
            }
            graphics.FillPolygon((Brush) new SolidBrush(this.SimTool.Color), points3);
            for (int index = 0; index <= pnt3DList2.Count - 1; ++index)
            {
              Pnt3D refPoint = new Pnt3D(pnt3DList2[index]);
              refPoint.Z *= -1.0;
              PointF pointF30 = new PointF();
              PointF pointF31 = this.ViewportUpdate(refPoint);
              points4[index] = new Point(this.UTPx((double) pointF31.X), this.UTPy((double) pointF31.Y));
            }
            graphics.FillPolygon((Brush) new SolidBrush(this.SimTool.Color), points4);
            for (int index = 1; index <= pnt3DList2.Count - 1; ++index)
            {
              Point[] points5 = new Point[4];
              Pnt3D refPoint13 = new Pnt3D(pnt3DList2[index - 1]);
              refPoint13.Z *= -1.0;
              PointF pointF = new PointF();
              pointF = this.ViewportUpdate(refPoint13);
              points5[0] = new Point(this.UTPx((double) pointF.X), this.UTPy((double) pointF.Y));
              Pnt3D refPoint14 = new Pnt3D(pnt3DList2[index]);
              refPoint14.Z *= -1.0;
              pointF = new PointF();
              pointF = this.ViewportUpdate(refPoint14);
              points5[1] = new Point(this.UTPx((double) pointF.X), this.UTPy((double) pointF.Y));
              Pnt3D refPoint15 = new Pnt3D(pnt3DList1[index]);
              refPoint15.Z *= -1.0;
              pointF = new PointF();
              pointF = this.ViewportUpdate(refPoint15);
              points5[2] = new Point(this.UTPx((double) pointF.X), this.UTPy((double) pointF.Y));
              Pnt3D refPoint16 = new Pnt3D(pnt3DList1[index - 1]);
              refPoint16.Z *= -1.0;
              pointF = new PointF();
              pointF = this.ViewportUpdate(refPoint16);
              points5[3] = new Point(this.UTPx((double) pointF.X), this.UTPy((double) pointF.Y));
              graphics.FillPolygon((Brush) new SolidBrush(this.SimTool.Color), points5);
            }
            graphics.DrawPolygon(new Pen(this.SimTool.BorderColor), points4);
            graphics.DrawPolygon(new Pen(this.SimTool.BorderColor), points3);
          }
          if (this.SimTool.Type == SimulationToolType.Saw)
          {
            if (this.SimTool.Orientation == LeftMiddleRightLocationType.Middle)
            {
              buControlCoreClass.cVector.PolygonCenter(new Pnt3D(this.SimTool.Coordinate.X, this.SimTool.Coordinate.Y - this.SimTool.Thickness / 2.0, this.SimTool.Coordinate.Z + this.SimTool.Diameter / 2.0), this.SimTool.Diameter / 2.0, 16 /*0x10*/, new WorkPlane(planeType.XZ, 1), ref pnt3DList1);
              buControlCoreClass.cVector.PolygonCenter(new Pnt3D(this.SimTool.Coordinate.X, this.SimTool.Coordinate.Y + this.SimTool.Thickness / 2.0, this.SimTool.Coordinate.Z + this.SimTool.Diameter / 2.0), this.SimTool.Diameter / 2.0, 16 /*0x10*/, new WorkPlane(planeType.XZ, 1), ref pnt3DList2);
              buControlCoreClass.cVector.Rotate(this.SimTool.Coordinate, this.SimTool.TangentAngle, new WorkPlane(), ref pnt3DList1);
              buControlCoreClass.cVector.Rotate(this.SimTool.Coordinate, this.SimTool.TangentAngle, new WorkPlane(), ref pnt3DList2);
            }
            if (this.SimTool.Orientation == LeftMiddleRightLocationType.Left)
            {
              buControlCoreClass.cVector.PolygonCenter(new Pnt3D(this.SimTool.Coordinate.X, this.SimTool.Coordinate.Y, this.SimTool.Coordinate.Z + this.SimTool.Diameter / 2.0), this.SimTool.Diameter / 2.0, 16 /*0x10*/, new WorkPlane(planeType.XZ, 1), ref pnt3DList1);
              buControlCoreClass.cVector.PolygonCenter(new Pnt3D(this.SimTool.Coordinate.X, this.SimTool.Coordinate.Y + this.SimTool.Thickness, this.SimTool.Coordinate.Z + this.SimTool.Diameter / 2.0), this.SimTool.Diameter / 2.0, 16 /*0x10*/, new WorkPlane(planeType.XZ, 1), ref pnt3DList2);
              buControlCoreClass.cVector.Rotate(new Pnt3D(this.SimTool.Coordinate.X, this.SimTool.Coordinate.Y + this.SimTool.Thickness / 2.0, this.SimTool.Coordinate.Z), this.SimTool.TangentAngle, new WorkPlane(), ref pnt3DList1);
              buControlCoreClass.cVector.Rotate(new Pnt3D(this.SimTool.Coordinate.X, this.SimTool.Coordinate.Y + this.SimTool.Thickness / 2.0, this.SimTool.Coordinate.Z), this.SimTool.TangentAngle, new WorkPlane(), ref pnt3DList2);
            }
            if (this.SimTool.Orientation == LeftMiddleRightLocationType.Right)
            {
              buControlCoreClass.cVector.PolygonCenter(new Pnt3D(this.SimTool.Coordinate.X, this.SimTool.Coordinate.Y - this.SimTool.Thickness, this.SimTool.Coordinate.Z + this.SimTool.Diameter / 2.0), this.SimTool.Diameter / 2.0, 16 /*0x10*/, new WorkPlane(planeType.XZ, 1), ref pnt3DList1);
              buControlCoreClass.cVector.PolygonCenter(new Pnt3D(this.SimTool.Coordinate.X, this.SimTool.Coordinate.Y, this.SimTool.Coordinate.Z + this.SimTool.Diameter / 2.0), this.SimTool.Diameter / 2.0, 16 /*0x10*/, new WorkPlane(planeType.XZ, 1), ref pnt3DList2);
              buControlCoreClass.cVector.Rotate(new Pnt3D(this.SimTool.Coordinate.X, this.SimTool.Coordinate.Y - this.SimTool.Thickness / 2.0, this.SimTool.Coordinate.Z), this.SimTool.TangentAngle, new WorkPlane(), ref pnt3DList1);
              buControlCoreClass.cVector.Rotate(new Pnt3D(this.SimTool.Coordinate.X, this.SimTool.Coordinate.Y - this.SimTool.Thickness / 2.0, this.SimTool.Coordinate.Z), this.SimTool.TangentAngle, new WorkPlane(), ref pnt3DList2);
            }
            Point[] points6 = new Point[pnt3DList1.Count];
            Point[] points7 = new Point[pnt3DList2.Count];
            for (int index = 0; index <= pnt3DList1.Count - 1; ++index)
            {
              Pnt3D refPoint = new Pnt3D(pnt3DList1[index]);
              refPoint.Z *= -1.0;
              PointF pointF32 = new PointF();
              PointF pointF33 = this.ViewportUpdate(refPoint);
              points6[index] = new Point(this.UTPx((double) pointF33.X), this.UTPy((double) pointF33.Y));
            }
            graphics.FillPolygon((Brush) new SolidBrush(this.SimTool.Color), points6);
            for (int index = 0; index <= pnt3DList2.Count - 1; ++index)
            {
              Pnt3D refPoint = new Pnt3D(pnt3DList2[index]);
              refPoint.Z *= -1.0;
              PointF pointF34 = new PointF();
              PointF pointF35 = this.ViewportUpdate(refPoint);
              points7[index] = new Point(this.UTPx((double) pointF35.X), this.UTPy((double) pointF35.Y));
            }
            graphics.FillPolygon((Brush) new SolidBrush(this.SimTool.Color), points7);
            for (int index = 1; index <= pnt3DList2.Count - 1; ++index)
            {
              Point[] points8 = new Point[4];
              Pnt3D refPoint17 = new Pnt3D(pnt3DList2[index - 1]);
              refPoint17.Z *= -1.0;
              PointF pointF = new PointF();
              pointF = this.ViewportUpdate(refPoint17);
              points8[0] = new Point(this.UTPx((double) pointF.X), this.UTPy((double) pointF.Y));
              Pnt3D refPoint18 = new Pnt3D(pnt3DList2[index]);
              refPoint18.Z *= -1.0;
              pointF = new PointF();
              pointF = this.ViewportUpdate(refPoint18);
              points8[1] = new Point(this.UTPx((double) pointF.X), this.UTPy((double) pointF.Y));
              Pnt3D refPoint19 = new Pnt3D(pnt3DList1[index]);
              refPoint19.Z *= -1.0;
              pointF = new PointF();
              pointF = this.ViewportUpdate(refPoint19);
              points8[2] = new Point(this.UTPx((double) pointF.X), this.UTPy((double) pointF.Y));
              Pnt3D refPoint20 = new Pnt3D(pnt3DList1[index - 1]);
              refPoint20.Z *= -1.0;
              pointF = new PointF();
              pointF = this.ViewportUpdate(refPoint20);
              points8[3] = new Point(this.UTPx((double) pointF.X), this.UTPy((double) pointF.Y));
              graphics.FillPolygon((Brush) new SolidBrush(this.SimTool.Color), points8);
            }
            graphics.DrawPolygon(new Pen(this.SimTool.BorderColor), points7);
            graphics.DrawPolygon(new Pen(this.SimTool.BorderColor), points6);
          }
          if (this.SimTool.Type == SimulationToolType.Cross)
          {
            Point pt1 = new Point(this.UTPx(this.SimTool.Coordinate.X), this.UTPy(this.SimTool.Coordinate.Y));
            Point pt2 = new Point(this.UTPx(this.SimTool.Coordinate.X + this.SimTool.Diameter / 2.0), pt1.Y);
            graphics.DrawLine(new Pen(this.SimTool.Color, (float) this.SimTool.Thickness), pt1, pt2);
            pt2 = new Point(this.UTPx(this.SimTool.Coordinate.X - this.SimTool.Diameter / 2.0), pt1.Y);
            graphics.DrawLine(new Pen(this.SimTool.Color, (float) this.SimTool.Thickness), pt1, pt2);
            pt2 = new Point(pt1.X, this.UTPy(this.SimTool.Coordinate.Y + this.SimTool.Diameter / 2.0));
            graphics.DrawLine(new Pen(this.SimTool.Color, (float) this.SimTool.Thickness), pt1, pt2);
            pt2 = new Point(pt1.X, this.UTPy(this.SimTool.Coordinate.Y - this.SimTool.Diameter / 2.0));
            graphics.DrawLine(new Pen(this.SimTool.Color, (float) this.SimTool.Thickness), pt1, pt2);
          }
        }
        this.pictureBox_0.Image = (Image) this.Bmp;
        Entities1.Clear();
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void AddEntities(List<eEntities> RefEntities)
  {
    this.Entities.Clear();
    eEntities.CopyEntities(RefEntities, ref this.Entities);
  }

  public void SaveScreenToFile(string Filename)
  {
    if (Filename.Length <= 0)
      return;
    this.pictureBox_0.Image.Save(Filename);
  }

  public void ClearEntities()
  {
    this.MaterialEntities.Clear();
    this.Entities.Clear();
    this.DimensionEntities.Clear();
    this.CamEntities.Clear();
    this.ArrowEntities.Clear();
    this.DrawEntities();
  }

  public void DrawCamEntities()
  {
    try
    {
      this.ClientHeight = this.pictureBox_0.Height;
      this.ClientWidth = this.pictureBox_0.Width;
      if (this.pictureBox_0.Width == 0 | this.pictureBox_0.Height == 0)
        return;
      Bitmap bitmap = new Bitmap(this.pictureBox_0.Width, this.pictureBox_0.Height);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      graphics.Clear(this.BackColor);
      Color color1 = new Color();
      Pnt3D MinPoint1 = new Pnt3D();
      Pnt3D MaxPoint1 = new Pnt3D();
      Pnt3D MinPoint2 = new Pnt3D();
      Pnt3D MaxPoint2 = new Pnt3D();
      List<Pnt3D> Points = new List<Pnt3D>();
      if (this.Entities.Count > 0)
      {
        buControlCoreClass.cVector.BoxSizeCalculate(this.Entities, ref MinPoint1, ref MaxPoint1);
        Points.Add(MinPoint1);
        Points.Add(MaxPoint1);
      }
      if (this.DimensionEntities.Count > 0)
      {
        buControlCoreClass.cVector.BoxSizeCalculate(this.DimensionEntities, ref MinPoint1, ref MaxPoint1);
        Points.Add(MinPoint1);
        Points.Add(MaxPoint1);
      }
      if (this.ArrowEntities.Count > 0)
      {
        buControlCoreClass.cVector.BoxSizeCalculate(this.ArrowEntities, ref MinPoint1, ref MaxPoint1);
        Points.Add(MinPoint1);
        Points.Add(MaxPoint1);
      }
      if (this.MaterialEntities.Count > 0)
      {
        buControlCoreClass.cVector.BoxSizeCalculate(this.MaterialEntities, ref MinPoint1, ref MaxPoint1);
        Points.Add(MinPoint1);
        Points.Add(MaxPoint1);
      }
      buControlCoreClass.cVector.BoxSizeCalculate(Points, ref MinPoint2, ref MaxPoint2);
      this.BoxSizeOfEntities = new BoxSize(MinPoint2, MaxPoint2);
      this.BoxSizeOfEntities.Delta = new Vec3D(MaxPoint2.X - MinPoint2.X, MaxPoint2.Y - MinPoint2.Y, MaxPoint2.Z - MinPoint2.Z);
      Color color2;
      for (int index1 = 0; index1 <= this.Entities.Count - 1; ++index1)
      {
        if (this.Entities[index1].bVisible)
        {
          color2 = this.Entities[index1].dispColor;
          if (color2.A == (byte) 0 & color2.B == (byte) 0 & color2.G == (byte) 0 & color2.R == (byte) 0)
            color2 = Color.Black;
          float width = this.Entities[index1].dispThickness;
          if (this.Entities[index1].bSelected)
          {
            color2 = this.SelectedEntityColor;
            width = (float) this.SelectedEntityThickness;
          }
          for (int index2 = 1; index2 <= this.Entities[index1].Vertice.Count - 1; ++index2)
            graphics.DrawLine(new Pen(color2, width), this.UTPx(this.Entities[index1].Vertice[index2 - 1].X), this.UTPy(this.Entities[index1].Vertice[index2 - 1].Y), this.UTPx(this.Entities[index1].Vertice[index2].X), this.UTPy(this.Entities[index1].Vertice[index2].Y));
          if (this.Entities[index1].Vertice.Count == 1)
            graphics.DrawArc(new Pen(color2, width), this.UTPx(this.Entities[index1].Vertice[0].X), this.UTPy(this.Entities[index1].Vertice[0].Y), 2, 2, 0, 360);
        }
      }
      for (int index3 = 0; index3 <= this.CamEntities.Count - 1; ++index3)
      {
        if (this.CamEntities[index3].bVisible)
        {
          color2 = this.CamEntities[index3].dispColor;
          color2 = this.CamEntitiesColor;
          if (color2.A == (byte) 0 & color2.B == (byte) 0 & color2.G == (byte) 0 & color2.R == (byte) 0)
            color2 = Color.Black;
          float width = this.CamEntities[index3].dispThickness + 1f;
          if (this.CamEntities[index3].bSelected)
          {
            color2 = this.SelectedEntityColor;
            width = (float) this.SelectedEntityThickness;
          }
          for (int index4 = 1; index4 <= this.CamEntities[index3].Vertice.Count - 1; ++index4)
            graphics.DrawLine(new Pen(color2, width), this.UTPx(this.CamEntities[index3].Vertice[index4 - 1].X), this.UTPy(this.CamEntities[index3].Vertice[index4 - 1].Y), this.UTPx(this.CamEntities[index3].Vertice[index4].X), this.UTPy(this.CamEntities[index3].Vertice[index4].Y));
          if (this.CamEntities[index3].Vertice.Count == 1)
            graphics.DrawLine(new Pen(color2, width), this.UTPx(this.CamEntities[index3].Vertice[0].X), this.UTPy(this.CamEntities[index3].Vertice[0].Y), this.UTPx(this.CamEntities[index3].Vertice[0].X + 0.1), this.UTPy(this.CamEntities[index3].Vertice[0].Y + 0.1));
        }
      }
      this.pictureBox_0.Image = (Image) bitmap;
    }
    catch (Exception ex)
    {
    }
  }

  public PointF ViewportUpdate(Pnt3D refPoint)
  {
    PointF pointF1 = new PointF();
    PointF pointF2;
    if (this.viewAngle.X == 0.0 & this.viewAngle.Y == 0.0 & this.viewAngle.Z == 0.0)
    {
      pointF1.X = (float) refPoint.X;
      pointF1.Y = (float) refPoint.Y;
      pointF2 = pointF1;
    }
    else if (this.viewAngle.X == 180.0 & this.viewAngle.Y == 180.0 & this.viewAngle.Z == 0.0)
    {
      pointF1.X = (float) refPoint.X;
      pointF1.Y = (float) refPoint.Y;
      pointF2 = pointF1;
    }
    else
    {
      if (!this.Only2D)
      {
        Pnt3D.Offset(ref refPoint, -this.viewRotateCenter.X, -this.viewRotateCenter.Y, -this.viewRotateCenter.Z);
        Quaternion quaternion1 = new Quaternion();
        quaternion1.FromAxisAngle(new Vec3D(1.0, 0.0, 0.0), this.viewAngle.X * Math.PI / 180.0);
        quaternion1.Rotate(refPoint);
        quaternion1.Rotate(this.viewRotateCenter);
        Quaternion quaternion2 = new Quaternion();
        quaternion2.FromAxisAngle(new Vec3D(0.0, 1.0, 0.0), this.viewAngle.Y * Math.PI / 180.0);
        quaternion2.Rotate(refPoint);
        quaternion2.Rotate(this.viewRotateCenter);
        Quaternion quaternion3 = new Quaternion();
        quaternion3.FromAxisAngle(new Vec3D(0.0, 0.0, 1.0), this.viewAngle.Z * Math.PI / 180.0);
        quaternion3.Rotate(refPoint);
        quaternion3.Rotate(this.viewRotateCenter);
        Pnt3D.Offset(ref refPoint, this.viewRotateCenter.X, this.viewRotateCenter.Y, this.viewRotateCenter.Z);
      }
      if (this.viewProjectionMode == ProjectionModeType.Orthographic)
        pointF1 = this.Get2D(refPoint);
      if (this.viewProjectionMode == ProjectionModeType.Perspective)
        pointF1 = this.viewCamera.GetProjection(refPoint);
      pointF2 = pointF1;
    }
    return pointF2;
  }

  public PointF Get2D(Pnt3D vec)
  {
    PointF pointF = new PointF();
    float num1 = (float) Screen.PrimaryScreen.Bounds.Width / 1.5f;
    Pnt3D pnt3D = new Pnt3D();
    float num2 = 100000f;
    pnt3D.X = this.pnt3D_1.X;
    pnt3D.Y = this.pnt3D_1.Y;
    pnt3D.Z = this.pnt3D_1.X * 100000.0 / this.pnt3D_1.X;
    float num3 = Convert.ToSingle(-vec.Z) - Convert.ToSingle(pnt3D.Z);
    pointF.X = (Convert.ToSingle(pnt3D.X) - Convert.ToSingle(vec.X)) / num3 * num2;
    pointF.Y = (Convert.ToSingle(pnt3D.Y) - Convert.ToSingle(vec.Y)) / num3 * num2;
    pointF.X = Convert.ToSingle(pnt3D.X) - Convert.ToSingle(vec.X);
    pointF.Y = Convert.ToSingle(pnt3D.Y) - Convert.ToSingle(vec.Y);
    return pointF;
  }

  public static Pnt3D RotateX(Pnt3D point3D, float degrees)
  {
    double num1 = (double) degrees * (Math.PI / 180.0);
    double num2 = Math.Cos(num1);
    double num3 = Math.Sin(num1);
    double y = point3D.Y * num2 + point3D.Z * num3;
    double z = point3D.Y * -num3 + point3D.Z * num2;
    return new Pnt3D(point3D.X, y, z);
  }

  public static Pnt3D RotateY(Pnt3D point3D, float degrees)
  {
    double num1 = (double) degrees * (Math.PI / 180.0);
    double num2 = Math.Cos(num1);
    double num3 = Math.Sin(num1);
    double x = point3D.X * num2 + point3D.Z * num3;
    double z = point3D.X * -num3 + point3D.Z * num2;
    return new Pnt3D(x, point3D.Y, z);
  }

  public static Pnt3D RotateZ(Pnt3D point3D, float degrees)
  {
    double num1 = (double) degrees * (Math.PI / 180.0);
    double num2 = Math.Cos(num1);
    double num3 = Math.Sin(num1);
    return new Pnt3D(point3D.X * num2 + point3D.Y * num3, point3D.X * -num3 + point3D.Y * num2, point3D.Z);
  }

  public static Pnt3D Translate(Pnt3D points3D, Pnt3D oldOrigin, Pnt3D newOrigin)
  {
    Pnt3D pnt3D = new Pnt3D(newOrigin.X - oldOrigin.X, newOrigin.Y - oldOrigin.Y, newOrigin.Z - oldOrigin.Z);
    points3D.X += pnt3D.X;
    points3D.Y += pnt3D.Y;
    points3D.Z += pnt3D.Z;
    return points3D;
  }

  public static Pnt3D[] RotateX(Pnt3D[] points3D, float degrees)
  {
    for (int index = 0; index < points3D.Length; ++index)
      points3D[index] = buViewer.RotateX(points3D[index], degrees);
    return points3D;
  }

  public static Pnt3D[] RotateY(Pnt3D[] points3D, float degrees)
  {
    for (int index = 0; index < points3D.Length; ++index)
      points3D[index] = buViewer.RotateY(points3D[index], degrees);
    return points3D;
  }

  public static Pnt3D[] RotateZ(Pnt3D[] points3D, float degrees)
  {
    for (int index = 0; index < points3D.Length; ++index)
      points3D[index] = buViewer.RotateZ(points3D[index], degrees);
    return points3D;
  }

  public static Pnt3D[] Translate(Pnt3D[] points3D, Pnt3D oldOrigin, Pnt3D newOrigin)
  {
    for (int index = 0; index < points3D.Length; ++index)
      points3D[index] = buViewer.Translate(points3D[index], oldOrigin, newOrigin);
    return points3D;
  }

  public double PTUx(int XPixel)
  {
    try
    {
      return this.ScreenLeft + (double) XPixel * this.ScreenWidth / (double) this.ClientWidth;
    }
    catch (Exception ex)
    {
      return 0.0;
    }
  }

  public double PTUy(int YPixel)
  {
    try
    {
      return this.ScreenTop + (double) (-1 * YPixel) * this.ScreenHeight / (double) this.ClientHeight;
    }
    catch (Exception ex)
    {
      return 0.0;
    }
  }

  public int UTPx(double XValue)
  {
    try
    {
      return this.ScreenWidth != 0.0 ? Convert.ToInt32((XValue - this.ScreenLeft) * (double) this.ClientWidth / this.ScreenWidth) : 0;
    }
    catch (Exception ex)
    {
      return 0;
    }
  }

  public int UTPy(double YValue)
  {
    try
    {
      return this.ScreenHeight != 0.0 ? Convert.ToInt32((this.ScreenTop - YValue) * (double) this.ClientHeight / this.ScreenHeight) : 0;
    }
    catch (Exception ex)
    {
      return 0;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
