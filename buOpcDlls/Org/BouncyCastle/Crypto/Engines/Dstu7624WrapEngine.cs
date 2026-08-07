// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.Dstu7624WrapEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class Dstu7624WrapEngine : IWrapper
{
  private KeyParameter param;
  private Dstu7624Engine engine;
  private bool forWrapping;
  private int blockSize;

  public Dstu7624WrapEngine(int blockSizeBits)
  {
    this.engine = new Dstu7624Engine(blockSizeBits);
    this.param = (KeyParameter) null;
    this.blockSize = blockSizeBits / 8;
  }

  public string AlgorithmName => nameof (Dstu7624WrapEngine);

  public void Init(bool forWrapping, ICipherParameters parameters)
  {
    this.forWrapping = forWrapping;
    this.param = parameters is KeyParameter ? (KeyParameter) parameters : throw new ArgumentException("Bad parameters passed to Dstu7624WrapEngine");
    this.engine.Init(forWrapping, (ICipherParameters) this.param);
  }

  public byte[] Wrap(byte[] input, int inOff, int length)
  {
    if (!this.forWrapping)
      throw new InvalidOperationException("Not set for wrapping");
    if (length % this.blockSize != 0)
      throw new ArgumentException("Padding not supported");
    int num1 = 2 * (1 + length / this.blockSize);
    int num2 = (num1 - 1) * 6;
    byte[] numArray1 = new byte[length + this.blockSize];
    Array.Copy((Array) input, inOff, (Array) numArray1, 0, length);
    byte[] numArray2 = new byte[this.blockSize / 2];
    Array.Copy((Array) numArray1, 0, (Array) numArray2, 0, this.blockSize / 2);
    List<byte[]> numArrayList = new List<byte[]>();
    int num3 = numArray1.Length - this.blockSize / 2;
    int sourceIndex = this.blockSize / 2;
    while (num3 != 0)
    {
      byte[] destinationArray = new byte[this.blockSize / 2];
      Array.Copy((Array) numArray1, sourceIndex, (Array) destinationArray, 0, this.blockSize / 2);
      numArrayList.Add(destinationArray);
      num3 -= this.blockSize / 2;
      sourceIndex += this.blockSize / 2;
    }
    for (int index1 = 0; index1 < num2; ++index1)
    {
      Array.Copy((Array) numArray2, 0, (Array) numArray1, 0, this.blockSize / 2);
      Array.Copy((Array) numArrayList[0], 0, (Array) numArray1, this.blockSize / 2, this.blockSize / 2);
      this.engine.ProcessBlock(numArray1, 0, numArray1, 0);
      byte[] le = Pack.UInt32_To_LE((uint) (index1 + 1));
      for (int index2 = 0; index2 < le.Length; ++index2)
        numArray1[index2 + this.blockSize / 2] ^= le[index2];
      Array.Copy((Array) numArray1, this.blockSize / 2, (Array) numArray2, 0, this.blockSize / 2);
      for (int index3 = 2; index3 < num1; ++index3)
        Array.Copy((Array) numArrayList[index3 - 1], 0, (Array) numArrayList[index3 - 2], 0, this.blockSize / 2);
      Array.Copy((Array) numArray1, 0, (Array) numArrayList[num1 - 2], 0, this.blockSize / 2);
    }
    Array.Copy((Array) numArray2, 0, (Array) numArray1, 0, this.blockSize / 2);
    int destinationIndex = this.blockSize / 2;
    for (int index = 0; index < num1 - 1; ++index)
    {
      Array.Copy((Array) numArrayList[index], 0, (Array) numArray1, destinationIndex, this.blockSize / 2);
      destinationIndex += this.blockSize / 2;
    }
    return numArray1;
  }

  public byte[] Unwrap(byte[] input, int inOff, int length)
  {
    if (this.forWrapping)
      throw new InvalidOperationException("not set for unwrapping");
    if (length % this.blockSize != 0)
      throw new ArgumentException("Padding not supported");
    int num1 = 2 * length / this.blockSize;
    int num2 = (num1 - 1) * 6;
    byte[] numArray1 = new byte[length];
    Array.Copy((Array) input, inOff, (Array) numArray1, 0, length);
    byte[] numArray2 = new byte[this.blockSize / 2];
    Array.Copy((Array) numArray1, 0, (Array) numArray2, 0, this.blockSize / 2);
    List<byte[]> numArrayList = new List<byte[]>();
    int num3 = numArray1.Length - this.blockSize / 2;
    int sourceIndex = this.blockSize / 2;
    while (num3 != 0)
    {
      byte[] destinationArray = new byte[this.blockSize / 2];
      Array.Copy((Array) numArray1, sourceIndex, (Array) destinationArray, 0, this.blockSize / 2);
      numArrayList.Add(destinationArray);
      num3 -= this.blockSize / 2;
      sourceIndex += this.blockSize / 2;
    }
    for (int index1 = 0; index1 < num2; ++index1)
    {
      Array.Copy((Array) numArrayList[num1 - 2], 0, (Array) numArray1, 0, this.blockSize / 2);
      Array.Copy((Array) numArray2, 0, (Array) numArray1, this.blockSize / 2, this.blockSize / 2);
      byte[] le = Pack.UInt32_To_LE((uint) (num2 - index1));
      for (int index2 = 0; index2 < le.Length; ++index2)
        numArray1[index2 + this.blockSize / 2] ^= le[index2];
      this.engine.ProcessBlock(numArray1, 0, numArray1, 0);
      Array.Copy((Array) numArray1, 0, (Array) numArray2, 0, this.blockSize / 2);
      for (int index3 = 2; index3 < num1; ++index3)
        Array.Copy((Array) numArrayList[num1 - index3 - 1], 0, (Array) numArrayList[num1 - index3], 0, this.blockSize / 2);
      Array.Copy((Array) numArray1, this.blockSize / 2, (Array) numArrayList[0], 0, this.blockSize / 2);
    }
    Array.Copy((Array) numArray2, 0, (Array) numArray1, 0, this.blockSize / 2);
    int destinationIndex = this.blockSize / 2;
    for (int index = 0; index < num1 - 1; ++index)
    {
      Array.Copy((Array) numArrayList[index], 0, (Array) numArray1, destinationIndex, this.blockSize / 2);
      destinationIndex += this.blockSize / 2;
    }
    byte num4 = 0;
    for (int index = numArray1.Length - this.blockSize; index < numArray1.Length; ++index)
      num4 |= numArray1[index];
    if (num4 != (byte) 0)
      throw new InvalidCipherTextException("checksum failed");
    return Arrays.CopyOfRange(numArray1, 0, numArray1.Length - this.blockSize);
  }
}
