using System.ComponentModel;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public abstract class ButtonSpecMdiChildFixed : ButtonSpec
{
	private Form _mdiChild;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool AllowComponent => false;

	public Form MdiChild
	{
		get
		{
			return _mdiChild;
		}
		set
		{
			_mdiChild = value;
		}
	}

	public PaletteButtonSpecStyle ButtonSpecType
	{
		get
		{
			return base.ProtectedType;
		}
		set
		{
			base.ProtectedType = value;
		}
	}

	public ButtonSpecMdiChildFixed(PaletteButtonSpecStyle fixedStyle)
	{
		base.ProtectedType = fixedStyle;
	}

	public override ButtonStyle GetStyle(IPalette palette)
	{
		return ButtonStyle.ButtonSpec;
	}
}
