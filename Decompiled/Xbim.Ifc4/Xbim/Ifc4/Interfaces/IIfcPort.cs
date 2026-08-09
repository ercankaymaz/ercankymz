using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPort : IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IEnumerable<IIfcRelConnectsPortToElement> ContainedIn { get; }

	IEnumerable<IIfcRelConnectsPorts> ConnectedFrom { get; }

	IEnumerable<IIfcRelConnectsPorts> ConnectedTo { get; }
}
