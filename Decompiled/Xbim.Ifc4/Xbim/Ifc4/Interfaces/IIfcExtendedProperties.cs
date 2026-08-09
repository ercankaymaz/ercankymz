using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcExtendedProperties : IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcIdentifier? Name { get; set; }

	IfcText? Description { get; set; }

	IEnumerable<IIfcProperty> Properties { get; }
}
