using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMaterialRelationship : IIfcResourceLevelRelationship, IPersistEntity, IPersist
{
	IIfcMaterial RelatingMaterial { get; set; }

	IItemSet<IIfcMaterial> RelatedMaterials { get; }

	IfcLabel? Expression { get; set; }
}
