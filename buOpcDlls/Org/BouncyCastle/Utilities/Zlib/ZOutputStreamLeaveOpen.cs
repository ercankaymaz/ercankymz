// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Zlib.ZOutputStreamLeaveOpen
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.Zlib;

public class ZOutputStreamLeaveOpen : ZOutputStream
{
  public ZOutputStreamLeaveOpen(Stream output)
    : base(output)
  {
  }

  public ZOutputStreamLeaveOpen(Stream output, bool nowrap)
    : base(output, nowrap)
  {
  }

  public ZOutputStreamLeaveOpen(Stream output, ZStream z)
    : base(output, z)
  {
  }

  public ZOutputStreamLeaveOpen(Stream output, int level)
    : base(output, level)
  {
  }

  public ZOutputStreamLeaveOpen(Stream output, int level, bool nowrap)
    : base(output, level, nowrap)
  {
  }

  protected override void Dispose(bool disposing) => this.Detach(disposing);
}
