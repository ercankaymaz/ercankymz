using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcArbitraryProfileDefWithVoids : IIfcArbitraryClosedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IItemSet<IIfcCurve> InnerCurves { get; }
}
