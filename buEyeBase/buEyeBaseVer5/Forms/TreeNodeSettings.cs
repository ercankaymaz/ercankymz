// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.TreeNodeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class TreeNodeSettings : TreeNode
{
  internal ToolStripSeparator \u0002;
  internal ToolStripMenuItem \u0006;

  protected virtual void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_NestSheetPartList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_NestSheetPartList) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }
}
