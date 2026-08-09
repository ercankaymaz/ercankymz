namespace ComponentFactory.Krypton.Toolkit;

internal class DataGridViewStyleConverter : StringLookupConverter
{
	private Pair[] _pairs = new Pair[4]
	{
		new Pair(DataGridViewStyle.List, "List"),
		new Pair(DataGridViewStyle.Sheet, "Sheet"),
		new Pair(DataGridViewStyle.Custom1, "Custom1"),
		new Pair(DataGridViewStyle.Mixed, "Mixed")
	};

	protected override Pair[] Pairs => _pairs;

	public DataGridViewStyleConverter()
		: base(typeof(DataGridViewStyle))
	{
	}
}
