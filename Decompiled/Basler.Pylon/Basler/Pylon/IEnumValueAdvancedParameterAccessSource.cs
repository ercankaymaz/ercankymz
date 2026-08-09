namespace Basler.Pylon;

internal interface IEnumValueAdvancedParameterAccessSource
{
	IAdvancedParameterAccess GetAdvancedValueProperties(string enumName, string valueName);
}
