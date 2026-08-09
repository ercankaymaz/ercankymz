using System.Drawing;

namespace devDept.Eyeshot;

public interface ISelectionSettings
{
	float LineWeightScaleFactor { get; set; }

	Color ColorDynamic { get; }

	Color Color { get; }
}
