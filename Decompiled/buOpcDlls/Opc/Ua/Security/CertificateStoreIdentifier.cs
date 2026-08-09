using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua.Security;

[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "CertificateStoreIdentifier", Namespace = "http://opcfoundation.org/UA/2011/03/SecuredApplication.xsd")]
[ComVisible(true)]
public class CertificateStoreIdentifier : IExtensibleDataObject
{
	private ExtensionDataObject extensionDataField;

	private string StoreTypeField;

	private string StorePathField;

	private int ValidationOptionsField;

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

	[DataMember(Order = 2)]
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

	public ICertificateStore OpenStore()
	{
		return SecuredApplication.FromCertificateStoreIdentifier(this).OpenStore();
	}
}
