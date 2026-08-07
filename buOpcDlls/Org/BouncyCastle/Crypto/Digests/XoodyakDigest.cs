// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.XoodyakDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public sealed class XoodyakDigest : IDigest
{
  private const int Rkin = 44;
  private static readonly uint[] RC = new uint[12]
  {
    88U,
    56U,
    960U,
    208U /*0xD0*/,
    288U,
    20U,
    96U /*0x60*/,
    44U,
    896U,
    240U /*0xF0*/,
    416U,
    18U
  };
  private byte[] state;
  private int phase;
  private XoodyakDigest.MODE mode;
  private int Rabsorb;
  private const int f_bPrime = 48 /*0x30*/;
  private const int Rkout = 24;
  private const int PhaseDown = 1;
  private const int PhaseUp = 2;
  private const int NLANES = 12;
  private const int NROWS = 3;
  private const int NCOLUMNS = 4;
  private const int MAXROUNDS = 12;
  private const int TAGLEN = 16 /*0x10*/;
  private const int Rhash = 16 /*0x10*/;
  private readonly MemoryStream buffer = new MemoryStream();

  public XoodyakDigest()
  {
    this.state = new byte[48 /*0x30*/];
    this.Reset();
  }

  public string AlgorithmName => "Xoodyak Hash";

  public int GetDigestSize() => 32 /*0x20*/;

  public int GetByteLength() => this.Rabsorb;

  public void Update(byte input) => this.buffer.WriteByte(input);

  public void BlockUpdate(byte[] input, int inOff, int inLen)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, inLen, "input buffer too short");
    this.buffer.Write(input, inOff, inLen);
  }

  public int DoFinal(byte[] output, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, 32 /*0x20*/, "output buffer is too short");
    byte[] buffer = this.buffer.GetBuffer();
    int length = (int) this.buffer.Length;
    int XiOff = 0;
    uint Cd = 3;
    do
    {
      if (this.phase != 2)
        goto label_2;
label_1:
      int XiLen = Math.Min(length, this.Rabsorb);
      this.Down(buffer, XiOff, XiLen, Cd);
      Cd = 0U;
      XiOff += XiLen;
      length -= XiLen;
      continue;
label_2:
      this.Up((byte[]) null, 0, 0, 0U);
      goto label_1;
    }
    while (length != 0);
    this.Up(output, outOff, 16 /*0x10*/, 64U /*0x40*/);
    this.Down((byte[]) null, 0, 0, 0U);
    this.Up(output, outOff + 16 /*0x10*/, 16 /*0x10*/, 0U);
    return 32 /*0x20*/;
  }

  public void Reset()
  {
    Array.Clear((Array) this.state, 0, this.state.Length);
    this.phase = 2;
    this.mode = XoodyakDigest.MODE.ModeHash;
    this.Rabsorb = 16 /*0x10*/;
    this.buffer.SetLength(0L);
  }

  private void Up(byte[] Yi, int YiOff, int YiLen, uint Cu)
  {
    if (this.mode != XoodyakDigest.MODE.ModeHash)
      this.state[47] ^= (byte) Cu;
    uint[] numArray1 = new uint[12];
    Pack.LE_To_UInt32(this.state, 0, numArray1, 0, numArray1.Length);
    uint[] sourceArray = new uint[12];
    uint[] numArray2 = new uint[4];
    uint[] numArray3 = new uint[4];
    for (int index1 = 0; index1 < 12; ++index1)
    {
      for (uint x = 0; x < 4U; ++x)
        numArray2[(int) x] = numArray1[(int) this.index(x, 0U)] ^ numArray1[(int) this.index(x, 1U)] ^ numArray1[(int) this.index(x, 2U)];
      for (uint index2 = 0; index2 < 4U; ++index2)
      {
        uint i = numArray2[(int) index2 + 3 & 3];
        numArray3[(int) index2] = Integers.RotateLeft(i, 5) ^ Integers.RotateLeft(i, 14);
      }
      for (uint x = 0; x < 4U; ++x)
      {
        for (uint y = 0; y < 3U; ++y)
          numArray1[(int) this.index(x, y)] ^= numArray3[(int) x];
      }
      for (uint x = 0; x < 4U; ++x)
      {
        sourceArray[(int) this.index(x, 0U)] = numArray1[(int) this.index(x, 0U)];
        sourceArray[(int) this.index(x, 1U)] = numArray1[(int) this.index(x + 3U, 1U)];
        sourceArray[(int) this.index(x, 2U)] = Integers.RotateLeft(numArray1[(int) this.index(x, 2U)], 11);
      }
      sourceArray[0] ^= XoodyakDigest.RC[index1];
      for (uint x = 0; x < 4U; ++x)
      {
        for (uint y = 0; y < 3U; ++y)
          numArray1[(int) this.index(x, y)] = sourceArray[(int) this.index(x, y)] ^ ~sourceArray[(int) this.index(x, y + 1U)] & sourceArray[(int) this.index(x, y + 2U)];
      }
      for (uint x = 0; x < 4U; ++x)
      {
        sourceArray[(int) this.index(x, 0U)] = numArray1[(int) this.index(x, 0U)];
        sourceArray[(int) this.index(x, 1U)] = Integers.RotateLeft(numArray1[(int) this.index(x, 1U)], 1);
        sourceArray[(int) this.index(x, 2U)] = Integers.RotateLeft(numArray1[(int) this.index(x + 2U, 2U)], 8);
      }
      Array.Copy((Array) sourceArray, 0, (Array) numArray1, 0, 12);
    }
    Pack.UInt32_To_LE(numArray1, 0, numArray1.Length, this.state, 0);
    this.phase = 2;
    if (Yi == null)
      return;
    Array.Copy((Array) this.state, 0, (Array) Yi, YiOff, YiLen);
  }

  private void Down(byte[] Xi, int XiOff, int XiLen, uint Cd)
  {
    for (int index = 0; index < XiLen; ++index)
      this.state[index] ^= Xi[XiOff++];
    this.state[XiLen] ^= (byte) 1;
    this.state[47] ^= this.mode == XoodyakDigest.MODE.ModeHash ? (byte) ((int) Cd & 1) : (byte) Cd;
    this.phase = 1;
  }

  private uint index(uint x, uint y) => y % 3U * 4U + x % 4U;

  private enum MODE
  {
    ModeHash,
    ModeKeyed,
  }
}
