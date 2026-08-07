// Decompiled with JetBrains decompiler
// Type: ns2.Class22
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buMutliTextbox;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace ns2;

internal sealed class Class22
{
  internal bool bool_0;
  internal bool bool_1;
  internal bool bool_2;

  public Class22(Keys keys_1, FCTBAction fctbaction_1)
  {
    KeyEventArgs keyEventArgs = new KeyEventArgs(keys_1);
    this.bool_0 = keyEventArgs.Control;
    this.bool_1 = keyEventArgs.Shift;
    this.bool_2 = keyEventArgs.Alt;
    this.method_1(keyEventArgs.KeyCode);
    this.method_3(fctbaction_1);
  }

  [CompilerGenerated]
  [SpecialName]
  public Keys method_0() => this.keys_0;

  [CompilerGenerated]
  [SpecialName]
  public void method_1(Keys keys_1) => this.keys_0 = keys_1;

  [CompilerGenerated]
  [SpecialName]
  public FCTBAction method_2() => this.fctbaction_0;

  [CompilerGenerated]
  [SpecialName]
  public void method_3(FCTBAction fctbaction_1) => this.fctbaction_0 = fctbaction_1;
}
