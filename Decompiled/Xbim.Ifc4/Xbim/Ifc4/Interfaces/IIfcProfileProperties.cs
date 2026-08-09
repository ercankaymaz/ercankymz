using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcProfileProperties : IIfcExtendedProperties, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IIfcProfileDef ProfileDefinition { get; set; }
}
