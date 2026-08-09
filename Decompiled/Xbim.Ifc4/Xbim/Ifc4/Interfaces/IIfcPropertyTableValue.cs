using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPropertyTableValue : IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IItemSet<IIfcValue> DefiningValues { get; }

	IItemSet<IIfcValue> DefinedValues { get; }

	IfcText? Expression { get; set; }

	IIfcUnit DefiningUnit { get; set; }

	IIfcUnit DefinedUnit { get; set; }

	IfcCurveInterpolationEnum? CurveInterpolation { get; set; }
}
