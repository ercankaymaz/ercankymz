using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcProfileDef : IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcProfileTypeEnum ProfileType { get; set; }

	IfcLabel? ProfileName { get; set; }

	IEnumerable<IIfcExternalReferenceRelationship> HasExternalReference { get; }

	IEnumerable<IIfcProfileProperties> HasProperties { get; }
}
