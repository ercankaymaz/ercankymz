using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.StructuralLoadResource;

[ExpressType("IfcBoundaryNodeCondition", 394)]
public class IfcBoundaryNodeCondition : IfcBoundaryCondition, IIfcBoundaryNodeCondition, IIfcBoundaryCondition, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcBoundaryNodeCondition>
{
	private IfcTranslationalStiffnessSelect _translationalStiffnessX;

	private IfcTranslationalStiffnessSelect _translationalStiffnessY;

	private IfcTranslationalStiffnessSelect _translationalStiffnessZ;

	private IfcRotationalStiffnessSelect _rotationalStiffnessX;

	private IfcRotationalStiffnessSelect _rotationalStiffnessY;

	private IfcRotationalStiffnessSelect _rotationalStiffnessZ;

	[CrossSchemaAttribute(typeof(IIfcBoundaryNodeCondition), 2)]
	IIfcTranslationalStiffnessSelect IIfcBoundaryNodeCondition.TranslationalStiffnessX
	{
		get
		{
			if (TranslationalStiffnessX == null)
			{
				return null;
			}
			if (TranslationalStiffnessX is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)TranslationalStiffnessX);
			}
			if (TranslationalStiffnessX is Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure)(object)TranslationalStiffnessX);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				TranslationalStiffnessX = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				TranslationalStiffnessX = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)
			{
				TranslationalStiffnessX = new Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryNodeCondition), 3)]
	IIfcTranslationalStiffnessSelect IIfcBoundaryNodeCondition.TranslationalStiffnessY
	{
		get
		{
			if (TranslationalStiffnessY == null)
			{
				return null;
			}
			if (TranslationalStiffnessY is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)TranslationalStiffnessY);
			}
			if (TranslationalStiffnessY is Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure)(object)TranslationalStiffnessY);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				TranslationalStiffnessY = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				TranslationalStiffnessY = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)
			{
				TranslationalStiffnessY = new Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryNodeCondition), 4)]
	IIfcTranslationalStiffnessSelect IIfcBoundaryNodeCondition.TranslationalStiffnessZ
	{
		get
		{
			if (TranslationalStiffnessZ == null)
			{
				return null;
			}
			if (TranslationalStiffnessZ is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)TranslationalStiffnessZ);
			}
			if (TranslationalStiffnessZ is Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure)(object)TranslationalStiffnessZ);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				TranslationalStiffnessZ = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				TranslationalStiffnessZ = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)
			{
				TranslationalStiffnessZ = new Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryNodeCondition), 5)]
	IIfcRotationalStiffnessSelect IIfcBoundaryNodeCondition.RotationalStiffnessX
	{
		get
		{
			if (RotationalStiffnessX == null)
			{
				return null;
			}
			if (RotationalStiffnessX is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)RotationalStiffnessX);
			}
			if (RotationalStiffnessX is Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure)(object)RotationalStiffnessX);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				RotationalStiffnessX = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				RotationalStiffnessX = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				RotationalStiffnessX = new Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryNodeCondition), 6)]
	IIfcRotationalStiffnessSelect IIfcBoundaryNodeCondition.RotationalStiffnessY
	{
		get
		{
			if (RotationalStiffnessY == null)
			{
				return null;
			}
			if (RotationalStiffnessY is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)RotationalStiffnessY);
			}
			if (RotationalStiffnessY is Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure)(object)RotationalStiffnessY);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				RotationalStiffnessY = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				RotationalStiffnessY = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				RotationalStiffnessY = new Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryNodeCondition), 7)]
	IIfcRotationalStiffnessSelect IIfcBoundaryNodeCondition.RotationalStiffnessZ
	{
		get
		{
			if (RotationalStiffnessZ == null)
			{
				return null;
			}
			if (RotationalStiffnessZ is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)RotationalStiffnessZ);
			}
			if (RotationalStiffnessZ is Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure)(object)RotationalStiffnessZ);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				RotationalStiffnessZ = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				RotationalStiffnessZ = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				RotationalStiffnessZ = new Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)(object)value);
			}
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcTranslationalStiffnessSelect TranslationalStiffnessX
	{
		get
		{
			if (_activated)
			{
				return _translationalStiffnessX;
			}
			Activate();
			return _translationalStiffnessX;
		}
		set
		{
			SetValue(delegate(IfcTranslationalStiffnessSelect v)
			{
				_translationalStiffnessX = v;
			}, _translationalStiffnessX, value, "TranslationalStiffnessX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcTranslationalStiffnessSelect TranslationalStiffnessY
	{
		get
		{
			if (_activated)
			{
				return _translationalStiffnessY;
			}
			Activate();
			return _translationalStiffnessY;
		}
		set
		{
			SetValue(delegate(IfcTranslationalStiffnessSelect v)
			{
				_translationalStiffnessY = v;
			}, _translationalStiffnessY, value, "TranslationalStiffnessY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcTranslationalStiffnessSelect TranslationalStiffnessZ
	{
		get
		{
			if (_activated)
			{
				return _translationalStiffnessZ;
			}
			Activate();
			return _translationalStiffnessZ;
		}
		set
		{
			SetValue(delegate(IfcTranslationalStiffnessSelect v)
			{
				_translationalStiffnessZ = v;
			}, _translationalStiffnessZ, value, "TranslationalStiffnessZ", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcRotationalStiffnessSelect RotationalStiffnessX
	{
		get
		{
			if (_activated)
			{
				return _rotationalStiffnessX;
			}
			Activate();
			return _rotationalStiffnessX;
		}
		set
		{
			SetValue(delegate(IfcRotationalStiffnessSelect v)
			{
				_rotationalStiffnessX = v;
			}, _rotationalStiffnessX, value, "RotationalStiffnessX", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcRotationalStiffnessSelect RotationalStiffnessY
	{
		get
		{
			if (_activated)
			{
				return _rotationalStiffnessY;
			}
			Activate();
			return _rotationalStiffnessY;
		}
		set
		{
			SetValue(delegate(IfcRotationalStiffnessSelect v)
			{
				_rotationalStiffnessY = v;
			}, _rotationalStiffnessY, value, "RotationalStiffnessY", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcRotationalStiffnessSelect RotationalStiffnessZ
	{
		get
		{
			if (_activated)
			{
				return _rotationalStiffnessZ;
			}
			Activate();
			return _rotationalStiffnessZ;
		}
		set
		{
			SetValue(delegate(IfcRotationalStiffnessSelect v)
			{
				_rotationalStiffnessZ = v;
			}, _rotationalStiffnessZ, value, "RotationalStiffnessZ", 7);
		}
	}

	internal IfcBoundaryNodeCondition(IModel model, int label, bool activated)
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
			_translationalStiffnessX = (IfcTranslationalStiffnessSelect)value.EntityVal;
			break;
		case 2:
			_translationalStiffnessY = (IfcTranslationalStiffnessSelect)value.EntityVal;
			break;
		case 3:
			_translationalStiffnessZ = (IfcTranslationalStiffnessSelect)value.EntityVal;
			break;
		case 4:
			_rotationalStiffnessX = (IfcRotationalStiffnessSelect)value.EntityVal;
			break;
		case 5:
			_rotationalStiffnessY = (IfcRotationalStiffnessSelect)value.EntityVal;
			break;
		case 6:
			_rotationalStiffnessZ = (IfcRotationalStiffnessSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBoundaryNodeCondition other)
	{
		return this == other;
	}
}
