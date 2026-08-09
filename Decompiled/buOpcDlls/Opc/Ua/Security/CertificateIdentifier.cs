using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Opc.Ua.Security;

[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "CertificateIdentifier", Namespace = "http://opcfoundation.org/UA/2011/03/SecuredApplication.xsd")]
[ComVisible(true)]
public class CertificateIdentifier : IExtensibleDataObject
{
	private ExtensionDataObject extensionDataField;

	private string StoreTypeField;

	private string StorePathField;

	private string SubjectNameField;

	private string ThumbprintField;

	private byte[] RawDataField;

	private int ValidationOptionsField;

	private byte[] OfflineRevocationListField;

	private string OnlineRevocationListField;

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

	[DataMember(EmitDefaultValue = false)]
	public string StoreType
	{
		get
		{
			return StoreTypeField;
		}
		set
		{
			StoreTypeField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string StorePath
	{
		get
		{
			return StorePathField;
		}
		set
		{
			StorePathField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string SubjectName
	{
		get
		{
			return SubjectNameField;
		}
		set
		{
			SubjectNameField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string Thumbprint
	{
		get
		{
			return ThumbprintField;
		}
		set
		{
			ThumbprintField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public byte[] RawData
	{
		get
		{
			return RawDataField;
		}
		set
		{
			RawDataField = value;
		}
	}

	[DataMember(Order = 5)]
	public int ValidationOptions
	{
		get
		{
			return ValidationOptionsField;
		}
		set
		{
			ValidationOptionsField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 6)]
	public byte[] OfflineRevocationList
	{
		get
		{
			return OfflineRevocationListField;
		}
		set
		{
			OfflineRevocationListField = value;
		}
	}

	[DataMember(EmitDefaultValue = false, Order = 7)]
	public string OnlineRevocationList
	{
		get
		{
			return OnlineRevocationListField;
		}
		set
		{
			OnlineRevocationListField = value;
		}
	}

	public async Task<X509Certificate2> Find()
	{
		return await SecuredApplication.FromCertificateIdentifier(this).Find(needPrivateKey: false).ConfigureAwait(continueOnCapturedContext: false);
	}

	public async Task<X509Certificate2> Find(bool needPrivateKey)
	{
		return await SecuredApplication.FromCertificateIdentifier(this).Find(needPrivateKey).ConfigureAwait(continueOnCapturedContext: false);
	}

	public ICertificateStore OpenStore()
	{
		return SecuredApplication.FromCertificateIdentifier(this).OpenStore();
	}
}
