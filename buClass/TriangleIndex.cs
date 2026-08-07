// Decompiled with JetBrains decompiler
// Type: buClass.TriangleIndex
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class TriangleIndex
{
  public int V1 = 0;
  public int V2 = 0;
  public int V3 = 0;

  public TriangleIndex()
  {
  }

  public TriangleIndex(TriangleIndex index)
  {
    this.V1 = index.V1;
    this.V2 = index.V2;
    this.V3 = index.V3;
  }

  public TriangleIndex(int v1, int v2, int v3)
  {
    this.V1 = v1;
    this.V2 = v2;
    this.V3 = v3;
  }

  public static void Copy(List<TriangleIndex> pts, ref List<TriangleIndex> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new TriangleIndex(pts[index]));
  }

  public override string ToString()
  {
    return $"V1: {this.V1.ToString()} - V2: {this.V2.ToString()} - V3: {this.V3.ToString()}";
  }
}
