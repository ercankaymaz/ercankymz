using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class SecurityConfiguration
{
	private CertificateIdentifier m_applicationCertificate;

	private CertificateTrustList m_trustedIssuerCertificates;

	private CertificateTrustList m_trustedPeerCertificates;

	private CertificateTrustList m_httpsIssuerCertificates;

	private CertificateTrustList m_trustedHttpsCertificates;

	private CertificateTrustList m_userIssuerCertificates;

	private CertificateTrustList m_trustedUserCertificates;

	private int m_nonceLength;

	private CertificateStoreIdentifier m_rejectedCertificateStore;

	private bool m_autoAcceptUntrustedCertificates;

	private string m_userRoleDirectory;

	private bool m_rejectSHA1SignedCertificates;

	private bool m_rejectUnknownRevocationStatus;

	private ushort m_minCertificateKeySize;

	private bool m_useValidatedCertificates;

	private bool m_addAppCertToTrustedStore;

	private bool m_sendCertificateChain;

	private bool m_suppressNonceValidationErrors;

	[DataMember(IsRequired = true, EmitDefaultValue = false, Order = 0)]
	public CertificateIdentifier ApplicationCertificate
	{
		get
		{
			return m_applicationCertificate;
		}
		set
		{
			m_applicationCertificate = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 2)]
	public CertificateTrustList TrustedIssuerCertificates
	{
		get
		{
			return m_trustedIssuerCertificates;
		}
		set
		{
			m_trustedIssuerCertificates = value ?? new CertificateTrustList();
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 4)]
	public CertificateTrustList TrustedPeerCertificates
	{
		get
		{
			return m_trustedPeerCertificates;
		}
		set
		{
			m_trustedPeerCertificates = value ?? new CertificateTrustList();
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 6)]
	public int NonceLength
	{
		get
		{
			return m_nonceLength;
		}
		set
		{
			m_nonceLength = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 7)]
	public CertificateStoreIdentifier RejectedCertificateStore
	{
		get
		{
			return m_rejectedCertificateStore;
		}
		set
		{
			m_rejectedCertificateStore = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 8)]
	public bool AutoAcceptUntrustedCertificates
	{
		get
		{
			return m_autoAcceptUntrustedCertificates;
		}
		set
		{
			m_autoAcceptUntrustedCertificates = value;
		}
	}

	[DataMember(Order = 9)]
	public string UserRoleDirectory
	{
		get
		{
			return m_userRoleDirectory;
		}
		set
		{
			m_userRoleDirectory = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 10)]
	public bool RejectSHA1SignedCertificates
	{
		get
		{
			return m_rejectSHA1SignedCertificates;
		}
		set
		{
			m_rejectSHA1SignedCertificates = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 11)]
	public bool RejectUnknownRevocationStatus
	{
		get
		{
			return m_rejectUnknownRevocationStatus;
		}
		set
		{
			m_rejectUnknownRevocationStatus = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 12)]
	public ushort MinimumCertificateKeySize
	{
		get
		{
			return m_minCertificateKeySize;
		}
		set
		{
			m_minCertificateKeySize = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 13)]
	public bool UseValidatedCertificates
	{
		get
		{
			return m_useValidatedCertificates;
		}
		set
		{
			m_useValidatedCertificates = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 14)]
	public bool AddAppCertToTrustedStore
	{
		get
		{
			return m_addAppCertToTrustedStore;
		}
		set
		{
			m_addAppCertToTrustedStore = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 15)]
	public bool SendCertificateChain
	{
		get
		{
			return m_sendCertificateChain;
		}
		set
		{
			m_sendCertificateChain = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 16)]
	public CertificateTrustList UserIssuerCertificates
	{
		get
		{
			return m_userIssuerCertificates;
		}
		set
		{
			m_userIssuerCertificates = value;
			if (m_userIssuerCertificates == null)
			{
				m_userIssuerCertificates = new CertificateTrustList();
			}
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 17)]
	public CertificateTrustList TrustedUserCertificates
	{
		get
		{
			return m_trustedUserCertificates;
		}
		set
		{
			m_trustedUserCertificates = value;
			if (m_trustedUserCertificates == null)
			{
				m_trustedUserCertificates = new CertificateTrustList();
			}
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 18)]
	public CertificateTrustList HttpsIssuerCertificates
	{
		get
		{
			return m_httpsIssuerCertificates;
		}
		set
		{
			m_httpsIssuerCertificates = value;
			if (m_httpsIssuerCertificates == null)
			{
				m_httpsIssuerCertificates = new CertificateTrustList();
			}
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 19)]
	public CertificateTrustList TrustedHttpsCertificates
	{
		get
		{
			return m_trustedHttpsCertificates;
		}
		set
		{
			m_trustedHttpsCertificates = value;
			if (m_trustedHttpsCertificates == null)
			{
				m_trustedHttpsCertificates = new CertificateTrustList();
			}
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 20)]
	public bool SuppressNonceValidationErrors
	{
		get
		{
			return m_suppressNonceValidationErrors;
		}
		set
		{
			m_suppressNonceValidationErrors = value;
		}
	}

	public ICertificatePasswordProvider CertificatePasswordProvider { get; set; }

	public SecurityConfiguration()
	{
		Initialize();
	}

	private void Initialize()
	{
		m_trustedIssuerCertificates = new CertificateTrustList();
		m_trustedPeerCertificates = new CertificateTrustList();
		m_nonceLength = 32;
		m_autoAcceptUntrustedCertificates = false;
		m_rejectSHA1SignedCertificates = true;
		m_rejectUnknownRevocationStatus = false;
		m_minCertificateKeySize = CertificateFactory.DefaultKeySize;
		m_addAppCertToTrustedStore = true;
		m_sendCertificateChain = true;
		m_suppressNonceValidationErrors = false;
	}

	[OnDeserializing]
	public void Initialize(StreamingContext context)
	{
		Initialize();
	}

	public void AddTrustedPeer(byte[] certificate)
	{
		TrustedPeerCertificates.TrustedCertificates.Add(new CertificateIdentifier(certificate));
	}

	public void Validate()
	{
		if (m_applicationCertificate == null)
		{
			throw ServiceResultException.Create(2156462080u, "ApplicationCertificate must be specified.");
		}
		TrustedIssuerCertificates = CreateDefaultTrustList(TrustedIssuerCertificates);
		TrustedPeerCertificates = CreateDefaultTrustList(TrustedPeerCertificates);
		if (RejectedCertificateStore == null)
		{
			RejectedCertificateStore = new CertificateStoreIdentifier();
			RejectedCertificateStore.StoreType = "Directory";
			RejectedCertificateStore.StorePath = Utils.DefaultLocalFolder + Path.DirectorySeparatorChar + "Rejected";
		}
		ApplicationCertificate.SubjectName = Utils.ReplaceDCLocalhost(ApplicationCertificate.SubjectName);
	}

	private CertificateTrustList CreateDefaultTrustList(CertificateTrustList trustList)
	{
		if (trustList != null && trustList.StorePath != null)
		{
			return trustList;
		}
		return new CertificateTrustList();
	}
}
