using System.Collections.Generic;
using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPropertySetDefinitionSelect : IExpressSelectType, IPersist
{
	IEnumerable<IIfcPropertySetDefinition> PropertySetDefinitions { get; }
}
