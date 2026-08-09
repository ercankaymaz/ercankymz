using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.StructuralLoadResource;

[ExpressType("IfcBoundaryNodeConditionWarping", 395)]
public class IfcBoundaryNodeConditionWarping : IfcBoundaryNodeCondition, IIfcBoundaryNodeConditionWarping, IIfcBoundaryNodeCondition, IIfcBoundaryCondition, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcBoundaryNodeConditionWarping>
{
	private IIfcWarpingStiffnessSelect _warpingStiffness4;

	private Xbim.Ifc2x3.MeasureResource.IfcWarpingMomentMeasure? _warpingStiffness;

	[CrossSchemaAttribute(typeof(IIfcBoundaryNodeConditionWarping), 8)]
	IIfcWarpingStiffnessSelect IIfcBoundaryNodeConditionWarping.WarpingStiffness
	{
		get
		{
			if (_warpingStiffness4 != null)
			{
				return _warpingStiffness4;
			}
			Xbim.Ifc2x3.MeasureResource.IfcWarpingMomentMeasure? warpingStiffness = WarpingStiffness;
			if (!warpingStiffness.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure(warpingStiffness.Value);
		}
		set
		{
			if (value == null)
			{
				WarpingStiffness = null;
				if (_warpingStiffness4 != null)
				{
					SetValue(delegate(IIfcWarpingStiffnessSelect v)
					{
						_warpingStiffness4 = v;
					}, _warpingStiffness4, null, "WarpingStiffness", -8);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)
			{
				WarpingStiffness = new Xbim.Ifc2x3.MeasureResource.IfcWarpingMomentMeasure((Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)(object)value);
				if (_warpingStiffness4 != null)
				{
					SetValue(delegate(IIfcWarpingStiffnessSelect v)
					{
						_warpingStiffness4 = v;
					}, _warpingStiffness4, null, "WarpingStiffness", -8);
				}
			}
			else
			{
				SetValue(delegate(IIfcWarpingStiffnessSelect v)
				{
					_warpingStiffness4 = v;
				}, _warpingStiffness4, value, "WarpingStiffness", -8);
			}
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc2x3.MeasureResource.IfcWarpingMomentMeasure? WarpingStiffness
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcWarpingMomentMeasure? v)
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
			_warpingStiffness = value.RealVal;
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
