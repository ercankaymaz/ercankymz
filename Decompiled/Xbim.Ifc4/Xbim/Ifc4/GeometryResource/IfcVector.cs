using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcVector", 652)]
public class IfcVector : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcVector, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcHatchLineDistanceSelect, IIfcHatchLineDistanceSelect, IfcVectorOrDirection, IIfcVectorOrDirection, IContainsEntityReferences, IEquatable<IfcVector>, IExpressValidatable
{
	public enum IfcVectorClause
	{
		MagGreaterOrEqualZero
	}

	private IfcDirection _orientation;

	private IfcLengthMeasure _magnitude;

	IIfcDirection IIfcVector.Orientation
	{
		get
		{
			return Orientation;
		}
		set
		{
			Orientation = value as IfcDirection;
		}
	}

	IfcLengthMeasure IIfcVector.Magnitude
	{
		get
		{
			return Magnitude;
		}
		set
		{
			Magnitude = value;
		}
	}

	IfcDimensionCount IIfcVector.Dim => Dim;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcDirection Orientation
	{
		get
		{
			if (_activated)
			{
				return _orientation;
			}
			Activate();
			return _orientation;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_orientation = v;
			}, _orientation, value, "Orientation", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLengthMeasure Magnitude
	{
		get
		{
			if (_activated)
			{
				return _magnitude;
			}
			Activate();
			return _magnitude;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure v)
			{
				_magnitude = v;
			}, _magnitude, value, "Magnitude", 2);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim => Orientation.Dim;

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Orientation != null)
			{
				yield return Orientation;
			}
		}
	}

	internal IfcVector(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_orientation = (IfcDirection)value.EntityVal;
			break;
		case 1:
			_magnitude = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcVector other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcVectorClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcVectorClause.MagGreaterOrEqualZero)
			{
				result = (double)Magnitude >= 0.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcVector>()?.LogError($"Exception thrown evaluating where-clause 'IfcVector.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcVectorClause.MagGreaterOrEqualZero))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcVector.MagGreaterOrEqualZero",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
