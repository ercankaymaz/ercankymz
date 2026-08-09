using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ProfileResource;

[ExpressType("IfcTrapeziumProfileDef", 561)]
public class IfcTrapeziumProfileDef : IfcParameterizedProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IIfcTrapeziumProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcTrapeziumProfileDef>
{
	private IfcPositiveLengthMeasure _bottomXDim;

	private IfcPositiveLengthMeasure _topXDim;

	private IfcPositiveLengthMeasure _yDim;

	private IfcLengthMeasure _topXOffset;

	IfcPositiveLengthMeasure IIfcTrapeziumProfileDef.BottomXDim
	{
		get
		{
			return BottomXDim;
		}
		set
		{
			BottomXDim = value;
		}
	}

	IfcPositiveLengthMeasure IIfcTrapeziumProfileDef.TopXDim
	{
		get
		{
			return TopXDim;
		}
		set
		{
			TopXDim = value;
		}
	}

	IfcPositiveLengthMeasure IIfcTrapeziumProfileDef.YDim
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

	IfcLengthMeasure IIfcTrapeziumProfileDef.TopXOffset
	{
		get
		{
			return TopXOffset;
		}
		set
		{
			TopXOffset = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveLengthMeasure BottomXDim
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_bottomXDim = v;
			}, _bottomXDim, value, "BottomXDim", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcPositiveLengthMeasure TopXDim
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_topXDim = v;
			}, _topXDim, value, "TopXDim", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
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
			}, _yDim, value, "YDim", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcLengthMeasure TopXOffset
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
			SetValue(delegate(IfcLengthMeasure v)
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
