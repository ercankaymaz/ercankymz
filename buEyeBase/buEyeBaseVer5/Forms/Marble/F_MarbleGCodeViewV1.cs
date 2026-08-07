// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleGCodeViewV1
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Materials;
using devDept.Eyeshot.Entities;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleGCodeViewV1 : Form
{
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buGround buGround1;
  public buButton btn_pencil3AX;
  public buButton btn_flatland3AX;
  public buButton btn_constantZ3AX;
  public buButton btn_paralllelcut3AX;
  public buButton btn_sawveralrough;
  public buButton btn_sawhorizontalrough;
  public buButton btn_pocketbydrill;
  public buButton btn_5axisrotartmilling;
  public buButton btn_5axisflatmilling;
  public buButton btn_Rough3AX;
  public buButton btn_roughoutside;
  public buButton btn_surfaceclear;
  public buButton btn_sawveralfinis;
  public buButton btn_sawhorizontalfinish;

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_MarbleJobOPListV2.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleDrawV1) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleDrawV1) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleDrawV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleDrawV1) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_MarbleJobOPListV2) this).btn_ok.Name)
    {
      ((MostClosestPointOption) ((F_MarbleDrawV1) this).Material).Entities.Clear();
      for (int index = 0; index <= ((F_MarbleJobOPListV2) this).viewportLayout.Entities.Count - 1; ++index)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(((F_MarbleJobOPListV2) this).viewportLayout.Entities[index], ref copiedEnt);
        CustomData customData = (CustomData) new ClipperOffset();
        copiedEnt.EntityData = (object) customData;
        ((MostClosestPointOption) ((F_MarbleDrawV1) this).Material).Entities.Add(copiedEnt);
      }
      ((F_MarbleDrawV1) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_MarbleDrawV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleDrawV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_MarbleJobOPListV2) this).btn_cancel.Name))
      return;
    ((F_MarbleDrawV1) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleDrawV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleDrawV1) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  private void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    \u0007.\u0001.\u0001((F_MaterialRect2D) this);
    ((F_MarbleJobOPListV2) this).btn_ok.Enabled = true;
    ((F_MarbleJobOPListV2) this).\u0001.Enabled = false;
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
    ((SortResult) ((F_MarbleDrawV1) this).Material).Size.Width = (double) ((F_MarbleJobOPListV2) this).\u0001.Value;
    ((SortResult) ((F_MarbleDrawV1) this).Material).Size.Height = (double) ((F_MarbleJobOPListV2) this).\u0002.Value;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MarbleDrawV1) this).PropertiesForm.Inited)
      return;
    ((SortResult) ((F_MarbleDrawV1) this).Material).Size.Width = (double) ((F_MarbleJobOPListV2) this).\u0001.Value;
    ((SortResult) ((F_MarbleDrawV1) this).Material).Size.Height = (double) ((F_MarbleJobOPListV2) this).\u0002.Value;
    \u0007.\u0001.\u0001((F_MaterialRect2D) this);
    ((F_MarbleDrawV1) this).PropertiesForm.Inited = true;
  }

  public void FindFirstClamperPositions(
    double Width,
    double ClamperLength,
    ref double X1,
    ref double X2)
  {
    X2 = ClamperLength / 2.0;
    X1 = Width - ClamperLength / 2.0;
    if (X1 - X2 >= ClamperLength + 10.0)
      return;
    double num = ClamperLength + 10.0 - (X2 - X1);
    if (num <= 0.0)
      return;
    X2 += num / 2.0;
    X1 -= num / 2.0;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleJobOPListV2) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleJobOPListV2) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
