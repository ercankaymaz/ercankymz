using Xbim.Common.Step21;

namespace Xbim.Common;

public interface IPropertyValue
{
	bool BooleanVal { get; }

	string EnumVal { get; }

	object EntityVal { get; }

	byte[] HexadecimalVal { get; }

	long IntegerVal { get; }

	double NumberVal { get; }

	double RealVal { get; }

	string StringVal { get; }

	StepParserType Type { get; }
}
