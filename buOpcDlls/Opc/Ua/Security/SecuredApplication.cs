// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.SecuredApplication
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua.Security;

[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "SecuredApplication", Namespace = "http://opcfoundation.org/UA/2011/03/SecuredApplication.xsd")]
[ComVisible(true)]
public class SecuredApplication : IExtensibleDataObject
{
  private ExtensionDataObject extensionDataField;
  private string ApplicationNameField;
  private string ApplicationUriField;
  private ApplicationType ApplicationTypeField;
  private string ProductNameField;
  private string ConfigurationModeField;
  private DateTime LastExportTimeField;
  private string ConfigurationFileField;
  private string ExecutableFileField;
  private CertificateIdentifier ApplicationCertificateField;
  private CertificateStoreIdentifier TrustedCertificateStoreField;
  private CertificateList TrustedCertificatesField;
  private CertificateStoreIdentifier IssuerCertificateStoreField;
  private CertificateList IssuerCertificatesField;
  private CertificateStoreIdentifier RejectedCertificatesStoreField;
  private ListOfBaseAddresses BaseAddressesField;
  private ListOfSecurityProfiles SecurityProfilesField;
  private ListOfExtensions ExtensionsField;

  public ExtensionDataObject ExtensionData
  {
    get => this.extensionDataField;
    set => this.extensionDataField = value;
  }

  [DataMember]
  public string ApplicationName
  {
    get => this.ApplicationNameField;
    set => this.ApplicationNameField = value;
  }

  [DataMember]
  public string ApplicationUri
  {
    get => this.ApplicationUriField;
    set => this.ApplicationUriField = value;
  }

  [DataMember(Order = 2)]
  public ApplicationType ApplicationType
  {
    get => this.ApplicationTypeField;
    set => this.ApplicationTypeField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 3)]
  public string ProductName
  {
    get => this.ProductNameField;
    set => this.ProductNameField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 4)]
  public string ConfigurationMode
  {
    get => this.ConfigurationModeField;
    set => this.ConfigurationModeField = value;
  }

  [DataMember(Order = 5)]
  public DateTime LastExportTime
  {
    get => this.LastExportTimeField;
    set => this.LastExportTimeField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 6)]
  public string ConfigurationFile
  {
    get => this.ConfigurationFileField;
    set => this.ConfigurationFileField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 7)]
  public string ExecutableFile
  {
    get => this.ExecutableFileField;
    set => this.ExecutableFileField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 8)]
  public CertificateIdentifier ApplicationCertificate
  {
    get => this.ApplicationCertificateField;
    set => this.ApplicationCertificateField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 9)]
  public CertificateStoreIdentifier TrustedCertificateStore
  {
    get => this.TrustedCertificateStoreField;
    set => this.TrustedCertificateStoreField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 10)]
  public CertificateList TrustedCertificates
  {
    get => this.TrustedCertificatesField;
    set => this.TrustedCertificatesField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 11)]
  public CertificateStoreIdentifier IssuerCertificateStore
  {
    get => this.IssuerCertificateStoreField;
    set => this.IssuerCertificateStoreField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 12)]
  public CertificateList IssuerCertificates
  {
    get => this.IssuerCertificatesField;
    set => this.IssuerCertificatesField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 13)]
  public CertificateStoreIdentifier RejectedCertificatesStore
  {
    get => this.RejectedCertificatesStoreField;
    set => this.RejectedCertificatesStoreField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 14)]
  public ListOfBaseAddresses BaseAddresses
  {
    get => this.BaseAddressesField;
    set => this.BaseAddressesField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 15)]
  public ListOfSecurityProfiles SecurityProfiles
  {
    get => this.SecurityProfilesField;
    set => this.SecurityProfilesField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 16 /*0x10*/)]
  public ListOfExtensions Extensions
  {
    get => this.ExtensionsField;
    set => this.ExtensionsField = value;
  }

  [Obsolete("Replaced by ApplicationName")]
  public string Name
  {
    get => this.ApplicationName;
    set => this.ApplicationName = value;
  }

  [Obsolete("Replaced by ApplicationUri")]
  public string Uri
  {
    get => this.ApplicationUri;
    set => this.ApplicationUri = value;
  }

  [Obsolete("Replaced by TrustedCertificateStore")]
  public CertificateStoreIdentifier TrustedPeerStore
  {
    get => this.TrustedCertificateStore;
    set => this.TrustedCertificateStore = value;
  }

  [Obsolete("Replaced by TrustedCertificates")]
  public CertificateList TrustedPeerCertificates
  {
    get => this.TrustedCertificates;
    set => this.TrustedCertificates = value;
  }

  [Obsolete("Replaced by TrustedIssuerStore")]
  public CertificateStoreIdentifier TrustedIssuerStore
  {
    get => this.IssuerCertificateStore;
    set => this.IssuerCertificateStore = value;
  }

  [Obsolete("Replaced by IssuerCertificates")]
  public CertificateList TrustedIssuerCertificates
  {
    get => this.IssuerCertificates;
    set => this.IssuerCertificates = value;
  }

  public static Opc.Ua.ApplicationType FromApplicationType(ApplicationType input)
  {
    return (Opc.Ua.ApplicationType) input;
  }

  public static ApplicationType ToApplicationType(Opc.Ua.ApplicationType input)
  {
    return (ApplicationType) input;
  }

  public static CertificateIdentifier ToCertificateIdentifier(Opc.Ua.CertificateIdentifier input)
  {
    if (input == null || string.IsNullOrEmpty(input.StoreType) || string.IsNullOrEmpty(input.StorePath))
      return (CertificateIdentifier) null;
    return new CertificateIdentifier()
    {
      StoreType = input.StoreType,
      StorePath = input.StorePath,
      SubjectName = input.SubjectName,
      Thumbprint = input.Thumbprint,
      ValidationOptions = (int) input.ValidationOptions,
      OfflineRevocationList = (byte[]) null,
      OnlineRevocationList = (string) null
    };
  }

  public static Opc.Ua.CertificateIdentifier FromCertificateIdentifier(CertificateIdentifier input)
  {
    Opc.Ua.CertificateIdentifier certificateIdentifier = new Opc.Ua.CertificateIdentifier();
    if (input != null)
    {
      certificateIdentifier.StoreType = input.StoreType;
      certificateIdentifier.StorePath = input.StorePath;
      certificateIdentifier.SubjectName = input.SubjectName;
      certificateIdentifier.Thumbprint = input.Thumbprint;
      certificateIdentifier.ValidationOptions = (CertificateValidationOptions) input.ValidationOptions;
    }
    return certificateIdentifier;
  }

  public static CertificateStoreIdentifier ToCertificateStoreIdentifier(
    Opc.Ua.CertificateStoreIdentifier input)
  {
    if (input == null || string.IsNullOrEmpty(input.StoreType) || string.IsNullOrEmpty(input.StorePath))
      return (CertificateStoreIdentifier) null;
    return new CertificateStoreIdentifier()
    {
      StoreType = input.StoreType,
      StorePath = input.StorePath,
      ValidationOptions = (int) input.ValidationOptions
    };
  }

  public static CertificateTrustList FromCertificateStoreIdentifierToTrustList(
    CertificateStoreIdentifier input)
  {
    CertificateTrustList trustList = new CertificateTrustList();
    if (input != null)
    {
      trustList.StoreType = input.StoreType;
      trustList.StorePath = input.StorePath;
      trustList.ValidationOptions = (CertificateValidationOptions) input.ValidationOptions;
    }
    return trustList;
  }

  public static Opc.Ua.CertificateStoreIdentifier FromCertificateStoreIdentifier(
    CertificateStoreIdentifier input)
  {
    Opc.Ua.CertificateStoreIdentifier certificateStoreIdentifier = new Opc.Ua.CertificateStoreIdentifier();
    if (input != null)
    {
      certificateStoreIdentifier.StoreType = input.StoreType;
      certificateStoreIdentifier.StorePath = input.StorePath;
      certificateStoreIdentifier.ValidationOptions = (CertificateValidationOptions) input.ValidationOptions;
    }
    return certificateStoreIdentifier;
  }

  public static CertificateTrustList ToCertificateTrustList(CertificateStoreIdentifier input)
  {
    CertificateTrustList certificateTrustList = new CertificateTrustList();
    if (input != null)
    {
      certificateTrustList.StoreType = input.StoreType;
      certificateTrustList.StorePath = input.StorePath;
      certificateTrustList.ValidationOptions = (CertificateValidationOptions) input.ValidationOptions;
    }
    return certificateTrustList;
  }

  public static CertificateList ToCertificateList(CertificateIdentifierCollection input)
  {
    CertificateList certificateList = new CertificateList();
    if (input != null)
    {
      certificateList.ValidationOptions = 0;
      certificateList.Certificates = new ListOfCertificateIdentifier();
      for (int index = 0; index < input.Count; ++index)
        certificateList.Certificates.Add(SecuredApplication.ToCertificateIdentifier(input[index]));
    }
    return certificateList;
  }

  public static CertificateIdentifierCollection FromCertificateList(CertificateList input)
  {
    CertificateIdentifierCollection identifierCollection = new CertificateIdentifierCollection();
    if (input != null && input.Certificates != null)
    {
      for (int index = 0; index < input.Certificates.Count; ++index)
        identifierCollection.Add(SecuredApplication.FromCertificateIdentifier(input.Certificates[index]));
    }
    return identifierCollection;
  }

  public static ListOfBaseAddresses ToListOfBaseAddresses(ServerBaseConfiguration configuration)
  {
    ListOfBaseAddresses listOfBaseAddresses = new ListOfBaseAddresses();
    if (configuration != null)
    {
      if (configuration.BaseAddresses != null)
      {
        for (int index = 0; index < configuration.BaseAddresses.Count; ++index)
          listOfBaseAddresses.Add(configuration.BaseAddresses[index]);
      }
      if (configuration.AlternateBaseAddresses != null)
      {
        for (int index = 0; index < configuration.AlternateBaseAddresses.Count; ++index)
          listOfBaseAddresses.Add(configuration.AlternateBaseAddresses[index]);
      }
    }
    return listOfBaseAddresses;
  }

  public static void FromListOfBaseAddresses(
    ServerBaseConfiguration configuration,
    ListOfBaseAddresses addresses)
  {
    Dictionary<string, string> dictionary = new Dictionary<string, string>();
    if (addresses == null || configuration == null)
      return;
    configuration.BaseAddresses = new StringCollection();
    configuration.AlternateBaseAddresses = (StringCollection) null;
    for (int index = 0; index < addresses.Count; ++index)
    {
      System.Uri uri = Utils.ParseUri(addresses[index]);
      if (uri != (System.Uri) null)
      {
        if (dictionary.ContainsKey(uri.Scheme))
        {
          if (configuration.AlternateBaseAddresses == null)
            configuration.AlternateBaseAddresses = new StringCollection();
          configuration.AlternateBaseAddresses.Add(uri.ToString());
        }
        else
        {
          configuration.BaseAddresses.Add(uri.ToString());
          dictionary.Add(uri.Scheme, string.Empty);
        }
      }
    }
  }

  public static ListOfSecurityProfiles ToListOfSecurityProfiles(
    ServerSecurityPolicyCollection policies)
  {
    ListOfSecurityProfiles securityProfiles = new ListOfSecurityProfiles();
    securityProfiles.Add(SecuredApplication.CreateProfile("http://opcfoundation.org/UA/SecurityPolicy#None"));
    securityProfiles.Add(SecuredApplication.CreateProfile("http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15"));
    securityProfiles.Add(SecuredApplication.CreateProfile("http://opcfoundation.org/UA/SecurityPolicy#Basic256"));
    securityProfiles.Add(SecuredApplication.CreateProfile("http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256"));
    securityProfiles.Add(SecuredApplication.CreateProfile("http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep"));
    securityProfiles.Add(SecuredApplication.CreateProfile("http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss"));
    if (policies != null)
    {
      for (int index1 = 0; index1 < policies.Count; ++index1)
      {
        for (int index2 = 0; index2 < securityProfiles.Count; ++index2)
        {
          if (policies[index1].SecurityPolicyUri == securityProfiles[index2].ProfileUri)
            securityProfiles[index2].Enabled = true;
        }
      }
    }
    return securityProfiles;
  }

  public static ServerSecurityPolicyCollection FromListOfSecurityProfiles(
    ListOfSecurityProfiles profiles)
  {
    ServerSecurityPolicyCollection policyCollection = new ServerSecurityPolicyCollection();
    if (profiles != null)
    {
      for (int index = 0; index < profiles.Count; ++index)
      {
        if (profiles[index].Enabled)
          policyCollection.Add(SecuredApplication.CreatePolicy(profiles[index].ProfileUri));
      }
    }
    if (policyCollection.Count == 0)
      policyCollection.Add(SecuredApplication.CreatePolicy("http://opcfoundation.org/UA/SecurityPolicy#None"));
    return policyCollection;
  }

  private static ServerSecurityPolicy CreatePolicy(string profileUri)
  {
    ServerSecurityPolicy policy = new ServerSecurityPolicy();
    policy.SecurityPolicyUri = profileUri;
    switch (profileUri)
    {
      case "http://opcfoundation.org/UA/SecurityPolicy#None":
        policy.SecurityMode = MessageSecurityMode.None;
        break;
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
        policy.SecurityMode = MessageSecurityMode.SignAndEncrypt;
        break;
    }
    return policy;
  }

  private static SecurityProfile CreateProfile(string profileUri)
  {
    return new SecurityProfile()
    {
      ProfileUri = profileUri,
      Enabled = false
    };
  }
}
