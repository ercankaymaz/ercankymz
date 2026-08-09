using System;

namespace Xbim.Ifc.Fluent.Internal;

internal class StableDateTimeGenerator : IDateTimeGenerator
{
	private readonly DateTime baseDate;

	public StableDateTimeGenerator(DateTime baseDate)
	{
		this.baseDate = baseDate;
	}

	public DateTime Generate()
	{
		return baseDate;
	}
}
