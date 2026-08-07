// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.SimpleLookupTable
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC;

public class SimpleLookupTable : AbstractECLookupTable
{
  private readonly ECPoint[] points;

  private static ECPoint[] Copy(ECPoint[] points, int off, int len)
  {
    ECPoint[] ecPointArray = new ECPoint[len];
    for (int index = 0; index < len; ++index)
      ecPointArray[index] = points[off + index];
    return ecPointArray;
  }

  public SimpleLookupTable(ECPoint[] points, int off, int len)
  {
    this.points = SimpleLookupTable.Copy(points, off, len);
  }

  public override int Size => this.points.Length;

  public override ECPoint Lookup(int index)
  {
    throw new NotSupportedException("Constant-time lookup not supported");
  }

  public override ECPoint LookupVar(int index) => this.points[index];
}
