using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class CertificateStoreIdentifier : IFormattable, ICloneable
{
	private string m_storeType;

	private string m_storePath;

	private string m_storeLocation;

	private string m_storeName;

	private CertificateValidationOptions m_validationOptions;

	public static readonly string DefaultPKIRoot = Path.Combine("%CommonApplicationData%", "OPC Foundation", "pki");

	public static readonly string CurrentUser = "CurrentUser\\";

	public static readonly string LocalMachine = "LocalMachine\\";

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
					return CurrentUser + m_storeName;
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
				m_storeType = DetermineStoreType(m_storePath);
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

	[DataMember(Name = "ValidationOptions", IsRequired = false, EmitDefaultValue = false, Order = 4)]
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

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return base.MemberwiseClone();
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
		if (string.IsNullOrEmpty(StoreType))
		{
			return Utils.Format("{0}", StorePath);
		}
		return Utils.Format("[{0}]{1}", StoreType, StorePath);
	}

	public static string DetermineStoreType(string storePath)
	{
		if (string.IsNullOrEmpty(storePath))
		{
			return "Directory";
		}
		if (storePath.StartsWith(LocalMachine, StringComparison.OrdinalIgnoreCase))
		{
			return "X509Store";
		}
		if (storePath.StartsWith(CurrentUser, StringComparison.OrdinalIgnoreCase))
		{
			return "X509Store";
		}
		foreach (string registeredStoreTypeName in CertificateStoreType.RegisteredStoreTypeNames)
		{
			if (CertificateStoreType.GetCertificateStoreTypeByName(registeredStoreTypeName).SupportsStorePath(storePath))
			{
				return registeredStoreTypeName;
			}
		}
		return "Directory";
	}

	public static ICertificateStore CreateStore(string storeTypeName)
	{
		ICertificateStore certificateStore = null;
		if (string.IsNullOrEmpty(storeTypeName))
		{
			return new CertificateIdentifierCollection();
		}
		if (!(storeTypeName == "X509Store"))
		{
			if (storeTypeName == "Directory")
			{
				return new DirectoryCertificateStore();
			}
			ICertificateStoreType certificateStoreTypeByName = CertificateStoreType.GetCertificateStoreTypeByName(storeTypeName);
			if (certificateStoreTypeByName != null)
			{
				return certificateStoreTypeByName.CreateStore();
			}
			throw new ArgumentException("Invalid store type name: " + storeTypeName);
		}
		return new X509CertificateStore();
	}

	public virtual ICertificateStore OpenStore()
	{
		ICertificateStore certificateStore = CreateStore(StoreType);
		certificateStore.Open(StorePath);
		return certificateStore;
	}

	public static ICertificateStore OpenStore(string path)
	{
		ICertificateStore certificateStore = CreateStore(DetermineStoreType(path));
		certificateStore.Open(path);
		return certificateStore;
	}
}
