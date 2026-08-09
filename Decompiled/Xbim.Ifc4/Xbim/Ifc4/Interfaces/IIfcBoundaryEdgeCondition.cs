using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcBoundaryEdgeCondition : IIfcBoundaryCondition, IPersistEntity, IPersist
{
	IIfcModulusOfTranslationalSubgradeReactionSelect TranslationalStiffnessByLengthX { get; set; }

	IIfcModulusOfTranslationalSubgradeReactionSelect TranslationalStiffnessByLengthY { get; set; }

	IIfcModulusOfTranslationalSubgradeReactionSelect TranslationalStiffnessByLengthZ { get; set; }

	IIfcModulusOfRotationalSubgradeReactionSelect RotationalStiffnessByLengthX { get; set; }

	IIfcModulusOfRotationalSubgradeReactionSelect RotationalStiffnessByLengthY { get; set; }

	IIfcModulusOfRotationalSubgradeReactionSelect RotationalStiffnessByLengthZ { get; set; }
}
