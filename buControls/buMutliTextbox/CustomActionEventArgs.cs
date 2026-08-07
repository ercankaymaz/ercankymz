// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.CustomActionEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace buMutliTextbox;

public class CustomActionEventArgs : EventArgs
{
  public FCTBAction Action { get; private set; }

  public CustomActionEventArgs(FCTBAction action) => this.Action = action;
}
