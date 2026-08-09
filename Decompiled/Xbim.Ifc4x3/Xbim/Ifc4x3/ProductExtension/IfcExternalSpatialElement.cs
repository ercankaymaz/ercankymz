using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.ProductExtension;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcExternalSpatialElement", 1174)]
public class IfcExternalSpatialElement : IfcExternalSpatialStructureElement, IIfcExternalSpatialElement, IIfcExternalSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, Xbim.Ifc4.ProductExtension.IfcSpaceBoundarySelect, IIfcSpaceBoundarySelect, IInstantiableEntity, IfcSpaceBoundarySelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcExternalSpatialElement>
{
	private IfcExternalSpatialElementTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcExternalSpatialElement), 9)]
	Xbim.Ifc4.Interfaces.IfcExternalSpatialElementTypeEnum? IIfcExternalSpatialElement.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcExternalSpatialElementTypeEnum.EXTERNAL => Xbim.Ifc4.Interfaces.IfcExternalSpatialElementTypeEnum.EXTERNAL, 
				IfcExternalSpatialElementTypeEnum.EXTERNAL_EARTH => Xbim.Ifc4.Interfaces.IfcExternalSpatialElementTypeEnum.EXTERNAL_EARTH, 
				IfcExternalSpatialElementTypeEnum.EXTERNAL_FIRE => Xbim.Ifc4.Interfaces.IfcExternalSpatialElementTypeEnum.EXTERNAL_FIRE, 
				IfcExternalSpatialElementTypeEnum.EXTERNAL_WATER => Xbim.Ifc4.Interfaces.IfcExternalSpatialElementTypeEnum.EXTERNAL_WATER, 
				IfcExternalSpatialElementTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcExternalSpatialElementTypeEnum.USERDEFINED, 
				IfcExternalSpatialElementTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcExternalSpatialElementTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcExternalSpatialElementTypeEnum.EXTERNAL:
				PredefinedType = IfcExternalSpatialElementTypeEnum.EXTERNAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcExternalSpatialElementTypeEnum.EXTERNAL_EARTH:
				PredefinedType = IfcExternalSpatialElementTypeEnum.EXTERNAL_EARTH;
				break;
			case Xbim.Ifc4.Interfaces.IfcExternalSpatialElementTypeEnum.EXTERNAL_WATER:
				PredefinedType = IfcExternalSpatialElementTypeEnum.EXTERNAL_WATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcExternalSpatialElementTypeEnum.EXTERNAL_FIRE:
				PredefinedType = IfcExternalSpatialElementTypeEnum.EXTERNAL_FIRE;
				break;
			case Xbim.Ifc4.Interfaces.IfcExternalSpatialElementTypeEnum.USERDEFINED:
				PredefinedType = IfcExternalSpatialElementTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcExternalSpatialElementTypeEnum.NOTDEFINED:
				PredefinedType = IfcExternalSpatialElementTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	IEnumerable<IIfcRelSpaceBoundary> IIfcExternalSpatialElement.BoundedBy => base.Model.Instances.Where((IIfcRelSpaceBoundary e) => e.RelatingSpace as IfcExternalSpatialElement == this, "RelatingSpace", this);

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 28)]
	public IfcExternalSpatialElementTypeEnum? PredefinedType
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
			SetValue(delegate(IfcExternalSpatialElementTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
		}
	}

	[InverseProperty("RelatingSpace")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 29)]
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

	internal IfcExternalSpatialElement(IModel model, int label, bool activated)
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
			_predefinedType = (IfcExternalSpatialElementTypeEnum)Enum.Parse(typeof(IfcExternalSpatialElementTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcExternalSpatialElement other)
	{
		return this == other;
	}
}
