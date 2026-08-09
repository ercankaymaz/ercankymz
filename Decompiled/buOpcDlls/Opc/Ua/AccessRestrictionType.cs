using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[Flags]
[ComVisible(true)]
public enum AccessRestrictionType : ushort
{
	[EnumMember(Value = "None_0")]
	None = 0,
	[EnumMember(Value = "SigningRequired_1")]
	SigningRequired = 1,
	[EnumMember(Value = "EncryptionRequired_2")]
	EncryptionRequired = 2,
	[EnumMember(Value = "SessionRequired_4")]
	SessionRequired = 4,
	[EnumMember(Value = "ApplyRestrictionsToBrowse_8")]
	ApplyRestrictionsToBrowse = 8
}
