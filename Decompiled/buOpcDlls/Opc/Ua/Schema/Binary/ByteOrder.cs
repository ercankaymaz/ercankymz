using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Opc.Ua.Schema.Binary;

[GeneratedCode("xsd", "2.0.50727.312")]
[DataContract]
[XmlType(Namespace = "http://opcfoundation.org/BinarySchema/")]
[ComVisible(true)]
public enum ByteOrder
{
	BigEndian,
	LittleEndian
}
