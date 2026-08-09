using System.Collections.Generic;
using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelSpaceBoundary2ndLevel : IIfcRelSpaceBoundary1stLevel, IIfcRelSpaceBoundary, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcRelSpaceBoundary2ndLevel CorrespondingBoundary { get; set; }

	IEnumerable<IIfcRelSpaceBoundary2ndLevel> Corresponds { get; }
}
