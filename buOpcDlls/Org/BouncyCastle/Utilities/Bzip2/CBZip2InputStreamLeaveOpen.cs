// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Bzip2.CBZip2InputStreamLeaveOpen
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.Bzip2;

public class CBZip2InputStreamLeaveOpen(Stream outStream) : CBZip2InputStream(outStream)
{
  protected override void Dispose(bool disposing) => this.Detach(disposing);
}
