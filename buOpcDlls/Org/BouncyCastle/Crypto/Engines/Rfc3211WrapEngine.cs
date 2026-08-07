// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.Rfc3211WrapEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class Rfc3211WrapEngine : IWrapper
{
  private CbcBlockCipher engine;
  private ParametersWithIV param;
  private bool forWrapping;
  private SecureRandom rand;

  public Rfc3211WrapEngine(IBlockCipher engine) => this.engine = new CbcBlockCipher(engine);

  public virtual void Init(bool forWrapping, ICipherParameters param)
  {
    this.forWrapping = forWrapping;
    if (param is ParametersWithRandom parametersWithRandom)
    {
      this.param = parametersWithRandom.Parameters as ParametersWithIV;
      this.rand = parametersWithRandom.Random;
    }
    else
    {
      this.param = param as ParametersWithIV;
      this.rand = forWrapping ? CryptoServicesRegistrar.GetSecureRandom() : (SecureRandom) null;
    }
    if (this.param == null)
      throw new ArgumentException("RFC3211Wrap requires an IV", nameof (param));
  }

  public virtual string AlgorithmName
  {
    get => this.engine.UnderlyingCipher.AlgorithmName + "/RFC3211Wrap";
  }

  public virtual byte[] Wrap(byte[] inBytes, int inOff, int inLen)
  {
    if (!this.forWrapping)
      throw new InvalidOperationException("not set for wrapping");
    if (inLen > (int) byte.MaxValue || inLen < 0)
      throw new ArgumentException("input must be from 0 to 255 bytes", nameof (inLen));
    this.engine.Init(true, (ICipherParameters) this.param);
    int blockSize = this.engine.GetBlockSize();
    byte[] numArray = inLen + 4 >= blockSize * 2 ? new byte[(inLen + 4) % blockSize == 0 ? inLen + 4 : ((inLen + 4) / blockSize + 1) * blockSize] : new byte[blockSize * 2];
    numArray[0] = (byte) inLen;
    Array.Copy((Array) inBytes, inOff, (Array) numArray, 4, inLen);
    this.rand.NextBytes(numArray, inLen + 4, numArray.Length - inLen - 4);
    numArray[1] = ~numArray[4];
    numArray[2] = ~numArray[5];
    numArray[3] = ~numArray[6];
    for (int index = 0; index < numArray.Length; index += blockSize)
      this.engine.ProcessBlock(numArray, index, numArray, index);
    for (int index = 0; index < numArray.Length; index += blockSize)
      this.engine.ProcessBlock(numArray, index, numArray, index);
    return numArray;
  }

  public virtual byte[] Unwrap(byte[] inBytes, int inOff, int inLen)
  {
    if (this.forWrapping)
      throw new InvalidOperationException("not set for unwrapping");
    int blockSize = this.engine.GetBlockSize();
    byte[] numArray1 = inLen >= 2 * blockSize ? new byte[inLen] : throw new InvalidCipherTextException("input too short");
    byte[] numArray2 = new byte[blockSize];
    Array.Copy((Array) inBytes, inOff, (Array) numArray1, 0, inLen);
    Array.Copy((Array) inBytes, inOff, (Array) numArray2, 0, numArray2.Length);
    this.engine.Init(false, (ICipherParameters) new ParametersWithIV(this.param.Parameters, numArray2));
    for (int index = blockSize; index < numArray1.Length; index += blockSize)
      this.engine.ProcessBlock(numArray1, index, numArray1, index);
    Array.Copy((Array) numArray1, numArray1.Length - numArray2.Length, (Array) numArray2, 0, numArray2.Length);
    this.engine.Init(false, (ICipherParameters) new ParametersWithIV(this.param.Parameters, numArray2));
    this.engine.ProcessBlock(numArray1, 0, numArray1, 0);
    this.engine.Init(false, (ICipherParameters) this.param);
    for (int index = 0; index < numArray1.Length; index += blockSize)
      this.engine.ProcessBlock(numArray1, index, numArray1, index);
    bool flag;
    byte[] destinationArray = !(flag = (int) numArray1[0] > numArray1.Length - 4) ? new byte[(int) numArray1[0]] : new byte[numArray1.Length - 4];
    Array.Copy((Array) numArray1, 4, (Array) destinationArray, 0, destinationArray.Length);
    int num1 = 0;
    for (int index = 0; index != 3; ++index)
    {
      byte num2 = ~numArray1[1 + index];
      num1 |= (int) num2 ^ (int) numArray1[4 + index];
    }
    Array.Clear((Array) numArray1, 0, numArray1.Length);
    if (num1 != 0 | flag)
      throw new InvalidCipherTextException("wrapped key corrupted");
    return destinationArray;
  }
}
