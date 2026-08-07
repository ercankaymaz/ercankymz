// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.SubButtonItemEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.Windows.Forms;

public class SubButtonItemEventArgs : EventArgs
{
  private SubButtonItem p_Item;

  public SubButtonItem ButtonItem
  {
    get => this.p_Item;
    set => this.p_Item = value;
  }

  public SubButtonItemEventArgs(SubButtonItem p_Item) => this.p_Item = p_Item;
}
