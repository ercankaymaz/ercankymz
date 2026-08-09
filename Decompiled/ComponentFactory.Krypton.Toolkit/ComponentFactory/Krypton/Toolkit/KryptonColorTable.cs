using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonColorTable : ProfessionalColorTable
{
	private IPalette _palette;

	public IPalette Palette => _palette;

	public virtual InheritBool UseRoundedEdges => InheritBool.True;

	public virtual Color MenuItemText => SystemColors.MenuText;

	public virtual Color MenuStripText => SystemColors.MenuText;

	public virtual Color ToolStripText => SystemColors.MenuText;

	public virtual Color StatusStripText => SystemColors.MenuText;

	public virtual Font MenuStripFont => SystemInformation.MenuFont;

	public virtual Font ToolStripFont => SystemInformation.MenuFont;

	public virtual Font StatusStripFont => SystemInformation.MenuFont;

	public KryptonColorTable(IPalette palette)
	{
		_palette = palette;
	}
}
