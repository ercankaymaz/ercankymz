#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonProfessionalKCT : KryptonColorTable
{
	private Color[] _colors;

	public Color Header1Begin => _colors[0];

	public Color Header1End => _colors[1];

	public KryptonProfessionalKCT(Color[] colors, bool useSystemColors, IPalette palette)
		: base(palette)
	{
		Debug.Assert(colors != null);
		_colors = colors;
		base.UseSystemColors = useSystemColors;
	}
}
