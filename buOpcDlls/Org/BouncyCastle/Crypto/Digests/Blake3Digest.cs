// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.Blake3Digest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public sealed class Blake3Digest : IDigest, IMemoable, IXof
{
  private const string ERR_OUTPUTTING = "Already outputting";
  private const int NUMWORDS = 8;
  private const int ROUNDS = 7;
  private const int BLOCKLEN = 64 /*0x40*/;
  private const int CHUNKLEN = 1024 /*0x0400*/;
  private const int CHUNKSTART = 1;
  private const int CHUNKEND = 2;
  private const int PARENT = 4;
  private const int ROOT = 8;
  private const int KEYEDHASH = 16 /*0x10*/;
  private const int DERIVECONTEXT = 32 /*0x20*/;
  private const int DERIVEKEY = 64 /*0x40*/;
  private const int CHAINING0 = 0;
  private const int CHAINING1 = 1;
  private const int CHAINING2 = 2;
  private const int CHAINING3 = 3;
  private const int CHAINING4 = 4;
  private const int CHAINING5 = 5;
  private const int CHAINING6 = 6;
  private const int CHAINING7 = 7;
  private const int IV0 = 8;
  private const int IV1 = 9;
  private const int IV2 = 10;
  private const int IV3 = 11;
  private const int COUNT0 = 12;
  private const int COUNT1 = 13;
  private const int DATALEN = 14;
  private const int FLAGS = 15;
  private static readonly byte[] SIGMA = new byte[16 /*0x10*/]
  {
    (byte) 2,
    (byte) 6,
    (byte) 3,
    (byte) 10,
    (byte) 7,
    (byte) 0,
    (byte) 4,
    (byte) 13,
    (byte) 1,
    (byte) 11,
    (byte) 12,
    (byte) 5,
    (byte) 9,
    (byte) 14,
    (byte) 15,
    (byte) 8
  };
  private static readonly uint[] IV = new uint[8]
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
  private readonly byte[] m_theBuffer = new byte[64 /*0x40*/];
  private readonly uint[] m_theK = new uint[8];
  private readonly uint[] m_theChaining = new uint[8];
  private readonly uint[] m_theV = new uint[16 /*0x10*/];
  private readonly uint[] m_theM = new uint[16 /*0x10*/];
  private readonly byte[] m_theIndices = new byte[16 /*0x10*/];
  private readonly List<uint[]> m_theStack = new List<uint[]>();
  private readonly int m_theDigestLen;
  private bool m_outputting;
  private long m_outputAvailable;
  private int m_theMode;
  private int m_theOutputMode;
  private int m_theOutputDataLen;
  private long m_theCounter;
  private int m_theCurrBytes;
  private int m_thePos;

  public Blake3Digest()
    : this(256 /*0x0100*/)
  {
  }

  public Blake3Digest(int pDigestSize)
  {
    this.m_theDigestLen = pDigestSize / 8;
    this.Init((Blake3Parameters) null);
  }

  public Blake3Digest(Blake3Digest pSource)
  {
    this.m_theDigestLen = pSource.m_theDigestLen;
    this.Reset((IMemoable) pSource);
  }

  public int GetByteLength() => 64 /*0x40*/;

  public string AlgorithmName => "BLAKE3";

  public int GetDigestSize() => this.m_theDigestLen;

  public void Init(Blake3Parameters pParams)
  {
    byte[] key = pParams?.GetKey();
    byte[] context = pParams?.GetContext();
    this.Reset();
    if (key != null)
    {
      this.InitKey(key);
      Arrays.Fill(key, (byte) 0);
    }
    else if (context != null)
    {
      this.InitNullKey();
      this.m_theMode = 32 /*0x20*/;
      this.BlockUpdate(context, 0, context.Length);
      this.DoFinal(this.m_theBuffer, 0);
      this.InitKeyFromContext();
      this.Reset();
    }
    else
    {
      this.InitNullKey();
      this.m_theMode = 0;
    }
  }

  public void Update(byte b)
  {
    if (this.m_outputting)
      throw new InvalidOperationException("Already outputting");
    if (this.m_theBuffer.Length - this.m_thePos == 0)
    {
      this.CompressBlock(this.m_theBuffer, 0);
      Arrays.Fill(this.m_theBuffer, (byte) 0);
      this.m_thePos = 0;
    }
    this.m_theBuffer[this.m_thePos] = b;
    ++this.m_thePos;
  }

  public void BlockUpdate(byte[] pMessage, int pOffset, int pLen)
  {
    if (pMessage == null || pLen == 0)
      return;
    if (this.m_outputting)
      throw new InvalidOperationException("Already outputting");
    int length = 0;
    if (this.m_thePos != 0)
    {
      length = 64 /*0x40*/ - this.m_thePos;
      if (length >= pLen)
      {
        Array.Copy((Array) pMessage, pOffset, (Array) this.m_theBuffer, this.m_thePos, pLen);
        this.m_thePos += pLen;
        return;
      }
      Array.Copy((Array) pMessage, pOffset, (Array) this.m_theBuffer, this.m_thePos, length);
      this.CompressBlock(this.m_theBuffer, 0);
      this.m_thePos = 0;
      Arrays.Fill(this.m_theBuffer, (byte) 0);
    }
    int num1 = pOffset + pLen - 64 /*0x40*/;
    int num2;
    for (num2 = pOffset + length; num2 < num1; num2 += 64 /*0x40*/)
      this.CompressBlock(pMessage, num2);
    int num3 = pLen - num2;
    Array.Copy((Array) pMessage, num2, (Array) this.m_theBuffer, 0, pOffset + num3);
    this.m_thePos += pOffset + num3;
  }

  public int DoFinal(byte[] pOutput, int pOutOffset)
  {
    return this.OutputFinal(pOutput, pOutOffset, this.GetDigestSize());
  }

  public int OutputFinal(byte[] pOut, int pOutOffset, int pOutLen)
  {
    int num = this.Output(pOut, pOutOffset, pOutLen);
    this.Reset();
    return num;
  }

  public int Output(byte[] pOut, int pOutOffset, int pOutLen)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(pOut, pOutOffset, pOutLen, "output buffer too short");
    if (!this.m_outputting)
      this.CompressFinalBlock(this.m_thePos);
    int val1 = pOutLen >= 0 && (this.m_outputAvailable < 0L || (long) pOutLen <= this.m_outputAvailable) ? pOutLen : throw new ArgumentException("Insufficient bytes remaining");
    int destinationIndex = pOutOffset;
    if (this.m_thePos < 64 /*0x40*/)
    {
      int length = Math.Min(val1, 64 /*0x40*/ - this.m_thePos);
      Array.Copy((Array) this.m_theBuffer, this.m_thePos, (Array) pOut, destinationIndex, length);
      this.m_thePos += length;
      destinationIndex += length;
      val1 -= length;
    }
    int length1;
    for (; val1 > 0; val1 -= length1)
    {
      this.NextOutputBlock();
      length1 = Math.Min(val1, 64 /*0x40*/);
      Array.Copy((Array) this.m_theBuffer, 0, (Array) pOut, destinationIndex, length1);
      this.m_thePos += length1;
      destinationIndex += length1;
    }
    this.m_outputAvailable -= (long) pOutLen;
    return pOutLen;
  }

  public void Reset()
  {
    this.ResetBlockCount();
    this.m_thePos = 0;
    this.m_outputting = false;
    Arrays.Fill(this.m_theBuffer, (byte) 0);
  }

  public void Reset(IMemoable pSource)
  {
    Blake3Digest blake3Digest = (Blake3Digest) pSource;
    this.m_theCounter = blake3Digest.m_theCounter;
    this.m_theCurrBytes = blake3Digest.m_theCurrBytes;
    this.m_theMode = blake3Digest.m_theMode;
    this.m_outputting = blake3Digest.m_outputting;
    this.m_outputAvailable = blake3Digest.m_outputAvailable;
    this.m_theOutputMode = blake3Digest.m_theOutputMode;
    this.m_theOutputDataLen = blake3Digest.m_theOutputDataLen;
    Array.Copy((Array) blake3Digest.m_theChaining, 0, (Array) this.m_theChaining, 0, this.m_theChaining.Length);
    Array.Copy((Array) blake3Digest.m_theK, 0, (Array) this.m_theK, 0, this.m_theK.Length);
    Array.Copy((Array) blake3Digest.m_theM, 0, (Array) this.m_theM, 0, this.m_theM.Length);
    this.m_theStack.Clear();
    foreach (uint[] the in blake3Digest.m_theStack)
      this.m_theStack.Add(Arrays.Clone(the));
    Array.Copy((Array) blake3Digest.m_theBuffer, 0, (Array) this.m_theBuffer, 0, this.m_theBuffer.Length);
    this.m_thePos = blake3Digest.m_thePos;
  }

  public IMemoable Copy() => (IMemoable) new Blake3Digest(this);

  private void CompressBlock(byte[] pMessage, int pMsgPos)
  {
    this.InitChunkBlock(64 /*0x40*/, false);
    this.InitM(pMessage, pMsgPos);
    this.Compress();
    if (this.m_theCurrBytes != 0)
      return;
    this.AdjustStack();
  }

  private void InitM(byte[] pMessage, int pMsgPos)
  {
    Pack.LE_To_UInt32(pMessage, pMsgPos, this.m_theM);
  }

  private void AdjustStack()
  {
    for (long theCounter = this.m_theCounter; theCounter > 0L && (theCounter & 1L) != 1L; theCounter >>= 1)
    {
      uint[] the = this.m_theStack[this.m_theStack.Count - 1];
      this.m_theStack.RemoveAt(this.m_theStack.Count - 1);
      uint[] theM = this.m_theM;
      Array.Copy((Array) the, 0, (Array) theM, 0, 8);
      Array.Copy((Array) this.m_theChaining, 0, (Array) this.m_theM, 8, 8);
      this.InitParentBlock();
      this.Compress();
    }
    this.m_theStack.Add(Arrays.CopyOf(this.m_theChaining, 8));
  }

  private void CompressFinalBlock(int pDataLen)
  {
    this.InitChunkBlock(pDataLen, true);
    this.InitM(this.m_theBuffer, 0);
    this.Compress();
    this.ProcessStack();
  }

  private void ProcessStack()
  {
    while (this.m_theStack.Count > 0)
    {
      uint[] the = this.m_theStack[this.m_theStack.Count - 1];
      this.m_theStack.RemoveAt(this.m_theStack.Count - 1);
      uint[] theM = this.m_theM;
      Array.Copy((Array) the, 0, (Array) theM, 0, 8);
      Array.Copy((Array) this.m_theChaining, 0, (Array) this.m_theM, 8, 8);
      this.InitParentBlock();
      if (this.m_theStack.Count < 1)
        this.SetRoot();
      this.Compress();
    }
  }

  private void Compress()
  {
    this.InitIndices();
    for (int index = 0; index < 6; ++index)
    {
      this.PerformRound();
      this.PermuteIndices();
    }
    this.PerformRound();
    this.AdjustChaining();
  }

  private void PerformRound()
  {
    this.MixG(0, 0, 4, 8, 12);
    this.MixG(1, 1, 5, 9, 13);
    this.MixG(2, 2, 6, 10, 14);
    this.MixG(3, 3, 7, 11, 15);
    this.MixG(4, 0, 5, 10, 15);
    this.MixG(5, 1, 6, 11, 12);
    this.MixG(6, 2, 7, 8, 13);
    this.MixG(7, 3, 4, 9, 14);
  }

  private void AdjustChaining()
  {
    if (this.m_outputting)
    {
      for (int index = 0; index < 8; ++index)
      {
        this.m_theV[index] ^= this.m_theV[index + 8];
        this.m_theV[index + 8] ^= this.m_theChaining[index];
      }
      Pack.UInt32_To_LE(this.m_theV, this.m_theBuffer, 0);
      this.m_thePos = 0;
    }
    else
    {
      for (int index = 0; index < 8; ++index)
        this.m_theChaining[index] = this.m_theV[index] ^ this.m_theV[index + 8];
    }
  }

  private void MixG(int msgIdx, int posA, int posB, int posC, int posD)
  {
    int num1 = msgIdx << 1;
    ref uint local = ref this.m_theV[posA];
    int num2 = (int) local;
    int num3 = (int) this.m_theV[posB];
    uint[] theM = this.m_theM;
    byte[] theIndices = this.m_theIndices;
    int index1 = num1;
    int index2 = index1 + 1;
    int index3 = (int) theIndices[index1];
    int num4 = (int) theM[index3];
    int num5 = num3 + num4;
    local = (uint) (num2 + num5);
    this.m_theV[posD] = Integers.RotateRight(this.m_theV[posD] ^ this.m_theV[posA], 16 /*0x10*/);
    this.m_theV[posC] += this.m_theV[posD];
    this.m_theV[posB] = Integers.RotateRight(this.m_theV[posB] ^ this.m_theV[posC], 12);
    this.m_theV[posA] += this.m_theV[posB] + this.m_theM[(int) this.m_theIndices[index2]];
    this.m_theV[posD] = Integers.RotateRight(this.m_theV[posD] ^ this.m_theV[posA], 8);
    this.m_theV[posC] += this.m_theV[posD];
    this.m_theV[posB] = Integers.RotateRight(this.m_theV[posB] ^ this.m_theV[posC], 7);
  }

  private void InitIndices()
  {
    for (byte index = 0; (int) index < this.m_theIndices.Length; ++index)
      this.m_theIndices[(int) index] = index;
  }

  private void PermuteIndices()
  {
    for (byte index = 0; (int) index < this.m_theIndices.Length; ++index)
      this.m_theIndices[(int) index] = Blake3Digest.SIGMA[(int) this.m_theIndices[(int) index]];
  }

  private void InitNullKey() => Array.Copy((Array) Blake3Digest.IV, 0, (Array) this.m_theK, 0, 8);

  private void InitKey(byte[] pKey)
  {
    Pack.LE_To_UInt32(pKey, 0, this.m_theK);
    this.m_theMode = 16 /*0x10*/;
  }

  private void InitKeyFromContext()
  {
    Array.Copy((Array) this.m_theV, 0, (Array) this.m_theK, 0, 8);
    this.m_theMode = 64 /*0x40*/;
  }

  private void InitChunkBlock(int pDataLen, bool pFinal)
  {
    Array.Copy(this.m_theCurrBytes == 0 ? (Array) this.m_theK : (Array) this.m_theChaining, 0, (Array) this.m_theV, 0, 8);
    Array.Copy((Array) Blake3Digest.IV, 0, (Array) this.m_theV, 8, 4);
    this.m_theV[12] = (uint) this.m_theCounter;
    this.m_theV[13] = (uint) (this.m_theCounter >> 32 /*0x20*/);
    this.m_theV[14] = (uint) pDataLen;
    this.m_theV[15] = (uint) (this.m_theMode + (this.m_theCurrBytes == 0 ? 1 : 0) + (pFinal ? 2 : 0));
    this.m_theCurrBytes += pDataLen;
    if (this.m_theCurrBytes >= 1024 /*0x0400*/)
    {
      this.IncrementBlockCount();
      this.m_theV[15] |= 2U;
    }
    if (!pFinal || this.m_theStack.Count >= 1)
      return;
    this.SetRoot();
  }

  private void InitParentBlock()
  {
    Array.Copy((Array) this.m_theK, 0, (Array) this.m_theV, 0, 8);
    Array.Copy((Array) Blake3Digest.IV, 0, (Array) this.m_theV, 8, 4);
    this.m_theV[12] = 0U;
    this.m_theV[13] = 0U;
    this.m_theV[14] = 64U /*0x40*/;
    this.m_theV[15] = (uint) (this.m_theMode | 4);
  }

  private void NextOutputBlock()
  {
    ++this.m_theCounter;
    Array.Copy((Array) this.m_theChaining, 0, (Array) this.m_theV, 0, 8);
    Array.Copy((Array) Blake3Digest.IV, 0, (Array) this.m_theV, 8, 4);
    this.m_theV[12] = (uint) this.m_theCounter;
    this.m_theV[13] = (uint) (this.m_theCounter >> 32 /*0x20*/);
    this.m_theV[14] = (uint) this.m_theOutputDataLen;
    this.m_theV[15] = (uint) this.m_theOutputMode;
    this.Compress();
  }

  private void IncrementBlockCount()
  {
    ++this.m_theCounter;
    this.m_theCurrBytes = 0;
  }

  private void ResetBlockCount()
  {
    this.m_theCounter = 0L;
    this.m_theCurrBytes = 0;
  }

  private void SetRoot()
  {
    this.m_theV[15] |= 8U;
    this.m_theOutputMode = (int) this.m_theV[15];
    this.m_theOutputDataLen = (int) this.m_theV[14];
    this.m_theCounter = 0L;
    this.m_outputting = true;
    this.m_outputAvailable = -1L;
    Array.Copy((Array) this.m_theV, 0, (Array) this.m_theChaining, 0, 8);
  }
}
