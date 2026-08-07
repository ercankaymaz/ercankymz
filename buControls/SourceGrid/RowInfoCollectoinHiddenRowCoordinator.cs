// Decompiled with JetBrains decompiler
// Type: SourceGrid.RowInfoCollectoinHiddenRowCoordinator
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace SourceGrid;

public class RowInfoCollectoinHiddenRowCoordinator : StandardHiddenRowCoordinator
{
  public RowInfoCollectoinHiddenRowCoordinator(RowInfoCollection rows)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    RowInfoCollectoinHiddenRowCoordinator.Class29 class29 = new RowInfoCollectoinHiddenRowCoordinator.Class29();
    // ISSUE: reference to a compiler-generated field
    class29.rowInfoCollection_0 = rows;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: explicit constructor call
    base.\u002Ector((RowsBase) class29.rowInfoCollection_0);
    // ISSUE: reference to a compiler-generated field
    class29.rowInfoCollectoinHiddenRowCoordinator_0 = this;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    class29.rowInfoCollection_0.RowsRemoving += new IndexRangeEventHandler(class29.method_0);
  }
}
