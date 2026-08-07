// Decompiled with JetBrains decompiler
// Type: QuadTreeLib.QuadTree
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid;
using System.Collections.Generic;

#nullable disable
namespace QuadTreeLib;

public class QuadTree
{
  private QuadTreeNode quadTreeNode_0;
  private Range rectangle;

  public IQuadTreeNodeDivider QuadTreeNodeDivider { get; set; }

  public Range Bounds => this.rectangle;

  public QuadTreeNode Root => this.quadTreeNode_0;

  public List<Range> Contents => this.Query(this.Bounds);

  public void Grow()
  {
    this.quadTreeNode_0 = this.QuadTreeNodeDivider.CreateNewRoot(this.quadTreeNode_0);
    this.rectangle = this.quadTreeNode_0.Bounds;
  }

  public QuadTree(int rows, int columns)
    : this(new Range(1, 1, rows, columns))
  {
  }

  public QuadTree(Range rectangle)
  {
    this.rectangle = rectangle;
    this.quadTreeNode_0 = new QuadTreeNode(this.rectangle, 0, this);
    this.QuadTreeNodeDivider = (IQuadTreeNodeDivider) new ProportioanteSizeNodeDivider();
  }

  public int Count => this.quadTreeNode_0.Count;

  public QuadTree Insert(Range item)
  {
    this.quadTreeNode_0.Insert(item);
    return this;
  }

  public QuadTree Remove(Range range)
  {
    this.quadTreeNode_0.Remove(range);
    return this;
  }

  public int MaxDepth => this.quadTreeNode_0.MaxDepth;

  public QuadTree Insert(IEnumerable<Range> items)
  {
    foreach (Range range in items)
      this.quadTreeNode_0.Insert(range);
    return this;
  }

  public List<Range> Query(Range area) => this.quadTreeNode_0.Query(area);

  public List<Range> Query(Position area) => this.quadTreeNode_0.Query(area);

  public Range? QueryFirst(Position area) => this.quadTreeNode_0.QueryFirst(area);

  public Range? QueryFirst(Range area) => this.quadTreeNode_0.QueryFirst(area);

  public void ForEach(QuadTree.QTAction action) => this.quadTreeNode_0.ForEach(action);

  public delegate void QTAction(QuadTreeNode obj);
}
