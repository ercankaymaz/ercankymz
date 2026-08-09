namespace Xbim.IO.Esent;

public enum P21ParseAction
{
	BeginList,
	EndList,
	BeginComplex,
	EndComplex,
	SetIntegerValue,
	SetHexValue,
	SetFloatValue,
	SetStringValue,
	SetEnumValue,
	SetBooleanValue,
	SetNonDefinedValue,
	SetOverrideValue,
	BeginNestedType,
	EndNestedType,
	EndEntity,
	NewEntity,
	SetObjectValueUInt16,
	SetObjectValueInt32,
	SetObjectValueInt64
}
