// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.IsaacEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class IsaacEngine : IStreamCipher
{
  private static readonly int sizeL = 8;
  private static readonly int stateArraySize = IsaacEngine.sizeL << 5;
  private uint[] engineState;
  private uint[] results;
  private uint a;
  private uint b;
  private uint c;
  private int index;
  private byte[] keyStream = new byte[IsaacEngine.stateArraySize << 2];
  private byte[] workingKey;
  private bool initialised;

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    if (!(parameters is KeyParameter))
      throw new ArgumentException("invalid parameter passed to ISAAC Init - " + Platform.GetTypeName((object) parameters), nameof (parameters));
    this.setKey(((KeyParameter) parameters).GetKey());
  }

  public virtual byte ReturnByte(byte input)
  {
    if (this.index == 0)
    {
      this.isaac();
      this.keyStream = Pack.UInt32_To_BE(this.results);
    }
    int num = (int) (byte) ((uint) this.keyStream[this.index] ^ (uint) input);
    this.index = this.index + 1 & 1023 /*0x03FF*/;
    return (byte) num;
  }

  public virtual void ProcessBytes(byte[] input, int inOff, int len, byte[] output, int outOff)
  {
    if (!this.initialised)
      throw new InvalidOperationException(this.AlgorithmName + " not initialised");
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, len, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, len, "output buffer too short");
    for (int index = 0; index < len; ++index)
    {
      if (this.index == 0)
      {
        this.isaac();
        this.keyStream = Pack.UInt32_To_BE(this.results);
      }
      output[index + outOff] = (byte) ((uint) this.keyStream[this.index] ^ (uint) input[index + inOff]);
      this.index = this.index + 1 & 1023 /*0x03FF*/;
    }
  }

  public virtual string AlgorithmName => "ISAAC";

  public virtual void Reset() => this.setKey(this.workingKey);

  private void setKey(byte[] keyBytes)
  {
    this.workingKey = keyBytes;
    if (this.engineState == null)
      this.engineState = new uint[IsaacEngine.stateArraySize];
    if (this.results == null)
      this.results = new uint[IsaacEngine.stateArraySize];
    for (int index1 = 0; index1 < IsaacEngine.stateArraySize; ++index1)
    {
      uint[] engineState = this.engineState;
      int index2 = index1;
      this.results[index1] = 0U;
      engineState[index2] = 0U;
    }
    this.c = 0U;
    this.b = 0U;
    this.a = 0U;
    this.index = 0;
    byte[] numArray = new byte[keyBytes.Length + (keyBytes.Length & 3)];
    Array.Copy((Array) keyBytes, 0, (Array) numArray, 0, keyBytes.Length);
    for (int off = 0; off < numArray.Length; off += 4)
      this.results[off >> 2] = Pack.LE_To_UInt32(numArray, off);
    uint[] x = new uint[IsaacEngine.sizeL];
    for (int index = 0; index < IsaacEngine.sizeL; ++index)
      x[index] = 2654435769U;
    for (int index = 0; index < 4; ++index)
      this.mix(x);
    for (int index3 = 0; index3 < 2; ++index3)
    {
      for (int index4 = 0; index4 < IsaacEngine.stateArraySize; index4 += IsaacEngine.sizeL)
      {
        for (int index5 = 0; index5 < IsaacEngine.sizeL; ++index5)
          x[index5] += index3 < 1 ? this.results[index4 + index5] : this.engineState[index4 + index5];
        this.mix(x);
        for (int index6 = 0; index6 < IsaacEngine.sizeL; ++index6)
          this.engineState[index4 + index6] = x[index6];
      }
    }
    this.isaac();
    this.initialised = true;
  }

  private void isaac()
  {
    this.b += ++this.c;
    for (int index = 0; index < IsaacEngine.stateArraySize; ++index)
    {
      uint num1 = this.engineState[index];
      switch (index & 3)
      {
        case 0:
          this.a ^= this.a << 13;
          break;
        case 1:
          this.a ^= this.a >> 6;
          break;
        case 2:
          this.a ^= this.a << 2;
          break;
        case 3:
          this.a ^= this.a >> 16 /*0x10*/;
          break;
      }
      this.a += this.engineState[index + 128 /*0x80*/ & (int) byte.MaxValue];
      uint num2;
      this.engineState[index] = num2 = this.engineState[(int) (num1 >> 2) & (int) byte.MaxValue] + this.a + this.b;
      this.results[index] = this.b = this.engineState[(int) (num2 >> 10) & (int) byte.MaxValue] + num1;
    }
  }

  private void mix(uint[] x)
  {
    x[0] ^= x[1] << 11;
    x[3] += x[0];
    x[1] += x[2];
    x[1] ^= x[2] >> 2;
    x[4] += x[1];
    x[2] += x[3];
    x[2] ^= x[3] << 8;
    x[5] += x[2];
    x[3] += x[4];
    x[3] ^= x[4] >> 16 /*0x10*/;
    x[6] += x[3];
    x[4] += x[5];
    x[4] ^= x[5] << 10;
    x[7] += x[4];
    x[5] += x[6];
    x[5] ^= x[6] >> 4;
    x[0] += x[5];
    x[6] += x[7];
    x[6] ^= x[7] << 8;
    x[1] += x[6];
    x[7] += x[0];
    x[7] ^= x[0] >> 9;
    x[2] += x[7];
    x[0] += x[1];
  }
}
