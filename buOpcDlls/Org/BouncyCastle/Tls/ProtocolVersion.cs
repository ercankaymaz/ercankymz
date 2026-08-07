// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.ProtocolVersion
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class ProtocolVersion
{
  public static readonly ProtocolVersion SSLv3 = new ProtocolVersion(768 /*0x0300*/, "SSL 3.0");
  public static readonly ProtocolVersion TLSv10 = new ProtocolVersion(769, "TLS 1.0");
  public static readonly ProtocolVersion TLSv11 = new ProtocolVersion(770, "TLS 1.1");
  public static readonly ProtocolVersion TLSv12 = new ProtocolVersion(771, "TLS 1.2");
  public static readonly ProtocolVersion TLSv13 = new ProtocolVersion(772, "TLS 1.3");
  public static readonly ProtocolVersion DTLSv10 = new ProtocolVersion(65279, "DTLS 1.0");
  public static readonly ProtocolVersion DTLSv12 = new ProtocolVersion(65277, "DTLS 1.2");
  public static readonly ProtocolVersion DTLSv13 = new ProtocolVersion(65276, "DTLS 1.3");
  internal static readonly ProtocolVersion CLIENT_EARLIEST_SUPPORTED_DTLS = ProtocolVersion.DTLSv10;
  internal static readonly ProtocolVersion CLIENT_EARLIEST_SUPPORTED_TLS = ProtocolVersion.SSLv3;
  internal static readonly ProtocolVersion CLIENT_LATEST_SUPPORTED_DTLS = ProtocolVersion.DTLSv12;
  internal static readonly ProtocolVersion CLIENT_LATEST_SUPPORTED_TLS = ProtocolVersion.TLSv13;
  internal static readonly ProtocolVersion SERVER_EARLIEST_SUPPORTED_DTLS = ProtocolVersion.DTLSv10;
  internal static readonly ProtocolVersion SERVER_EARLIEST_SUPPORTED_TLS = ProtocolVersion.SSLv3;
  internal static readonly ProtocolVersion SERVER_LATEST_SUPPORTED_DTLS = ProtocolVersion.DTLSv12;
  internal static readonly ProtocolVersion SERVER_LATEST_SUPPORTED_TLS = ProtocolVersion.TLSv13;
  private readonly int version;
  private readonly string name;

  public static bool Contains(ProtocolVersion[] versions, ProtocolVersion version)
  {
    if (versions != null && version != null)
    {
      for (int index = 0; index < versions.Length; ++index)
      {
        if (version.Equals(versions[index]))
          return true;
      }
    }
    return false;
  }

  public static ProtocolVersion GetEarliestDtls(ProtocolVersion[] versions)
  {
    ProtocolVersion earliestDtls = (ProtocolVersion) null;
    if (versions != null)
    {
      for (int index = 0; index < versions.Length; ++index)
      {
        ProtocolVersion version = versions[index];
        if (version != null && version.IsDtls && (earliestDtls == null || version.MinorVersion > earliestDtls.MinorVersion))
          earliestDtls = version;
      }
    }
    return earliestDtls;
  }

  public static ProtocolVersion GetEarliestTls(ProtocolVersion[] versions)
  {
    ProtocolVersion earliestTls = (ProtocolVersion) null;
    if (versions != null)
    {
      for (int index = 0; index < versions.Length; ++index)
      {
        ProtocolVersion version = versions[index];
        if (version != null && version.IsTls && (earliestTls == null || version.MinorVersion < earliestTls.MinorVersion))
          earliestTls = version;
      }
    }
    return earliestTls;
  }

  public static ProtocolVersion GetLatestDtls(ProtocolVersion[] versions)
  {
    ProtocolVersion latestDtls = (ProtocolVersion) null;
    if (versions != null)
    {
      for (int index = 0; index < versions.Length; ++index)
      {
        ProtocolVersion version = versions[index];
        if (version != null && version.IsDtls && (latestDtls == null || version.MinorVersion < latestDtls.MinorVersion))
          latestDtls = version;
      }
    }
    return latestDtls;
  }

  public static ProtocolVersion GetLatestTls(ProtocolVersion[] versions)
  {
    ProtocolVersion latestTls = (ProtocolVersion) null;
    if (versions != null)
    {
      for (int index = 0; index < versions.Length; ++index)
      {
        ProtocolVersion version = versions[index];
        if (version != null && version.IsTls && (latestTls == null || version.MinorVersion > latestTls.MinorVersion))
          latestTls = version;
      }
    }
    return latestTls;
  }

  internal static bool IsSupportedDtlsVersionClient(ProtocolVersion version)
  {
    return version != null && version.IsEqualOrLaterVersionOf(ProtocolVersion.CLIENT_EARLIEST_SUPPORTED_DTLS) && version.IsEqualOrEarlierVersionOf(ProtocolVersion.CLIENT_LATEST_SUPPORTED_DTLS);
  }

  internal static bool IsSupportedDtlsVersionServer(ProtocolVersion version)
  {
    return version != null && version.IsEqualOrLaterVersionOf(ProtocolVersion.SERVER_EARLIEST_SUPPORTED_DTLS) && version.IsEqualOrEarlierVersionOf(ProtocolVersion.SERVER_LATEST_SUPPORTED_DTLS);
  }

  internal static bool IsSupportedTlsVersionClient(ProtocolVersion version)
  {
    if (version == null)
      return false;
    int fullVersion = version.FullVersion;
    return fullVersion >= ProtocolVersion.CLIENT_EARLIEST_SUPPORTED_TLS.FullVersion && fullVersion <= ProtocolVersion.CLIENT_LATEST_SUPPORTED_TLS.FullVersion;
  }

  internal static bool IsSupportedTlsVersionServer(ProtocolVersion version)
  {
    if (version == null)
      return false;
    int fullVersion = version.FullVersion;
    return fullVersion >= ProtocolVersion.SERVER_EARLIEST_SUPPORTED_TLS.FullVersion && fullVersion <= ProtocolVersion.SERVER_LATEST_SUPPORTED_TLS.FullVersion;
  }

  private ProtocolVersion(int v, string name)
  {
    this.version = v & (int) ushort.MaxValue;
    this.name = name;
  }

  public ProtocolVersion[] DownTo(ProtocolVersion min)
  {
    if (!this.IsEqualOrLaterVersionOf(min))
      throw new ArgumentException("must be an equal or earlier version of this one", nameof (min));
    List<ProtocolVersion> protocolVersionList = new List<ProtocolVersion>();
    protocolVersionList.Add(this);
    ProtocolVersion protocolVersion = this;
    while (!protocolVersion.Equals(min))
    {
      protocolVersion = protocolVersion.GetPreviousVersion();
      protocolVersionList.Add(protocolVersion);
    }
    return protocolVersionList.ToArray();
  }

  public int FullVersion => this.version;

  public int MajorVersion => this.version >> 8;

  public int MinorVersion => this.version & (int) byte.MaxValue;

  public string Name => this.name;

  public bool IsDtls => this.MajorVersion == 254;

  public bool IsSsl => this == ProtocolVersion.SSLv3;

  public bool IsTls => this.MajorVersion == 3;

  public ProtocolVersion GetEquivalentTlsVersion()
  {
    switch (this.MajorVersion)
    {
      case 3:
        return this;
      case 254:
        switch (this.MinorVersion)
        {
          case 252:
            return ProtocolVersion.TLSv13;
          case 253:
            return ProtocolVersion.TLSv12;
          case (int) byte.MaxValue:
            return ProtocolVersion.TLSv11;
          default:
            return (ProtocolVersion) null;
        }
      default:
        return (ProtocolVersion) null;
    }
  }

  public ProtocolVersion GetNextVersion()
  {
    int majorVersion = this.MajorVersion;
    int minorVersion = this.MinorVersion;
    switch (majorVersion)
    {
      case 3:
        return minorVersion == (int) byte.MaxValue ? (ProtocolVersion) null : ProtocolVersion.Get(majorVersion, minorVersion + 1);
      case 254:
        if (minorVersion == 0)
          return (ProtocolVersion) null;
        return minorVersion != (int) byte.MaxValue ? ProtocolVersion.Get(majorVersion, minorVersion - 1) : ProtocolVersion.DTLSv12;
      default:
        return (ProtocolVersion) null;
    }
  }

  public ProtocolVersion GetPreviousVersion()
  {
    int majorVersion = this.MajorVersion;
    int minorVersion = this.MinorVersion;
    switch (majorVersion)
    {
      case 3:
        return minorVersion == 0 ? (ProtocolVersion) null : ProtocolVersion.Get(majorVersion, minorVersion - 1);
      case 254:
        if (minorVersion == 253)
          return ProtocolVersion.DTLSv10;
        return minorVersion == (int) byte.MaxValue ? (ProtocolVersion) null : ProtocolVersion.Get(majorVersion, minorVersion + 1);
      default:
        return (ProtocolVersion) null;
    }
  }

  public bool IsEarlierVersionOf(ProtocolVersion version)
  {
    if (version == null || this.MajorVersion != version.MajorVersion)
      return false;
    int num = this.MinorVersion - version.MinorVersion;
    return !this.IsDtls ? num < 0 : num > 0;
  }

  public bool IsEqualOrEarlierVersionOf(ProtocolVersion version)
  {
    if (version == null || this.MajorVersion != version.MajorVersion)
      return false;
    int num = this.MinorVersion - version.MinorVersion;
    return !this.IsDtls ? num <= 0 : num >= 0;
  }

  public bool IsEqualOrLaterVersionOf(ProtocolVersion version)
  {
    if (version == null || this.MajorVersion != version.MajorVersion)
      return false;
    int num = this.MinorVersion - version.MinorVersion;
    return !this.IsDtls ? num >= 0 : num <= 0;
  }

  public bool IsLaterVersionOf(ProtocolVersion version)
  {
    if (version == null || this.MajorVersion != version.MajorVersion)
      return false;
    int num = this.MinorVersion - version.MinorVersion;
    return !this.IsDtls ? num > 0 : num < 0;
  }

  public override bool Equals(object other)
  {
    if (this == other)
      return true;
    return other is ProtocolVersion && this.Equals((ProtocolVersion) other);
  }

  public bool Equals(ProtocolVersion other) => other != null && this.version == other.version;

  public override int GetHashCode() => this.version;

  public static ProtocolVersion Get(int major, int minor)
  {
    switch (major)
    {
      case 3:
        switch (minor)
        {
          case 0:
            return ProtocolVersion.SSLv3;
          case 1:
            return ProtocolVersion.TLSv10;
          case 2:
            return ProtocolVersion.TLSv11;
          case 3:
            return ProtocolVersion.TLSv12;
          case 4:
            return ProtocolVersion.TLSv13;
          default:
            return ProtocolVersion.GetUnknownVersion(major, minor, "TLS");
        }
      case 254:
        switch (minor)
        {
          case 252:
            return ProtocolVersion.DTLSv13;
          case 253:
            return ProtocolVersion.DTLSv12;
          case 254:
            throw new ArgumentException("{0xFE, 0xFE} is a reserved protocol version");
          case (int) byte.MaxValue:
            return ProtocolVersion.DTLSv10;
          default:
            return ProtocolVersion.GetUnknownVersion(major, minor, "DTLS");
        }
      default:
        return ProtocolVersion.GetUnknownVersion(major, minor, "UNKNOWN");
    }
  }

  public ProtocolVersion[] Only()
  {
    return new ProtocolVersion[1]{ this };
  }

  public override string ToString() => this.name;

  private static void CheckUint8(int versionOctet)
  {
    if (!TlsUtilities.IsValidUint8(versionOctet))
      throw new ArgumentException("not a valid octet", nameof (versionOctet));
  }

  private static ProtocolVersion GetUnknownVersion(int major, int minor, string prefix)
  {
    ProtocolVersion.CheckUint8(major);
    ProtocolVersion.CheckUint8(minor);
    int v = major << 8 | minor;
    string upperInvariant = Convert.ToString(65536 /*0x010000*/ | v, 16 /*0x10*/).Substring(1).ToUpperInvariant();
    return new ProtocolVersion(v, $"{prefix} 0x{upperInvariant}");
  }
}
