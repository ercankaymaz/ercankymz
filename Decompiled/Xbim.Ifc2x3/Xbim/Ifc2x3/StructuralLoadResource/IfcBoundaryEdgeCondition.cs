using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.StructuralLoadResource;

[ExpressType("IfcBoundaryEdgeCondition", 319)]
public class IfcBoundaryEdgeCondition : IfcBoundaryCondition, IIfcBoundaryEdgeCondition, IIfcBoundaryCondition, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcBoundaryEdgeCondition>
{
	private IIfcModulusOfTranslationalSubgradeReactionSelect _translationalStiffnessByLengthX;

	private IIfcModulusOfTranslationalSubgradeReactionSelect _translationalStiffnessByLengthY;

	private IIfcModulusOfTranslationalSubgradeReactionSelect _translationalStiffnessByLengthZ;

	private IIfcModulusOfRotationalSubgradeReactionSelect _rotationalStiffnessByLengthX4;

	private IIfcModulusOfRotationalSubgradeReactionSelect _rotationalStiffnessByLengthY4;

	private IIfcModulusOfRotationalSubgradeReactionSelect _rotationalStiffnessByLengthZ4;

	private Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure? _linearStiffnessByLengthX;

	private Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure? _linearStiffnessByLengthY;

	private Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure? _linearStiffnessByLengthZ;

	private Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure? _rotationalStiffnessByLengthX;

	private Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure? _rotationalStiffnessByLengthY;

	private Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure? _rotationalStiffnessByLengthZ;

	[CrossSchemaAttribute(typeof(IIfcBoundaryEdgeCondition), 2)]
	IIfcModulusOfTranslationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.TranslationalStiffnessByLengthX
	{
		get
		{
			if (_translationalStiffnessByLengthX != null)
			{
				return _translationalStiffnessByLengthX;
			}
			Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure? linearStiffnessByLengthX = LinearStiffnessByLengthX;
			if (!linearStiffnessByLengthX.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure(linearStiffnessByLengthX.Value);
		}
		set
		{
			if (value == null)
			{
				LinearStiffnessByLengthX = null;
				if (_translationalStiffnessByLengthX != null)
				{
					SetValue(delegate(IIfcModulusOfTranslationalSubgradeReactionSelect v)
					{
						_translationalStiffnessByLengthX = v;
					}, _translationalStiffnessByLengthX, null, "TranslationalStiffnessByLengthX", -2);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				LinearStiffnessByLengthX = new Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)value);
				if (_translationalStiffnessByLengthX != null)
				{
					SetValue(delegate(IIfcModulusOfTranslationalSubgradeReactionSelect v)
					{
						_translationalStiffnessByLengthX = v;
					}, _translationalStiffnessByLengthX, null, "TranslationalStiffnessByLengthX", -2);
				}
			}
			else
			{
				SetValue(delegate(IIfcModulusOfTranslationalSubgradeReactionSelect v)
				{
					_translationalStiffnessByLengthX = v;
				}, _translationalStiffnessByLengthX, value, "TranslationalStiffnessByLengthX", -2);
				NotifyPropertyChanged("TranslationalStiffnessByLengthX");
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryEdgeCondition), 3)]
	IIfcModulusOfTranslationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.TranslationalStiffnessByLengthY
	{
		get
		{
			if (_translationalStiffnessByLengthY != null)
			{
				return _translationalStiffnessByLengthY;
			}
			Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure? linearStiffnessByLengthY = LinearStiffnessByLengthY;
			if (!linearStiffnessByLengthY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure(linearStiffnessByLengthY.Value);
		}
		set
		{
			if (value == null)
			{
				LinearStiffnessByLengthY = null;
				if (_translationalStiffnessByLengthY != null)
				{
					SetValue(delegate(IIfcModulusOfTranslationalSubgradeReactionSelect v)
					{
						_translationalStiffnessByLengthY = v;
					}, _translationalStiffnessByLengthY, null, "LinearStiffnessByLengthY", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				LinearStiffnessByLengthY = new Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)value);
				if (_translationalStiffnessByLengthY != null)
				{
					SetValue(delegate(IIfcModulusOfTranslationalSubgradeReactionSelect v)
					{
						_translationalStiffnessByLengthY = v;
					}, _translationalStiffnessByLengthY, null, "LinearStiffnessByLengthY", -3);
				}
			}
			else
			{
				SetValue(delegate(IIfcModulusOfTranslationalSubgradeReactionSelect v)
				{
					_translationalStiffnessByLengthY = v;
				}, _translationalStiffnessByLengthY, value, "LinearStiffnessByLengthY", -3);
				NotifyPropertyChanged("TranslationalStiffnessByLengthY");
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryEdgeCondition), 4)]
	IIfcModulusOfTranslationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.TranslationalStiffnessByLengthZ
	{
		get
		{
			if (_translationalStiffnessByLengthZ != null)
			{
				return _translationalStiffnessByLengthZ;
			}
			Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure? linearStiffnessByLengthZ = LinearStiffnessByLengthZ;
			if (!linearStiffnessByLengthZ.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure(linearStiffnessByLengthZ.Value);
		}
		set
		{
			if (value == null)
			{
				LinearStiffnessByLengthZ = null;
				if (_translationalStiffnessByLengthZ != null)
				{
					SetValue(delegate(IIfcModulusOfTranslationalSubgradeReactionSelect v)
					{
						_translationalStiffnessByLengthZ = v;
					}, _translationalStiffnessByLengthZ, null, "TranslationalStiffnessByLengthZ", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				LinearStiffnessByLengthZ = new Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)value);
				if (_translationalStiffnessByLengthZ != null)
				{
					SetValue(delegate(IIfcModulusOfTranslationalSubgradeReactionSelect v)
					{
						_translationalStiffnessByLengthZ = v;
					}, _translationalStiffnessByLengthZ, null, "TranslationalStiffnessByLengthZ", -4);
				}
			}
			else
			{
				SetValue(delegate(IIfcModulusOfTranslationalSubgradeReactionSelect v)
				{
					_translationalStiffnessByLengthZ = v;
				}, _translationalStiffnessByLengthZ, value, "TranslationalStiffnessByAreaZ", -4);
				NotifyPropertyChanged("TranslationalStiffnessByLengthZ");
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryEdgeCondition), 5)]
	IIfcModulusOfRotationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.RotationalStiffnessByLengthX
	{
		get
		{
			if (_rotationalStiffnessByLengthX4 != null)
			{
				return _rotationalStiffnessByLengthX4;
			}
			Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure? rotationalStiffnessByLengthX = RotationalStiffnessByLengthX;
			if (!rotationalStiffnessByLengthX.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure(rotationalStiffnessByLengthX.Value);
		}
		set
		{
			if (value == null)
			{
				RotationalStiffnessByLengthX = null;
				if (_rotationalStiffnessByLengthX4 != null)
				{
					SetValue(delegate(IIfcModulusOfRotationalSubgradeReactionSelect v)
					{
						_rotationalStiffnessByLengthX4 = v;
					}, _rotationalStiffnessByLengthX4, null, "TranslationalStiffnessByAreaZ", -5);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				RotationalStiffnessByLengthX = new Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)value);
				if (_rotationalStiffnessByLengthX4 != null)
				{
					SetValue(delegate(IIfcModulusOfRotationalSubgradeReactionSelect v)
					{
						_rotationalStiffnessByLengthX4 = v;
					}, _rotationalStiffnessByLengthX4, null, "TranslationalStiffnessByAreaZ", -5);
				}
			}
			else
			{
				SetValue(delegate(IIfcModulusOfRotationalSubgradeReactionSelect v)
				{
					_rotationalStiffnessByLengthX4 = v;
				}, _rotationalStiffnessByLengthX4, value, "TranslationalStiffnessByAreaZ", -5);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryEdgeCondition), 6)]
	IIfcModulusOfRotationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.RotationalStiffnessByLengthY
	{
		get
		{
			if (_rotationalStiffnessByLengthY4 != null)
			{
				return _rotationalStiffnessByLengthY4;
			}
			Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure? rotationalStiffnessByLengthY = RotationalStiffnessByLengthY;
			if (!rotationalStiffnessByLengthY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure(rotationalStiffnessByLengthY.Value);
		}
		set
		{
			if (value == null)
			{
				RotationalStiffnessByLengthY = null;
				if (_rotationalStiffnessByLengthY4 != null)
				{
					SetValue(delegate(IIfcModulusOfRotationalSubgradeReactionSelect v)
					{
						_rotationalStiffnessByLengthY4 = v;
					}, _rotationalStiffnessByLengthY4, null, "TranslationalStiffnessByAreaZ", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				RotationalStiffnessByLengthY = new Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)value);
				if (_rotationalStiffnessByLengthY4 != null)
				{
					SetValue(delegate(IIfcModulusOfRotationalSubgradeReactionSelect v)
					{
						_rotationalStiffnessByLengthY4 = v;
					}, _rotationalStiffnessByLengthY4, null, "TranslationalStiffnessByAreaZ", -6);
				}
			}
			else
			{
				SetValue(delegate(IIfcModulusOfRotationalSubgradeReactionSelect v)
				{
					_rotationalStiffnessByLengthY4 = v;
				}, _rotationalStiffnessByLengthY4, value, "TranslationalStiffnessByAreaZ", -6);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryEdgeCondition), 7)]
	IIfcModulusOfRotationalSubgradeReactionSelect IIfcBoundaryEdgeCondition.RotationalStiffnessByLengthZ
	{
		get
		{
			if (_rotationalStiffnessByLengthZ4 != null)
			{
				return _rotationalStiffnessByLengthZ4;
			}
			Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure? rotationalStiffnessByLengthZ = RotationalStiffnessByLengthZ;
			if (!rotationalStiffnessByLengthZ.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure(rotationalStiffnessByLengthZ.Value);
		}
		set
		{
			if (value == null)
			{
				RotationalStiffnessByLengthZ = null;
				if (_rotationalStiffnessByLengthZ4 != null)
				{
					SetValue(delegate(IIfcModulusOfRotationalSubgradeReactionSelect v)
					{
						_rotationalStiffnessByLengthZ4 = v;
					}, _rotationalStiffnessByLengthZ4, null, "TranslationalStiffnessByAreaZ", -7);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				RotationalStiffnessByLengthZ = new Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)value);
				if (_rotationalStiffnessByLengthZ4 != null)
				{
					SetValue(delegate(IIfcModulusOfRotationalSubgradeReactionSelect v)
					{
						_rotationalStiffnessByLengthZ4 = v;
					}, _rotationalStiffnessByLengthZ4, null, "TranslationalStiffnessByAreaZ", -7);
				}
			}
			else
			{
				SetValue(delegate(IIfcModulusOfRotationalSubgradeReactionSelect v)
				{
					_rotationalStiffnessByLengthZ4 = v;
				}, _rotationalStiffnessByLengthZ4, value, "TranslationalStiffnessByAreaZ", -7);
			}
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure? LinearStiffnessByLengthX
	{
		get
		{
			if (_activated)
			{
				return _linearStiffnessByLengthX;
			}
			Activate();
			return _linearStiffnessByLengthX;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure? v)
			{
				_linearStiffnessByLengthX = v;
			}, _linearStiffnessByLengthX, value, "LinearStiffnessByLengthX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure? LinearStiffnessByLengthY
	{
		get
		{
			if (_activated)
			{
				return _linearStiffnessByLengthY;
			}
			Activate();
			return _linearStiffnessByLengthY;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure? v)
			{
				_linearStiffnessByLengthY = v;
			}, _linearStiffnessByLengthY, value, "LinearStiffnessByLengthY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure? LinearStiffnessByLengthZ
	{
		get
		{
			if (_activated)
			{
				return _linearStiffnessByLengthZ;
			}
			Activate();
			return _linearStiffnessByLengthZ;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure? v)
			{
				_linearStiffnessByLengthZ = v;
			}, _linearStiffnessByLengthZ, value, "LinearStiffnessByLengthZ", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure? RotationalStiffnessByLengthX
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure? v)
			{
				_rotationalStiffnessByLengthX = v;
			}, _rotationalStiffnessByLengthX, value, "RotationalStiffnessByLengthX", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure? RotationalStiffnessByLengthY
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure? v)
			{
				_rotationalStiffnessByLengthY = v;
			}, _rotationalStiffnessByLengthY, value, "RotationalStiffnessByLengthY", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure? RotationalStiffnessByLengthZ
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure? v)
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
			_linearStiffnessByLengthX = value.RealVal;
			break;
		case 2:
			_linearStiffnessByLengthY = value.RealVal;
			break;
		case 3:
			_linearStiffnessByLengthZ = value.RealVal;
			break;
		case 4:
			_rotationalStiffnessByLengthX = value.RealVal;
			break;
		case 5:
			_rotationalStiffnessByLengthY = value.RealVal;
			break;
		case 6:
			_rotationalStiffnessByLengthZ = value.RealVal;
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
