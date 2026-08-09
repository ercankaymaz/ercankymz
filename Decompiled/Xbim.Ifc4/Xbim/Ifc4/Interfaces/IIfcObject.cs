using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcObject : IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IfcLabel? ObjectType { get; set; }

	IEnumerable<IIfcRelDefinesByObject> IsDeclaredBy { get; }

	IEnumerable<IIfcRelDefinesByObject> Declares { get; }

	IEnumerable<IIfcRelDefinesByType> IsTypedBy { get; }

	IEnumerable<IIfcRelDefinesByProperties> IsDefinedBy { get; }
}
