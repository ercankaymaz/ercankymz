using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometricModelResource;

[ExpressType("IfcBooleanResult", 339)]
public class IfcBooleanResult : Xbim.Ifc2x3.GeometryResource.IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IfcBooleanOperand, IExpressSelectType, IIfcBooleanOperand, IfcCsgSelect, IIfcCsgSelect, IContainsEntityReferences, IEquatable<IfcBooleanResult>, IIfcBooleanResult, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, Xbim.Ifc4.GeometricModelResource.IfcCsgSelect, IExpressValidatable
{
	public enum IfcBooleanResultClause
	{
		WR1
	}

	private IfcBooleanOperator _operator;

	private IfcBooleanOperand _firstOperand;

	private IfcBooleanOperand _secondOperand;

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
	public Xbim.Ifc2x3.GeometryResource.IfcDimensionCount Dim => _firstOperand.Dim;

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

	[CrossSchemaAttribute(typeof(IIfcBooleanResult), 1)]
	Xbim.Ifc4.Interfaces.IfcBooleanOperator IIfcBooleanResult.Operator
	{
		get
		{
			return Operator switch
			{
				IfcBooleanOperator.UNION => Xbim.Ifc4.Interfaces.IfcBooleanOperator.UNION, 
				IfcBooleanOperator.INTERSECTION => Xbim.Ifc4.Interfaces.IfcBooleanOperator.INTERSECTION, 
				IfcBooleanOperator.DIFFERENCE => Xbim.Ifc4.Interfaces.IfcBooleanOperator.DIFFERENCE, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcBooleanOperator.UNION:
				Operator = IfcBooleanOperator.UNION;
				break;
			case Xbim.Ifc4.Interfaces.IfcBooleanOperator.INTERSECTION:
				Operator = IfcBooleanOperator.INTERSECTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcBooleanOperator.DIFFERENCE:
				Operator = IfcBooleanOperator.DIFFERENCE;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBooleanResult), 2)]
	IIfcBooleanOperand IIfcBooleanResult.FirstOperand
	{
		get
		{
			if (FirstOperand == null)
			{
				return null;
			}
			IfcSolidModel ifcSolidModel = FirstOperand as IfcSolidModel;
			if (ifcSolidModel != null)
			{
				return ifcSolidModel;
			}
			IfcHalfSpaceSolid ifcHalfSpaceSolid = FirstOperand as IfcHalfSpaceSolid;
			if (ifcHalfSpaceSolid != null)
			{
				return ifcHalfSpaceSolid;
			}
			IfcBooleanResult ifcBooleanResult = FirstOperand as IfcBooleanResult;
			if (ifcBooleanResult != null)
			{
				return ifcBooleanResult;
			}
			IfcCsgPrimitive3D ifcCsgPrimitive3D = FirstOperand as IfcCsgPrimitive3D;
			if (ifcCsgPrimitive3D != null)
			{
				return ifcCsgPrimitive3D;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				FirstOperand = null;
				return;
			}
			IfcBooleanResult ifcBooleanResult = value as IfcBooleanResult;
			if (ifcBooleanResult != null)
			{
				FirstOperand = ifcBooleanResult;
				return;
			}
			IfcCsgPrimitive3D ifcCsgPrimitive3D = value as IfcCsgPrimitive3D;
			if (ifcCsgPrimitive3D != null)
			{
				FirstOperand = ifcCsgPrimitive3D;
				return;
			}
			IfcHalfSpaceSolid ifcHalfSpaceSolid = value as IfcHalfSpaceSolid;
			if (ifcHalfSpaceSolid != null)
			{
				FirstOperand = ifcHalfSpaceSolid;
				return;
			}
			IfcSolidModel ifcSolidModel = value as IfcSolidModel;
			if (ifcSolidModel != null)
			{
				FirstOperand = ifcSolidModel;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBooleanResult), 3)]
	IIfcBooleanOperand IIfcBooleanResult.SecondOperand
	{
		get
		{
			if (SecondOperand == null)
			{
				return null;
			}
			IfcSolidModel ifcSolidModel = SecondOperand as IfcSolidModel;
			if (ifcSolidModel != null)
			{
				return ifcSolidModel;
			}
			IfcHalfSpaceSolid ifcHalfSpaceSolid = SecondOperand as IfcHalfSpaceSolid;
			if (ifcHalfSpaceSolid != null)
			{
				return ifcHalfSpaceSolid;
			}
			IfcBooleanResult ifcBooleanResult = SecondOperand as IfcBooleanResult;
			if (ifcBooleanResult != null)
			{
				return ifcBooleanResult;
			}
			IfcCsgPrimitive3D ifcCsgPrimitive3D = SecondOperand as IfcCsgPrimitive3D;
			if (ifcCsgPrimitive3D != null)
			{
				return ifcCsgPrimitive3D;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				SecondOperand = null;
				return;
			}
			IfcBooleanResult ifcBooleanResult = value as IfcBooleanResult;
			if (ifcBooleanResult != null)
			{
				SecondOperand = ifcBooleanResult;
				return;
			}
			IfcCsgPrimitive3D ifcCsgPrimitive3D = value as IfcCsgPrimitive3D;
			if (ifcCsgPrimitive3D != null)
			{
				SecondOperand = ifcCsgPrimitive3D;
				return;
			}
			IfcHalfSpaceSolid ifcHalfSpaceSolid = value as IfcHalfSpaceSolid;
			if (ifcHalfSpaceSolid != null)
			{
				SecondOperand = ifcHalfSpaceSolid;
				return;
			}
			IfcSolidModel ifcSolidModel = value as IfcSolidModel;
			if (ifcSolidModel != null)
			{
				SecondOperand = ifcSolidModel;
			}
		}
	}

	Xbim.Ifc4.GeometryResource.IfcDimensionCount Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

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
			if (clause == IfcBooleanResultClause.WR1)
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
		if (!ValidateClause(IfcBooleanResultClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBooleanResult.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
