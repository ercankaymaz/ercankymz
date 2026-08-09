using Xbim.Common.Exceptions;
using Xbim.Common.Step21;

namespace Xbim.Common;

public static class PersistEntityExtensions
{
	internal static void HandleUnexpectedAttribute(this IPersist persistIfc, int propIndex, IPropertyValue value)
	{
		if (value.Type == StepParserType.Enum && string.CompareOrdinal(value.EnumVal, "NOTDEFINED") == 0)
		{
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {persistIfc.GetType().Name.ToUpper()}");
	}
}
