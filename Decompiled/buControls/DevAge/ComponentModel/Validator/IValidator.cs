using System;
using System.Collections;
using System.Globalization;

namespace DevAge.ComponentModel.Validator;

public interface IValidator
{
	bool AllowNull { get; set; }

	string NullString { get; set; }

	string NullDisplayString { get; set; }

	bool AllowStringConversion { get; set; }

	object MinimumValue { get; set; }

	object MaximumValue { get; set; }

	Type ValueType { get; }

	object DefaultValue { get; set; }

	ICollection StandardValues { get; set; }

	bool StandardValuesExclusive { get; set; }

	CultureInfo CultureInfo { get; set; }

	event ConvertingObjectEventHandler ConvertingObjectToValue;

	event ConvertingObjectEventHandler ConvertingValueToObject;

	event ConvertingObjectEventHandler ConvertingValueToDisplayString;

	event EventHandler Changed;

	bool IsNullString(string p_str);

	object ObjectToValue(object p_Object);

	object ValueToObject(object p_Value, Type p_ReturnObjectType);

	string ValueToString(object p_Value);

	object StringToValue(string p_str);

	bool IsStringConversionSupported();

	string ValueToDisplayString(object p_Value);

	bool IsValidValue(object p_Value);

	bool IsValidObject(object p_Object);

	bool IsValidObject(object p_Object, out object p_ValueConverted);

	bool IsValidString(string p_strValue);

	bool IsValidString(string p_strValue, out object p_ValueConverted);

	bool IsInStandardValues(object p_Value);

	object StandardValueAtIndex(int p_Index);

	int StandardValuesIndexOf(object p_StandardValue);
}
