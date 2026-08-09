namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonLinkBehaviorConverter : StringLookupConverter
{
	private Pair[] _pairs = new Pair[3]
	{
		new Pair(KryptonLinkBehavior.AlwaysUnderline, "Always Underline"),
		new Pair(KryptonLinkBehavior.HoverUnderline, "Hover Underline"),
		new Pair(KryptonLinkBehavior.NeverUnderline, "Never Underline")
	};

	protected override Pair[] Pairs => _pairs;

	public KryptonLinkBehaviorConverter()
		: base(typeof(KryptonLinkBehavior))
	{
	}
}
