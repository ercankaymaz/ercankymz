// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.CertificateStatus
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class CertificateStatus
{
  private readonly short m_statusType;
  private readonly object m_response;

  public CertificateStatus(short statusType, object response)
  {
    this.m_statusType = CertificateStatus.IsCorrectType(statusType, response) ? statusType : throw new ArgumentException("not an instance of the correct type", nameof (response));
    this.m_response = response;
  }

  public short StatusType => this.m_statusType;

  public object Response => this.m_response;

  public OcspResponse OcspResponse
  {
    get
    {
      return CertificateStatus.IsCorrectType((short) 1, this.m_response) ? (OcspResponse) this.m_response : throw new InvalidOperationException("'response' is not an OCSPResponse");
    }
  }

  public IList<OcspResponse> OcspResponseList
  {
    get
    {
      return CertificateStatus.IsCorrectType((short) 2, this.m_response) ? (IList<OcspResponse>) this.m_response : throw new InvalidOperationException("'response' is not an OCSPResponseList");
    }
  }

  public void Encode(Stream output)
  {
    TlsUtilities.WriteUint8(this.m_statusType, output);
    switch (this.m_statusType)
    {
      case 1:
        TlsUtilities.WriteOpaque24(((Asn1Encodable) this.m_response).GetEncoded("DER"), output);
        break;
      case 2:
        IList<OcspResponse> response = (IList<OcspResponse>) this.m_response;
        List<byte[]> numArrayList = new List<byte[]>(response.Count);
        long i = 0;
        foreach (OcspResponse ocspResponse in (IEnumerable<OcspResponse>) response)
        {
          if (ocspResponse == null)
          {
            numArrayList.Add(TlsUtilities.EmptyBytes);
          }
          else
          {
            byte[] encoded = ocspResponse.GetEncoded("DER");
            numArrayList.Add(encoded);
            i += (long) encoded.Length;
          }
          i += 3L;
        }
        TlsUtilities.CheckUint24(i);
        TlsUtilities.WriteUint24((int) i, output);
        using (List<byte[]>.Enumerator enumerator = numArrayList.GetEnumerator())
        {
          while (enumerator.MoveNext())
            TlsUtilities.WriteOpaque24(enumerator.Current, output);
          break;
        }
      default:
        throw new TlsFatalAlert((short) 80 /*0x50*/);
    }
  }

  public static CertificateStatus Parse(TlsContext context, Stream input)
  {
    SecurityParameters securityParameters = context.SecurityParameters;
    Certificate peerCertificate = securityParameters.PeerCertificate;
    if (peerCertificate == null || peerCertificate.IsEmpty || peerCertificate.CertificateType != (short) 0)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    int length1 = peerCertificate.Length;
    int statusRequestVersion = securityParameters.StatusRequestVersion;
    short statusType = TlsUtilities.ReadUint8(input);
    object response;
    switch (statusType)
    {
      case 1:
        CertificateStatus.RequireStatusRequestVersion(1, statusRequestVersion);
        response = (object) CertificateStatus.ParseOcspResponse(TlsUtilities.ReadOpaque24(input, 1));
        break;
      case 2:
        CertificateStatus.RequireStatusRequestVersion(2, statusRequestVersion);
        MemoryStream input1 = new MemoryStream(TlsUtilities.ReadOpaque24(input, 1), false);
        List<OcspResponse> ocspResponseList = new List<OcspResponse>();
        while (input1.Position < input1.Length)
        {
          if (ocspResponseList.Count >= length1)
            throw new TlsFatalAlert((short) 47);
          int length2 = TlsUtilities.ReadUint24((Stream) input1);
          if (length2 < 1)
          {
            ocspResponseList.Add((OcspResponse) null);
          }
          else
          {
            byte[] derEncoding = TlsUtilities.ReadFully(length2, (Stream) input1);
            ocspResponseList.Add(CertificateStatus.ParseOcspResponse(derEncoding));
          }
        }
        response = (object) ocspResponseList;
        break;
      default:
        throw new TlsFatalAlert((short) 50);
    }
    return new CertificateStatus(statusType, response);
  }

  private static bool IsCorrectType(short statusType, object response)
  {
    if (statusType == (short) 1)
      return response is OcspResponse;
    if (statusType != (short) 2)
      throw new ArgumentException("unsupported CertificateStatusType", nameof (statusType));
    return CertificateStatus.IsOcspResponseList(response);
  }

  private static bool IsOcspResponseList(object response)
  {
    return response is IList<OcspResponse> ocspResponseList && ocspResponseList.Count > 0;
  }

  private static OcspResponse ParseOcspResponse(byte[] derEncoding)
  {
    OcspResponse instance = OcspResponse.GetInstance((object) TlsUtilities.ReadAsn1Object(derEncoding));
    TlsUtilities.RequireDerEncoding((Asn1Encodable) instance, derEncoding);
    return instance;
  }

  private static void RequireStatusRequestVersion(int minVersion, int statusRequestVersion)
  {
    if (statusRequestVersion < minVersion)
      throw new TlsFatalAlert((short) 50);
  }
}
