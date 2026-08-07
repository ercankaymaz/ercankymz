// Decompiled with JetBrains decompiler
// Type: QuadTreeLib.QuadTreeNode
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid;
using System;
using System.Collections.Generic;

#nullable disable
namespace QuadTreeLib;

public class QuadTreeNode
{
  private Range bounds;
  private List<Range> list_0 = new List<Range>();
  private List<QuadTreeNode> list_1 = new List<QuadTreeNode>(4);

  public int Depth { get; set; }

  public QuadTree QuadTree { get; set; }

  public List<QuadTreeNode> Nodes => this.list_1;

  public QuadTreeNode(Range bounds) => this.bounds = bounds;

  public QuadTreeNode(Range bounds, int currentDepth, QuadTree quadTree)
    : this(bounds)
  {
    this.bounds = bounds;
    this.QuadTree = quadTree;
    this.Depth = currentDepth + 1;
  }

  public bool IsEmpty => this.list_1.Count == 0 && this.list_0.Count == 0;

  public Range Bounds => this.bounds;

  public int MaxDepth
  {
    get
    {
      int maxDepth1 = this.Depth;
      foreach (QuadTreeNode quadTreeNode in this.list_1)
      {
        int maxDepth2 = quadTreeNode.MaxDepth;
        if (maxDepth2 > maxDepth1)
          maxDepth1 = maxDepth2;
      }
      return maxDepth1;
    }
  }

  public int Count
  {
    get
    {
      int num = 0;
      foreach (QuadTreeNode quadTreeNode in this.list_1)
        num += quadTreeNode.Count;
      return num + this.Contents.Count;
    }
  }

  public List<Range> SubTreeContents
  {
    get
    {
      List<Range> subTreeContents = new List<Range>();
      foreach (QuadTreeNode quadTreeNode in this.list_1)
        subTreeContents.AddRange((IEnumerable<Range>) quadTreeNode.SubTreeContents);
      subTreeContents.AddRange((IEnumerable<Range>) this.Contents);
      return subTreeContents;
    }
  }

  public List<Range> Contents => this.list_0;

  public List<Range> Query(Range queryArea) => this.QueryInternal(queryArea, false);

  public Range? QueryFirst(Range queryArea)
  {
    List<Range> rangeList = this.QueryInternal(queryArea, true);
    return rangeList.Count != 0 ? new Range?(rangeList[0]) : new Range?();
  }

  public List<Range> QueryInternal(Range queryArea, bool stopOnFirst)
  {
    List<Range> rangeList1 = new List<Range>();
    List<Range> rangeList2;
    foreach (Range content in this.Contents)
    {
      if (queryArea.IntersectsWith(content))
      {
        rangeList1.Add(content);
        if (stopOnFirst)
        {
          rangeList2 = rangeList1;
          goto label_19;
        }
      }
    }
    foreach (QuadTreeNode quadTreeNode in this.list_1)
    {
      if (!quadTreeNode.IsEmpty)
      {
        if (!quadTreeNode.Bounds.Contains(queryArea))
        {
          if (queryArea.Contains(quadTreeNode.Bounds))
            rangeList1.AddRange((IEnumerable<Range>) quadTreeNode.SubTreeContents);
          else if (quadTreeNode.Bounds.IntersectsWith(queryArea))
            rangeList1.AddRange((IEnumerable<Range>) quadTreeNode.QueryInternal(queryArea, stopOnFirst));
        }
        else
        {
          rangeList1.AddRange((IEnumerable<Range>) quadTreeNode.QueryInternal(queryArea, stopOnFirst));
          break;
        }
      }
    }
    rangeList2 = rangeList1;
label_19:
    return rangeList2;
  }

  public List<Range> Query(Position queryArea)
  {
    List<Range> rangeList = new List<Range>();
    foreach (Range content in this.Contents)
    {
      if (content.Contains(queryArea))
        rangeList.Add(content);
    }
    foreach (QuadTreeNode quadTreeNode in this.list_1)
    {
      if (!quadTreeNode.IsEmpty && quadTreeNode.Bounds.Contains(queryArea))
      {
        rangeList.AddRange((IEnumerable<Range>) quadTreeNode.Query(queryArea));
        break;
      }
    }
    return rangeList;
  }

  public Range? QueryFirst(Position queryArea)
  {
    Range? nullable;
    foreach (Range content in this.Contents)
    {
      if (content.Contains(queryArea))
      {
        nullable = new Range?(content);
        goto label_13;
      }
    }
    foreach (QuadTreeNode quadTreeNode in this.list_1)
    {
      if (!quadTreeNode.IsEmpty && quadTreeNode.Bounds.Contains(queryArea))
      {
        nullable = quadTreeNode.QueryFirst(queryArea);
        goto label_13;
      }
    }
    nullable = new Range?();
label_13:
    return nullable;
  }

  public bool Remove(Range range)
  {
    if (!this.bounds.Contains(range))
      throw new ArgumentException("range is out of the bounds of this quadtree node");
    bool flag;
    foreach (QuadTreeNode quadTreeNode in this.list_1)
    {
      if (quadTreeNode.Bounds.Contains(range))
      {
        flag = quadTreeNode.Remove(range);
        goto label_14;
      }
    }
    for (int index = 0; index < this.Contents.Count; ++index)
    {
      if (this.Contents[index].Equals(range))
      {
        this.Contents.RemoveAt(index);
        flag = true;
        goto label_14;
      }
    }
    flag = false;
label_14:
    return flag;
  }

  public void Insert(Range item)
  {
    if (!this.bounds.Contains(item))
      throw new ArgumentException("range is out of the bounds of this quadtree node");
    if (this.list_1.Count == 0)
      this.QuadTree.QuadTreeNodeDivider.CreateSubNodes(this);
    foreach (QuadTreeNode quadTreeNode in this.list_1)
    {
      if (quadTreeNode.Bounds.Contains(item))
      {
        quadTreeNode.Insert(item);
        return;
      }
    }
    this.Contents.Add(item);
  }

  public void ForEach(QuadTree.QTAction action)
  {
    action(this);
    foreach (QuadTreeNode quadTreeNode in this.list_1)
      quadTreeNode.ForEach(action);
  }
}
