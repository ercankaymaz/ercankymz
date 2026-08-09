using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcGrid : IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IItemSet<IIfcGridAxis> UAxes { get; }

	IItemSet<IIfcGridAxis> VAxes { get; }

	IItemSet<IIfcGridAxis> WAxes { get; }

	IfcGridTypeEnum? PredefinedType { get; set; }

	IEnumerable<IIfcRelContainedInSpatialStructure> ContainedInStructure { get; }
}
