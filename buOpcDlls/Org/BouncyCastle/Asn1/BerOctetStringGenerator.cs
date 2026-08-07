// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.BerOctetStringGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class BerOctetStringGenerator : BerGenerator
{
  public BerOctetStringGenerator(Stream outStream)
    : base(outStream)
  {
    this.WriteBerHeader(36);
  }

  public BerOctetStringGenerator(Stream outStream, int tagNo, bool isExplicit)
    : base(outStream, tagNo, isExplicit)
  {
    this.WriteBerHeader(36);
  }

  public Stream GetOctetOutputStream() => this.GetOctetOutputStream(new byte[1000]);

  public Stream GetOctetOutputStream(int bufSize)
  {
    return bufSize >= 1 ? this.GetOctetOutputStream(new byte[bufSize]) : this.GetOctetOutputStream();
  }

  public Stream GetOctetOutputStream(byte[] buf)
  {
    return (Stream) new BerOctetStringGenerator.BufferedBerOctetStream(this.GetRawOutputStream(), buf);
  }

  private class BufferedBerOctetStream : BaseOutputStream
  {
    private byte[] _buf;
    private int _off;
    private readonly Asn1OutputStream _derOut;

    internal BufferedBerOctetStream(Stream outStream, byte[] buf)
    {
      this._buf = buf;
      this._off = 0;
      this._derOut = Asn1OutputStream.Create(outStream, "DER", true);
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      Streams.ValidateBufferArguments(buffer, offset, count);
      int length1 = this._buf.Length;
      int length2 = length1 - this._off;
      if (count < length2)
      {
        Array.Copy((Array) buffer, offset, (Array) this._buf, this._off, count);
        this._off += count;
      }
      else
      {
        int num = 0;
        if (this._off > 0)
        {
          Array.Copy((Array) buffer, offset, (Array) this._buf, this._off, length2);
          num = length2;
          DerOctetString.Encode(this._derOut, this._buf, 0, length1);
        }
        int length3;
        for (; (length3 = count - num) >= length1; num += length1)
          DerOctetString.Encode(this._derOut, buffer, offset + num, length1);
        Array.Copy((Array) buffer, offset + num, (Array) this._buf, 0, length3);
        this._off = length3;
      }
    }

    public override void WriteByte(byte value)
    {
      this._buf[this._off++] = value;
      if (this._off != this._buf.Length)
        return;
      DerOctetString.Encode(this._derOut, this._buf, 0, this._off);
      this._off = 0;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (this._off != 0)
        {
          DerOctetString.Encode(this._derOut, this._buf, 0, this._off);
          this._off = 0;
        }
        this._derOut.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
