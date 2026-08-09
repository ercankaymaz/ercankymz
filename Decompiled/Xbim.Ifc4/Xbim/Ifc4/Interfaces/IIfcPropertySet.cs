using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPropertySet : IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect
{
	IItemSet<IIfcProperty> HasProperties { get; }
}
