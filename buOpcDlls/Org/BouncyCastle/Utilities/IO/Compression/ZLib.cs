// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.IO.Compression.ZLib
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Zlib;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.IO.Compression;

internal static class ZLib
{
  internal static Stream CompressOutput(Stream stream, int zlibCompressionLevel, bool leaveOpen = false)
  {
    return !leaveOpen ? (Stream) new ZOutputStream(stream, zlibCompressionLevel, false) : (Stream) new ZOutputStreamLeaveOpen(stream, zlibCompressionLevel, false);
  }

  internal static Stream DecompressInput(Stream stream, bool leaveOpen = false)
  {
    return !leaveOpen ? (Stream) new ZInputStream(stream) : (Stream) new ZInputStreamLeaveOpen(stream);
  }
}
