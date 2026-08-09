using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCovering : IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	IfcCoveringTypeEnum? PredefinedType { get; set; }

	IEnumerable<IIfcRelCoversSpaces> CoversSpaces { get; }

	IEnumerable<IIfcRelCoversBldgElements> CoversElements { get; }
}
