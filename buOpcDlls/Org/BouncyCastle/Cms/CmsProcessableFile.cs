// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsProcessableFile
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsProcessableFile : CmsProcessable, CmsReadable
{
  private const int DefaultBufSize = 32768 /*0x8000*/;
  private readonly FileInfo _file;
  private readonly int _bufSize;

  public CmsProcessableFile(FileInfo file)
    : this(file, 32768 /*0x8000*/)
  {
  }

  public CmsProcessableFile(FileInfo file, int bufSize)
  {
    this._file = file;
    this._bufSize = bufSize;
  }

  public virtual Stream GetInputStream()
  {
    return (Stream) new FileStream(this._file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, this._bufSize);
  }

  public virtual void Write(Stream zOut)
  {
    using (FileStream inStr = this._file.OpenRead())
      Streams.PipeAll((Stream) inStr, zOut, this._bufSize);
  }
}
