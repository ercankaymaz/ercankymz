// Decompiled with JetBrains decompiler
// Type: SourceGrid.ChangeActivePositionEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.ComponentModel;

#nullable disable
namespace SourceGrid;

public class ChangeActivePositionEventArgs : CancelEventArgs
{
  private Position pOldFocusPosition;
  private Position pNewFocusPosition;

  public ChangeActivePositionEventArgs(Position pOldFocusPosition, Position pNewFocusPosition)
    : base(false)
  {
    this.pOldFocusPosition = pOldFocusPosition;
    this.pNewFocusPosition = pNewFocusPosition;
  }

  public Position OldFocusPosition => this.pOldFocusPosition;

  public Position NewFocusPosition => this.pNewFocusPosition;
}
