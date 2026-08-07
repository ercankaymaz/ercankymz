// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Delaunay.Sweep.DTSweepBasin
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

#nullable disable
namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class DTSweepBasin
{
  public AdvancingFrontNode LeftNode;
  public AdvancingFrontNode BottomNode;
  public AdvancingFrontNode RightNode;
  public double Width;
  public bool LeftHighest;
}
