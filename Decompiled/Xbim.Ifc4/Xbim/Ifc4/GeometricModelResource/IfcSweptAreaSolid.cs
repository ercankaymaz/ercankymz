using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.ProfileResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcSweptAreaSolid", 239)]
public abstract class IfcSweptAreaSolid : IfcSolidModel, IIfcSweptAreaSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell, IEquatable<IfcSweptAreaSolid>, IExpressValidatable
{
	public enum IfcSweptAreaSolidClause
	{
		SweptAreaType
	}

	private IfcProfileDef _sweptArea;

	private IfcAxis2Placement3D _position;

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

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
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
			if (clause == IfcSweptAreaSolidClause.SweptAreaType)
			{
				result = SweptArea.ProfileType == IfcProfileTypeEnum.AREA;
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
		if (!ValidateClause(IfcSweptAreaSolidClause.SweptAreaType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSweptAreaSolid.SweptAreaType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
