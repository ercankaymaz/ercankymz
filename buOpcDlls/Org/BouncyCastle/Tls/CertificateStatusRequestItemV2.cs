// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.CertificateStatusRequestItemV2
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class CertificateStatusRequestItemV2
{
  private readonly short m_statusType;
  private readonly object m_request;

  public CertificateStatusRequestItemV2(short statusType, object request)
  {
    this.m_statusType = CertificateStatusRequestItemV2.IsCorrectType(statusType, request) ? statusType : throw new ArgumentException("not an instance of the correct type", nameof (request));
    this.m_request = request;
  }

  public short StatusType => this.m_statusType;

  public object Request => this.m_request;

  public OcspStatusRequest OcspStatusRequest
  {
    get
    {
      return this.m_request is OcspStatusRequest ? (OcspStatusRequest) this.m_request : throw new InvalidOperationException("'request' is not an OcspStatusRequest");
    }
  }

  public void Encode(Stream output)
  {
    TlsUtilities.WriteUint8(this.m_statusType, output);
    MemoryStream output1 = new MemoryStream();
    switch (this.m_statusType)
    {
      case 1:
      case 2:
        ((OcspStatusRequest) this.m_request).Encode((Stream) output1);
        TlsUtilities.WriteOpaque16(output1.ToArray(), output);
        break;
      default:
        throw new TlsFatalAlert((short) 80 /*0x50*/);
    }
  }

  public static CertificateStatusRequestItemV2 Parse(Stream input)
  {
    short statusType = TlsUtilities.ReadUint8(input);
    MemoryStream memoryStream = new MemoryStream(TlsUtilities.ReadOpaque16(input), false);
    switch (statusType)
    {
      case 1:
      case 2:
        object request = (object) OcspStatusRequest.Parse((Stream) memoryStream);
        TlsProtocol.AssertEmpty(memoryStream);
        return new CertificateStatusRequestItemV2(statusType, request);
      default:
        throw new TlsFatalAlert((short) 50);
    }
  }

  private static bool IsCorrectType(short statusType, object request)
  {
    switch (statusType)
    {
      case 1:
      case 2:
        return request is OcspStatusRequest;
      default:
        throw new ArgumentException("unsupported CertificateStatusType", nameof (statusType));
    }
  }
}
