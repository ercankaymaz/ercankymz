// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.Rfc3394WrapEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class Rfc3394WrapEngine : IWrapper
{
  private readonly IBlockCipher engine;
  private readonly bool wrapCipherMode;
  private KeyParameter param;
  private bool forWrapping;
  private byte[] iv = new byte[8]
  {
    (byte) 166,
    (byte) 166,
    (byte) 166,
    (byte) 166,
    (byte) 166,
    (byte) 166,
    (byte) 166,
    (byte) 166
  };

  public Rfc3394WrapEngine(IBlockCipher engine)
    : this(engine, false)
  {
  }

  public Rfc3394WrapEngine(IBlockCipher engine, bool useReverseDirection)
  {
    this.engine = engine;
    this.wrapCipherMode = !useReverseDirection;
  }

  public virtual void Init(bool forWrapping, ICipherParameters parameters)
  {
    this.forWrapping = forWrapping;
    if (parameters is ParametersWithRandom parametersWithRandom)
      parameters = parametersWithRandom.Parameters;
    if (parameters is KeyParameter keyParameter)
    {
      this.param = keyParameter;
    }
    else
    {
      if (!(parameters is ParametersWithIV parametersWithIv))
        return;
      byte[] iv = parametersWithIv.GetIV();
      this.iv = iv.Length == 8 ? iv : throw new ArgumentException("IV length not equal to 8", nameof (parameters));
      this.param = (KeyParameter) parametersWithIv.Parameters;
    }
  }

  public virtual string AlgorithmName => this.engine.AlgorithmName;

  public virtual byte[] Wrap(byte[] input, int inOff, int inLen)
  {
    if (!this.forWrapping)
      throw new InvalidOperationException("not set for wrapping");
    if (inLen < 8)
      throw new DataLengthException("wrap data must be at least 8 bytes");
    int num1 = inLen / 8;
    if (num1 * 8 != inLen)
      throw new DataLengthException("wrap data must be a multiple of 8 bytes");
    this.engine.Init(this.wrapCipherMode, (ICipherParameters) this.param);
    byte[] numArray1 = new byte[inLen + this.iv.Length];
    Array.Copy((Array) this.iv, 0, (Array) numArray1, 0, this.iv.Length);
    Array.Copy((Array) input, inOff, (Array) numArray1, this.iv.Length, inLen);
    if (num1 == 1)
    {
      this.engine.ProcessBlock(numArray1, 0, numArray1, 0);
    }
    else
    {
      byte[] numArray2 = new byte[8 + this.iv.Length];
      for (int index1 = 0; index1 != 6; ++index1)
      {
        for (int index2 = 1; index2 <= num1; ++index2)
        {
          Array.Copy((Array) numArray1, 0, (Array) numArray2, 0, this.iv.Length);
          Array.Copy((Array) numArray1, 8 * index2, (Array) numArray2, this.iv.Length, 8);
          this.engine.ProcessBlock(numArray2, 0, numArray2, 0);
          int num2 = num1 * index1 + index2;
          int num3 = 1;
          while (num2 != 0)
          {
            byte num4 = (byte) num2;
            numArray2[this.iv.Length - num3] ^= num4;
            num2 >>>= 8;
            ++num3;
          }
          Array.Copy((Array) numArray2, 0, (Array) numArray1, 0, 8);
          Array.Copy((Array) numArray2, 8, (Array) numArray1, 8 * index2, 8);
        }
      }
    }
    return numArray1;
  }

  public virtual byte[] Unwrap(byte[] input, int inOff, int inLen)
  {
    if (this.forWrapping)
      throw new InvalidOperationException("not set for unwrapping");
    if (inLen < 16 /*0x10*/)
      throw new InvalidCipherTextException("unwrap data too short");
    int num1 = inLen / 8;
    if (num1 * 8 != inLen)
      throw new InvalidCipherTextException("unwrap data must be a multiple of 8 bytes");
    this.engine.Init(!this.wrapCipherMode, (ICipherParameters) this.param);
    byte[] numArray1 = new byte[inLen - this.iv.Length];
    byte[] numArray2 = new byte[this.iv.Length];
    byte[] numArray3 = new byte[8 + this.iv.Length];
    int num2 = num1 - 1;
    if (num2 == 1)
    {
      this.engine.ProcessBlock(input, inOff, numArray3, 0);
      Array.Copy((Array) numArray3, 0, (Array) numArray2, 0, this.iv.Length);
      Array.Copy((Array) numArray3, this.iv.Length, (Array) numArray1, 0, 8);
    }
    else
    {
      Array.Copy((Array) input, inOff, (Array) numArray2, 0, this.iv.Length);
      Array.Copy((Array) input, inOff + this.iv.Length, (Array) numArray1, 0, inLen - this.iv.Length);
      for (int index1 = 5; index1 >= 0; --index1)
      {
        for (int index2 = num2; index2 >= 1; --index2)
        {
          Array.Copy((Array) numArray2, 0, (Array) numArray3, 0, this.iv.Length);
          Array.Copy((Array) numArray1, 8 * (index2 - 1), (Array) numArray3, this.iv.Length, 8);
          int num3 = num2 * index1 + index2;
          int num4 = 1;
          while (num3 != 0)
          {
            byte num5 = (byte) num3;
            numArray3[this.iv.Length - num4] ^= num5;
            num3 >>>= 8;
            ++num4;
          }
          this.engine.ProcessBlock(numArray3, 0, numArray3, 0);
          Array.Copy((Array) numArray3, 0, (Array) numArray2, 0, 8);
          Array.Copy((Array) numArray3, 8, (Array) numArray1, 8 * (index2 - 1), 8);
        }
      }
    }
    if (!Arrays.FixedTimeEquals(numArray2, this.iv))
      throw new InvalidCipherTextException("checksum failed");
    return numArray1;
  }
}
