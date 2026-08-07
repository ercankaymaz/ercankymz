// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Encodings.ISO9796d1Encoding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Encodings;

public class ISO9796d1Encoding : IAsymmetricBlockCipher
{
  private static readonly BigInteger Sixteen = BigInteger.ValueOf(16L /*0x10*/);
  private static readonly BigInteger Six = BigInteger.ValueOf(6L);
  private static readonly byte[] shadows = new byte[16 /*0x10*/]
  {
    (byte) 14,
    (byte) 3,
    (byte) 5,
    (byte) 8,
    (byte) 9,
    (byte) 4,
    (byte) 2,
    (byte) 15,
    (byte) 0,
    (byte) 13,
    (byte) 11,
    (byte) 6,
    (byte) 7,
    (byte) 10,
    (byte) 12,
    (byte) 1
  };
  private static readonly byte[] inverse = new byte[16 /*0x10*/]
  {
    (byte) 8,
    (byte) 15,
    (byte) 6,
    (byte) 1,
    (byte) 5,
    (byte) 2,
    (byte) 11,
    (byte) 12,
    (byte) 3,
    (byte) 4,
    (byte) 13,
    (byte) 10,
    (byte) 14,
    (byte) 9,
    (byte) 0,
    (byte) 7
  };
  private readonly IAsymmetricBlockCipher engine;
  private bool forEncryption;
  private int bitSize;
  private int padBits;
  private BigInteger modulus;

  public ISO9796d1Encoding(IAsymmetricBlockCipher cipher) => this.engine = cipher;

  public string AlgorithmName => this.engine.AlgorithmName + "/ISO9796-1Padding";

  public IAsymmetricBlockCipher UnderlyingCipher => this.engine;

  public void Init(bool forEncryption, ICipherParameters parameters)
  {
    RsaKeyParameters rsaKeyParameters = !(parameters is ParametersWithRandom parametersWithRandom) ? (RsaKeyParameters) parameters : (RsaKeyParameters) parametersWithRandom.Parameters;
    this.engine.Init(forEncryption, parameters);
    this.modulus = rsaKeyParameters.Modulus;
    this.bitSize = this.modulus.BitLength;
    this.forEncryption = forEncryption;
  }

  public int GetInputBlockSize()
  {
    int inputBlockSize = this.engine.GetInputBlockSize();
    return this.forEncryption ? (inputBlockSize + 1) / 2 : inputBlockSize;
  }

  public int GetOutputBlockSize()
  {
    int outputBlockSize = this.engine.GetOutputBlockSize();
    return this.forEncryption ? outputBlockSize : (outputBlockSize + 1) / 2;
  }

  public void SetPadBits(int padBits)
  {
    this.padBits = padBits <= 7 ? padBits : throw new ArgumentException("padBits > 7");
  }

  public int GetPadBits() => this.padBits;

  public byte[] ProcessBlock(byte[] input, int inOff, int length)
  {
    return this.forEncryption ? this.EncodeBlock(input, inOff, length) : this.DecodeBlock(input, inOff, length);
  }

  private byte[] EncodeBlock(byte[] input, int inOff, int inLen)
  {
    byte[] numArray = new byte[(this.bitSize + 7) / 8];
    int num1 = this.padBits + 1;
    int length = inLen;
    int num2 = (this.bitSize + 13) / 16 /*0x10*/;
    for (int index = 0; index < num2; index += length)
    {
      if (index > num2 - length)
        Array.Copy((Array) input, inOff + inLen - (num2 - index), (Array) numArray, numArray.Length - num2, num2 - index);
      else
        Array.Copy((Array) input, inOff, (Array) numArray, numArray.Length - (index + length), length);
    }
    for (int index = numArray.Length - 2 * num2; index != numArray.Length; index += 2)
    {
      byte num3 = numArray[numArray.Length - num2 + index / 2];
      numArray[index] = (byte) ((uint) ISO9796d1Encoding.shadows[(int) (((uint) num3 & (uint) byte.MaxValue) >> 4)] << 4 | (uint) ISO9796d1Encoding.shadows[(int) num3 & 15]);
      numArray[index + 1] = num3;
    }
    numArray[numArray.Length - 2 * length] ^= (byte) num1;
    numArray[numArray.Length - 1] = (byte) ((int) numArray[numArray.Length - 1] << 4 | 6);
    int num4 = 8 - (this.bitSize - 1) % 8;
    int inOff1 = 0;
    if (num4 != 8)
    {
      numArray[0] &= (byte) ((int) byte.MaxValue >> num4);
      numArray[0] |= (byte) (128 /*0x80*/ >> num4);
    }
    else
    {
      numArray[0] = (byte) 0;
      numArray[1] |= (byte) 128 /*0x80*/;
      inOff1 = 1;
    }
    return this.engine.ProcessBlock(numArray, inOff1, numArray.Length - inOff1);
  }

  private byte[] DecodeBlock(byte[] input, int inOff, int inLen)
  {
    byte[] bytes = this.engine.ProcessBlock(input, inOff, inLen);
    int num1 = 1;
    int num2 = (this.bitSize + 13) / 16 /*0x10*/;
    BigInteger n = new BigInteger(1, bytes);
    BigInteger bigInteger;
    if (n.Mod(ISO9796d1Encoding.Sixteen).Equals(ISO9796d1Encoding.Six))
    {
      bigInteger = n;
    }
    else
    {
      bigInteger = this.modulus.Subtract(n);
      if (!bigInteger.Mod(ISO9796d1Encoding.Sixteen).Equals(ISO9796d1Encoding.Six))
        throw new InvalidCipherTextException("resulting integer iS or (modulus - iS) is not congruent to 6 mod 16");
    }
    byte[] byteArrayUnsigned = bigInteger.ToByteArrayUnsigned();
    if (((int) byteArrayUnsigned[byteArrayUnsigned.Length - 1] & 15) != 6)
      throw new InvalidCipherTextException("invalid forcing byte in block");
    byteArrayUnsigned[byteArrayUnsigned.Length - 1] = (byte) ((int) (ushort) ((uint) byteArrayUnsigned[byteArrayUnsigned.Length - 1] & (uint) byte.MaxValue) >> 4 | (int) ISO9796d1Encoding.inverse[((int) byteArrayUnsigned[byteArrayUnsigned.Length - 2] & (int) byte.MaxValue) >> 4] << 4);
    byteArrayUnsigned[0] = (byte) ((uint) ISO9796d1Encoding.shadows[(int) (((uint) byteArrayUnsigned[1] & (uint) byte.MaxValue) >> 4)] << 4 | (uint) ISO9796d1Encoding.shadows[(int) byteArrayUnsigned[1] & 15]);
    bool flag = false;
    int index1 = 0;
    for (int index2 = byteArrayUnsigned.Length - 1; index2 >= byteArrayUnsigned.Length - 2 * num2; index2 -= 2)
    {
      int num3 = (int) ISO9796d1Encoding.shadows[(int) (((uint) byteArrayUnsigned[index2] & (uint) byte.MaxValue) >> 4)] << 4 | (int) ISO9796d1Encoding.shadows[(int) byteArrayUnsigned[index2] & 15];
      if ((((int) byteArrayUnsigned[index2 - 1] ^ num3) & (int) byte.MaxValue) != 0)
      {
        flag = !flag ? true : throw new InvalidCipherTextException("invalid tsums in block");
        num1 = ((int) byteArrayUnsigned[index2 - 1] ^ num3) & (int) byte.MaxValue;
        index1 = index2 - 1;
      }
    }
    byteArrayUnsigned[index1] = (byte) 0;
    byte[] numArray = new byte[(byteArrayUnsigned.Length - index1) / 2];
    for (int index3 = 0; index3 < numArray.Length; ++index3)
      numArray[index3] = byteArrayUnsigned[2 * index3 + index1 + 1];
    this.padBits = num1 - 1;
    return numArray;
  }
}
