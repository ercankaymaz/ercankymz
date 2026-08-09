using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Opc.Ua.Security.Certificates;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfCertificateIdentifier", Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd", ItemName = "CertificateIdentifier")]
[ComVisible(true)]
public class CertificateIdentifierCollection : List<CertificateIdentifier>, ICertificateStore, IDisposable, ICloneable
{
	public string StoreType => string.Empty;

	public string StorePath => string.Empty;

	public bool SupportsLoadPrivateKey => false;

	public bool SupportsCRLs => false;

	public CertificateIdentifierCollection()
	{
	}

	public CertificateIdentifierCollection(IEnumerable<CertificateIdentifier> collection)
		: base(collection)
	{
	}

	public CertificateIdentifierCollection(int capacity)
		: base(capacity)
	{
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		CertificateIdentifierCollection certificateIdentifierCollection = new CertificateIdentifierCollection();
		for (int i = 0; i < base.Count; i++)
		{
			certificateIdentifierCollection.Add((CertificateIdentifier)Utils.Clone(base[i]));
		}
		return certificateIdentifierCollection;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public void Open(string location, bool noPrivateKeys)
	{
	}

	public void Close()
	{
	}

	public async Task<X509Certificate2Collection> Enumerate()
	{
		X509Certificate2Collection collection = new X509Certificate2Collection();
		for (int ii = 0; ii < base.Count; ii++)
		{
			X509Certificate2 x509Certificate = await base[ii].Find(needPrivateKey: false).ConfigureAwait(continueOnCapturedContext: false);
			if (x509Certificate != null)
			{
				collection.Add(x509Certificate);
			}
		}
		return collection;
	}

	public async Task Add(X509Certificate2 certificate, string password = null)
	{
		if (certificate == null)
		{
			throw new ArgumentNullException("certificate");
		}
		for (int ii = 0; ii < base.Count; ii++)
		{
			X509Certificate2 x509Certificate = await base[ii].Find(needPrivateKey: false).ConfigureAwait(continueOnCapturedContext: false);
			if (x509Certificate != null && x509Certificate.Thumbprint == certificate.Thumbprint)
			{
				throw ServiceResultException.Create(2157903872u, "A certificate with the specified thumbprint already exists. Subject={0}, Thumbprint={1}", certificate.SubjectName, certificate.Thumbprint);
			}
		}
		Add(new CertificateIdentifier(certificate));
	}

	public async Task<bool> Delete(string thumbprint)
	{
		if (string.IsNullOrEmpty(thumbprint))
		{
			return false;
		}
		for (int ii = 0; ii < base.Count; ii++)
		{
			X509Certificate2 x509Certificate = await base[ii].Find(needPrivateKey: false).ConfigureAwait(continueOnCapturedContext: false);
			if (x509Certificate != null && x509Certificate.Thumbprint == thumbprint)
			{
				RemoveAt(ii);
				return true;
			}
		}
		return false;
	}

	public async Task<X509Certificate2Collection> FindByThumbprint(string thumbprint)
	{
		if (string.IsNullOrEmpty(thumbprint))
		{
			return null;
		}
		for (int ii = 0; ii < base.Count; ii++)
		{
			X509Certificate2 x509Certificate = await base[ii].Find(needPrivateKey: false).ConfigureAwait(continueOnCapturedContext: false);
			if (x509Certificate != null && x509Certificate.Thumbprint == thumbprint)
			{
				return new X509Certificate2Collection { x509Certificate };
			}
		}
		return new X509Certificate2Collection();
	}

	public Task<X509Certificate2> LoadPrivateKey(string thumbprint, string subjectName, string password)
	{
		return Task.FromResult<X509Certificate2>(null);
	}

	public Task<StatusCode> IsRevoked(X509Certificate2 issuer, X509Certificate2 certificate)
	{
		return Task.FromResult((StatusCode)2151481344u);
	}

	public Task<X509CRLCollection> EnumerateCRLs()
	{
		return Task.FromResult(new X509CRLCollection());
	}

	public Task<X509CRLCollection> EnumerateCRLs(X509Certificate2 issuer, bool validateUpdateTime = true)
	{
		return Task.FromResult(new X509CRLCollection());
	}

	public Task AddCRL(X509CRL crl)
	{
		throw new ServiceResultException(2151481344u);
	}

	public Task<bool> DeleteCRL(X509CRL crl)
	{
		throw new ServiceResultException(2151481344u);
	}
}
