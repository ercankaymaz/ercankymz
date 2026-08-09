namespace ComponentFactory.Krypton.Toolkit;

internal class HeaderGroupCollapsedTargetConverter : StringLookupConverter
{
	private Pair[] _pairs = new Pair[3]
	{
		new Pair(HeaderGroupCollapsedTarget.CollapsedToPrimary, "Collapse to Primary Header"),
		new Pair(HeaderGroupCollapsedTarget.CollapsedToSecondary, "Collapse to Secondary Header"),
		new Pair(HeaderGroupCollapsedTarget.CollapsedToBoth, "Collapse to Both Headers")
	};

	protected override Pair[] Pairs => _pairs;

	public HeaderGroupCollapsedTargetConverter()
		: base(typeof(HeaderGroupCollapsedTarget))
	{
	}
}
