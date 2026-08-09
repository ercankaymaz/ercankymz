using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcGeometricCurveSet", 237)]
public class IfcGeometricCurveSet : IfcGeometricSet, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcGeometricCurveSet>, IIfcGeometricCurveSet, IIfcGeometricSet, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcGeometricSetSelect element in base.Elements)
			{
				yield return element;
			}
		}
	}

	internal IfcGeometricCurveSet(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcGeometricCurveSet other)
	{
		return this == other;
	}
}
