using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.StructuralLoadResource;

[ExpressType("IfcBoundaryEdgeCondition", 319)]
public class IfcBoundaryEdgeCondition : IfcBoundaryCondition, IIfcBoundaryEdgeCondition, IIfcBoundaryCondition, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcBoundaryEdgeCondition>
{
	private IfcModulusOfTranslationalSubgradeReactionSelect _translationalStiffnessByLengthX;

	private IfcModulusOfTranslationalSubgradeReactionSelect _translationalStiffnessByLengthY;

	private IfcModulusOfTranslationalSubgradeReactionSelect _translationalStiffnessByLengthZ;

	private IfcModulusOfRotationalSubgradeReactionSelect _rotationalStiffnessByLengthX;

	private IfcModulusOfRotationalSubgradeReactionSelect _rotationalStiffnessByLengthY;

	private IfcModulusOfRotationalSubgradeReactionSelect _rotationalStiffnessByLengthZ;

	[CrossSchemaAttribute(typeof(IIfcBoundaryEdgeCondition), 2)]
	IIfcModulusOfTranslationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.TranslationalStiffnessByLengthX
	{
		get
		{
			if (TranslationalStiffnessByLengthX == null)
			{
				return null;
			}
			if (TranslationalStiffnessByLengthX is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)TranslationalStiffnessByLengthX);
			}
			if (TranslationalStiffnessByLengthX is Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)TranslationalStiffnessByLengthX);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				TranslationalStiffnessByLengthX = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				TranslationalStiffnessByLengthX = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				TranslationalStiffnessByLengthX = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryEdgeCondition), 3)]
	IIfcModulusOfTranslationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.TranslationalStiffnessByLengthY
	{
		get
		{
			if (TranslationalStiffnessByLengthY == null)
			{
				return null;
			}
			if (TranslationalStiffnessByLengthY is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)TranslationalStiffnessByLengthY);
			}
			if (TranslationalStiffnessByLengthY is Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)TranslationalStiffnessByLengthY);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				TranslationalStiffnessByLengthY = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				TranslationalStiffnessByLengthY = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				TranslationalStiffnessByLengthY = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryEdgeCondition), 4)]
	IIfcModulusOfTranslationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.TranslationalStiffnessByLengthZ
	{
		get
		{
			if (TranslationalStiffnessByLengthZ == null)
			{
				return null;
			}
			if (TranslationalStiffnessByLengthZ is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)TranslationalStiffnessByLengthZ);
			}
			if (TranslationalStiffnessByLengthZ is Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)TranslationalStiffnessByLengthZ);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				TranslationalStiffnessByLengthZ = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				TranslationalStiffnessByLengthZ = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				TranslationalStiffnessByLengthZ = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryEdgeCondition), 5)]
	IIfcModulusOfRotationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.RotationalStiffnessByLengthX
	{
		get
		{
			if (RotationalStiffnessByLengthX == null)
			{
				return null;
			}
			if (RotationalStiffnessByLengthX is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)RotationalStiffnessByLengthX);
			}
			if (RotationalStiffnessByLengthX is Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)RotationalStiffnessByLengthX);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				RotationalStiffnessByLengthX = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				RotationalStiffnessByLengthX = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				RotationalStiffnessByLengthX = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryEdgeCondition), 6)]
	IIfcModulusOfRotationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.RotationalStiffnessByLengthY
	{
		get
		{
			if (RotationalStiffnessByLengthY == null)
			{
				return null;
			}
			if (RotationalStiffnessByLengthY is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)RotationalStiffnessByLengthY);
			}
			if (RotationalStiffnessByLengthY is Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)RotationalStiffnessByLengthY);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				RotationalStiffnessByLengthY = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				RotationalStiffnessByLengthY = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				RotationalStiffnessByLengthY = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryEdgeCondition), 7)]
	IIfcModulusOfRotationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.RotationalStiffnessByLengthZ
	{
		get
		{
			if (RotationalStiffnessByLengthZ == null)
			{
				return null;
			}
			if (RotationalStiffnessByLengthZ is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)RotationalStiffnessByLengthZ);
			}
			if (RotationalStiffnessByLengthZ is Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)RotationalStiffnessByLengthZ);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				RotationalStiffnessByLengthZ = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				RotationalStiffnessByLengthZ = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				RotationalStiffnessByLengthZ = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)value);
			}
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
