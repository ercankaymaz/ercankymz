using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.StructuralLoadResource;

[ExpressType("IfcStructuralLoadSingleDisplacement", 289)]
public class IfcStructuralLoadSingleDisplacement : IfcStructuralLoadStatic, IIfcStructuralLoadSingleDisplacement, IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcStructuralLoadSingleDisplacement>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? _displacementX;

	private Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? _displacementY;

	private Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? _displacementZ;

	private Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? _rotationalDisplacementRX;

	private Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? _rotationalDisplacementRY;

	private Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? _rotationalDisplacementRZ;

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadSingleDisplacement), 2)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcStructuralLoadSingleDisplacement.DisplacementX
	{
		get
		{
			if (!DisplacementX.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(DisplacementX.Value);
		}
		set
		{
			DisplacementX = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadSingleDisplacement), 3)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcStructuralLoadSingleDisplacement.DisplacementY
	{
		get
		{
			if (!DisplacementY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(DisplacementY.Value);
		}
		set
		{
			DisplacementY = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadSingleDisplacement), 4)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcStructuralLoadSingleDisplacement.DisplacementZ
	{
		get
		{
			if (!DisplacementZ.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(DisplacementZ.Value);
		}
		set
		{
			DisplacementZ = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadSingleDisplacement), 5)]
	Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? IIfcStructuralLoadSingleDisplacement.RotationalDisplacementRX
	{
		get
		{
			if (!RotationalDisplacementRX.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure(RotationalDisplacementRX.Value);
		}
		set
		{
			RotationalDisplacementRX = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadSingleDisplacement), 6)]
	Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? IIfcStructuralLoadSingleDisplacement.RotationalDisplacementRY
	{
		get
		{
			if (!RotationalDisplacementRY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure(RotationalDisplacementRY.Value);
		}
		set
		{
			RotationalDisplacementRY = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadSingleDisplacement), 7)]
	Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? IIfcStructuralLoadSingleDisplacement.RotationalDisplacementRZ
	{
		get
		{
			if (!RotationalDisplacementRZ.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure(RotationalDisplacementRZ.Value);
		}
		set
		{
			RotationalDisplacementRZ = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure?)null));
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? DisplacementX
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? v)
			{
				_displacementX = v;
			}, _displacementX, value, "DisplacementX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? DisplacementY
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? v)
			{
				_displacementY = v;
			}, _displacementY, value, "DisplacementY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? DisplacementZ
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? v)
			{
				_displacementZ = v;
			}, _displacementZ, value, "DisplacementZ", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? RotationalDisplacementRX
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? v)
			{
				_rotationalDisplacementRX = v;
			}, _rotationalDisplacementRX, value, "RotationalDisplacementRX", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? RotationalDisplacementRY
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? v)
			{
				_rotationalDisplacementRY = v;
			}, _rotationalDisplacementRY, value, "RotationalDisplacementRY", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? RotationalDisplacementRZ
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? v)
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
