// Decompiled with JetBrains decompiler
// Type: buCore.buClipperLib.MyIntersectNodeSort
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System.Collections.Generic;

#nullable disable
namespace buCore.buClipperLib;

public class MyIntersectNodeSort : IComparer<IntersectNode>
{
  public int Compare(IntersectNode node1, IntersectNode node2)
  {
    long num = node2.intPoint_0.Y - node1.intPoint_0.Y;
    return num <= 0L ? (num >= 0L ? 0 : -1) : 1;
  }
}
