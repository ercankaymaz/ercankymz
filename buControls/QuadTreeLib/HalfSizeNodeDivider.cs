// Decompiled with JetBrains decompiler
// Type: QuadTreeLib.HalfSizeNodeDivider
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid;

#nullable disable
namespace QuadTreeLib;

public class HalfSizeNodeDivider : IQuadTreeNodeDivider
{
  public QuadTreeNode CreateNewRoot(QuadTreeNode currentRoot)
  {
    return new ProportioanteSizeNodeDivider().CreateNewRoot(currentRoot);
  }

  public void CreateSubNodes(QuadTreeNode parentNode)
  {
    Range bounds1 = parentNode.Bounds;
    Range bounds2 = parentNode.Bounds;
    int columnsCount = bounds2.ColumnsCount;
    bounds2 = parentNode.Bounds;
    int rowsCount = bounds2.RowsCount;
    if (columnsCount * rowsCount <= 10)
      return;
    int row = bounds1.Start.Row;
    int column = bounds1.Start.Column;
    int colCount = bounds1.ColumnsCount / 2;
    int rowCount = bounds1.RowsCount / 2;
    int depth = parentNode.Depth;
    QuadTree quadTree = parentNode.QuadTree;
    parentNode.Nodes.Add(new QuadTreeNode(Range.From(bounds1.Start, rowCount, colCount), depth, quadTree));
    parentNode.Nodes.Add(new QuadTreeNode(Range.From(new Position(row, column + colCount), rowCount, colCount), depth, quadTree));
    parentNode.Nodes.Add(new QuadTreeNode(Range.From(new Position(row + rowCount, column), rowCount, colCount), depth, quadTree));
    parentNode.Nodes.Add(new QuadTreeNode(Range.From(new Position(row + rowCount, column + colCount), rowCount, colCount), depth, quadTree));
  }
}
