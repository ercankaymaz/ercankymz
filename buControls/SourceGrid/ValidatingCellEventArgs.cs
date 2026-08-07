// Decompiled with JetBrains decompiler
// Type: SourceGrid.ValidatingCellEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace SourceGrid;

public class ValidatingCellEventArgs : CellCancelEventArgs
{
  private object p_NewValue;

  public ValidatingCellEventArgs(CellContext pCellContext, object p_NewValue)
    : base(pCellContext)
  {
    this.p_NewValue = p_NewValue;
  }

  public object NewValue
  {
    get => this.p_NewValue;
    set => this.p_NewValue = value;
  }
}
