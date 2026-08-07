// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Encodings.Pkcs1Encoding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Encodings;

public class Pkcs1Encoding : IAsymmetricBlockCipher
{
  public const string StrictLengthEnabledProperty = "Org.BouncyCastle.Pkcs1.Strict";
  private const int HeaderLength = 10;
  private static readonly bool[] strictLengthEnabled;
  private SecureRandom random;
  private IAsymmetricBlockCipher engine;
  private bool forEncryption;
  private bool forPrivateKey;
  private bool useStrictLength;
  private int pLen = -1;
  private byte[] fallback;
  private byte[] blockBuffer;

  public static bool StrictLengthEnabled
  {
    get => Pkcs1Encoding.strictLengthEnabled[0];
    set => Pkcs1Encoding.strictLengthEnabled[0] = value;
  }

  static Pkcs1Encoding()
  {
    string environmentVariable = Platform.GetEnvironmentVariable("Org.BouncyCastle.Pkcs1.Strict");
    Pkcs1Encoding.strictLengthEnabled = new bool[1]
    {
      environmentVariable == null || Platform.EqualsIgnoreCase("true", environmentVariable)
    };
  }

  public Pkcs1Encoding(IAsymmetricBlockCipher cipher)
  {
    this.engine = cipher;
    this.useStrictLength = Pkcs1Encoding.StrictLengthEnabled;
  }

  public Pkcs1Encoding(IAsymmetricBlockCipher cipher, int pLen)
  {
    this.engine = cipher;
    this.useStrictLength = Pkcs1Encoding.StrictLengthEnabled;
    this.pLen = pLen;
  }

  public Pkcs1Encoding(IAsymmetricBlockCipher cipher, byte[] fallback)
  {
    this.engine = cipher;
    this.useStrictLength = Pkcs1Encoding.StrictLengthEnabled;
    this.fallback = fallback;
    this.pLen = fallback.Length;
  }

  public string AlgorithmName => this.engine.AlgorithmName + "/PKCS1Padding";

  public IAsymmetricBlockCipher UnderlyingCipher => this.engine;

  public void Init(bool forEncryption, ICipherParameters parameters)
  {
    AsymmetricKeyParameter asymmetricKeyParameter;
    if (parameters is ParametersWithRandom parametersWithRandom)
    {
      asymmetricKeyParameter = (AsymmetricKeyParameter) parametersWithRandom.Parameters;
      this.random = parametersWithRandom.Random;
    }
    else
    {
      asymmetricKeyParameter = (AsymmetricKeyParameter) parameters;
      this.random = !forEncryption || asymmetricKeyParameter.IsPrivate ? (SecureRandom) null : CryptoServicesRegistrar.GetSecureRandom();
    }
    this.engine.Init(forEncryption, parameters);
    this.forPrivateKey = asymmetricKeyParameter.IsPrivate;
    this.forEncryption = forEncryption;
    this.blockBuffer = new byte[this.engine.GetOutputBlockSize()];
  }

  public int GetInputBlockSize()
  {
    int inputBlockSize = this.engine.GetInputBlockSize();
    return !this.forEncryption ? inputBlockSize : inputBlockSize - 10;
  }

  public int GetOutputBlockSize()
  {
    int outputBlockSize = this.engine.GetOutputBlockSize();
    return !this.forEncryption ? outputBlockSize - 10 : outputBlockSize;
  }

  public byte[] ProcessBlock(byte[] input, int inOff, int length)
  {
    return !this.forEncryption ? this.DecodeBlock(input, inOff, length) : this.EncodeBlock(input, inOff, length);
  }

  private byte[] EncodeBlock(byte[] input, int inOff, int inLen)
  {
    if (inLen > this.GetInputBlockSize())
      throw new ArgumentException("input data too large", nameof (inLen));
    byte[] numArray = new byte[this.engine.GetInputBlockSize()];
    if (this.forPrivateKey)
    {
      numArray[0] = (byte) 1;
      for (int index = 1; index != numArray.Length - inLen - 1; ++index)
        numArray[index] = byte.MaxValue;
    }
    else
    {
      this.random.NextBytes(numArray);
      numArray[0] = (byte) 2;
      for (int index = 1; index != numArray.Length - inLen - 1; ++index)
      {
        while (numArray[index] == (byte) 0)
          numArray[index] = (byte) this.random.NextInt();
      }
    }
    numArray[numArray.Length - inLen - 1] = (byte) 0;
    Array.Copy((Array) input, inOff, (Array) numArray, numArray.Length - inLen, inLen);
    return this.engine.ProcessBlock(numArray, 0, numArray.Length);
  }

  private static int CheckPkcs1Encoding(byte[] encoded, int pLen)
  {
    int num1 = 0 | (int) encoded[0] ^ 2;
    int num2 = encoded.Length - (pLen + 1);
    for (int index = 1; index < num2; ++index)
    {
      int num3 = (int) encoded[index];
      int num4 = num3 | num3 >> 1;
      int num5 = num4 | num4 >> 2;
      int num6 = num5 | num5 >> 4;
      num1 |= (num6 & 1) - 1;
    }
    int num7 = num1 | (int) encoded[encoded.Length - (pLen + 1)];
    int num8 = num7 | num7 >> 1;
    int num9 = num8 | num8 >> 2;
    return ~(((num9 | num9 >> 4) & 1) - 1);
  }

  private byte[] DecodeBlockOrRandom(byte[] input, int inOff, int inLen)
  {
    if (!this.forPrivateKey)
      throw new InvalidCipherTextException("sorry, this method is only for decryption, not for signing");
    byte[] numArray1 = this.engine.ProcessBlock(input, inOff, inLen);
    byte[] numArray2 = this.fallback ?? SecureRandom.GetNextBytes(SecureRandom.ArbitraryRandom, this.pLen);
    byte[] numArray3 = this.useStrictLength & numArray1.Length != this.engine.GetOutputBlockSize() ? this.blockBuffer : numArray1;
    int num = Pkcs1Encoding.CheckPkcs1Encoding(numArray3, this.pLen);
    byte[] numArray4 = new byte[this.pLen];
    for (int index = 0; index < this.pLen; ++index)
      numArray4[index] = (byte) ((int) numArray3[index + (numArray3.Length - this.pLen)] & ~num | (int) numArray2[index] & num);
    Arrays.Fill(numArray3, (byte) 0);
    return numArray4;
  }

  private byte[] DecodeBlock(byte[] input, int inOff, int inLen)
  {
    if (this.pLen != -1)
      return this.DecodeBlockOrRandom(input, inOff, inLen);
    byte[] numArray1 = this.engine.ProcessBlock(input, inOff, inLen);
    int num1 = this.useStrictLength & numArray1.Length != this.engine.GetOutputBlockSize() ? 1 : 0;
    byte[] numArray2 = numArray1.Length >= this.GetOutputBlockSize() ? numArray1 : this.blockBuffer;
    byte num2 = this.forPrivateKey ? (byte) 2 : (byte) 1;
    byte type = numArray2[0];
    int num3 = (int) type != (int) num2 ? 1 : 0;
    int sourceIndex = this.FindStart(type, numArray2) + 1;
    int num4 = sourceIndex < 10 ? 1 : 0;
    if ((num3 | num4) != 0)
    {
      Arrays.Fill(numArray2, (byte) 0);
      throw new InvalidCipherTextException("block incorrect");
    }
    if (num1 != 0)
    {
      Arrays.Fill(numArray2, (byte) 0);
      throw new InvalidCipherTextException("block incorrect size");
    }
    byte[] destinationArray = new byte[numArray2.Length - sourceIndex];
    Array.Copy((Array) numArray2, sourceIndex, (Array) destinationArray, 0, destinationArray.Length);
    return destinationArray;
  }

  private int FindStart(byte type, byte[] block)
  {
    int num1 = -1;
    bool flag = false;
    for (int index = 1; index != block.Length; ++index)
    {
      byte num2 = block[index];
      if (num2 == (byte) 0 & num1 < 0)
        num1 = index;
      flag |= type == (byte) 1 & num1 < 0 & num2 != byte.MaxValue;
    }
    return !flag ? num1 : -1;
  }
}
