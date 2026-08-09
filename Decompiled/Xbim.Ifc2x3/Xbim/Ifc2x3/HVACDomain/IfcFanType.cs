using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.HVACDomain;

[ExpressType("IfcFanType", 651)]
public class IfcFanType : IfcFlowMovingDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFanType>, IIfcFanType, IIfcFlowMovingDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcFanTypeClause
	{
		WR1
	}

	private IfcFanTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcFanTypeEnum PredefinedType
	{
		get
		{
			if (_activated)
			{
				return _predefinedType;
			}
			Activate();
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcFanTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
			foreach (IfcRepresentationMap representationMap in base.RepresentationMaps)
			{
				yield return representationMap;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFanType), 10)]
	Xbim.Ifc4.Interfaces.IfcFanTypeEnum IIfcFanType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcFanTypeEnum.CENTRIFUGALFORWARDCURVED => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.CENTRIFUGALFORWARDCURVED, 
				IfcFanTypeEnum.CENTRIFUGALRADIAL => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.CENTRIFUGALRADIAL, 
				IfcFanTypeEnum.CENTRIFUGALBACKWARDINCLINEDCURVED => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.CENTRIFUGALBACKWARDINCLINEDCURVED, 
				IfcFanTypeEnum.CENTRIFUGALAIRFOIL => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.CENTRIFUGALAIRFOIL, 
				IfcFanTypeEnum.TUBEAXIAL => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.TUBEAXIAL, 
				IfcFanTypeEnum.VANEAXIAL => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.VANEAXIAL, 
				IfcFanTypeEnum.PROPELLORAXIAL => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.PROPELLORAXIAL, 
				IfcFanTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.USERDEFINED, 
				IfcFanTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.CENTRIFUGALFORWARDCURVED:
				PredefinedType = IfcFanTypeEnum.CENTRIFUGALFORWARDCURVED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.CENTRIFUGALRADIAL:
				PredefinedType = IfcFanTypeEnum.CENTRIFUGALRADIAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.CENTRIFUGALBACKWARDINCLINEDCURVED:
				PredefinedType = IfcFanTypeEnum.CENTRIFUGALBACKWARDINCLINEDCURVED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.CENTRIFUGALAIRFOIL:
				PredefinedType = IfcFanTypeEnum.CENTRIFUGALAIRFOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.TUBEAXIAL:
				PredefinedType = IfcFanTypeEnum.TUBEAXIAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.VANEAXIAL:
				PredefinedType = IfcFanTypeEnum.VANEAXIAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.PROPELLORAXIAL:
				PredefinedType = IfcFanTypeEnum.PROPELLORAXIAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.USERDEFINED:
				PredefinedType = IfcFanTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.NOTDEFINED:
				PredefinedType = IfcFanTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcFanType(IModel model, int label, bool activated)
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
		case 8:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_predefinedType = (IfcFanTypeEnum)Enum.Parse(typeof(IfcFanTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFanType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcFanTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcFanTypeClause.WR1)
			{
				result = PredefinedType != IfcFanTypeEnum.USERDEFINED || (PredefinedType == IfcFanTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcFanType>()?.LogError($"Exception thrown evaluating where-clause 'IfcFanType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcFanTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcFanType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
