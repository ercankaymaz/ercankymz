// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.Blake2sDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public sealed class Blake2sDigest : IDigest
{
  private static readonly uint[] blake2s_IV = new uint[8]
  {
    1779033703U,
    3144134277U,
    1013904242U,
    2773480762U,
    1359893119U,
    2600822924U,
    528734635U,
    1541459225U
  };
  private static readonly byte[,] blake2s_sigma = new byte[10, 16 /*0x10*/]
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
    }
  };
  private const int ROUNDS = 10;
  private const int BLOCK_LENGTH_BYTES = 64 /*0x40*/;
  private int digestLength = 32 /*0x20*/;
  private int keyLength;
  private byte[] salt;
  private byte[] personalization;
  private byte[] key;
  private int fanout = 1;
  private int depth = 1;
  private int leafLength;
  private long nodeOffset;
  private int nodeDepth;
  private int innerHashLength;
  private byte[] buffer;
  private int bufferPos;
  private uint[] internalState = new uint[16 /*0x10*/];
  private uint[] chainValue;
  private uint t0;
  private uint t1;
  private uint f0;

  public Blake2sDigest()
    : this(256 /*0x0100*/)
  {
  }

  public Blake2sDigest(Blake2sDigest digest)
  {
    this.bufferPos = digest.bufferPos;
    this.buffer = Arrays.Clone(digest.buffer);
    this.keyLength = digest.keyLength;
    this.key = Arrays.Clone(digest.key);
    this.digestLength = digest.digestLength;
    this.internalState = Arrays.Clone(digest.internalState);
    this.chainValue = Arrays.Clone(digest.chainValue);
    this.t0 = digest.t0;
    this.t1 = digest.t1;
    this.f0 = digest.f0;
    this.salt = Arrays.Clone(digest.salt);
    this.personalization = Arrays.Clone(digest.personalization);
    this.fanout = digest.fanout;
    this.depth = digest.depth;
    this.leafLength = digest.leafLength;
    this.nodeOffset = digest.nodeOffset;
    this.nodeDepth = digest.nodeDepth;
    this.innerHashLength = digest.innerHashLength;
  }

  public Blake2sDigest(int digestBits)
  {
    if (digestBits < 8 || digestBits > 256 /*0x0100*/ || digestBits % 8 != 0)
      throw new ArgumentException("BLAKE2s digest bit length must be a multiple of 8 and not greater than 256");
    this.digestLength = digestBits / 8;
    this.Init((byte[]) null, (byte[]) null, (byte[]) null);
  }

  public Blake2sDigest(byte[] key) => this.Init((byte[]) null, (byte[]) null, key);

  public Blake2sDigest(byte[] key, int digestBytes, byte[] salt, byte[] personalization)
  {
    this.digestLength = digestBytes >= 1 && digestBytes <= 32 /*0x20*/ ? digestBytes : throw new ArgumentException("Invalid digest length (required: 1 - 32)");
    this.Init(salt, personalization, key);
  }

  internal Blake2sDigest(
    int digestBytes,
    byte[] key,
    byte[] salt,
    byte[] personalization,
    long offset)
  {
    this.digestLength = digestBytes;
    this.nodeOffset = offset;
    this.Init(salt, personalization, key);
  }

  internal Blake2sDigest(int digestBytes, int hashLength, long offset)
  {
    this.digestLength = digestBytes;
    this.nodeOffset = offset;
    this.fanout = 0;
    this.depth = 0;
    this.leafLength = hashLength;
    this.innerHashLength = hashLength;
    this.nodeDepth = 0;
    this.Init((byte[]) null, (byte[]) null, (byte[]) null);
  }

  private void Init(byte[] salt, byte[] personalization, byte[] key)
  {
    this.buffer = new byte[64 /*0x40*/];
    if (key != null && key.Length != 0)
    {
      this.keyLength = key.Length;
      this.key = this.keyLength <= 32 /*0x20*/ ? new byte[this.keyLength] : throw new ArgumentException("Keys > 32 bytes are not supported");
      Array.Copy((Array) key, 0, (Array) this.key, 0, this.keyLength);
      Array.Copy((Array) key, 0, (Array) this.buffer, 0, this.keyLength);
      this.bufferPos = 64 /*0x40*/;
    }
    if (this.chainValue != null)
      return;
    this.chainValue = new uint[8];
    this.chainValue[0] = Blake2sDigest.blake2s_IV[0] ^ (uint) (this.digestLength | this.keyLength << 8 | this.fanout << 16 /*0x10*/ | this.depth << 24);
    this.chainValue[1] = Blake2sDigest.blake2s_IV[1] ^ (uint) this.leafLength;
    int num = (int) (this.nodeOffset >> 32 /*0x20*/);
    int nodeOffset = (int) this.nodeOffset;
    this.chainValue[2] = Blake2sDigest.blake2s_IV[2] ^ (uint) nodeOffset;
    this.chainValue[3] = Blake2sDigest.blake2s_IV[3] ^ (uint) (num | this.nodeDepth << 16 /*0x10*/ | this.innerHashLength << 24);
    this.chainValue[4] = Blake2sDigest.blake2s_IV[4];
    this.chainValue[5] = Blake2sDigest.blake2s_IV[5];
    if (salt != null)
    {
      if (salt.Length != 8)
        throw new ArgumentException("Salt length must be exactly 8 bytes");
      this.salt = new byte[8];
      Array.Copy((Array) salt, 0, (Array) this.salt, 0, salt.Length);
      this.chainValue[4] ^= Pack.LE_To_UInt32(salt, 0);
      this.chainValue[5] ^= Pack.LE_To_UInt32(salt, 4);
    }
    this.chainValue[6] = Blake2sDigest.blake2s_IV[6];
    this.chainValue[7] = Blake2sDigest.blake2s_IV[7];
    if (personalization == null)
      return;
    if (personalization.Length != 8)
      throw new ArgumentException("Personalization length must be exactly 8 bytes");
    this.personalization = new byte[8];
    Array.Copy((Array) personalization, 0, (Array) this.personalization, 0, personalization.Length);
    this.chainValue[6] ^= Pack.LE_To_UInt32(personalization, 0);
    this.chainValue[7] ^= Pack.LE_To_UInt32(personalization, 4);
  }

  private void InitializeInternalState()
  {
    Array.Copy((Array) this.chainValue, 0, (Array) this.internalState, 0, this.chainValue.Length);
    Array.Copy((Array) Blake2sDigest.blake2s_IV, 0, (Array) this.internalState, this.chainValue.Length, 4);
    this.internalState[12] = this.t0 ^ Blake2sDigest.blake2s_IV[4];
    this.internalState[13] = this.t1 ^ Blake2sDigest.blake2s_IV[5];
    this.internalState[14] = this.f0 ^ Blake2sDigest.blake2s_IV[6];
    this.internalState[15] = Blake2sDigest.blake2s_IV[7];
  }

  public void Update(byte b)
  {
    if (64 /*0x40*/ - this.bufferPos == 0)
    {
      this.t0 += 64U /*0x40*/;
      if (this.t0 == 0U)
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
      length = 64 /*0x40*/ - this.bufferPos;
      if (length < len)
      {
        Array.Copy((Array) message, offset, (Array) this.buffer, this.bufferPos, length);
        this.t0 += 64U /*0x40*/;
        if (this.t0 == 0U)
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
    int num1 = offset + len - 64 /*0x40*/;
    int num2;
    for (num2 = offset + length; num2 < num1; num2 += 64 /*0x40*/)
    {
      this.t0 += 64U /*0x40*/;
      if (this.t0 == 0U)
        ++this.t1;
      this.Compress(message, num2);
    }
    Array.Copy((Array) message, num2, (Array) this.buffer, 0, offset + len - num2);
    this.bufferPos += offset + len - num2;
  }

  public int DoFinal(byte[] output, int outOffset)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOffset, this.digestLength, "output buffer too short");
    this.f0 = uint.MaxValue;
    this.t0 += (uint) this.bufferPos;
    this.Compress(this.buffer, 0);
    Array.Clear((Array) this.buffer, 0, this.buffer.Length);
    Array.Clear((Array) this.internalState, 0, this.internalState.Length);
    int nsLen = this.digestLength >> 2;
    int length = this.digestLength & 3;
    Pack.UInt32_To_LE(this.chainValue, 0, nsLen, output, outOffset);
    if (length > 0)
    {
      byte[] numArray = new byte[4];
      Pack.UInt32_To_LE(this.chainValue[nsLen], numArray, 0);
      Array.Copy((Array) numArray, 0, (Array) output, outOffset + this.digestLength - length, length);
    }
    Array.Clear((Array) this.chainValue, 0, this.chainValue.Length);
    this.Reset();
    return this.digestLength;
  }

  public void Reset()
  {
    this.bufferPos = 0;
    this.f0 = 0U;
    this.t0 = 0U;
    this.t1 = 0U;
    this.chainValue = (uint[]) null;
    Array.Clear((Array) this.buffer, 0, this.buffer.Length);
    if (this.key != null)
    {
      Array.Copy((Array) this.key, 0, (Array) this.buffer, 0, this.key.Length);
      this.bufferPos = 64 /*0x40*/;
    }
    this.Init(this.salt, this.personalization, this.key);
  }

  private void Compress(byte[] message, int messagePos)
  {
    this.InitializeInternalState();
    uint[] ns = new uint[16 /*0x10*/];
    Pack.LE_To_UInt32(message, messagePos, ns);
    for (int index = 0; index < 10; ++index)
    {
      this.G(ns[(int) Blake2sDigest.blake2s_sigma[index, 0]], ns[(int) Blake2sDigest.blake2s_sigma[index, 1]], 0, 4, 8, 12);
      this.G(ns[(int) Blake2sDigest.blake2s_sigma[index, 2]], ns[(int) Blake2sDigest.blake2s_sigma[index, 3]], 1, 5, 9, 13);
      this.G(ns[(int) Blake2sDigest.blake2s_sigma[index, 4]], ns[(int) Blake2sDigest.blake2s_sigma[index, 5]], 2, 6, 10, 14);
      this.G(ns[(int) Blake2sDigest.blake2s_sigma[index, 6]], ns[(int) Blake2sDigest.blake2s_sigma[index, 7]], 3, 7, 11, 15);
      this.G(ns[(int) Blake2sDigest.blake2s_sigma[index, 8]], ns[(int) Blake2sDigest.blake2s_sigma[index, 9]], 0, 5, 10, 15);
      this.G(ns[(int) Blake2sDigest.blake2s_sigma[index, 10]], ns[(int) Blake2sDigest.blake2s_sigma[index, 11]], 1, 6, 11, 12);
      this.G(ns[(int) Blake2sDigest.blake2s_sigma[index, 12]], ns[(int) Blake2sDigest.blake2s_sigma[index, 13]], 2, 7, 8, 13);
      this.G(ns[(int) Blake2sDigest.blake2s_sigma[index, 14]], ns[(int) Blake2sDigest.blake2s_sigma[index, 15]], 3, 4, 9, 14);
    }
    for (int index = 0; index < this.chainValue.Length; ++index)
      this.chainValue[index] = this.chainValue[index] ^ this.internalState[index] ^ this.internalState[index + 8];
  }

  private void G(uint m1, uint m2, int posA, int posB, int posC, int posD)
  {
    this.internalState[posA] = this.internalState[posA] + this.internalState[posB] + m1;
    this.internalState[posD] = Integers.RotateRight(this.internalState[posD] ^ this.internalState[posA], 16 /*0x10*/);
    this.internalState[posC] = this.internalState[posC] + this.internalState[posD];
    this.internalState[posB] = Integers.RotateRight(this.internalState[posB] ^ this.internalState[posC], 12);
    this.internalState[posA] = this.internalState[posA] + this.internalState[posB] + m2;
    this.internalState[posD] = Integers.RotateRight(this.internalState[posD] ^ this.internalState[posA], 8);
    this.internalState[posC] = this.internalState[posC] + this.internalState[posD];
    this.internalState[posB] = Integers.RotateRight(this.internalState[posB] ^ this.internalState[posC], 7);
  }

  public string AlgorithmName => "BLAKE2s";

  public int GetDigestSize() => this.digestLength;

  public int GetByteLength() => 64 /*0x40*/;

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
