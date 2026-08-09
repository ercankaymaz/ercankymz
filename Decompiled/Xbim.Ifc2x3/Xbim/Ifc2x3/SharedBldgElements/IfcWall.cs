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
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.QuantityResource;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.SharedBldgElements;

[ExpressType("IfcWall", 452)]
public class IfcWall : IfcBuildingElement, IIfcWall, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcWall>, IExpressValidatable
{
	public enum IfcWallClause
	{
		WR1
	}

	private Xbim.Ifc4.Interfaces.IfcWallTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcWall), 9)]
	Xbim.Ifc4.Interfaces.IfcWallTypeEnum? IIfcWall.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.Interfaces.IfcWallTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -9);
		}
	}

	public Xbim.Ifc4.MeasureResource.IfcAreaMeasure? GetWallSideArea
	{
		get
		{
			IfcQuantityArea quantity = GetQuantity<IfcQuantityArea>("BaseQuantities", "GrossSideArea");
			if (quantity == null)
			{
				quantity = GetQuantity<IfcQuantityArea>("GrossSideArea");
			}
			if (quantity != null)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAreaMeasure(quantity.AreaValue);
			}
			return null;
		}
	}

	public Xbim.Ifc4.MeasureResource.IfcBoolean? IsExternal
	{
		get
		{
			Xbim.Ifc2x3.MeasureResource.IfcValue propertySingleNominalValue = GetPropertySingleNominalValue("Pset_WallCommon", "IsExternal");
			if (propertySingleNominalValue != null && propertySingleNominalValue is Xbim.Ifc2x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc2x3.MeasureResource.IfcBoolean)(object)propertySingleNominalValue);
			}
			return null;
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

	internal IfcWall(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 7u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcWall other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcWallClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcWallClause.WR1)
			{
				result = Functions.SIZEOF(base.HasAssociations.Where((Xbim.Ifc2x3.Kernel.IfcRelAssociates temp) => Functions.TYPEOF(temp).Contains("IFC2X3.IFCRELASSOCIATESMATERIAL"))) <= 1;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcWall>()?.LogError($"Exception thrown evaluating where-clause 'IfcWall.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcWallClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcWall.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
