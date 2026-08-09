using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcBuildingElementProxy", 560)]
public class IfcBuildingElementProxy : IfcBuildingElement, IIfcBuildingElementProxy, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcBuildingElementProxy>, IExpressValidatable
{
	public enum IfcBuildingElementProxyClause
	{
		WR1
	}

	private Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum? _predefinedType;

	private IfcElementCompositionEnum? _compositionType;

	[CrossSchemaAttribute(typeof(IIfcBuildingElementProxy), 9)]
	Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum? IIfcBuildingElementProxy.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -9);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 27)]
	public IfcElementCompositionEnum? CompositionType
	{
		get
		{
			if (_activated)
			{
				return _compositionType;
			}
			Activate();
			return _compositionType;
		}
		set
		{
			SetValue(delegate(IfcElementCompositionEnum? v)
			{
				_compositionType = v;
			}, _compositionType, value, "CompositionType", 9);
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

	internal IfcBuildingElementProxy(IModel model, int label, bool activated)
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
			_compositionType = (IfcElementCompositionEnum)Enum.Parse(typeof(IfcElementCompositionEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBuildingElementProxy other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcBuildingElementProxyClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcBuildingElementProxyClause.WR1)
			{
				result = Functions.EXISTS(base.Name);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcBuildingElementProxy>()?.LogError($"Exception thrown evaluating where-clause 'IfcBuildingElementProxy.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcBuildingElementProxyClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBuildingElementProxy.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
