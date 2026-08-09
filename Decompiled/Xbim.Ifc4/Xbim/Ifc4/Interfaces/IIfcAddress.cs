using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcAddress : IPersistEntity, IPersist, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IExpressSelectType
{
	IfcAddressTypeEnum? Purpose { get; set; }

	IfcText? Description { get; set; }

	IfcLabel? UserDefinedPurpose { get; set; }

	IEnumerable<IIfcPerson> OfPerson { get; }

	IEnumerable<IIfcOrganization> OfOrganization { get; }
}
