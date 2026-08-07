// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Multiplier.FixedPointUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Math.EC.Multiplier;

public class FixedPointUtilities
{
  public static readonly string PRECOMP_NAME = "bc_fixed_point";

  public static int GetCombSize(ECCurve c)
  {
    BigInteger order = c.Order;
    return order != null ? order.BitLength : c.FieldSize + 1;
  }

  public static FixedPointPreCompInfo GetFixedPointPreCompInfo(PreCompInfo preCompInfo)
  {
    return preCompInfo as FixedPointPreCompInfo;
  }

  public static FixedPointPreCompInfo Precompute(ECPoint p)
  {
    return (FixedPointPreCompInfo) p.Curve.Precompute(p, FixedPointUtilities.PRECOMP_NAME, (IPreCompCallback) new FixedPointUtilities.FixedPointCallback(p));
  }

  private class FixedPointCallback : IPreCompCallback
  {
    private readonly ECPoint m_p;

    internal FixedPointCallback(ECPoint p) => this.m_p = p;

    public PreCompInfo Precompute(PreCompInfo existing)
    {
      FixedPointPreCompInfo existingFP = existing as FixedPointPreCompInfo;
      ECCurve curve = this.m_p.Curve;
      int combSize = FixedPointUtilities.GetCombSize(curve);
      int index1 = combSize > 250 ? 6 : 5;
      int n = 1 << index1;
      if (this.CheckExisting(existingFP, n))
        return (PreCompInfo) existingFP;
      int e = (combSize + index1 - 1) / index1;
      ECPoint[] points1 = new ECPoint[index1 + 1];
      points1[0] = this.m_p;
      for (int index2 = 1; index2 < index1; ++index2)
        points1[index2] = points1[index2 - 1].TimesPow2(e);
      points1[index1] = points1[0].Subtract(points1[1]);
      curve.NormalizeAll(points1);
      ECPoint[] points2 = new ECPoint[n];
      points2[0] = points1[0];
      for (int index3 = index1 - 1; index3 >= 0; --index3)
      {
        ECPoint b = points1[index3];
        int num = 1 << index3;
        for (int index4 = num; index4 < n; index4 += num << 1)
          points2[index4] = points2[index4 - num].Add(b);
      }
      curve.NormalizeAll(points2);
      return (PreCompInfo) new FixedPointPreCompInfo()
      {
        LookupTable = curve.CreateCacheSafeLookupTable(points2, 0, points2.Length),
        Offset = points1[index1],
        Width = index1
      };
    }

    private bool CheckExisting(FixedPointPreCompInfo existingFP, int n)
    {
      return existingFP != null && this.CheckTable(existingFP.LookupTable, n);
    }

    private bool CheckTable(ECLookupTable table, int n) => table != null && table.Size >= n;
  }
}
