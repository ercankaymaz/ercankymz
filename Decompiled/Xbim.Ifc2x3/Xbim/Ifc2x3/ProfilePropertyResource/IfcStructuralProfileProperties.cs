using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.ProfilePropertyResource;

[ExpressType("IfcStructuralProfileProperties", 683)]
public class IfcStructuralProfileProperties : IfcGeneralProfileProperties, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcStructuralProfileProperties>, IExpressValidatable
{
	public enum IfcStructuralProfilePropertiesClause
	{
		WR21,
		WR22
	}

	private IfcMomentOfInertiaMeasure? _torsionalConstantX;

	private IfcMomentOfInertiaMeasure? _momentOfInertiaYZ;

	private IfcMomentOfInertiaMeasure? _momentOfInertiaY;

	private IfcMomentOfInertiaMeasure? _momentOfInertiaZ;

	private IfcWarpingConstantMeasure? _warpingConstant;

	private IfcLengthMeasure? _shearCentreZ;

	private IfcLengthMeasure? _shearCentreY;

	private IfcAreaMeasure? _shearDeformationAreaZ;

	private IfcAreaMeasure? _shearDeformationAreaY;

	private IfcSectionModulusMeasure? _maximumSectionModulusY;

	private IfcSectionModulusMeasure? _minimumSectionModulusY;

	private IfcSectionModulusMeasure? _maximumSectionModulusZ;

	private IfcSectionModulusMeasure? _minimumSectionModulusZ;

	private IfcSectionModulusMeasure? _torsionalSectionModulus;

	private IfcLengthMeasure? _centreOfGravityInX;

	private IfcLengthMeasure? _centreOfGravityInY;

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcMomentOfInertiaMeasure? TorsionalConstantX
	{
		get
		{
			if (_activated)
			{
				return _torsionalConstantX;
			}
			Activate();
			return _torsionalConstantX;
		}
		set
		{
			SetValue(delegate(IfcMomentOfInertiaMeasure? v)
			{
				_torsionalConstantX = v;
			}, _torsionalConstantX, value, "TorsionalConstantX", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcMomentOfInertiaMeasure? MomentOfInertiaYZ
	{
		get
		{
			if (_activated)
			{
				return _momentOfInertiaYZ;
			}
			Activate();
			return _momentOfInertiaYZ;
		}
		set
		{
			SetValue(delegate(IfcMomentOfInertiaMeasure? v)
			{
				_momentOfInertiaYZ = v;
			}, _momentOfInertiaYZ, value, "MomentOfInertiaYZ", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcMomentOfInertiaMeasure? MomentOfInertiaY
	{
		get
		{
			if (_activated)
			{
				return _momentOfInertiaY;
			}
			Activate();
			return _momentOfInertiaY;
		}
		set
		{
			SetValue(delegate(IfcMomentOfInertiaMeasure? v)
			{
				_momentOfInertiaY = v;
			}, _momentOfInertiaY, value, "MomentOfInertiaY", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcMomentOfInertiaMeasure? MomentOfInertiaZ
	{
		get
		{
			if (_activated)
			{
				return _momentOfInertiaZ;
			}
			Activate();
			return _momentOfInertiaZ;
		}
		set
		{
			SetValue(delegate(IfcMomentOfInertiaMeasure? v)
			{
				_momentOfInertiaZ = v;
			}, _momentOfInertiaZ, value, "MomentOfInertiaZ", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcWarpingConstantMeasure? WarpingConstant
	{
		get
		{
			if (_activated)
			{
				return _warpingConstant;
			}
			Activate();
			return _warpingConstant;
		}
		set
		{
			SetValue(delegate(IfcWarpingConstantMeasure? v)
			{
				_warpingConstant = v;
			}, _warpingConstant, value, "WarpingConstant", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcLengthMeasure? ShearCentreZ
	{
		get
		{
			if (_activated)
			{
				return _shearCentreZ;
			}
			Activate();
			return _shearCentreZ;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_shearCentreZ = v;
			}, _shearCentreZ, value, "ShearCentreZ", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public IfcLengthMeasure? ShearCentreY
	{
		get
		{
			if (_activated)
			{
				return _shearCentreY;
			}
			Activate();
			return _shearCentreY;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_shearCentreY = v;
			}, _shearCentreY, value, "ShearCentreY", 14);
		}
	}

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public IfcAreaMeasure? ShearDeformationAreaZ
	{
		get
		{
			if (_activated)
			{
				return _shearDeformationAreaZ;
			}
			Activate();
			return _shearDeformationAreaZ;
		}
		set
		{
			SetValue(delegate(IfcAreaMeasure? v)
			{
				_shearDeformationAreaZ = v;
			}, _shearDeformationAreaZ, value, "ShearDeformationAreaZ", 15);
		}
	}

	[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public IfcAreaMeasure? ShearDeformationAreaY
	{
		get
		{
			if (_activated)
			{
				return _shearDeformationAreaY;
			}
			Activate();
			return _shearDeformationAreaY;
		}
		set
		{
			SetValue(delegate(IfcAreaMeasure? v)
			{
				_shearDeformationAreaY = v;
			}, _shearDeformationAreaY, value, "ShearDeformationAreaY", 16);
		}
	}

	[EntityAttribute(17, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public IfcSectionModulusMeasure? MaximumSectionModulusY
	{
		get
		{
			if (_activated)
			{
				return _maximumSectionModulusY;
			}
			Activate();
			return _maximumSectionModulusY;
		}
		set
		{
			SetValue(delegate(IfcSectionModulusMeasure? v)
			{
				_maximumSectionModulusY = v;
			}, _maximumSectionModulusY, value, "MaximumSectionModulusY", 17);
		}
	}

	[EntityAttribute(18, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 18)]
	public IfcSectionModulusMeasure? MinimumSectionModulusY
	{
		get
		{
			if (_activated)
			{
				return _minimumSectionModulusY;
			}
			Activate();
			return _minimumSectionModulusY;
		}
		set
		{
			SetValue(delegate(IfcSectionModulusMeasure? v)
			{
				_minimumSectionModulusY = v;
			}, _minimumSectionModulusY, value, "MinimumSectionModulusY", 18);
		}
	}

	[EntityAttribute(19, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 19)]
	public IfcSectionModulusMeasure? MaximumSectionModulusZ
	{
		get
		{
			if (_activated)
			{
				return _maximumSectionModulusZ;
			}
			Activate();
			return _maximumSectionModulusZ;
		}
		set
		{
			SetValue(delegate(IfcSectionModulusMeasure? v)
			{
				_maximumSectionModulusZ = v;
			}, _maximumSectionModulusZ, value, "MaximumSectionModulusZ", 19);
		}
	}

	[EntityAttribute(20, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
	public IfcSectionModulusMeasure? MinimumSectionModulusZ
	{
		get
		{
			if (_activated)
			{
				return _minimumSectionModulusZ;
			}
			Activate();
			return _minimumSectionModulusZ;
		}
		set
		{
			SetValue(delegate(IfcSectionModulusMeasure? v)
			{
				_minimumSectionModulusZ = v;
			}, _minimumSectionModulusZ, value, "MinimumSectionModulusZ", 20);
		}
	}

	[EntityAttribute(21, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public IfcSectionModulusMeasure? TorsionalSectionModulus
	{
		get
		{
			if (_activated)
			{
				return _torsionalSectionModulus;
			}
			Activate();
			return _torsionalSectionModulus;
		}
		set
		{
			SetValue(delegate(IfcSectionModulusMeasure? v)
			{
				_torsionalSectionModulus = v;
			}, _torsionalSectionModulus, value, "TorsionalSectionModulus", 21);
		}
	}

	[EntityAttribute(22, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
	public IfcLengthMeasure? CentreOfGravityInX
	{
		get
		{
			if (_activated)
			{
				return _centreOfGravityInX;
			}
			Activate();
			return _centreOfGravityInX;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_centreOfGravityInX = v;
			}, _centreOfGravityInX, value, "CentreOfGravityInX", 22);
		}
	}

	[EntityAttribute(23, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 23)]
	public IfcLengthMeasure? CentreOfGravityInY
	{
		get
		{
			if (_activated)
			{
				return _centreOfGravityInY;
			}
			Activate();
			return _centreOfGravityInY;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_centreOfGravityInY = v;
			}, _centreOfGravityInY, value, "CentreOfGravityInY", 23);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.ProfileDefinition != null)
			{
				yield return base.ProfileDefinition;
			}
		}
	}

	internal IfcStructuralProfileProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_torsionalConstantX = value.RealVal;
			break;
		case 8:
			_momentOfInertiaYZ = value.RealVal;
			break;
		case 9:
			_momentOfInertiaY = value.RealVal;
			break;
		case 10:
			_momentOfInertiaZ = value.RealVal;
			break;
		case 11:
			_warpingConstant = value.RealVal;
			break;
		case 12:
			_shearCentreZ = value.RealVal;
			break;
		case 13:
			_shearCentreY = value.RealVal;
			break;
		case 14:
			_shearDeformationAreaZ = value.RealVal;
			break;
		case 15:
			_shearDeformationAreaY = value.RealVal;
			break;
		case 16:
			_maximumSectionModulusY = value.RealVal;
			break;
		case 17:
			_minimumSectionModulusY = value.RealVal;
			break;
		case 18:
			_maximumSectionModulusZ = value.RealVal;
			break;
		case 19:
			_minimumSectionModulusZ = value.RealVal;
			break;
		case 20:
			_torsionalSectionModulus = value.RealVal;
			break;
		case 21:
			_centreOfGravityInX = value.RealVal;
			break;
		case 22:
			_centreOfGravityInY = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralProfileProperties other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuralProfilePropertiesClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcStructuralProfilePropertiesClause.WR21:
				result = !Functions.EXISTS(ShearDeformationAreaY) || (double?)ShearDeformationAreaY >= 0.0;
				break;
			case IfcStructuralProfilePropertiesClause.WR22:
				result = !Functions.EXISTS(ShearDeformationAreaZ) || (double?)ShearDeformationAreaZ >= 0.0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuralProfileProperties>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuralProfileProperties.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStructuralProfilePropertiesClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralProfileProperties.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcStructuralProfilePropertiesClause.WR22))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralProfileProperties.WR22",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
