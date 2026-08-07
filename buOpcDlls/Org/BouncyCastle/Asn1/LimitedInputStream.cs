// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.LimitedInputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal abstract class LimitedInputStream : BaseInputStream
{
  protected readonly Stream _in;
  private int _limit;

  internal LimitedInputStream(Stream inStream, int limit)
  {
    this._in = inStream;
    this._limit = limit;
  }

  internal virtual int Limit => this._limit;

  protected void SetParentEofDetect()
  {
    if (!(this._in is IndefiniteLengthInputStream))
      return;
    ((IndefiniteLengthInputStream) this._in).SetEofOn00(true);
  }
}
