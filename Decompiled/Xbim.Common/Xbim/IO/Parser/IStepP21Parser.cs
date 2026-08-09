namespace Xbim.IO.Parser;

internal interface IStepP21Parser
{
	void SetErrorMessage();

	void CharacterError();

	void BeginParse();

	void EndParse();

	void BeginHeader();

	void EndHeader();

	void BeginScope();

	void EndScope();

	void EndSec();

	void BeginList();

	void EndList();

	void BeginComplex();

	void EndComplex();

	void NewEntity(string entityLabel);

	void SetType(string entityTypeName);

	void EndEntity();

	void EndHeaderEntity();

	void SetIntegerValue(string value);

	void SetHexValue(string value);

	void SetFloatValue(string value);

	void SetStringValue(string value);

	void SetInvalidStringValue(string value);

	void SetEnumValue(string value);

	void SetBooleanValue(string value);

	void SetNonDefinedValue();

	void SetOverrideValue();

	void SetObjectValue(string value);

	void EndNestedType(string value);

	void BeginNestedType(string value);
}
