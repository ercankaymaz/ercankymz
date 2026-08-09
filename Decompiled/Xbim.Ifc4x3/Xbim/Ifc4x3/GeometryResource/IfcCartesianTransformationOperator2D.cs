using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Common.Geometry;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcCartesianTransformationOperator2D", 145)]
public class IfcCartesianTransformationOperator2D : IfcCartesianTransformationOperator, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcCartesianTransformationOperator2D>, IIfcCartesianTransformationOperator2D, IIfcCartesianTransformationOperator, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 2 }, new int[] { 2 }, 0)]
	public List<XbimVector3D> U
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Axis1 != null)
			{
				yield return base.Axis1;
			}
			if (base.Axis2 != null)
			{
				yield return base.Axis2;
			}
			if (base.LocalOrigin != null)
			{
				yield return base.LocalOrigin;
			}
		}
	}

	List<XbimVector3D> IIfcCartesianTransformationOperator2D.U => U;

	internal IfcCartesianTransformationOperator2D(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 3u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcCartesianTransformationOperator2D other)
	{
		return this == other;
	}
}
