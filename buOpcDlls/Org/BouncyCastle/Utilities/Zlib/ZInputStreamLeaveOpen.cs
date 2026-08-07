// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Zlib.ZInputStreamLeaveOpen
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.Zlib;

public class ZInputStreamLeaveOpen : ZInputStream
{
  public ZInputStreamLeaveOpen(Stream input)
    : base(input)
  {
  }

  public ZInputStreamLeaveOpen(Stream input, bool nowrap)
    : base(input, nowrap)
  {
  }

  public ZInputStreamLeaveOpen(Stream input, ZStream z)
    : base(input, z)
  {
  }

  public ZInputStreamLeaveOpen(Stream input, int level)
    : base(input, level)
  {
  }

  public ZInputStreamLeaveOpen(Stream input, int level, bool nowrap)
    : base(input, level, nowrap)
  {
  }

  protected override void Dispose(bool disposing) => this.Detach(disposing);
}
