using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcGeometricSet", 236)]
public class IfcGeometricSet : Xbim.Ifc4x3.GeometryResource.IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcGeometricSet>, IIfcGeometricSet, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	private readonly ItemSet<IfcGeometricSetSelect> _elements;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<IfcGeometricSetSelect> Elements
	{
		get
		{
			if (_activated)
			{
				return _elements;
			}
			Activate();
			return _elements;
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc4x3.GeometryResource.IfcDimensionCount Dim
	{
		get
		{
			IfcGeometricSetSelect ifcGeometricSetSelect = Elements.FirstOrDefault();
			if (ifcGeometricSetSelect == null)
			{
				return default(Xbim.Ifc4x3.GeometryResource.IfcDimensionCount);
			}
			if (ifcGeometricSetSelect is Xbim.Ifc4x3.GeometryResource.IfcCartesianPoint ifcCartesianPoint)
			{
				return ifcCartesianPoint.Dim;
			}
			if (ifcGeometricSetSelect is Xbim.Ifc4x3.GeometryResource.IfcPointOnCurve ifcPointOnCurve)
			{
				return ifcPointOnCurve.Dim;
			}
			if (ifcGeometricSetSelect is Xbim.Ifc4x3.GeometryResource.IfcPointOnSurface ifcPointOnSurface)
			{
				return ifcPointOnSurface.Dim;
			}
			if (ifcGeometricSetSelect is Xbim.Ifc4x3.GeometryResource.IfcCurve ifcCurve)
			{
				return ifcCurve.Dim;
			}
			if (ifcGeometricSetSelect is Xbim.Ifc4x3.GeometryResource.IfcSurface ifcSurface)
			{
				return ifcSurface.Dim;
			}
			throw new NotSupportedException();
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcGeometricSetSelect element in Elements)
			{
				yield return element;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcGeometricSet), 1)]
	IItemSet<IIfcGeometricSetSelect> IIfcGeometricSet.Elements => new ProxyItemSet<IfcGeometricSetSelect, IIfcGeometricSetSelect>(Elements);

	Xbim.Ifc4.GeometryResource.IfcDimensionCount IIfcGeometricSet.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

	internal IfcGeometricSet(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_elements = new ItemSet<IfcGeometricSetSelect>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_elements.InternalAdd((IfcGeometricSetSelect)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcGeometricSet other)
	{
		return this == other;
	}
}
