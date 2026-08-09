namespace ComponentFactory.Krypton.Toolkit;

internal class GridStyleConverter : StringLookupConverter
{
	private Pair[] _pairs = new Pair[3]
	{
		new Pair(GridStyle.List, "List"),
		new Pair(GridStyle.Sheet, "Sheet"),
		new Pair(GridStyle.Custom1, "Custom1")
	};

	protected override Pair[] Pairs => _pairs;

	public GridStyleConverter()
		: base(typeof(GridStyle))
	{
	}
}
