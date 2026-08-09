using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.ProcessExtension;

[ExpressType("IfcProcedure", 294)]
public class IfcProcedure : Xbim.Ifc2x3.Kernel.IfcProcess, IIfcProcedure, IIfcProcess, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProcessSelect, IIfcProcessSelect, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcProcedure>, IExpressValidatable
{
	public enum IfcProcedureClause
	{
		WR1,
		WR2,
		WR3,
		WR4
	}

	private IfcIdentifier _procedureID;

	private IfcProcedureTypeEnum _procedureType;

	private IfcLabel? _userDefinedProcedureType;

	[CrossSchemaAttribute(typeof(IIfcProcedure), 8)]
	Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum? IIfcProcedure.PredefinedType
	{
		get
		{
			return ProcedureType switch
			{
				IfcProcedureTypeEnum.ADVICE_CAUTION => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.ADVICE_CAUTION, 
				IfcProcedureTypeEnum.ADVICE_NOTE => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.ADVICE_NOTE, 
				IfcProcedureTypeEnum.ADVICE_WARNING => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.ADVICE_WARNING, 
				IfcProcedureTypeEnum.CALIBRATION => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.CALIBRATION, 
				IfcProcedureTypeEnum.DIAGNOSTIC => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.DIAGNOSTIC, 
				IfcProcedureTypeEnum.SHUTDOWN => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.SHUTDOWN, 
				IfcProcedureTypeEnum.STARTUP => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.STARTUP, 
				IfcProcedureTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.USERDEFINED, 
				IfcProcedureTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.ADVICE_CAUTION:
				ProcedureType = IfcProcedureTypeEnum.ADVICE_CAUTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.ADVICE_NOTE:
				ProcedureType = IfcProcedureTypeEnum.ADVICE_NOTE;
				break;
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.ADVICE_WARNING:
				ProcedureType = IfcProcedureTypeEnum.ADVICE_WARNING;
				break;
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.CALIBRATION:
				ProcedureType = IfcProcedureTypeEnum.CALIBRATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.DIAGNOSTIC:
				ProcedureType = IfcProcedureTypeEnum.DIAGNOSTIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.SHUTDOWN:
				ProcedureType = IfcProcedureTypeEnum.SHUTDOWN;
				break;
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.STARTUP:
				ProcedureType = IfcProcedureTypeEnum.STARTUP;
				break;
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.USERDEFINED:
				ProcedureType = IfcProcedureTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.NOTDEFINED:
				ProcedureType = IfcProcedureTypeEnum.NOTDEFINED;
				break;
			case null:
				ProcedureType = IfcProcedureTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public IfcIdentifier ProcedureID
	{
		get
		{
			if (_activated)
			{
				return _procedureID;
			}
			Activate();
			return _procedureID;
		}
		set
		{
			SetValue(delegate(IfcIdentifier v)
			{
				_procedureID = v;
			}, _procedureID, value, "ProcedureID", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcProcedureTypeEnum ProcedureType
	{
		get
		{
			if (_activated)
			{
				return _procedureType;
			}
			Activate();
			return _procedureType;
		}
		set
		{
			SetValue(delegate(IfcProcedureTypeEnum v)
			{
				_procedureType = v;
			}, _procedureType, value, "ProcedureType", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public IfcLabel? UserDefinedProcedureType
	{
		get
		{
			if (_activated)
			{
				return _userDefinedProcedureType;
			}
			Activate();
			return _userDefinedProcedureType;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedProcedureType = v;
			}, _userDefinedProcedureType, value, "UserDefinedProcedureType", 8);
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
		}
	}

	internal IfcProcedure(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_procedureID = value.StringVal;
			break;
		case 6:
			_procedureType = (IfcProcedureTypeEnum)Enum.Parse(typeof(IfcProcedureTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 7:
			_userDefinedProcedureType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProcedure other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcProcedureClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcProcedureClause.WR1:
				result = Functions.SIZEOF(base.Decomposes.Where((Xbim.Ifc2x3.Kernel.IfcRelDecomposes temp) => !Functions.TYPEOF(temp).Contains("IFC2X3.IFCRELNESTS"))) == 0;
				break;
			case IfcProcedureClause.WR2:
				result = Functions.SIZEOF(base.IsDecomposedBy.Where((Xbim.Ifc2x3.Kernel.IfcRelDecomposes temp) => !Functions.TYPEOF(temp).Contains("IFC2X3.IFCRELNESTS"))) == 0;
				break;
			case IfcProcedureClause.WR3:
				result = Functions.EXISTS(base.Name);
				break;
			case IfcProcedureClause.WR4:
				result = ProcedureType != IfcProcedureTypeEnum.USERDEFINED || (ProcedureType == IfcProcedureTypeEnum.USERDEFINED && Functions.EXISTS(UserDefinedProcedureType));
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcProcedure>()?.LogError($"Exception thrown evaluating where-clause 'IfcProcedure.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcProcedureClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcProcedure.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcProcedureClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcProcedure.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcProcedureClause.WR3))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcProcedure.WR3",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcProcedureClause.WR4))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcProcedure.WR4",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
