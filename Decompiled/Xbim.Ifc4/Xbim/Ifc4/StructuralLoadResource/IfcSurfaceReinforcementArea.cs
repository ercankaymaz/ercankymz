using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.StructuralLoadResource;

[ExpressType("IfcSurfaceReinforcementArea", 1288)]
public class IfcSurfaceReinforcementArea : IfcStructuralLoadOrResult, IInstantiableEntity, IPersistEntity, IPersist, IIfcSurfaceReinforcementArea, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IEquatable<IfcSurfaceReinforcementArea>, IExpressValidatable
{
	public enum IfcSurfaceReinforcementAreaClause
	{
		SurfaceAndOrShearAreaSpecified,
		NonnegativeArea1,
		NonnegativeArea2,
		NonnegativeArea3
	}

	private readonly OptionalItemSet<IfcLengthMeasure> _surfaceReinforcement1;

	private readonly OptionalItemSet<IfcLengthMeasure> _surfaceReinforcement2;

	private IfcRatioMeasure? _shearReinforcement;

	IItemSet<IfcLengthMeasure> IIfcSurfaceReinforcementArea.SurfaceReinforcement1 => SurfaceReinforcement1;

	IItemSet<IfcLengthMeasure> IIfcSurfaceReinforcementArea.SurfaceReinforcement2 => SurfaceReinforcement2;

	IfcRatioMeasure? IIfcSurfaceReinforcementArea.ShearReinforcement
	{
		get
		{
			return ShearReinforcement;
		}
		set
		{
			ShearReinforcement = value;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { 3 }, 2)]
	public IOptionalItemSet<IfcLengthMeasure> SurfaceReinforcement1
	{
		get
		{
			if (_activated)
			{
				return _surfaceReinforcement1;
			}
			Activate();
			return _surfaceReinforcement1;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { 3 }, 3)]
	public IOptionalItemSet<IfcLengthMeasure> SurfaceReinforcement2
	{
		get
		{
			if (_activated)
			{
				return _surfaceReinforcement2;
			}
			Activate();
			return _surfaceReinforcement2;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcRatioMeasure? ShearReinforcement
	{
		get
		{
			if (_activated)
			{
				return _shearReinforcement;
			}
			Activate();
			return _shearReinforcement;
		}
		set
		{
			SetValue(delegate(IfcRatioMeasure? v)
			{
				_shearReinforcement = v;
			}, _shearReinforcement, value, "ShearReinforcement", 4);
		}
	}

	internal IfcSurfaceReinforcementArea(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_surfaceReinforcement1 = new OptionalItemSet<IfcLengthMeasure>(this, 3, 2);
		_surfaceReinforcement2 = new OptionalItemSet<IfcLengthMeasure>(this, 3, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_surfaceReinforcement1.InternalAdd(value.RealVal);
			break;
		case 2:
			_surfaceReinforcement2.InternalAdd(value.RealVal);
			break;
		case 3:
			_shearReinforcement = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSurfaceReinforcementArea other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcSurfaceReinforcementAreaClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcSurfaceReinforcementAreaClause.SurfaceAndOrShearAreaSpecified:
				result = Functions.EXISTS(SurfaceReinforcement1) || Functions.EXISTS(SurfaceReinforcement2) || Functions.EXISTS(ShearReinforcement);
				break;
			case IfcSurfaceReinforcementAreaClause.NonnegativeArea1:
				result = !Functions.EXISTS(SurfaceReinforcement1) || ((double)SurfaceReinforcement1.ItemAt(0L) >= 0.0 && (double)SurfaceReinforcement1.ItemAt(1L) >= 0.0 && (Functions.SIZEOF(SurfaceReinforcement1) == 1 || (double)SurfaceReinforcement1.ItemAt(0L) >= 0.0));
				break;
			case IfcSurfaceReinforcementAreaClause.NonnegativeArea2:
				result = !Functions.EXISTS(SurfaceReinforcement2) || ((double)SurfaceReinforcement2.ItemAt(0L) >= 0.0 && (double)SurfaceReinforcement2.ItemAt(1L) >= 0.0 && (Functions.SIZEOF(SurfaceReinforcement2) == 1 || (double)SurfaceReinforcement2.ItemAt(0L) >= 0.0));
				break;
			case IfcSurfaceReinforcementAreaClause.NonnegativeArea3:
				result = !Functions.EXISTS(ShearReinforcement) || (double?)ShearReinforcement >= 0.0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSurfaceReinforcementArea>()?.LogError($"Exception thrown evaluating where-clause 'IfcSurfaceReinforcementArea.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcSurfaceReinforcementAreaClause.SurfaceAndOrShearAreaSpecified))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceReinforcementArea.SurfaceAndOrShearAreaSpecified",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSurfaceReinforcementAreaClause.NonnegativeArea1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceReinforcementArea.NonnegativeArea1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSurfaceReinforcementAreaClause.NonnegativeArea2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceReinforcementArea.NonnegativeArea2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSurfaceReinforcementAreaClause.NonnegativeArea3))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSurfaceReinforcementArea.NonnegativeArea3",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
