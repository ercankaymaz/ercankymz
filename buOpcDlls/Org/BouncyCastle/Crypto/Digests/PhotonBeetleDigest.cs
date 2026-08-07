// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.PhotonBeetleDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public sealed class PhotonBeetleDigest : IDigest
{
  private byte[] state;
  private byte[][] state_2d;
  private MemoryStream buffer = new MemoryStream();
  private const int INITIAL_RATE_INBYTES = 16 /*0x10*/;
  private int RATE_INBYTES = 4;
  private int SQUEEZE_RATE_INBYTES = 16 /*0x10*/;
  private int STATE_INBYTES = 32 /*0x20*/;
  private int TAG_INBYTES = 32 /*0x20*/;
  private int LAST_THREE_BITS_OFFSET = 5;
  private int ROUND = 12;
  private int D = 8;
  private int Dq = 3;
  private int Dr = 7;
  private int DSquare = 64 /*0x40*/;
  private int S = 4;
  private int S_1 = 3;
  private byte[][] RC = new byte[8][]
  {
    new byte[12]
    {
      (byte) 1,
      (byte) 3,
      (byte) 7,
      (byte) 14,
      (byte) 13,
      (byte) 11,
      (byte) 6,
      (byte) 12,
      (byte) 9,
      (byte) 2,
      (byte) 5,
      (byte) 10
    },
    new byte[12]
    {
      (byte) 0,
      (byte) 2,
      (byte) 6,
      (byte) 15,
      (byte) 12,
      (byte) 10,
      (byte) 7,
      (byte) 13,
      (byte) 8,
      (byte) 3,
      (byte) 4,
      (byte) 11
    },
    new byte[12]
    {
      (byte) 2,
      (byte) 0,
      (byte) 4,
      (byte) 13,
      (byte) 14,
      (byte) 8,
      (byte) 5,
      (byte) 15,
      (byte) 10,
      (byte) 1,
      (byte) 6,
      (byte) 9
    },
    new byte[12]
    {
      (byte) 6,
      (byte) 4,
      (byte) 0,
      (byte) 9,
      (byte) 10,
      (byte) 12,
      (byte) 1,
      (byte) 11,
      (byte) 14,
      (byte) 5,
      (byte) 2,
      (byte) 13
    },
    new byte[12]
    {
      (byte) 14,
      (byte) 12,
      (byte) 8,
      (byte) 1,
      (byte) 2,
      (byte) 4,
      (byte) 9,
      (byte) 3,
      (byte) 6,
      (byte) 13,
      (byte) 10,
      (byte) 5
    },
    new byte[12]
    {
      (byte) 15,
      (byte) 13,
      (byte) 9,
      (byte) 0,
      (byte) 3,
      (byte) 5,
      (byte) 8,
      (byte) 2,
      (byte) 7,
      (byte) 12,
      (byte) 11,
      (byte) 4
    },
    new byte[12]
    {
      (byte) 13,
      (byte) 15,
      (byte) 11,
      (byte) 2,
      (byte) 1,
      (byte) 7,
      (byte) 10,
      (byte) 0,
      (byte) 5,
      (byte) 14,
      (byte) 9,
      (byte) 6
    },
    new byte[12]
    {
      (byte) 9,
      (byte) 11,
      (byte) 15,
      (byte) 6,
      (byte) 5,
      (byte) 3,
      (byte) 14,
      (byte) 4,
      (byte) 1,
      (byte) 10,
      (byte) 13,
      (byte) 2
    }
  };
  private byte[][] MixColMatrix = new byte[8][]
  {
    new byte[8]
    {
      (byte) 2,
      (byte) 4,
      (byte) 2,
      (byte) 11,
      (byte) 2,
      (byte) 8,
      (byte) 5,
      (byte) 6
    },
    new byte[8]
    {
      (byte) 12,
      (byte) 9,
      (byte) 8,
      (byte) 13,
      (byte) 7,
      (byte) 7,
      (byte) 5,
      (byte) 2
    },
    new byte[8]
    {
      (byte) 4,
      (byte) 4,
      (byte) 13,
      (byte) 13,
      (byte) 9,
      (byte) 4,
      (byte) 13,
      (byte) 9
    },
    new byte[8]
    {
      (byte) 1,
      (byte) 6,
      (byte) 5,
      (byte) 1,
      (byte) 12,
      (byte) 13,
      (byte) 15,
      (byte) 14
    },
    new byte[8]
    {
      (byte) 15,
      (byte) 12,
      (byte) 9,
      (byte) 13,
      (byte) 14,
      (byte) 5,
      (byte) 14,
      (byte) 13
    },
    new byte[8]
    {
      (byte) 9,
      (byte) 14,
      (byte) 5,
      (byte) 15,
      (byte) 4,
      (byte) 12,
      (byte) 9,
      (byte) 6
    },
    new byte[8]
    {
      (byte) 12,
      (byte) 2,
      (byte) 2,
      (byte) 10,
      (byte) 3,
      (byte) 1,
      (byte) 1,
      (byte) 14
    },
    new byte[8]
    {
      (byte) 15,
      (byte) 1,
      (byte) 13,
      (byte) 10,
      (byte) 5,
      (byte) 10,
      (byte) 2,
      (byte) 3
    }
  };
  private byte[] sbox = new byte[16 /*0x10*/]
  {
    (byte) 12,
    (byte) 5,
    (byte) 6,
    (byte) 11,
    (byte) 9,
    (byte) 0,
    (byte) 10,
    (byte) 13,
    (byte) 3,
    (byte) 14,
    (byte) 15,
    (byte) 8,
    (byte) 4,
    (byte) 7,
    (byte) 1,
    (byte) 2
  };

  public PhotonBeetleDigest()
  {
    this.state = new byte[this.STATE_INBYTES];
    this.state_2d = new byte[this.D][];
    for (int index = 0; index < this.D; ++index)
      this.state_2d[index] = new byte[this.D];
  }

  public string AlgorithmName => "Photon-Beetle Hash";

  public int GetDigestSize() => this.TAG_INBYTES;

  public int GetByteLength() => throw new NotImplementedException();

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
    if (length == 0)
      this.state[this.STATE_INBYTES - 1] ^= (byte) (1 << this.LAST_THREE_BITS_OFFSET);
    else if (length <= 16 /*0x10*/)
    {
      Array.Copy((Array) buffer, 0, (Array) this.state, 0, length);
      if (length < 16 /*0x10*/)
        this.state[length] ^= (byte) 1;
      this.state[this.STATE_INBYTES - 1] ^= (byte) ((length < 16 /*0x10*/ ? 1 : 2) << this.LAST_THREE_BITS_OFFSET);
    }
    else
    {
      Array.Copy((Array) buffer, 0, (Array) this.state, 0, 16 /*0x10*/);
      int num1 = length - 16 /*0x10*/;
      int num2 = (num1 + this.RATE_INBYTES - 1) / this.RATE_INBYTES;
      int num3;
      for (num3 = 0; num3 < num2 - 1; ++num3)
      {
        this.PHOTON_Permutation();
        Bytes.XorTo(this.RATE_INBYTES, buffer, 16 /*0x10*/ + num3 * this.RATE_INBYTES, this.state, 0);
      }
      this.PHOTON_Permutation();
      int len = num1 - num3 * this.RATE_INBYTES;
      Bytes.XorTo(len, buffer, 16 /*0x10*/ + num3 * this.RATE_INBYTES, this.state, 0);
      if (len < this.RATE_INBYTES)
        this.state[len] ^= (byte) 1;
      this.state[this.STATE_INBYTES - 1] ^= (byte) ((num1 % this.RATE_INBYTES == 0 ? 1 : 2) << this.LAST_THREE_BITS_OFFSET);
    }
    this.PHOTON_Permutation();
    Array.Copy((Array) this.state, 0, (Array) output, outOff, this.SQUEEZE_RATE_INBYTES);
    this.PHOTON_Permutation();
    Array.Copy((Array) this.state, 0, (Array) output, outOff + this.SQUEEZE_RATE_INBYTES, this.TAG_INBYTES - this.SQUEEZE_RATE_INBYTES);
    return this.TAG_INBYTES;
  }

  public void Reset()
  {
    this.buffer.SetLength(0L);
    Arrays.Fill(this.state, (byte) 0);
  }

  private void PHOTON_Permutation()
  {
    for (int index = 0; index < this.DSquare; ++index)
      this.state_2d[index >> this.Dq][index & this.Dr] = (byte) (((int) this.state[index >> 1] & (int) byte.MaxValue) >> 4 * (index & 1) & 15);
    for (int index1 = 0; index1 < this.ROUND; ++index1)
    {
      for (int index2 = 0; index2 < this.D; ++index2)
        this.state_2d[index2][0] ^= this.RC[index2][index1];
      for (int index3 = 0; index3 < this.D; ++index3)
      {
        for (int index4 = 0; index4 < this.D; ++index4)
          this.state_2d[index3][index4] = this.sbox[(int) this.state_2d[index3][index4]];
      }
      for (int index5 = 1; index5 < this.D; ++index5)
      {
        Array.Copy((Array) this.state_2d[index5], 0, (Array) this.state, 0, this.D);
        Array.Copy((Array) this.state, index5, (Array) this.state_2d[index5], 0, this.D - index5);
        Array.Copy((Array) this.state, 0, (Array) this.state_2d[index5], this.D - index5, index5);
      }
      for (int index6 = 0; index6 < this.D; ++index6)
      {
        for (int index7 = 0; index7 < this.D; ++index7)
        {
          byte num1 = 0;
          for (int index8 = 0; index8 < this.D; ++index8)
          {
            int num2 = (int) this.MixColMatrix[index7][index8];
            int num3 = 0;
            int num4 = (int) this.state_2d[index8][index6];
            for (int index9 = 0; index9 < this.S; ++index9)
            {
              if ((num4 >> index9 & 1) != 0)
                num3 ^= num2;
              if ((num2 >> this.S_1 & 1) != 0)
                num2 = num2 << 1 ^ 3;
              else
                num2 <<= 1;
            }
            num1 ^= (byte) (num3 & 15);
          }
          this.state[index7] = num1;
        }
        for (int index10 = 0; index10 < this.D; ++index10)
          this.state_2d[index10][index6] = this.state[index10];
      }
    }
    for (int index = 0; index < this.DSquare; index += 2)
      this.state[index >> 1] = (byte) ((int) this.state_2d[index >> this.Dq][index & this.Dr] & 15 | ((int) this.state_2d[index >> this.Dq][index + 1 & this.Dr] & 15) << 4);
  }
}
