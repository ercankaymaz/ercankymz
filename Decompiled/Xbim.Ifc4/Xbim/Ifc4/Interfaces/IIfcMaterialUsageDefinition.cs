using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.MaterialResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMaterialUsageDefinition : IPersistEntity, IPersist, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType
{
	IEnumerable<IIfcRelAssociatesMaterial> AssociatedTo { get; }
}
