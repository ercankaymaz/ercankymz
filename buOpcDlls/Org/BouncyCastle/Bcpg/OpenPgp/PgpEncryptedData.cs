// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpEncryptedData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public abstract class PgpEncryptedData
{
  internal InputStreamPacket encData;
  internal Stream encStream;
  internal PgpEncryptedData.TruncatedStream truncStream;

  internal PgpEncryptedData(InputStreamPacket encData) => this.encData = encData;

  public virtual Stream GetInputStream() => (Stream) this.encData.GetInputStream();

  public bool IsIntegrityProtected() => this.encData is SymmetricEncIntegrityPacket;

  public bool Verify()
  {
    if (!this.IsIntegrityProtected())
      throw new PgpException("data not integrity protected.");
    DigestStream encStream = (DigestStream) this.encStream;
    do
      ;
    while (this.encStream.ReadByte() >= 0);
    byte[] lookAhead = this.truncStream.GetLookAhead();
    IDigest readDigest = encStream.ReadDigest;
    readDigest.BlockUpdate(lookAhead, 0, 2);
    byte[] a = DigestUtilities.DoFinal(readDigest);
    byte[] numArray = new byte[a.Length];
    Array.Copy((Array) lookAhead, 2, (Array) numArray, 0, numArray.Length);
    return Arrays.FixedTimeEquals(a, numArray);
  }

  internal class TruncatedStream : BaseInputStream
  {
    private const int LookAheadSize = 22;
    private const int LookAheadBufSize = 512 /*0x0200*/;
    private const int LookAheadBufLimit = 490;
    private readonly Stream inStr;
    private readonly byte[] lookAhead = new byte[512 /*0x0200*/];
    private int bufStart;
    private int bufEnd;

    internal TruncatedStream(Stream inStr)
    {
      int num = Streams.ReadFully(inStr, this.lookAhead, 0, this.lookAhead.Length);
      if (num < 22)
        throw new EndOfStreamException();
      this.inStr = inStr;
      this.bufStart = 0;
      this.bufEnd = num - 22;
    }

    private int FillBuffer()
    {
      if (this.bufEnd < 490)
        return 0;
      Array.Copy((Array) this.lookAhead, 490, (Array) this.lookAhead, 0, 22);
      this.bufEnd = Streams.ReadFully(this.inStr, this.lookAhead, 22, 490);
      this.bufStart = 0;
      return this.bufEnd;
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      Streams.ValidateBufferArguments(buffer, offset, count);
      int length = this.bufEnd - this.bufStart;
      int destinationIndex = offset;
      while (count > length)
      {
        Array.Copy((Array) this.lookAhead, this.bufStart, (Array) buffer, destinationIndex, length);
        this.bufStart += length;
        destinationIndex += length;
        count -= length;
        if ((length = this.FillBuffer()) < 1)
          return destinationIndex - offset;
      }
      Array.Copy((Array) this.lookAhead, this.bufStart, (Array) buffer, destinationIndex, count);
      this.bufStart += count;
      return destinationIndex + count - offset;
    }

    public override int ReadByte()
    {
      return this.bufStart < this.bufEnd || this.FillBuffer() >= 1 ? (int) this.lookAhead[this.bufStart++] : -1;
    }

    internal byte[] GetLookAhead()
    {
      byte[] destinationArray = new byte[22];
      Array.Copy((Array) this.lookAhead, this.bufStart, (Array) destinationArray, 0, 22);
      return destinationArray;
    }
  }
}
