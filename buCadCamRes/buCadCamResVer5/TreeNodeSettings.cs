// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.TreeNodeSettings
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5;

public class TreeNodeSettings : TreeNode
{
  public int ClassIndex = -1;
  public int ClassSubIndex = -1;
  public int ClassSubSubIndex = -1;
  public int ClassSubSubSubIndex = -1;
  public int ClassSubSubSubSubIndex = -1;
  public int ClassSubSubSubSubSubIndex = -1;
  public int ClassSubSubSubSubSubSubIndex = -1;
  public int ClassSubSubSubSubSubSubSubIndex = -1;
  public int ClassSubSubSubSubSubSubSubSubIndex = -1;
  public int ClassSubSubSubSubSubSubSubSubSubIndex = -1;
  public string Command = "";
  public string Name = "";
  public string Info = "";
  public int Index = -1;
  public int OldImageIndex = -1;

  public TreeNodeSettings()
  {
  }

  public TreeNodeSettings(string NodeText) => this.Text = NodeText;
}
