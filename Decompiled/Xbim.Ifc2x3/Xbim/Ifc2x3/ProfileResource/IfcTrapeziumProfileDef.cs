using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProfileResource;

[ExpressType("IfcTrapeziumProfileDef", 561)]
public class IfcTrapeziumProfileDef : IfcParameterizedProfileDef, IIfcTrapeziumProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcTrapeziumProfileDef>
{
	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _bottomXDim;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _topXDim;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _yDim;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure _topXOffset;

	[CrossSchemaAttribute(typeof(IIfcTrapeziumProfileDef), 4)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcTrapeziumProfileDef.BottomXDim
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(BottomXDim);
		}
		set
		{
			BottomXDim = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTrapeziumProfileDef), 5)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcTrapeziumProfileDef.TopXDim
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(TopXDim);
		}
		set
		{
			TopXDim = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTrapeziumProfileDef), 6)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcTrapeziumProfileDef.YDim
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

	[CrossSchemaAttribute(typeof(IIfcTrapeziumProfileDef), 7)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure IIfcTrapeziumProfileDef.TopXOffset
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(TopXOffset);
		}
		set
		{
			TopXOffset = new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure BottomXDim
	{
		get
		{
			if (_activated)
			{
				return _bottomXDim;
			}
			Activate();
			return _bottomXDim;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_bottomXDim = v;
			}, _bottomXDim, value, "BottomXDim", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure TopXDim
	{
		get
		{
			if (_activated)
			{
				return _topXDim;
			}
			Activate();
			return _topXDim;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_topXDim = v;
			}, _topXDim, value, "TopXDim", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
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
			}, _yDim, value, "YDim", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure TopXOffset
	{
		get
		{
			if (_activated)
			{
				return _topXOffset;
			}
			Activate();
			return _topXOffset;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure v)
			{
				_topXOffset = v;
			}, _topXOffset, value, "TopXOffset", 7);
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

	internal IfcTrapeziumProfileDef(IModel model, int label, bool activated)
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
			_bottomXDim = value.RealVal;
			break;
		case 4:
			_topXDim = value.RealVal;
			break;
		case 5:
			_yDim = value.RealVal;
			break;
		case 6:
			_topXOffset = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTrapeziumProfileDef other)
	{
		return this == other;
	}
}
