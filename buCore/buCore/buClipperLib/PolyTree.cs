// Decompiled with JetBrains decompiler
// Type: buCore.buClipperLib.PolyTree
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System.Collections.Generic;

#nullable disable
namespace buCore.buClipperLib;

public class PolyTree : PolyNode
{
  internal List<PolyNode> list_2 = new List<PolyNode>();

  public void Clear()
  {
    for (int index = 0; index < this.list_2.Count; ++index)
      this.list_2[index] = (PolyNode) null;
    this.list_2.Clear();
    this.list_1.Clear();
  }

  public PolyNode GetFirst() => this.list_1.Count <= 0 ? (PolyNode) null : this.list_1[0];

  public int Total
  {
    get
    {
      int count = this.list_2.Count;
      if ((count <= 0 ? 0 : (this.list_1[0] != this.list_2[0] ? 1 : 0)) != 0)
        --count;
      return count;
    }
  }
}
