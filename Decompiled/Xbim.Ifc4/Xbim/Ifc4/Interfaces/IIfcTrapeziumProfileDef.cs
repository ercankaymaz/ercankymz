using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTrapeziumProfileDef : IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcPositiveLengthMeasure BottomXDim { get; set; }

	IfcPositiveLengthMeasure TopXDim { get; set; }

	IfcPositiveLengthMeasure YDim { get; set; }

	IfcLengthMeasure TopXOffset { get; set; }
}
