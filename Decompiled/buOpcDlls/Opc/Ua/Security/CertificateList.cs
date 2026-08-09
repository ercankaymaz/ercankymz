using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua.Security;

[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "CertificateList", Namespace = "http://opcfoundation.org/UA/2011/03/SecuredApplication.xsd")]
[ComVisible(true)]
public class CertificateList : IExtensibleDataObject
{
	private ExtensionDataObject extensionDataField;

	private ListOfCertificateIdentifier CertificatesField;

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
	public ListOfCertificateIdentifier Certificates
	{
		get
		{
			return CertificatesField;
		}
		set
		{
			CertificatesField = value;
		}
	}

	[DataMember]
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
}
