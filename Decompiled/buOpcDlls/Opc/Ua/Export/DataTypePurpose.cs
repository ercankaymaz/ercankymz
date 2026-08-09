using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace Opc.Ua.Export;

[Serializable]
[GeneratedCode("xsd", "4.8.3928.0")]
[XmlType(Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
[ComVisible(true)]
public enum DataTypePurpose
{
	Normal,
	ServicesOnly,
	CodeGenerator
}
