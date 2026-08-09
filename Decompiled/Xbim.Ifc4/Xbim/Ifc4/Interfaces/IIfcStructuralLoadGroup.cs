using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcStructuralLoadGroup : IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IfcLoadGroupTypeEnum PredefinedType { get; set; }

	IfcActionTypeEnum ActionType { get; set; }

	IfcActionSourceTypeEnum ActionSource { get; set; }

	IfcRatioMeasure? Coefficient { get; set; }

	IfcLabel? Purpose { get; set; }

	IEnumerable<IIfcStructuralResultGroup> SourceOfResultGroup { get; }

	IEnumerable<IIfcStructuralAnalysisModel> LoadGroupFor { get; }
}
