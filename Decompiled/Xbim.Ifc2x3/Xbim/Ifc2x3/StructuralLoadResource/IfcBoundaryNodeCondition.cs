using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.StructuralLoadResource;

[ExpressType("IfcBoundaryNodeCondition", 394)]
public class IfcBoundaryNodeCondition : IfcBoundaryCondition, IIfcBoundaryNodeCondition, IIfcBoundaryCondition, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcBoundaryNodeCondition>
{
	private IIfcTranslationalStiffnessSelect _translationalStiffnessX;

	private IIfcTranslationalStiffnessSelect _translationalStiffnessY;

	private IIfcTranslationalStiffnessSelect _translationalStiffnessZ;

	private IIfcRotationalStiffnessSelect _rotationalStiffnessX4;

	private IIfcRotationalStiffnessSelect _rotationalStiffnessY4;

	private IIfcRotationalStiffnessSelect _rotationalStiffnessZ4;

	private Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure? _linearStiffnessX;

	private Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure? _linearStiffnessY;

	private Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure? _linearStiffnessZ;

	private Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure? _rotationalStiffnessX;

	private Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure? _rotationalStiffnessY;

	private Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure? _rotationalStiffnessZ;

	[CrossSchemaAttribute(typeof(IIfcBoundaryNodeCondition), 2)]
	IIfcTranslationalStiffnessSelect IIfcBoundaryNodeCondition.TranslationalStiffnessX
	{
		get
		{
			if (_translationalStiffnessX != null)
			{
				return _translationalStiffnessX;
			}
			Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure? linearStiffnessX = LinearStiffnessX;
			if (!linearStiffnessX.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure(linearStiffnessX.Value);
		}
		set
		{
			if (value == null)
			{
				LinearStiffnessX = null;
				if (_translationalStiffnessX != null)
				{
					SetValue(delegate(IIfcTranslationalStiffnessSelect v)
					{
						_translationalStiffnessX = v;
					}, _translationalStiffnessX, null, "TranslationalStiffnessX", -2);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)
			{
				LinearStiffnessX = new Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)(object)value);
				if (_translationalStiffnessX != null)
				{
					SetValue(delegate(IIfcTranslationalStiffnessSelect v)
					{
						_translationalStiffnessX = v;
					}, _translationalStiffnessX, null, "TranslationalStiffnessX", -2);
				}
			}
			else
			{
				SetValue(delegate(IIfcTranslationalStiffnessSelect v)
				{
					_translationalStiffnessX = v;
				}, _translationalStiffnessX, value, "TranslationalStiffnessX", -2);
				NotifyPropertyChanged("TranslationalStiffnessX");
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryNodeCondition), 3)]
	IIfcTranslationalStiffnessSelect IIfcBoundaryNodeCondition.TranslationalStiffnessY
	{
		get
		{
			if (_translationalStiffnessY != null)
			{
				return _translationalStiffnessY;
			}
			Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure? linearStiffnessY = LinearStiffnessY;
			if (!linearStiffnessY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure(linearStiffnessY.Value);
		}
		set
		{
			if (value == null)
			{
				LinearStiffnessY = null;
				if (_translationalStiffnessY != null)
				{
					SetValue(delegate(IIfcTranslationalStiffnessSelect v)
					{
						_translationalStiffnessY = v;
					}, _translationalStiffnessY, null, "TranslationalStiffnessY", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)
			{
				LinearStiffnessY = new Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)(object)value);
				if (_translationalStiffnessY != null)
				{
					SetValue(delegate(IIfcTranslationalStiffnessSelect v)
					{
						_translationalStiffnessY = v;
					}, _translationalStiffnessY, null, "TranslationalStiffnessY", -3);
				}
			}
			else
			{
				SetValue(delegate(IIfcTranslationalStiffnessSelect v)
				{
					_translationalStiffnessY = v;
				}, _translationalStiffnessY, value, "TranslationalStiffnessY", -3);
				NotifyPropertyChanged("TranslationalStiffnessY");
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryNodeCondition), 4)]
	IIfcTranslationalStiffnessSelect IIfcBoundaryNodeCondition.TranslationalStiffnessZ
	{
		get
		{
			if (_translationalStiffnessZ != null)
			{
				return _translationalStiffnessZ;
			}
			Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure? linearStiffnessZ = LinearStiffnessZ;
			if (!linearStiffnessZ.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure(linearStiffnessZ.Value);
		}
		set
		{
			if (value == null)
			{
				LinearStiffnessZ = null;
				if (_translationalStiffnessZ != null)
				{
					SetValue(delegate(IIfcTranslationalStiffnessSelect v)
					{
						_translationalStiffnessZ = v;
					}, _translationalStiffnessZ, null, "TranslationalStiffnessZ", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)
			{
				LinearStiffnessZ = new Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)(object)value);
				SetValue(delegate(IIfcTranslationalStiffnessSelect v)
				{
					_translationalStiffnessZ = v;
				}, _translationalStiffnessZ, null, "TranslationalStiffnessZ", -4);
			}
			else
			{
				SetValue(delegate(IIfcTranslationalStiffnessSelect v)
				{
					_translationalStiffnessZ = v;
				}, _translationalStiffnessZ, value, "TranslationalStiffnessZ", -4);
				NotifyPropertyChanged("TranslationalStiffnessZ");
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryNodeCondition), 5)]
	IIfcRotationalStiffnessSelect IIfcBoundaryNodeCondition.RotationalStiffnessX
	{
		get
		{
			if (_rotationalStiffnessX4 != null)
			{
				return _rotationalStiffnessX4;
			}
			Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure? rotationalStiffnessX = RotationalStiffnessX;
			if (!rotationalStiffnessX.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure(rotationalStiffnessX.Value);
		}
		set
		{
			if (value == null)
			{
				RotationalStiffnessX = null;
				if (_rotationalStiffnessX4 != null)
				{
					SetValue(delegate(IIfcRotationalStiffnessSelect v)
					{
						_rotationalStiffnessX4 = v;
					}, _rotationalStiffnessX4, null, "RotationalStiffnessX", -5);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				RotationalStiffnessX = new Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)(object)value);
				if (_rotationalStiffnessX4 != null)
				{
					SetValue(delegate(IIfcRotationalStiffnessSelect v)
					{
						_rotationalStiffnessX4 = v;
					}, _rotationalStiffnessX4, null, "RotationalStiffnessX", -5);
				}
			}
			else
			{
				SetValue(delegate(IIfcRotationalStiffnessSelect v)
				{
					_rotationalStiffnessX4 = v;
				}, _rotationalStiffnessX4, value, "RotationalStiffnessX", -5);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryNodeCondition), 6)]
	IIfcRotationalStiffnessSelect IIfcBoundaryNodeCondition.RotationalStiffnessY
	{
		get
		{
			if (_rotationalStiffnessY4 != null)
			{
				return _rotationalStiffnessY4;
			}
			Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure? rotationalStiffnessY = RotationalStiffnessY;
			if (!rotationalStiffnessY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure(rotationalStiffnessY.Value);
		}
		set
		{
			if (value == null)
			{
				RotationalStiffnessY = null;
				if (_rotationalStiffnessY4 != null)
				{
					SetValue(delegate(IIfcRotationalStiffnessSelect v)
					{
						_rotationalStiffnessY4 = v;
					}, _rotationalStiffnessY4, null, "RotationalStiffnessY", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				RotationalStiffnessY = new Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)(object)value);
				if (_rotationalStiffnessY4 != null)
				{
					SetValue(delegate(IIfcRotationalStiffnessSelect v)
					{
						_rotationalStiffnessY4 = v;
					}, _rotationalStiffnessY4, null, "RotationalStiffnessY", -6);
				}
			}
			else
			{
				SetValue(delegate(IIfcRotationalStiffnessSelect v)
				{
					_rotationalStiffnessY4 = v;
				}, _rotationalStiffnessY4, value, "RotationalStiffnessY", -6);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryNodeCondition), 7)]
	IIfcRotationalStiffnessSelect IIfcBoundaryNodeCondition.RotationalStiffnessZ
	{
		get
		{
			if (_rotationalStiffnessZ4 != null)
			{
				return _rotationalStiffnessZ4;
			}
			Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure? rotationalStiffnessZ = RotationalStiffnessZ;
			if (!rotationalStiffnessZ.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure(rotationalStiffnessZ.Value);
		}
		set
		{
			if (value == null)
			{
				RotationalStiffnessZ = null;
				if (_rotationalStiffnessZ4 != null)
				{
					SetValue(delegate(IIfcRotationalStiffnessSelect v)
					{
						_rotationalStiffnessZ4 = v;
					}, _rotationalStiffnessZ4, null, "RotationalStiffnessZ", -7);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				RotationalStiffnessZ = new Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)(object)value);
				if (_rotationalStiffnessZ4 != null)
				{
					SetValue(delegate(IIfcRotationalStiffnessSelect v)
					{
						_rotationalStiffnessZ4 = v;
					}, _rotationalStiffnessZ4, null, "RotationalStiffnessZ", -7);
				}
			}
			else
			{
				SetValue(delegate(IIfcRotationalStiffnessSelect v)
				{
					_rotationalStiffnessZ4 = v;
				}, _rotationalStiffnessZ4, value, "RotationalStiffnessZ", -7);
			}
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure? LinearStiffnessX
	{
		get
		{
			if (_activated)
			{
				return _linearStiffnessX;
			}
			Activate();
			return _linearStiffnessX;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure? v)
			{
				_linearStiffnessX = v;
			}, _linearStiffnessX, value, "LinearStiffnessX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure? LinearStiffnessY
	{
		get
		{
			if (_activated)
			{
				return _linearStiffnessY;
			}
			Activate();
			return _linearStiffnessY;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure? v)
			{
				_linearStiffnessY = v;
			}, _linearStiffnessY, value, "LinearStiffnessY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure? LinearStiffnessZ
	{
		get
		{
			if (_activated)
			{
				return _linearStiffnessZ;
			}
			Activate();
			return _linearStiffnessZ;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure? v)
			{
				_linearStiffnessZ = v;
			}, _linearStiffnessZ, value, "LinearStiffnessZ", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure? RotationalStiffnessX
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure? v)
			{
				_rotationalStiffnessX = v;
			}, _rotationalStiffnessX, value, "RotationalStiffnessX", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure? RotationalStiffnessY
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure? v)
			{
				_rotationalStiffnessY = v;
			}, _rotationalStiffnessY, value, "RotationalStiffnessY", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure? RotationalStiffnessZ
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure? v)
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
			_linearStiffnessX = value.RealVal;
			break;
		case 2:
			_linearStiffnessY = value.RealVal;
			break;
		case 3:
			_linearStiffnessZ = value.RealVal;
			break;
		case 4:
			_rotationalStiffnessX = value.RealVal;
			break;
		case 5:
			_rotationalStiffnessY = value.RealVal;
			break;
		case 6:
			_rotationalStiffnessZ = value.RealVal;
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
