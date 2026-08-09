using System.Drawing;

namespace devDept.Eyeshot;

public interface IHiddenLinesSettings
{
	bool Lighting { get; }

	hiddenLinesColorMethodType ColorMethod { get; }

	Color WireColor { get; }

	edgeColorMethodType WireColorMethod { get; }
}
