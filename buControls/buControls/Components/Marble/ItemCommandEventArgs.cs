// Decompiled with JetBrains decompiler
// Type: buControls.Components.Marble.ItemCommandEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using System;

#nullable disable
namespace buControls.Components.Marble;

[Serializable]
public class ItemCommandEventArgs
{
  public MarbleOperationMenuCommands Command = MarbleOperationMenuCommands.None;
  public int OperationIndex = -1;
  public bool Enable = false;
  public bool Selected = false;
  public int OperationID = -1;
  public int IndexControl = -1;

  public ItemCommandEventArgs()
  {
  }

  public ItemCommandEventArgs(
    MarbleOperationMenuCommands command,
    int operationIndex,
    bool enable,
    int operationID,
    int indexControl,
    bool selected)
  {
    this.Command = command;
    this.OperationIndex = operationIndex;
    this.Enable = enable;
    this.OperationID = operationID;
    this.IndexControl = indexControl;
    this.Selected = selected;
  }
}
