// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSawMillingCam
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls;
using buControls.Controls;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSawMillingCam : Form
{
  public buButton btn_angle;
  public buTab buTab2;
  internal TabPage \u0004;
  public TabPage tabPage2;
  public buButton btn_length;
  public buButton btn_closedrawing;
  public buButton btn_add;
  public buSpin spn_dy;
  public buSpin spn_dx;
  public static byte f001E34;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public DiameterDepthPoint Hole;
  private IContainer \u0001;
  internal buGround \u0001;
  internal buButton \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buSpin spn_depth;
  public buSpin spn_dia;
  public buSpin spn_z;
  public buSpin spn_y;
  public buSpin spn_x;
  public static byte f001E44;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public marbleCamPars Settings;
  private IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public Panel pnl_base;
  public buSpin spn_matsawstraightcutstep;
  public buButton btn_ok;
  public buSpin spn_matsawplungespeed;
  public buSpin spn_matsawstraightcuttingsspeed;
  public buButton btn_cancel;
  public buSpin spn_matsawcircularcutstep;
  public buSpin spn_matmillingcutspeed;
  public buSpin spn_matmillingplungespeed;
  public buSpin spn_matmillingfirstcutspeed;
  public buSpin spn_matmillingcutstep;
  public buSpin spn_matmillingheaddrillspeed;
  public buSpin spn_matmillingheadcutspeed;
  public buSpin spn_matmillingheadplungespeed;
  public buSpin spn_matmillingheadfirstcutspeed;
  public buSpin spn_matmillingheadcutstep;
  public buSpin spn_matsawcircularcutspeed;
  public buSpin spn_matsawstraightcutfirststep;
  public buSpin spn_matsawstraightcutfirstspeed;
  public buSpin spn_matmillingfirstcutstep;
  public buSpin spn_matsawcircularcutfirststep;
  public buSpin spn_matsawcircularcutfirstspeed;
  public buSpin spn_matmillingdrillspeed;
  public buSpin spn_matmillingheadfirstcutstep;
  internal buListBox \u0001;
  public buTab buTab_command_settings;
  public TabPage tabPage_saw;
  public TabPage tabPage_mlling;
  internal TabPage \u0001;
  public buSpin spn_porositydegree;
  public buSpin spn_unitvalumeweight;
  public buSpin spn_density;
  public buSpin spn_monshardness;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal buTextBox \u0001;
  internal PictureBox \u0001;
  internal buTextBox \u0002;

  private void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  public void Init()
  {
    ((F_MarbleCutRemailMaterial) this).PropertiesForm.Inited = false;
    if (((F_MarbleCutRemailMaterial) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleCutRemailMaterial) this).PropertiesForm.Height;
    if (((F_MarbleCutRemailMaterial) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleCutRemailMaterial) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleCutRemailMaterial) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleCutRemailMaterial) this).PropertiesForm.FormPosition;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleEasyDraw) this);
    ((F_MarbleTap) this).\u0001.Clear();
    ((F_MarbleCutRemailMaterial) this).EntityList.Clear();
    ((F_MarbleDrillPocketCam) this).tree_entities.Nodes.Clear();
    ((F_MarbleDrillPocketCam) this).buTab1.ItemSize = new Size(1, 1);
    this.buTab2.ItemSize = new Size(1, 1);
    \u0007.\u0001.\u0001((F_MarbleEasyDraw) this);
    ((F_MarbleProfileCurveCam) this).MenuButtonColors(((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).BasicDrawLineMethod);
    ((F_MarbleProfileCurveCam) this).MenuButtonDrawColors(((F_MarbleTap) this).\u0001);
    ((F_MarbleProfileCurveCam) this).MenuButtonAngleColors(((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).BasicDrawAngle);
    ((F_MarbleCutRemailMaterial) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleCutRemailMaterial) this).PropertiesForm.Inited = true;
    \u001E.\u0001.\u0001((F_MarbleEasyDraw) this);
  }

  public void DrawLineCoord(ref Point3D pNext)
  {
    pNext = new Point3D();
    if (this.buTab2.SelectedIndex == 0)
    {
      buCall.\u0001.LineWithLengthAndAngle(((F_MarbleTap) this).\u0002, ((F_MarbleCavity) this).spn_length.Value, ((F_MarbleCavity) this).spn_angle.Value, ref pNext);
    }
    else
    {
      if (this.buTab2.SelectedIndex != 1)
        return;
      pNext.X = ((F_MarbleTap) this).\u0002.X + this.spn_dx.Value;
      pNext.Y = ((F_MarbleTap) this).\u0002.Y + this.spn_dy.Value;
    }
  }

  public void AddToList(DrawingTypes T)
  {
    int num = 0;
    string NodeText = "";
    switch (T)
    {
      case DrawingTypes.Arc:
        num = 1;
        NodeText = buLangTranslate.preDef.Arc;
        break;
      case DrawingTypes.Line:
        num = 0;
        NodeText = buLangTranslate.preDef.Line;
        break;
      case DrawingTypes.Circle:
        num = 2;
        NodeText = buLangTranslate.preDef.Cirlce;
        break;
      case DrawingTypes.Rectangle:
        num = 3;
        NodeText = buLangTranslate.preDef.Rectangle;
        break;
    }
    buTreeNode node = new buTreeNode(NodeText);
    node.ImageIndex = num;
    node.SelectedImageIndex = num;
    node.Tag = (object) "0";
    node.ClassIndex = 0;
    node.ClassSubIndex = -1;
    node.Command = T.ToString();
    node.Checked = true;
    ((F_MarbleDrillPocketCam) this).tree_entities.Nodes.Add((TreeNode) node);
  }

  public void AddJoint(Point3D Pnt)
  {
    Joint joint = new Joint(new Point3D(Pnt.X, Pnt.Y, 0.0), 10.0, (byte) 2);
    joint.ColorMethod = colorMethodType.byEntity;
    joint.Color = Color.WhiteSmoke;
    CustomData customData = (CustomData) new ClipperOffset();
    ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.Mark);
    joint.EntityData = (object) customData;
    buEyeItems.viewportDialogs.Entities.Add((Entity) joint);
    buEyeItems.viewportDialogs.Invalidate();
  }

  public void RemoveJoint()
  {
    if (buEyeItems.viewportDialogs.Entities.Count <= 0)
      return;
    if (buEyeItems.viewportDialogs.Entities[buEyeItems.viewportDialogs.Entities.Count - 1] is Joint)
      buEyeItems.viewportDialogs.Entities.RemoveAt(buEyeItems.viewportDialogs.Entities.Count - 1);
    if (buEyeItems.viewportDialogs.Entities.Count <= 0 || !(buEyeItems.viewportDialogs.Entities[buEyeItems.viewportDialogs.Entities.Count - 1] is Joint))
      return;
    buEyeItems.viewportDialogs.Entities.RemoveAt(buEyeItems.viewportDialogs.Entities.Count - 1);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleCutRemailMaterial) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleCutRemailMaterial) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCutRemailMaterial) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCutRemailMaterial) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == this.btn_angle.Name)
        ((F_MarbleProfileCurveCam) this).MenuButtonColors(0);
      if (control.Name == this.btn_length.Name)
        ((F_MarbleProfileCurveCam) this).MenuButtonColors(1);
      if (control.Name == ((F_MarbleDrillPocketCam) this).btn_rotate.Name)
      {
        if (buEyeItems.viewportDialogs.ActionMode == actionType.Rotate)
          buEyeItems.viewportDialogs.ActionMode = actionType.None;
        else
          buEyeItems.viewportDialogs.ActionMode = actionType.Rotate;
      }
      else if (control.Name == ((F_MarbleDrillPocketCam) this).btn_pan.Name)
      {
        if (buEyeItems.viewportDialogs.ActionMode == actionType.Pan)
          buEyeItems.viewportDialogs.ActionMode = actionType.None;
        else
          buEyeItems.viewportDialogs.ActionMode = actionType.Pan;
      }
      else if (control.Name == ((F_MarbleTap) this).btn_viewtop.Name)
      {
        buEyeItems.viewportDialogs.SetView(viewType.Top);
        buEyeItems.viewportDialogs.Invalidate();
      }
      else if (control.Name == ((F_MarbleTap) this).btn_viewfront.Name)
      {
        buEyeItems.viewportDialogs.SetView(viewType.Front);
        buEyeItems.viewportDialogs.Invalidate();
      }
      else if (control.Name == ((F_MarbleTap) this).btn_viewback.Name)
      {
        buEyeItems.viewportDialogs.SetView(viewType.Rear);
        buEyeItems.viewportDialogs.Invalidate();
      }
      else if (control.Name == ((F_MarbleDrillPocketCam) this).btn_viewleft.Name)
      {
        buEyeItems.viewportDialogs.SetView(viewType.Left);
        buEyeItems.viewportDialogs.Invalidate();
      }
      else if (control.Name == ((F_MarbleDrillPocketCam) this).btn_viewright.Name)
      {
        buEyeItems.viewportDialogs.SetView(viewType.Right);
        buEyeItems.viewportDialogs.Invalidate();
      }
      else if (control.Name == ((F_MarbleDrillPocketCam) this).btn_viewiso.Name)
      {
        buEyeItems.viewportDialogs.SetView(viewType.Trimetric);
        buEyeItems.viewportDialogs.Invalidate();
      }
      else if (control.Name == ((F_MarbleDrillPocketCam) this).btn_viewzoomfit.Name)
      {
        buEyeItems.viewportDialogs.ZoomFit(10);
        buEyeItems.viewportDialogs.Invalidate();
      }
      else
      {
        if (control.Name == this.btn_add.Name)
        {
          this.DrawLineCoord(ref ((F_MarbleTap) this).\u0001);
          if (buCall.\u0001.Length3D(((F_MarbleTap) this).\u0002, ((F_MarbleTap) this).\u0001, Plane.XY) > 0.0)
          {
            this.RemoveJoint();
            if (((F_MarbleTap) this).\u0001 == DrawingTypes.Line)
            {
              Line line = new Line(F_NotchEdit.ToPoint3D(((F_MarbleTap) this).\u0002), F_NotchEdit.ToPoint3D(((F_MarbleTap) this).\u0001));
              line.LayerName = "Default";
              line.Color = Color.Black;
              line.LineWeight = 2f;
              line.ColorMethod = colorMethodType.byEntity;
              line.LineWeightMethod = colorMethodType.byEntity;
              CustomData customData = (CustomData) new ClipperOffset();
              ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.Drawing);
              ((RollerJob) customData).set_infoBasePoint(new Point3D(((F_MarbleTap) this).\u0001.X, ((F_MarbleTap) this).\u0001.Y));
              line.EntityData = (object) customData;
              buEyeItems.viewportDialogs.Entities.Add((Entity) line);
              ((F_MarbleCutRemailMaterial) this).EntityList.Add((Entity) line);
              this.AddToList(((F_MarbleTap) this).\u0001);
            }
            if (((F_MarbleTap) this).\u0001 == DrawingTypes.Arc)
            {
              if (((F_MarbleCutRemailMaterial) this).pntList.Count == 0)
              {
                ((F_MarbleCutRemailMaterial) this).pntList.Add(new Point3D(((F_MarbleTap) this).\u0002.X, ((F_MarbleTap) this).\u0002.Y));
                ((F_MarbleCutRemailMaterial) this).pntList.Add(new Point3D(((F_MarbleTap) this).\u0001.X, ((F_MarbleTap) this).\u0001.Y));
                LinearPath linearPath = new LinearPath((ICollection<Point3D>) new List<Point3D>()
                {
                  ((F_MarbleTap) this).\u0002,
                  ((F_MarbleTap) this).\u0001
                });
                linearPath.LayerName = "Default";
                linearPath.Color = Color.Red;
                linearPath.LineWeight = 1f;
                linearPath.ColorMethod = colorMethodType.byEntity;
                linearPath.LineWeightMethod = colorMethodType.byEntity;
                CustomData customData = (CustomData) new ClipperOffset();
                ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.Drawing);
                linearPath.EntityData = (object) customData;
                buEyeItems.viewportDialogs.Entities.Add((Entity) linearPath);
              }
              else
              {
                if (buEyeItems.viewportDialogs.Entities.Count > 0 && buEyeItems.viewportDialogs.Entities[buEyeItems.viewportDialogs.Entities.Count - 1] is LinearPath)
                  buEyeItems.viewportDialogs.Entities.RemoveAt(buEyeItems.viewportDialogs.Entities.Count - 1);
                Arc arc = new Arc(F_NotchEdit.ToPoint3D(((F_MarbleCutRemailMaterial) this).pntList[0]), F_NotchEdit.ToPoint3D(((F_MarbleCutRemailMaterial) this).pntList[1]), F_NotchEdit.ToPoint3D(((F_MarbleTap) this).\u0001), false);
                arc.LayerName = "Default";
                arc.Color = Color.Black;
                arc.LineWeight = 2f;
                arc.ColorMethod = colorMethodType.byEntity;
                arc.LineWeightMethod = colorMethodType.byEntity;
                CustomData customData = (CustomData) new ClipperOffset();
                ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.Drawing);
                ((RollerJob) customData).set_infoBasePoint(new Point3D(((F_MarbleTap) this).\u0001.X, ((F_MarbleTap) this).\u0001.Y));
                arc.EntityData = (object) customData;
                buEyeItems.viewportDialogs.Entities.Add((Entity) arc);
                ((F_MarbleCutRemailMaterial) this).EntityList.Add((Entity) arc);
                ((F_MarbleCutRemailMaterial) this).pntList.Clear();
                this.AddToList(((F_MarbleTap) this).\u0001);
              }
            }
            this.AddJoint(((F_MarbleTap) this).\u0001);
            ((F_MarbleTap) this).\u0002.X = ((F_MarbleTap) this).\u0001.X;
            ((F_MarbleTap) this).\u0002.Y = ((F_MarbleTap) this).\u0001.Y;
          }
        }
        if (control.Name == ((F_MarbleCavity) this).btn_clear.Name && buNumeric5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWantToDelete) == DialogResult.Yes)
        {
          ((F_MarbleDrillPocketCam) this).tree_entities.Nodes.Clear();
          ((F_MarbleCutRemailMaterial) this).pntList.Clear();
          ((F_MarbleCutRemailMaterial) this).EntityList.Clear();
          buEyeItems.viewportDialogs.Entities.Clear();
          buEyeItems.viewportDialogs.Invalidate();
        }
        if (control.Name == ((F_MarbleDrillPocketCam) this).btn_arc.Name)
        {
          ((F_MarbleTap) this).\u0001 = DrawingTypes.Arc;
          ((F_MarbleProfileCurveCam) this).MenuButtonDrawColors(((F_MarbleTap) this).\u0001);
        }
        if (control.Name == ((F_MarbleDrillPocketCam) this).btn_polyline.Name)
        {
          ((F_MarbleTap) this).\u0001 = DrawingTypes.Line;
          ((F_MarbleProfileCurveCam) this).MenuButtonDrawColors(((F_MarbleTap) this).\u0001);
        }
        if (control.Name == ((F_MarbleDrillPocketCam) this).btn_circle.Name)
        {
          ((F_MarbleTap) this).\u0001 = DrawingTypes.Circle;
          ((F_MarbleProfileCurveCam) this).MenuButtonDrawColors(((F_MarbleTap) this).\u0001);
        }
        if (control.Name == ((F_MarbleDrillPocketCam) this).btn_rectangle.Name)
        {
          ((F_MarbleTap) this).\u0001 = DrawingTypes.Rectangle;
          ((F_MarbleProfileCurveCam) this).MenuButtonDrawColors(((F_MarbleTap) this).\u0001);
        }
        if (control.Name == ((F_MarbleCavity) this).btn_undo.Name)
        {
          if (((F_MarbleCutRemailMaterial) this).EntityList.Count > 0)
          {
            this.RemoveJoint();
            if (buEyeItems.viewportDialogs.Entities.Count > 0)
              buEyeItems.viewportDialogs.Entities.RemoveAt(buEyeItems.viewportDialogs.Entities.Count - 1);
            if (((F_MarbleCutRemailMaterial) this).pntList.Count > 1)
            {
              ((F_MarbleTap) this).\u0002 = new Point3D(((F_MarbleCutRemailMaterial) this).pntList[0].X, ((F_MarbleCutRemailMaterial) this).pntList[0].Y);
              ((F_MarbleCutRemailMaterial) this).EntityList.RemoveAt(((F_MarbleCutRemailMaterial) this).EntityList.Count - 1);
              ((F_MarbleCutRemailMaterial) this).pntList.Clear();
              this.AddJoint(((F_MarbleTap) this).\u0002);
            }
            else
            {
              ((F_MarbleCutRemailMaterial) this).EntityList.RemoveAt(((F_MarbleCutRemailMaterial) this).EntityList.Count - 1);
              ((F_MarbleCutRemailMaterial) this).pntList.Clear();
              if (((F_MarbleDrillPocketCam) this).tree_entities.Nodes.Count > 0)
                ((F_MarbleDrillPocketCam) this).tree_entities.Nodes.RemoveAt(((F_MarbleDrillPocketCam) this).tree_entities.Nodes.Count - 1);
              if (((F_MarbleCutRemailMaterial) this).EntityList.Count == 0)
              {
                this.\u0002((object) ((F_MarbleDrillPocketCam) this).btn_start, obj1);
              }
              else
              {
                Entity entity = ((F_MarbleCutRemailMaterial) this).EntityList[((F_MarbleCutRemailMaterial) this).EntityList.Count - 1];
                ((F_MarbleTap) this).\u0002 = new Point3D(((buRollerBendCalc) entity.EntityData).get_infoBasePoint().X, ((buRollerBendCalc) entity.EntityData).get_infoBasePoint().Y);
                this.AddJoint(((F_MarbleTap) this).\u0002);
              }
            }
            buEyeItems.viewportDialogs.Invalidate();
          }
          else
            this.\u0002((object) ((F_MarbleDrillPocketCam) this).btn_start, obj1);
        }
        if (control.Name == ((F_MarbleDrillPocketCam) this).btn_start.Name)
        {
          buEyeItems.viewportDialogs.SetView(viewType.Top);
          buEyeItems.viewportDialogs.Invalidate();
          ((F_MarbleCutRemailMaterial) this).pntList.Clear();
          buEyeItems.viewportDialogs.Entities.Clear();
          ((F_MarbleTap) this).\u0002 = new Point3D(((F_MarbleDrillPocketCam) this).spn_startx.Value, ((F_MarbleDrillPocketCam) this).spn_starty.Value, 0.0);
          Joint joint = new Joint(new Point3D(((F_MarbleDrillPocketCam) this).spn_startx.Value, ((F_MarbleDrillPocketCam) this).spn_starty.Value, 0.0), 20.0, (byte) 2);
          joint.ColorMethod = colorMethodType.byEntity;
          joint.Color = Color.WhiteSmoke;
          CustomData customData = (CustomData) new ClipperOffset();
          ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.Mark);
          joint.EntityData = (object) customData;
          buEyeItems.viewportDialogs.Entities.Add((Entity) joint);
          ((F_MarbleDrillPocketCam) this).tree_entities.Nodes.Clear();
          ((F_MarbleCutRemailMaterial) this).EntityList.Clear();
        }
        if (control.Name == this.btn_closedrawing.Name && ((F_MarbleCutRemailMaterial) this).EntityList.Count > 0)
        {
          this.RemoveJoint();
          Line line = new Line(new Point3D(((F_MarbleTap) this).\u0002.X, ((F_MarbleTap) this).\u0002.Y), new Point3D());
          line.LayerName = "Default";
          line.Color = Color.Black;
          line.LineWeight = 2f;
          line.ColorMethod = colorMethodType.byEntity;
          line.LineWeightMethod = colorMethodType.byEntity;
          CustomData customData = (CustomData) new ClipperOffset();
          ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.Drawing);
          ((RollerJob) customData).set_infoBasePoint(new Point3D(((F_MarbleTap) this).\u0001.X, ((F_MarbleTap) this).\u0001.Y));
          line.EntityData = (object) customData;
          buEyeItems.viewportDialogs.Entities.Add((Entity) line);
          ((F_MarbleCutRemailMaterial) this).EntityList.Add((Entity) line);
          this.AddToList(((F_MarbleTap) this).\u0001);
          ((F_MarbleTap) this).\u0002.X = 0.0;
          ((F_MarbleTap) this).\u0002.Y = 0.0;
          this.AddJoint(((F_MarbleTap) this).\u0002);
        }
        if (control.Name == ((F_MarbleCavity) this).btn_left.Name)
        {
          ((F_MarbleCavity) this).spn_angle.Value = 180.0;
          ((F_MarbleProfileCurveCam) this).MenuButtonAngleColors(((F_MarbleCavity) this).spn_angle.Value);
        }
        else if (control.Name == ((F_MarbleCavity) this).btn_leftdown.Name)
        {
          ((F_MarbleCavity) this).spn_angle.Value = 225.0;
          ((F_MarbleProfileCurveCam) this).MenuButtonAngleColors(((F_MarbleCavity) this).spn_angle.Value);
        }
        else if (control.Name == ((F_MarbleCavity) this).btn_leftup.Name)
        {
          ((F_MarbleCavity) this).spn_angle.Value = 135.0;
          ((F_MarbleProfileCurveCam) this).MenuButtonAngleColors(((F_MarbleCavity) this).spn_angle.Value);
        }
        else if (control.Name == ((F_MarbleCavity) this).btn_up.Name)
        {
          ((F_MarbleCavity) this).spn_angle.Value = 90.0;
          ((F_MarbleProfileCurveCam) this).MenuButtonAngleColors(((F_MarbleCavity) this).spn_angle.Value);
        }
        else if (control.Name == ((F_MarbleCavity) this).btn_down.Name)
        {
          ((F_MarbleCavity) this).spn_angle.Value = 270.0;
          ((F_MarbleProfileCurveCam) this).MenuButtonAngleColors(((F_MarbleCavity) this).spn_angle.Value);
        }
        else if (control.Name == ((F_MarbleCavity) this).btn_right.Name)
        {
          ((F_MarbleCavity) this).spn_angle.Value = 0.0;
          ((F_MarbleProfileCurveCam) this).MenuButtonAngleColors(((F_MarbleCavity) this).spn_angle.Value);
        }
        else if (control.Name == ((F_MarbleCavity) this).btn_rightdown.Name)
        {
          ((F_MarbleCavity) this).spn_angle.Value = 315.0;
          ((F_MarbleProfileCurveCam) this).MenuButtonAngleColors(((F_MarbleCavity) this).spn_angle.Value);
        }
        else if (control.Name == ((F_MarbleCavity) this).btn_rightup.Name)
        {
          ((F_MarbleCavity) this).spn_angle.Value = 45.0;
          ((F_MarbleProfileCurveCam) this).MenuButtonAngleColors(((F_MarbleCavity) this).spn_angle.Value);
        }
        if (control.Name == ((F_MarbleTap) this).btn_settings.Name)
          ;
        if (control.Name == ((F_MarbleTap) this).btn_save.Name)
        {
          SaveFileDialog saveFileDialog = new SaveFileDialog();
          saveFileDialog.Filter = "Dxf Files (*.dxf)|*.dxf";
          saveFileDialog.InitialDirectory = ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).pathEasyDraw;
          if (saveFileDialog.ShowDialog() == DialogResult.OK)
          {
            this.RemoveJoint();
            buVector5.SaveDxfDwg(buEyeItems.viewportDialogs, saveFileDialog.FileName);
            ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).pathEasyDraw = buFile5.bunesting.GetPath(saveFileDialog.FileName);
            this.AddJoint(((F_MarbleTap) this).\u0001);
          }
        }
        if (control.Name == ((F_MarbleTap) this).btn_ok.Name)
        {
          \u0007.\u0001.\u0001((F_MarbleEasyDraw) this);
          ((F_MarbleCutRemailMaterial) this).PropertiesForm.Result = DialogResult.OK;
          if (((F_MarbleCutRemailMaterial) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
            this.Dispose();
          if (((F_MarbleCutRemailMaterial) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
            this.Visible = false;
        }
        if (!(control.Name == ((F_MarbleTap) this).btn_cancel.Name | control.Name == ((F_MarbleTap) this).btn_close.Name))
          return;
        ((F_MarbleCutRemailMaterial) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_MarbleCutRemailMaterial) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleCutRemailMaterial) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
    }
    catch (Exception ex)
    {
    }
  }
}
