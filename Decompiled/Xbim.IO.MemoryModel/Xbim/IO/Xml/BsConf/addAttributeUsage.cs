using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Xbim.IO.Xml.BsConf;

[Serializable]
[GeneratedCode("System.Xml", "4.0.30319.34234")]
[XmlType(AnonymousType = true, Namespace = "urn:iso:std:iso:10303:-28:ed-2:tech:XMLschema:configuration_language")]
public enum addAttributeUsage
{
	optional,
	required,
	@fixed,
	@default
}
