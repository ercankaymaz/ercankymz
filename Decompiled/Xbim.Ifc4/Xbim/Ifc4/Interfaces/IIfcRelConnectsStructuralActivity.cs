using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelConnectsStructuralActivity : IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcStructuralActivityAssignmentSelect RelatingElement { get; set; }

	IIfcStructuralActivity RelatedStructuralActivity { get; set; }
}
