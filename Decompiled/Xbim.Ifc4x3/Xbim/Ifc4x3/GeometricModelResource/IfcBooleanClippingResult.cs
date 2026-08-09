using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcBooleanClippingResult", 340)]
public class IfcBooleanClippingResult : IfcBooleanResult, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcBooleanClippingResult>, IIfcBooleanClippingResult, IIfcBooleanResult, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, Xbim.Ifc4.GeometricModelResource.IfcCsgSelect, IIfcCsgSelect
{
	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.FirstOperand != null)
			{
				yield return base.FirstOperand;
			}
			if (base.SecondOperand != null)
			{
				yield return base.SecondOperand;
			}
		}
	}

	internal IfcBooleanClippingResult(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 2u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcBooleanClippingResult other)
	{
		return this == other;
	}
}
