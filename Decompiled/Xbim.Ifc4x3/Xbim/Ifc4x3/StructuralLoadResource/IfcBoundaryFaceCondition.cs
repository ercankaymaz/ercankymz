using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.StructuralLoadResource;

[ExpressType("IfcBoundaryFaceCondition", 674)]
public class IfcBoundaryFaceCondition : IfcBoundaryCondition, IIfcBoundaryFaceCondition, IIfcBoundaryCondition, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcBoundaryFaceCondition>
{
	private IfcModulusOfSubgradeReactionSelect _translationalStiffnessByAreaX;

	private IfcModulusOfSubgradeReactionSelect _translationalStiffnessByAreaY;

	private IfcModulusOfSubgradeReactionSelect _translationalStiffnessByAreaZ;

	[CrossSchemaAttribute(typeof(IIfcBoundaryFaceCondition), 2)]
	IIfcModulusOfSubgradeReactionSelect IIfcBoundaryFaceCondition.TranslationalStiffnessByAreaX
	{
		get
		{
			if (TranslationalStiffnessByAreaX == null)
			{
				return null;
			}
			if (TranslationalStiffnessByAreaX is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)TranslationalStiffnessByAreaX);
			}
			if (TranslationalStiffnessByAreaX is Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)TranslationalStiffnessByAreaX);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				TranslationalStiffnessByAreaX = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				TranslationalStiffnessByAreaX = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				TranslationalStiffnessByAreaX = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryFaceCondition), 3)]
	IIfcModulusOfSubgradeReactionSelect IIfcBoundaryFaceCondition.TranslationalStiffnessByAreaY
	{
		get
		{
			if (TranslationalStiffnessByAreaY == null)
			{
				return null;
			}
			if (TranslationalStiffnessByAreaY is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)TranslationalStiffnessByAreaY);
			}
			if (TranslationalStiffnessByAreaY is Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)TranslationalStiffnessByAreaY);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				TranslationalStiffnessByAreaY = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				TranslationalStiffnessByAreaY = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				TranslationalStiffnessByAreaY = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryFaceCondition), 4)]
	IIfcModulusOfSubgradeReactionSelect IIfcBoundaryFaceCondition.TranslationalStiffnessByAreaZ
	{
		get
		{
			if (TranslationalStiffnessByAreaZ == null)
			{
				return null;
			}
			if (TranslationalStiffnessByAreaZ is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)TranslationalStiffnessByAreaZ);
			}
			if (TranslationalStiffnessByAreaZ is Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)TranslationalStiffnessByAreaZ);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				TranslationalStiffnessByAreaZ = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				TranslationalStiffnessByAreaZ = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				TranslationalStiffnessByAreaZ = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)value);
			}
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
