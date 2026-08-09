using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Opc.Ua.Security.Certificates;

namespace Opc.Ua;

[ComVisible(true)]
public interface ICertificateStore : IDisposable
{
	string StoreType { get; }

	string StorePath { get; }

	bool SupportsLoadPrivateKey { get; }

	bool SupportsCRLs { get; }

	void Open(string location, bool noPrivateKeys = true);

	void Close();

	Task<X509Certificate2Collection> Enumerate();

	Task Add(X509Certificate2 certificate, string password = null);

	Task<bool> Delete(string thumbprint);

	Task<X509Certificate2Collection> FindByThumbprint(string thumbprint);

	Task<X509Certificate2> LoadPrivateKey(string thumbprint, string subjectName, string password);

	Task<StatusCode> IsRevoked(X509Certificate2 issuer, X509Certificate2 certificate);

	Task<X509CRLCollection> EnumerateCRLs();

	Task<X509CRLCollection> EnumerateCRLs(X509Certificate2 issuer, bool validateUpdateTime = true);

	Task AddCRL(X509CRL crl);

	Task<bool> DeleteCRL(X509CRL crl);
}
