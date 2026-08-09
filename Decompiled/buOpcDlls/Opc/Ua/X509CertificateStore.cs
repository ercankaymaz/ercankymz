using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua.Security.Certificates;

namespace Opc.Ua;

[ComVisible(true)]
public class X509CertificateStore : ICertificateStore, IDisposable
{
	private bool m_noPrivateKeys;

	private string m_storeName;

	private string m_storePath;

	private StoreLocation m_storeLocation;

	public string StoreType => "X509Store";

	public string StorePath => m_storePath;

	public bool SupportsLoadPrivateKey => false;

	public bool SupportsCRLs => false;

	public X509CertificateStore()
	{
		m_storeName = "My";
		m_storeLocation = StoreLocation.CurrentUser;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			Close();
		}
	}

	public void Open(string location, bool noPrivateKeys = true)
	{
		if (location == null)
		{
			throw new ArgumentNullException("location");
		}
		m_storePath = location;
		m_noPrivateKeys = noPrivateKeys;
		location = location.Trim();
		if (string.IsNullOrEmpty(location))
		{
			throw ServiceResultException.Create(2147549184u, "Store Location cannot be empty.");
		}
		int num = location.IndexOf('\\');
		if (num == -1)
		{
			throw ServiceResultException.Create(2147549184u, "Path does not specify a store name. Path={0}", location);
		}
		string text = location.Substring(0, num);
		bool flag = false;
		StoreLocation[] array = (StoreLocation[])Enum.GetValues(typeof(StoreLocation));
		for (int i = 0; i < array.Length; i++)
		{
			StoreLocation storeLocation = array[i];
			if (storeLocation.ToString().Equals(text, StringComparison.OrdinalIgnoreCase))
			{
				m_storeLocation = storeLocation;
				flag = true;
			}
		}
		if (!flag)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Store location specified not available.");
			stringBuilder.AppendLine("Store location={0}");
			throw ServiceResultException.Create(2147549184u, stringBuilder.ToString(), text);
		}
		m_storeName = location.Substring(num + 1);
	}

	public void Close()
	{
	}

	public Task<X509Certificate2Collection> Enumerate()
	{
		using X509Store x509Store = new X509Store(m_storeName, m_storeLocation);
		x509Store.Open(OpenFlags.ReadOnly);
		return Task.FromResult(new X509Certificate2Collection(x509Store.Certificates));
	}

	public Task Add(X509Certificate2 certificate, string password = null)
	{
		if (certificate == null)
		{
			throw new ArgumentNullException("certificate");
		}
		using (X509Store x509Store = new X509Store(m_storeName, m_storeLocation))
		{
			x509Store.Open(OpenFlags.ReadWrite);
			if (!x509Store.Certificates.Contains(certificate))
			{
				if (certificate.HasPrivateKey && !m_noPrivateKeys && Environment.OSVersion.Platform == PlatformID.Win32NT)
				{
					string password2 = X509Utils.GeneratePasscode();
					using X509Certificate2 certificate2 = new X509Certificate2(certificate.Export(X509ContentType.Pfx, password2), password2, X509KeyStorageFlags.PersistKeySet);
					x509Store.Add(certificate2);
				}
				else if (certificate.HasPrivateKey && m_noPrivateKeys)
				{
					x509Store.Add(new X509Certificate2(certificate.RawData));
				}
				else
				{
					x509Store.Add(certificate);
				}
				Utils.LogCertificate("Added certificate to X509Store {0}.", certificate, x509Store.Name);
			}
		}
		return Task.CompletedTask;
	}

	public Task<bool> Delete(string thumbprint)
	{
		using (X509Store x509Store = new X509Store(m_storeName, m_storeLocation))
		{
			x509Store.Open(OpenFlags.ReadWrite);
			X509Certificate2Enumerator enumerator = x509Store.Certificates.GetEnumerator();
			while (enumerator.MoveNext())
			{
				X509Certificate2 current = enumerator.Current;
				if (current.Thumbprint == thumbprint)
				{
					x509Store.Remove(current);
				}
			}
		}
		return Task.FromResult(result: true);
	}

	public Task<X509Certificate2Collection> FindByThumbprint(string thumbprint)
	{
		using X509Store x509Store = new X509Store(m_storeName, m_storeLocation);
		x509Store.Open(OpenFlags.ReadOnly);
		X509Certificate2Collection x509Certificate2Collection = new X509Certificate2Collection();
		X509Certificate2Enumerator enumerator = x509Store.Certificates.GetEnumerator();
		while (enumerator.MoveNext())
		{
			X509Certificate2 current = enumerator.Current;
			if (current.Thumbprint == thumbprint)
			{
				x509Certificate2Collection.Add(current);
			}
		}
		return Task.FromResult(x509Certificate2Collection);
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
		throw new ServiceResultException(2151481344u);
	}

	public Task<X509CRLCollection> EnumerateCRLs(X509Certificate2 issuer, bool validateUpdateTime = true)
	{
		throw new ServiceResultException(2151481344u);
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
