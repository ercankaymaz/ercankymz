using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.StructuralLoadResource;

[ExpressType("IfcSlippageConnectionCondition", 638)]
public class IfcSlippageConnectionCondition : IfcStructuralConnectionCondition, IInstantiableEntity, IPersistEntity, IPersist, IIfcSlippageConnectionCondition, IIfcStructuralConnectionCondition, IEquatable<IfcSlippageConnectionCondition>
{
	private IfcLengthMeasure? _slippageX;

	private IfcLengthMeasure? _slippageY;

	private IfcLengthMeasure? _slippageZ;

	IfcLengthMeasure? IIfcSlippageConnectionCondition.SlippageX
	{
		get
		{
			return SlippageX;
		}
		set
		{
			SlippageX = value;
		}
	}

	IfcLengthMeasure? IIfcSlippageConnectionCondition.SlippageY
	{
		get
		{
			return SlippageY;
		}
		set
		{
			SlippageY = value;
		}
	}

	IfcLengthMeasure? IIfcSlippageConnectionCondition.SlippageZ
	{
		get
		{
			return SlippageZ;
		}
		set
		{
			SlippageZ = value;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcLengthMeasure? SlippageX
	{
		get
		{
			if (_activated)
			{
				return _slippageX;
			}
			Activate();
			return _slippageX;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_slippageX = v;
			}, _slippageX, value, "SlippageX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLengthMeasure? SlippageY
	{
		get
		{
			if (_activated)
			{
				return _slippageY;
			}
			Activate();
			return _slippageY;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_slippageY = v;
			}, _slippageY, value, "SlippageY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLengthMeasure? SlippageZ
	{
		get
		{
			if (_activated)
			{
				return _slippageZ;
			}
			Activate();
			return _slippageZ;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_slippageZ = v;
			}, _slippageZ, value, "SlippageZ", 4);
		}
	}

	internal IfcSlippageConnectionCondition(IModel model, int label, bool activated)
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
			_slippageX = value.RealVal;
			break;
		case 2:
			_slippageY = value.RealVal;
			break;
		case 3:
			_slippageZ = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSlippageConnectionCondition other)
	{
		return this == other;
	}
}
