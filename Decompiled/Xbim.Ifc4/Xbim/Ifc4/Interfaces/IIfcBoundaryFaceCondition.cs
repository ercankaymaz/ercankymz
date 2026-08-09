using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcBoundaryFaceCondition : IIfcBoundaryCondition, IPersistEntity, IPersist
{
	IIfcModulusOfSubgradeReactionSelect TranslationalStiffnessByAreaX { get; set; }

	IIfcModulusOfSubgradeReactionSelect TranslationalStiffnessByAreaY { get; set; }

	IIfcModulusOfSubgradeReactionSelect TranslationalStiffnessByAreaZ { get; set; }
}
