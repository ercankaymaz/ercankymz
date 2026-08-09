using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.SharedFacilitiesElements;

[ExpressType("IfcFurnitureType", 359)]
public class IfcFurnitureType : IfcFurnishingElementType, IIfcFurnitureType, IIfcFurnishingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFurnitureType>
{
	private IfcFurnitureTypeEnum? _predefinedType;

	private Xbim.Ifc2x3.ProductExtension.IfcAssemblyPlaceEnum _assemblyPlace;

	[CrossSchemaAttribute(typeof(IIfcFurnitureType), 10)]
	Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum IIfcFurnitureType.AssemblyPlace
	{
		get
		{
			return AssemblyPlace switch
			{
				Xbim.Ifc2x3.ProductExtension.IfcAssemblyPlaceEnum.SITE => Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.SITE, 
				Xbim.Ifc2x3.ProductExtension.IfcAssemblyPlaceEnum.FACTORY => Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.FACTORY, 
				Xbim.Ifc2x3.ProductExtension.IfcAssemblyPlaceEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.SITE:
				AssemblyPlace = Xbim.Ifc2x3.ProductExtension.IfcAssemblyPlaceEnum.SITE;
				break;
			case Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.FACTORY:
				AssemblyPlace = Xbim.Ifc2x3.ProductExtension.IfcAssemblyPlaceEnum.FACTORY;
				break;
			case Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.NOTDEFINED:
				AssemblyPlace = Xbim.Ifc2x3.ProductExtension.IfcAssemblyPlaceEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFurnitureType), 11)]
	IfcFurnitureTypeEnum? IIfcFurnitureType.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcFurnitureTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -11);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public Xbim.Ifc2x3.ProductExtension.IfcAssemblyPlaceEnum AssemblyPlace
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
			SetValue(delegate(Xbim.Ifc2x3.ProductExtension.IfcAssemblyPlaceEnum v)
			{
				_assemblyPlace = v;
			}, _assemblyPlace, value, "AssemblyPlace", 10);
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
			_assemblyPlace = (Xbim.Ifc2x3.ProductExtension.IfcAssemblyPlaceEnum)Enum.Parse(typeof(Xbim.Ifc2x3.ProductExtension.IfcAssemblyPlaceEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFurnitureType other)
	{
		return this == other;
	}
}
