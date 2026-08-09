using System.Collections.Generic;
using Xbim.Common;

namespace Xbim.Ifc4x3.Kernel;

public interface IfcPropertySetDefinitionSelect : IExpressSelectType, IPersist
{
	IEnumerable<IfcPropertySetDefinition> PropertySetDefinitions { get; }
}
