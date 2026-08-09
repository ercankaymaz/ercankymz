using System.Collections.Generic;
using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcStyleAssignmentSelect : IExpressSelectType, IPersist, IPersistEntity
{
	IEnumerable<IIfcSurfaceStyle> SurfaceStyles { get; }
}
