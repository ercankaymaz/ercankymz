using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedFacilitiesElements;

[ExpressType("IfcFurniture", 1184)]
public class IfcFurniture : IfcFurnishingElement, IIfcFurniture, IIfcFurnishingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFurniture>
{
	private IfcFurnitureTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcFurniture), 9)]
	Xbim.Ifc4.Interfaces.IfcFurnitureTypeEnum? IIfcFurniture.PredefinedType
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

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 35)]
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
			}, _predefinedType, value, "PredefinedType", 9);
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

	internal IfcFurniture(IModel model, int label, bool activated)
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
			_predefinedType = (IfcFurnitureTypeEnum)Enum.Parse(typeof(IfcFurnitureTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFurniture other)
	{
		return this == other;
	}
}
