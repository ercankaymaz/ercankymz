// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.TreeViewExtensions
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using ns8;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5;

public static class TreeViewExtensions
{
  public static bool IsCheckBoxVisible(this TreeNode node)
  {
    if (node == null)
      throw new ArgumentNullException(nameof (node));
    TreeViewExtensions.Struct7 struct7_0 = node.TreeView != null ? new TreeViewExtensions.Struct7()
    {
      intptr_0 = node.Handle,
      int_0 = 8
    } : throw new InvalidOperationException("The node does not belong to a tree.");
    if (Class5.SendMessage_1(node.TreeView.Handle, 4414, node.Handle, ref struct7_0) == IntPtr.Zero)
      throw new ApplicationException("Error getting TreeNode state.");
    return (struct7_0.int_1 & 61440 /*0xF000*/) >> 12 != 0;
  }

  public static void SetIsCheckBoxVisible(this TreeNode node, bool value)
  {
    if (node == null)
      throw new ArgumentNullException(nameof (node));
    if (node.TreeView == null)
      throw new InvalidOperationException("The node does not belong to a tree.");
    TreeViewExtensions.Struct7 struct7_0 = new TreeViewExtensions.Struct7()
    {
      intptr_0 = node.Handle,
      int_0 = 8,
      int_2 = 61440 /*0xF000*/,
      int_1 = (value ? (node.Checked ? 2 : 1) : 0) << 12
    };
    if (Class5.SendMessage_1(node.TreeView.Handle, 4415, IntPtr.Zero, ref struct7_0) == IntPtr.Zero)
      throw new ApplicationException("Error setting TreeNode state.");
  }

  [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
  internal struct Struct7
  {
    public int int_0;
    public IntPtr intptr_0;
    public int int_1;
    public int int_2;
    [MarshalAs(UnmanagedType.LPTStr)]
    public string string_0;
    public int int_3;
    public int int_4;
    public int int_5;
    public int int_6;
    public IntPtr intptr_1;
  }
}
