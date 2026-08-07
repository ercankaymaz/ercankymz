// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.IO.TeeOutputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.IO;

public class TeeOutputStream : BaseOutputStream
{
  private readonly Stream output;
  private readonly Stream tee;

  public TeeOutputStream(Stream output, Stream tee)
  {
    this.output = output;
    this.tee = tee;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
    {
      this.output.Dispose();
      this.tee.Dispose();
    }
    base.Dispose(disposing);
  }

  public override void Write(byte[] buffer, int offset, int count)
  {
    this.output.Write(buffer, offset, count);
    this.tee.Write(buffer, offset, count);
  }

  public override void WriteByte(byte value)
  {
    this.output.WriteByte(value);
    this.tee.WriteByte(value);
  }
}
