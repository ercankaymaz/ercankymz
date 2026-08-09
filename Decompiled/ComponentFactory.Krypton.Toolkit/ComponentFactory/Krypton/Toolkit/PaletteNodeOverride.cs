#define DEBUG
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteNodeOverride : GlobalId, IPaletteTriple
{
	private PaletteBackInheritNode _overrideBack;

	private PaletteBorderInheritOverride _overrideBorder;

	private PaletteContentInheritNode _overrideContent;

	public TreeNode TreeNode
	{
		set
		{
			_overrideBack.TreeNode = value;
			_overrideContent.TreeNode = value;
		}
	}

	public IPaletteBack PaletteBack => _overrideBack;

	public IPaletteBorder PaletteBorder => _overrideBorder;

	public IPaletteContent PaletteContent => _overrideContent;

	public PaletteNodeOverride(IPaletteTriple triple)
	{
		Debug.Assert(triple != null);
		if (triple == null)
		{
			throw new ArgumentNullException("triple");
		}
		_overrideBack = new PaletteBackInheritNode(triple.PaletteBack);
		_overrideBorder = new PaletteBorderInheritOverride(triple.PaletteBorder, triple.PaletteBorder);
		_overrideContent = new PaletteContentInheritNode(triple.PaletteContent);
	}
}
