using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ProfileResource;

[ExpressType("IfcRectangleProfileDef", 103)]
public class IfcRectangleProfileDef : IfcParameterizedProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IIfcRectangleProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcRectangleProfileDef>
{
	private IfcPositiveLengthMeasure _xDim;

	private IfcPositiveLengthMeasure _yDim;

	IfcPositiveLengthMeasure IIfcRectangleProfileDef.XDim
	{
		get
		{
			return XDim;
		}
		set
		{
			XDim = value;
		}
	}

	IfcPositiveLengthMeasure IIfcRectangleProfileDef.YDim
	{
		get
		{
			return YDim;
		}
		set
		{
			YDim = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveLengthMeasure XDim
	{
		get
		{
			if (_activated)
			{
				return _xDim;
			}
			Activate();
			return _xDim;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_xDim = v;
			}, _xDim, value, "XDim", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcPositiveLengthMeasure YDim
	{
		get
		{
			if (_activated)
			{
				return _yDim;
			}
			Activate();
			return _yDim;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_yDim = v;
			}, _yDim, value, "YDim", 5);
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

	internal IfcRectangleProfileDef(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_xDim = value.RealVal;
			break;
		case 4:
			_yDim = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRectangleProfileDef other)
	{
		return this == other;
	}
}
