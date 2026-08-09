using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcBooleanResult", 339)]
public class IfcBooleanResult : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcBooleanResult, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcCsgSelect, IIfcCsgSelect, IContainsEntityReferences, IEquatable<IfcBooleanResult>, IExpressValidatable
{
	public enum IfcBooleanResultClause
	{
		SameDim
	}

	private IfcBooleanOperator _operator;

	private IfcBooleanOperand _firstOperand;

	private IfcBooleanOperand _secondOperand;

	IfcBooleanOperator IIfcBooleanResult.Operator
	{
		get
		{
			return Operator;
		}
		set
		{
			Operator = value;
		}
	}

	IIfcBooleanOperand IIfcBooleanResult.FirstOperand
	{
		get
		{
			return FirstOperand;
		}
		set
		{
			FirstOperand = value as IfcBooleanOperand;
		}
	}

	IIfcBooleanOperand IIfcBooleanResult.SecondOperand
	{
		get
		{
			return SecondOperand;
		}
		set
		{
			SecondOperand = value as IfcBooleanOperand;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 3)]
	public IfcBooleanOperator Operator
	{
		get
		{
			if (_activated)
			{
				return _operator;
			}
			Activate();
			return _operator;
		}
		set
		{
			SetValue(delegate(IfcBooleanOperator v)
			{
				_operator = v;
			}, _operator, value, "Operator", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcBooleanOperand FirstOperand
	{
		get
		{
			if (_activated)
			{
				return _firstOperand;
			}
			Activate();
			return _firstOperand;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcBooleanOperand v)
			{
				_firstOperand = v;
			}, _firstOperand, value, "FirstOperand", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcBooleanOperand SecondOperand
	{
		get
		{
			if (_activated)
			{
				return _secondOperand;
			}
			Activate();
			return _secondOperand;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcBooleanOperand v)
			{
				_secondOperand = v;
			}, _secondOperand, value, "SecondOperand", 3);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim => _firstOperand.Dim;

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (FirstOperand != null)
			{
				yield return FirstOperand;
			}
			if (SecondOperand != null)
			{
				yield return SecondOperand;
			}
		}
	}

	internal IfcBooleanResult(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_operator = (IfcBooleanOperator)Enum.Parse(typeof(IfcBooleanOperator), value.EnumVal, ignoreCase: true);
			break;
		case 1:
			_firstOperand = (IfcBooleanOperand)value.EntityVal;
			break;
		case 2:
			_secondOperand = (IfcBooleanOperand)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBooleanResult other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcBooleanResultClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcBooleanResultClause.SameDim)
			{
				result = FirstOperand.Dim == SecondOperand.Dim;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcBooleanResult>()?.LogError($"Exception thrown evaluating where-clause 'IfcBooleanResult.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcBooleanResultClause.SameDim))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBooleanResult.SameDim",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
