using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcProperty : IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcIdentifier Name { get; set; }

	IfcText? Description { get; set; }

	IEnumerable<IIfcPropertySet> PartOfPset { get; }

	IEnumerable<IIfcPropertyDependencyRelationship> PropertyForDependance { get; }

	IEnumerable<IIfcPropertyDependencyRelationship> PropertyDependsOn { get; }

	IEnumerable<IIfcComplexProperty> PartOfComplex { get; }

	IEnumerable<IIfcResourceConstraintRelationship> HasConstraints { get; }

	IEnumerable<IIfcResourceApprovalRelationship> HasApprovals { get; }
}
