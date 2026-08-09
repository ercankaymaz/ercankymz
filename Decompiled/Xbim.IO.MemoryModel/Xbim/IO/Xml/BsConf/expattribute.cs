using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Xbim.IO.Xml.BsConf;

[Serializable]
[GeneratedCode("System.Xml", "4.0.30319.34234")]
[XmlType(TypeName = "exp-attribute", Namespace = "urn:iso:std:iso:10303:-28:ed-2:tech:XMLschema:configuration_language")]
[XmlRoot("exp-attribute", Namespace = "urn:iso:std:iso:10303:-28:ed-2:tech:XMLschema:configuration_language", IsNullable = false)]
public enum expattribute
{
	unspecified,
	[XmlEnum("double-tag")]
	doubletag,
	[XmlEnum("attribute-tag")]
	attributetag,
	[XmlEnum("type-tag")]
	typetag,
	[XmlEnum("no-tag")]
	notag,
	[XmlEnum("no-tag-simple")]
	notagsimple,
	[XmlEnum("attribute-content")]
	attributecontent
}
