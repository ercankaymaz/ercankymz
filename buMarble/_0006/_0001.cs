// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buMarble;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace \u0006;

internal class \u0001
{
  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((\u0001.\u0003) this).btn_ok.Name)
      {
        ((\u000E.\u0001) this).Apply();
        ((\u0007.\u0001) this).PropertiesForm.Result = DialogResult.OK;
        if (((\u0007.\u0001) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        {
          // ISSUE: explicit non-virtual call
          __nonvirtual (((Component) this).Dispose());
        }
        if (((\u0007.\u0001) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          ((Control) this).Visible = false;
      }
      if (control2.Name == ((\u0001.\u0003) this).btn_close.Name | control2.Name == ((\u0001.\u0003) this).btn_cancel.Name)
      {
        ((\u0007.\u0001) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((\u0007.\u0001) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        {
          // ISSUE: explicit non-virtual call
          __nonvirtual (((Component) this).Dispose());
        }
        if (((\u0007.\u0001) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          ((Control) this).Visible = false;
      }
      if (!(control2.Name == ((\u0005.\u0001) this).btn_wagonparkgetpos.Name) || !AppBool.Connected)
        return;
      if (clsAppMarbleVars.varRuntime.AxX >= 0)
        ((\u0005.\u0001) this).spn_WagonUpPositionX.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxY >= 0)
        ((\u0005.\u0001) this).spn_WagonUpPositionY.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxZ >= 0)
        ((\u0005.\u0001) this).spn_WagonUpPositionZ.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxC >= 0)
        ((\u0004) this).spn_WagonUpPositionC.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxA < 0)
        return;
      ((\u0004) this).spn_WagonUpPositionA.Value = Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2);
    }
    catch (Exception ex)
    {
    }
  }
}
