using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.StructuralLoadResource;

[ExpressType("IfcSlippageConnectionCondition", 638)]
public class IfcSlippageConnectionCondition : IfcStructuralConnectionCondition, IIfcSlippageConnectionCondition, IIfcStructuralConnectionCondition, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcSlippageConnectionCondition>
{
	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? _slippageX;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? _slippageY;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? _slippageZ;

	[CrossSchemaAttribute(typeof(IIfcSlippageConnectionCondition), 2)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcSlippageConnectionCondition.SlippageX
	{
		get
		{
			if (!SlippageX.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(SlippageX.Value);
		}
		set
		{
			SlippageX = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSlippageConnectionCondition), 3)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcSlippageConnectionCondition.SlippageY
	{
		get
		{
			if (!SlippageY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(SlippageY.Value);
		}
		set
		{
			SlippageY = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSlippageConnectionCondition), 4)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcSlippageConnectionCondition.SlippageZ
	{
		get
		{
			if (!SlippageZ.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(SlippageZ.Value);
		}
		set
		{
			SlippageZ = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? SlippageX
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? v)
			{
				_slippageX = v;
			}, _slippageX, value, "SlippageX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? SlippageY
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? v)
			{
				_slippageY = v;
			}, _slippageY, value, "SlippageY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? SlippageZ
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? v)
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
