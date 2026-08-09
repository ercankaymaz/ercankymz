using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometricConstraintResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcRelSpaceBoundary", 15)]
public class IfcRelSpaceBoundary : IfcRelConnects, IIfcRelSpaceBoundary, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelSpaceBoundary>, IExpressValidatable
{
	public enum IfcRelSpaceBoundaryClause
	{
		WR1
	}

	private IIfcSpaceBoundarySelect _relatingSpace4;

	private IfcSpace _relatingSpace;

	private IfcElement _relatedBuildingElement;

	private IfcConnectionGeometry _connectionGeometry;

	private IfcPhysicalOrVirtualEnum _physicalOrVirtualBoundary;

	private IfcInternalOrExternalEnum _internalOrExternalBoundary;

	[CrossSchemaAttribute(typeof(IIfcRelSpaceBoundary), 5)]
	IIfcSpaceBoundarySelect IIfcRelSpaceBoundary.RelatingSpace
	{
		get
		{
			return _relatingSpace4 ?? RelatingSpace;
		}
		set
		{
			if (value == null)
			{
				RelatingSpace = null;
				if (_relatingSpace4 != null)
				{
					SetValue(delegate(IIfcSpaceBoundarySelect v)
					{
						_relatingSpace4 = v;
					}, _relatingSpace4, null, "RelatingSpace", -5);
				}
				return;
			}
			IfcSpace ifcSpace = value as IfcSpace;
			if (ifcSpace != null)
			{
				RelatingSpace = ifcSpace;
				if (_relatingSpace4 != null)
				{
					SetValue(delegate(IIfcSpaceBoundarySelect v)
					{
						_relatingSpace4 = v;
					}, _relatingSpace4, null, "RelatingSpace", -5);
				}
			}
			else
			{
				if (RelatingSpace != null)
				{
					RelatingSpace = null;
				}
				SetValue(delegate(IIfcSpaceBoundarySelect v)
				{
					_relatingSpace4 = v;
				}, _relatingSpace4, value, "RelatingSpace", -5);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelSpaceBoundary), 6)]
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

	[CrossSchemaAttribute(typeof(IIfcRelSpaceBoundary), 7)]
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

	[CrossSchemaAttribute(typeof(IIfcRelSpaceBoundary), 8)]
	Xbim.Ifc4.Interfaces.IfcPhysicalOrVirtualEnum IIfcRelSpaceBoundary.PhysicalOrVirtualBoundary
	{
		get
		{
			return PhysicalOrVirtualBoundary switch
			{
				IfcPhysicalOrVirtualEnum.PHYSICAL => Xbim.Ifc4.Interfaces.IfcPhysicalOrVirtualEnum.PHYSICAL, 
				IfcPhysicalOrVirtualEnum.VIRTUAL => Xbim.Ifc4.Interfaces.IfcPhysicalOrVirtualEnum.VIRTUAL, 
				IfcPhysicalOrVirtualEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcPhysicalOrVirtualEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcPhysicalOrVirtualEnum.PHYSICAL:
				PhysicalOrVirtualBoundary = IfcPhysicalOrVirtualEnum.PHYSICAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcPhysicalOrVirtualEnum.VIRTUAL:
				PhysicalOrVirtualBoundary = IfcPhysicalOrVirtualEnum.VIRTUAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcPhysicalOrVirtualEnum.NOTDEFINED:
				PhysicalOrVirtualBoundary = IfcPhysicalOrVirtualEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelSpaceBoundary), 9)]
	Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum IIfcRelSpaceBoundary.InternalOrExternalBoundary
	{
		get
		{
			if (base.Description.HasValue)
			{
				switch (base.Description.Value)
				{
				case "EXTERNAL_EARTH":
				case "EXTERNAL_WATER":
				case "EXTERNAL_FIRE":
					return (Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum)Enum.Parse(typeof(Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum), base.Description.Value);
				}
			}
			return InternalOrExternalBoundary switch
			{
				IfcInternalOrExternalEnum.INTERNAL => Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum.INTERNAL, 
				IfcInternalOrExternalEnum.EXTERNAL => Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum.EXTERNAL, 
				IfcInternalOrExternalEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum.INTERNAL:
				InternalOrExternalBoundary = IfcInternalOrExternalEnum.INTERNAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum.EXTERNAL:
				InternalOrExternalBoundary = IfcInternalOrExternalEnum.EXTERNAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum.EXTERNAL_EARTH:
				base.Description = value.ToString();
				break;
			case Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum.EXTERNAL_WATER:
				base.Description = value.ToString();
				break;
			case Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum.EXTERNAL_FIRE:
				base.Description = value.ToString();
				break;
			case Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum.NOTDEFINED:
				InternalOrExternalBoundary = IfcInternalOrExternalEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcSpace RelatingSpace
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
			SetValue(delegate(IfcSpace v)
			{
				_relatingSpace = v;
			}, _relatingSpace, value, "RelatingSpace", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
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
			_relatingSpace = (IfcSpace)value.EntityVal;
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
			if (clause == IfcRelSpaceBoundaryClause.WR1)
			{
				result = (PhysicalOrVirtualBoundary == IfcPhysicalOrVirtualEnum.PHYSICAL && Functions.EXISTS(RelatedBuildingElement) && !Functions.TYPEOF(RelatedBuildingElement).Contains("IFC2X3.IFCVIRTUALELEMENT")) || (PhysicalOrVirtualBoundary == IfcPhysicalOrVirtualEnum.VIRTUAL && (!Functions.EXISTS(RelatedBuildingElement) || Functions.TYPEOF(RelatedBuildingElement).Contains("IFC2X3.IFCVIRTUALELEMENT"))) || PhysicalOrVirtualBoundary == IfcPhysicalOrVirtualEnum.NOTDEFINED;
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
		if (!ValidateClause(IfcRelSpaceBoundaryClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelSpaceBoundary.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
