using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class CertificateTrustList : CertificateStoreIdentifier
{
	private CertificateIdentifierCollection m_trustedCertificates;

	private object m_lock = new object();

	private ICertificateStore m_store;

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 3)]
	public CertificateIdentifierCollection TrustedCertificates
	{
		get
		{
			return m_trustedCertificates;
		}
		set
		{
			m_trustedCertificates = value;
			if (m_trustedCertificates == null)
			{
				m_trustedCertificates = new CertificateIdentifierCollection();
			}
		}
	}

	public CertificateTrustList()
	{
		Initialize();
	}

	private void Initialize()
	{
		m_lock = new object();
		m_trustedCertificates = new CertificateIdentifierCollection();
	}

	[OnDeserializing]
	public void Initialize(StreamingContext context)
	{
		Initialize();
	}

	public override ICertificateStore OpenStore()
	{
		lock (m_lock)
		{
			if (m_store == null || m_store.StoreType != base.StoreType || m_store.StorePath != base.StorePath)
			{
				m_store = CertificateStoreIdentifier.CreateStore(base.StoreType);
			}
			m_store.Open(base.StorePath);
			return m_store;
		}
	}

	public async Task<X509Certificate2Collection> GetCertificates()
	{
		X509Certificate2Collection collection = new X509Certificate2Collection();
		if (!string.IsNullOrEmpty(base.StorePath))
		{
			ICertificateStore store = null;
			try
			{
				store = OpenStore();
				collection = await store.Enumerate().ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception)
			{
				Utils.LogError("Could not load certificates from store: {0}.", base.StorePath);
			}
			finally
			{
				store?.Close();
			}
		}
		foreach (CertificateIdentifier trustedCertificate in TrustedCertificates)
		{
			X509Certificate2 x509Certificate = await trustedCertificate.Find().ConfigureAwait(continueOnCapturedContext: false);
			if (x509Certificate != null)
			{
				collection.Add(x509Certificate);
			}
		}
		return collection;
	}
}
