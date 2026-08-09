namespace ComponentFactory.Krypton.Toolkit;

internal class HeaderStyleConverter : StringLookupConverter
{
	private Pair[] _pairs = new Pair[8]
	{
		new Pair(HeaderStyle.Primary, "Primary"),
		new Pair(HeaderStyle.Secondary, "Secondary"),
		new Pair(HeaderStyle.DockInactive, "Dock - Inactive"),
		new Pair(HeaderStyle.DockActive, "Dock - Active"),
		new Pair(HeaderStyle.Form, "Form"),
		new Pair(HeaderStyle.Calendar, "Calendar"),
		new Pair(HeaderStyle.Custom1, "Custom1"),
		new Pair(HeaderStyle.Custom2, "Custom2")
	};

	protected override Pair[] Pairs => _pairs;

	public HeaderStyleConverter()
		: base(typeof(HeaderStyle))
	{
	}
}
