using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.SharedBldgElements;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcSpace", 454)]
public class IfcSpace : IfcSpatialStructureElement, IInstantiableEntity, IPersistEntity, IPersist, IIfcSpace, IIfcSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcSpaceBoundarySelect, IIfcSpaceBoundarySelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSpace>, IExpressValidatable
{
	public enum IfcSpaceClause
	{
		CorrectPredefinedType,
		CorrectTypeAssigned
	}

	private IfcSpaceTypeEnum? _predefinedType;

	private IfcLengthMeasure? _elevationWithFlooring;

	IfcSpaceTypeEnum? IIfcSpace.PredefinedType
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

	IfcLengthMeasure? IIfcSpace.ElevationWithFlooring
	{
		get
		{
			return ElevationWithFlooring;
		}
		set
		{
			ElevationWithFlooring = value;
		}
	}

	IEnumerable<IIfcRelCoversSpaces> IIfcSpace.HasCoverings => HasCoverings;

	IEnumerable<IIfcRelSpaceBoundary> IIfcSpace.BoundedBy => BoundedBy;

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 25)]
	public IfcSpaceTypeEnum? PredefinedType
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
			SetValue(delegate(IfcSpaceTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 26)]
	public IfcLengthMeasure? ElevationWithFlooring
	{
		get
		{
			if (_activated)
			{
				return _elevationWithFlooring;
			}
			Activate();
			return _elevationWithFlooring;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_elevationWithFlooring = v;
			}, _elevationWithFlooring, value, "ElevationWithFlooring", 11);
		}
	}

	[InverseProperty("RelatingSpace")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 27)]
	public IEnumerable<IfcRelCoversSpaces> HasCoverings => base.Model.Instances.Where((IfcRelCoversSpaces e) => Equals(e.RelatingSpace), "RelatingSpace", this);

	[InverseProperty("RelatingSpace")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 28)]
	public IEnumerable<IfcRelSpaceBoundary> BoundedBy => base.Model.Instances.Where((IfcRelSpaceBoundary e) => Equals(e.RelatingSpace), "RelatingSpace", this);

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

	public IfcAreaMeasure? GrossFloorArea => (GetQuantity<IIfcQuantityArea>("BaseQuantities", "GrossFloorArea") ?? GetQuantity<IIfcQuantityArea>("GrossFloorArea"))?.AreaValue;

	public IfcAreaMeasure? NetFloorArea
	{
		get
		{
			IIfcQuantityArea ifcQuantityArea = GetQuantity<IIfcQuantityArea>("BaseQuantities", "NetFloorArea") ?? GetQuantity<IIfcQuantityArea>("NetFloorArea");
			if (ifcQuantityArea != null)
			{
				return ifcQuantityArea.AreaValue;
			}
			return GetQuantity<IIfcQuantityArea>("GSA Space Areas", "GSA BIM Area")?.AreaValue;
		}
	}

	public IfcLengthMeasure? Height => (GetQuantity<IIfcQuantityLength>("BaseQuantities", "Height") ?? GetQuantity<IIfcQuantityLength>("Height"))?.LengthValue;

	public IfcLengthMeasure? GrossPerimeter => (GetQuantity<IIfcQuantityLength>("BaseQuantities", "GrossPerimeter") ?? GetQuantity<IIfcQuantityLength>("GrossPerimeter"))?.LengthValue;

	public IEnumerable<IIfcSpace> Spaces => base.IsDecomposedBy.SelectMany((IfcRelAggregates s) => s.RelatedObjects).OfType<IIfcSpace>();

	internal IfcSpace(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSpaceTypeEnum)Enum.Parse(typeof(IfcSpaceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_elevationWithFlooring = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSpace other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcSpaceClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcSpaceClause.CorrectPredefinedType:
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcSpaceTypeEnum.USERDEFINED || (PredefinedType == IfcSpaceTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
				break;
			case IfcSpaceClause.CorrectTypeAssigned:
				result = Functions.SIZEOF(base.IsTypedBy) == 0 || Functions.TYPEOF(base.IsTypedBy.ItemAt(0L).RelatingType).Contains("IFC4.IFCSPACETYPE");
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSpace>()?.LogError($"Exception thrown evaluating where-clause 'IfcSpace.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcSpaceClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSpace.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSpaceClause.CorrectTypeAssigned))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSpace.CorrectTypeAssigned",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
