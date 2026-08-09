using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.GeometricConstraintResource;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcRelSpaceBoundary", 15)]
public class IfcRelSpaceBoundary : IfcRelConnects, IIfcRelSpaceBoundary, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelSpaceBoundary>
{
	private IfcSpaceBoundarySelect _relatingSpace;

	private IfcElement _relatedBuildingElement;

	private IfcConnectionGeometry _connectionGeometry;

	private IfcPhysicalOrVirtualEnum _physicalOrVirtualBoundary;

	private IfcInternalOrExternalEnum _internalOrExternalBoundary;

	[CrossSchemaAttribute(typeof(IIfcRelSpaceBoundary), 5)]
	IIfcSpaceBoundarySelect IIfcRelSpaceBoundary.RelatingSpace
	{
		get
		{
			if (RelatingSpace == null)
			{
				return null;
			}
			IfcExternalSpatialElement ifcExternalSpatialElement = RelatingSpace as IfcExternalSpatialElement;
			if (ifcExternalSpatialElement != null)
			{
				return ifcExternalSpatialElement;
			}
			IfcSpace ifcSpace = RelatingSpace as IfcSpace;
			if (ifcSpace != null)
			{
				return ifcSpace;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				RelatingSpace = null;
				return;
			}
			IfcExternalSpatialElement ifcExternalSpatialElement = value as IfcExternalSpatialElement;
			if (ifcExternalSpatialElement != null)
			{
				RelatingSpace = ifcExternalSpatialElement;
				return;
			}
			IfcSpace ifcSpace = value as IfcSpace;
			if (ifcSpace != null)
			{
				RelatingSpace = ifcSpace;
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
			return InternalOrExternalBoundary switch
			{
				IfcInternalOrExternalEnum.EXTERNAL => Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum.EXTERNAL, 
				IfcInternalOrExternalEnum.EXTERNAL_EARTH => Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum.EXTERNAL_EARTH, 
				IfcInternalOrExternalEnum.EXTERNAL_FIRE => Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum.EXTERNAL_FIRE, 
				IfcInternalOrExternalEnum.EXTERNAL_WATER => Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum.EXTERNAL_WATER, 
				IfcInternalOrExternalEnum.INTERNAL => Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum.INTERNAL, 
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
				InternalOrExternalBoundary = IfcInternalOrExternalEnum.EXTERNAL_EARTH;
				break;
			case Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum.EXTERNAL_WATER:
				InternalOrExternalBoundary = IfcInternalOrExternalEnum.EXTERNAL_WATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum.EXTERNAL_FIRE:
				InternalOrExternalBoundary = IfcInternalOrExternalEnum.EXTERNAL_FIRE;
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
}
