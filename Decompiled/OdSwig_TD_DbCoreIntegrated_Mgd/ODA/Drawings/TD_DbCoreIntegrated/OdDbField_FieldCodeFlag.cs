using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbField_FieldCodeFlag
{
	kRawCode = 0,
	kFieldCode = 1,
	kEvaluatedText = 2,
	kEvaluatedChildren = 4,
	kObjectReference = 8,
	kAddMarkers = 0x10,
	kEscapeBackslash = 0x20,
	kStripOptions = 0x40,
	kPreserveFields = 0x80,
	kTextField = 0x100,
	kPreserveOptions = 0x200,
	kDetachChildren = 0x400,
	kChildObjectReference = 0x800,
	kForExpression = 0x1000
}
