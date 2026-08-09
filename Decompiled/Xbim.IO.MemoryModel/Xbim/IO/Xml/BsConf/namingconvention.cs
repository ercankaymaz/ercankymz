using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Xbim.IO.Xml.BsConf;

[Serializable]
[GeneratedCode("System.Xml", "4.0.30319.34234")]
[XmlType(TypeName = "naming-convention", Namespace = "urn:iso:std:iso:10303:-28:ed-2:tech:XMLschema:configuration_language")]
[XmlRoot("naming-convention", Namespace = "urn:iso:std:iso:10303:-28:ed-2:tech:XMLschema:configuration_language", IsNullable = false)]
public enum namingconvention
{
	[XmlEnum("initial-upper")]
	initialupper,
	[XmlEnum("camel-case")]
	camelcase,
	[XmlEnum("preserve-case")]
	preservecase
}
