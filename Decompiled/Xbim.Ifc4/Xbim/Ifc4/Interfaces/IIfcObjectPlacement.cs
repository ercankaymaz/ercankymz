using System.Collections.Generic;
using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcObjectPlacement : IPersistEntity, IPersist
{
	IEnumerable<IIfcProduct> PlacesObject { get; }

	IEnumerable<IIfcLocalPlacement> ReferencedByPlacements { get; }
}
