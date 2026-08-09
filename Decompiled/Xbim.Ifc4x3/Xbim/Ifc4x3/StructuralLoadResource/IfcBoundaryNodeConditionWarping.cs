using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.StructuralLoadResource;

[ExpressType("IfcBoundaryNodeConditionWarping", 395)]
public class IfcBoundaryNodeConditionWarping : IfcBoundaryNodeCondition, IIfcBoundaryNodeConditionWarping, IIfcBoundaryNodeCondition, IIfcBoundaryCondition, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcBoundaryNodeConditionWarping>
{
	private IfcWarpingStiffnessSelect _warpingStiffness;

	[CrossSchemaAttribute(typeof(IIfcBoundaryNodeConditionWarping), 8)]
	IIfcWarpingStiffnessSelect IIfcBoundaryNodeConditionWarping.WarpingStiffness
	{
		get
		{
			if (WarpingStiffness == null)
			{
				return null;
			}
			if (WarpingStiffness is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)WarpingStiffness);
			}
			if (WarpingStiffness is Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure((Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure)(object)WarpingStiffness);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				WarpingStiffness = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				WarpingStiffness = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)
			{
				WarpingStiffness = new Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure((Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)(object)value);
			}
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcWarpingStiffnessSelect WarpingStiffness
	{
		get
		{
			if (_activated)
			{
				return _warpingStiffness;
			}
			Activate();
			return _warpingStiffness;
		}
		set
		{
			SetValue(delegate(IfcWarpingStiffnessSelect v)
			{
				_warpingStiffness = v;
			}, _warpingStiffness, value, "WarpingStiffness", 8);
		}
	}

	internal IfcBoundaryNodeConditionWarping(IModel model, int label, bool activated)
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
		case 5:
		case 6:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_warpingStiffness = (IfcWarpingStiffnessSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBoundaryNodeConditionWarping other)
	{
		return this == other;
	}
}
