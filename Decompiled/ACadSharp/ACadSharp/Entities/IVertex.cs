using CSMath;

namespace ACadSharp.Entities;

public interface IVertex
{
	IVector Location { get; set; }

	double Bulge { get; set; }
}
