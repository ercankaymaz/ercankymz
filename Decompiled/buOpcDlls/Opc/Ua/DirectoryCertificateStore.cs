using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua.Security.Certificates;

namespace Opc.Ua;

[ComVisible(true)]
public class DirectoryCertificateStore : ICertificateStore, IDisposable
{
	private class Entry
	{
		public FileInfo CertificateFile;

		public X509Certificate2 Certificate;

		public FileInfo PrivateKeyFile;

		public X509Certificate2 CertificateWithPrivateKey;
	}

	private const string kCertsPath = "certs";

	private const string kPrivateKeyPath = "private";

	private const string kCrlPath = "crl";

	private const string kCertExtension = ".der";

	private const string kCrlExtension = ".crl";

	private const string kPemExtension = ".pem";

	private const string kPfxExtension = ".pfx";

	private readonly object m_lock = new object();

	private bool m_noSubDirs;

	private DirectoryInfo m_directory;

	private DirectoryInfo m_certificateSubdir;

	private DirectoryInfo m_crlSubdir;

	private DirectoryInfo m_privateKeySubdir;

	private Dictionary<string, Entry> m_certificates;

	private DateTime m_lastDirectoryCheck;

	public DirectoryInfo Directory => m_directory;

	public string StoreType => "Directory";

	public string StorePath { get; private set; }

	public bool SupportsLoadPrivateKey => true;

	public bool SupportsCRLs => true;

	private bool NoPrivateKeys { get; set; }

	public DirectoryCertificateStore()
		: this(noSubDirs: false)
	{
	}

	public DirectoryCertificateStore(bool noSubDirs)
	{
		m_noSubDirs = noSubDirs;
		m_certificates = new Dictionary<string, Entry>();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			lock (m_lock)
			{
				m_certificates.Clear();
				m_directory = null;
				m_certificateSubdir = null;
				m_privateKeySubdir = null;
				m_crlSubdir = null;
				m_lastDirectoryCheck = DateTime.MinValue;
			}
		}
		Close();
	}

	public void Open(string location, bool noPrivateKeys = false)
	{
		lock (m_lock)
		{
			string text = Utils.ReplaceSpecialFolderNames(location);
			DirectoryInfo directory = m_directory;
			if (directory == null || !directory.FullName.Equals(text, StringComparison.Ordinal) || NoPrivateKeys != noPrivateKeys)
			{
				NoPrivateKeys = noPrivateKeys;
				StorePath = location;
				m_directory = new DirectoryInfo(text);
				if (m_noSubDirs)
				{
					m_certificateSubdir = m_directory;
					m_crlSubdir = m_directory;
					m_privateKeySubdir = ((!noPrivateKeys) ? m_directory : null);
				}
				else
				{
					m_certificateSubdir = new DirectoryInfo(Path.Combine(m_directory.FullName, "certs"));
					m_crlSubdir = new DirectoryInfo(Path.Combine(m_directory.FullName, "crl"));
					m_privateKeySubdir = ((!noPrivateKeys) ? new DirectoryInfo(Path.Combine(m_directory.FullName, "private")) : null);
				}
				m_certificates.Clear();
				m_lastDirectoryCheck = DateTime.MinValue;
			}
		}
	}

	public void Close()
	{
	}

	public Task<X509Certificate2Collection> Enumerate()
	{
		lock (m_lock)
		{
			IDictionary<string, Entry> dictionary = Load(null);
			X509Certificate2Collection x509Certificate2Collection = new X509Certificate2Collection();
			foreach (Entry value in dictionary.Values)
			{
				if (value.CertificateWithPrivateKey != null)
				{
					x509Certificate2Collection.Add(value.CertificateWithPrivateKey);
				}
				else if (value.Certificate != null)
				{
					x509Certificate2Collection.Add(value.Certificate);
				}
			}
			return Task.FromResult(x509Certificate2Collection);
		}
	}

	public Task Add(X509Certificate2 certificate, string password = null)
	{
		if (certificate == null)
		{
			throw new ArgumentNullException("certificate");
		}
		lock (m_lock)
		{
			byte[] array = null;
			if (Find(certificate.Thumbprint) != null)
			{
				throw new ArgumentException("A certificate with the same thumbprint is already in the store.");
			}
			bool flag = !NoPrivateKeys && certificate.HasPrivateKey;
			if (flag)
			{
				string password2 = password ?? string.Empty;
				array = certificate.Export(X509ContentType.Pfx, password2);
			}
			else
			{
				array = certificate.RawData;
			}
			string fileName = GetFileName(certificate);
			WriteFile(array, fileName, flag);
			if (flag)
			{
				WriteFile(certificate.RawData, fileName, includePrivateKey: false);
			}
			m_lastDirectoryCheck = DateTime.MinValue;
		}
		return Task.CompletedTask;
	}

	public async Task<bool> Delete(string thumbprint)
	{
		int retry = 5;
		bool found = false;
		do
		{
			lock (m_lock)
			{
				Entry entry = Find(thumbprint);
				try
				{
					if (entry != null)
					{
						if (entry.PrivateKeyFile != null && entry.PrivateKeyFile.Exists)
						{
							entry.PrivateKeyFile.Delete();
							found = true;
						}
						if (entry.CertificateFile != null && entry.CertificateFile.Exists)
						{
							entry.CertificateFile.Delete();
							found = true;
						}
					}
					retry = 0;
				}
				catch (IOException)
				{
					Utils.LogWarning("Failed to delete cert [{0}], retry.", thumbprint);
					retry--;
				}
				if (found)
				{
					m_lastDirectoryCheck = DateTime.MinValue;
				}
			}
			if (retry > 0)
			{
				await Task.Delay(100).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		while (retry > 0);
		return found;
	}

	public Task<X509Certificate2Collection> FindByThumbprint(string thumbprint)
	{
		X509Certificate2Collection x509Certificate2Collection = new X509Certificate2Collection();
		lock (m_lock)
		{
			Entry entry = Find(thumbprint);
			if (entry != null)
			{
				if (entry.CertificateWithPrivateKey != null)
				{
					x509Certificate2Collection.Add(entry.CertificateWithPrivateKey);
				}
				else
				{
					x509Certificate2Collection.Add(entry.Certificate);
				}
			}
			return Task.FromResult(x509Certificate2Collection);
		}
	}

	public string GetPublicKeyFilePath(string thumbprint)
	{
		Entry entry = Find(thumbprint);
		if (entry == null)
		{
			return null;
		}
		if (entry.CertificateFile == null || !entry.CertificateFile.Exists)
		{
			return null;
		}
		return entry.CertificateFile.FullName;
	}

	public string GetPrivateKeyFilePath(string thumbprint)
	{
		Entry entry = Find(thumbprint);
		if (entry == null)
		{
			return null;
		}
		if (entry.PrivateKeyFile == null || !entry.PrivateKeyFile.Exists)
		{
			return null;
		}
		return entry.PrivateKeyFile.FullName;
	}

	public async Task<X509Certificate2> LoadPrivateKey(string thumbprint, string subjectName, string password)
	{
		if (NoPrivateKeys || m_privateKeySubdir == null || m_certificateSubdir == null || !m_certificateSubdir.Exists)
		{
			return null;
		}
		if (string.IsNullOrEmpty(thumbprint) && string.IsNullOrEmpty(subjectName))
		{
			return null;
		}
		int retryCounter = 3;
		while (retryCounter-- > 0)
		{
			bool flag = false;
			Exception ex = null;
			FileInfo[] files = m_certificateSubdir.GetFiles("*.der");
			foreach (FileInfo fileInfo in files)
			{
				try
				{
					X509Certificate2 x509Certificate = new X509Certificate2(fileInfo.FullName);
					if ((!string.IsNullOrEmpty(thumbprint) && !string.Equals(x509Certificate.Thumbprint, thumbprint, StringComparison.OrdinalIgnoreCase)) || (!string.IsNullOrEmpty(subjectName) && !X509Utils.CompareDistinguishedName(subjectName, x509Certificate.Subject) && (subjectName.Contains('=') || !X509Utils.ParseDistinguishedName(x509Certificate.Subject).Any((string s) => s.Equals("CN=" + subjectName, StringComparison.Ordinal)))) || X509Utils.GetRSAPublicKeySize(x509Certificate) < 0)
					{
						continue;
					}
					string value = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length);
					StringBuilder stringBuilder = new StringBuilder().Append(m_privateKeySubdir.FullName).Append(Path.DirectorySeparatorChar).Append(value);
					X509KeyStorageFlags[] array = new X509KeyStorageFlags[2]
					{
						X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable,
						X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.Exportable
					};
					FileInfo fileInfo2 = new FileInfo(stringBuilder?.ToString() + ".pfx");
					FileInfo fileInfo3 = new FileInfo(stringBuilder?.ToString() + ".pem");
					password = password ?? string.Empty;
					if (fileInfo2.Exists)
					{
						flag = true;
						X509KeyStorageFlags[] array2 = array;
						foreach (X509KeyStorageFlags keyStorageFlags in array2)
						{
							try
							{
								x509Certificate = new X509Certificate2(fileInfo2.FullName, password, keyStorageFlags);
								if (X509Utils.VerifyRSAKeyPair(x509Certificate, x509Certificate, throwOnError: true))
								{
									Utils.LogInfo(512, "Imported the PFX private key for [{0}].", x509Certificate.Thumbprint);
									return x509Certificate;
								}
							}
							catch (Exception ex2)
							{
								ex = ex2;
								x509Certificate?.Dispose();
							}
						}
					}
					else if (fileInfo3.Exists)
					{
						flag = true;
						try
						{
							byte[] pemDataBlob = File.ReadAllBytes(fileInfo3.FullName);
							x509Certificate = CertificateFactory.CreateCertificateWithPEMPrivateKey(x509Certificate, pemDataBlob, password);
							if (X509Utils.VerifyRSAKeyPair(x509Certificate, x509Certificate, throwOnError: true))
							{
								Utils.LogInfo(512, "Imported the PEM private key for [{0}].", x509Certificate.Thumbprint);
								return x509Certificate;
							}
						}
						catch (Exception ex3)
						{
							x509Certificate?.Dispose();
							ex = ex3;
						}
					}
					else
					{
						Utils.LogError(512, "A private key for the certificate with thumbprint [{0}] does not exist.", x509Certificate.Thumbprint);
					}
				}
				catch (Exception exception)
				{
					Utils.LogError(exception, "Could not load private key for certificate {0}", subjectName);
				}
			}
			if (flag)
			{
				Utils.LogError(512, "The private key for the certificate with subject {0} failed to import.", subjectName);
				if (ex != null)
				{
					Utils.LogError(ex, "Certificate import failed.");
				}
				if (retryCounter > 0)
				{
					Utils.LogInfo(512, "Retry to import private key after {0} ms.", 100);
					await Task.Delay(100).ConfigureAwait(continueOnCapturedContext: false);
				}
				continue;
			}
			if (!string.IsNullOrEmpty(thumbprint))
			{
				Utils.LogError(512, "A Private key for the certificate with thumbpint {0} was not found.", thumbprint);
			}
			break;
		}
		return null;
	}

	public Task<StatusCode> IsRevoked(X509Certificate2 issuer, X509Certificate2 certificate)
	{
		if (issuer == null)
		{
			throw new ArgumentNullException("issuer");
		}
		if (certificate == null)
		{
			throw new ArgumentNullException("certificate");
		}
		if (m_crlSubdir.Exists)
		{
			bool flag = true;
			FileInfo[] files = m_crlSubdir.GetFiles("*.crl");
			foreach (FileInfo fileInfo in files)
			{
				X509CRL x509CRL = null;
				try
				{
					x509CRL = new X509CRL(fileInfo.FullName);
				}
				catch (Exception exception)
				{
					Utils.LogError(exception, "Could not parse CRL file.");
					continue;
				}
				if (X509Utils.CompareDistinguishedName(x509CRL.IssuerName, issuer.SubjectName) && x509CRL.VerifySignature(issuer, throwOnError: false))
				{
					if (x509CRL.IsRevoked(certificate))
					{
						return Task.FromResult((StatusCode)2149384192u);
					}
					if (x509CRL.ThisUpdate <= DateTime.UtcNow && (x509CRL.NextUpdate == DateTime.MinValue || x509CRL.NextUpdate >= DateTime.UtcNow))
					{
						flag = false;
					}
				}
			}
			if (!flag)
			{
				return Task.FromResult((StatusCode)0u);
			}
		}
		return Task.FromResult((StatusCode)2149253120u);
	}

	public Task<X509CRLCollection> EnumerateCRLs()
	{
		X509CRLCollection x509CRLCollection = new X509CRLCollection();
		if (m_crlSubdir.Exists)
		{
			FileInfo[] files = m_crlSubdir.GetFiles("*.crl");
			for (int i = 0; i < files.Length; i++)
			{
				X509CRL item = new X509CRL(files[i].FullName);
				x509CRLCollection.Add(item);
			}
		}
		return Task.FromResult(x509CRLCollection);
	}

	public async Task<X509CRLCollection> EnumerateCRLs(X509Certificate2 issuer, bool validateUpdateTime = true)
	{
		if (issuer == null)
		{
			throw new ArgumentNullException("issuer");
		}
		X509CRLCollection crls = new X509CRLCollection();
		foreach (X509CRL item in await EnumerateCRLs().ConfigureAwait(continueOnCapturedContext: false))
		{
			if (X509Utils.CompareDistinguishedName(item.IssuerName, issuer.SubjectName) && item.VerifySignature(issuer, throwOnError: false) && (!validateUpdateTime || (item.ThisUpdate <= DateTime.UtcNow && (item.NextUpdate == DateTime.MinValue || item.NextUpdate >= DateTime.UtcNow))))
			{
				crls.Add(item);
			}
		}
		return crls;
	}

	public async Task AddCRL(X509CRL crl)
	{
		if (crl == null)
		{
			throw new ArgumentNullException("crl");
		}
		X509Certificate2 issuer = null;
		X509Certificate2Enumerator enumerator = (await Enumerate().ConfigureAwait(continueOnCapturedContext: false)).GetEnumerator();
		while (enumerator.MoveNext())
		{
			X509Certificate2 current = enumerator.Current;
			if (X509Utils.CompareDistinguishedName(current.SubjectName, crl.IssuerName) && crl.VerifySignature(current, throwOnError: false))
			{
				issuer = current;
				break;
			}
		}
		if (issuer == null)
		{
			throw new ServiceResultException(2148663296u, "Could not find issuer of the CRL.");
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(m_crlSubdir.FullName).Append(Path.DirectorySeparatorChar);
		stringBuilder.Append(GetFileName(issuer)).Append(".crl");
		FileInfo fileInfo = new FileInfo(stringBuilder.ToString());
		if (!fileInfo.Directory.Exists)
		{
			fileInfo.Directory.Create();
		}
		File.WriteAllBytes(fileInfo.FullName, crl.RawData);
	}

	public Task<bool> DeleteCRL(X509CRL crl)
	{
		if (crl == null)
		{
			throw new ArgumentNullException("crl");
		}
		if (m_crlSubdir.Exists)
		{
			FileInfo[] files = m_crlSubdir.GetFiles("*.crl");
			foreach (FileInfo fileInfo in files)
			{
				if (fileInfo.Length == crl.RawData.Length && Utils.IsEqual(File.ReadAllBytes(fileInfo.FullName), crl.RawData))
				{
					fileInfo.Delete();
					return Task.FromResult(result: true);
				}
			}
		}
		return Task.FromResult(result: false);
	}

	private IDictionary<string, Entry> Load(string thumbprint)
	{
		lock (m_lock)
		{
			DateTime utcNow = DateTime.UtcNow;
			if (m_certificateSubdir != null)
			{
				m_certificateSubdir.Refresh();
			}
			if (!NoPrivateKeys && m_privateKeySubdir != null)
			{
				m_privateKeySubdir.Refresh();
			}
			if (!m_certificateSubdir.Exists)
			{
				m_certificates.Clear();
				return m_certificates;
			}
			if (m_certificateSubdir.LastWriteTimeUtc < m_lastDirectoryCheck && (NoPrivateKeys || m_privateKeySubdir == null || !m_privateKeySubdir.Exists || m_privateKeySubdir.LastWriteTimeUtc < m_lastDirectoryCheck))
			{
				return m_certificates;
			}
			m_certificates.Clear();
			m_lastDirectoryCheck = utcNow;
			bool flag = false;
			FileInfo[] files = m_certificateSubdir.GetFiles("*.der");
			foreach (FileInfo fileInfo in files)
			{
				try
				{
					Entry entry = new Entry
					{
						Certificate = new X509Certificate2(fileInfo.FullName),
						CertificateFile = fileInfo,
						PrivateKeyFile = null,
						CertificateWithPrivateKey = null
					};
					if (!NoPrivateKeys)
					{
						string value = fileInfo.Name.Substring(0, entry.CertificateFile.Name.Length - entry.CertificateFile.Extension.Length);
						StringBuilder stringBuilder = new StringBuilder();
						stringBuilder.Append(m_privateKeySubdir.FullName);
						stringBuilder.Append(Path.DirectorySeparatorChar);
						stringBuilder.Append(value);
						entry.PrivateKeyFile = new FileInfo(stringBuilder.ToString() + ".pfx");
						if (!entry.PrivateKeyFile.Exists)
						{
							entry.PrivateKeyFile = new FileInfo(stringBuilder.ToString() + ".pem");
							if (!entry.PrivateKeyFile.Exists)
							{
								entry.PrivateKeyFile = null;
							}
						}
					}
					m_certificates[entry.Certificate.Thumbprint] = entry;
					if (!string.IsNullOrEmpty(thumbprint) && thumbprint.Equals(entry.Certificate.Thumbprint, StringComparison.OrdinalIgnoreCase))
					{
						flag = true;
						break;
					}
				}
				catch (Exception exception)
				{
					Utils.LogError(exception, "Could not load certificate from file: {0}", fileInfo.FullName);
				}
			}
			if (flag)
			{
				m_lastDirectoryCheck = DateTime.MinValue;
			}
			return m_certificates;
		}
	}

	private Entry Find(string thumbprint)
	{
		IDictionary<string, Entry> dictionary = Load(thumbprint);
		Entry value = null;
		if (!string.IsNullOrEmpty(thumbprint) && !dictionary.TryGetValue(thumbprint, out value))
		{
			return null;
		}
		return value;
	}

	private string GetFileName(X509Certificate2 certificate)
	{
		string text = certificate.FriendlyName;
		List<string> list = X509Utils.ParseDistinguishedName(certificate.Subject);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].StartsWith("CN=", StringComparison.Ordinal))
			{
				text = list[i].Substring(3).Trim();
				break;
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int j = 0; j < text.Length; j++)
		{
			char value = text[j];
			if ("<>:\"/\\|?*".IndexOf(value) != -1)
			{
				value = '+';
			}
			stringBuilder.Append(value);
		}
		stringBuilder.Append(" [");
		stringBuilder.Append(certificate.Thumbprint);
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}

	private void WriteFile(byte[] data, string fileName, bool includePrivateKey)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (!m_directory.Exists)
		{
			m_directory.Create();
		}
		if (includePrivateKey)
		{
			if (m_privateKeySubdir == null)
			{
				return;
			}
			stringBuilder.Append(m_privateKeySubdir.FullName);
		}
		else
		{
			stringBuilder.Append(m_certificateSubdir.FullName);
		}
		stringBuilder.Append(Path.DirectorySeparatorChar);
		stringBuilder.Append(fileName);
		if (includePrivateKey)
		{
			stringBuilder.Append(".pfx");
		}
		else
		{
			stringBuilder.Append(".der");
		}
		FileInfo fileInfo = new FileInfo(stringBuilder.ToString());
		if (!fileInfo.Directory.Exists)
		{
			fileInfo.Directory.Create();
		}
		BinaryWriter binaryWriter = new BinaryWriter(fileInfo.Open(FileMode.Create));
		try
		{
			binaryWriter.Write(data);
		}
		finally
		{
			binaryWriter.Flush();
			binaryWriter.Dispose();
		}
		m_certificateSubdir.Refresh();
		m_privateKeySubdir?.Refresh();
	}
}
