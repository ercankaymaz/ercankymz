// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.ECCurve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Endo;
using Org.BouncyCastle.Math.EC.Multiplier;
using Org.BouncyCastle.Math.Field;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Math.EC;

public abstract class ECCurve
{
  public const int COORD_AFFINE = 0;
  public const int COORD_HOMOGENEOUS = 1;
  public const int COORD_JACOBIAN = 2;
  public const int COORD_JACOBIAN_CHUDNOVSKY = 3;
  public const int COORD_JACOBIAN_MODIFIED = 4;
  public const int COORD_LAMBDA_AFFINE = 5;
  public const int COORD_LAMBDA_PROJECTIVE = 6;
  public const int COORD_SKEWED = 7;
  protected readonly IFiniteField m_field;
  protected ECFieldElement m_a;
  protected ECFieldElement m_b;
  protected BigInteger m_order;
  protected BigInteger m_cofactor;
  protected int m_coord;
  protected ECEndomorphism m_endomorphism;
  protected ECMultiplier m_multiplier;
  private IDictionary<string, PreCompInfo> m_preCompTable;

  public static int[] GetAllCoordinateSystems()
  {
    return new int[8]{ 0, 1, 2, 3, 4, 5, 6, 7 };
  }

  protected ECCurve(IFiniteField field) => this.m_field = field;

  public abstract int FieldSize { get; }

  public abstract ECFieldElement FromBigInteger(BigInteger x);

  public abstract bool IsValidFieldElement(BigInteger x);

  public abstract ECFieldElement RandomFieldElement(SecureRandom r);

  public abstract ECFieldElement RandomFieldElementMult(SecureRandom r);

  public virtual ECCurve.Config Configure()
  {
    return new ECCurve.Config(this, this.m_coord, this.m_endomorphism, this.m_multiplier);
  }

  public virtual ECPoint ValidatePoint(BigInteger x, BigInteger y)
  {
    ECPoint point = this.CreatePoint(x, y);
    return point.IsValid() ? point : throw new ArgumentException("Invalid point coordinates");
  }

  public virtual ECPoint CreatePoint(BigInteger x, BigInteger y)
  {
    return this.CreateRawPoint(this.FromBigInteger(x), this.FromBigInteger(y));
  }

  protected abstract ECCurve CloneCurve();

  protected internal abstract ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y);

  protected internal abstract ECPoint CreateRawPoint(
    ECFieldElement x,
    ECFieldElement y,
    ECFieldElement[] zs);

  protected virtual ECMultiplier CreateDefaultMultiplier()
  {
    return this.m_endomorphism is GlvEndomorphism endomorphism ? (ECMultiplier) new GlvMultiplier(this, endomorphism) : (ECMultiplier) new WNafL2RMultiplier();
  }

  public virtual bool SupportsCoordinateSystem(int coord) => coord == 0;

  public virtual PreCompInfo GetPreCompInfo(ECPoint point, string name)
  {
    this.CheckPoint(point);
    IDictionary<string, PreCompInfo> preCompTable;
    lock (point)
      preCompTable = point.m_preCompTable;
    if (preCompTable == null)
      return (PreCompInfo) null;
    lock (preCompTable)
    {
      PreCompInfo preCompInfo;
      return preCompTable.TryGetValue(name, out preCompInfo) ? preCompInfo : (PreCompInfo) null;
    }
  }

  internal virtual PreCompInfo Precompute(string name, IPreCompCallback callback)
  {
    IDictionary<string, PreCompInfo> dictionary;
    lock (this)
    {
      dictionary = this.m_preCompTable;
      if (dictionary == null)
        this.m_preCompTable = dictionary = (IDictionary<string, PreCompInfo>) new Dictionary<string, PreCompInfo>();
    }
    lock (dictionary)
    {
      PreCompInfo preCompInfo1;
      PreCompInfo existing = dictionary.TryGetValue(name, out preCompInfo1) ? preCompInfo1 : (PreCompInfo) null;
      PreCompInfo preCompInfo2 = callback.Precompute(existing);
      if (preCompInfo2 != existing)
        dictionary[name] = preCompInfo2;
      return preCompInfo2;
    }
  }

  public virtual PreCompInfo Precompute(ECPoint point, string name, IPreCompCallback callback)
  {
    this.CheckPoint(point);
    IDictionary<string, PreCompInfo> dictionary;
    lock (point)
    {
      dictionary = point.m_preCompTable;
      if (dictionary == null)
        point.m_preCompTable = dictionary = (IDictionary<string, PreCompInfo>) new Dictionary<string, PreCompInfo>();
    }
    lock (dictionary)
    {
      PreCompInfo preCompInfo1;
      PreCompInfo existing = dictionary.TryGetValue(name, out preCompInfo1) ? preCompInfo1 : (PreCompInfo) null;
      PreCompInfo preCompInfo2 = callback.Precompute(existing);
      if (preCompInfo2 != existing)
        dictionary[name] = preCompInfo2;
      return preCompInfo2;
    }
  }

  public virtual ECPoint ImportPoint(ECPoint p)
  {
    if (this == p.Curve)
      return p;
    if (p.IsInfinity)
      return this.Infinity;
    p = p.Normalize();
    return this.CreatePoint(p.XCoord.ToBigInteger(), p.YCoord.ToBigInteger());
  }

  public virtual void NormalizeAll(ECPoint[] points)
  {
    this.NormalizeAll(points, 0, points.Length, (ECFieldElement) null);
  }

  public virtual void NormalizeAll(ECPoint[] points, int off, int len, ECFieldElement iso)
  {
    this.CheckPoints(points, off, len);
    switch (this.CoordinateSystem)
    {
      case 0:
      case 5:
        if (iso == null)
          break;
        throw new ArgumentException("not valid for affine coordinates", nameof (iso));
      default:
        ECFieldElement[] zs = new ECFieldElement[len];
        int[] numArray = new int[len];
        int len1 = 0;
        for (int index = 0; index < len; ++index)
        {
          ECPoint point = points[off + index];
          if (point != null && (iso != null || !point.IsNormalized()))
          {
            zs[len1] = point.GetZCoord(0);
            numArray[len1++] = off + index;
          }
        }
        if (len1 == 0)
          break;
        ECAlgorithms.MontgomeryTrick(zs, 0, len1, iso);
        for (int index1 = 0; index1 < len1; ++index1)
        {
          int index2 = numArray[index1];
          points[index2] = points[index2].Normalize(zs[index1]);
        }
        break;
    }
  }

  public abstract ECPoint Infinity { get; }

  public virtual IFiniteField Field => this.m_field;

  public virtual ECFieldElement A => this.m_a;

  public virtual ECFieldElement B => this.m_b;

  public virtual BigInteger Order => this.m_order;

  public virtual BigInteger Cofactor => this.m_cofactor;

  public virtual int CoordinateSystem => this.m_coord;

  public virtual ECLookupTable CreateCacheSafeLookupTable(ECPoint[] points, int off, int len)
  {
    int num1 = (this.FieldSize + 7) / 8;
    byte[] numArray = new byte[len * num1 * 2];
    int num2 = 0;
    for (int index = 0; index < len; ++index)
    {
      ECPoint point = points[off + index];
      byte[] byteArray1 = point.RawXCoord.ToBigInteger().ToByteArray();
      byte[] byteArray2 = point.RawYCoord.ToBigInteger().ToByteArray();
      int sourceIndex1 = byteArray1.Length > num1 ? 1 : 0;
      int length1 = byteArray1.Length - sourceIndex1;
      int sourceIndex2 = byteArray2.Length > num1 ? 1 : 0;
      int length2 = byteArray2.Length - sourceIndex2;
      Array.Copy((Array) byteArray1, sourceIndex1, (Array) numArray, num2 + num1 - length1, length1);
      int num3 = num2 + num1;
      Array.Copy((Array) byteArray2, sourceIndex2, (Array) numArray, num3 + num1 - length2, length2);
      num2 = num3 + num1;
    }
    return (ECLookupTable) new ECCurve.DefaultLookupTable(this, numArray, len);
  }

  protected virtual void CheckPoint(ECPoint point)
  {
    if (point == null || this != point.Curve)
      throw new ArgumentException("must be non-null and on this curve", nameof (point));
  }

  protected virtual void CheckPoints(ECPoint[] points)
  {
    this.CheckPoints(points, 0, points.Length);
  }

  protected virtual void CheckPoints(ECPoint[] points, int off, int len)
  {
    if (points == null)
      throw new ArgumentNullException(nameof (points));
    if (off < 0 || len < 0 || off > points.Length - len)
      throw new ArgumentException("invalid range specified", nameof (points));
    for (int index = 0; index < len; ++index)
    {
      ECPoint point = points[off + index];
      if (point != null && this != point.Curve)
        throw new ArgumentException("entries must be null or on this curve", nameof (points));
    }
  }

  public virtual bool Equals(ECCurve other)
  {
    if (this == other)
      return true;
    return other != null && this.Field.Equals((object) other.Field) && this.A.ToBigInteger().Equals(other.A.ToBigInteger()) && this.B.ToBigInteger().Equals(other.B.ToBigInteger());
  }

  public override bool Equals(object obj) => this.Equals(obj as ECCurve);

  public override int GetHashCode()
  {
    return this.Field.GetHashCode() ^ Integers.RotateLeft(this.A.ToBigInteger().GetHashCode(), 8) ^ Integers.RotateLeft(this.B.ToBigInteger().GetHashCode(), 16 /*0x10*/);
  }

  protected abstract ECPoint DecompressPoint(int yTilde, BigInteger X1);

  public virtual ECEndomorphism GetEndomorphism() => this.m_endomorphism;

  public virtual ECMultiplier GetMultiplier()
  {
    if (this.m_multiplier == null)
      this.m_multiplier = this.CreateDefaultMultiplier();
    return this.m_multiplier;
  }

  public virtual ECPoint DecodePoint(byte[] encoded)
  {
    int length = (this.FieldSize + 7) / 8;
    byte num = encoded[0];
    ECPoint ecPoint;
    switch (num)
    {
      case 0:
        if (encoded.Length != 1)
          throw new ArgumentException("Incorrect length for infinity encoding", nameof (encoded));
        ecPoint = this.Infinity;
        break;
      case 2:
      case 3:
        if (encoded.Length != length + 1)
          throw new ArgumentException("Incorrect length for compressed encoding", nameof (encoded));
        ecPoint = this.DecompressPoint((int) num & 1, new BigInteger(1, encoded, 1, length));
        if (!ecPoint.ImplIsValid(true, true))
          throw new ArgumentException("Invalid point");
        break;
      case 4:
        if (encoded.Length != 2 * length + 1)
          throw new ArgumentException("Incorrect length for uncompressed encoding", nameof (encoded));
        ecPoint = this.ValidatePoint(new BigInteger(1, encoded, 1, length), new BigInteger(1, encoded, 1 + length, length));
        break;
      case 6:
      case 7:
        if (encoded.Length != 2 * length + 1)
          throw new ArgumentException("Incorrect length for hybrid encoding", nameof (encoded));
        BigInteger x = new BigInteger(1, encoded, 1, length);
        BigInteger y = new BigInteger(1, encoded, 1 + length, length);
        ecPoint = y.TestBit(0) == (num == (byte) 7) ? this.ValidatePoint(x, y) : throw new ArgumentException("Inconsistent Y coordinate in hybrid encoding", nameof (encoded));
        break;
      default:
        throw new FormatException("Invalid point encoding " + num.ToString());
    }
    if (num != (byte) 0 && ecPoint.IsInfinity)
      throw new ArgumentException("Invalid infinity encoding", nameof (encoded));
    return ecPoint;
  }

  public class Config
  {
    protected ECCurve outer;
    protected int coord;
    protected ECEndomorphism endomorphism;
    protected ECMultiplier multiplier;

    internal Config(
      ECCurve outer,
      int coord,
      ECEndomorphism endomorphism,
      ECMultiplier multiplier)
    {
      this.outer = outer;
      this.coord = coord;
      this.endomorphism = endomorphism;
      this.multiplier = multiplier;
    }

    public ECCurve.Config SetCoordinateSystem(int coord)
    {
      this.coord = coord;
      return this;
    }

    public ECCurve.Config SetEndomorphism(ECEndomorphism endomorphism)
    {
      this.endomorphism = endomorphism;
      return this;
    }

    public ECCurve.Config SetMultiplier(ECMultiplier multiplier)
    {
      this.multiplier = multiplier;
      return this;
    }

    public ECCurve Create()
    {
      ECCurve ecCurve = this.outer.SupportsCoordinateSystem(this.coord) ? this.outer.CloneCurve() : throw new InvalidOperationException("unsupported coordinate system");
      if (ecCurve == this.outer)
        throw new InvalidOperationException("implementation returned current curve");
      ecCurve.m_coord = this.coord;
      ecCurve.m_endomorphism = this.endomorphism;
      ecCurve.m_multiplier = this.multiplier;
      return ecCurve;
    }
  }

  private class DefaultLookupTable : AbstractECLookupTable
  {
    private readonly ECCurve m_outer;
    private readonly byte[] m_table;
    private readonly int m_size;

    internal DefaultLookupTable(ECCurve outer, byte[] table, int size)
    {
      this.m_outer = outer;
      this.m_table = table;
      this.m_size = size;
    }

    public override int Size => this.m_size;

    public override ECPoint Lookup(int index)
    {
      int length = (this.m_outer.FieldSize + 7) / 8;
      byte[] x = new byte[length];
      byte[] y = new byte[length];
      int num1 = 0;
      for (int index1 = 0; index1 < this.m_size; ++index1)
      {
        byte num2 = (byte) ((index1 ^ index) - 1 >> 31 /*0x1F*/);
        for (int index2 = 0; index2 < length; ++index2)
        {
          x[index2] ^= (byte) ((uint) this.m_table[num1 + index2] & (uint) num2);
          y[index2] ^= (byte) ((uint) this.m_table[num1 + length + index2] & (uint) num2);
        }
        num1 += length * 2;
      }
      return this.CreatePoint(x, y);
    }

    public override ECPoint LookupVar(int index)
    {
      int length = (this.m_outer.FieldSize + 7) / 8;
      byte[] x = new byte[length];
      byte[] y = new byte[length];
      int num = index * length * 2;
      for (int index1 = 0; index1 < length; ++index1)
      {
        x[index1] = this.m_table[num + index1];
        y[index1] = this.m_table[num + length + index1];
      }
      return this.CreatePoint(x, y);
    }

    private ECPoint CreatePoint(byte[] x, byte[] y)
    {
      return this.m_outer.CreateRawPoint(this.m_outer.FromBigInteger(new BigInteger(1, x)), this.m_outer.FromBigInteger(new BigInteger(1, y)));
    }
  }
}
