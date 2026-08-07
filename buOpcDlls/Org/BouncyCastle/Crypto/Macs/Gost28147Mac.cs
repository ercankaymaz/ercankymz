// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Macs.Gost28147Mac
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Macs;

public class Gost28147Mac : IMac
{
  private const int BlockSize = 8;
  private const int MacSize = 4;
  private int bufOff;
  private byte[] buf;
  private byte[] mac;
  private bool firstStep = true;
  private int[] workingKey;
  private byte[] macIV;
  private byte[] S = new byte[128 /*0x80*/]
  {
    (byte) 9,
    (byte) 6,
    (byte) 3,
    (byte) 2,
    (byte) 8,
    (byte) 11,
    (byte) 1,
    (byte) 7,
    (byte) 10,
    (byte) 4,
    (byte) 14,
    (byte) 15,
    (byte) 12,
    (byte) 0,
    (byte) 13,
    (byte) 5,
    (byte) 3,
    (byte) 7,
    (byte) 14,
    (byte) 9,
    (byte) 8,
    (byte) 10,
    (byte) 15,
    (byte) 0,
    (byte) 5,
    (byte) 2,
    (byte) 6,
    (byte) 12,
    (byte) 11,
    (byte) 4,
    (byte) 13,
    (byte) 1,
    (byte) 14,
    (byte) 4,
    (byte) 6,
    (byte) 2,
    (byte) 11,
    (byte) 3,
    (byte) 13,
    (byte) 8,
    (byte) 12,
    (byte) 15,
    (byte) 5,
    (byte) 10,
    (byte) 0,
    (byte) 7,
    (byte) 1,
    (byte) 9,
    (byte) 14,
    (byte) 7,
    (byte) 10,
    (byte) 12,
    (byte) 13,
    (byte) 1,
    (byte) 3,
    (byte) 9,
    (byte) 0,
    (byte) 2,
    (byte) 11,
    (byte) 4,
    (byte) 15,
    (byte) 8,
    (byte) 5,
    (byte) 6,
    (byte) 11,
    (byte) 5,
    (byte) 1,
    (byte) 9,
    (byte) 8,
    (byte) 13,
    (byte) 15,
    (byte) 0,
    (byte) 14,
    (byte) 4,
    (byte) 2,
    (byte) 3,
    (byte) 12,
    (byte) 7,
    (byte) 10,
    (byte) 6,
    (byte) 3,
    (byte) 10,
    (byte) 13,
    (byte) 12,
    (byte) 1,
    (byte) 2,
    (byte) 0,
    (byte) 11,
    (byte) 7,
    (byte) 5,
    (byte) 9,
    (byte) 4,
    (byte) 8,
    (byte) 15,
    (byte) 14,
    (byte) 6,
    (byte) 1,
    (byte) 13,
    (byte) 2,
    (byte) 9,
    (byte) 7,
    (byte) 10,
    (byte) 6,
    (byte) 0,
    (byte) 8,
    (byte) 12,
    (byte) 4,
    (byte) 5,
    (byte) 15,
    (byte) 3,
    (byte) 11,
    (byte) 14,
    (byte) 11,
    (byte) 10,
    (byte) 15,
    (byte) 5,
    (byte) 0,
    (byte) 12,
    (byte) 14,
    (byte) 8,
    (byte) 6,
    (byte) 2,
    (byte) 3,
    (byte) 9,
    (byte) 1,
    (byte) 7,
    (byte) 13,
    (byte) 4
  };

  public Gost28147Mac()
  {
    this.mac = new byte[8];
    this.buf = new byte[8];
    this.bufOff = 0;
  }

  private static int[] GenerateWorkingKey(byte[] userKey)
  {
    if (userKey.Length != 32 /*0x20*/)
      throw new ArgumentException("Key length invalid. Key needs to be 32 byte - 256 bit!!!");
    int[] workingKey = new int[8];
    for (int index = 0; index != 8; ++index)
      workingKey[index] = (int) Pack.LE_To_UInt32(userKey, index * 4);
    return workingKey;
  }

  public void Init(ICipherParameters parameters)
  {
    this.Reset();
    this.buf = new byte[8];
    this.macIV = (byte[]) null;
    switch (parameters)
    {
      case ParametersWithSBox parametersWithSbox:
        parametersWithSbox.GetSBox().CopyTo((Array) this.S, 0);
        if (parametersWithSbox.Parameters == null)
          break;
        this.workingKey = Gost28147Mac.GenerateWorkingKey(((KeyParameter) parametersWithSbox.Parameters).GetKey());
        break;
      case KeyParameter keyParameter:
        this.workingKey = Gost28147Mac.GenerateWorkingKey(keyParameter.GetKey());
        break;
      case ParametersWithIV parametersWithIv:
        this.workingKey = Gost28147Mac.GenerateWorkingKey(((KeyParameter) parametersWithIv.Parameters).GetKey());
        this.macIV = parametersWithIv.GetIV();
        Array.Copy((Array) this.macIV, 0, (Array) this.mac, 0, this.mac.Length);
        break;
      default:
        throw new ArgumentException("invalid parameter passed to Gost28147 init - " + Platform.GetTypeName((object) parameters));
    }
  }

  public string AlgorithmName => nameof (Gost28147Mac);

  public int GetMacSize() => 4;

  private int Gost28147_mainStep(int n1, int key)
  {
    int num1 = key + n1;
    int num2 = (int) this.S[num1 & 15] + ((int) this.S[16 /*0x10*/ + (num1 >> 4 & 15)] << 4) + ((int) this.S[32 /*0x20*/ + (num1 >> 8 & 15)] << 8) + ((int) this.S[48 /*0x30*/ + (num1 >> 12 & 15)] << 12) + ((int) this.S[64 /*0x40*/ + (num1 >> 16 /*0x10*/ & 15)] << 16 /*0x10*/) + ((int) this.S[80 /*0x50*/ + (num1 >> 20 & 15)] << 20) + ((int) this.S[96 /*0x60*/ + (num1 >> 24 & 15)] << 24) + ((int) this.S[112 /*0x70*/ + (num1 >> 28 & 15)] << 28);
    return num2 << 11 | num2 >>> 21;
  }

  private void Gost28147MacFunc(
    int[] workingKey,
    byte[] input,
    int inOff,
    byte[] output,
    int outOff)
  {
    int num1 = (int) Pack.LE_To_UInt32(input, inOff);
    int n = (int) Pack.LE_To_UInt32(input, inOff + 4);
    for (int index1 = 0; index1 < 2; ++index1)
    {
      for (int index2 = 0; index2 < 8; ++index2)
      {
        int num2 = num1;
        num1 = n ^ this.Gost28147_mainStep(num1, workingKey[index2]);
        n = num2;
      }
    }
    Pack.UInt32_To_LE((uint) num1, output, outOff);
    Pack.UInt32_To_LE((uint) n, output, outOff + 4);
  }

  public void Update(byte input)
  {
    if (this.bufOff == this.buf.Length)
    {
      byte[] numArray = new byte[this.buf.Length];
      if (this.firstStep)
      {
        this.firstStep = false;
        if (this.macIV != null)
          Gost28147Mac.Cm5Func(this.buf, 0, this.macIV, numArray);
        else
          Array.Copy((Array) this.buf, 0, (Array) numArray, 0, this.mac.Length);
      }
      else
        Gost28147Mac.Cm5Func(this.buf, 0, this.mac, numArray);
      this.Gost28147MacFunc(this.workingKey, numArray, 0, this.mac, 0);
      this.bufOff = 0;
    }
    this.buf[this.bufOff++] = input;
  }

  public void BlockUpdate(byte[] input, int inOff, int len)
  {
    if (len < 0)
      throw new ArgumentException("Can't have a negative input length!");
    int length = 8 - this.bufOff;
    if (len > length)
    {
      Array.Copy((Array) input, inOff, (Array) this.buf, this.bufOff, length);
      byte[] numArray = new byte[this.buf.Length];
      if (this.firstStep)
      {
        this.firstStep = false;
        if (this.macIV != null)
          Gost28147Mac.Cm5Func(this.buf, 0, this.macIV, numArray);
        else
          Array.Copy((Array) this.buf, 0, (Array) numArray, 0, this.mac.Length);
      }
      else
        Gost28147Mac.Cm5Func(this.buf, 0, this.mac, numArray);
      this.Gost28147MacFunc(this.workingKey, numArray, 0, this.mac, 0);
      this.bufOff = 0;
      len -= length;
      inOff += length;
      while (len > 8)
      {
        Gost28147Mac.Cm5Func(input, inOff, this.mac, numArray);
        this.Gost28147MacFunc(this.workingKey, numArray, 0, this.mac, 0);
        len -= 8;
        inOff += 8;
      }
    }
    Array.Copy((Array) input, inOff, (Array) this.buf, this.bufOff, len);
    this.bufOff += len;
  }

  public int DoFinal(byte[] output, int outOff)
  {
    while (this.bufOff < 8)
      this.buf[this.bufOff++] = (byte) 0;
    byte[] numArray = new byte[this.buf.Length];
    if (this.firstStep)
    {
      this.firstStep = false;
      Array.Copy((Array) this.buf, 0, (Array) numArray, 0, this.mac.Length);
    }
    else
      Gost28147Mac.Cm5Func(this.buf, 0, this.mac, numArray);
    this.Gost28147MacFunc(this.workingKey, numArray, 0, this.mac, 0);
    Array.Copy((Array) this.mac, this.mac.Length / 2 - 4, (Array) output, outOff, 4);
    this.Reset();
    return 4;
  }

  public void Reset()
  {
    Array.Clear((Array) this.buf, 0, this.buf.Length);
    this.bufOff = 0;
    this.firstStep = true;
  }

  private static void Cm5Func(byte[] buf, int bufOff, byte[] mac, byte[] sum)
  {
    for (int index = 0; index < 8; ++index)
      sum[index] = (byte) ((uint) buf[bufOff + index] ^ (uint) mac[index]);
  }
}
