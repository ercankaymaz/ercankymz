using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcStructuralActivity : IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IIfcStructuralLoad AppliedLoad { get; set; }

	IfcGlobalOrLocalEnum GlobalOrLocal { get; set; }

	IEnumerable<IIfcRelConnectsStructuralActivity> AssignedToStructuralItem { get; }
}
