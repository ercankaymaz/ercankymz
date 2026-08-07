// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerProperties
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class ServerProperties
{
  private string m_productUri;
  private string m_productName;
  private string m_manufacturerName;
  private string m_softwareVersion;
  private string m_buildNumber;
  private DateTime m_buildDate;
  private StringCollection m_datatypeAssemblies;
  private SignedSoftwareCertificateCollection m_softwareCertificates;

  public ServerProperties()
  {
    this.m_productUri = string.Empty;
    this.m_manufacturerName = string.Empty;
    this.m_productName = string.Empty;
    this.m_softwareVersion = string.Empty;
    this.m_buildNumber = string.Empty;
    this.m_buildDate = DateTime.MinValue;
    this.m_datatypeAssemblies = new StringCollection();
    this.m_softwareCertificates = new SignedSoftwareCertificateCollection();
  }

  public string ProductUri
  {
    get => this.m_productUri;
    set => this.m_productUri = value;
  }

  public string ProductName
  {
    get => this.m_productName;
    set => this.m_productName = value;
  }

  public string ManufacturerName
  {
    get => this.m_manufacturerName;
    set => this.m_manufacturerName = value;
  }

  public string SoftwareVersion
  {
    get => this.m_softwareVersion;
    set => this.m_softwareVersion = value;
  }

  public string BuildNumber
  {
    get => this.m_buildNumber;
    set => this.m_buildNumber = value;
  }

  public DateTime BuildDate
  {
    get => this.m_buildDate;
    set => this.m_buildDate = value;
  }

  public StringCollection DatatypeAssemblies => this.m_datatypeAssemblies;

  public SignedSoftwareCertificateCollection SoftwareCertificates => this.m_softwareCertificates;
}
