using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedFacilitiesElements;

[ExpressType("IfcSystemFurnitureElementType", 422)]
public class IfcSystemFurnitureElementType : IfcFurnishingElementType, IIfcSystemFurnitureElementType, IIfcFurnishingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSystemFurnitureElementType>
{
	private IfcSystemFurnitureElementTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcSystemFurnitureElementType), 10)]
	Xbim.Ifc4.Interfaces.IfcSystemFurnitureElementTypeEnum? IIfcSystemFurnitureElementType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcSystemFurnitureElementTypeEnum.PANEL => Xbim.Ifc4.Interfaces.IfcSystemFurnitureElementTypeEnum.PANEL, 
				IfcSystemFurnitureElementTypeEnum.SUBRACK => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSystemFurnitureElementTypeEnum>(), 
				IfcSystemFurnitureElementTypeEnum.WORKSURFACE => Xbim.Ifc4.Interfaces.IfcSystemFurnitureElementTypeEnum.WORKSURFACE, 
				IfcSystemFurnitureElementTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcSystemFurnitureElementTypeEnum.USERDEFINED, 
				IfcSystemFurnitureElementTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcSystemFurnitureElementTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSystemFurnitureElementTypeEnum.PANEL:
				PredefinedType = IfcSystemFurnitureElementTypeEnum.PANEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcSystemFurnitureElementTypeEnum.WORKSURFACE:
				PredefinedType = IfcSystemFurnitureElementTypeEnum.WORKSURFACE;
				break;
			case Xbim.Ifc4.Interfaces.IfcSystemFurnitureElementTypeEnum.USERDEFINED:
				PredefinedType = IfcSystemFurnitureElementTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSystemFurnitureElementTypeEnum.NOTDEFINED:
				PredefinedType = IfcSystemFurnitureElementTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcSystemFurnitureElementTypeEnum? PredefinedType
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
			SetValue(delegate(IfcSystemFurnitureElementTypeEnum? v)
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
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
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
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	internal IfcSystemFurnitureElementType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSystemFurnitureElementTypeEnum)Enum.Parse(typeof(IfcSystemFurnitureElementTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSystemFurnitureElementType other)
	{
		return this == other;
	}
}
