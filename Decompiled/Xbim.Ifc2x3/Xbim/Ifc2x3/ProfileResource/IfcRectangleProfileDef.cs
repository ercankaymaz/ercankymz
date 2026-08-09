using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProfileResource;

[ExpressType("IfcRectangleProfileDef", 103)]
public class IfcRectangleProfileDef : IfcParameterizedProfileDef, IIfcRectangleProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcRectangleProfileDef>
{
	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _xDim;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _yDim;

	[CrossSchemaAttribute(typeof(IIfcRectangleProfileDef), 4)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcRectangleProfileDef.XDim
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(XDim);
		}
		set
		{
			XDim = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRectangleProfileDef), 5)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcRectangleProfileDef.YDim
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(YDim);
		}
		set
		{
			YDim = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure XDim
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_xDim = v;
			}, _xDim, value, "XDim", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure YDim
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
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
