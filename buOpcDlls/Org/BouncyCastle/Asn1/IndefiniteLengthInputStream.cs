// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.IndefiniteLengthInputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class IndefiniteLengthInputStream : LimitedInputStream
{
  private int _lookAhead;
  private bool _eofOn00 = true;

  internal IndefiniteLengthInputStream(Stream inStream, int limit)
    : base(inStream, limit)
  {
    this._lookAhead = this.RequireByte();
    if (this._lookAhead != 0)
      return;
    this.CheckEndOfContents();
  }

  internal void SetEofOn00(bool eofOn00)
  {
    this._eofOn00 = eofOn00;
    if (!this._eofOn00 || this._lookAhead != 0)
      return;
    this.CheckEndOfContents();
  }

  private void CheckEndOfContents()
  {
    if (this.RequireByte() != 0)
      throw new IOException("malformed end-of-contents marker");
    this._lookAhead = -1;
    this.SetParentEofDetect();
  }

  public override int Read(byte[] buffer, int offset, int count)
  {
    if (this._eofOn00 || count <= 1)
      return base.Read(buffer, offset, count);
    if (this._lookAhead < 0)
      return 0;
    int num = this._in.Read(buffer, offset + 1, count - 1);
    if (num <= 0)
      throw new EndOfStreamException();
    buffer[offset] = (byte) this._lookAhead;
    this._lookAhead = this.RequireByte();
    return num + 1;
  }

  public override int ReadByte()
  {
    if (this._eofOn00 && this._lookAhead <= 0)
    {
      if (this._lookAhead == 0)
        this.CheckEndOfContents();
      return -1;
    }
    int lookAhead = this._lookAhead;
    this._lookAhead = this.RequireByte();
    return lookAhead;
  }

  private int RequireByte()
  {
    int num = this._in.ReadByte();
    return num >= 0 ? num : throw new EndOfStreamException();
  }
}
