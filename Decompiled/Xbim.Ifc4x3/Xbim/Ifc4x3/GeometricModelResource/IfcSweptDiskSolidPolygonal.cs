using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcSweptDiskSolidPolygonal", 1289)]
public class IfcSweptDiskSolidPolygonal : IfcSweptDiskSolid, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcSweptDiskSolidPolygonal>, IIfcSweptDiskSolidPolygonal, IIfcSweptDiskSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell
{
	private Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? _filletRadius;

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? FilletRadius
	{
		get
		{
			if (_activated)
			{
				return _filletRadius;
			}
			Activate();
			return _filletRadius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? v)
			{
				_filletRadius = v;
			}, _filletRadius, value, "FilletRadius", 6);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Directrix != null)
			{
				yield return base.Directrix;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSweptDiskSolidPolygonal), 6)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcSweptDiskSolidPolygonal.FilletRadius
	{
		get
		{
			if (!FilletRadius.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(FilletRadius.Value);
		}
		set
		{
			FilletRadius = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?)null));
		}
	}

	internal IfcSweptDiskSolidPolygonal(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_filletRadius = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSweptDiskSolidPolygonal other)
	{
		return this == other;
	}
}
