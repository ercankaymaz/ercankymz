// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CertificateValidationEventArgs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class CertificateValidationEventArgs : EventArgs
{
  private readonly ServiceResult m_error;
  private readonly X509Certificate2 m_certificate;
  private bool m_accept;
  private bool m_acceptAll;
  private string m_applicationErrorMsg;

  public CertificateValidationEventArgs(ServiceResult error, X509Certificate2 certificate)
  {
    this.m_error = error;
    this.m_certificate = certificate;
  }

  public ServiceResult Error => this.m_error;

  public X509Certificate2 Certificate => this.m_certificate;

  public bool Accept
  {
    get => this.m_accept;
    set => this.m_accept = value;
  }

  public bool AcceptAll
  {
    get => this.m_acceptAll;
    set => this.m_acceptAll = value;
  }

  public string ApplicationErrorMsg
  {
    get => this.m_applicationErrorMsg;
    set => this.m_applicationErrorMsg = value;
  }
}
