using System.Drawing;

namespace devDept.Graphics;

public interface IDataPerFrame
{
	ILightsData[] Lights { get; }

	Size ViewportSize { get; }

	bool[] ClipPlanesEnabled { get; }

	float[][] ClipPlanes { get; }
}
