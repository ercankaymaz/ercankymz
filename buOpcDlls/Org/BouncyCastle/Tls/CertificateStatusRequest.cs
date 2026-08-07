// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.CertificateStatusRequest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class CertificateStatusRequest
{
  private short m_statusType;
  private object m_request;

  public CertificateStatusRequest(short statusType, object request)
  {
    this.m_statusType = CertificateStatusRequest.IsCorrectType(statusType, request) ? statusType : throw new ArgumentException("not an instance of the correct type", nameof (request));
    this.m_request = request;
  }

  public short StatusType => this.m_statusType;

  public object Request => this.m_request;

  public OcspStatusRequest OcspStatusRequest
  {
    get
    {
      return CertificateStatusRequest.IsCorrectType((short) 1, this.m_request) ? (OcspStatusRequest) this.m_request : throw new InvalidOperationException("'request' is not an OCSPStatusRequest");
    }
  }

  public void Encode(Stream output)
  {
    TlsUtilities.WriteUint8(this.m_statusType, output);
    if (this.m_statusType != (short) 1)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    ((OcspStatusRequest) this.m_request).Encode(output);
  }

  public static CertificateStatusRequest Parse(Stream input)
  {
    int statusType = (int) TlsUtilities.ReadUint8(input);
    return statusType == 1 ? new CertificateStatusRequest((short) statusType, (object) OcspStatusRequest.Parse(input)) : throw new TlsFatalAlert((short) 50);
  }

  private static bool IsCorrectType(short statusType, object request)
  {
    if (statusType != (short) 1)
      throw new ArgumentException("unsupported CertificateStatusType", nameof (statusType));
    return request is OcspStatusRequest;
  }
}
