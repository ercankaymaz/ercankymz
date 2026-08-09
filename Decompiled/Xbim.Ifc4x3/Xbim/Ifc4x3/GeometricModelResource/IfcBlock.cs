using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcBlock", 702)]
public class IfcBlock : IfcCsgPrimitive3D, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcBlock>, IIfcBlock, IIfcCsgPrimitive3D, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, Xbim.Ifc4.GeometricModelResource.IfcCsgSelect, IIfcCsgSelect
{
	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _xLength;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _yLength;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _zLength;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure XLength
	{
		get
		{
			if (_activated)
			{
				return _xLength;
			}
			Activate();
			return _xLength;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_xLength = v;
			}, _xLength, value, "XLength", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure YLength
	{
		get
		{
			if (_activated)
			{
				return _yLength;
			}
			Activate();
			return _yLength;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_yLength = v;
			}, _yLength, value, "YLength", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure ZLength
	{
		get
		{
			if (_activated)
			{
				return _zLength;
			}
			Activate();
			return _zLength;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_zLength = v;
			}, _zLength, value, "ZLength", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Position != null)
			{
				yield return base.Position;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBlock), 2)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcBlock.XLength
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(XLength);
		}
		set
		{
			XLength = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBlock), 3)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcBlock.YLength
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(YLength);
		}
		set
		{
			YLength = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBlock), 4)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcBlock.ZLength
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(ZLength);
		}
		set
		{
			ZLength = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	internal IfcBlock(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_xLength = value.RealVal;
			break;
		case 2:
			_yLength = value.RealVal;
			break;
		case 3:
			_zLength = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBlock other)
	{
		return this == other;
	}
}
