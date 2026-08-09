using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class CertificateIdentifier : IFormattable
{
	private string m_storeType;

	private string m_storePath;

	private string m_storeLocation;

	private string m_storeName;

	private string m_subjectName;

	private string m_thumbprint;

	private X509Certificate2 m_certificate;

	private CertificateValidationOptions m_validationOptions;

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 0)]
	public string StoreType
	{
		get
		{
			if (!string.IsNullOrEmpty(m_storeName))
			{
				return "X509Store";
			}
			return m_storeType;
		}
		set
		{
			m_storeType = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 1)]
	public string StorePath
	{
		get
		{
			if (!string.IsNullOrEmpty(m_storeName))
			{
				if (string.IsNullOrEmpty(m_storeLocation))
				{
					return Utils.Format("LocalMachine\\{0}", m_storeName);
				}
				return Utils.Format("{0}\\{1}", m_storeLocation, m_storeName);
			}
			return m_storePath;
		}
		set
		{
			m_storePath = value;
			if (!string.IsNullOrEmpty(m_storePath) && string.IsNullOrEmpty(m_storeType))
			{
				m_storeType = CertificateStoreIdentifier.DetermineStoreType(m_storePath);
			}
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 2)]
	[Obsolete("Use StoreType/StorePath instead")]
	public string StoreName
	{
		get
		{
			return m_storeName;
		}
		set
		{
			m_storeName = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 3)]
	[Obsolete("Use StoreType/StorePath instead")]
	public string StoreLocation
	{
		get
		{
			return m_storeLocation;
		}
		set
		{
			m_storeLocation = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 4)]
	public string SubjectName
	{
		get
		{
			if (m_certificate == null)
			{
				return m_subjectName;
			}
			return m_certificate.Subject;
		}
		set
		{
			if (m_certificate != null && !string.IsNullOrEmpty(value) && m_certificate.Subject != value)
			{
				throw new ArgumentException("SubjectName does not match the SubjectName of the current certificate.");
			}
			m_subjectName = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 5)]
	public string Thumbprint
	{
		get
		{
			if (m_certificate == null)
			{
				return m_thumbprint;
			}
			return m_certificate.Thumbprint;
		}
		set
		{
			if (m_certificate != null && !string.IsNullOrEmpty(value) && m_certificate.Thumbprint != value)
			{
				throw new ArgumentException("Thumbprint does not match the thumbprint of the current certificate.");
			}
			m_thumbprint = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 6)]
	public byte[] RawData
	{
		get
		{
			if (m_certificate == null)
			{
				return null;
			}
			return m_certificate.RawData;
		}
		set
		{
			if (value == null || value.Length == 0)
			{
				m_certificate = null;
				return;
			}
			m_certificate = CertificateFactory.Create(value, useCache: true);
			m_subjectName = m_certificate.Subject;
			m_thumbprint = m_certificate.Thumbprint;
		}
	}

	[DataMember(Name = "ValidationOptions", IsRequired = false, EmitDefaultValue = false, Order = 7)]
	private int XmlEncodedValidationOptions
	{
		get
		{
			return (int)m_validationOptions;
		}
		set
		{
			m_validationOptions = (CertificateValidationOptions)value;
		}
	}

	public CertificateValidationOptions ValidationOptions
	{
		get
		{
			return m_validationOptions;
		}
		set
		{
			m_validationOptions = value;
		}
	}

	public X509Certificate2 Certificate
	{
		get
		{
			return m_certificate;
		}
		set
		{
			m_certificate = value;
		}
	}

	public CertificateIdentifier()
	{
		Initialize();
	}

	public CertificateIdentifier(X509Certificate2 certificate)
	{
		Initialize();
		m_certificate = certificate;
	}

	public CertificateIdentifier(X509Certificate2 certificate, CertificateValidationOptions validationOptions)
	{
		Initialize();
		m_certificate = certificate;
		m_validationOptions = validationOptions;
	}

	public CertificateIdentifier(byte[] rawData)
	{
		Initialize();
		m_certificate = CertificateFactory.Create(rawData, useCache: true);
	}

	private void Initialize()
	{
	}

	[OnDeserializing]
	public void Initialize(StreamingContext context)
	{
		Initialize();
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (!string.IsNullOrEmpty(format))
		{
			throw new FormatException();
		}
		return ToString();
	}

	public override string ToString()
	{
		if (m_certificate != null)
		{
			return GetDisplayName(m_certificate);
		}
		if (m_subjectName != null)
		{
			return m_subjectName;
		}
		return m_thumbprint;
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is CertificateIdentifier certificateIdentifier))
		{
			return false;
		}
		if (m_certificate != null && certificateIdentifier.m_certificate != null)
		{
			return m_certificate.Thumbprint == certificateIdentifier.m_certificate.Thumbprint;
		}
		if (Thumbprint == certificateIdentifier.Thumbprint)
		{
			return true;
		}
		if (m_storeLocation != certificateIdentifier.m_storeLocation)
		{
			return false;
		}
		if (m_storeName != certificateIdentifier.m_storeName)
		{
			return false;
		}
		if (SubjectName != certificateIdentifier.SubjectName)
		{
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Thumbprint, m_storeLocation, m_storeName, SubjectName);
	}

	public Task<X509Certificate2> Find()
	{
		return Find(needPrivateKey: false);
	}

	public Task<X509Certificate2> LoadPrivateKey(string password)
	{
		return LoadPrivateKeyEx((password != null) ? new CertificatePasswordProvider(password) : null);
	}

	public async Task<X509Certificate2> LoadPrivateKeyEx(ICertificatePasswordProvider passwordProvider)
	{
		if (StoreType != "X509Store")
		{
			using ICertificateStore store = CertificateStoreIdentifier.CreateStore(StoreType);
			if (store.SupportsLoadPrivateKey)
			{
				store.Open(StorePath, noPrivateKeys: false);
				string password = passwordProvider?.GetPassword(this);
				m_certificate = await store.LoadPrivateKey(Thumbprint, SubjectName, password).ConfigureAwait(continueOnCapturedContext: false);
				return m_certificate;
			}
		}
		return await Find(needPrivateKey: true).ConfigureAwait(continueOnCapturedContext: false);
	}

	public async Task<X509Certificate2> Find(bool needPrivateKey)
	{
		X509Certificate2 x509Certificate = null;
		if (m_certificate != null && (!needPrivateKey || m_certificate.HasPrivateKey))
		{
			x509Certificate = m_certificate;
		}
		else
		{
			using ICertificateStore store = CertificateStoreIdentifier.CreateStore(StoreType);
			store.Open(StorePath, noPrivateKeys: false);
			x509Certificate = Find(await store.Enumerate().ConfigureAwait(continueOnCapturedContext: false), m_thumbprint, m_subjectName, needPrivateKey);
			if (x509Certificate != null)
			{
				if (needPrivateKey && store.SupportsLoadPrivateKey)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.AppendLine("Loaded a certificate with private key from store {0}.");
					stringBuilder.AppendLine("Ensure to call LoadPrivateKeyEx with password provider before calling Find(true).");
					Utils.LogWarning(stringBuilder.ToString(), StoreType);
				}
				m_certificate = x509Certificate;
			}
		}
		if (needPrivateKey)
		{
			x509Certificate = (m_certificate = CertificateFactory.Load(x509Certificate, ensurePrivateKeyAccessible: true));
		}
		return x509Certificate;
	}

	private void Paste(CertificateIdentifier certificate)
	{
		SubjectName = certificate.SubjectName;
		Thumbprint = certificate.Thumbprint;
		RawData = certificate.RawData;
		ValidationOptions = certificate.ValidationOptions;
		Certificate = certificate.Certificate;
	}

	private static string GetDisplayName(X509Certificate2 certificate)
	{
		if (!string.IsNullOrEmpty(certificate.FriendlyName))
		{
			return certificate.FriendlyName;
		}
		string subject = certificate.Subject;
		int num = subject.IndexOf("CN", StringComparison.Ordinal);
		if (num == -1)
		{
			return subject;
		}
		StringBuilder stringBuilder = new StringBuilder(subject.Length);
		for (int i = num + 2; i < subject.Length; i++)
		{
			if (subject[i] == '=')
			{
				num = i + 1;
				break;
			}
		}
		for (int j = num; j < subject.Length; j++)
		{
			if (!char.IsWhiteSpace(subject[j]))
			{
				num = j;
				break;
			}
		}
		for (int k = num; k < subject.Length && subject[k] != ','; k++)
		{
			stringBuilder.Append(subject[k]);
		}
		return stringBuilder.ToString();
	}

	public static X509Certificate2 Find(X509Certificate2Collection collection, string thumbprint, string subjectName, bool needPrivateKey)
	{
		if (!string.IsNullOrEmpty(thumbprint))
		{
			collection = collection.Find(X509FindType.FindByThumbprint, thumbprint, validOnly: false);
			X509Certificate2Enumerator enumerator = collection.GetEnumerator();
			while (enumerator.MoveNext())
			{
				X509Certificate2 current = enumerator.Current;
				if (!needPrivateKey || current.HasPrivateKey)
				{
					if (string.IsNullOrEmpty(subjectName))
					{
						return current;
					}
					List<string> parsedName = X509Utils.ParseDistinguishedName(subjectName);
					if (X509Utils.CompareDistinguishedName(current, parsedName))
					{
						return current;
					}
				}
			}
			return null;
		}
		if (!string.IsNullOrEmpty(subjectName))
		{
			List<string> parsedName2 = X509Utils.ParseDistinguishedName(subjectName);
			X509Certificate2Enumerator enumerator = collection.GetEnumerator();
			while (enumerator.MoveNext())
			{
				X509Certificate2 current2 = enumerator.Current;
				if (X509Utils.CompareDistinguishedName(current2, parsedName2) && (!needPrivateKey || current2.HasPrivateKey) && X509Utils.GetRSAPublicKeySize(current2) >= 0)
				{
					return current2;
				}
			}
			collection = collection.Find(X509FindType.FindBySubjectName, subjectName, validOnly: false);
			enumerator = collection.GetEnumerator();
			while (enumerator.MoveNext())
			{
				X509Certificate2 current3 = enumerator.Current;
				if ((!needPrivateKey || current3.HasPrivateKey) && X509Utils.GetRSAPublicKeySize(current3) >= 0)
				{
					return current3;
				}
			}
		}
		return null;
	}

	public static byte[] CreateBlob(IList<X509Certificate2> certificates)
	{
		if (certificates == null || certificates.Count == 0)
		{
			throw new CryptographicException("Primary certificate has not been provided.");
		}
		byte[] array = certificates[0].RawData;
		if (certificates.Count > 1)
		{
			List<byte[]> list = new List<byte[]>(certificates.Count - 1);
			int num = array.Length;
			for (int i = 1; i < certificates.Count; i++)
			{
				byte[] rawData = certificates[i].RawData;
				num += rawData.Length;
				list.Add(rawData);
			}
			byte[] array2 = new byte[num];
			Array.Copy(array, array2, array.Length);
			num = array.Length;
			for (int j = 0; j < list.Count; j++)
			{
				byte[] array3 = list[j];
				Array.Copy(array3, 0, array2, num, array3.Length);
				num += array3.Length;
			}
			array = array2;
		}
		return array;
	}

	public static X509Certificate2Collection ParseBlob(byte[] encodedData)
	{
		if (!IsValidCertificateBlob(encodedData))
		{
			throw new CryptographicException("Primary certificate in blob is not valid.");
		}
		X509Certificate2Collection x509Certificate2Collection = new X509Certificate2Collection();
		X509Certificate2 x509Certificate = CertificateFactory.Create(encodedData, useCache: true);
		x509Certificate2Collection.Add(x509Certificate);
		byte[] rawData = x509Certificate.RawData;
		int num = rawData.Length;
		if (encodedData.Length < num)
		{
			byte[] array = new byte[encodedData.Length - num];
			do
			{
				Array.Copy(encodedData, num, array, 0, encodedData.Length - num);
				if (!IsValidCertificateBlob(array))
				{
					throw new CryptographicException("Supporting certificate in blob is not valid.");
				}
				X509Certificate2 x509Certificate2 = CertificateFactory.Create(array, useCache: true);
				x509Certificate2Collection.Add(x509Certificate2);
				rawData = x509Certificate2.RawData;
				num += rawData.Length;
			}
			while (num < encodedData.Length);
		}
		return x509Certificate2Collection;
	}

	public ICertificateStore OpenStore()
	{
		ICertificateStore certificateStore = CertificateStoreIdentifier.CreateStore(StoreType);
		certificateStore.Open(StorePath, noPrivateKeys: false);
		return certificateStore;
	}

	private static bool IsValidCertificateBlob(byte[] rawData)
	{
		if (rawData == null || rawData.Length < 4)
		{
			return false;
		}
		if (rawData[0] != 48)
		{
			return false;
		}
		byte b = rawData[1];
		int num;
		if ((b & 0x80) == 0)
		{
			num = b & 0x7F;
			if (2 + num < rawData.Length)
			{
				return false;
			}
			return true;
		}
		int num2 = b & 0x7F;
		if (rawData.Length <= 2 + num2)
		{
			return false;
		}
		if ((rawData[2] & 0x80) != 0)
		{
			return false;
		}
		num = rawData[2];
		for (int i = 0; i < num2 - 1; i++)
		{
			num <<= 8;
			num |= rawData[i + 3];
		}
		if (2 + num2 + num > rawData.Length)
		{
			return false;
		}
		return true;
	}
}
