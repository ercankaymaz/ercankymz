// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Holes.F_Contour
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.KeyPad;
using buEyeBaseVer5.Forms.Library;
using buEyeBaseVer5.Forms.Location;
using buEyeBaseVer5.Forms.Machine;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Holes;

public class F_Contour : Form
{
  internal Label \u0002;
  internal Label \u0003;
  internal Label \u0004;
  internal Label \u0005;
  internal Label \u0006;
  internal Label \u0007;
  internal Label \u0008;
  internal Label \u000E;
  internal Label \u000F;
  internal Label \u0010;
  internal Label \u0011;
  internal Label \u0012;
  internal Label \u0013;
  internal Label \u0014;
  internal Label \u0015;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal Label \u0016;
  internal Label \u0017;
  internal Label \u0018;
  internal Label \u0019;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    string str = ((F_KeyPadCharV1) this).\u0001 + " btn_Click";
    try
    {
      Control control = obj0 as Control;
      if (control.Name == ((F_KeyPadCharV1) this).btn_ok.Name)
      {
        if (!((F_KeyPadCharV1) this).Properties.Inited)
          return;
        if (((F_KeyPadCharV1) this).Properties.ReadOnly)
        {
          this.Dispose();
          return;
        }
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MachineGCodeCfg) this);
        ((F_KeyPadCharV1) this).Properties.Result = DialogResult.OK;
        if (((F_KeyPadCharV1) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_KeyPadCharV1) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control.Name == ((F_KeyPadCharV1) this).btn_cancel.Name)
      {
        ((F_KeyPadCharV1) this).Properties.Result = DialogResult.Cancel;
        if (((F_KeyPadCharV1) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_KeyPadCharV1) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control.Name == ((F_KeyPadNumV1) this).btn_addaxis.Name)
      {
        F_MachineAxisCfg fMachineAxisCfg = (F_MachineAxisCfg) new F_RotatePanel();
        ((F_KeyPadCharV1) fMachineAxisCfg).Properties.FormCloseMode = FormCloseModeType.Dispose;
        ((F_KeyPadCharV1) fMachineAxisCfg).Properties.FormPosition = FormStartPosition.CenterParent;
        ((F_KeyPadCharV1) fMachineAxisCfg).Axis = (MachineAxisInfo) new F_Move();
        ((F_RotatePanel) fMachineAxisCfg).Init();
        int num = (int) fMachineAxisCfg.ShowDialog();
        if (((F_KeyPadCharV1) fMachineAxisCfg).Properties.Result == DialogResult.OK)
        {
          ((F_KeyPadCharV1) this).\u0001.Items.Add((object) F_Devide.AxisToString(((F_KeyPadCharV1) fMachineAxisCfg).Axis));
          ((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).AxesList.Add((MachineAxisInfo) new F_Devide(((F_KeyPadCharV1) fMachineAxisCfg).Axis));
        }
      }
      if (control.Name == ((F_KeyPadNumV1) this).btn_removeaxis.Name && ((F_KeyPadCharV1) this).\u0001.SelectedIndex >= 0 && buNumeric5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWantToDelete) == DialogResult.Yes)
      {
        ((F_KeyPadCharV1) this).\u0001.Items.RemoveAt(((F_KeyPadCharV1) this).\u0001.SelectedIndex);
        ((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).AxesList.RemoveAt(((F_KeyPadCharV1) this).\u0001.SelectedIndex);
      }
      if (control.Name == ((F_KeyPadNumV1) this).btn_addmcodes.Name)
      {
        F_MachineMCodeCfg fMachineMcodeCfg = (F_MachineMCodeCfg) new F_RotatePanel();
        ((F_KeyPadCharV1) fMachineMcodeCfg).Properties.FormCloseMode = FormCloseModeType.Dispose;
        ((F_KeyPadCharV1) fMachineMcodeCfg).Properties.FormPosition = FormStartPosition.CenterParent;
        ((F_KeyPadCharV1) fMachineMcodeCfg).MCode = (MachineMCodeInfo) new F_Devide();
        ((F_RotatePanel) fMachineMcodeCfg).Init();
        int num = (int) fMachineMcodeCfg.ShowDialog();
        if (((F_KeyPadCharV1) fMachineMcodeCfg).Properties.Result == DialogResult.OK)
        {
          ((F_KeyPadNumV1) this).\u0002.Items.Add((object) F_Devide.MCodeToString(((F_KeyPadCharV1) fMachineMcodeCfg).MCode));
          ((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).MCodeList.Add((MachineMCodeInfo) new F_Devide(((F_KeyPadCharV1) fMachineMcodeCfg).MCode));
        }
      }
      if (control.Name == ((F_KeyPadNumV1) this).btn_removemcodes.Name && ((F_KeyPadNumV1) this).\u0002.SelectedIndex >= 0 && buNumeric5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWantToDelete) == DialogResult.Yes)
      {
        ((F_KeyPadNumV1) this).\u0002.Items.RemoveAt(((F_KeyPadNumV1) this).\u0002.SelectedIndex);
        ((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).MCodeList.RemoveAt(((F_KeyPadNumV1) this).\u0002.SelectedIndex);
      }
      if (control.Name == ((F_KeyPadNumV1) this).btn_addothercodes.Name)
      {
        F_MachineOtherCodeCfg machineOtherCodeCfg = (F_MachineOtherCodeCfg) new F_CabinetSettings();
        ((F_KeyPadCharV1) machineOtherCodeCfg).Properties.FormCloseMode = FormCloseModeType.Dispose;
        ((F_KeyPadCharV1) machineOtherCodeCfg).Properties.FormPosition = FormStartPosition.CenterParent;
        ((F_KeyPadCharV1) machineOtherCodeCfg).OtherCode = (MachineOtherCodeInfo) new F_Devide();
        ((F_CabinetSettings) machineOtherCodeCfg).Init();
        int num = (int) machineOtherCodeCfg.ShowDialog();
        if (((F_KeyPadCharV1) machineOtherCodeCfg).Properties.Result == DialogResult.OK)
        {
          ((F_KeyPadNumV1) this).\u0003.Items.Add((object) F_Devide.OtherCodeToString(((F_KeyPadCharV1) machineOtherCodeCfg).OtherCode));
          ((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).OtherCodeList.Add((MachineOtherCodeInfo) new F_Devide(((F_KeyPadCharV1) machineOtherCodeCfg).OtherCode));
        }
      }
      if (!(control.Name == ((F_KeyPadNumV1) this).btn_removeothercodes.Name) || ((F_KeyPadNumV1) this).\u0003.SelectedIndex < 0 || buNumeric5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWantToDelete) != DialogResult.Yes)
        return;
      ((F_KeyPadNumV1) this).\u0003.Items.RemoveAt(((F_KeyPadNumV1) this).\u0003.SelectedIndex);
      ((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).OtherCodeList.RemoveAt(((F_KeyPadNumV1) this).\u0003.SelectedIndex);
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_KeyPadCharV1) this).\u0001, str, "Exception", ex.Message);
      buException.throwException(ex, str, true);
    }
  }

  internal void \u0001([In] object obj0, [In] MouseEventArgs obj1)
  {
    string str = ((F_KeyPadCharV1) this).\u0001 + " lst_MouseDoubleClick";
    try
    {
      Control control = obj0 as Control;
      if (control.Name == ((F_KeyPadCharV1) this).\u0001.Name && ((F_KeyPadCharV1) this).\u0001.SelectedIndex >= 0 & ((F_KeyPadCharV1) this).\u0001.SelectedIndex <= ((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).AxesList.Count - 1)
      {
        F_MachineAxisCfg fMachineAxisCfg = (F_MachineAxisCfg) new F_RotatePanel();
        ((F_KeyPadCharV1) fMachineAxisCfg).Properties.FormCloseMode = FormCloseModeType.Dispose;
        ((F_KeyPadCharV1) fMachineAxisCfg).Properties.FormPosition = FormStartPosition.CenterParent;
        ((F_KeyPadCharV1) fMachineAxisCfg).Axis = (MachineAxisInfo) new F_Devide(((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).AxesList[((F_KeyPadCharV1) this).\u0001.SelectedIndex]);
        ((F_RotatePanel) fMachineAxisCfg).Init();
        int num = (int) fMachineAxisCfg.ShowDialog();
        if (((F_KeyPadCharV1) fMachineAxisCfg).Properties.Result == DialogResult.OK)
        {
          ((F_KeyPadCharV1) this).\u0001.Items[((F_KeyPadCharV1) this).\u0001.SelectedIndex] = (object) F_Devide.AxisToString(((F_KeyPadCharV1) fMachineAxisCfg).Axis);
          ((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).AxesList[((F_KeyPadCharV1) this).\u0001.SelectedIndex] = (MachineAxisInfo) new F_Devide(((F_KeyPadCharV1) fMachineAxisCfg).Axis);
        }
      }
      if (control.Name == ((F_KeyPadNumV1) this).\u0002.Name && ((F_KeyPadNumV1) this).\u0002.SelectedIndex >= 0 & ((F_KeyPadNumV1) this).\u0002.SelectedIndex <= ((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).MCodeList.Count - 1)
      {
        F_MachineMCodeCfg fMachineMcodeCfg = (F_MachineMCodeCfg) new F_RotatePanel();
        ((F_KeyPadCharV1) fMachineMcodeCfg).Properties.FormCloseMode = FormCloseModeType.Dispose;
        ((F_KeyPadCharV1) fMachineMcodeCfg).Properties.FormPosition = FormStartPosition.CenterParent;
        ((F_KeyPadCharV1) fMachineMcodeCfg).MCode = (MachineMCodeInfo) new F_Devide(((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).MCodeList[((F_KeyPadNumV1) this).\u0002.SelectedIndex]);
        ((F_RotatePanel) fMachineMcodeCfg).Init();
        int num = (int) fMachineMcodeCfg.ShowDialog();
        if (((F_KeyPadCharV1) fMachineMcodeCfg).Properties.Result == DialogResult.OK)
        {
          ((F_KeyPadNumV1) this).\u0002.Items[((F_KeyPadNumV1) this).\u0002.SelectedIndex] = (object) F_Devide.MCodeToString(((F_KeyPadCharV1) fMachineMcodeCfg).MCode);
          ((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).MCodeList[((F_KeyPadNumV1) this).\u0002.SelectedIndex] = (MachineMCodeInfo) new F_Devide(((F_KeyPadCharV1) fMachineMcodeCfg).MCode);
        }
      }
      if (!(control.Name == ((F_KeyPadNumV1) this).\u0003.Name) || !(((F_KeyPadNumV1) this).\u0003.SelectedIndex >= 0 & ((F_KeyPadNumV1) this).\u0003.SelectedIndex <= ((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).AxesList.Count - 1))
        return;
      F_MachineOtherCodeCfg machineOtherCodeCfg = (F_MachineOtherCodeCfg) new F_CabinetSettings();
      ((F_KeyPadCharV1) machineOtherCodeCfg).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_KeyPadCharV1) machineOtherCodeCfg).Properties.FormPosition = FormStartPosition.CenterParent;
      ((F_KeyPadCharV1) machineOtherCodeCfg).OtherCode = (MachineOtherCodeInfo) new F_Devide(((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).OtherCodeList[((F_KeyPadNumV1) this).\u0003.SelectedIndex]);
      ((F_CabinetSettings) machineOtherCodeCfg).Init();
      int num1 = (int) machineOtherCodeCfg.ShowDialog();
      if (((F_KeyPadCharV1) machineOtherCodeCfg).Properties.Result != DialogResult.OK)
        return;
      ((F_KeyPadNumV1) this).\u0003.Items[((F_KeyPadNumV1) this).\u0003.SelectedIndex] = (object) F_Devide.OtherCodeToString(((F_KeyPadCharV1) machineOtherCodeCfg).OtherCode);
      ((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).OtherCodeList[((F_KeyPadNumV1) this).\u0003.SelectedIndex] = (MachineOtherCodeInfo) new F_Devide(((F_KeyPadCharV1) machineOtherCodeCfg).OtherCode);
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_KeyPadCharV1) this).\u0001, str, "Exception", ex.Message);
      buException.throwException(ex, str, true);
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_KeyPadCharV1) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_KeyPadCharV1) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Contour() => F_KeyPadCharV1.Captions = new List<string>();

  public F_Contour()
  {
    ((F_KeyPadNumV1) this).Properties = new FormProperties();
    ((F_KeyPadNumV1) this).\u0001 = Color.LightBlue;
    ((F_KeyPadNumV1) this).\u0002 = Color.Gainsboro;
    ((F_KeyPadNumV1) this).Alingnment = ObjectAlignment.MiddleLeft;
    ((F_KeyPadNumV1) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ObjectLocation) this);
  }

  public void Init()
  {
    ((F_KeyPadNumV1) this).Properties.Inited = false;
    ((F_KeyPadNumV1) this).Properties.Result = DialogResult.None;
    this.TopMost = ((F_KeyPadNumV1) this).Properties.TopMost;
    this.StartPosition = ((F_KeyPadNumV1) this).Properties.FormPosition;
    this.AutoScaleMode = ((F_KeyPadNumV1) this).Properties.ScaleFromMode;
    if (((F_KeyPadNumV1) this).Properties.Height > 10)
      this.Height = ((F_KeyPadNumV1) this).Properties.Height;
    if (((F_KeyPadNumV1) this).Properties.Width > 10)
      this.Width = ((F_KeyPadNumV1) this).Properties.Width;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ObjectLocation) this);
    ((F_KeyPadNumV1) this).Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_KeyPadNumV1) this).btn_topleft.Name)
    {
      ((F_KeyPadNumV1) this).Alingnment = ObjectAlignment.TopLeft;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ObjectLocation) this);
      ((F_KeyPadNumV1) this).Properties.Result = DialogResult.OK;
    }
    if (control2.Name == ((F_KeyPadNumV1) this).btn_topcenter.Name)
    {
      ((F_KeyPadNumV1) this).Alingnment = ObjectAlignment.TopCenter;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ObjectLocation) this);
      ((F_KeyPadNumV1) this).Properties.Result = DialogResult.OK;
    }
    if (control2.Name == ((F_KeyPadNumV1) this).btn_topright.Name)
    {
      ((F_KeyPadNumV1) this).Alingnment = ObjectAlignment.TopRight;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ObjectLocation) this);
      ((F_KeyPadNumV1) this).Properties.Result = DialogResult.OK;
    }
    if (control2.Name == ((F_KeyPadNumV1) this).btn_middleleft.Name)
    {
      ((F_KeyPadNumV1) this).Alingnment = ObjectAlignment.MiddleLeft;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ObjectLocation) this);
      ((F_KeyPadNumV1) this).Properties.Result = DialogResult.OK;
    }
    if (control2.Name == ((F_KeyPadNumV1) this).btn_middlecenter.Name)
    {
      ((F_KeyPadNumV1) this).Alingnment = ObjectAlignment.MiddleCenter;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ObjectLocation) this);
      ((F_KeyPadNumV1) this).Properties.Result = DialogResult.OK;
    }
    if (control2.Name == ((F_KeyPadNumV1) this).btn_middleright.Name)
    {
      ((F_KeyPadNumV1) this).Alingnment = ObjectAlignment.MiddleRight;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ObjectLocation) this);
      ((F_KeyPadNumV1) this).Properties.Result = DialogResult.OK;
    }
    if (control2.Name == ((F_KeyPadNumV1) this).btn_bottomleft.Name)
    {
      ((F_KeyPadNumV1) this).Alingnment = ObjectAlignment.BottomLeft;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ObjectLocation) this);
      ((F_KeyPadNumV1) this).Properties.Result = DialogResult.OK;
    }
    if (control2.Name == ((F_KeyPadNumV1) this).btn_bottomcenter.Name)
    {
      ((F_KeyPadNumV1) this).Alingnment = ObjectAlignment.BottomCenter;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ObjectLocation) this);
      ((F_KeyPadNumV1) this).Properties.Result = DialogResult.OK;
    }
    if (control2.Name == ((F_KeyPadNumV1) this).btn_bottomright.Name)
    {
      ((F_KeyPadNumV1) this).Alingnment = ObjectAlignment.BottomRight;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ObjectLocation) this);
      ((F_KeyPadNumV1) this).Properties.Result = DialogResult.OK;
    }
    if (((F_KeyPadNumV1) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_KeyPadNumV1) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_KeyPadNumV1) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_KeyPadNumV1) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Contour() => F_KeyPadNumV1.Captions = new List<string>();

  public F_Contour()
  {
    ((F_CabinetSettings) this).Properties = new FormProperties();
    ((F_CabinetSettings) this).\u0001 = Color.LightBlue;
    ((F_CabinetSettings) this).\u0002 = Color.Gainsboro;
    ((F_CabinetSettings) this).Corner = CornerLocation.BottomCenter;
    ((F_CabinetSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_CornerLocation) this);
  }

  public void Init()
  {
    ((F_CabinetSettings) this).Properties.Inited = false;
    ((F_CabinetSettings) this).Properties.Result = DialogResult.None;
    this.TopMost = ((F_CabinetSettings) this).Properties.TopMost;
    this.StartPosition = ((F_CabinetSettings) this).Properties.FormPosition;
    this.AutoScaleMode = ((F_CabinetSettings) this).Properties.ScaleFromMode;
    if (((F_CabinetSettings) this).Properties.Height > 10)
      this.Height = ((F_CabinetSettings) this).Properties.Height;
    if (((F_CabinetSettings) this).Properties.Width > 10)
      this.Width = ((F_CabinetSettings) this).Properties.Width;
    \u0007.\u0001.\u0001((F_CornerLocation) this);
    ((F_CabinetSettings) this).Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_CabinetSettings) this).btn_topleft.Name)
    {
      ((F_CabinetSettings) this).Corner = CornerLocation.LeftTop;
      \u0007.\u0001.\u0001((F_CornerLocation) this);
      ((F_CabinetSettings) this).Properties.Result = DialogResult.OK;
    }
    if (control2.Name == ((F_CabinetSettings) this).btn_topcenter.Name)
    {
      ((F_CabinetSettings) this).Corner = CornerLocation.TopCenter;
      \u0007.\u0001.\u0001((F_CornerLocation) this);
      ((F_CabinetSettings) this).Properties.Result = DialogResult.OK;
    }
    if (control2.Name == ((F_CabinetSettings) this).btn_topright.Name)
    {
      ((F_CabinetSettings) this).Corner = CornerLocation.RightTop;
      \u0007.\u0001.\u0001((F_CornerLocation) this);
      ((F_CabinetSettings) this).Properties.Result = DialogResult.OK;
    }
    if (control2.Name == ((F_CabinetSettings) this).btn_middleleft.Name)
    {
      ((F_CabinetSettings) this).Corner = CornerLocation.LeftCenter;
      \u0007.\u0001.\u0001((F_CornerLocation) this);
      ((F_CabinetSettings) this).Properties.Result = DialogResult.OK;
    }
    if (control2.Name == ((F_CabinetSettings) this).btn_middleright.Name)
    {
      ((F_CabinetSettings) this).Corner = CornerLocation.RightCenter;
      \u0007.\u0001.\u0001((F_CornerLocation) this);
      ((F_CabinetSettings) this).Properties.Result = DialogResult.OK;
    }
    if (control2.Name == ((F_CabinetSettings) this).btn_bottomleft.Name)
    {
      ((F_CabinetSettings) this).Corner = CornerLocation.LeftBottom;
      \u0007.\u0001.\u0001((F_CornerLocation) this);
      ((F_CabinetSettings) this).Properties.Result = DialogResult.OK;
    }
    if (control2.Name == ((F_CabinetSettings) this).btn_bottomcenter.Name)
    {
      ((F_CabinetSettings) this).Corner = CornerLocation.BottomCenter;
      \u0007.\u0001.\u0001((F_CornerLocation) this);
      ((F_CabinetSettings) this).Properties.Result = DialogResult.OK;
    }
    if (control2.Name == ((F_CabinetSettings) this).btn_bottomright.Name)
    {
      ((F_CabinetSettings) this).Corner = CornerLocation.RightBottom;
      \u0007.\u0001.\u0001((F_CornerLocation) this);
      ((F_CabinetSettings) this).Properties.Result = DialogResult.OK;
    }
    if (((F_CabinetSettings) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_CabinetSettings) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CabinetSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CabinetSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Contour() => F_CabinetSettings.Captions = new List<string>();

  public F_Contour()
  {
    ((F_CabinetSettings) this).Properties = new FormProperties();
    ((F_CabinetSettings) this).Chars = new List<CharLibrary5>();
    ((F_CabinetSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_CharList) this);
  }

  public event OkCommandWithTwoDataEventHandler DataChanged;

  public event OkCommandWithTwoDataEventHandler DataOk;

  public event CancelCommandEventHandler DataCancel;
}
