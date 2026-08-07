// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.Blake2bDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public sealed class Blake2bDigest : IDigest
{
  private static readonly ulong[] blake2b_IV = new ulong[8]
  {
    7640891576956012808UL,
    13503953896175478587UL,
    4354685564936845355UL,
    11912009170470909681UL,
    5840696475078001361UL,
    11170449401992604703UL,
    2270897969802886507UL,
    6620516959819538809UL
  };
  private static readonly byte[,] blake2b_sigma = new byte[12, 16 /*0x10*/]
  {
    {
      (byte) 0,
      (byte) 1,
      (byte) 2,
      (byte) 3,
      (byte) 4,
      (byte) 5,
      (byte) 6,
      (byte) 7,
      (byte) 8,
      (byte) 9,
      (byte) 10,
      (byte) 11,
      (byte) 12,
      (byte) 13,
      (byte) 14,
      (byte) 15
    },
    {
      (byte) 14,
      (byte) 10,
      (byte) 4,
      (byte) 8,
      (byte) 9,
      (byte) 15,
      (byte) 13,
      (byte) 6,
      (byte) 1,
      (byte) 12,
      (byte) 0,
      (byte) 2,
      (byte) 11,
      (byte) 7,
      (byte) 5,
      (byte) 3
    },
    {
      (byte) 11,
      (byte) 8,
      (byte) 12,
      (byte) 0,
      (byte) 5,
      (byte) 2,
      (byte) 15,
      (byte) 13,
      (byte) 10,
      (byte) 14,
      (byte) 3,
      (byte) 6,
      (byte) 7,
      (byte) 1,
      (byte) 9,
      (byte) 4
    },
    {
      (byte) 7,
      (byte) 9,
      (byte) 3,
      (byte) 1,
      (byte) 13,
      (byte) 12,
      (byte) 11,
      (byte) 14,
      (byte) 2,
      (byte) 6,
      (byte) 5,
      (byte) 10,
      (byte) 4,
      (byte) 0,
      (byte) 15,
      (byte) 8
    },
    {
      (byte) 9,
      (byte) 0,
      (byte) 5,
      (byte) 7,
      (byte) 2,
      (byte) 4,
      (byte) 10,
      (byte) 15,
      (byte) 14,
      (byte) 1,
      (byte) 11,
      (byte) 12,
      (byte) 6,
      (byte) 8,
      (byte) 3,
      (byte) 13
    },
    {
      (byte) 2,
      (byte) 12,
      (byte) 6,
      (byte) 10,
      (byte) 0,
      (byte) 11,
      (byte) 8,
      (byte) 3,
      (byte) 4,
      (byte) 13,
      (byte) 7,
      (byte) 5,
      (byte) 15,
      (byte) 14,
      (byte) 1,
      (byte) 9
    },
    {
      (byte) 12,
      (byte) 5,
      (byte) 1,
      (byte) 15,
      (byte) 14,
      (byte) 13,
      (byte) 4,
      (byte) 10,
      (byte) 0,
      (byte) 7,
      (byte) 6,
      (byte) 3,
      (byte) 9,
      (byte) 2,
      (byte) 8,
      (byte) 11
    },
    {
      (byte) 13,
      (byte) 11,
      (byte) 7,
      (byte) 14,
      (byte) 12,
      (byte) 1,
      (byte) 3,
      (byte) 9,
      (byte) 5,
      (byte) 0,
      (byte) 15,
      (byte) 4,
      (byte) 8,
      (byte) 6,
      (byte) 2,
      (byte) 10
    },
    {
      (byte) 6,
      (byte) 15,
      (byte) 14,
      (byte) 9,
      (byte) 11,
      (byte) 3,
      (byte) 0,
      (byte) 8,
      (byte) 12,
      (byte) 2,
      (byte) 13,
      (byte) 7,
      (byte) 1,
      (byte) 4,
      (byte) 10,
      (byte) 5
    },
    {
      (byte) 10,
      (byte) 2,
      (byte) 8,
      (byte) 4,
      (byte) 7,
      (byte) 6,
      (byte) 1,
      (byte) 5,
      (byte) 15,
      (byte) 11,
      (byte) 9,
      (byte) 14,
      (byte) 3,
      (byte) 12,
      (byte) 13,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 1,
      (byte) 2,
      (byte) 3,
      (byte) 4,
      (byte) 5,
      (byte) 6,
      (byte) 7,
      (byte) 8,
      (byte) 9,
      (byte) 10,
      (byte) 11,
      (byte) 12,
      (byte) 13,
      (byte) 14,
      (byte) 15
    },
    {
      (byte) 14,
      (byte) 10,
      (byte) 4,
      (byte) 8,
      (byte) 9,
      (byte) 15,
      (byte) 13,
      (byte) 6,
      (byte) 1,
      (byte) 12,
      (byte) 0,
      (byte) 2,
      (byte) 11,
      (byte) 7,
      (byte) 5,
      (byte) 3
    }
  };
  private const int ROUNDS = 12;
  private const int BLOCK_LENGTH_BYTES = 128 /*0x80*/;
  private int digestLength = 64 /*0x40*/;
  private int keyLength;
  private byte[] salt;
  private byte[] personalization;
  private byte[] key;
  private byte[] buffer;
  private int bufferPos;
  private ulong[] internalState = new ulong[16 /*0x10*/];
  private ulong[] chainValue;
  private ulong t0;
  private ulong t1;
  private ulong f0;

  public Blake2bDigest()
    : this(512 /*0x0200*/)
  {
  }

  public Blake2bDigest(Blake2bDigest digest)
  {
    this.bufferPos = digest.bufferPos;
    this.buffer = Arrays.Clone(digest.buffer);
    this.keyLength = digest.keyLength;
    this.key = Arrays.Clone(digest.key);
    this.digestLength = digest.digestLength;
    this.chainValue = Arrays.Clone(digest.chainValue);
    this.personalization = Arrays.Clone(digest.personalization);
    this.salt = Arrays.Clone(digest.salt);
    this.t0 = digest.t0;
    this.t1 = digest.t1;
    this.f0 = digest.f0;
  }

  public Blake2bDigest(int digestSize)
  {
    if (digestSize < 8 || digestSize > 512 /*0x0200*/ || digestSize % 8 != 0)
      throw new ArgumentException("BLAKE2b digest bit length must be a multiple of 8 and not greater than 512");
    this.buffer = new byte[128 /*0x80*/];
    this.keyLength = 0;
    this.digestLength = digestSize / 8;
    this.Init();
  }

  public Blake2bDigest(byte[] key)
  {
    this.buffer = new byte[128 /*0x80*/];
    if (key != null)
    {
      this.key = new byte[key.Length];
      Array.Copy((Array) key, 0, (Array) this.key, 0, key.Length);
      this.keyLength = key.Length <= 64 /*0x40*/ ? key.Length : throw new ArgumentException("Keys > 64 are not supported");
      Array.Copy((Array) key, 0, (Array) this.buffer, 0, key.Length);
      this.bufferPos = 128 /*0x80*/;
    }
    this.digestLength = 64 /*0x40*/;
    this.Init();
  }

  public Blake2bDigest(byte[] key, int digestLength, byte[] salt, byte[] personalization)
  {
    this.digestLength = digestLength >= 1 && digestLength <= 64 /*0x40*/ ? digestLength : throw new ArgumentException("Invalid digest length (required: 1 - 64)");
    this.buffer = new byte[128 /*0x80*/];
    if (salt != null)
    {
      if (salt.Length != 16 /*0x10*/)
        throw new ArgumentException("salt length must be exactly 16 bytes");
      this.salt = new byte[16 /*0x10*/];
      Array.Copy((Array) salt, 0, (Array) this.salt, 0, salt.Length);
    }
    if (personalization != null)
    {
      if (personalization.Length != 16 /*0x10*/)
        throw new ArgumentException("personalization length must be exactly 16 bytes");
      this.personalization = new byte[16 /*0x10*/];
      Array.Copy((Array) personalization, 0, (Array) this.personalization, 0, personalization.Length);
    }
    if (key != null)
    {
      this.key = key.Length <= 64 /*0x40*/ ? new byte[key.Length] : throw new ArgumentException("Keys > 64 are not supported");
      Array.Copy((Array) key, 0, (Array) this.key, 0, key.Length);
      this.keyLength = key.Length;
      Array.Copy((Array) key, 0, (Array) this.buffer, 0, key.Length);
      this.bufferPos = 128 /*0x80*/;
    }
    this.Init();
  }

  private void Init()
  {
    if (this.chainValue != null)
      return;
    this.chainValue = new ulong[8];
    this.chainValue[0] = Blake2bDigest.blake2b_IV[0] ^ (ulong) (this.digestLength | this.keyLength << 8 | 16842752 /*0x01010000*/);
    this.chainValue[1] = Blake2bDigest.blake2b_IV[1];
    this.chainValue[2] = Blake2bDigest.blake2b_IV[2];
    this.chainValue[3] = Blake2bDigest.blake2b_IV[3];
    this.chainValue[4] = Blake2bDigest.blake2b_IV[4];
    this.chainValue[5] = Blake2bDigest.blake2b_IV[5];
    if (this.salt != null)
    {
      this.chainValue[4] ^= Pack.LE_To_UInt64(this.salt, 0);
      this.chainValue[5] ^= Pack.LE_To_UInt64(this.salt, 8);
    }
    this.chainValue[6] = Blake2bDigest.blake2b_IV[6];
    this.chainValue[7] = Blake2bDigest.blake2b_IV[7];
    if (this.personalization == null)
      return;
    this.chainValue[6] ^= Pack.LE_To_UInt64(this.personalization, 0);
    this.chainValue[7] ^= Pack.LE_To_UInt64(this.personalization, 8);
  }

  private void InitializeInternalState()
  {
    Array.Copy((Array) this.chainValue, 0, (Array) this.internalState, 0, this.chainValue.Length);
    Array.Copy((Array) Blake2bDigest.blake2b_IV, 0, (Array) this.internalState, this.chainValue.Length, 4);
    this.internalState[12] = this.t0 ^ Blake2bDigest.blake2b_IV[4];
    this.internalState[13] = this.t1 ^ Blake2bDigest.blake2b_IV[5];
    this.internalState[14] = this.f0 ^ Blake2bDigest.blake2b_IV[6];
    this.internalState[15] = Blake2bDigest.blake2b_IV[7];
  }

  public void Update(byte b)
  {
    if (128 /*0x80*/ - this.bufferPos == 0)
    {
      this.t0 += 128UL /*0x80*/;
      if (this.t0 == 0UL)
        ++this.t1;
      this.Compress(this.buffer, 0);
      Array.Clear((Array) this.buffer, 0, this.buffer.Length);
      this.buffer[0] = b;
      this.bufferPos = 1;
    }
    else
    {
      this.buffer[this.bufferPos] = b;
      ++this.bufferPos;
    }
  }

  public void BlockUpdate(byte[] message, int offset, int len)
  {
    if (message == null || len == 0)
      return;
    int length = 0;
    if (this.bufferPos != 0)
    {
      length = 128 /*0x80*/ - this.bufferPos;
      if (length < len)
      {
        Array.Copy((Array) message, offset, (Array) this.buffer, this.bufferPos, length);
        this.t0 += 128UL /*0x80*/;
        if (this.t0 == 0UL)
          ++this.t1;
        this.Compress(this.buffer, 0);
        this.bufferPos = 0;
        Array.Clear((Array) this.buffer, 0, this.buffer.Length);
      }
      else
      {
        Array.Copy((Array) message, offset, (Array) this.buffer, this.bufferPos, len);
        this.bufferPos += len;
        return;
      }
    }
    int num1 = offset + len - 128 /*0x80*/;
    int num2;
    for (num2 = offset + length; num2 < num1; num2 += 128 /*0x80*/)
    {
      this.t0 += 128UL /*0x80*/;
      if (this.t0 == 0UL)
        ++this.t1;
      this.Compress(message, num2);
    }
    Array.Copy((Array) message, num2, (Array) this.buffer, 0, offset + len - num2);
    this.bufferPos += offset + len - num2;
  }

  public int DoFinal(byte[] output, int outOffset)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOffset, this.digestLength, "output buffer too short");
    this.f0 = ulong.MaxValue;
    this.t0 += (ulong) this.bufferPos;
    if (this.bufferPos > 0 && this.t0 == 0UL)
      ++this.t1;
    this.Compress(this.buffer, 0);
    Array.Clear((Array) this.buffer, 0, this.buffer.Length);
    Array.Clear((Array) this.internalState, 0, this.internalState.Length);
    int nsLen = this.digestLength >> 3;
    int length = this.digestLength & 7;
    Pack.UInt64_To_LE(this.chainValue, 0, nsLen, output, outOffset);
    if (length > 0)
    {
      byte[] numArray = new byte[8];
      Pack.UInt64_To_LE(this.chainValue[nsLen], numArray, 0);
      Array.Copy((Array) numArray, 0, (Array) output, outOffset + this.digestLength - length, length);
    }
    Array.Clear((Array) this.chainValue, 0, this.chainValue.Length);
    this.Reset();
    return this.digestLength;
  }

  public void Reset()
  {
    this.bufferPos = 0;
    this.f0 = 0UL;
    this.t0 = 0UL;
    this.t1 = 0UL;
    this.chainValue = (ulong[]) null;
    Array.Clear((Array) this.buffer, 0, this.buffer.Length);
    if (this.key != null)
    {
      Array.Copy((Array) this.key, 0, (Array) this.buffer, 0, this.key.Length);
      this.bufferPos = 128 /*0x80*/;
    }
    this.Init();
  }

  private void Compress(byte[] message, int messagePos)
  {
    this.InitializeInternalState();
    ulong[] ns = new ulong[16 /*0x10*/];
    Pack.LE_To_UInt64(message, messagePos, ns);
    for (int index = 0; index < 12; ++index)
    {
      this.G(ns[(int) Blake2bDigest.blake2b_sigma[index, 0]], ns[(int) Blake2bDigest.blake2b_sigma[index, 1]], 0, 4, 8, 12);
      this.G(ns[(int) Blake2bDigest.blake2b_sigma[index, 2]], ns[(int) Blake2bDigest.blake2b_sigma[index, 3]], 1, 5, 9, 13);
      this.G(ns[(int) Blake2bDigest.blake2b_sigma[index, 4]], ns[(int) Blake2bDigest.blake2b_sigma[index, 5]], 2, 6, 10, 14);
      this.G(ns[(int) Blake2bDigest.blake2b_sigma[index, 6]], ns[(int) Blake2bDigest.blake2b_sigma[index, 7]], 3, 7, 11, 15);
      this.G(ns[(int) Blake2bDigest.blake2b_sigma[index, 8]], ns[(int) Blake2bDigest.blake2b_sigma[index, 9]], 0, 5, 10, 15);
      this.G(ns[(int) Blake2bDigest.blake2b_sigma[index, 10]], ns[(int) Blake2bDigest.blake2b_sigma[index, 11]], 1, 6, 11, 12);
      this.G(ns[(int) Blake2bDigest.blake2b_sigma[index, 12]], ns[(int) Blake2bDigest.blake2b_sigma[index, 13]], 2, 7, 8, 13);
      this.G(ns[(int) Blake2bDigest.blake2b_sigma[index, 14]], ns[(int) Blake2bDigest.blake2b_sigma[index, 15]], 3, 4, 9, 14);
    }
    for (int index = 0; index < this.chainValue.Length; ++index)
      this.chainValue[index] = this.chainValue[index] ^ this.internalState[index] ^ this.internalState[index + 8];
  }

  private void G(ulong m1, ulong m2, int posA, int posB, int posC, int posD)
  {
    this.internalState[posA] = this.internalState[posA] + this.internalState[posB] + m1;
    this.internalState[posD] = Blake2bDigest.Rotr64(this.internalState[posD] ^ this.internalState[posA], 32 /*0x20*/);
    this.internalState[posC] = this.internalState[posC] + this.internalState[posD];
    this.internalState[posB] = Blake2bDigest.Rotr64(this.internalState[posB] ^ this.internalState[posC], 24);
    this.internalState[posA] = this.internalState[posA] + this.internalState[posB] + m2;
    this.internalState[posD] = Blake2bDigest.Rotr64(this.internalState[posD] ^ this.internalState[posA], 16 /*0x10*/);
    this.internalState[posC] = this.internalState[posC] + this.internalState[posD];
    this.internalState[posB] = Blake2bDigest.Rotr64(this.internalState[posB] ^ this.internalState[posC], 63 /*0x3F*/);
  }

  private static ulong Rotr64(ulong x, int rot) => x >> rot | x << -rot;

  public string AlgorithmName => "BLAKE2b";

  public int GetDigestSize() => this.digestLength;

  public int GetByteLength() => 128 /*0x80*/;

  public void ClearKey()
  {
    if (this.key == null)
      return;
    Array.Clear((Array) this.key, 0, this.key.Length);
    Array.Clear((Array) this.buffer, 0, this.buffer.Length);
  }

  public void ClearSalt()
  {
    if (this.salt == null)
      return;
    Array.Clear((Array) this.salt, 0, this.salt.Length);
  }
}
