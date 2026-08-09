using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcBoundaryNodeCondition : IIfcBoundaryCondition, IPersistEntity, IPersist
{
	IIfcTranslationalStiffnessSelect TranslationalStiffnessX { get; set; }

	IIfcTranslationalStiffnessSelect TranslationalStiffnessY { get; set; }

	IIfcTranslationalStiffnessSelect TranslationalStiffnessZ { get; set; }

	IIfcRotationalStiffnessSelect RotationalStiffnessX { get; set; }

	IIfcRotationalStiffnessSelect RotationalStiffnessY { get; set; }

	IIfcRotationalStiffnessSelect RotationalStiffnessZ { get; set; }
}
