// Decompiled with JetBrains decompiler
// Type: buCore.buClipperLib.PolyNode
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using System.Collections.Generic;

#nullable disable
namespace buCore.buClipperLib;

public class PolyNode
{
  internal PolyNode polyNode_0;
  internal List<IntPoint> list_0 = new List<IntPoint>();
  internal int int_0;
  internal JoinType joinType_0;
  internal EndType endType_0;
  internal List<PolyNode> list_1 = new List<PolyNode>();

  public int ChildCount => this.list_1.Count;

  public List<IntPoint> Contour => this.list_0;

  public PolyNode GetNext() => this.list_1.Count <= 0 ? Class30.smethod_77(this) : this.list_1[0];

  public List<PolyNode> Childs => this.list_1;

  public PolyNode Parent => this.polyNode_0;

  public bool IsHole => Class30.smethod_4(this);

  public bool IsOpen { get; set; }
}
