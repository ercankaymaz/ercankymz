using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcStructuralAnalysisModel : IIfcSystem, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IfcAnalysisModelTypeEnum PredefinedType { get; set; }

	IIfcAxis2Placement3D OrientationOf2DPlane { get; set; }

	IItemSet<IIfcStructuralLoadGroup> LoadedBy { get; }

	IItemSet<IIfcStructuralResultGroup> HasResults { get; }

	IIfcObjectPlacement SharedPlacement { get; set; }
}
