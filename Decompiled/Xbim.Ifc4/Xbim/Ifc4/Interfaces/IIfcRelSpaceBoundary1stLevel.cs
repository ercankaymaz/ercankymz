using System.Collections.Generic;
using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelSpaceBoundary1stLevel : IIfcRelSpaceBoundary, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcRelSpaceBoundary1stLevel ParentBoundary { get; set; }

	IEnumerable<IIfcRelSpaceBoundary1stLevel> InnerBoundaries { get; }
}
