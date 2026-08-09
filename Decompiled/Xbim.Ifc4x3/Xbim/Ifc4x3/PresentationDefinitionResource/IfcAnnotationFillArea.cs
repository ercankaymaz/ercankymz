using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.PresentationDefinitionResource;

[ExpressType("IfcAnnotationFillArea", 173)]
public class IfcAnnotationFillArea : IfcGeometricRepresentationItem, IIfcAnnotationFillArea, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcAnnotationFillArea>
{
	private IfcCurve _outerBoundary;

	private readonly OptionalItemSet<IfcCurve> _innerBoundaries;

	[CrossSchemaAttribute(typeof(IIfcAnnotationFillArea), 1)]
	IIfcCurve IIfcAnnotationFillArea.OuterBoundary
	{
		get
		{
			return OuterBoundary;
		}
		set
		{
			OuterBoundary = value as IfcCurve;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAnnotationFillArea), 2)]
	IItemSet<IIfcCurve> IIfcAnnotationFillArea.InnerBoundaries => new ProxyItemSet<IfcCurve, IIfcCurve>(InnerBoundaries);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCurve OuterBoundary
	{
		get
		{
			if (_activated)
			{
				return _outerBoundary;
			}
			Activate();
			return _outerBoundary;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_outerBoundary = v;
			}, _outerBoundary, value, "OuterBoundary", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IOptionalItemSet<IfcCurve> InnerBoundaries
	{
		get
		{
			if (_activated)
			{
				return _innerBoundaries;
			}
			Activate();
			return _innerBoundaries;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (OuterBoundary != null)
			{
				yield return OuterBoundary;
			}
			foreach (IfcCurve innerBoundary in InnerBoundaries)
			{
				yield return innerBoundary;
			}
		}
	}

	internal IfcAnnotationFillArea(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_innerBoundaries = new OptionalItemSet<IfcCurve>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_outerBoundary = (IfcCurve)value.EntityVal;
			break;
		case 1:
			_innerBoundaries.InternalAdd((IfcCurve)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAnnotationFillArea other)
	{
		return this == other;
	}
}
