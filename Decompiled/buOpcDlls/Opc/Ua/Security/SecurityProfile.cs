using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua.Security;

[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "SecurityProfile", Namespace = "http://opcfoundation.org/UA/2011/03/SecuredApplication.xsd")]
[ComVisible(true)]
public class SecurityProfile : IExtensibleDataObject
{
	private ExtensionDataObject extensionDataField;

	private string ProfileUriField;

	private bool EnabledField;

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
	public string ProfileUri
	{
		get
		{
			return ProfileUriField;
		}
		set
		{
			ProfileUriField = value;
		}
	}

	[DataMember(Order = 1)]
	public bool Enabled
	{
		get
		{
			return EnabledField;
		}
		set
		{
			EnabledField = value;
		}
	}
}
