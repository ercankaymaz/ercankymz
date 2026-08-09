using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.StructuralLoadResource;

[ExpressType("IfcBoundaryFaceCondition", 674)]
public class IfcBoundaryFaceCondition : IfcBoundaryCondition, IIfcBoundaryFaceCondition, IIfcBoundaryCondition, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcBoundaryFaceCondition>
{
	private IIfcModulusOfSubgradeReactionSelect _translationalStiffnessByAreaX;

	private IIfcModulusOfSubgradeReactionSelect _translationalStiffnessByAreaY;

	private IIfcModulusOfSubgradeReactionSelect _translationalStiffnessByAreaZ;

	private Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure? _linearStiffnessByAreaX;

	private Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure? _linearStiffnessByAreaY;

	private Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure? _linearStiffnessByAreaZ;

	[CrossSchemaAttribute(typeof(IIfcBoundaryFaceCondition), 2)]
	IIfcModulusOfSubgradeReactionSelect IIfcBoundaryFaceCondition.TranslationalStiffnessByAreaX
	{
		get
		{
			if (_translationalStiffnessByAreaX != null)
			{
				return _translationalStiffnessByAreaX;
			}
			Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure? linearStiffnessByAreaX = LinearStiffnessByAreaX;
			if (!linearStiffnessByAreaX.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure(linearStiffnessByAreaX.Value);
		}
		set
		{
			if (value == null)
			{
				LinearStiffnessByAreaX = null;
				if (_translationalStiffnessByAreaX != null)
				{
					SetValue(delegate(IIfcModulusOfSubgradeReactionSelect v)
					{
						_translationalStiffnessByAreaX = v;
					}, _translationalStiffnessByAreaX, null, "TranslationalStiffnessByAreaX", -2);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				LinearStiffnessByAreaX = new Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)value);
				if (_translationalStiffnessByAreaX != null)
				{
					SetValue(delegate(IIfcModulusOfSubgradeReactionSelect v)
					{
						_translationalStiffnessByAreaX = v;
					}, _translationalStiffnessByAreaX, null, "TranslationalStiffnessByAreaX", -2);
				}
			}
			else
			{
				SetValue(delegate(IIfcModulusOfSubgradeReactionSelect v)
				{
					_translationalStiffnessByAreaX = v;
				}, _translationalStiffnessByAreaX, value, "TranslationalStiffnessByAreaX", -2);
				NotifyPropertyChanged("TranslationalStiffnessByAreaX");
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryFaceCondition), 3)]
	IIfcModulusOfSubgradeReactionSelect IIfcBoundaryFaceCondition.TranslationalStiffnessByAreaY
	{
		get
		{
			if (_translationalStiffnessByAreaY != null)
			{
				return _translationalStiffnessByAreaY;
			}
			Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure? linearStiffnessByAreaY = LinearStiffnessByAreaY;
			if (!linearStiffnessByAreaY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure(linearStiffnessByAreaY.Value);
		}
		set
		{
			if (value == null)
			{
				LinearStiffnessByAreaY = null;
				if (_translationalStiffnessByAreaY != null)
				{
					SetValue(delegate(IIfcModulusOfSubgradeReactionSelect v)
					{
						_translationalStiffnessByAreaY = v;
					}, _translationalStiffnessByAreaY, null, "TranslationalStiffnessByAreaY", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				LinearStiffnessByAreaY = new Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)value);
				if (_translationalStiffnessByAreaY != null)
				{
					SetValue(delegate(IIfcModulusOfSubgradeReactionSelect v)
					{
						_translationalStiffnessByAreaY = v;
					}, _translationalStiffnessByAreaY, null, "TranslationalStiffnessByAreaY", -3);
				}
			}
			else
			{
				SetValue(delegate(IIfcModulusOfSubgradeReactionSelect v)
				{
					_translationalStiffnessByAreaY = v;
				}, _translationalStiffnessByAreaY, value, "TranslationalStiffnessByAreaY", -3);
				NotifyPropertyChanged("TranslationalStiffnessByAreaY");
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBoundaryFaceCondition), 4)]
	IIfcModulusOfSubgradeReactionSelect IIfcBoundaryFaceCondition.TranslationalStiffnessByAreaZ
	{
		get
		{
			if (_translationalStiffnessByAreaZ != null)
			{
				return _translationalStiffnessByAreaZ;
			}
			Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure? linearStiffnessByAreaZ = LinearStiffnessByAreaZ;
			if (!linearStiffnessByAreaZ.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure(linearStiffnessByAreaZ.Value);
		}
		set
		{
			if (value == null)
			{
				LinearStiffnessByAreaZ = null;
				if (_translationalStiffnessByAreaZ != null)
				{
					SetValue(delegate(IIfcModulusOfSubgradeReactionSelect v)
					{
						_translationalStiffnessByAreaZ = v;
					}, _translationalStiffnessByAreaZ, null, "TranslationalStiffnessByAreaZ", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				LinearStiffnessByAreaZ = new Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)value);
				if (_translationalStiffnessByAreaZ != null)
				{
					SetValue(delegate(IIfcModulusOfSubgradeReactionSelect v)
					{
						_translationalStiffnessByAreaZ = v;
					}, _translationalStiffnessByAreaZ, null, "TranslationalStiffnessByAreaZ", -4);
				}
			}
			else
			{
				SetValue(delegate(IIfcModulusOfSubgradeReactionSelect v)
				{
					_translationalStiffnessByAreaZ = v;
				}, _translationalStiffnessByAreaZ, value, "TranslationalStiffnessByAreaZ", -4);
				NotifyPropertyChanged("TranslationalStiffnessByAreaZ");
			}
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure? LinearStiffnessByAreaX
	{
		get
		{
			if (_activated)
			{
				return _linearStiffnessByAreaX;
			}
			Activate();
			return _linearStiffnessByAreaX;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure? v)
			{
				_linearStiffnessByAreaX = v;
			}, _linearStiffnessByAreaX, value, "LinearStiffnessByAreaX", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure? LinearStiffnessByAreaY
	{
		get
		{
			if (_activated)
			{
				return _linearStiffnessByAreaY;
			}
			Activate();
			return _linearStiffnessByAreaY;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure? v)
			{
				_linearStiffnessByAreaY = v;
			}, _linearStiffnessByAreaY, value, "LinearStiffnessByAreaY", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure? LinearStiffnessByAreaZ
	{
		get
		{
			if (_activated)
			{
				return _linearStiffnessByAreaZ;
			}
			Activate();
			return _linearStiffnessByAreaZ;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure? v)
			{
				_linearStiffnessByAreaZ = v;
			}, _linearStiffnessByAreaZ, value, "LinearStiffnessByAreaZ", 4);
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
			_linearStiffnessByAreaX = value.RealVal;
			break;
		case 2:
			_linearStiffnessByAreaY = value.RealVal;
			break;
		case 3:
			_linearStiffnessByAreaZ = value.RealVal;
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
