// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Macs.VmpcMac
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Macs;

public class VmpcMac : IMac
{
  private byte g;
  private byte n;
  private byte[] P;
  private byte s;
  private readonly byte[] T = new byte[32 /*0x20*/];
  private byte[] workingIV;
  private byte[] workingKey;
  private byte x1;
  private byte x2;
  private byte x3;
  private byte x4;

  public virtual int DoFinal(byte[] output, int outOff)
  {
    for (int index = 1; index < 25; ++index)
    {
      this.s = this.P[(int) this.s + (int) this.P[(int) this.n & (int) byte.MaxValue] & (int) byte.MaxValue];
      this.x4 = this.P[(int) this.x4 + (int) this.x3 + index & (int) byte.MaxValue];
      this.x3 = this.P[(int) this.x3 + (int) this.x2 + index & (int) byte.MaxValue];
      this.x2 = this.P[(int) this.x2 + (int) this.x1 + index & (int) byte.MaxValue];
      this.x1 = this.P[(int) this.x1 + (int) this.s + index & (int) byte.MaxValue];
      this.T[(int) this.g & 31 /*0x1F*/] = (byte) ((uint) this.T[(int) this.g & 31 /*0x1F*/] ^ (uint) this.x1);
      this.T[(int) this.g + 1 & 31 /*0x1F*/] = (byte) ((uint) this.T[(int) this.g + 1 & 31 /*0x1F*/] ^ (uint) this.x2);
      this.T[(int) this.g + 2 & 31 /*0x1F*/] = (byte) ((uint) this.T[(int) this.g + 2 & 31 /*0x1F*/] ^ (uint) this.x3);
      this.T[(int) this.g + 3 & 31 /*0x1F*/] = (byte) ((uint) this.T[(int) this.g + 3 & 31 /*0x1F*/] ^ (uint) this.x4);
      this.g = (byte) ((int) this.g + 4 & 31 /*0x1F*/);
      byte num = this.P[(int) this.n & (int) byte.MaxValue];
      this.P[(int) this.n & (int) byte.MaxValue] = this.P[(int) this.s & (int) byte.MaxValue];
      this.P[(int) this.s & (int) byte.MaxValue] = num;
      this.n = (byte) ((int) this.n + 1 & (int) byte.MaxValue);
    }
    for (int index = 0; index < 768 /*0x0300*/; ++index)
    {
      this.s = this.P[(int) this.s + (int) this.P[index & (int) byte.MaxValue] + (int) this.T[index & 31 /*0x1F*/] & (int) byte.MaxValue];
      byte num = this.P[index & (int) byte.MaxValue];
      this.P[index & (int) byte.MaxValue] = this.P[(int) this.s & (int) byte.MaxValue];
      this.P[(int) this.s & (int) byte.MaxValue] = num;
    }
    byte[] sourceArray = new byte[20];
    for (int index = 0; index < 20; ++index)
    {
      this.s = this.P[(int) this.s + (int) this.P[index & (int) byte.MaxValue] & (int) byte.MaxValue];
      sourceArray[index] = this.P[(int) this.P[(int) this.P[(int) this.s & (int) byte.MaxValue] & (int) byte.MaxValue] + 1 & (int) byte.MaxValue];
      byte num = this.P[index & (int) byte.MaxValue];
      this.P[index & (int) byte.MaxValue] = this.P[(int) this.s & (int) byte.MaxValue];
      this.P[(int) this.s & (int) byte.MaxValue] = num;
    }
    Array.Copy((Array) sourceArray, 0, (Array) output, outOff, sourceArray.Length);
    this.Reset();
    return sourceArray.Length;
  }

  public virtual string AlgorithmName => "VMPC-MAC";

  public virtual int GetMacSize() => 20;

  public virtual void Init(ICipherParameters parameters)
  {
    if (!(parameters is ParametersWithIV parametersWithIv))
      throw new ArgumentException("VMPC-MAC Init parameters must include an IV", nameof (parameters));
    if (!(parametersWithIv.Parameters is KeyParameter parameters1))
      throw new ArgumentException("VMPC-MAC Init parameters must include a key", nameof (parameters));
    int keyLength = parameters1.KeyLength;
    if (keyLength < 16 /*0x10*/ || keyLength > 64 /*0x40*/)
      throw new ArgumentException("VMPC requires 16 to 64 bytes of key");
    int ivLength = parametersWithIv.IVLength;
    if (ivLength < 16 /*0x10*/ || ivLength > 64 /*0x40*/)
      throw new ArgumentException("VMPC requires 16 to 64 bytes of IV");
    this.workingKey = parameters1.GetKey();
    this.workingIV = parametersWithIv.GetIV();
    this.Reset();
  }

  private void InitKey(byte[] keyBytes, byte[] ivBytes)
  {
    this.n = (byte) 0;
    this.s = (byte) 0;
    this.P = new byte[256 /*0x0100*/];
    for (int index = 0; index < 256 /*0x0100*/; ++index)
      this.P[index] = (byte) index;
    VmpcEngine.KsaRound(this.P, ref this.s, keyBytes);
    VmpcEngine.KsaRound(this.P, ref this.s, ivBytes);
  }

  public virtual void Reset()
  {
    this.InitKey(this.workingKey, this.workingIV);
    this.n = (byte) 0;
    this.x4 = (byte) 0;
    this.x3 = (byte) 0;
    this.x2 = (byte) 0;
    this.x1 = (byte) 0;
    this.g = (byte) 0;
    Array.Clear((Array) this.T, 0, this.T.Length);
  }

  public virtual void Update(byte input)
  {
    byte num1 = this.P[(int) this.n];
    this.s = this.P[(int) this.s + (int) num1 & (int) byte.MaxValue];
    byte index = this.P[(int) this.s];
    byte num2 = (byte) ((uint) input ^ (uint) this.P[(int) this.P[(int) index] + 1 & (int) byte.MaxValue]);
    this.x4 = this.P[(int) this.x4 + (int) this.x3 & (int) byte.MaxValue];
    this.x3 = this.P[(int) this.x3 + (int) this.x2 & (int) byte.MaxValue];
    this.x2 = this.P[(int) this.x2 + (int) this.x1 & (int) byte.MaxValue];
    this.x1 = this.P[(int) this.x1 + (int) this.s + (int) num2 & (int) byte.MaxValue];
    this.T[(int) this.g & 31 /*0x1F*/] = (byte) ((uint) this.T[(int) this.g & 31 /*0x1F*/] ^ (uint) this.x1);
    this.T[(int) this.g + 1 & 31 /*0x1F*/] = (byte) ((uint) this.T[(int) this.g + 1 & 31 /*0x1F*/] ^ (uint) this.x2);
    this.T[(int) this.g + 2 & 31 /*0x1F*/] = (byte) ((uint) this.T[(int) this.g + 2 & 31 /*0x1F*/] ^ (uint) this.x3);
    this.T[(int) this.g + 3 & 31 /*0x1F*/] = (byte) ((uint) this.T[(int) this.g + 3 & 31 /*0x1F*/] ^ (uint) this.x4);
    this.g = (byte) ((int) this.g + 4 & 31 /*0x1F*/);
    this.P[(int) this.n] = index;
    this.P[(int) this.s] = num1;
    ++this.n;
  }

  public virtual void BlockUpdate(byte[] input, int inOff, int inLen)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, inLen, "input buffer too short");
    for (int index1 = 0; index1 < inLen; ++index1)
    {
      byte num1 = this.P[(int) this.n];
      this.s = this.P[(int) this.s + (int) num1 & (int) byte.MaxValue];
      byte index2 = this.P[(int) this.s];
      byte num2 = (byte) ((uint) input[inOff + index1] ^ (uint) this.P[(int) this.P[(int) index2] + 1 & (int) byte.MaxValue]);
      this.x4 = this.P[(int) this.x4 + (int) this.x3 & (int) byte.MaxValue];
      this.x3 = this.P[(int) this.x3 + (int) this.x2 & (int) byte.MaxValue];
      this.x2 = this.P[(int) this.x2 + (int) this.x1 & (int) byte.MaxValue];
      this.x1 = this.P[(int) this.x1 + (int) this.s + (int) num2 & (int) byte.MaxValue];
      this.T[(int) this.g & 31 /*0x1F*/] = (byte) ((uint) this.T[(int) this.g & 31 /*0x1F*/] ^ (uint) this.x1);
      this.T[(int) this.g + 1 & 31 /*0x1F*/] = (byte) ((uint) this.T[(int) this.g + 1 & 31 /*0x1F*/] ^ (uint) this.x2);
      this.T[(int) this.g + 2 & 31 /*0x1F*/] = (byte) ((uint) this.T[(int) this.g + 2 & 31 /*0x1F*/] ^ (uint) this.x3);
      this.T[(int) this.g + 3 & 31 /*0x1F*/] = (byte) ((uint) this.T[(int) this.g + 3 & 31 /*0x1F*/] ^ (uint) this.x4);
      this.g = (byte) ((int) this.g + 4 & 31 /*0x1F*/);
      this.P[(int) this.n] = index2;
      this.P[(int) this.s] = num1;
      ++this.n;
    }
  }
}
