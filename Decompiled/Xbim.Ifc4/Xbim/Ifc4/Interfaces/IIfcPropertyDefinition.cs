using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPropertyDefinition : IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IEnumerable<IIfcRelDeclares> HasContext { get; }

	IEnumerable<IIfcRelAssociates> HasAssociations { get; }
}
