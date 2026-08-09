using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.StructuralLoadResource;

[ExpressType("IfcBoundaryFaceCondition", 674)]
public class IfcBoundaryFaceCondition : IfcBoundaryCondition, IInstantiableEntity, IPersistEntity, IPersist, IIfcBoundaryFaceCondition, IIfcBoundaryCondition, IEquatable<IfcBoundaryFaceCondition>
{
	private IfcModulusOfSubgradeReactionSelect _translationalStiffnessByAreaX;

	private IfcModulusOfSubgradeReactionSelect _translationalStiffnessByAreaY;

	private IfcModulusOfSubgradeReactionSelect _translationalStiffnessByAreaZ;

	IIfcModulusOfSubgradeReactionSelect IIfcBoundaryFaceCondition.TranslationalStiffnessByAreaX
	{
		get
		{
			return TranslationalStiffnessByAreaX;
		}
		set
		{
			TranslationalStiffnessByAreaX = value as IfcModulusOfSubgradeReactionSelect;
		}
	}

	IIfcModulusOfSubgradeReactionSelect IIfcBoundaryFaceCondition.TranslationalStiffnessByAreaY
	{
		get
		{
			return TranslationalStiffnessByAreaY;
		}
		set
		{
			TranslationalStiffnessByAreaY = value as IfcModulusOfSubgradeReactionSelect;
		}
	}

	IIfcModulusOfSubgradeReactionSelect IIfcBoundaryFaceCondition.TranslationalStiffnessByAreaZ
	{
		get
		{
			return TranslationalStiffnessByAreaZ;
		}
		set
		{
			TranslationalStiffnessByAreaZ = value as IfcModulusOfSubgradeReactionSelect;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcModulusOfSubgradeReactionSelect TranslationalStiffnessByAreaX
	{
		get
		{
			if (_activated)
			{
				return _translationalStiffnessByAreaX;
			}
			Activate();
			return _translationalStiffnessByAreaX;
		}
		set
		{
			SetValue(delegate(IfcModulusOfSubgradeReactionSelect v)
			{
				_translationalStiffnessByAreaX = v;
			}, _translationalStiffnessByAreaX, value, "TranslationalStiffnessByAreaX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcModulusOfSubgradeReactionSelect TranslationalStiffnessByAreaY
	{
		get
		{
			if (_activated)
			{
				return _translationalStiffnessByAreaY;
			}
			Activate();
			return _translationalStiffnessByAreaY;
		}
		set
		{
			SetValue(delegate(IfcModulusOfSubgradeReactionSelect v)
			{
				_translationalStiffnessByAreaY = v;
			}, _translationalStiffnessByAreaY, value, "TranslationalStiffnessByAreaY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcModulusOfSubgradeReactionSelect TranslationalStiffnessByAreaZ
	{
		get
		{
			if (_activated)
			{
				return _translationalStiffnessByAreaZ;
			}
			Activate();
			return _translationalStiffnessByAreaZ;
		}
		set
		{
			SetValue(delegate(IfcModulusOfSubgradeReactionSelect v)
			{
				_translationalStiffnessByAreaZ = v;
			}, _translationalStiffnessByAreaZ, value, "TranslationalStiffnessByAreaZ", 4);
		}
	}

	internal IfcBoundaryFaceCondition(IModel model, int label, bool activated)
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
			_translationalStiffnessByAreaX = (IfcModulusOfSubgradeReactionSelect)value.EntityVal;
			break;
		case 2:
			_translationalStiffnessByAreaY = (IfcModulusOfSubgradeReactionSelect)value.EntityVal;
			break;
		case 3:
			_translationalStiffnessByAreaZ = (IfcModulusOfSubgradeReactionSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBoundaryFaceCondition other)
	{
		return this == other;
	}
}
