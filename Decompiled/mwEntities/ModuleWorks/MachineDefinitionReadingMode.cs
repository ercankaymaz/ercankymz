using System;

namespace ModuleWorks;

[Serializable]
public enum MachineDefinitionReadingMode
{
	OnlyMPS,
	OnlyXml,
	XmlAndMPS,
	XmlWithPostSection
}
