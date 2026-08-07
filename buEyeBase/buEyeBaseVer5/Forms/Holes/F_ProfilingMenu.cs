// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Holes.F_ProfilingMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Library;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Holes;

public class F_ProfilingMenu : Form
{
  internal Label \u001A;
  internal Label \u001B;
  internal Label \u001C;
  internal Label \u001D;
  internal Label \u001E;
  internal Label \u001F;
  internal Label \u007F;
  internal Label \u0080;
  internal Label \u0081;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (!(((F_CabinetSettings) this).Properties.Result != DialogResult.OK & ((F_CabinetSettings) this).Properties.Result != DialogResult.Ignore))
      return;
    obj1.Cancel = true;
    ((F_CabinetSettings) this).Properties.Result = DialogResult.Cancel;
    if (((F_CabinetSettings) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_CabinetSettings) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Init()
  {
    ((F_CabinetSettings) this).Properties.Inited = false;
    ArrayList arrayList = new ArrayList();
    if (((F_CabinetSettings) this).Properties.Height > 10)
      this.Height = ((F_CabinetSettings) this).Properties.Height;
    if (((F_CabinetSettings) this).Properties.Width > 10)
      this.Width = ((F_CabinetSettings) this).Properties.Width;
    ((F_CabinetSettings) this).Chars = this.SortByCharVal(((F_CabinetSettings) this).Chars, (CharLibrary5) new KinematicBase5("0"), SortDirection.BiggerToLower);
    for (int index = 0; index <= ((F_CabinetSettings) this).Chars.Count - 1; ++index)
    {
      if (((EntitiesCopySettings) ((F_CabinetSettings) this).Chars[index]).Char.Length > 0)
      {
        string str = "";
        if (((EntitiesCopySettings) ((F_CabinetSettings) this).Chars[index]).Index > 0)
          str = "_" + ((EntitiesCopySettings) ((F_CabinetSettings) this).Chars[index]).Index.ToString();
        ((F_CabinetSettings) this).\u0001.Items.Add((object) (((EntitiesCopySettings) ((F_CabinetSettings) this).Chars[index]).Char + str), true);
      }
    }
    this.Refresh();
    ((F_CabinetSettings) this).Properties.Result = DialogResult.None;
    ((F_CabinetSettings) this).Properties.Inited = true;
    this.ControlUpdate();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_CharList) this);
  }

  public void ControlUpdate()
  {
  }

  public List<CharLibrary5> SortByCharVal(
    List<CharLibrary5> lst,
    CharLibrary5 refPoint,
    SortDirection Direction)
  {
    List<CharLibrary5> charLibrary5List = new List<CharLibrary5>();
    if (lst.Count > 0)
    {
      charLibrary5List.Add(lst[this.NearestIndexPoint((CharLibrary5) new Clamper(refPoint), lst)]);
      lst.Remove(charLibrary5List[0]);
      int num = 0;
      for (int index = 0; index < lst.Count + num; ++index)
      {
        charLibrary5List.Add(lst[this.NearestIndexPoint(charLibrary5List[charLibrary5List.Count - 1], lst)]);
        lst.Remove(charLibrary5List[charLibrary5List.Count - 1]);
        ++num;
      }
      if (Direction == SortDirection.LowerToBigger)
        charLibrary5List.Reverse();
    }
    return charLibrary5List;
  }

  public int NearestIndexPoint(CharLibrary5 srcPt, List<CharLibrary5> lookIn)
  {
    KeyValuePair<int, int> keyValuePair = new KeyValuePair<int, int>();
    for (int index = 0; index < lookIn.Count; ++index)
    {
      string str = ((EntitiesCopySettings) lookIn[index]).Char;
      if (((EntitiesCopySettings) lookIn[index]).Char.Length > 1)
        str = ((EntitiesCopySettings) lookIn[index]).Char.Substring(0, 1);
      int int32 = Convert.ToInt32(Convert.ToChar(str));
      if (index == 0)
        keyValuePair = new KeyValuePair<int, int>(int32, index);
      else if (int32 < keyValuePair.Key)
        keyValuePair = new KeyValuePair<int, int>(int32, index);
    }
    return keyValuePair.Value;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_CabinetSettings) this).btn_ok.Name)
    {
      if (!((F_CabinetSettings) this).Properties.Inited)
        return;
      if (((F_CabinetSettings) this).Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_CharList) this);
      ((F_CabinetSettings) this).Properties.Result = DialogResult.OK;
      this.Dispose();
    }
    if (control2.Name == ((F_CabinetSettings) this).btn_cancel.Name)
    {
      ((F_CabinetSettings) this).Properties.Result = DialogResult.Cancel;
      if (((F_CabinetSettings) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_CabinetSettings) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_CabinetSettings) this).btn_remove.Name)
    {
      if (((F_CabinetSettings) this).\u0001.SelectedIndex < 0)
        return;
      ((F_CabinetSettings) this).Chars.RemoveAt(((F_CabinetSettings) this).\u0001.SelectedIndex);
      ((F_CabinetSettings) this).\u0001.Items.RemoveAt(((F_CabinetSettings) this).\u0001.SelectedIndex);
    }
    else if (control2.Name == ((F_RotatePanel) this).btn_selectall.Name)
    {
      for (int index = 0; index <= ((F_CabinetSettings) this).\u0001.Items.Count - 1; ++index)
        ((F_CabinetSettings) this).\u0001.SetItemChecked(index, true);
    }
    else if (control2.Name == ((F_RotatePanel) this).btn_unlsectall.Name)
    {
      for (int index = 0; index <= ((F_CabinetSettings) this).\u0001.Items.Count - 1; ++index)
        ((F_CabinetSettings) this).\u0001.SetItemChecked(index, false);
    }
    else
    {
      if (!(control2.Name == ((F_RotatePanel) this).btn_removeall.Name) || buNumeric5.MessageBoxQuestion(AppLanguage.CadCamMessages[130]) != DialogResult.Yes)
        return;
      for (int index1 = 0; index1 <= ((F_CabinetSettings) this).\u0001.Items.Count - 1; ++index1)
      {
        if (((F_CabinetSettings) this).\u0001.GetItemChecked(index1))
        {
          for (int index2 = 0; index2 <= ((F_CabinetSettings) this).Chars.Count - 1; ++index2)
          {
            if (((F_CabinetSettings) this).\u0001.Items[index1].ToString() == ((EntitiesCopySettings) ((F_CabinetSettings) this).Chars[index2]).Char)
            {
              ((F_CabinetSettings) this).Chars.RemoveAt(index2);
              index2 = ((F_CabinetSettings) this).Chars.Count;
            }
          }
        }
      }
      for (int index = ((F_CabinetSettings) this).\u0001.Items.Count - 1; index >= 0; --index)
      {
        if (((F_CabinetSettings) this).\u0001.GetItemChecked(index))
          ((F_CabinetSettings) this).\u0001.Items.RemoveAt(index);
      }
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_CabinetSettings) this).Properties.Inited || ((F_CabinetSettings) this).\u0001.SelectedIndex < 0)
      return;
    Point3D MinPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    buCall.\u0001.BoxSizeCalculate(((EntitiesCopySettings) ((F_CabinetSettings) this).Chars[((F_CabinetSettings) this).\u0001.SelectedIndex]).CharEntities, ref MinPoint, ref MaxPoint);
    ((F_CabinetSettings) this).buViewer1.Entities.Clear();
    List<eEntities> RefEntities = new List<eEntities>();
    for (int index = 0; index <= ((EntitiesCopySettings) ((F_CabinetSettings) this).Chars[((F_CabinetSettings) this).\u0001.SelectedIndex]).CharEntities.Count - 1; ++index)
    {
      eEntities buEntity = (eEntities) null;
      Entity copiedEntity = (Entity) null;
      buAngularDim.Copy(((EntitiesCopySettings) ((F_CabinetSettings) this).Chars[((F_CabinetSettings) this).\u0001.SelectedIndex]).CharEntities[index], ref copiedEntity);
      buString5.eyeEntityToEEntities(copiedEntity, Color.Black, ref buEntity);
      RefEntities.Add(buEntity);
    }
    ((F_CabinetSettings) this).buViewer1.AddEntities(RefEntities);
    ((F_CabinetSettings) this).buViewer1.DrawEntities();
    ((F_CabinetSettings) this).buViewer1.ZoomFit();
    ((F_CabinetSettings) this).buViewer1.ZoomOut();
    ((F_CabinetSettings) this).\u0001.Value = Convert.ToDecimal(MaxPoint.X - MinPoint.X);
    ((F_CabinetSettings) this).\u0002.Value = Convert.ToDecimal(MaxPoint.Y - MinPoint.Y);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CabinetSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CabinetSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ProfilingMenu() => F_CabinetSettings.Captions = new List<string>();
}
