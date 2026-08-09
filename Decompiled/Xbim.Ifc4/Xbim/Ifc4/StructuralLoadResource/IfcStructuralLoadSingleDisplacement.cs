using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.StructuralLoadResource;

[ExpressType("IfcStructuralLoadSingleDisplacement", 289)]
public class IfcStructuralLoadSingleDisplacement : IfcStructuralLoadStatic, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralLoadSingleDisplacement, IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IEquatable<IfcStructuralLoadSingleDisplacement>
{
	private IfcLengthMeasure? _displacementX;

	private IfcLengthMeasure? _displacementY;

	private IfcLengthMeasure? _displacementZ;

	private IfcPlaneAngleMeasure? _rotationalDisplacementRX;

	private IfcPlaneAngleMeasure? _rotationalDisplacementRY;

	private IfcPlaneAngleMeasure? _rotationalDisplacementRZ;

	IfcLengthMeasure? IIfcStructuralLoadSingleDisplacement.DisplacementX
	{
		get
		{
			return DisplacementX;
		}
		set
		{
			DisplacementX = value;
		}
	}

	IfcLengthMeasure? IIfcStructuralLoadSingleDisplacement.DisplacementY
	{
		get
		{
			return DisplacementY;
		}
		set
		{
			DisplacementY = value;
		}
	}

	IfcLengthMeasure? IIfcStructuralLoadSingleDisplacement.DisplacementZ
	{
		get
		{
			return DisplacementZ;
		}
		set
		{
			DisplacementZ = value;
		}
	}

	IfcPlaneAngleMeasure? IIfcStructuralLoadSingleDisplacement.RotationalDisplacementRX
	{
		get
		{
			return RotationalDisplacementRX;
		}
		set
		{
			RotationalDisplacementRX = value;
		}
	}

	IfcPlaneAngleMeasure? IIfcStructuralLoadSingleDisplacement.RotationalDisplacementRY
	{
		get
		{
			return RotationalDisplacementRY;
		}
		set
		{
			RotationalDisplacementRY = value;
		}
	}

	IfcPlaneAngleMeasure? IIfcStructuralLoadSingleDisplacement.RotationalDisplacementRZ
	{
		get
		{
			return RotationalDisplacementRZ;
		}
		set
		{
			RotationalDisplacementRZ = value;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcLengthMeasure? DisplacementX
	{
		get
		{
			if (_activated)
			{
				return _displacementX;
			}
			Activate();
			return _displacementX;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_displacementX = v;
			}, _displacementX, value, "DisplacementX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLengthMeasure? DisplacementY
	{
		get
		{
			if (_activated)
			{
				return _displacementY;
			}
			Activate();
			return _displacementY;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_displacementY = v;
			}, _displacementY, value, "DisplacementY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLengthMeasure? DisplacementZ
	{
		get
		{
			if (_activated)
			{
				return _displacementZ;
			}
			Activate();
			return _displacementZ;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_displacementZ = v;
			}, _displacementZ, value, "DisplacementZ", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcPlaneAngleMeasure? RotationalDisplacementRX
	{
		get
		{
			if (_activated)
			{
				return _rotationalDisplacementRX;
			}
			Activate();
			return _rotationalDisplacementRX;
		}
		set
		{
			SetValue(delegate(IfcPlaneAngleMeasure? v)
			{
				_rotationalDisplacementRX = v;
			}, _rotationalDisplacementRX, value, "RotationalDisplacementRX", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPlaneAngleMeasure? RotationalDisplacementRY
	{
		get
		{
			if (_activated)
			{
				return _rotationalDisplacementRY;
			}
			Activate();
			return _rotationalDisplacementRY;
		}
		set
		{
			SetValue(delegate(IfcPlaneAngleMeasure? v)
			{
				_rotationalDisplacementRY = v;
			}, _rotationalDisplacementRY, value, "RotationalDisplacementRY", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcPlaneAngleMeasure? RotationalDisplacementRZ
	{
		get
		{
			if (_activated)
			{
				return _rotationalDisplacementRZ;
			}
			Activate();
			return _rotationalDisplacementRZ;
		}
		set
		{
			SetValue(delegate(IfcPlaneAngleMeasure? v)
			{
				_rotationalDisplacementRZ = v;
			}, _rotationalDisplacementRZ, value, "RotationalDisplacementRZ", 7);
		}
	}

	internal IfcStructuralLoadSingleDisplacement(IModel model, int label, bool activated)
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
			_displacementX = value.RealVal;
			break;
		case 2:
			_displacementY = value.RealVal;
			break;
		case 3:
			_displacementZ = value.RealVal;
			break;
		case 4:
			_rotationalDisplacementRX = value.RealVal;
			break;
		case 5:
			_rotationalDisplacementRY = value.RealVal;
			break;
		case 6:
			_rotationalDisplacementRZ = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralLoadSingleDisplacement other)
	{
		return this == other;
	}
}
