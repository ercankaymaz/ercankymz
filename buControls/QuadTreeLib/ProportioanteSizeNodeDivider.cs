// Decompiled with JetBrains decompiler
// Type: QuadTreeLib.ProportioanteSizeNodeDivider
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using SourceGrid;

#nullable disable
namespace QuadTreeLib;

public class ProportioanteSizeNodeDivider : IQuadTreeNodeDivider
{
  private HalfSizeNodeDivider halfSizeNodeDivider_0 = new HalfSizeNodeDivider();

  public QuadTreeNode CreateNewRoot(QuadTreeNode currentRoot)
  {
    Range bounds = currentRoot.Bounds;
    int row = bounds.Start.Row;
    int column = bounds.Start.Column;
    int columnsCount = bounds.ColumnsCount;
    int rowsCount = bounds.RowsCount;
    int depth = currentRoot.Depth;
    QuadTree quadTree = currentRoot.QuadTree;
    return new QuadTreeNode(new Range(row, column, columnsCount * 2, rowsCount * 2), currentRoot.Depth, currentRoot.QuadTree)
    {
      Nodes = {
        currentRoot,
        new QuadTreeNode(Range.From(new Position(row, column + columnsCount), rowsCount, columnsCount), depth, quadTree),
        new QuadTreeNode(Range.From(new Position(row + rowsCount, column), rowsCount, columnsCount), depth, quadTree),
        new QuadTreeNode(Range.From(new Position(row + rowsCount, column + columnsCount), rowsCount, columnsCount), depth, quadTree)
      }
    };
  }

  public bool IsProportionate(QuadTreeNode node)
  {
    Range bounds = node.Bounds;
    int num = bounds.ColumnsCount * 2;
    bounds = node.Bounds;
    int rowsCount = bounds.RowsCount;
    return num >= rowsCount;
  }

  public void CreateSubNodes(QuadTreeNode parentNode)
  {
    Range bounds = parentNode.Bounds;
    int columnsCount = bounds.ColumnsCount;
    bounds = parentNode.Bounds;
    int rowsCount = bounds.RowsCount;
    if (columnsCount * rowsCount <= 10)
      return;
    if (!this.IsProportionate(parentNode))
      Class39.smethod_7(parentNode, this);
    else
      Class39.smethod_115(this, parentNode);
  }
}
