using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcRelSpaceBoundary", 15)]
public class IfcRelSpaceBoundary : IfcRelConnects, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelSpaceBoundary, IIfcRelConnects, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelSpaceBoundary>, IExpressValidatable
{
	public enum IfcRelSpaceBoundaryClause
	{
		CorrectPhysOrVirt
	}

	private IfcSpaceBoundarySelect _relatingSpace;

	private IfcElement _relatedBuildingElement;

	private IfcConnectionGeometry _connectionGeometry;

	private IfcPhysicalOrVirtualEnum _physicalOrVirtualBoundary;

	private IfcInternalOrExternalEnum _internalOrExternalBoundary;

	IIfcSpaceBoundarySelect IIfcRelSpaceBoundary.RelatingSpace
	{
		get
		{
			return RelatingSpace;
		}
		set
		{
			RelatingSpace = value as IfcSpaceBoundarySelect;
		}
	}

	IIfcElement IIfcRelSpaceBoundary.RelatedBuildingElement
	{
		get
		{
			return RelatedBuildingElement;
		}
		set
		{
			RelatedBuildingElement = value as IfcElement;
		}
	}

	IIfcConnectionGeometry IIfcRelSpaceBoundary.ConnectionGeometry
	{
		get
		{
			return ConnectionGeometry;
		}
		set
		{
			ConnectionGeometry = value as IfcConnectionGeometry;
		}
	}

	IfcPhysicalOrVirtualEnum IIfcRelSpaceBoundary.PhysicalOrVirtualBoundary
	{
		get
		{
			return PhysicalOrVirtualBoundary;
		}
		set
		{
			PhysicalOrVirtualBoundary = value;
		}
	}

	IfcInternalOrExternalEnum IIfcRelSpaceBoundary.InternalOrExternalBoundary
	{
		get
		{
			return InternalOrExternalBoundary;
		}
		set
		{
			InternalOrExternalBoundary = value;
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcSpaceBoundarySelect RelatingSpace
	{
		get
		{
			if (_activated)
			{
				return _relatingSpace;
			}
			Activate();
			return _relatingSpace;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSpaceBoundarySelect v)
			{
				_relatingSpace = v;
			}, _relatingSpace, value, "RelatingSpace", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcElement RelatedBuildingElement
	{
		get
		{
			if (_activated)
			{
				return _relatedBuildingElement;
			}
			Activate();
			return _relatedBuildingElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcElement v)
			{
				_relatedBuildingElement = v;
			}, _relatedBuildingElement, value, "RelatedBuildingElement", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcConnectionGeometry ConnectionGeometry
	{
		get
		{
			if (_activated)
			{
				return _connectionGeometry;
			}
			Activate();
			return _connectionGeometry;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcConnectionGeometry v)
			{
				_connectionGeometry = v;
			}, _connectionGeometry, value, "ConnectionGeometry", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 8)]
	public IfcPhysicalOrVirtualEnum PhysicalOrVirtualBoundary
	{
		get
		{
			if (_activated)
			{
				return _physicalOrVirtualBoundary;
			}
			Activate();
			return _physicalOrVirtualBoundary;
		}
		set
		{
			SetValue(delegate(IfcPhysicalOrVirtualEnum v)
			{
				_physicalOrVirtualBoundary = v;
			}, _physicalOrVirtualBoundary, value, "PhysicalOrVirtualBoundary", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 9)]
	public IfcInternalOrExternalEnum InternalOrExternalBoundary
	{
		get
		{
			if (_activated)
			{
				return _internalOrExternalBoundary;
			}
			Activate();
			return _internalOrExternalBoundary;
		}
		set
		{
			SetValue(delegate(IfcInternalOrExternalEnum v)
			{
				_internalOrExternalBoundary = v;
			}, _internalOrExternalBoundary, value, "InternalOrExternalBoundary", 9);
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
			if (RelatingSpace != null)
			{
				yield return RelatingSpace;
			}
			if (RelatedBuildingElement != null)
			{
				yield return RelatedBuildingElement;
			}
			if (ConnectionGeometry != null)
			{
				yield return ConnectionGeometry;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingSpace != null)
			{
				yield return RelatingSpace;
			}
			if (RelatedBuildingElement != null)
			{
				yield return RelatedBuildingElement;
			}
		}
	}

	internal IfcRelSpaceBoundary(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_relatingSpace = (IfcSpaceBoundarySelect)value.EntityVal;
			break;
		case 5:
			_relatedBuildingElement = (IfcElement)value.EntityVal;
			break;
		case 6:
			_connectionGeometry = (IfcConnectionGeometry)value.EntityVal;
			break;
		case 7:
			_physicalOrVirtualBoundary = (IfcPhysicalOrVirtualEnum)Enum.Parse(typeof(IfcPhysicalOrVirtualEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_internalOrExternalBoundary = (IfcInternalOrExternalEnum)Enum.Parse(typeof(IfcInternalOrExternalEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelSpaceBoundary other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelSpaceBoundaryClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelSpaceBoundaryClause.CorrectPhysOrVirt)
			{
				result = (PhysicalOrVirtualBoundary == IfcPhysicalOrVirtualEnum.PHYSICAL && !Functions.TYPEOF(RelatedBuildingElement).Contains("IFC4.IFCVIRTUALELEMENT")) || (PhysicalOrVirtualBoundary == IfcPhysicalOrVirtualEnum.VIRTUAL && (Functions.TYPEOF(RelatedBuildingElement).Contains("IFC4.IFCVIRTUALELEMENT") || Functions.TYPEOF(RelatedBuildingElement).Contains("IFC4.IFCOPENINGELEMENT"))) || PhysicalOrVirtualBoundary == IfcPhysicalOrVirtualEnum.NOTDEFINED;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelSpaceBoundary>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelSpaceBoundary.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRelSpaceBoundaryClause.CorrectPhysOrVirt))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelSpaceBoundary.CorrectPhysOrVirt",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
