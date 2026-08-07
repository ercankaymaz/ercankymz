// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buMW.CamForms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace \u0006;

internal class \u0001
{
  internal Button \u0001;
  internal CheckBox \u0002;
  public ComboBox combo_direction;

  protected virtual void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_StockDef) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_StockDef) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }

  static \u0001() => F_StockDef.Captions = new List<string>();

  public \u0001()
    : this()
  {
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
    internal Label \u0008;
    public CheckBox chk_stovkhasundercut;
    public Panel pnl_area;
    internal CheckBox \u0003;

    public \u0001() => ((object) ref this).\u002Ector();

    [SpecialName]
    internal static bool \u0001()
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
}
