using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public interface IPaletteMetric
{
	int GetMetricInt(PaletteState state, PaletteMetricInt metric);

	InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric);

	Padding GetMetricPadding(PaletteState state, PaletteMetricPadding metric);
}
