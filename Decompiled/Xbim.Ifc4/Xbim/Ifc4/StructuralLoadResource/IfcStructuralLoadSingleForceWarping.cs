using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.StructuralLoadResource;

[ExpressType("IfcStructuralLoadSingleForceWarping", 393)]
public class IfcStructuralLoadSingleForceWarping : IfcStructuralLoadSingleForce, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralLoadSingleForceWarping, IIfcStructuralLoadSingleForce, IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IEquatable<IfcStructuralLoadSingleForceWarping>
{
	private IfcWarpingMomentMeasure? _warpingMoment;

	IfcWarpingMomentMeasure? IIfcStructuralLoadSingleForceWarping.WarpingMoment
	{
		get
		{
			return WarpingMoment;
		}
		set
		{
			WarpingMoment = value;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcWarpingMomentMeasure? WarpingMoment
	{
		get
		{
			if (_activated)
			{
				return _warpingMoment;
			}
			Activate();
			return _warpingMoment;
		}
		set
		{
			SetValue(delegate(IfcWarpingMomentMeasure? v)
			{
				_warpingMoment = v;
			}, _warpingMoment, value, "WarpingMoment", 8);
		}
	}

	internal IfcStructuralLoadSingleForceWarping(IModel model, int label, bool activated)
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
			_warpingMoment = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralLoadSingleForceWarping other)
	{
		return this == other;
	}
}
