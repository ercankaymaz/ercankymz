namespace ComponentFactory.Krypton.Toolkit;

internal class TabStyleConverter : StringLookupConverter
{
	private Pair[] _pairs = new Pair[9]
	{
		new Pair(TabStyle.HighProfile, "High Profile"),
		new Pair(TabStyle.StandardProfile, "Standard Profile"),
		new Pair(TabStyle.LowProfile, "Low Profile"),
		new Pair(TabStyle.OneNote, "OneNote"),
		new Pair(TabStyle.Dock, "Dock"),
		new Pair(TabStyle.DockAutoHidden, "Dock AutoHidden"),
		new Pair(TabStyle.Custom1, "Custom1"),
		new Pair(TabStyle.Custom2, "Custom2"),
		new Pair(TabStyle.Custom3, "Custom3")
	};

	protected override Pair[] Pairs => _pairs;

	public TabStyleConverter()
		: base(typeof(TabStyle))
	{
	}
}
