namespace ComponentFactory.Krypton.Toolkit;

internal class InputControlStyleConverter : StringLookupConverter
{
	private Pair[] _pairs = new Pair[3]
	{
		new Pair(InputControlStyle.Standalone, "Standalone"),
		new Pair(InputControlStyle.Ribbon, "Ribbon"),
		new Pair(InputControlStyle.Custom1, "Custom1")
	};

	protected override Pair[] Pairs => _pairs;

	public InputControlStyleConverter()
		: base(typeof(InputControlStyle))
	{
	}
}
