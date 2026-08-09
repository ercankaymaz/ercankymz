using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcBlock", 702)]
public class IfcBlock : IfcCsgPrimitive3D, IInstantiableEntity, IPersistEntity, IPersist, IIfcBlock, IIfcCsgPrimitive3D, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcCsgSelect, IIfcCsgSelect, IContainsEntityReferences, IEquatable<IfcBlock>
{
	private IfcPositiveLengthMeasure _xLength;

	private IfcPositiveLengthMeasure _yLength;

	private IfcPositiveLengthMeasure _zLength;

	IfcPositiveLengthMeasure IIfcBlock.XLength
	{
		get
		{
			return XLength;
		}
		set
		{
			XLength = value;
		}
	}

	IfcPositiveLengthMeasure IIfcBlock.YLength
	{
		get
		{
			return YLength;
		}
		set
		{
			YLength = value;
		}
	}

	IfcPositiveLengthMeasure IIfcBlock.ZLength
	{
		get
		{
			return ZLength;
		}
		set
		{
			ZLength = value;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcPositiveLengthMeasure XLength
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_xLength = v;
			}, _xLength, value, "XLength", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcPositiveLengthMeasure YLength
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_yLength = v;
			}, _yLength, value, "YLength", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveLengthMeasure ZLength
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
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
