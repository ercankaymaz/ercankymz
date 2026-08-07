// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.HMacDsaKCalculator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class HMacDsaKCalculator : IDsaKCalculator
{
  private readonly HMac hMac;
  private readonly byte[] K;
  private readonly byte[] V;
  private BigInteger n;

  public HMacDsaKCalculator(IDigest digest)
  {
    this.hMac = new HMac(digest);
    this.V = new byte[this.hMac.GetMacSize()];
    this.K = new byte[this.hMac.GetMacSize()];
  }

  public virtual bool IsDeterministic => true;

  public virtual void Init(BigInteger n, SecureRandom random)
  {
    throw new InvalidOperationException("Operation not supported");
  }

  public void Init(BigInteger n, BigInteger d, byte[] message)
  {
    this.n = n;
    Arrays.Fill(this.V, (byte) 1);
    Arrays.Fill(this.K, (byte) 0);
    BigInteger n1 = this.BitsToInt(message);
    if (n1.CompareTo(n) >= 0)
      n1 = n1.Subtract(n);
    int unsignedByteLength = BigIntegers.GetUnsignedByteLength(n);
    byte[] input1 = BigIntegers.AsUnsignedByteArray(unsignedByteLength, d);
    byte[] input2 = BigIntegers.AsUnsignedByteArray(unsignedByteLength, n1);
    this.hMac.Init((ICipherParameters) new KeyParameter(this.K));
    this.hMac.BlockUpdate(this.V, 0, this.V.Length);
    this.hMac.Update((byte) 0);
    this.hMac.BlockUpdate(input1, 0, input1.Length);
    this.hMac.BlockUpdate(input2, 0, input2.Length);
    this.InitAdditionalInput0(this.hMac);
    this.hMac.DoFinal(this.K, 0);
    this.hMac.Init((ICipherParameters) new KeyParameter(this.K));
    this.hMac.BlockUpdate(this.V, 0, this.V.Length);
    this.hMac.DoFinal(this.V, 0);
    this.hMac.BlockUpdate(this.V, 0, this.V.Length);
    this.hMac.Update((byte) 1);
    this.hMac.BlockUpdate(input1, 0, input1.Length);
    this.hMac.BlockUpdate(input2, 0, input2.Length);
    this.hMac.DoFinal(this.K, 0);
    this.hMac.Init((ICipherParameters) new KeyParameter(this.K));
    this.hMac.BlockUpdate(this.V, 0, this.V.Length);
    this.hMac.DoFinal(this.V, 0);
  }

  public virtual BigInteger NextK()
  {
    byte[] numArray = new byte[BigIntegers.GetUnsignedByteLength(this.n)];
    BigInteger bigInteger;
    while (true)
    {
      int length;
      for (int destinationIndex = 0; destinationIndex < numArray.Length; destinationIndex += length)
      {
        this.hMac.BlockUpdate(this.V, 0, this.V.Length);
        this.hMac.DoFinal(this.V, 0);
        length = System.Math.Min(numArray.Length - destinationIndex, this.V.Length);
        Array.Copy((Array) this.V, 0, (Array) numArray, destinationIndex, length);
      }
      bigInteger = this.BitsToInt(numArray);
      if (bigInteger.SignValue <= 0 || bigInteger.CompareTo(this.n) >= 0)
      {
        this.hMac.BlockUpdate(this.V, 0, this.V.Length);
        this.hMac.Update((byte) 0);
        this.hMac.DoFinal(this.K, 0);
        this.hMac.Init((ICipherParameters) new KeyParameter(this.K));
        this.hMac.BlockUpdate(this.V, 0, this.V.Length);
        this.hMac.DoFinal(this.V, 0);
      }
      else
        break;
    }
    return bigInteger;
  }

  protected virtual void InitAdditionalInput0(HMac hmac0)
  {
  }

  private BigInteger BitsToInt(byte[] t)
  {
    BigInteger bigInteger = new BigInteger(1, t);
    if (t.Length * 8 > this.n.BitLength)
      bigInteger = bigInteger.ShiftRight(t.Length * 8 - this.n.BitLength);
    return bigInteger;
  }
}
