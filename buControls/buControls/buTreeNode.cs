// Decompiled with JetBrains decompiler
// Type: buControls.buTreeNode
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Windows.Forms;

#nullable disable
namespace buControls;

public class buTreeNode : TreeNode
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
  public string Info = "";
  public string ParentName = "";
  public int OldImageIndex = -1;
  public int NodeIndex = -1;

  public buTreeNode()
  {
  }

  public buTreeNode(string NodeText) => this.Text = NodeText;
}
