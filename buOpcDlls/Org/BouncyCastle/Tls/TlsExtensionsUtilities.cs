// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsExtensionsUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public static class TlsExtensionsUtilities
{
  public static IDictionary<int, byte[]> EnsureExtensionsInitialised(
    IDictionary<int, byte[]> extensions)
  {
    return extensions != null ? extensions : (IDictionary<int, byte[]>) new Dictionary<int, byte[]>();
  }

  public static void AddAlpnExtensionClient(
    IDictionary<int, byte[]> extensions,
    IList<ProtocolName> protocolNameList)
  {
    extensions[16 /*0x10*/] = TlsExtensionsUtilities.CreateAlpnExtensionClient(protocolNameList);
  }

  public static void AddAlpnExtensionServer(
    IDictionary<int, byte[]> extensions,
    ProtocolName protocolName)
  {
    extensions[16 /*0x10*/] = TlsExtensionsUtilities.CreateAlpnExtensionServer(protocolName);
  }

  public static void AddCertificateAuthoritiesExtension(
    IDictionary<int, byte[]> extensions,
    IList<X509Name> authorities)
  {
    extensions[47] = TlsExtensionsUtilities.CreateCertificateAuthoritiesExtension(authorities);
  }

  public static void AddClientCertificateTypeExtensionClient(
    IDictionary<int, byte[]> extensions,
    short[] certificateTypes)
  {
    extensions[19] = TlsExtensionsUtilities.CreateCertificateTypeExtensionClient(certificateTypes);
  }

  public static void AddClientCertificateTypeExtensionServer(
    IDictionary<int, byte[]> extensions,
    short certificateType)
  {
    extensions[19] = TlsExtensionsUtilities.CreateCertificateTypeExtensionServer(certificateType);
  }

  public static void AddClientCertificateUrlExtension(IDictionary<int, byte[]> extensions)
  {
    extensions[2] = TlsExtensionsUtilities.CreateClientCertificateUrlExtension();
  }

  public static void AddCompressCertificateExtension(
    IDictionary<int, byte[]> extensions,
    int[] algorithms)
  {
    extensions[27] = TlsExtensionsUtilities.CreateCompressCertificateExtension(algorithms);
  }

  public static void AddConnectionIDExtension(
    IDictionary<int, byte[]> extensions,
    byte[] connectionID)
  {
    extensions[54] = TlsExtensionsUtilities.CreateConnectionIDExtension(connectionID);
  }

  public static void AddCookieExtension(IDictionary<int, byte[]> extensions, byte[] cookie)
  {
    extensions[44] = TlsExtensionsUtilities.CreateCookieExtension(cookie);
  }

  public static void AddEarlyDataIndication(IDictionary<int, byte[]> extensions)
  {
    extensions[42] = TlsExtensionsUtilities.CreateEarlyDataIndication();
  }

  public static void AddEarlyDataMaxSize(IDictionary<int, byte[]> extensions, long maxSize)
  {
    extensions[42] = TlsExtensionsUtilities.CreateEarlyDataMaxSize(maxSize);
  }

  public static void AddEmptyExtensionData(IDictionary<int, byte[]> extensions, int extType)
  {
    extensions[extType] = TlsExtensionsUtilities.CreateEmptyExtensionData();
  }

  public static void AddEncryptThenMacExtension(IDictionary<int, byte[]> extensions)
  {
    extensions[22] = TlsExtensionsUtilities.CreateEncryptThenMacExtension();
  }

  public static void AddExtendedMasterSecretExtension(IDictionary<int, byte[]> extensions)
  {
    extensions[23] = TlsExtensionsUtilities.CreateExtendedMasterSecretExtension();
  }

  public static void AddHeartbeatExtension(
    IDictionary<int, byte[]> extensions,
    HeartbeatExtension heartbeatExtension)
  {
    extensions[15] = TlsExtensionsUtilities.CreateHeartbeatExtension(heartbeatExtension);
  }

  public static void AddKeyShareClientHello(
    IDictionary<int, byte[]> extensions,
    IList<KeyShareEntry> clientShares)
  {
    extensions[51] = TlsExtensionsUtilities.CreateKeyShareClientHello(clientShares);
  }

  public static void AddKeyShareHelloRetryRequest(
    IDictionary<int, byte[]> extensions,
    int namedGroup)
  {
    extensions[51] = TlsExtensionsUtilities.CreateKeyShareHelloRetryRequest(namedGroup);
  }

  public static void AddKeyShareServerHello(
    IDictionary<int, byte[]> extensions,
    KeyShareEntry serverShare)
  {
    extensions[51] = TlsExtensionsUtilities.CreateKeyShareServerHello(serverShare);
  }

  public static void AddMaxFragmentLengthExtension(
    IDictionary<int, byte[]> extensions,
    short maxFragmentLength)
  {
    extensions[1] = TlsExtensionsUtilities.CreateMaxFragmentLengthExtension(maxFragmentLength);
  }

  public static void AddOidFiltersExtension(
    IDictionary<int, byte[]> extensions,
    IDictionary<DerObjectIdentifier, byte[]> filters)
  {
    extensions[48 /*0x30*/] = TlsExtensionsUtilities.CreateOidFiltersExtension(filters);
  }

  public static void AddPaddingExtension(IDictionary<int, byte[]> extensions, int dataLength)
  {
    extensions[21] = TlsExtensionsUtilities.CreatePaddingExtension(dataLength);
  }

  public static void AddPostHandshakeAuthExtension(IDictionary<int, byte[]> extensions)
  {
    extensions[49] = TlsExtensionsUtilities.CreatePostHandshakeAuthExtension();
  }

  public static void AddPreSharedKeyClientHello(
    IDictionary<int, byte[]> extensions,
    OfferedPsks offeredPsks)
  {
    extensions[41] = TlsExtensionsUtilities.CreatePreSharedKeyClientHello(offeredPsks);
  }

  public static void AddPreSharedKeyServerHello(
    IDictionary<int, byte[]> extensions,
    int selectedIdentity)
  {
    extensions[41] = TlsExtensionsUtilities.CreatePreSharedKeyServerHello(selectedIdentity);
  }

  public static void AddPskKeyExchangeModesExtension(
    IDictionary<int, byte[]> extensions,
    short[] modes)
  {
    extensions[45] = TlsExtensionsUtilities.CreatePskKeyExchangeModesExtension(modes);
  }

  public static void AddRecordSizeLimitExtension(
    IDictionary<int, byte[]> extensions,
    int recordSizeLimit)
  {
    extensions[28] = TlsExtensionsUtilities.CreateRecordSizeLimitExtension(recordSizeLimit);
  }

  public static void AddServerCertificateTypeExtensionClient(
    IDictionary<int, byte[]> extensions,
    short[] certificateTypes)
  {
    extensions[20] = TlsExtensionsUtilities.CreateCertificateTypeExtensionClient(certificateTypes);
  }

  public static void AddServerCertificateTypeExtensionServer(
    IDictionary<int, byte[]> extensions,
    short certificateType)
  {
    extensions[20] = TlsExtensionsUtilities.CreateCertificateTypeExtensionServer(certificateType);
  }

  public static void AddServerNameExtensionClient(
    IDictionary<int, byte[]> extensions,
    IList<ServerName> serverNameList)
  {
    extensions[0] = TlsExtensionsUtilities.CreateServerNameExtensionClient(serverNameList);
  }

  public static void AddServerNameExtensionServer(IDictionary<int, byte[]> extensions)
  {
    extensions[0] = TlsExtensionsUtilities.CreateServerNameExtensionServer();
  }

  public static void AddSignatureAlgorithmsExtension(
    IDictionary<int, byte[]> extensions,
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithms)
  {
    extensions[13] = TlsExtensionsUtilities.CreateSignatureAlgorithmsExtension(supportedSignatureAlgorithms);
  }

  public static void AddSignatureAlgorithmsCertExtension(
    IDictionary<int, byte[]> extensions,
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithms)
  {
    extensions[50] = TlsExtensionsUtilities.CreateSignatureAlgorithmsCertExtension(supportedSignatureAlgorithms);
  }

  public static void AddStatusRequestExtension(
    IDictionary<int, byte[]> extensions,
    CertificateStatusRequest statusRequest)
  {
    extensions[5] = TlsExtensionsUtilities.CreateStatusRequestExtension(statusRequest);
  }

  public static void AddStatusRequestV2Extension(
    IDictionary<int, byte[]> extensions,
    IList<CertificateStatusRequestItemV2> statusRequestV2)
  {
    extensions[17] = TlsExtensionsUtilities.CreateStatusRequestV2Extension(statusRequestV2);
  }

  public static void AddSupportedGroupsExtension(
    IDictionary<int, byte[]> extensions,
    IList<int> namedGroups)
  {
    extensions[10] = TlsExtensionsUtilities.CreateSupportedGroupsExtension(namedGroups);
  }

  public static void AddSupportedPointFormatsExtension(
    IDictionary<int, byte[]> extensions,
    short[] ecPointFormats)
  {
    extensions[11] = TlsExtensionsUtilities.CreateSupportedPointFormatsExtension(ecPointFormats);
  }

  public static void AddSupportedVersionsExtensionClient(
    IDictionary<int, byte[]> extensions,
    ProtocolVersion[] versions)
  {
    extensions[43] = TlsExtensionsUtilities.CreateSupportedVersionsExtensionClient(versions);
  }

  public static void AddSupportedVersionsExtensionServer(
    IDictionary<int, byte[]> extensions,
    ProtocolVersion selectedVersion)
  {
    extensions[43] = TlsExtensionsUtilities.CreateSupportedVersionsExtensionServer(selectedVersion);
  }

  public static void AddTruncatedHmacExtension(IDictionary<int, byte[]> extensions)
  {
    extensions[4] = TlsExtensionsUtilities.CreateTruncatedHmacExtension();
  }

  public static void AddTrustedCAKeysExtensionClient(
    IDictionary<int, byte[]> extensions,
    IList<TrustedAuthority> trustedAuthoritiesList)
  {
    extensions[3] = TlsExtensionsUtilities.CreateTrustedCAKeysExtensionClient(trustedAuthoritiesList);
  }

  public static void AddTrustedCAKeysExtensionServer(IDictionary<int, byte[]> extensions)
  {
    extensions[3] = TlsExtensionsUtilities.CreateTrustedCAKeysExtensionServer();
  }

  public static IList<ProtocolName> GetAlpnExtensionClient(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 16 /*0x10*/);
    return extensionData != null ? TlsExtensionsUtilities.ReadAlpnExtensionClient(extensionData) : (IList<ProtocolName>) null;
  }

  public static ProtocolName GetAlpnExtensionServer(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 16 /*0x10*/);
    return extensionData != null ? TlsExtensionsUtilities.ReadAlpnExtensionServer(extensionData) : (ProtocolName) null;
  }

  public static IList<X509Name> GetCertificateAuthoritiesExtension(
    IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 47);
    return extensionData != null ? TlsExtensionsUtilities.ReadCertificateAuthoritiesExtension(extensionData) : (IList<X509Name>) null;
  }

  public static short[] GetClientCertificateTypeExtensionClient(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 19);
    return extensionData != null ? TlsExtensionsUtilities.ReadCertificateTypeExtensionClient(extensionData) : (short[]) null;
  }

  public static short GetClientCertificateTypeExtensionServer(
    IDictionary<int, byte[]> extensions,
    short defaultValue)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 19);
    return extensionData != null ? TlsExtensionsUtilities.ReadCertificateTypeExtensionServer(extensionData) : defaultValue;
  }

  public static int[] GetCompressCertificateExtension(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 27);
    return extensionData != null ? TlsExtensionsUtilities.ReadCompressCertificateExtension(extensionData) : (int[]) null;
  }

  public static byte[] GetConnectionIDExtension(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 54);
    return extensionData != null ? TlsExtensionsUtilities.ReadConnectionIDExtension(extensionData) : (byte[]) null;
  }

  public static byte[] GetCookieExtension(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 44);
    return extensionData != null ? TlsExtensionsUtilities.ReadCookieExtension(extensionData) : (byte[]) null;
  }

  public static long GetEarlyDataMaxSize(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 42);
    return extensionData != null ? TlsExtensionsUtilities.ReadEarlyDataMaxSize(extensionData) : -1L;
  }

  public static HeartbeatExtension GetHeartbeatExtension(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 15);
    return extensionData != null ? TlsExtensionsUtilities.ReadHeartbeatExtension(extensionData) : (HeartbeatExtension) null;
  }

  public static IList<KeyShareEntry> GetKeyShareClientHello(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 51);
    return extensionData != null ? TlsExtensionsUtilities.ReadKeyShareClientHello(extensionData) : (IList<KeyShareEntry>) null;
  }

  public static int GetKeyShareHelloRetryRequest(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 51);
    return extensionData != null ? TlsExtensionsUtilities.ReadKeyShareHelloRetryRequest(extensionData) : -1;
  }

  public static KeyShareEntry GetKeyShareServerHello(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 51);
    return extensionData != null ? TlsExtensionsUtilities.ReadKeyShareServerHello(extensionData) : (KeyShareEntry) null;
  }

  public static short GetMaxFragmentLengthExtension(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 1);
    return extensionData != null ? TlsExtensionsUtilities.ReadMaxFragmentLengthExtension(extensionData) : (short) -1;
  }

  public static IDictionary<DerObjectIdentifier, byte[]> GetOidFiltersExtension(
    IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 48 /*0x30*/);
    return extensionData != null ? TlsExtensionsUtilities.ReadOidFiltersExtension(extensionData) : (IDictionary<DerObjectIdentifier, byte[]>) null;
  }

  public static int GetPaddingExtension(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 21);
    return extensionData != null ? TlsExtensionsUtilities.ReadPaddingExtension(extensionData) : -1;
  }

  public static OfferedPsks GetPreSharedKeyClientHello(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 41);
    return extensionData != null ? TlsExtensionsUtilities.ReadPreSharedKeyClientHello(extensionData) : (OfferedPsks) null;
  }

  public static int GetPreSharedKeyServerHello(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 41);
    return extensionData != null ? TlsExtensionsUtilities.ReadPreSharedKeyServerHello(extensionData) : -1;
  }

  public static short[] GetPskKeyExchangeModesExtension(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 45);
    return extensionData != null ? TlsExtensionsUtilities.ReadPskKeyExchangeModesExtension(extensionData) : (short[]) null;
  }

  public static int GetRecordSizeLimitExtension(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 28);
    return extensionData != null ? TlsExtensionsUtilities.ReadRecordSizeLimitExtension(extensionData) : -1;
  }

  public static short[] GetServerCertificateTypeExtensionClient(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 20);
    return extensionData != null ? TlsExtensionsUtilities.ReadCertificateTypeExtensionClient(extensionData) : (short[]) null;
  }

  public static short GetServerCertificateTypeExtensionServer(
    IDictionary<int, byte[]> extensions,
    short defaultValue)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 20);
    return extensionData != null ? TlsExtensionsUtilities.ReadCertificateTypeExtensionServer(extensionData) : defaultValue;
  }

  public static IList<ServerName> GetServerNameExtensionClient(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 0);
    return extensionData != null ? TlsExtensionsUtilities.ReadServerNameExtensionClient(extensionData) : (IList<ServerName>) null;
  }

  public static IList<SignatureAndHashAlgorithm> GetSignatureAlgorithmsExtension(
    IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 13);
    return extensionData != null ? TlsExtensionsUtilities.ReadSignatureAlgorithmsExtension(extensionData) : (IList<SignatureAndHashAlgorithm>) null;
  }

  public static IList<SignatureAndHashAlgorithm> GetSignatureAlgorithmsCertExtension(
    IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 50);
    return extensionData != null ? TlsExtensionsUtilities.ReadSignatureAlgorithmsCertExtension(extensionData) : (IList<SignatureAndHashAlgorithm>) null;
  }

  public static CertificateStatusRequest GetStatusRequestExtension(
    IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 5);
    return extensionData != null ? TlsExtensionsUtilities.ReadStatusRequestExtension(extensionData) : (CertificateStatusRequest) null;
  }

  public static IList<CertificateStatusRequestItemV2> GetStatusRequestV2Extension(
    IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 17);
    return extensionData != null ? TlsExtensionsUtilities.ReadStatusRequestV2Extension(extensionData) : (IList<CertificateStatusRequestItemV2>) null;
  }

  public static int[] GetSupportedGroupsExtension(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 10);
    return extensionData != null ? TlsExtensionsUtilities.ReadSupportedGroupsExtension(extensionData) : (int[]) null;
  }

  public static short[] GetSupportedPointFormatsExtension(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 11);
    return extensionData != null ? TlsExtensionsUtilities.ReadSupportedPointFormatsExtension(extensionData) : (short[]) null;
  }

  public static ProtocolVersion[] GetSupportedVersionsExtensionClient(
    IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 43);
    return extensionData != null ? TlsExtensionsUtilities.ReadSupportedVersionsExtensionClient(extensionData) : (ProtocolVersion[]) null;
  }

  public static ProtocolVersion GetSupportedVersionsExtensionServer(
    IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 43);
    return extensionData != null ? TlsExtensionsUtilities.ReadSupportedVersionsExtensionServer(extensionData) : (ProtocolVersion) null;
  }

  public static IList<TrustedAuthority> GetTrustedCAKeysExtensionClient(
    IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 3);
    return extensionData != null ? TlsExtensionsUtilities.ReadTrustedCAKeysExtensionClient(extensionData) : (IList<TrustedAuthority>) null;
  }

  public static bool HasClientCertificateUrlExtension(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 2);
    return extensionData != null && TlsExtensionsUtilities.ReadClientCertificateUrlExtension(extensionData);
  }

  public static bool HasEarlyDataIndication(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 42);
    return extensionData != null && TlsExtensionsUtilities.ReadEarlyDataIndication(extensionData);
  }

  public static bool HasEncryptThenMacExtension(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 22);
    return extensionData != null && TlsExtensionsUtilities.ReadEncryptThenMacExtension(extensionData);
  }

  public static bool HasExtendedMasterSecretExtension(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 23);
    return extensionData != null && TlsExtensionsUtilities.ReadExtendedMasterSecretExtension(extensionData);
  }

  public static bool HasServerNameExtensionServer(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 0);
    return extensionData != null && TlsExtensionsUtilities.ReadServerNameExtensionServer(extensionData);
  }

  public static bool HasPostHandshakeAuthExtension(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 49);
    return extensionData != null && TlsExtensionsUtilities.ReadPostHandshakeAuthExtension(extensionData);
  }

  public static bool HasTruncatedHmacExtension(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 4);
    return extensionData != null && TlsExtensionsUtilities.ReadTruncatedHmacExtension(extensionData);
  }

  public static bool HasTrustedCAKeysExtensionServer(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 3);
    return extensionData != null && TlsExtensionsUtilities.ReadTrustedCAKeysExtensionServer(extensionData);
  }

  public static byte[] CreateAlpnExtensionClient(IList<ProtocolName> protocolNameList)
  {
    if (protocolNameList == null || protocolNameList.Count < 1)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    MemoryStream memoryStream = new MemoryStream();
    TlsUtilities.WriteUint16(0, (Stream) memoryStream);
    foreach (ProtocolName protocolName in (IEnumerable<ProtocolName>) protocolNameList)
      protocolName.Encode((Stream) memoryStream);
    return TlsExtensionsUtilities.PatchOpaque16(memoryStream);
  }

  public static byte[] CreateAlpnExtensionServer(ProtocolName protocolName)
  {
    return TlsExtensionsUtilities.CreateAlpnExtensionClient((IList<ProtocolName>) new List<ProtocolName>()
    {
      protocolName
    });
  }

  public static byte[] CreateCertificateAuthoritiesExtension(IList<X509Name> authorities)
  {
    if (authorities == null || authorities.Count < 1)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    MemoryStream memoryStream = new MemoryStream();
    TlsUtilities.WriteUint16(0, (Stream) memoryStream);
    foreach (Asn1Encodable authority in (IEnumerable<X509Name>) authorities)
      TlsUtilities.WriteOpaque16(authority.GetEncoded("DER"), (Stream) memoryStream);
    return TlsExtensionsUtilities.PatchOpaque16(memoryStream);
  }

  public static byte[] CreateCertificateTypeExtensionClient(short[] certificateTypes)
  {
    return !TlsUtilities.IsNullOrEmpty<short>(certificateTypes) && certificateTypes.Length <= (int) byte.MaxValue ? TlsUtilities.EncodeUint8ArrayWithUint8Length(certificateTypes) : throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static byte[] CreateCertificateTypeExtensionServer(short certificateType)
  {
    return TlsUtilities.EncodeUint8(certificateType);
  }

  public static byte[] CreateClientCertificateUrlExtension()
  {
    return TlsExtensionsUtilities.CreateEmptyExtensionData();
  }

  public static byte[] CreateCompressCertificateExtension(int[] algorithms)
  {
    return !TlsUtilities.IsNullOrEmpty<int>(algorithms) && algorithms.Length <= (int) sbyte.MaxValue ? TlsUtilities.EncodeUint16ArrayWithUint8Length(algorithms) : throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static byte[] CreateConnectionIDExtension(byte[] connectionID)
  {
    return connectionID != null ? TlsUtilities.EncodeOpaque8(connectionID) : throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static byte[] CreateCookieExtension(byte[] cookie)
  {
    return !TlsUtilities.IsNullOrEmpty<byte>(cookie) && cookie.Length < 65536 /*0x010000*/ ? TlsUtilities.EncodeOpaque16(cookie) : throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static byte[] CreateEarlyDataIndication()
  {
    return TlsExtensionsUtilities.CreateEmptyExtensionData();
  }

  public static byte[] CreateEarlyDataMaxSize(long maxSize) => TlsUtilities.EncodeUint32(maxSize);

  public static byte[] CreateEmptyExtensionData() => TlsUtilities.EmptyBytes;

  public static byte[] CreateEncryptThenMacExtension()
  {
    return TlsExtensionsUtilities.CreateEmptyExtensionData();
  }

  public static byte[] CreateExtendedMasterSecretExtension()
  {
    return TlsExtensionsUtilities.CreateEmptyExtensionData();
  }

  public static byte[] CreateHeartbeatExtension(HeartbeatExtension heartbeatExtension)
  {
    if (heartbeatExtension == null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    MemoryStream output = new MemoryStream();
    heartbeatExtension.Encode((Stream) output);
    return output.ToArray();
  }

  public static byte[] CreateKeyShareClientHello(IList<KeyShareEntry> clientShares)
  {
    if (clientShares == null || clientShares.Count < 1)
      return TlsUtilities.EncodeUint16(0);
    MemoryStream memoryStream = new MemoryStream();
    TlsUtilities.WriteUint16(0, (Stream) memoryStream);
    foreach (KeyShareEntry clientShare in (IEnumerable<KeyShareEntry>) clientShares)
      clientShare.Encode((Stream) memoryStream);
    return TlsExtensionsUtilities.PatchOpaque16(memoryStream);
  }

  public static byte[] CreateKeyShareHelloRetryRequest(int namedGroup)
  {
    return TlsUtilities.EncodeUint16(namedGroup);
  }

  public static byte[] CreateKeyShareServerHello(KeyShareEntry serverShare)
  {
    if (serverShare == null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    MemoryStream output = new MemoryStream();
    serverShare.Encode((Stream) output);
    return output.ToArray();
  }

  public static byte[] CreateMaxFragmentLengthExtension(short maxFragmentLength)
  {
    return TlsUtilities.EncodeUint8(maxFragmentLength);
  }

  public static byte[] CreateOidFiltersExtension(IDictionary<DerObjectIdentifier, byte[]> filters)
  {
    MemoryStream memoryStream = new MemoryStream();
    TlsUtilities.WriteUint16(0, (Stream) memoryStream);
    if (filters != null)
    {
      foreach (KeyValuePair<DerObjectIdentifier, byte[]> filter in (IEnumerable<KeyValuePair<DerObjectIdentifier, byte[]>>) filters)
      {
        DerObjectIdentifier key = filter.Key;
        byte[] buf = filter.Value;
        if (key == null || buf == null)
          throw new TlsFatalAlert((short) 80 /*0x50*/);
        TlsUtilities.WriteOpaque8(key.GetEncoded("DER"), (Stream) memoryStream);
        TlsUtilities.WriteOpaque16(buf, (Stream) memoryStream);
      }
    }
    return TlsExtensionsUtilities.PatchOpaque16(memoryStream);
  }

  public static byte[] CreatePaddingExtension(int dataLength)
  {
    TlsUtilities.CheckUint16(dataLength);
    return new byte[dataLength];
  }

  public static byte[] CreatePostHandshakeAuthExtension()
  {
    return TlsExtensionsUtilities.CreateEmptyExtensionData();
  }

  public static byte[] CreatePreSharedKeyClientHello(OfferedPsks offeredPsks)
  {
    if (offeredPsks == null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    MemoryStream output = new MemoryStream();
    offeredPsks.Encode((Stream) output);
    return output.ToArray();
  }

  public static byte[] CreatePreSharedKeyServerHello(int selectedIdentity)
  {
    return TlsUtilities.EncodeUint16(selectedIdentity);
  }

  public static byte[] CreatePskKeyExchangeModesExtension(short[] modes)
  {
    return !TlsUtilities.IsNullOrEmpty<short>(modes) && modes.Length <= (int) byte.MaxValue ? TlsUtilities.EncodeUint8ArrayWithUint8Length(modes) : throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static byte[] CreateRecordSizeLimitExtension(int recordSizeLimit)
  {
    return recordSizeLimit >= 64 /*0x40*/ ? TlsUtilities.EncodeUint16(recordSizeLimit) : throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static byte[] CreateServerNameExtensionClient(IList<ServerName> serverNameList)
  {
    if (serverNameList == null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    MemoryStream output = new MemoryStream();
    new ServerNameList(serverNameList).Encode((Stream) output);
    return output.ToArray();
  }

  public static byte[] CreateServerNameExtensionServer()
  {
    return TlsExtensionsUtilities.CreateEmptyExtensionData();
  }

  public static byte[] CreateSignatureAlgorithmsExtension(
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithms)
  {
    MemoryStream output = new MemoryStream();
    TlsUtilities.EncodeSupportedSignatureAlgorithms(supportedSignatureAlgorithms, (Stream) output);
    return output.ToArray();
  }

  public static byte[] CreateSignatureAlgorithmsCertExtension(
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithms)
  {
    return TlsExtensionsUtilities.CreateSignatureAlgorithmsExtension(supportedSignatureAlgorithms);
  }

  public static byte[] CreateStatusRequestExtension(CertificateStatusRequest statusRequest)
  {
    if (statusRequest == null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    MemoryStream output = new MemoryStream();
    statusRequest.Encode((Stream) output);
    return output.ToArray();
  }

  public static byte[] CreateStatusRequestV2Extension(
    IList<CertificateStatusRequestItemV2> statusRequestV2)
  {
    if (statusRequestV2 == null || statusRequestV2.Count < 1)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    MemoryStream memoryStream = new MemoryStream();
    TlsUtilities.WriteUint16(0, (Stream) memoryStream);
    foreach (CertificateStatusRequestItemV2 statusRequestItemV2 in (IEnumerable<CertificateStatusRequestItemV2>) statusRequestV2)
      statusRequestItemV2.Encode((Stream) memoryStream);
    return TlsExtensionsUtilities.PatchOpaque16(memoryStream);
  }

  public static byte[] CreateSupportedGroupsExtension(IList<int> namedGroups)
  {
    int length = namedGroups != null && namedGroups.Count >= 1 ? namedGroups.Count : throw new TlsFatalAlert((short) 80 /*0x50*/);
    int[] u16s = new int[length];
    for (int index = 0; index < length; ++index)
      u16s[index] = namedGroups[index];
    return TlsUtilities.EncodeUint16ArrayWithUint16Length(u16s);
  }

  public static byte[] CreateSupportedPointFormatsExtension(short[] ecPointFormats)
  {
    if (ecPointFormats == null || !Arrays.Contains(ecPointFormats, (short) 0))
      ecPointFormats = Arrays.Prepend(ecPointFormats, (short) 0);
    return TlsUtilities.EncodeUint8ArrayWithUint8Length(ecPointFormats);
  }

  public static byte[] CreateSupportedVersionsExtensionClient(ProtocolVersion[] versions)
  {
    int num = !TlsUtilities.IsNullOrEmpty<ProtocolVersion>(versions) && versions.Length <= (int) sbyte.MaxValue ? versions.Length : throw new TlsFatalAlert((short) 80 /*0x50*/);
    byte[] buf = new byte[1 + num * 2];
    TlsUtilities.WriteUint8(num * 2, buf, 0);
    for (int index = 0; index < num; ++index)
      TlsUtilities.WriteVersion(versions[index], buf, 1 + index * 2);
    return buf;
  }

  public static byte[] CreateSupportedVersionsExtensionServer(ProtocolVersion selectedVersion)
  {
    return TlsUtilities.EncodeVersion(selectedVersion);
  }

  public static byte[] CreateTruncatedHmacExtension()
  {
    return TlsExtensionsUtilities.CreateEmptyExtensionData();
  }

  public static byte[] CreateTrustedCAKeysExtensionClient(
    IList<TrustedAuthority> trustedAuthoritiesList)
  {
    MemoryStream memoryStream = new MemoryStream();
    TlsUtilities.WriteUint16(0, (Stream) memoryStream);
    if (trustedAuthoritiesList != null)
    {
      foreach (TrustedAuthority trustedAuthorities in (IEnumerable<TrustedAuthority>) trustedAuthoritiesList)
        trustedAuthorities.Encode((Stream) memoryStream);
    }
    return TlsExtensionsUtilities.PatchOpaque16(memoryStream);
  }

  public static byte[] CreateTrustedCAKeysExtensionServer()
  {
    return TlsExtensionsUtilities.CreateEmptyExtensionData();
  }

  private static bool ReadEmptyExtensionData(byte[] extensionData)
  {
    if (extensionData == null)
      throw new ArgumentNullException(nameof (extensionData));
    if (extensionData.Length != 0)
      throw new TlsFatalAlert((short) 47);
    return true;
  }

  public static IList<ProtocolName> ReadAlpnExtensionClient(byte[] extensionData)
  {
    MemoryStream input = extensionData != null ? new MemoryStream(extensionData) : throw new ArgumentNullException(nameof (extensionData));
    if (TlsUtilities.ReadUint16((Stream) input) != extensionData.Length - 2)
      throw new TlsFatalAlert((short) 50);
    List<ProtocolName> protocolNameList = new List<ProtocolName>();
    while (input.Position < input.Length)
    {
      ProtocolName protocolName = ProtocolName.Parse((Stream) input);
      protocolNameList.Add(protocolName);
    }
    return (IList<ProtocolName>) protocolNameList;
  }

  public static ProtocolName ReadAlpnExtensionServer(byte[] extensionData)
  {
    IList<ProtocolName> protocolNameList = TlsExtensionsUtilities.ReadAlpnExtensionClient(extensionData);
    return protocolNameList.Count == 1 ? protocolNameList[0] : throw new TlsFatalAlert((short) 50);
  }

  public static IList<X509Name> ReadCertificateAuthoritiesExtension(byte[] extensionData)
  {
    if (extensionData == null)
      throw new ArgumentNullException(nameof (extensionData));
    MemoryStream input = extensionData.Length >= 5 ? new MemoryStream(extensionData) : throw new TlsFatalAlert((short) 50);
    if (TlsUtilities.ReadUint16((Stream) input) != extensionData.Length - 2)
      throw new TlsFatalAlert((short) 50);
    List<X509Name> x509NameList = new List<X509Name>();
    while (input.Position < input.Length)
    {
      byte[] encoding = TlsUtilities.ReadOpaque16((Stream) input, 1);
      X509Name instance = X509Name.GetInstance((object) TlsUtilities.ReadAsn1Object(encoding));
      TlsUtilities.RequireDerEncoding((Asn1Encodable) instance, encoding);
      x509NameList.Add(instance);
    }
    return (IList<X509Name>) x509NameList;
  }

  public static short[] ReadCertificateTypeExtensionClient(byte[] extensionData)
  {
    short[] numArray = TlsUtilities.DecodeUint8ArrayWithUint8Length(extensionData);
    return numArray.Length >= 1 ? numArray : throw new TlsFatalAlert((short) 50);
  }

  public static short ReadCertificateTypeExtensionServer(byte[] extensionData)
  {
    return TlsUtilities.DecodeUint8(extensionData);
  }

  public static bool ReadClientCertificateUrlExtension(byte[] extensionData)
  {
    return TlsExtensionsUtilities.ReadEmptyExtensionData(extensionData);
  }

  public static int[] ReadCompressCertificateExtension(byte[] extensionData)
  {
    int[] numArray = TlsUtilities.DecodeUint16ArrayWithUint8Length(extensionData);
    return numArray.Length >= 1 ? numArray : throw new TlsFatalAlert((short) 50);
  }

  public static byte[] ReadConnectionIDExtension(byte[] extensionData)
  {
    return TlsUtilities.DecodeOpaque8(extensionData);
  }

  public static byte[] ReadCookieExtension(byte[] extensionData)
  {
    return TlsUtilities.DecodeOpaque16(extensionData, 1);
  }

  public static bool ReadEarlyDataIndication(byte[] extensionData)
  {
    return TlsExtensionsUtilities.ReadEmptyExtensionData(extensionData);
  }

  public static long ReadEarlyDataMaxSize(byte[] extensionData)
  {
    return TlsUtilities.DecodeUint32(extensionData);
  }

  public static bool ReadEncryptThenMacExtension(byte[] extensionData)
  {
    return TlsExtensionsUtilities.ReadEmptyExtensionData(extensionData);
  }

  public static bool ReadExtendedMasterSecretExtension(byte[] extensionData)
  {
    return TlsExtensionsUtilities.ReadEmptyExtensionData(extensionData);
  }

  public static HeartbeatExtension ReadHeartbeatExtension(byte[] extensionData)
  {
    MemoryStream memoryStream = extensionData != null ? new MemoryStream(extensionData, false) : throw new ArgumentNullException(nameof (extensionData));
    HeartbeatExtension heartbeatExtension = HeartbeatExtension.Parse((Stream) memoryStream);
    TlsProtocol.AssertEmpty(memoryStream);
    return heartbeatExtension;
  }

  public static IList<KeyShareEntry> ReadKeyShareClientHello(byte[] extensionData)
  {
    MemoryStream input = extensionData != null ? new MemoryStream(extensionData, false) : throw new ArgumentNullException(nameof (extensionData));
    if (TlsUtilities.ReadUint16((Stream) input) != extensionData.Length - 2)
      throw new TlsFatalAlert((short) 50);
    List<KeyShareEntry> keyShareEntryList = new List<KeyShareEntry>();
    while (input.Position < input.Length)
    {
      KeyShareEntry keyShareEntry = KeyShareEntry.Parse((Stream) input);
      keyShareEntryList.Add(keyShareEntry);
    }
    return (IList<KeyShareEntry>) keyShareEntryList;
  }

  public static int ReadKeyShareHelloRetryRequest(byte[] extensionData)
  {
    return TlsUtilities.DecodeUint16(extensionData);
  }

  public static KeyShareEntry ReadKeyShareServerHello(byte[] extensionData)
  {
    MemoryStream memoryStream = extensionData != null ? new MemoryStream(extensionData, false) : throw new ArgumentNullException(nameof (extensionData));
    KeyShareEntry keyShareEntry = KeyShareEntry.Parse((Stream) memoryStream);
    TlsProtocol.AssertEmpty(memoryStream);
    return keyShareEntry;
  }

  public static short ReadMaxFragmentLengthExtension(byte[] extensionData)
  {
    return TlsUtilities.DecodeUint8(extensionData);
  }

  public static IDictionary<DerObjectIdentifier, byte[]> ReadOidFiltersExtension(
    byte[] extensionData)
  {
    if (extensionData == null)
      throw new ArgumentNullException(nameof (extensionData));
    MemoryStream input = extensionData.Length >= 2 ? new MemoryStream(extensionData, false) : throw new TlsFatalAlert((short) 50);
    if (TlsUtilities.ReadUint16((Stream) input) != extensionData.Length - 2)
      throw new TlsFatalAlert((short) 50);
    Dictionary<DerObjectIdentifier, byte[]> dictionary = new Dictionary<DerObjectIdentifier, byte[]>();
    while (input.Position < input.Length)
    {
      byte[] encoding = TlsUtilities.ReadOpaque8((Stream) input, 1);
      DerObjectIdentifier instance = DerObjectIdentifier.GetInstance((object) TlsUtilities.ReadAsn1Object(encoding));
      TlsUtilities.RequireDerEncoding((Asn1Encodable) instance, encoding);
      if (dictionary.ContainsKey(instance))
        throw new TlsFatalAlert((short) 47);
      byte[] numArray = TlsUtilities.ReadOpaque16((Stream) input);
      dictionary[instance] = numArray;
    }
    return (IDictionary<DerObjectIdentifier, byte[]>) dictionary;
  }

  public static int ReadPaddingExtension(byte[] extensionData)
  {
    if (extensionData == null)
      throw new ArgumentNullException(nameof (extensionData));
    return Arrays.AreAllZeroes(extensionData, 0, extensionData.Length) ? extensionData.Length : throw new TlsFatalAlert((short) 47);
  }

  public static bool ReadPostHandshakeAuthExtension(byte[] extensionData)
  {
    return TlsExtensionsUtilities.ReadEmptyExtensionData(extensionData);
  }

  public static OfferedPsks ReadPreSharedKeyClientHello(byte[] extensionData)
  {
    MemoryStream memoryStream = extensionData != null ? new MemoryStream(extensionData, false) : throw new ArgumentNullException(nameof (extensionData));
    OfferedPsks offeredPsks = OfferedPsks.Parse((Stream) memoryStream);
    TlsProtocol.AssertEmpty(memoryStream);
    return offeredPsks;
  }

  public static int ReadPreSharedKeyServerHello(byte[] extensionData)
  {
    return TlsUtilities.DecodeUint16(extensionData);
  }

  public static short[] ReadPskKeyExchangeModesExtension(byte[] extensionData)
  {
    short[] numArray = TlsUtilities.DecodeUint8ArrayWithUint8Length(extensionData);
    return numArray.Length >= 1 ? numArray : throw new TlsFatalAlert((short) 50);
  }

  public static int ReadRecordSizeLimitExtension(byte[] extensionData)
  {
    int num = TlsUtilities.DecodeUint16(extensionData);
    return num >= 64 /*0x40*/ ? num : throw new TlsFatalAlert((short) 47);
  }

  public static IList<ServerName> ReadServerNameExtensionClient(byte[] extensionData)
  {
    MemoryStream memoryStream = extensionData != null ? new MemoryStream(extensionData, false) : throw new ArgumentNullException(nameof (extensionData));
    ServerNameList serverNameList = ServerNameList.Parse((Stream) memoryStream);
    TlsProtocol.AssertEmpty(memoryStream);
    return serverNameList.ServerNames;
  }

  public static bool ReadServerNameExtensionServer(byte[] extensionData)
  {
    return TlsExtensionsUtilities.ReadEmptyExtensionData(extensionData);
  }

  public static IList<SignatureAndHashAlgorithm> ReadSignatureAlgorithmsExtension(
    byte[] extensionData)
  {
    MemoryStream memoryStream = extensionData != null ? new MemoryStream(extensionData, false) : throw new ArgumentNullException(nameof (extensionData));
    IList<SignatureAndHashAlgorithm> signatureAlgorithms = TlsUtilities.ParseSupportedSignatureAlgorithms((Stream) memoryStream);
    TlsProtocol.AssertEmpty(memoryStream);
    return signatureAlgorithms;
  }

  public static IList<SignatureAndHashAlgorithm> ReadSignatureAlgorithmsCertExtension(
    byte[] extensionData)
  {
    return TlsExtensionsUtilities.ReadSignatureAlgorithmsExtension(extensionData);
  }

  public static CertificateStatusRequest ReadStatusRequestExtension(byte[] extensionData)
  {
    MemoryStream memoryStream = extensionData != null ? new MemoryStream(extensionData, false) : throw new ArgumentNullException(nameof (extensionData));
    CertificateStatusRequest certificateStatusRequest = CertificateStatusRequest.Parse((Stream) memoryStream);
    TlsProtocol.AssertEmpty(memoryStream);
    return certificateStatusRequest;
  }

  public static IList<CertificateStatusRequestItemV2> ReadStatusRequestV2Extension(
    byte[] extensionData)
  {
    if (extensionData == null)
      throw new ArgumentNullException(nameof (extensionData));
    MemoryStream input = extensionData.Length >= 3 ? new MemoryStream(extensionData, false) : throw new TlsFatalAlert((short) 50);
    if (TlsUtilities.ReadUint16((Stream) input) != extensionData.Length - 2)
      throw new TlsFatalAlert((short) 50);
    List<CertificateStatusRequestItemV2> statusRequestItemV2List = new List<CertificateStatusRequestItemV2>();
    while (input.Position < input.Length)
    {
      CertificateStatusRequestItemV2 statusRequestItemV2 = CertificateStatusRequestItemV2.Parse((Stream) input);
      statusRequestItemV2List.Add(statusRequestItemV2);
    }
    return (IList<CertificateStatusRequestItemV2>) statusRequestItemV2List;
  }

  public static int[] ReadSupportedGroupsExtension(byte[] extensionData)
  {
    MemoryStream memoryStream = extensionData != null ? new MemoryStream(extensionData, false) : throw new ArgumentNullException(nameof (extensionData));
    int num = TlsUtilities.ReadUint16((Stream) memoryStream);
    int[] numArray = num >= 2 && (num & 1) == 0 ? TlsUtilities.ReadUint16Array(num / 2, (Stream) memoryStream) : throw new TlsFatalAlert((short) 50);
    TlsProtocol.AssertEmpty(memoryStream);
    return numArray;
  }

  public static short[] ReadSupportedPointFormatsExtension(byte[] extensionData)
  {
    short[] a = TlsUtilities.DecodeUint8ArrayWithUint8Length(extensionData);
    return Arrays.Contains(a, (short) 0) ? a : throw new TlsFatalAlert((short) 47);
  }

  public static ProtocolVersion[] ReadSupportedVersionsExtensionClient(byte[] extensionData)
  {
    if (extensionData == null)
      throw new ArgumentNullException(nameof (extensionData));
    int num = extensionData.Length >= 3 && extensionData.Length <= (int) byte.MaxValue && (extensionData.Length & 1) != 0 ? (int) TlsUtilities.ReadUint8(extensionData, 0) : throw new TlsFatalAlert((short) 50);
    if (num != extensionData.Length - 1)
      throw new TlsFatalAlert((short) 50);
    int length = num / 2;
    ProtocolVersion[] protocolVersionArray = new ProtocolVersion[length];
    for (int index = 0; index < length; ++index)
      protocolVersionArray[index] = TlsUtilities.ReadVersion(extensionData, 1 + index * 2);
    return protocolVersionArray;
  }

  public static ProtocolVersion ReadSupportedVersionsExtensionServer(byte[] extensionData)
  {
    if (extensionData == null)
      throw new ArgumentNullException(nameof (extensionData));
    return extensionData.Length == 2 ? TlsUtilities.ReadVersion(extensionData, 0) : throw new TlsFatalAlert((short) 50);
  }

  public static bool ReadTruncatedHmacExtension(byte[] extensionData)
  {
    return TlsExtensionsUtilities.ReadEmptyExtensionData(extensionData);
  }

  public static IList<TrustedAuthority> ReadTrustedCAKeysExtensionClient(byte[] extensionData)
  {
    if (extensionData == null)
      throw new ArgumentNullException(nameof (extensionData));
    MemoryStream input = extensionData.Length >= 2 ? new MemoryStream(extensionData, false) : throw new TlsFatalAlert((short) 50);
    if (TlsUtilities.ReadUint16((Stream) input) != extensionData.Length - 2)
      throw new TlsFatalAlert((short) 50);
    List<TrustedAuthority> trustedAuthorityList = new List<TrustedAuthority>();
    while (input.Position < input.Length)
    {
      TrustedAuthority trustedAuthority = TrustedAuthority.Parse((Stream) input);
      trustedAuthorityList.Add(trustedAuthority);
    }
    return (IList<TrustedAuthority>) trustedAuthorityList;
  }

  public static bool ReadTrustedCAKeysExtensionServer(byte[] extensionData)
  {
    return TlsExtensionsUtilities.ReadEmptyExtensionData(extensionData);
  }

  private static byte[] PatchOpaque16(MemoryStream buf)
  {
    int i = Convert.ToInt32(buf.Length) - 2;
    TlsUtilities.CheckUint16(i);
    byte[] array = buf.ToArray();
    TlsUtilities.WriteUint16(i, array, 0);
    return array;
  }
}
