using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedFacilitiesElements;

[ExpressType("IfcSystemFurnitureElement", 1291)]
public class IfcSystemFurnitureElement : IfcFurnishingElement, IIfcSystemFurnitureElement, IIfcFurnishingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSystemFurnitureElement>
{
	private IfcSystemFurnitureElementTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcSystemFurnitureElement), 9)]
	Xbim.Ifc4.Interfaces.IfcSystemFurnitureElementTypeEnum? IIfcSystemFurnitureElement.PredefinedType
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

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 35)]
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

	internal IfcSystemFurnitureElement(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSystemFurnitureElementTypeEnum)Enum.Parse(typeof(IfcSystemFurnitureElementTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSystemFurnitureElement other)
	{
		return this == other;
	}
}
