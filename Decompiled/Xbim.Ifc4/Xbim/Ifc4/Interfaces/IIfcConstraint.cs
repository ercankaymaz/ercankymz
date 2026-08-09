using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcConstraint : IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcLabel Name { get; set; }

	IfcText? Description { get; set; }

	IfcConstraintEnum ConstraintGrade { get; set; }

	IfcLabel? ConstraintSource { get; set; }

	IIfcActorSelect CreatingActor { get; set; }

	IfcDateTime? CreationTime { get; set; }

	IfcLabel? UserDefinedGrade { get; set; }

	IEnumerable<IIfcExternalReferenceRelationship> HasExternalReferences { get; }

	IEnumerable<IIfcResourceConstraintRelationship> PropertiesForConstraint { get; }
}
