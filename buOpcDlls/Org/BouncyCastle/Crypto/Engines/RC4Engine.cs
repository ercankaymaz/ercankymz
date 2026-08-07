// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.RC4Engine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class RC4Engine : IStreamCipher
{
  private static readonly int STATE_LENGTH = 256 /*0x0100*/;
  private byte[] engineState;
  private int x;
  private int y;
  private byte[] workingKey;

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.workingKey = parameters is KeyParameter keyParameter ? keyParameter.GetKey() : throw new ArgumentException("invalid parameter passed to RC4 init - " + Platform.GetTypeName((object) parameters));
    this.SetKey(this.workingKey);
  }

  public virtual string AlgorithmName => "RC4";

  public virtual byte ReturnByte(byte input)
  {
    this.x = this.x + 1 & (int) byte.MaxValue;
    this.y = (int) this.engineState[this.x] + this.y & (int) byte.MaxValue;
    byte num = this.engineState[this.x];
    this.engineState[this.x] = this.engineState[this.y];
    this.engineState[this.y] = num;
    return (byte) ((uint) input ^ (uint) this.engineState[(int) this.engineState[this.x] + (int) this.engineState[this.y] & (int) byte.MaxValue]);
  }

  public virtual void ProcessBytes(
    byte[] input,
    int inOff,
    int length,
    byte[] output,
    int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, length, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, length, "output buffer too short");
    for (int index = 0; index < length; ++index)
    {
      this.x = this.x + 1 & (int) byte.MaxValue;
      this.y = (int) this.engineState[this.x] + this.y & (int) byte.MaxValue;
      byte num1 = this.engineState[this.x];
      byte num2 = this.engineState[this.y];
      this.engineState[this.x] = num2;
      this.engineState[this.y] = num1;
      output[index + outOff] = (byte) ((uint) input[index + inOff] ^ (uint) this.engineState[(int) num1 + (int) num2 & (int) byte.MaxValue]);
    }
  }

  public virtual void Reset() => this.SetKey(this.workingKey);

  private void SetKey(byte[] keyBytes)
  {
    this.workingKey = keyBytes;
    this.x = 0;
    this.y = 0;
    if (this.engineState == null)
      this.engineState = new byte[RC4Engine.STATE_LENGTH];
    for (int index = 0; index < RC4Engine.STATE_LENGTH; ++index)
      this.engineState[index] = (byte) index;
    int index1 = 0;
    int index2 = 0;
    for (int index3 = 0; index3 < RC4Engine.STATE_LENGTH; ++index3)
    {
      index2 = ((int) keyBytes[index1] & (int) byte.MaxValue) + (int) this.engineState[index3] + index2 & (int) byte.MaxValue;
      byte num = this.engineState[index3];
      this.engineState[index3] = this.engineState[index2];
      this.engineState[index2] = num;
      index1 = (index1 + 1) % keyBytes.Length;
    }
  }
}
