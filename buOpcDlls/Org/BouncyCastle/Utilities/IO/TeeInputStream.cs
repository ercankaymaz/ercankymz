// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.IO.TeeInputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.IO;

public class TeeInputStream : BaseInputStream
{
  private readonly Stream input;
  private readonly Stream tee;

  public TeeInputStream(Stream input, Stream tee)
  {
    this.input = input;
    this.tee = tee;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
    {
      this.input.Dispose();
      this.tee.Dispose();
    }
    base.Dispose(disposing);
  }

  public override int Read(byte[] buffer, int offset, int count)
  {
    int count1 = this.input.Read(buffer, offset, count);
    if (count1 > 0)
      this.tee.Write(buffer, offset, count1);
    return count1;
  }

  public override int ReadByte()
  {
    int num = this.input.ReadByte();
    if (num >= 0)
      this.tee.WriteByte((byte) num);
    return num;
  }
}
