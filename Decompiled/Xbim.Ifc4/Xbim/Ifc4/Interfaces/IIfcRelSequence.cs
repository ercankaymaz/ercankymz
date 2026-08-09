using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelSequence : IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcProcess RelatingProcess { get; set; }

	IIfcProcess RelatedProcess { get; set; }

	IIfcLagTime TimeLag { get; set; }

	IfcSequenceEnum? SequenceType { get; set; }

	IfcLabel? UserDefinedSequenceType { get; set; }
}
