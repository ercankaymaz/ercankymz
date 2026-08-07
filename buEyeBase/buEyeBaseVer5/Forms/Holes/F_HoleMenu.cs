// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Holes.F_HoleMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5.Forms.Layer;
using buEyeBaseVer5.Forms.Library;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Holes;

public class F_HoleMenu : Form
{
  internal TextBox \u0015;
  internal TextBox \u0016;
  internal TextBox \u0017;
  internal TextBox \u0018;
  internal TextBox \u0019;
  internal TextBox \u001A;
  internal TextBox \u001B;
  internal TextBox \u001C;
  internal TextBox \u001D;
  internal TextBox \u001E;
  internal TextBox \u001F;
  internal TextBox \u007F;
  internal TextBox \u0080;

  internal void \u0007([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      int num = 1;
      if (((F_MirrorOP) this).\u0001.Text.Length == 0)
      {
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SketchLibrary) this);
      }
      else
      {
        ((F_MirrorOP) this).\u0001.Items.Clear();
        for (int index = 0; index <= ((F_RotatePanel) this).\u0001.Count - 1; ++index)
        {
          string withoutExtension = buFile.getFileNameWithoutExtension(((F_RotatePanel) this).\u0001[index]);
          if (withoutExtension.ToLower().IndexOf(((F_MirrorOP) this).\u0001.Text.ToLower()) >= 0)
          {
            ((F_MirrorOP) this).\u0001.Items.Add((object) withoutExtension);
            ++num;
          }
        }
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  private void \u0001([In] object obj0, [In] MouseEventArgs obj1)
  {
    Point3D intPoint = new Point3D();
    ((F_RotatePanel) this).viewport.ScreenToPlane(obj1.Location, Plane.XY, out intPoint);
    ((F_MirrorOP) this).\u0001.Text = $"X: {intPoint.X.ToString("f2")} - Y: {intPoint.Y.ToString("f2")}";
  }

  private void \u0002([In] object obj0, [In] MouseEventArgs obj1)
  {
    int[] underMouseCursor = ((F_RotatePanel) this).viewport.GetAllEntitiesUnderMouseCursor(obj1.Location);
    if (underMouseCursor == null || underMouseCursor.Length == 0 || !(((F_RotatePanel) this).viewport.Entities[underMouseCursor[0]].GetType().BaseType == typeof (Dimension)) || ((F_RotatePanel) this).viewport.Entities[underMouseCursor[0]].EntityData != null)
      ;
  }

  private void \u0003([In] object obj0, [In] MouseEventArgs obj1)
  {
    SelectedItem underMouseCursor = ((F_RotatePanel) this).viewport.GetItemUnderMouseCursor(obj1.Location, true);
    if (underMouseCursor == null)
      return;
    Entity entity = underMouseCursor.Item as Entity;
    VisualConstraint constraint = ((F_RotatePanel) this).viewport.CurrentSketch.GetConstraint(entity);
    if (!(constraint is ValueVisualConstraint))
      return;
    DialogBoxInput dialogBoxInput = new DialogBoxInput();
    dialogBoxInput.Value = ((ValueVisualConstraint) constraint).Value;
    dialogBoxInput.StartPosition = FormStartPosition.CenterParent;
    dialogBoxInput.Init();
    dialogBoxInput.SelectAll();
    int num = (int) dialogBoxInput.ShowDialog();
    if (dialogBoxInput.Result == DialogResult.OK)
    {
      ((ValueVisualConstraint) constraint).Value = dialogBoxInput.Value;
      int index1 = 0;
      for (int index2 = 0; index2 <= ((F_RotatePanel) this).viewport.Entities.Count - 1; ++index2)
      {
        if (((F_RotatePanel) this).viewport.Entities[index2] is Dimension)
        {
          if (buCall.\u0001.isEntitySame(entity, ((F_RotatePanel) this).viewport.Entities[index2]) && index1 <= ((F_MirrorOP) this).\u0001.Rows.Count - 1)
          {
            ((F_RotatePanel) this).PropertiesForm.Inited = false;
            ((F_MirrorOP) this).\u0001.Rows[index1].Cells[1].Value = (object) dialogBoxInput.Value;
          }
          ++index1;
        }
      }
    }
    ((F_RotatePanel) this).viewport.CurrentSketch.UpdateAndInvalidate();
    ((F_RotatePanel) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    ((F_MirrorOP) this).\u0001 = obj1.Control;
  }

  internal void \u0002([In] object obj0, [In] KeyEventArgs obj1)
  {
    ((F_MirrorOP) this).\u0001 = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MirrorOP) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MirrorOP) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_HoleMenu() => F_RotatePanel.Captions = new List<string>();

  public F_HoleMenu()
  {
    ((F_MirrorOP) this).PropertiesForm = new FormProperties();
    ((F_MirrorOP) this).LayerOptions = new List<LayerOverride>();
    ((F_MirrorOP) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_LayerOptionList) this);
  }
}
