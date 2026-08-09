using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.ProfileResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcExtrudedAreaSolidTapered", 1176)]
public class IfcExtrudedAreaSolidTapered : IfcExtrudedAreaSolid, IInstantiableEntity, IPersistEntity, IPersist, IIfcExtrudedAreaSolidTapered, IIfcExtrudedAreaSolid, IIfcSweptAreaSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell, IContainsEntityReferences, IEquatable<IfcExtrudedAreaSolidTapered>, IExpressValidatable
{
	public enum IfcExtrudedAreaSolidTaperedClause
	{
		CorrectProfileAssignment
	}

	private IfcProfileDef _endSweptArea;

	IIfcProfileDef IIfcExtrudedAreaSolidTapered.EndSweptArea
	{
		get
		{
			return EndSweptArea;
		}
		set
		{
			EndSweptArea = value as IfcProfileDef;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcProfileDef EndSweptArea
	{
		get
		{
			if (_activated)
			{
				return _endSweptArea;
			}
			Activate();
			return _endSweptArea;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProfileDef v)
			{
				_endSweptArea = v;
			}, _endSweptArea, value, "EndSweptArea", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.SweptArea != null)
			{
				yield return base.SweptArea;
			}
			if (base.Position != null)
			{
				yield return base.Position;
			}
			if (base.ExtrudedDirection != null)
			{
				yield return base.ExtrudedDirection;
			}
			if (EndSweptArea != null)
			{
				yield return EndSweptArea;
			}
		}
	}

	internal IfcExtrudedAreaSolidTapered(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_endSweptArea = (IfcProfileDef)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcExtrudedAreaSolidTapered other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcExtrudedAreaSolidTaperedClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcExtrudedAreaSolidTaperedClause.CorrectProfileAssignment)
			{
				result = Functions.IfcTaperedSweptAreaProfiles(base.SweptArea, EndSweptArea);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcExtrudedAreaSolidTapered>()?.LogError($"Exception thrown evaluating where-clause 'IfcExtrudedAreaSolidTapered.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcExtrudedAreaSolidTaperedClause.CorrectProfileAssignment))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcExtrudedAreaSolidTapered.CorrectProfileAssignment",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
