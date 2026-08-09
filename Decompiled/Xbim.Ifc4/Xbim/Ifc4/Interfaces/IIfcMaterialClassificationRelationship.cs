using System.Collections.Generic;
using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMaterialClassificationRelationship : IPersistEntity, IPersist
{
	IEnumerable<IIfcClassificationSelect> MaterialClassifications { get; }

	IIfcMaterial ClassifiedMaterial { get; set; }
}
