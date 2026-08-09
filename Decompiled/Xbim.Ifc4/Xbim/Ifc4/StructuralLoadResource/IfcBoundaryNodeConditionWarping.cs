using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.StructuralLoadResource;

[ExpressType("IfcBoundaryNodeConditionWarping", 395)]
public class IfcBoundaryNodeConditionWarping : IfcBoundaryNodeCondition, IInstantiableEntity, IPersistEntity, IPersist, IIfcBoundaryNodeConditionWarping, IIfcBoundaryNodeCondition, IIfcBoundaryCondition, IEquatable<IfcBoundaryNodeConditionWarping>
{
	private IfcWarpingStiffnessSelect _warpingStiffness;

	IIfcWarpingStiffnessSelect IIfcBoundaryNodeConditionWarping.WarpingStiffness
	{
		get
		{
			return WarpingStiffness;
		}
		set
		{
			WarpingStiffness = value as IfcWarpingStiffnessSelect;
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
