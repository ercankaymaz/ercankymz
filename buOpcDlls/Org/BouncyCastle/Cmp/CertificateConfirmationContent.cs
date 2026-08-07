// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cmp.CertificateConfirmationContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Cms;

#nullable disable
namespace Org.BouncyCastle.Cmp;

public class CertificateConfirmationContent
{
  private readonly DefaultDigestAlgorithmIdentifierFinder m_digestAlgFinder;
  private readonly CertConfirmContent m_content;

  public CertificateConfirmationContent(CertConfirmContent content) => this.m_content = content;

  public CertificateConfirmationContent(
    CertConfirmContent content,
    DefaultDigestAlgorithmIdentifierFinder digestAlgFinder)
  {
    this.m_content = content;
    this.m_digestAlgFinder = digestAlgFinder;
  }

  public CertConfirmContent ToAsn1Structure() => this.m_content;

  public CertificateStatus[] GetStatusMessages()
  {
    CertStatus[] certStatusArray = this.m_content.ToCertStatusArray();
    CertificateStatus[] statusMessages = new CertificateStatus[certStatusArray.Length];
    for (int index = 0; index != statusMessages.Length; ++index)
      statusMessages[index] = new CertificateStatus(this.m_digestAlgFinder, certStatusArray[index]);
    return statusMessages;
  }
}
