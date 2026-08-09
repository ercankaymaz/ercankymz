namespace ComponentFactory.Krypton.Toolkit;

internal class LabelStyleConverter : StringLookupConverter
{
	private Pair[] _pairs = new Pair[15]
	{
		new Pair(LabelStyle.NormalControl, "Normal (Control)"),
		new Pair(LabelStyle.BoldControl, "Bold (Control)"),
		new Pair(LabelStyle.ItalicControl, "Italic (Control)"),
		new Pair(LabelStyle.TitleControl, "Title (Control)"),
		new Pair(LabelStyle.NormalPanel, "Normal (Panel)"),
		new Pair(LabelStyle.BoldPanel, "Bold (Panel)"),
		new Pair(LabelStyle.ItalicPanel, "Italic (Panel)"),
		new Pair(LabelStyle.TitlePanel, "Title (Panel)"),
		new Pair(LabelStyle.GroupBoxCaption, "Caption (Panel)"),
		new Pair(LabelStyle.ToolTip, "ToolTip"),
		new Pair(LabelStyle.SuperTip, "SuperTip"),
		new Pair(LabelStyle.KeyTip, "KeyTip"),
		new Pair(LabelStyle.Custom1, "Custom1"),
		new Pair(LabelStyle.Custom2, "Custom2"),
		new Pair(LabelStyle.Custom3, "Custom3")
	};

	protected override Pair[] Pairs => _pairs;

	public LabelStyleConverter()
		: base(typeof(LabelStyle))
	{
	}
}
