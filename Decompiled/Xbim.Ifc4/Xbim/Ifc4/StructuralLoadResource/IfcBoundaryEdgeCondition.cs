using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.StructuralLoadResource;

[ExpressType("IfcBoundaryEdgeCondition", 319)]
public class IfcBoundaryEdgeCondition : IfcBoundaryCondition, IInstantiableEntity, IPersistEntity, IPersist, IIfcBoundaryEdgeCondition, IIfcBoundaryCondition, IEquatable<IfcBoundaryEdgeCondition>
{
	private IfcModulusOfTranslationalSubgradeReactionSelect _translationalStiffnessByLengthX;

	private IfcModulusOfTranslationalSubgradeReactionSelect _translationalStiffnessByLengthY;

	private IfcModulusOfTranslationalSubgradeReactionSelect _translationalStiffnessByLengthZ;

	private IfcModulusOfRotationalSubgradeReactionSelect _rotationalStiffnessByLengthX;

	private IfcModulusOfRotationalSubgradeReactionSelect _rotationalStiffnessByLengthY;

	private IfcModulusOfRotationalSubgradeReactionSelect _rotationalStiffnessByLengthZ;

	IIfcModulusOfTranslationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.TranslationalStiffnessByLengthX
	{
		get
		{
			return TranslationalStiffnessByLengthX;
		}
		set
		{
			TranslationalStiffnessByLengthX = value as IfcModulusOfTranslationalSubgradeReactionSelect;
		}
	}

	IIfcModulusOfTranslationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.TranslationalStiffnessByLengthY
	{
		get
		{
			return TranslationalStiffnessByLengthY;
		}
		set
		{
			TranslationalStiffnessByLengthY = value as IfcModulusOfTranslationalSubgradeReactionSelect;
		}
	}

	IIfcModulusOfTranslationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.TranslationalStiffnessByLengthZ
	{
		get
		{
			return TranslationalStiffnessByLengthZ;
		}
		set
		{
			TranslationalStiffnessByLengthZ = value as IfcModulusOfTranslationalSubgradeReactionSelect;
		}
	}

	IIfcModulusOfRotationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.RotationalStiffnessByLengthX
	{
		get
		{
			return RotationalStiffnessByLengthX;
		}
		set
		{
			RotationalStiffnessByLengthX = value as IfcModulusOfRotationalSubgradeReactionSelect;
		}
	}

	IIfcModulusOfRotationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.RotationalStiffnessByLengthY
	{
		get
		{
			return RotationalStiffnessByLengthY;
		}
		set
		{
			RotationalStiffnessByLengthY = value as IfcModulusOfRotationalSubgradeReactionSelect;
		}
	}

	IIfcModulusOfRotationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.RotationalStiffnessByLengthZ
	{
		get
		{
			return RotationalStiffnessByLengthZ;
		}
		set
		{
			RotationalStiffnessByLengthZ = value as IfcModulusOfRotationalSubgradeReactionSelect;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcModulusOfTranslationalSubgradeReactionSelect TranslationalStiffnessByLengthX
	{
		get
		{
			if (_activated)
			{
				return _translationalStiffnessByLengthX;
			}
			Activate();
			return _translationalStiffnessByLengthX;
		}
		set
		{
			SetValue(delegate(IfcModulusOfTranslationalSubgradeReactionSelect v)
			{
				_translationalStiffnessByLengthX = v;
			}, _translationalStiffnessByLengthX, value, "TranslationalStiffnessByLengthX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcModulusOfTranslationalSubgradeReactionSelect TranslationalStiffnessByLengthY
	{
		get
		{
			if (_activated)
			{
				return _translationalStiffnessByLengthY;
			}
			Activate();
			return _translationalStiffnessByLengthY;
		}
		set
		{
			SetValue(delegate(IfcModulusOfTranslationalSubgradeReactionSelect v)
			{
				_translationalStiffnessByLengthY = v;
			}, _translationalStiffnessByLengthY, value, "TranslationalStiffnessByLengthY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcModulusOfTranslationalSubgradeReactionSelect TranslationalStiffnessByLengthZ
	{
		get
		{
			if (_activated)
			{
				return _translationalStiffnessByLengthZ;
			}
			Activate();
			return _translationalStiffnessByLengthZ;
		}
		set
		{
			SetValue(delegate(IfcModulusOfTranslationalSubgradeReactionSelect v)
			{
				_translationalStiffnessByLengthZ = v;
			}, _translationalStiffnessByLengthZ, value, "TranslationalStiffnessByLengthZ", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcModulusOfRotationalSubgradeReactionSelect RotationalStiffnessByLengthX
	{
		get
		{
			if (_activated)
			{
				return _rotationalStiffnessByLengthX;
			}
			Activate();
			return _rotationalStiffnessByLengthX;
		}
		set
		{
			SetValue(delegate(IfcModulusOfRotationalSubgradeReactionSelect v)
			{
				_rotationalStiffnessByLengthX = v;
			}, _rotationalStiffnessByLengthX, value, "RotationalStiffnessByLengthX", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcModulusOfRotationalSubgradeReactionSelect RotationalStiffnessByLengthY
	{
		get
		{
			if (_activated)
			{
				return _rotationalStiffnessByLengthY;
			}
			Activate();
			return _rotationalStiffnessByLengthY;
		}
		set
		{
			SetValue(delegate(IfcModulusOfRotationalSubgradeReactionSelect v)
			{
				_rotationalStiffnessByLengthY = v;
			}, _rotationalStiffnessByLengthY, value, "RotationalStiffnessByLengthY", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcModulusOfRotationalSubgradeReactionSelect RotationalStiffnessByLengthZ
	{
		get
		{
			if (_activated)
			{
				return _rotationalStiffnessByLengthZ;
			}
			Activate();
			return _rotationalStiffnessByLengthZ;
		}
		set
		{
			SetValue(delegate(IfcModulusOfRotationalSubgradeReactionSelect v)
			{
				_rotationalStiffnessByLengthZ = v;
			}, _rotationalStiffnessByLengthZ, value, "RotationalStiffnessByLengthZ", 7);
		}
	}

	internal IfcBoundaryEdgeCondition(IModel model, int label, bool activated)
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
			_translationalStiffnessByLengthX = (IfcModulusOfTranslationalSubgradeReactionSelect)value.EntityVal;
			break;
		case 2:
			_translationalStiffnessByLengthY = (IfcModulusOfTranslationalSubgradeReactionSelect)value.EntityVal;
			break;
		case 3:
			_translationalStiffnessByLengthZ = (IfcModulusOfTranslationalSubgradeReactionSelect)value.EntityVal;
			break;
		case 4:
			_rotationalStiffnessByLengthX = (IfcModulusOfRotationalSubgradeReactionSelect)value.EntityVal;
			break;
		case 5:
			_rotationalStiffnessByLengthY = (IfcModulusOfRotationalSubgradeReactionSelect)value.EntityVal;
			break;
		case 6:
			_rotationalStiffnessByLengthZ = (IfcModulusOfRotationalSubgradeReactionSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBoundaryEdgeCondition other)
	{
		return this == other;
	}
}
