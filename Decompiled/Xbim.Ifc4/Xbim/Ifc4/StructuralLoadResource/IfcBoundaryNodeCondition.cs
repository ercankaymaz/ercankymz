using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.StructuralLoadResource;

[ExpressType("IfcBoundaryNodeCondition", 394)]
public class IfcBoundaryNodeCondition : IfcBoundaryCondition, IInstantiableEntity, IPersistEntity, IPersist, IIfcBoundaryNodeCondition, IIfcBoundaryCondition, IEquatable<IfcBoundaryNodeCondition>
{
	private IfcTranslationalStiffnessSelect _translationalStiffnessX;

	private IfcTranslationalStiffnessSelect _translationalStiffnessY;

	private IfcTranslationalStiffnessSelect _translationalStiffnessZ;

	private IfcRotationalStiffnessSelect _rotationalStiffnessX;

	private IfcRotationalStiffnessSelect _rotationalStiffnessY;

	private IfcRotationalStiffnessSelect _rotationalStiffnessZ;

	IIfcTranslationalStiffnessSelect IIfcBoundaryNodeCondition.TranslationalStiffnessX
	{
		get
		{
			return TranslationalStiffnessX;
		}
		set
		{
			TranslationalStiffnessX = value as IfcTranslationalStiffnessSelect;
		}
	}

	IIfcTranslationalStiffnessSelect IIfcBoundaryNodeCondition.TranslationalStiffnessY
	{
		get
		{
			return TranslationalStiffnessY;
		}
		set
		{
			TranslationalStiffnessY = value as IfcTranslationalStiffnessSelect;
		}
	}

	IIfcTranslationalStiffnessSelect IIfcBoundaryNodeCondition.TranslationalStiffnessZ
	{
		get
		{
			return TranslationalStiffnessZ;
		}
		set
		{
			TranslationalStiffnessZ = value as IfcTranslationalStiffnessSelect;
		}
	}

	IIfcRotationalStiffnessSelect IIfcBoundaryNodeCondition.RotationalStiffnessX
	{
		get
		{
			return RotationalStiffnessX;
		}
		set
		{
			RotationalStiffnessX = value as IfcRotationalStiffnessSelect;
		}
	}

	IIfcRotationalStiffnessSelect IIfcBoundaryNodeCondition.RotationalStiffnessY
	{
		get
		{
			return RotationalStiffnessY;
		}
		set
		{
			RotationalStiffnessY = value as IfcRotationalStiffnessSelect;
		}
	}

	IIfcRotationalStiffnessSelect IIfcBoundaryNodeCondition.RotationalStiffnessZ
	{
		get
		{
			return RotationalStiffnessZ;
		}
		set
		{
			RotationalStiffnessZ = value as IfcRotationalStiffnessSelect;
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
