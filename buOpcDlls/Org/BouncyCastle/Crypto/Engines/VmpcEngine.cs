// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.VmpcEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class VmpcEngine : IStreamCipher
{
  protected byte n;
  protected byte[] P;
  protected byte s;
  protected byte[] workingIV;
  protected byte[] workingKey;

  public virtual string AlgorithmName => "VMPC";

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    if (!(parameters is ParametersWithIV parametersWithIv))
      throw new ArgumentException("VMPC Init parameters must include an IV");
    if (!(parametersWithIv.Parameters is KeyParameter parameters1))
      throw new ArgumentException("VMPC Init parameters must include a key");
    int keyLength = parameters1.KeyLength;
    if (keyLength < 16 /*0x10*/ || keyLength > 64 /*0x40*/)
      throw new ArgumentException("VMPC requires 16 to 64 bytes of key");
    int ivLength = parametersWithIv.IVLength;
    if (ivLength < 16 /*0x10*/ || ivLength > 64 /*0x40*/)
      throw new ArgumentException("VMPC requires 16 to 64 bytes of IV");
    this.workingKey = parameters1.GetKey();
    this.workingIV = parametersWithIv.GetIV();
    this.InitKey(this.workingKey, this.workingIV);
  }

  protected virtual void InitKey(byte[] keyBytes, byte[] ivBytes)
  {
    this.n = (byte) 0;
    this.s = (byte) 0;
    this.P = new byte[256 /*0x0100*/];
    for (int index = 0; index < 256 /*0x0100*/; ++index)
      this.P[index] = (byte) index;
    VmpcEngine.KsaRound(this.P, ref this.s, keyBytes);
    VmpcEngine.KsaRound(this.P, ref this.s, ivBytes);
  }

  public virtual void ProcessBytes(byte[] input, int inOff, int len, byte[] output, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, len, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, len, "output buffer too short");
    for (int index1 = 0; index1 < len; ++index1)
    {
      byte num = this.P[(int) this.n];
      this.s = this.P[(int) this.s + (int) num & (int) byte.MaxValue];
      byte index2 = this.P[(int) this.s];
      output[outOff + index1] = (byte) ((uint) input[inOff + index1] ^ (uint) this.P[(int) this.P[(int) index2] + 1 & (int) byte.MaxValue]);
      this.P[(int) this.n] = index2;
      this.P[(int) this.s] = num;
      ++this.n;
    }
  }

  public virtual void Reset() => this.InitKey(this.workingKey, this.workingIV);

  public virtual byte ReturnByte(byte input)
  {
    byte num1 = this.P[(int) this.n];
    this.s = this.P[(int) this.s + (int) num1 & (int) byte.MaxValue];
    byte index = this.P[(int) this.s];
    int num2 = (int) (byte) ((uint) input ^ (uint) this.P[(int) this.P[(int) index] + 1 & (int) byte.MaxValue]);
    this.P[(int) this.n] = index;
    this.P[(int) this.s] = num1;
    ++this.n;
    return (byte) num2;
  }

  internal static void KsaRound(byte[] P, ref byte S, byte[] input)
  {
    byte index1 = S;
    int length = input.Length;
    int index2 = 0;
    for (int index3 = 0; index3 < 768 /*0x0300*/; ++index3)
    {
      byte num1 = P[index3 & (int) byte.MaxValue];
      index1 = P[(int) index1 + (int) num1 + (int) input[index2] & (int) byte.MaxValue];
      int num2 = index2 + 1 - length;
      index2 = num2 + (length & num2 >> 31 /*0x1F*/);
      P[index3 & (int) byte.MaxValue] = P[(int) index1];
      P[(int) index1] = num1;
    }
    S = index1;
  }
}
