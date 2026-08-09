using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcStructuralResultGroup : IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IfcAnalysisTheoryTypeEnum TheoryType { get; set; }

	IIfcStructuralLoadGroup ResultForLoadGroup { get; set; }

	IfcBoolean IsLinear { get; set; }

	IEnumerable<IIfcStructuralAnalysisModel> ResultGroupFor { get; }
}
