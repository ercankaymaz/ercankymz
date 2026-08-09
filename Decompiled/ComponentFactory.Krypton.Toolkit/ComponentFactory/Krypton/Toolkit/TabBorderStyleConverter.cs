namespace ComponentFactory.Krypton.Toolkit;

internal class TabBorderStyleConverter : StringLookupConverter
{
	private Pair[] _pairs = new Pair[23]
	{
		new Pair(TabBorderStyle.OneNote, "OneNote"),
		new Pair(TabBorderStyle.SquareEqualSmall, "Square Equal Small"),
		new Pair(TabBorderStyle.SquareEqualMedium, "Square Equal Medium"),
		new Pair(TabBorderStyle.SquareEqualLarge, "Square Equal Large"),
		new Pair(TabBorderStyle.SquareOutsizeSmall, "Square Outsize Small"),
		new Pair(TabBorderStyle.SquareOutsizeMedium, "Square Outsize Medium"),
		new Pair(TabBorderStyle.SquareOutsizeLarge, "Square Outsize Large"),
		new Pair(TabBorderStyle.RoundedEqualSmall, "Rounded Equal Small"),
		new Pair(TabBorderStyle.RoundedEqualMedium, "Rounded Equal Medium"),
		new Pair(TabBorderStyle.RoundedEqualLarge, "Rounded Equal Large"),
		new Pair(TabBorderStyle.RoundedOutsizeSmall, "Rounded Outsize Small"),
		new Pair(TabBorderStyle.RoundedOutsizeMedium, "Rounded Outsize Medium"),
		new Pair(TabBorderStyle.RoundedOutsizeLarge, "Rounded Outsize Large"),
		new Pair(TabBorderStyle.SlantEqualNear, "Slant Equal Near"),
		new Pair(TabBorderStyle.SlantEqualFar, "Slant Equal Far"),
		new Pair(TabBorderStyle.SlantEqualBoth, "Slant Equal Both"),
		new Pair(TabBorderStyle.SlantOutsizeNear, "Slant Outsize Near"),
		new Pair(TabBorderStyle.SlantOutsizeFar, "Slant Outsize Far"),
		new Pair(TabBorderStyle.SlantOutsizeBoth, "Slant Outsize Both"),
		new Pair(TabBorderStyle.SmoothEqual, "Smooth Equal"),
		new Pair(TabBorderStyle.SmoothOutsize, "Smooth Outsize"),
		new Pair(TabBorderStyle.DockEqual, "Dock Equal"),
		new Pair(TabBorderStyle.DockOutsize, "Dock Outsize")
	};

	protected override Pair[] Pairs => _pairs;

	public TabBorderStyleConverter()
		: base(typeof(TabBorderStyle))
	{
	}
}
