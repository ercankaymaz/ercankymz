// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.IO.Compression.Bzip2
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Bzip2;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.IO.Compression;

internal static class Bzip2
{
  internal static Stream CompressOutput(Stream stream, bool leaveOpen = false)
  {
    return !leaveOpen ? (Stream) new CBZip2OutputStream(stream) : (Stream) new CBZip2OutputStreamLeaveOpen(stream);
  }

  internal static Stream DecompressInput(Stream stream, bool leaveOpen = false)
  {
    return !leaveOpen ? (Stream) new CBZip2InputStream(stream) : (Stream) new CBZip2InputStreamLeaveOpen(stream);
  }
}
