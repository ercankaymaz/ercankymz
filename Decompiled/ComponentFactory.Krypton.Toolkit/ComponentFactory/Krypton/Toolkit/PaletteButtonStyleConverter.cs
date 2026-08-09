namespace ComponentFactory.Krypton.Toolkit;

internal class PaletteButtonStyleConverter : StringLookupConverter
{
	private Pair[] _pairs = new Pair[18]
	{
		new Pair(PaletteButtonStyle.Inherit, "Inherit"),
		new Pair(PaletteButtonStyle.Standalone, "Standalone"),
		new Pair(PaletteButtonStyle.Alternate, "Alternate"),
		new Pair(PaletteButtonStyle.LowProfile, "Low Profile"),
		new Pair(PaletteButtonStyle.BreadCrumb, "BreadCrumb"),
		new Pair(PaletteButtonStyle.Cluster, "Cluster"),
		new Pair(PaletteButtonStyle.NavigatorStack, "Navigator Stack"),
		new Pair(PaletteButtonStyle.NavigatorOverflow, "Navigator Overflow"),
		new Pair(PaletteButtonStyle.NavigatorMini, "Navigator Mini"),
		new Pair(PaletteButtonStyle.InputControl, "Input Control"),
		new Pair(PaletteButtonStyle.ListItem, "List Item"),
		new Pair(PaletteButtonStyle.Form, "Form"),
		new Pair(PaletteButtonStyle.FormClose, "Form Close"),
		new Pair(PaletteButtonStyle.ButtonSpec, "ButtonSpec"),
		new Pair(PaletteButtonStyle.Command, "Command"),
		new Pair(PaletteButtonStyle.Custom1, "Custom1"),
		new Pair(PaletteButtonStyle.Custom2, "Custom2"),
		new Pair(PaletteButtonStyle.Custom3, "Custom3")
	};

	protected override Pair[] Pairs => _pairs;

	public PaletteButtonStyleConverter()
		: base(typeof(PaletteButtonStyle))
	{
	}
}
