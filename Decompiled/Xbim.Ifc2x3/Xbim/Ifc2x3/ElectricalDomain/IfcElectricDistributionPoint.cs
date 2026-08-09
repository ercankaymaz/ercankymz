using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.ElectricalDomain;

[ExpressType("IfcElectricDistributionPoint", 242)]
public class IfcElectricDistributionPoint : IfcFlowController, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcElectricDistributionPoint>, IExpressValidatable
{
	public enum IfcElectricDistributionPointClause
	{
		WR31
	}

	private IfcElectricDistributionPointFunctionEnum _distributionPointFunction;

	private IfcLabel? _userDefinedFunction;

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 28)]
	public IfcElectricDistributionPointFunctionEnum DistributionPointFunction
	{
		get
		{
			if (_activated)
			{
				return _distributionPointFunction;
			}
			Activate();
			return _distributionPointFunction;
		}
		set
		{
			SetValue(delegate(IfcElectricDistributionPointFunctionEnum v)
			{
				_distributionPointFunction = v;
			}, _distributionPointFunction, value, "DistributionPointFunction", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 29)]
	public IfcLabel? UserDefinedFunction
	{
		get
		{
			if (_activated)
			{
				return _userDefinedFunction;
			}
			Activate();
			return _userDefinedFunction;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedFunction = v;
			}, _userDefinedFunction, value, "UserDefinedFunction", 10);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	internal IfcElectricDistributionPoint(IModel model, int label, bool activated)
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
		case 7:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_distributionPointFunction = (IfcElectricDistributionPointFunctionEnum)Enum.Parse(typeof(IfcElectricDistributionPointFunctionEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_userDefinedFunction = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElectricDistributionPoint other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcElectricDistributionPointClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcElectricDistributionPointClause.WR31)
			{
				result = DistributionPointFunction != IfcElectricDistributionPointFunctionEnum.USERDEFINED || (DistributionPointFunction == IfcElectricDistributionPointFunctionEnum.USERDEFINED && Functions.EXISTS(UserDefinedFunction));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcElectricDistributionPoint>()?.LogError($"Exception thrown evaluating where-clause 'IfcElectricDistributionPoint.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcElectricDistributionPointClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcElectricDistributionPoint.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
