// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.DataTableItem
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class DataTableItem : DataTable
{
  internal ToolStripMenuItem \u0005;

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_NestSheetPartList) this).PropertiesForm.Inited)
      return;
    buNestingVar Settings = (buNestingVar) new ProfileOperationDataBarel(((F_NestSheetPartList) this).Settings);
    ((ProfileOperationCamData) ((ProfileMultiply) Settings).Draw).PartInnerShow = ((F_NestSheetPartList) this).\u0001.Checked;
    buCall.\u0001.DrawPart(((F_NestSheetPartList) this).Part, Settings, ref ((F_NestSheetPartList) this).\u0001);
  }
}
