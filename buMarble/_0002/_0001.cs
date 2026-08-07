// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace \u0002;

internal class \u0001
{
  public buSpin spn_toollowerradius;
  public buSpin spn_toolcuttinglen;
  public buSpin spn_toollength;

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buNumeric5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  protected virtual void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((\u0007.\u0001) this).\u0001 != null ? 1 : 0)) != 0)
      ((\u0007.\u0001) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }

  internal static bool IsWebApplication
  {
    [SpecialName] get
    {
      try
      {
        switch (Process.GetCurrentProcess().MainModule.ModuleName.ToLower())
        {
          case "w3wp.exe":
            return true;
          case "aspnet_wp.exe":
            return true;
        }
      }
      catch
      {
      }
      return false;
    }
  }

  internal struct \u0001
  {
    public buSpin spn_tooldia;
    internal Panel \u0001;
    internal buTextBox \u0001;
    public Panel pnl_preview;

    static \u0001() => \u0003.\u0001.Captions = new List<string>();

    public \u0001() => ((Attribute) ref this).\u002Ector();
  }
}
