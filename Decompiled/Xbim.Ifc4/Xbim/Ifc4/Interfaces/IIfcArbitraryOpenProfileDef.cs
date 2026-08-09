using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcArbitraryOpenProfileDef : IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IIfcBoundedCurve Curve { get; set; }
}
