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

[ExpressType("IfcPipeSegmentType", 62)]
public class IfcPipeSegmentType : IfcFlowSegmentType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPipeSegmentType>, IIfcPipeSegmentType, IIfcFlowSegmentType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcPipeSegmentTypeClause
	{
		WR1
	}

	private IfcPipeSegmentTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcPipeSegmentTypeEnum PredefinedType
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
			SetValue(delegate(IfcPipeSegmentTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcPipeSegmentType), 10)]
	Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum IIfcPipeSegmentType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcPipeSegmentTypeEnum.FLEXIBLESEGMENT:
				return Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.FLEXIBLESEGMENT;
			case IfcPipeSegmentTypeEnum.RIGIDSEGMENT:
				return Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.RIGIDSEGMENT;
			case IfcPipeSegmentTypeEnum.GUTTER:
				return Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.GUTTER;
			case IfcPipeSegmentTypeEnum.SPOOL:
				return Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.SPOOL;
			case IfcPipeSegmentTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.USERDEFINED;
			}
			case IfcPipeSegmentTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.CULVERT:
				base.ElementType = value.ToString();
				PredefinedType = IfcPipeSegmentTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.FLEXIBLESEGMENT:
				PredefinedType = IfcPipeSegmentTypeEnum.FLEXIBLESEGMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.RIGIDSEGMENT:
				PredefinedType = IfcPipeSegmentTypeEnum.RIGIDSEGMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.GUTTER:
				PredefinedType = IfcPipeSegmentTypeEnum.GUTTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.SPOOL:
				PredefinedType = IfcPipeSegmentTypeEnum.SPOOL;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.USERDEFINED:
				PredefinedType = IfcPipeSegmentTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeSegmentTypeEnum.NOTDEFINED:
				PredefinedType = IfcPipeSegmentTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcPipeSegmentType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcPipeSegmentTypeEnum)Enum.Parse(typeof(IfcPipeSegmentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPipeSegmentType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPipeSegmentTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPipeSegmentTypeClause.WR1)
			{
				result = PredefinedType != IfcPipeSegmentTypeEnum.USERDEFINED || (PredefinedType == IfcPipeSegmentTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPipeSegmentType>()?.LogError($"Exception thrown evaluating where-clause 'IfcPipeSegmentType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcPipeSegmentTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPipeSegmentType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
