using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.ProductExtension;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.SharedFacilitiesElements;

[ExpressType("IfcFurnitureType", 359)]
public class IfcFurnitureType : IfcFurnishingElementType, IInstantiableEntity, IPersistEntity, IPersist, IIfcFurnitureType, IIfcFurnishingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFurnitureType>, IExpressValidatable
{
	public enum IfcFurnitureTypeClause
	{
		CorrectPredefinedType
	}

	private IfcAssemblyPlaceEnum _assemblyPlace;

	private IfcFurnitureTypeEnum? _predefinedType;

	IfcAssemblyPlaceEnum IIfcFurnitureType.AssemblyPlace
	{
		get
		{
			return AssemblyPlace;
		}
		set
		{
			AssemblyPlace = value;
		}
	}

	IfcFurnitureTypeEnum? IIfcFurnitureType.PredefinedType
	{
		get
		{
			return PredefinedType;
		}
		set
		{
			PredefinedType = value;
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcAssemblyPlaceEnum AssemblyPlace
	{
		get
		{
			if (_activated)
			{
				return _assemblyPlace;
			}
			Activate();
			return _assemblyPlace;
		}
		set
		{
			SetValue(delegate(IfcAssemblyPlaceEnum v)
			{
				_assemblyPlace = v;
			}, _assemblyPlace, value, "AssemblyPlace", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 20)]
	public IfcFurnitureTypeEnum? PredefinedType
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
			SetValue(delegate(IfcFurnitureTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 11);
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
			foreach (IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
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
			foreach (IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	internal IfcFurnitureType(IModel model, int label, bool activated)
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
			_assemblyPlace = (IfcAssemblyPlaceEnum)Enum.Parse(typeof(IfcAssemblyPlaceEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_predefinedType = (IfcFurnitureTypeEnum)Enum.Parse(typeof(IfcFurnitureTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFurnitureType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcFurnitureTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcFurnitureTypeClause.CorrectPredefinedType)
			{
				result = PredefinedType != IfcFurnitureTypeEnum.USERDEFINED || (PredefinedType == IfcFurnitureTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcFurnitureType>()?.LogError($"Exception thrown evaluating where-clause 'IfcFurnitureType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcFurnitureTypeClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcFurnitureType.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
