namespace ComponentFactory.Krypton.Toolkit;

internal class SeparatorStyleConverter : StringLookupConverter
{
	private Pair[] _pairs = new Pair[4]
	{
		new Pair(SeparatorStyle.LowProfile, "Low Profile"),
		new Pair(SeparatorStyle.HighProfile, "High Profile"),
		new Pair(SeparatorStyle.HighInternalProfile, "High Internal Profile"),
		new Pair(SeparatorStyle.Custom1, "Custom1")
	};

	protected override Pair[] Pairs => _pairs;

	public SeparatorStyleConverter()
		: base(typeof(SeparatorStyle))
	{
	}
}
