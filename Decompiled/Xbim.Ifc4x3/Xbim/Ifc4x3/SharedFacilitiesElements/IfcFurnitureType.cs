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

[ExpressType("IfcFurnitureType", 359)]
public class IfcFurnitureType : IfcFurnishingElementType, IIfcFurnitureType, IIfcFurnishingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFurnitureType>
{
	private Xbim.Ifc4x3.ProductExtension.IfcAssemblyPlaceEnum _assemblyPlace;

	private IfcFurnitureTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcFurnitureType), 10)]
	Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum IIfcFurnitureType.AssemblyPlace
	{
		get
		{
			return AssemblyPlace switch
			{
				Xbim.Ifc4x3.ProductExtension.IfcAssemblyPlaceEnum.FACTORY => Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.FACTORY, 
				Xbim.Ifc4x3.ProductExtension.IfcAssemblyPlaceEnum.SITE => Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.SITE, 
				Xbim.Ifc4x3.ProductExtension.IfcAssemblyPlaceEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.SITE:
				AssemblyPlace = Xbim.Ifc4x3.ProductExtension.IfcAssemblyPlaceEnum.SITE;
				break;
			case Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.FACTORY:
				AssemblyPlace = Xbim.Ifc4x3.ProductExtension.IfcAssemblyPlaceEnum.FACTORY;
				break;
			case Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.NOTDEFINED:
				AssemblyPlace = Xbim.Ifc4x3.ProductExtension.IfcAssemblyPlaceEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFurnitureType), 11)]
	Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum? IIfcFurnitureType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcFurnitureTypeEnum.BED => Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.BED, 
				IfcFurnitureTypeEnum.CHAIR => Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.CHAIR, 
				IfcFurnitureTypeEnum.DESK => Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.DESK, 
				IfcFurnitureTypeEnum.FILECABINET => Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.FILECABINET, 
				IfcFurnitureTypeEnum.SHELF => Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.SHELF, 
				IfcFurnitureTypeEnum.SOFA => Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.SOFA, 
				IfcFurnitureTypeEnum.TABLE => Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.TABLE, 
				IfcFurnitureTypeEnum.TECHNICALCABINET => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum>(), 
				IfcFurnitureTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.USERDEFINED, 
				IfcFurnitureTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.CHAIR:
				PredefinedType = IfcFurnitureTypeEnum.CHAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.TABLE:
				PredefinedType = IfcFurnitureTypeEnum.TABLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.DESK:
				PredefinedType = IfcFurnitureTypeEnum.DESK;
				break;
			case Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.BED:
				PredefinedType = IfcFurnitureTypeEnum.BED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.FILECABINET:
				PredefinedType = IfcFurnitureTypeEnum.FILECABINET;
				break;
			case Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.SHELF:
				PredefinedType = IfcFurnitureTypeEnum.SHELF;
				break;
			case Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.SOFA:
				PredefinedType = IfcFurnitureTypeEnum.SOFA;
				break;
			case Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.USERDEFINED:
				PredefinedType = IfcFurnitureTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum.NOTDEFINED:
				PredefinedType = IfcFurnitureTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public Xbim.Ifc4x3.ProductExtension.IfcAssemblyPlaceEnum AssemblyPlace
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
			SetValue(delegate(Xbim.Ifc4x3.ProductExtension.IfcAssemblyPlaceEnum v)
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
			_assemblyPlace = (Xbim.Ifc4x3.ProductExtension.IfcAssemblyPlaceEnum)Enum.Parse(typeof(Xbim.Ifc4x3.ProductExtension.IfcAssemblyPlaceEnum), value.EnumVal, ignoreCase: true);
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
}
