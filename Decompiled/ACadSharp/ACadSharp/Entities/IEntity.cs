using ACadSharp.Objects;
using ACadSharp.Tables;

namespace ACadSharp.Entities;

public interface IEntity : IHandledCadObject, IGeometricEntity
{
	Color Color { get; set; }

	bool IsInvisible { get; set; }

	Layer Layer { get; set; }

	LineType LineType { get; set; }

	double LineTypeScale { get; set; }

	LineWeightType LineWeight { get; set; }

	Material Material { get; set; }

	Transparency Transparency { get; set; }

	Color GetActiveColor();

	LineType GetActiveLineType();

	LineWeightType GetActiveLineWeightType();

	void MatchProperties(IEntity entity);
}
