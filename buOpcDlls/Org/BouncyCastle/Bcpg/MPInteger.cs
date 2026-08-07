// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.MPInteger
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public sealed class MPInteger : BcpgObject
{
  private readonly BigInteger m_val;

  public MPInteger(BcpgInputStream bcpgIn)
  {
    byte[] numArray = bcpgIn != null ? new byte[((bcpgIn.ReadByte() << 8 | bcpgIn.ReadByte()) + 7) / 8] : throw new ArgumentNullException(nameof (bcpgIn));
    bcpgIn.ReadFully(numArray);
    this.m_val = new BigInteger(1, numArray);
  }

  public MPInteger(BigInteger val)
  {
    if (val == null)
      throw new ArgumentNullException(nameof (val));
    this.m_val = val.SignValue >= 0 ? val : throw new ArgumentException("Values must be positive", nameof (val));
  }

  public BigInteger Value => this.m_val;

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    bcpgOut.WriteShort((short) this.m_val.BitLength);
    bcpgOut.Write(this.m_val.ToByteArrayUnsigned());
  }

  internal static BigInteger ToMpiBigInteger(ECPoint point)
  {
    return new BigInteger(1, point.GetEncoded(false));
  }
}
