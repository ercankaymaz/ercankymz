using System.Runtime.CompilerServices;
using buMutliTextbox;

namespace ns20;

internal sealed class Class38
{
	[CompilerGenerated]
	private Place place_0;

	[CompilerGenerated]
	private Place place_1;

	[SpecialName]
	[CompilerGenerated]
	public Place method_0()
	{
		return place_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public void method_1(Place place_2)
	{
		place_0 = place_2;
	}

	[SpecialName]
	[CompilerGenerated]
	public Place method_2()
	{
		return place_1;
	}

	[SpecialName]
	[CompilerGenerated]
	public void method_3(Place place_2)
	{
		place_1 = place_2;
	}

	public Class38(Range range_0)
	{
		method_1(range_0.Start);
		method_3(range_0.End);
	}
}
