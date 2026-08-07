// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.IO.Compression.Zip
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Zlib;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.IO.Compression;

internal static class Zip
{
  internal static Stream CompressOutput(Stream stream, int zlibCompressionLevel, bool leaveOpen = false)
  {
    return !leaveOpen ? (Stream) new ZOutputStream(stream, zlibCompressionLevel, true) : (Stream) new ZOutputStreamLeaveOpen(stream, zlibCompressionLevel, true);
  }

  internal static Stream DecompressInput(Stream stream, bool leaveOpen = false)
  {
    return !leaveOpen ? (Stream) new ZInputStream(stream, true) : (Stream) new ZInputStreamLeaveOpen(stream, true);
  }
}
