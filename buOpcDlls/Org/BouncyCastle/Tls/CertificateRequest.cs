// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.CertificateRequest
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

public sealed class CertificateRequest
{
  private readonly byte[] m_certificateRequestContext;
  private readonly short[] m_certificateTypes;
  private readonly IList<SignatureAndHashAlgorithm> m_supportedSignatureAlgorithms;
  private readonly IList<SignatureAndHashAlgorithm> m_supportedSignatureAlgorithmsCert;
  private readonly IList<X509Name> m_certificateAuthorities;

  private static IList<SignatureAndHashAlgorithm> CheckSupportedSignatureAlgorithms(
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithms,
    short alertDescription)
  {
    return supportedSignatureAlgorithms != null ? supportedSignatureAlgorithms : throw new TlsFatalAlert(alertDescription, "'signature_algorithms' is required");
  }

  public CertificateRequest(
    short[] certificateTypes,
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithms,
    IList<X509Name> certificateAuthorities)
    : this((byte[]) null, certificateTypes, supportedSignatureAlgorithms, (IList<SignatureAndHashAlgorithm>) null, certificateAuthorities)
  {
  }

  public CertificateRequest(
    byte[] certificateRequestContext,
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithms,
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithmsCert,
    IList<X509Name> certificateAuthorities)
    : this(certificateRequestContext, (short[]) null, CertificateRequest.CheckSupportedSignatureAlgorithms(supportedSignatureAlgorithms, (short) 80 /*0x50*/), supportedSignatureAlgorithmsCert, certificateAuthorities)
  {
  }

  private CertificateRequest(
    byte[] certificateRequestContext,
    short[] certificateTypes,
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithms,
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithmsCert,
    IList<X509Name> certificateAuthorities)
  {
    if (certificateRequestContext != null && !TlsUtilities.IsValidUint8(certificateRequestContext.Length))
      throw new ArgumentException("cannot be longer than 255", nameof (certificateRequestContext));
    if (certificateTypes != null && (certificateTypes.Length < 1 || !TlsUtilities.IsValidUint8(certificateTypes.Length)))
      throw new ArgumentException("should have length from 1 to 255", nameof (certificateTypes));
    this.m_certificateRequestContext = TlsUtilities.Clone(certificateRequestContext);
    this.m_certificateTypes = certificateTypes;
    this.m_supportedSignatureAlgorithms = supportedSignatureAlgorithms;
    this.m_supportedSignatureAlgorithmsCert = supportedSignatureAlgorithmsCert;
    this.m_certificateAuthorities = certificateAuthorities;
  }

  public byte[] GetCertificateRequestContext()
  {
    return TlsUtilities.Clone(this.m_certificateRequestContext);
  }

  public short[] CertificateTypes => this.m_certificateTypes;

  public IList<SignatureAndHashAlgorithm> SupportedSignatureAlgorithms
  {
    get => this.m_supportedSignatureAlgorithms;
  }

  public IList<SignatureAndHashAlgorithm> SupportedSignatureAlgorithmsCert
  {
    get => this.m_supportedSignatureAlgorithmsCert;
  }

  public IList<X509Name> CertificateAuthorities => this.m_certificateAuthorities;

  public bool HasCertificateRequestContext(byte[] certificateRequestContext)
  {
    return Arrays.AreEqual(this.m_certificateRequestContext, certificateRequestContext);
  }

  public void Encode(TlsContext context, Stream output)
  {
    ProtocolVersion serverVersion = context.ServerVersion;
    bool flag1 = TlsUtilities.IsTlsV12(serverVersion);
    bool flag2;
    if ((flag2 = TlsUtilities.IsTlsV13(serverVersion)) != (this.m_certificateRequestContext != null) || flag2 != (this.m_certificateTypes == null) || flag1 != (this.m_supportedSignatureAlgorithms != null) || !flag2 && this.m_supportedSignatureAlgorithmsCert != null)
      throw new InvalidOperationException();
    if (flag2)
    {
      TlsUtilities.WriteOpaque8(this.m_certificateRequestContext, output);
      Dictionary<int, byte[]> extensions = new Dictionary<int, byte[]>();
      TlsExtensionsUtilities.AddSignatureAlgorithmsExtension((IDictionary<int, byte[]>) extensions, this.m_supportedSignatureAlgorithms);
      if (this.m_supportedSignatureAlgorithmsCert != null)
        TlsExtensionsUtilities.AddSignatureAlgorithmsCertExtension((IDictionary<int, byte[]>) extensions, this.m_supportedSignatureAlgorithmsCert);
      if (this.m_certificateAuthorities != null)
        TlsExtensionsUtilities.AddCertificateAuthoritiesExtension((IDictionary<int, byte[]>) extensions, this.m_certificateAuthorities);
      TlsUtilities.WriteOpaque16(TlsProtocol.WriteExtensionsData((IDictionary<int, byte[]>) extensions), output);
    }
    else
    {
      TlsUtilities.WriteUint8ArrayWithUint8Length(this.m_certificateTypes, output);
      if (flag1)
        TlsUtilities.EncodeSupportedSignatureAlgorithms(this.m_supportedSignatureAlgorithms, output);
      if (this.m_certificateAuthorities != null && this.m_certificateAuthorities.Count >= 1)
      {
        List<byte[]> numArrayList = new List<byte[]>(this.m_certificateAuthorities.Count);
        int i = 0;
        foreach (Asn1Encodable certificateAuthority in (IEnumerable<X509Name>) this.m_certificateAuthorities)
        {
          byte[] encoded = certificateAuthority.GetEncoded("DER");
          numArrayList.Add(encoded);
          i += encoded.Length + 2;
        }
        TlsUtilities.CheckUint16(i);
        TlsUtilities.WriteUint16(i, output);
        foreach (byte[] buf in numArrayList)
          TlsUtilities.WriteOpaque16(buf, output);
      }
      else
        TlsUtilities.WriteUint16(0, output);
    }
  }

  public static CertificateRequest Parse(TlsContext context, Stream input)
  {
    ProtocolVersion serverVersion = context.ServerVersion;
    if (TlsUtilities.IsTlsV13(serverVersion))
    {
      byte[] certificateRequestContext = TlsUtilities.ReadOpaque8(input);
      IDictionary<int, byte[]> extensions = TlsProtocol.ReadExtensionsData13(13, TlsUtilities.ReadOpaque16(input));
      IList<SignatureAndHashAlgorithm> andHashAlgorithmList = CertificateRequest.CheckSupportedSignatureAlgorithms(TlsExtensionsUtilities.GetSignatureAlgorithmsExtension(extensions), (short) 109);
      IList<SignatureAndHashAlgorithm> algorithmsCertExtension = TlsExtensionsUtilities.GetSignatureAlgorithmsCertExtension(extensions);
      IList<X509Name> authoritiesExtension = TlsExtensionsUtilities.GetCertificateAuthoritiesExtension(extensions);
      IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithms = andHashAlgorithmList;
      IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithmsCert = algorithmsCertExtension;
      IList<X509Name> certificateAuthorities = authoritiesExtension;
      return new CertificateRequest(certificateRequestContext, supportedSignatureAlgorithms, supportedSignatureAlgorithmsCert, certificateAuthorities);
    }
    int num = TlsUtilities.IsTlsV12(serverVersion) ? 1 : 0;
    short[] certificateTypes = TlsUtilities.ReadUint8ArrayWithUint8Length(input, 1);
    IList<SignatureAndHashAlgorithm> supportedSignatureAlgorithms1 = (IList<SignatureAndHashAlgorithm>) null;
    if (num != 0)
      supportedSignatureAlgorithms1 = TlsUtilities.ParseSupportedSignatureAlgorithms(input);
    IList<X509Name> certificateAuthorities1 = (IList<X509Name>) null;
    byte[] buffer = TlsUtilities.ReadOpaque16(input);
    if (buffer.Length != 0)
    {
      certificateAuthorities1 = (IList<X509Name>) new List<X509Name>();
      MemoryStream input1 = new MemoryStream(buffer, false);
      do
      {
        byte[] encoding = TlsUtilities.ReadOpaque16((Stream) input1, 1);
        X509Name instance = X509Name.GetInstance((object) TlsUtilities.ReadAsn1Object(encoding));
        TlsUtilities.RequireDerEncoding((Asn1Encodable) instance, encoding);
        certificateAuthorities1.Add(instance);
      }
      while (input1.Position < input1.Length);
    }
    return new CertificateRequest(certificateTypes, supportedSignatureAlgorithms1, certificateAuthorities1);
  }
}
