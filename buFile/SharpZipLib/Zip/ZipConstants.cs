// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Zip.ZipConstants
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Globalization;
using System.Text;

#nullable disable
namespace PdfSharp.SharpZipLib.Zip;

internal sealed class ZipConstants
{
  public const int VersionMadeBy = 51;
  [Obsolete("Use VersionMadeBy instead")]
  public const int VERSION_MADE_BY = 51;
  public const int VersionStrongEncryption = 50;
  [Obsolete("Use VersionStrongEncryption instead")]
  public const int VERSION_STRONG_ENCRYPTION = 50;
  public const int VERSION_AES = 51;
  public const int VersionZip64 = 45;
  public const int LocalHeaderBaseSize = 30;
  [Obsolete("Use LocalHeaderBaseSize instead")]
  public const int LOCHDR = 30;
  public const int Zip64DataDescriptorSize = 24;
  public const int DataDescriptorSize = 16 /*0x10*/;
  [Obsolete("Use DataDescriptorSize instead")]
  public const int EXTHDR = 16 /*0x10*/;
  public const int CentralHeaderBaseSize = 46;
  [Obsolete("Use CentralHeaderBaseSize instead")]
  public const int CENHDR = 46;
  public const int EndOfCentralRecordBaseSize = 22;
  [Obsolete("Use EndOfCentralRecordBaseSize instead")]
  public const int ENDHDR = 22;
  public const int CryptoHeaderSize = 12;
  [Obsolete("Use CryptoHeaderSize instead")]
  public const int CRYPTO_HEADER_SIZE = 12;
  public const int LocalHeaderSignature = 67324752;
  [Obsolete("Use LocalHeaderSignature instead")]
  public const int LOCSIG = 67324752;
  public const int SpanningSignature = 134695760;
  [Obsolete("Use SpanningSignature instead")]
  public const int SPANNINGSIG = 134695760;
  public const int SpanningTempSignature = 808471376;
  [Obsolete("Use SpanningTempSignature instead")]
  public const int SPANTEMPSIG = 808471376;
  public const int DataDescriptorSignature = 134695760;
  [Obsolete("Use DataDescriptorSignature instead")]
  public const int EXTSIG = 134695760;
  [Obsolete("Use CentralHeaderSignature instead")]
  public const int CENSIG = 33639248;
  public const int CentralHeaderSignature = 33639248;
  public const int Zip64CentralFileHeaderSignature = 101075792;
  [Obsolete("Use Zip64CentralFileHeaderSignature instead")]
  public const int CENSIG64 = 101075792;
  public const int Zip64CentralDirLocatorSignature = 117853008;
  public const int ArchiveExtraDataSignature = 117853008;
  public const int CentralHeaderDigitalSignature = 84233040;
  [Obsolete("Use CentralHeaderDigitalSignaure instead")]
  public const int CENDIGITALSIG = 84233040;
  public const int EndOfCentralDirectorySignature = 101010256;
  [Obsolete("Use EndOfCentralDirectorySignature instead")]
  public const int ENDSIG = 101010256;
  private static int defaultCodePage = CultureInfo.CurrentCulture.TextInfo.ANSICodePage;

  public static int DefaultCodePage
  {
    get => ZipConstants.defaultCodePage;
    set
    {
      ZipConstants.defaultCodePage = (value < 0 || value > (int) ushort.MaxValue || value == 1 || value == 2 || value == 3 ? 1 : (value == 42 ? 1 : 0)) == 0 ? value : throw new ArgumentOutOfRangeException(nameof (value));
    }
  }

  public static string ConvertToString(byte[] data, int count)
  {
    return data != null ? Encoding.GetEncoding(ZipConstants.DefaultCodePage).GetString(data, 0, count) : string.Empty;
  }

  public static string ConvertToString(byte[] data)
  {
    return data != null ? ZipConstants.ConvertToString(data, data.Length) : string.Empty;
  }

  public static string ConvertToStringExt(int flags, byte[] data, int count)
  {
    return data != null ? ((flags & 2048 /*0x0800*/) == 0 ? ZipConstants.ConvertToString(data, count) : Encoding.UTF8.GetString(data, 0, count)) : string.Empty;
  }

  public static string ConvertToStringExt(int flags, byte[] data)
  {
    return data != null ? ((flags & 2048 /*0x0800*/) == 0 ? ZipConstants.ConvertToString(data, data.Length) : Encoding.UTF8.GetString(data, 0, data.Length)) : string.Empty;
  }

  public static byte[] ConvertToArray(string str)
  {
    return str != null ? Encoding.GetEncoding(ZipConstants.DefaultCodePage).GetBytes(str) : new byte[0];
  }

  public static byte[] ConvertToArray(int flags, string str)
  {
    return str != null ? ((flags & 2048 /*0x0800*/) == 0 ? ZipConstants.ConvertToArray(str) : Encoding.UTF8.GetBytes(str)) : new byte[0];
  }

  private ZipConstants()
  {
  }
}
