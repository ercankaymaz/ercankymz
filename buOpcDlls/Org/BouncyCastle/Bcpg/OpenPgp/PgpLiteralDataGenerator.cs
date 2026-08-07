// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpLiteralDataGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Date;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpLiteralDataGenerator : IStreamGenerator
{
  public const char Binary = 'b';
  public const char Text = 't';
  public const char Utf8 = 'u';
  public const string Console = "_CONSOLE";
  private BcpgOutputStream pkOut;
  private bool oldFormat;

  public PgpLiteralDataGenerator()
  {
  }

  public PgpLiteralDataGenerator(bool oldFormat) => this.oldFormat = oldFormat;

  private void WriteHeader(
    BcpgOutputStream outStr,
    char format,
    byte[] encName,
    long modificationTime)
  {
    outStr.Write((byte) format, (byte) encName.Length);
    outStr.Write(encName);
    long num = modificationTime / 1000L;
    outStr.Write((byte) (num >> 24), (byte) (num >> 16 /*0x10*/), (byte) (num >> 8), (byte) num);
  }

  public Stream Open(
    Stream outStr,
    char format,
    string name,
    long length,
    DateTime modificationTime)
  {
    if (this.pkOut != null)
      throw new InvalidOperationException("generator already in open state");
    if (outStr == null)
      throw new ArgumentNullException(nameof (outStr));
    long unixMs = DateTimeUtilities.DateTimeToUnixMs(modificationTime);
    byte[] utf8ByteArray = Strings.ToUtf8ByteArray(name);
    this.pkOut = new BcpgOutputStream(outStr, PacketTag.LiteralData, length + 2L + (long) utf8ByteArray.Length + 4L, this.oldFormat);
    this.WriteHeader(this.pkOut, format, utf8ByteArray, unixMs);
    return (Stream) new WrappedGeneratorStream((IStreamGenerator) this, (Stream) this.pkOut);
  }

  public Stream Open(
    Stream outStr,
    char format,
    string name,
    DateTime modificationTime,
    byte[] buffer)
  {
    if (this.pkOut != null)
      throw new InvalidOperationException("generator already in open state");
    if (outStr == null)
      throw new ArgumentNullException(nameof (outStr));
    long unixMs = DateTimeUtilities.DateTimeToUnixMs(modificationTime);
    byte[] utf8ByteArray = Strings.ToUtf8ByteArray(name);
    this.pkOut = new BcpgOutputStream(outStr, PacketTag.LiteralData, buffer);
    this.WriteHeader(this.pkOut, format, utf8ByteArray, unixMs);
    return (Stream) new WrappedGeneratorStream((IStreamGenerator) this, (Stream) this.pkOut);
  }

  public Stream Open(Stream outStr, char format, FileInfo file)
  {
    return this.Open(outStr, format, file.Name, file.Length, file.LastWriteTime);
  }

  [Obsolete("Dispose any opened Stream directly")]
  public void Close()
  {
    if (this.pkOut == null)
      return;
    this.pkOut.Finish();
    this.pkOut.Flush();
    this.pkOut = (BcpgOutputStream) null;
  }
}
