// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.Grain128AeadEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public sealed class Grain128AeadEngine : IAeadCipher
{
  private static readonly int STATE_SIZE = 4;
  private byte[] workingKey;
  private byte[] workingIV;
  private uint[] lfsr;
  private uint[] nfsr;
  private uint[] authAcc;
  private uint[] authSr;
  private bool initialised;
  private bool aadFinished;
  private MemoryStream aadData = new MemoryStream();
  private byte[] mac;

  public string AlgorithmName => "Grain-128AEAD";

  public void Init(bool forEncryption, ICipherParameters param)
  {
    byte[] sourceArray = param is ParametersWithIV parametersWithIv ? parametersWithIv.GetIV() : throw new ArgumentException("Grain-128AEAD Init parameters must include an IV");
    if (sourceArray == null || sourceArray.Length != 12)
      throw new ArgumentException("Grain-128AEAD requires exactly 12 bytes of IV");
    if (!(parametersWithIv.Parameters is KeyParameter parameters))
      throw new ArgumentException("Grain-128AEAD Init parameters must include a key");
    byte[] key = parameters.GetKey();
    this.workingIV = key.Length == 16 /*0x10*/ ? new byte[key.Length] : throw new ArgumentException("Grain-128AEAD key must be 128 bits long");
    this.workingKey = key;
    this.lfsr = new uint[Grain128AeadEngine.STATE_SIZE];
    this.nfsr = new uint[Grain128AeadEngine.STATE_SIZE];
    this.authAcc = new uint[2];
    this.authSr = new uint[2];
    Array.Copy((Array) sourceArray, 0, (Array) this.workingIV, 0, sourceArray.Length);
    this.Reset();
  }

  private void InitGrain()
  {
    for (int index = 0; index < 320; ++index)
    {
      uint output = this.GetOutput();
      this.nfsr = this.Shift(this.nfsr, (uint) (((int) this.GetOutputNFSR() ^ (int) this.lfsr[0] ^ (int) output) & 1));
      this.lfsr = this.Shift(this.lfsr, (uint) (((int) this.GetOutputLFSR() ^ (int) output) & 1));
    }
    for (int index1 = 0; index1 < 8; ++index1)
    {
      for (int index2 = 0; index2 < 8; ++index2)
      {
        uint output = this.GetOutput();
        this.nfsr = this.Shift(this.nfsr, (uint) (((int) this.GetOutputNFSR() ^ (int) this.lfsr[0] ^ (int) output ^ (int) this.workingKey[index1] >> index2) & 1));
        this.lfsr = this.Shift(this.lfsr, (uint) (((int) this.GetOutputLFSR() ^ (int) output ^ (int) this.workingKey[index1 + 8] >> index2) & 1));
      }
    }
    for (int index3 = 0; index3 < 2; ++index3)
    {
      for (int index4 = 0; index4 < 32 /*0x20*/; ++index4)
      {
        uint output = this.GetOutput();
        this.nfsr = this.Shift(this.nfsr, (uint) (((int) this.GetOutputNFSR() ^ (int) this.lfsr[0]) & 1));
        this.lfsr = this.Shift(this.lfsr, this.GetOutputLFSR() & 1U);
        this.authAcc[index3] |= output << index4;
      }
    }
    for (int index5 = 0; index5 < 2; ++index5)
    {
      for (int index6 = 0; index6 < 32 /*0x20*/; ++index6)
      {
        uint output = this.GetOutput();
        this.nfsr = this.Shift(this.nfsr, (uint) (((int) this.GetOutputNFSR() ^ (int) this.lfsr[0]) & 1));
        this.lfsr = this.Shift(this.lfsr, this.GetOutputLFSR() & 1U);
        this.authSr[index5] |= output << index6;
      }
    }
    this.initialised = true;
  }

  private uint GetOutputNFSR()
  {
    int num1 = (int) this.nfsr[0];
    uint num2 = this.nfsr[0] >> 3;
    uint num3 = this.nfsr[0] >> 11;
    uint num4 = this.nfsr[0] >> 13;
    uint num5 = this.nfsr[0] >> 17;
    uint num6 = this.nfsr[0] >> 18;
    uint num7 = this.nfsr[0] >> 22;
    uint num8 = this.nfsr[0] >> 24;
    uint num9 = this.nfsr[0] >> 25;
    uint num10 = this.nfsr[0] >> 26;
    uint num11 = this.nfsr[0] >> 27;
    uint num12 = this.nfsr[1] >> 8;
    uint num13 = this.nfsr[1] >> 16 /*0x10*/;
    uint num14 = this.nfsr[1] >> 24;
    uint num15 = this.nfsr[1] >> 27;
    uint num16 = this.nfsr[1] >> 29;
    uint num17 = this.nfsr[2] >> 1;
    uint num18 = this.nfsr[2] >> 3;
    uint num19 = this.nfsr[2] >> 4;
    uint num20 = this.nfsr[2] >> 6;
    uint num21 = this.nfsr[2] >> 14;
    uint num22 = this.nfsr[2] >> 18;
    uint num23 = this.nfsr[2] >> 20;
    uint num24 = this.nfsr[2] >> 24;
    uint num25 = this.nfsr[2] >> 27;
    uint num26 = this.nfsr[2] >> 28;
    uint num27 = this.nfsr[2] >> 29;
    uint num28 = this.nfsr[2] >> 31 /*0x1F*/;
    uint num29 = this.nfsr[3];
    int num30 = (int) num10;
    return (uint) ((num1 ^ num30 ^ (int) num14 ^ (int) num25 ^ (int) num29 ^ (int) num2 & (int) num18 ^ (int) num3 & (int) num4 ^ (int) num5 & (int) num6 ^ (int) num11 & (int) num15 ^ (int) num12 & (int) num13 ^ (int) num16 & (int) num17 ^ (int) num19 & (int) num23 ^ (int) num7 & (int) num8 & (int) num9 ^ (int) num20 & (int) num21 & (int) num22 ^ (int) num24 & (int) num26 & (int) num27 & (int) num28) & 1);
  }

  private uint GetOutputLFSR()
  {
    int num1 = (int) this.lfsr[0];
    uint num2 = this.lfsr[0] >> 7;
    uint num3 = this.lfsr[1] >> 6;
    uint num4 = this.lfsr[2] >> 6;
    uint num5 = this.lfsr[2] >> 17;
    uint num6 = this.lfsr[3];
    int num7 = (int) num2;
    return (uint) ((num1 ^ num7 ^ (int) num3 ^ (int) num4 ^ (int) num5 ^ (int) num6) & 1);
  }

  private uint GetOutput()
  {
    uint num1 = this.nfsr[0] >> 2;
    uint num2 = this.nfsr[0] >> 12;
    uint num3 = this.nfsr[0] >> 15;
    uint num4 = this.nfsr[1] >> 4;
    uint num5 = this.nfsr[1] >> 13;
    uint num6 = this.nfsr[2];
    uint num7 = this.nfsr[2] >> 9;
    uint num8 = this.nfsr[2] >> 25;
    uint num9 = this.nfsr[2] >> 31 /*0x1F*/;
    uint num10 = this.lfsr[0] >> 8;
    uint num11 = this.lfsr[0] >> 13;
    uint num12 = this.lfsr[0] >> 20;
    uint num13 = this.lfsr[1] >> 10;
    uint num14 = this.lfsr[1] >> 28;
    uint num15 = this.lfsr[2] >> 15;
    uint num16 = this.lfsr[2] >> 29;
    uint num17 = this.lfsr[2] >> 30;
    return (uint) (((int) num2 & (int) num10 ^ (int) num11 & (int) num12 ^ (int) num9 & (int) num13 ^ (int) num14 & (int) num15 ^ (int) num2 & (int) num9 & (int) num17 ^ (int) num16 ^ (int) num1 ^ (int) num3 ^ (int) num4 ^ (int) num5 ^ (int) num6 ^ (int) num7 ^ (int) num8) & 1);
  }

  private uint[] Shift(uint[] array, uint val)
  {
    array[0] = array[0] >> 1 | array[1] << 31 /*0x1F*/;
    array[1] = array[1] >> 1 | array[2] << 31 /*0x1F*/;
    array[2] = array[2] >> 1 | array[3] << 31 /*0x1F*/;
    array[3] = array[3] >> 1 | val << 31 /*0x1F*/;
    return array;
  }

  private void SetKey(byte[] keyBytes, byte[] ivBytes)
  {
    ivBytes[12] = byte.MaxValue;
    ivBytes[13] = byte.MaxValue;
    ivBytes[14] = byte.MaxValue;
    ivBytes[15] = (byte) 127 /*0x7F*/;
    this.workingKey = keyBytes;
    this.workingIV = ivBytes;
    Pack.LE_To_UInt32(this.workingKey, 0, this.nfsr);
    Pack.LE_To_UInt32(this.workingIV, 0, this.lfsr);
  }

  public int ProcessBytes(byte[] input, int inOff, int len, byte[] output, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, len, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, len, "output buffer too short");
    if (!this.initialised)
      throw new ArgumentException(this.AlgorithmName + " not initialised");
    if (!this.aadFinished)
    {
      this.DoProcessAADBytes(this.aadData.GetBuffer(), 0, (int) this.aadData.Length);
      this.aadFinished = true;
    }
    this.GetKeyStream(input, inOff, len, output, outOff);
    return len;
  }

  public void Reset() => this.Reset(true);

  private void Reset(bool clearMac)
  {
    if (clearMac)
      this.mac = (byte[]) null;
    this.aadData.SetLength(0L);
    this.aadFinished = false;
    this.SetKey(this.workingKey, this.workingIV);
    this.InitGrain();
  }

  private void GetKeyStream(byte[] input, int inOff, int len, byte[] ciphertext, int outOff)
  {
    for (int index1 = 0; index1 < len; ++index1)
    {
      uint num1 = 0;
      uint num2 = (uint) input[inOff + index1];
      for (int index2 = 0; index2 < 8; ++index2)
      {
        uint output = this.GetOutput();
        this.nfsr = this.Shift(this.nfsr, (uint) (((int) this.GetOutputNFSR() ^ (int) this.lfsr[0]) & 1));
        this.lfsr = this.Shift(this.lfsr, this.GetOutputLFSR() & 1U);
        uint num3 = num2 >> index2 & 1U;
        num1 |= (uint) (((int) num3 ^ (int) output) << index2);
        uint num4 = (uint) -(int) num3;
        this.authAcc[0] ^= this.authSr[0] & num4;
        this.authAcc[1] ^= this.authSr[1] & num4;
        this.AuthShift(this.GetOutput());
        this.nfsr = this.Shift(this.nfsr, (uint) (((int) this.GetOutputNFSR() ^ (int) this.lfsr[0]) & 1));
        this.lfsr = this.Shift(this.lfsr, this.GetOutputLFSR() & 1U);
      }
      ciphertext[outOff + index1] = (byte) num1;
    }
  }

  public byte ReturnByte(byte input)
  {
    if (!this.initialised)
      throw new ArgumentException(this.AlgorithmName + " not initialised");
    byte[] input1 = new byte[1]{ input };
    byte[] ciphertext = new byte[1];
    this.GetKeyStream(input1, 0, 1, ciphertext, 0);
    return ciphertext[0];
  }

  public void ProcessAadByte(byte input)
  {
    if (this.aadFinished)
      throw new ArgumentException("associated data must be added before plaintext/ciphertext");
    this.aadData.WriteByte(input);
  }

  public void ProcessAadBytes(byte[] input, int inOff, int len)
  {
    if (this.aadFinished)
      throw new ArgumentException("associated data must be added before plaintext/ciphertext");
    this.aadData.Write(input, inOff, len);
  }

  private void Accumulate()
  {
    this.authAcc[0] ^= this.authSr[0];
    this.authAcc[1] ^= this.authSr[1];
  }

  private void AuthShift(uint val)
  {
    this.authSr[0] = this.authSr[0] >> 1 | this.authSr[1] << 31 /*0x1F*/;
    this.authSr[1] = this.authSr[1] >> 1 | val << 31 /*0x1F*/;
  }

  public int ProcessByte(byte input, byte[] output, int outOff)
  {
    return this.ProcessBytes(new byte[1]{ input }, 0, 1, output, outOff);
  }

  private void DoProcessAADBytes(byte[] input, int inOff, int len)
  {
    byte[] numArray;
    int num1;
    if (len < 128 /*0x80*/)
    {
      numArray = new byte[1 + len];
      numArray[0] = (byte) len;
      num1 = 0;
    }
    else
    {
      num1 = Grain128AeadEngine.LenLength(len);
      numArray = new byte[num1 + 1 + len];
      numArray[0] = (byte) (128 /*0x80*/ | num1);
      uint num2 = (uint) len;
      for (int index = 0; index < num1; ++index)
      {
        numArray[1 + index] = (byte) num2;
        num2 >>= 8;
      }
    }
    for (int index = 0; index < len; ++index)
      numArray[1 + num1 + index] = input[inOff + index];
    for (int index1 = 0; index1 < numArray.Length; ++index1)
    {
      uint num3 = (uint) numArray[index1];
      for (int index2 = 0; index2 < 8; ++index2)
      {
        this.nfsr = this.Shift(this.nfsr, (uint) (((int) this.GetOutputNFSR() ^ (int) this.lfsr[0]) & 1));
        this.lfsr = this.Shift(this.lfsr, this.GetOutputLFSR() & 1U);
        uint num4 = (uint) -(int) (num3 >> index2 & 1U);
        this.authAcc[0] ^= this.authSr[0] & num4;
        this.authAcc[1] ^= this.authSr[1] & num4;
        this.AuthShift(this.GetOutput());
        this.nfsr = this.Shift(this.nfsr, (uint) (((int) this.GetOutputNFSR() ^ (int) this.lfsr[0]) & 1));
        this.lfsr = this.Shift(this.lfsr, this.GetOutputLFSR() & 1U);
      }
    }
  }

  public int DoFinal(byte[] output, int outOff)
  {
    if (!this.aadFinished)
    {
      this.DoProcessAADBytes(this.aadData.GetBuffer(), 0, (int) this.aadData.Length);
      this.aadFinished = true;
    }
    this.Accumulate();
    this.mac = Pack.UInt32_To_LE(this.authAcc);
    Array.Copy((Array) this.mac, 0, (Array) output, outOff, this.mac.Length);
    this.Reset(false);
    return this.mac.Length;
  }

  public byte[] GetMac() => this.mac;

  public int GetUpdateOutputSize(int len) => len;

  public int GetOutputSize(int len) => len + 8;

  private static int LenLength(int v)
  {
    if ((v & (int) byte.MaxValue) == v)
      return 1;
    if ((v & (int) ushort.MaxValue) == v)
      return 2;
    return (v & 16777215 /*0xFFFFFF*/) == v ? 3 : 4;
  }
}
