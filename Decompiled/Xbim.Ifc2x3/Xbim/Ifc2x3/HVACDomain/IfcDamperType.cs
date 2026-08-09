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

[ExpressType("IfcDamperType", 514)]
public class IfcDamperType : IfcFlowControllerType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDamperType>, IIfcDamperType, IIfcFlowControllerType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcDamperTypeClause
	{
		WR1
	}

	private IfcDamperTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcDamperTypeEnum PredefinedType
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
			SetValue(delegate(IfcDamperTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcDamperType), 10)]
	Xbim.Ifc4.Interfaces.IfcDamperTypeEnum IIfcDamperType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcDamperTypeEnum.CONTROLDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.CONTROLDAMPER, 
				IfcDamperTypeEnum.FIREDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.FIREDAMPER, 
				IfcDamperTypeEnum.SMOKEDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.SMOKEDAMPER, 
				IfcDamperTypeEnum.FIRESMOKEDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.FIRESMOKEDAMPER, 
				IfcDamperTypeEnum.BACKDRAFTDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.BACKDRAFTDAMPER, 
				IfcDamperTypeEnum.RELIEFDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.RELIEFDAMPER, 
				IfcDamperTypeEnum.BLASTDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.BLASTDAMPER, 
				IfcDamperTypeEnum.GRAVITYDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.GRAVITYDAMPER, 
				IfcDamperTypeEnum.GRAVITYRELIEFDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.GRAVITYRELIEFDAMPER, 
				IfcDamperTypeEnum.BALANCINGDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.BALANCINGDAMPER, 
				IfcDamperTypeEnum.FUMEHOODEXHAUST => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.FUMEHOODEXHAUST, 
				IfcDamperTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.USERDEFINED, 
				IfcDamperTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.BACKDRAFTDAMPER:
				PredefinedType = IfcDamperTypeEnum.BACKDRAFTDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.BALANCINGDAMPER:
				PredefinedType = IfcDamperTypeEnum.BALANCINGDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.BLASTDAMPER:
				PredefinedType = IfcDamperTypeEnum.BLASTDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.CONTROLDAMPER:
				PredefinedType = IfcDamperTypeEnum.CONTROLDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.FIREDAMPER:
				PredefinedType = IfcDamperTypeEnum.FIREDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.FIRESMOKEDAMPER:
				PredefinedType = IfcDamperTypeEnum.FIRESMOKEDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.FUMEHOODEXHAUST:
				PredefinedType = IfcDamperTypeEnum.FUMEHOODEXHAUST;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.GRAVITYDAMPER:
				PredefinedType = IfcDamperTypeEnum.GRAVITYDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.GRAVITYRELIEFDAMPER:
				PredefinedType = IfcDamperTypeEnum.GRAVITYRELIEFDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.RELIEFDAMPER:
				PredefinedType = IfcDamperTypeEnum.RELIEFDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.SMOKEDAMPER:
				PredefinedType = IfcDamperTypeEnum.SMOKEDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.USERDEFINED:
				PredefinedType = IfcDamperTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.NOTDEFINED:
				PredefinedType = IfcDamperTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcDamperType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcDamperTypeEnum)Enum.Parse(typeof(IfcDamperTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDamperType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcDamperTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcDamperTypeClause.WR1)
			{
				result = PredefinedType != IfcDamperTypeEnum.USERDEFINED || (PredefinedType == IfcDamperTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDamperType>()?.LogError($"Exception thrown evaluating where-clause 'IfcDamperType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcDamperTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDamperType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
