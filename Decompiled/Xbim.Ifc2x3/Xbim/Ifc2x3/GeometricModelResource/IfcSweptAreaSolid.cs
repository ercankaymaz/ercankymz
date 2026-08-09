using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.ProfileResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometricModelResource;

[ExpressType("IfcSweptAreaSolid", 239)]
public abstract class IfcSweptAreaSolid : IfcSolidModel, IEquatable<IfcSweptAreaSolid>, IIfcSweptAreaSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell, IExpressValidatable
{
	public enum IfcSweptAreaSolidClause
	{
		WR22
	}

	private IfcProfileDef _sweptArea;

	private IfcAxis2Placement3D _position;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcProfileDef SweptArea
	{
		get
		{
			if (_activated)
			{
				return _sweptArea;
			}
			Activate();
			return _sweptArea;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProfileDef v)
			{
				_sweptArea = v;
			}, _sweptArea, value, "SweptArea", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcAxis2Placement3D Position
	{
		get
		{
			if (_activated)
			{
				return _position;
			}
			Activate();
			return _position;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis2Placement3D v)
			{
				_position = v;
			}, _position, value, "Position", 2);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSweptAreaSolid), 1)]
	IIfcProfileDef IIfcSweptAreaSolid.SweptArea
	{
		get
		{
			return SweptArea;
		}
		set
		{
			SweptArea = value as IfcProfileDef;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSweptAreaSolid), 2)]
	IIfcAxis2Placement3D IIfcSweptAreaSolid.Position
	{
		get
		{
			return Position;
		}
		set
		{
			Position = value as IfcAxis2Placement3D;
		}
	}

	internal IfcSweptAreaSolid(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_sweptArea = (IfcProfileDef)value.EntityVal;
			break;
		case 1:
			_position = (IfcAxis2Placement3D)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSweptAreaSolid other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcSweptAreaSolidClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcSweptAreaSolidClause.WR22)
			{
				result = SweptArea.ProfileType == Xbim.Ifc2x3.ProfileResource.IfcProfileTypeEnum.AREA;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSweptAreaSolid>()?.LogError($"Exception thrown evaluating where-clause 'IfcSweptAreaSolid.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcSweptAreaSolidClause.WR22))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSweptAreaSolid.WR22",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
