using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

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
		get
		{
			return extensionDataField;
		}
		set
		{
			extensionDataField = value;
		}
	}

	[DataMember]
	public string ApplicationName
	{
		get
		{
			return ApplicationNameField;
		}
		set
		{
			ApplicationNameField = value;
		}
	}

	[DataMember]
	public string ApplicationUri
	{
		get
		{
			return ApplicationUriField;
		}
		set
		{
			ApplicationUriField = value;
		}
	}

	[DataMember(Order = 2)]
	public ApplicationType ApplicationType
	{
		get
		{
			return ApplicationTypeField;
		}
		set
		{
			ApplicationTypeField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string ProductName
	{
		get
		{
			return ProductNameField;
		}
		set
		{
			ProductNameField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string ConfigurationMode
	{
		get
		{
			return ConfigurationModeField;
		}
		set
		{
			ConfigurationModeField = value;
		}
	}

	[DataMember(Order = 5)]
	public DateTime LastExportTime
	{
		get
		{
			return LastExportTimeField;
		}
		set
		{
			LastExportTimeField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 6)]
	public string ConfigurationFile
	{
		get
		{
			return ConfigurationFileField;
		}
		set
		{
			ConfigurationFileField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 7)]
	public string ExecutableFile
	{
		get
		{
			return ExecutableFileField;
		}
		set
		{
			ExecutableFileField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 8)]
	public CertificateIdentifier ApplicationCertificate
	{
		get
		{
			return ApplicationCertificateField;
		}
		set
		{
			ApplicationCertificateField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 9)]
	public CertificateStoreIdentifier TrustedCertificateStore
	{
		get
		{
			return TrustedCertificateStoreField;
		}
		set
		{
			TrustedCertificateStoreField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 10)]
	public CertificateList TrustedCertificates
	{
		get
		{
			return TrustedCertificatesField;
		}
		set
		{
			TrustedCertificatesField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 11)]
	public CertificateStoreIdentifier IssuerCertificateStore
	{
		get
		{
			return IssuerCertificateStoreField;
		}
		set
		{
			IssuerCertificateStoreField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 12)]
	public CertificateList IssuerCertificates
	{
		get
		{
			return IssuerCertificatesField;
		}
		set
		{
			IssuerCertificatesField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 13)]
	public CertificateStoreIdentifier RejectedCertificatesStore
	{
		get
		{
			return RejectedCertificatesStoreField;
		}
		set
		{
			RejectedCertificatesStoreField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 14)]
	public ListOfBaseAddresses BaseAddresses
	{
		get
		{
			return BaseAddressesField;
		}
		set
		{
			BaseAddressesField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 15)]
	public ListOfSecurityProfiles SecurityProfiles
	{
		get
		{
			return SecurityProfilesField;
		}
		set
		{
			SecurityProfilesField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 16)]
	public ListOfExtensions Extensions
	{
		get
		{
			return ExtensionsField;
		}
		set
		{
			ExtensionsField = value;
		}
	}

	[Obsolete("Replaced by ApplicationName")]
	public string Name
	{
		get
		{
			return ApplicationName;
		}
		set
		{
			ApplicationName = value;
		}
	}

	[Obsolete("Replaced by ApplicationUri")]
	public string Uri
	{
		get
		{
			return ApplicationUri;
		}
		set
		{
			ApplicationUri = value;
		}
	}

	[Obsolete("Replaced by TrustedCertificateStore")]
	public CertificateStoreIdentifier TrustedPeerStore
	{
		get
		{
			return TrustedCertificateStore;
		}
		set
		{
			TrustedCertificateStore = value;
		}
	}

	[Obsolete("Replaced by TrustedCertificates")]
	public CertificateList TrustedPeerCertificates
	{
		get
		{
			return TrustedCertificates;
		}
		set
		{
			TrustedCertificates = value;
		}
	}

	[Obsolete("Replaced by TrustedIssuerStore")]
	public CertificateStoreIdentifier TrustedIssuerStore
	{
		get
		{
			return IssuerCertificateStore;
		}
		set
		{
			IssuerCertificateStore = value;
		}
	}

	[Obsolete("Replaced by IssuerCertificates")]
	public CertificateList TrustedIssuerCertificates
	{
		get
		{
			return IssuerCertificates;
		}
		set
		{
			IssuerCertificates = value;
		}
	}

	public static Opc.Ua.ApplicationType FromApplicationType(ApplicationType input)
	{
		return (Opc.Ua.ApplicationType)input;
	}

	public static ApplicationType ToApplicationType(Opc.Ua.ApplicationType input)
	{
		return (ApplicationType)input;
	}

	public static CertificateIdentifier ToCertificateIdentifier(Opc.Ua.CertificateIdentifier input)
	{
		if (input != null && !string.IsNullOrEmpty(input.StoreType) && !string.IsNullOrEmpty(input.StorePath))
		{
			return new CertificateIdentifier
			{
				StoreType = input.StoreType,
				StorePath = input.StorePath,
				SubjectName = input.SubjectName,
				Thumbprint = input.Thumbprint,
				ValidationOptions = (int)input.ValidationOptions,
				OfflineRevocationList = null,
				OnlineRevocationList = null
			};
		}
		return null;
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
			certificateIdentifier.ValidationOptions = (CertificateValidationOptions)input.ValidationOptions;
		}
		return certificateIdentifier;
	}

	public static CertificateStoreIdentifier ToCertificateStoreIdentifier(Opc.Ua.CertificateStoreIdentifier input)
	{
		if (input != null && !string.IsNullOrEmpty(input.StoreType) && !string.IsNullOrEmpty(input.StorePath))
		{
			return new CertificateStoreIdentifier
			{
				StoreType = input.StoreType,
				StorePath = input.StorePath,
				ValidationOptions = (int)input.ValidationOptions
			};
		}
		return null;
	}

	public static CertificateTrustList FromCertificateStoreIdentifierToTrustList(CertificateStoreIdentifier input)
	{
		CertificateTrustList certificateTrustList = new CertificateTrustList();
		if (input != null)
		{
			certificateTrustList.StoreType = input.StoreType;
			certificateTrustList.StorePath = input.StorePath;
			certificateTrustList.ValidationOptions = (CertificateValidationOptions)input.ValidationOptions;
		}
		return certificateTrustList;
	}

	public static Opc.Ua.CertificateStoreIdentifier FromCertificateStoreIdentifier(CertificateStoreIdentifier input)
	{
		Opc.Ua.CertificateStoreIdentifier certificateStoreIdentifier = new Opc.Ua.CertificateStoreIdentifier();
		if (input != null)
		{
			certificateStoreIdentifier.StoreType = input.StoreType;
			certificateStoreIdentifier.StorePath = input.StorePath;
			certificateStoreIdentifier.ValidationOptions = (CertificateValidationOptions)input.ValidationOptions;
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
			certificateTrustList.ValidationOptions = (CertificateValidationOptions)input.ValidationOptions;
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
			for (int i = 0; i < input.Count; i++)
			{
				certificateList.Certificates.Add(ToCertificateIdentifier(input[i]));
			}
		}
		return certificateList;
	}

	public static CertificateIdentifierCollection FromCertificateList(CertificateList input)
	{
		CertificateIdentifierCollection certificateIdentifierCollection = new CertificateIdentifierCollection();
		if (input != null && input.Certificates != null)
		{
			for (int i = 0; i < input.Certificates.Count; i++)
			{
				certificateIdentifierCollection.Add(FromCertificateIdentifier(input.Certificates[i]));
			}
		}
		return certificateIdentifierCollection;
	}

	public static ListOfBaseAddresses ToListOfBaseAddresses(ServerBaseConfiguration configuration)
	{
		ListOfBaseAddresses listOfBaseAddresses = new ListOfBaseAddresses();
		if (configuration != null)
		{
			if (configuration.BaseAddresses != null)
			{
				for (int i = 0; i < configuration.BaseAddresses.Count; i++)
				{
					listOfBaseAddresses.Add(configuration.BaseAddresses[i]);
				}
			}
			if (configuration.AlternateBaseAddresses != null)
			{
				for (int j = 0; j < configuration.AlternateBaseAddresses.Count; j++)
				{
					listOfBaseAddresses.Add(configuration.AlternateBaseAddresses[j]);
				}
			}
		}
		return listOfBaseAddresses;
	}

	public static void FromListOfBaseAddresses(ServerBaseConfiguration configuration, ListOfBaseAddresses addresses)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (addresses == null || configuration == null)
		{
			return;
		}
		configuration.BaseAddresses = new StringCollection();
		configuration.AlternateBaseAddresses = null;
		for (int i = 0; i < addresses.Count; i++)
		{
			Uri uri = Utils.ParseUri(addresses[i]);
			if (!(uri != null))
			{
				continue;
			}
			if (dictionary.ContainsKey(uri.Scheme))
			{
				if (configuration.AlternateBaseAddresses == null)
				{
					configuration.AlternateBaseAddresses = new StringCollection();
				}
				configuration.AlternateBaseAddresses.Add(uri.ToString());
			}
			else
			{
				configuration.BaseAddresses.Add(uri.ToString());
				dictionary.Add(uri.Scheme, string.Empty);
			}
		}
	}

	public static ListOfSecurityProfiles ToListOfSecurityProfiles(ServerSecurityPolicyCollection policies)
	{
		ListOfSecurityProfiles listOfSecurityProfiles = new ListOfSecurityProfiles();
		listOfSecurityProfiles.Add(CreateProfile("http://opcfoundation.org/UA/SecurityPolicy#None"));
		listOfSecurityProfiles.Add(CreateProfile("http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15"));
		listOfSecurityProfiles.Add(CreateProfile("http://opcfoundation.org/UA/SecurityPolicy#Basic256"));
		listOfSecurityProfiles.Add(CreateProfile("http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256"));
		listOfSecurityProfiles.Add(CreateProfile("http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep"));
		listOfSecurityProfiles.Add(CreateProfile("http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss"));
		if (policies != null)
		{
			for (int i = 0; i < policies.Count; i++)
			{
				for (int j = 0; j < listOfSecurityProfiles.Count; j++)
				{
					if (policies[i].SecurityPolicyUri == listOfSecurityProfiles[j].ProfileUri)
					{
						listOfSecurityProfiles[j].Enabled = true;
					}
				}
			}
		}
		return listOfSecurityProfiles;
	}

	public static ServerSecurityPolicyCollection FromListOfSecurityProfiles(ListOfSecurityProfiles profiles)
	{
		ServerSecurityPolicyCollection serverSecurityPolicyCollection = new ServerSecurityPolicyCollection();
		if (profiles != null)
		{
			for (int i = 0; i < profiles.Count; i++)
			{
				if (profiles[i].Enabled)
				{
					serverSecurityPolicyCollection.Add(CreatePolicy(profiles[i].ProfileUri));
				}
			}
		}
		if (serverSecurityPolicyCollection.Count == 0)
		{
			serverSecurityPolicyCollection.Add(CreatePolicy("http://opcfoundation.org/UA/SecurityPolicy#None"));
		}
		return serverSecurityPolicyCollection;
	}

	private static ServerSecurityPolicy CreatePolicy(string profileUri)
	{
		ServerSecurityPolicy serverSecurityPolicy = new ServerSecurityPolicy();
		serverSecurityPolicy.SecurityPolicyUri = profileUri;
		switch (profileUri)
		{
		case "http://opcfoundation.org/UA/SecurityPolicy#None":
			serverSecurityPolicy.SecurityMode = MessageSecurityMode.None;
			break;
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
			serverSecurityPolicy.SecurityMode = MessageSecurityMode.SignAndEncrypt;
			break;
		}
		return serverSecurityPolicy;
	}

	private static SecurityProfile CreateProfile(string profileUri)
	{
		return new SecurityProfile
		{
			ProfileUri = profileUri,
			Enabled = false
		};
	}
}
