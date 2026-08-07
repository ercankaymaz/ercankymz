// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.GcmSivBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Modes.Gcm;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes;

public class GcmSivBlockCipher : IAeadBlockCipher, IAeadCipher
{
  private static readonly int BUFLEN = 16 /*0x10*/;
  private static readonly int HALFBUFLEN = GcmSivBlockCipher.BUFLEN >> 1;
  private static readonly int NONCELEN = 12;
  private static readonly int MAX_DATALEN = 2147483639 - GcmSivBlockCipher.BUFLEN;
  private static readonly byte MASK = 128 /*0x80*/;
  private static readonly byte ADD = 225;
  private static readonly int INIT = 1;
  private static readonly int AEAD_COMPLETE = 2;
  private readonly IBlockCipher theCipher;
  private readonly IGcmMultiplier theMultiplier;
  internal readonly byte[] theGHash = new byte[GcmSivBlockCipher.BUFLEN];
  internal readonly byte[] theReverse = new byte[GcmSivBlockCipher.BUFLEN];
  private readonly GcmSivBlockCipher.GcmSivHasher theAEADHasher;
  private readonly GcmSivBlockCipher.GcmSivHasher theDataHasher;
  private GcmSivBlockCipher.GcmSivCache thePlain;
  private GcmSivBlockCipher.GcmSivCache theEncData;
  private bool forEncryption;
  private byte[] theInitialAEAD;
  private byte[] theNonce;
  private int theFlags;

  public GcmSivBlockCipher()
    : this(AesUtilities.CreateEngine())
  {
  }

  public GcmSivBlockCipher(IBlockCipher pCipher)
    : this(pCipher, (IGcmMultiplier) null)
  {
  }

  [Obsolete("Will be removed")]
  public GcmSivBlockCipher(IBlockCipher pCipher, IGcmMultiplier pMultiplier)
  {
    if (pCipher.GetBlockSize() != GcmSivBlockCipher.BUFLEN)
      throw new ArgumentException($"Cipher required with a block size of {GcmSivBlockCipher.BUFLEN.ToString()}.");
    if (pMultiplier == null)
      pMultiplier = GcmBlockCipher.CreateGcmMultiplier();
    this.theCipher = pCipher;
    this.theMultiplier = pMultiplier;
    this.theAEADHasher = new GcmSivBlockCipher.GcmSivHasher(this);
    this.theDataHasher = new GcmSivBlockCipher.GcmSivHasher(this);
  }

  public virtual IBlockCipher UnderlyingCipher => this.theCipher;

  public virtual int GetBlockSize() => this.theCipher.GetBlockSize();

  public virtual void Init(bool pEncrypt, ICipherParameters cipherParameters)
  {
    byte[] numArray1 = (byte[]) null;
    byte[] numArray2;
    KeyParameter pKey;
    switch (cipherParameters)
    {
      case AeadParameters aeadParameters:
        numArray1 = aeadParameters.GetAssociatedText();
        numArray2 = aeadParameters.GetNonce();
        pKey = aeadParameters.Key;
        break;
      case ParametersWithIV parametersWithIv:
        numArray2 = parametersWithIv.GetIV();
        pKey = (KeyParameter) parametersWithIv.Parameters;
        break;
      default:
        throw new ArgumentException("invalid parameters passed to GCM_SIV");
    }
    if (numArray2.Length != GcmSivBlockCipher.NONCELEN)
      throw new ArgumentException("Invalid nonce");
    int num = pKey != null ? pKey.KeyLength : throw new ArgumentException("Invalid key");
    if (num != GcmSivBlockCipher.BUFLEN && num != GcmSivBlockCipher.BUFLEN << 1)
      throw new ArgumentException("Invalid key");
    this.forEncryption = pEncrypt;
    this.theInitialAEAD = numArray1;
    this.theNonce = numArray2;
    this.DeriveKeys(pKey);
    this.ResetStreams();
  }

  public virtual string AlgorithmName => this.theCipher.AlgorithmName + "-GCM-SIV";

  private void CheckAeadStatus(int pLen)
  {
    if ((this.theFlags & GcmSivBlockCipher.INIT) == 0)
      throw new InvalidOperationException("Cipher is not initialised");
    if ((this.theFlags & GcmSivBlockCipher.AEAD_COMPLETE) != 0)
      throw new InvalidOperationException("AEAD data cannot be processed after ordinary data");
    if ((long) this.theAEADHasher.getBytesProcessed() + long.MinValue > (long) (GcmSivBlockCipher.MAX_DATALEN - pLen) + long.MinValue)
      throw new InvalidOperationException("AEAD byte count exceeded");
  }

  private void CheckStatus(int pLen)
  {
    if ((this.theFlags & GcmSivBlockCipher.INIT) == 0)
      throw new InvalidOperationException("Cipher is not initialised");
    if ((this.theFlags & GcmSivBlockCipher.AEAD_COMPLETE) == 0)
    {
      this.theAEADHasher.completeHash();
      this.theFlags |= GcmSivBlockCipher.AEAD_COMPLETE;
    }
    long maxDatalen = (long) GcmSivBlockCipher.MAX_DATALEN;
    long length = this.thePlain.Length;
    if (!this.forEncryption)
    {
      maxDatalen += (long) GcmSivBlockCipher.BUFLEN;
      length = this.theEncData.Length;
    }
    if (length + long.MinValue > maxDatalen - (long) pLen + long.MinValue)
      throw new InvalidOperationException("byte count exceeded");
  }

  public virtual void ProcessAadByte(byte pByte)
  {
    this.CheckAeadStatus(1);
    this.theAEADHasher.UpdateHash(pByte);
  }

  public virtual void ProcessAadBytes(byte[] pData, int pOffset, int pLen)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(pData, pOffset, pLen, "input buffer too short");
    this.CheckAeadStatus(pLen);
    this.theAEADHasher.UpdateHash(pData, pOffset, pLen);
  }

  public virtual int ProcessByte(byte pByte, byte[] pOutput, int pOutOffset)
  {
    this.CheckStatus(1);
    if (this.forEncryption)
    {
      this.thePlain.WriteByte(pByte);
      this.theDataHasher.UpdateHash(pByte);
    }
    else
      this.theEncData.WriteByte(pByte);
    return 0;
  }

  public virtual int ProcessBytes(
    byte[] pData,
    int pOffset,
    int pLen,
    byte[] pOutput,
    int pOutOffset)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(pData, pOffset, pLen, "input buffer too short");
    this.CheckStatus(pLen);
    if (this.forEncryption)
    {
      this.thePlain.Write(pData, pOffset, pLen);
      this.theDataHasher.UpdateHash(pData, pOffset, pLen);
    }
    else
      this.theEncData.Write(pData, pOffset, pLen);
    return 0;
  }

  public virtual int DoFinal(byte[] pOutput, int pOffset)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(pOutput, pOffset, this.GetOutputSize(0), "output buffer too short");
    this.CheckStatus(0);
    if (this.forEncryption)
    {
      byte[] tag = this.CalculateTag();
      int num = GcmSivBlockCipher.BUFLEN + this.EncryptPlain(tag, pOutput, pOffset);
      Array.Copy((Array) tag, 0, (Array) pOutput, pOffset + Convert.ToInt32(this.thePlain.Length), GcmSivBlockCipher.BUFLEN);
      this.ResetStreams();
      return num;
    }
    this.DecryptPlain();
    int num1 = Streams.WriteBufTo((MemoryStream) this.thePlain, pOutput, pOffset);
    this.ResetStreams();
    return num1;
  }

  public virtual byte[] GetMac() => throw new InvalidOperationException();

  public virtual int GetUpdateOutputSize(int pLen) => 0;

  public virtual int GetOutputSize(int pLen)
  {
    if (this.forEncryption)
      return pLen + Convert.ToInt32(this.thePlain.Length) + GcmSivBlockCipher.BUFLEN;
    int num = pLen + Convert.ToInt32(this.theEncData.Length);
    return num <= GcmSivBlockCipher.BUFLEN ? 0 : num - GcmSivBlockCipher.BUFLEN;
  }

  public virtual void Reset() => this.ResetStreams();

  private void ResetStreams()
  {
    if (this.thePlain != null)
    {
      int int32 = Convert.ToInt32(this.thePlain.Length);
      Array.Clear((Array) this.thePlain.GetBuffer(), 0, int32);
      this.thePlain.SetLength(0L);
    }
    this.theAEADHasher.Reset();
    this.theDataHasher.Reset();
    this.thePlain = new GcmSivBlockCipher.GcmSivCache();
    this.theEncData = this.forEncryption ? (GcmSivBlockCipher.GcmSivCache) null : new GcmSivBlockCipher.GcmSivCache();
    this.theFlags &= ~GcmSivBlockCipher.AEAD_COMPLETE;
    Arrays.Fill(this.theGHash, (byte) 0);
    if (this.theInitialAEAD == null)
      return;
    this.theAEADHasher.UpdateHash(this.theInitialAEAD, 0, this.theInitialAEAD.Length);
  }

  private static int bufLength(byte[] pBuffer) => pBuffer != null ? pBuffer.Length : 0;

  private int EncryptPlain(byte[] pCounter, byte[] pTarget, int pOffset)
  {
    byte[] buffer = this.thePlain.GetBuffer();
    int int32 = Convert.ToInt32(this.thePlain.Length);
    byte[] pRight = buffer;
    byte[] numArray1 = Arrays.Clone(pCounter);
    numArray1[GcmSivBlockCipher.BUFLEN - 1] |= GcmSivBlockCipher.MASK;
    byte[] numArray2 = new byte[GcmSivBlockCipher.BUFLEN];
    long val2 = (long) int32;
    int pOffset1 = 0;
    while (val2 > 0L)
    {
      this.theCipher.ProcessBlock(numArray1, 0, numArray2, 0);
      int num = (int) Math.Min((long) GcmSivBlockCipher.BUFLEN, val2);
      GcmSivBlockCipher.xorBlock(numArray2, pRight, pOffset1, num);
      Array.Copy((Array) numArray2, 0, (Array) pTarget, pOffset + pOffset1, num);
      val2 -= (long) num;
      pOffset1 += num;
      GcmSivBlockCipher.incrementCounter(numArray1);
    }
    return int32;
  }

  private void DecryptPlain()
  {
    byte[] buffer = this.theEncData.GetBuffer();
    int int32 = Convert.ToInt32(this.theEncData.Length);
    byte[] numArray1 = buffer;
    int buflen = GcmSivBlockCipher.BUFLEN;
    int num1 = int32 - buflen;
    if (num1 < 0)
      throw new InvalidCipherTextException("Data too short");
    byte[] numArray2 = Arrays.CopyOfRange(numArray1, num1, num1 + GcmSivBlockCipher.BUFLEN);
    byte[] numArray3 = Arrays.Clone(numArray2);
    numArray3[GcmSivBlockCipher.BUFLEN - 1] |= GcmSivBlockCipher.MASK;
    byte[] numArray4 = new byte[GcmSivBlockCipher.BUFLEN];
    int pOffset = 0;
    while (num1 > 0)
    {
      this.theCipher.ProcessBlock(numArray3, 0, numArray4, 0);
      int num2 = Math.Min(GcmSivBlockCipher.BUFLEN, num1);
      GcmSivBlockCipher.xorBlock(numArray4, numArray1, pOffset, num2);
      this.thePlain.Write(numArray4, 0, num2);
      this.theDataHasher.UpdateHash(numArray4, 0, num2);
      num1 -= num2;
      pOffset += num2;
      GcmSivBlockCipher.incrementCounter(numArray3);
    }
    if (!Arrays.FixedTimeEquals(this.CalculateTag(), numArray2))
    {
      this.Reset();
      throw new InvalidCipherTextException("mac check failed");
    }
  }

  private byte[] CalculateTag()
  {
    this.theDataHasher.completeHash();
    byte[] inBuf = this.completePolyVal();
    byte[] outBuf = new byte[GcmSivBlockCipher.BUFLEN];
    for (int index = 0; index < GcmSivBlockCipher.NONCELEN; ++index)
      inBuf[index] ^= this.theNonce[index];
    inBuf[GcmSivBlockCipher.BUFLEN - 1] &= (byte) ((uint) GcmSivBlockCipher.MASK - 1U);
    this.theCipher.ProcessBlock(inBuf, 0, outBuf, 0);
    return outBuf;
  }

  private byte[] completePolyVal()
  {
    byte[] pOutput = new byte[GcmSivBlockCipher.BUFLEN];
    this.gHashLengths();
    GcmSivBlockCipher.fillReverse(this.theGHash, 0, GcmSivBlockCipher.BUFLEN, pOutput);
    return pOutput;
  }

  private void gHashLengths()
  {
    byte[] numArray = new byte[GcmSivBlockCipher.BUFLEN];
    Pack.UInt64_To_BE(8UL * this.theDataHasher.getBytesProcessed(), numArray, 0);
    Pack.UInt64_To_BE(8UL * this.theAEADHasher.getBytesProcessed(), numArray, 8);
    this.gHASH(numArray);
  }

  private void gHASH(byte[] pNext)
  {
    GcmSivBlockCipher.xorBlock(this.theGHash, pNext);
    this.theMultiplier.MultiplyH(this.theGHash);
  }

  private static void fillReverse(byte[] pInput, int pOffset, int pLength, byte[] pOutput)
  {
    int num = 0;
    int index = GcmSivBlockCipher.BUFLEN - 1;
    while (num < pLength)
    {
      pOutput[index] = pInput[pOffset + num];
      ++num;
      --index;
    }
  }

  private static void xorBlock(byte[] pLeft, byte[] pRight)
  {
    for (int index = 0; index < GcmSivBlockCipher.BUFLEN; ++index)
      pLeft[index] ^= pRight[index];
  }

  private static void xorBlock(byte[] pLeft, byte[] pRight, int pOffset, int pLength)
  {
    for (int index = 0; index < pLength; ++index)
      pLeft[index] ^= pRight[index + pOffset];
  }

  private static void incrementCounter(byte[] pCounter)
  {
    int index = 0;
    while (index < 4 && ++pCounter[index] == (byte) 0)
      ++index;
  }

  private static void mulX(byte[] pValue)
  {
    byte num1 = 0;
    for (int index = 0; index < GcmSivBlockCipher.BUFLEN; ++index)
    {
      byte num2 = pValue[index];
      pValue[index] = (byte) ((uint) num2 >> 1 & (uint) ~GcmSivBlockCipher.MASK | (uint) num1);
      num1 = ((int) num2 & 1) == 0 ? (byte) 0 : GcmSivBlockCipher.MASK;
    }
    if (num1 == (byte) 0)
      return;
    pValue[0] ^= GcmSivBlockCipher.ADD;
  }

  private void DeriveKeys(KeyParameter pKey)
  {
    byte[] numArray1 = new byte[GcmSivBlockCipher.BUFLEN];
    byte[] numArray2 = new byte[GcmSivBlockCipher.BUFLEN];
    byte[] numArray3 = new byte[GcmSivBlockCipher.BUFLEN];
    byte[] numArray4 = new byte[pKey.KeyLength];
    Array.Copy((Array) this.theNonce, 0, (Array) numArray1, GcmSivBlockCipher.BUFLEN - GcmSivBlockCipher.NONCELEN, GcmSivBlockCipher.NONCELEN);
    this.theCipher.Init(true, (ICipherParameters) pKey);
    int num = 0;
    this.theCipher.ProcessBlock(numArray1, 0, numArray2, 0);
    Array.Copy((Array) numArray2, 0, (Array) numArray3, 0, GcmSivBlockCipher.HALFBUFLEN);
    ++numArray1[0];
    int destinationIndex1 = 0 + GcmSivBlockCipher.HALFBUFLEN;
    this.theCipher.ProcessBlock(numArray1, 0, numArray2, 0);
    Array.Copy((Array) numArray2, 0, (Array) numArray3, destinationIndex1, GcmSivBlockCipher.HALFBUFLEN);
    ++numArray1[0];
    num = 0;
    this.theCipher.ProcessBlock(numArray1, 0, numArray2, 0);
    Array.Copy((Array) numArray2, 0, (Array) numArray4, 0, GcmSivBlockCipher.HALFBUFLEN);
    ++numArray1[0];
    int destinationIndex2 = 0 + GcmSivBlockCipher.HALFBUFLEN;
    this.theCipher.ProcessBlock(numArray1, 0, numArray2, 0);
    Array.Copy((Array) numArray2, 0, (Array) numArray4, destinationIndex2, GcmSivBlockCipher.HALFBUFLEN);
    if (numArray4.Length == GcmSivBlockCipher.BUFLEN << 1)
    {
      ++numArray1[0];
      int destinationIndex3 = destinationIndex2 + GcmSivBlockCipher.HALFBUFLEN;
      this.theCipher.ProcessBlock(numArray1, 0, numArray2, 0);
      Array.Copy((Array) numArray2, 0, (Array) numArray4, destinationIndex3, GcmSivBlockCipher.HALFBUFLEN);
      ++numArray1[0];
      int destinationIndex4 = destinationIndex3 + GcmSivBlockCipher.HALFBUFLEN;
      this.theCipher.ProcessBlock(numArray1, 0, numArray2, 0);
      Array.Copy((Array) numArray2, 0, (Array) numArray4, destinationIndex4, GcmSivBlockCipher.HALFBUFLEN);
    }
    this.theCipher.Init(true, (ICipherParameters) new KeyParameter(numArray4));
    GcmSivBlockCipher.fillReverse(numArray3, 0, GcmSivBlockCipher.BUFLEN, numArray2);
    GcmSivBlockCipher.mulX(numArray2);
    this.theMultiplier.Init(numArray2);
    this.theFlags |= GcmSivBlockCipher.INIT;
  }

  private class GcmSivCache : MemoryStream
  {
    internal GcmSivCache()
    {
    }
  }

  private class GcmSivHasher
  {
    private readonly byte[] theBuffer = new byte[GcmSivBlockCipher.BUFLEN];
    private readonly byte[] theByte = new byte[1];
    private int numActive;
    private ulong numHashed;
    private readonly GcmSivBlockCipher parent;

    internal GcmSivHasher(GcmSivBlockCipher parent) => this.parent = parent;

    internal ulong getBytesProcessed() => this.numHashed;

    internal void Reset()
    {
      this.numActive = 0;
      this.numHashed = 0UL;
    }

    internal void UpdateHash(byte pByte)
    {
      this.theByte[0] = pByte;
      this.UpdateHash(this.theByte, 0, 1);
    }

    internal void UpdateHash(byte[] pBuffer, int pOffset, int pLen)
    {
      int length1 = GcmSivBlockCipher.BUFLEN - this.numActive;
      int num = 0;
      int length2 = pLen;
      if (this.numActive > 0 && pLen >= length1)
      {
        Array.Copy((Array) pBuffer, pOffset, (Array) this.theBuffer, this.numActive, length1);
        GcmSivBlockCipher.fillReverse(this.theBuffer, 0, GcmSivBlockCipher.BUFLEN, this.parent.theReverse);
        this.parent.gHASH(this.parent.theReverse);
        num += length1;
        length2 -= length1;
        this.numActive = 0;
      }
      for (; length2 >= GcmSivBlockCipher.BUFLEN; length2 -= GcmSivBlockCipher.BUFLEN)
      {
        GcmSivBlockCipher.fillReverse(pBuffer, pOffset + num, GcmSivBlockCipher.BUFLEN, this.parent.theReverse);
        this.parent.gHASH(this.parent.theReverse);
        num += GcmSivBlockCipher.BUFLEN;
      }
      if (length2 > 0)
      {
        Array.Copy((Array) pBuffer, pOffset + num, (Array) this.theBuffer, this.numActive, length2);
        this.numActive += length2;
      }
      this.numHashed += (ulong) pLen;
    }

    internal void completeHash()
    {
      if (this.numActive <= 0)
        return;
      Arrays.Fill(this.parent.theReverse, (byte) 0);
      GcmSivBlockCipher.fillReverse(this.theBuffer, 0, this.numActive, this.parent.theReverse);
      this.parent.gHASH(this.parent.theReverse);
    }
  }
}
