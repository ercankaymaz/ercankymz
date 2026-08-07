// Decompiled with JetBrains decompiler
// Type: buCore.buClipperLib.IntRect
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

#nullable disable
namespace buCore.buClipperLib;

public struct IntRect
{
  public long left;
  public long top;
  public long right;
  public long bottom;

  public IntRect(long l, long t, long r, long b)
  {
    this.left = l;
    this.top = t;
    this.right = r;
    this.bottom = b;
  }

  public IntRect(IntRect ir)
  {
    this.left = ir.left;
    this.top = ir.top;
    this.right = ir.right;
    this.bottom = ir.bottom;
  }
}
