using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.StructuralElementsDomain;

[ExpressType("IfcFootingType", 1183)]
public class IfcFootingType : IfcBuiltElementType, IIfcFootingType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFootingType>
{
	private IfcFootingTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcFootingType), 10)]
	Xbim.Ifc4.Interfaces.IfcFootingTypeEnum IIfcFootingType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcFootingTypeEnum.CAISSON_FOUNDATION => Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.CAISSON_FOUNDATION, 
				IfcFootingTypeEnum.FOOTING_BEAM => Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.FOOTING_BEAM, 
				IfcFootingTypeEnum.PAD_FOOTING => Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.PAD_FOOTING, 
				IfcFootingTypeEnum.PILE_CAP => Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.PILE_CAP, 
				IfcFootingTypeEnum.STRIP_FOOTING => Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.STRIP_FOOTING, 
				IfcFootingTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.USERDEFINED, 
				IfcFootingTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.CAISSON_FOUNDATION:
				PredefinedType = IfcFootingTypeEnum.CAISSON_FOUNDATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.FOOTING_BEAM:
				PredefinedType = IfcFootingTypeEnum.FOOTING_BEAM;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.PAD_FOOTING:
				PredefinedType = IfcFootingTypeEnum.PAD_FOOTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.PILE_CAP:
				PredefinedType = IfcFootingTypeEnum.PILE_CAP;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.STRIP_FOOTING:
				PredefinedType = IfcFootingTypeEnum.STRIP_FOOTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.USERDEFINED:
				PredefinedType = IfcFootingTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFootingTypeEnum.NOTDEFINED:
				PredefinedType = IfcFootingTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcFootingTypeEnum PredefinedType
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
			SetValue(delegate(IfcFootingTypeEnum v)
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

	internal IfcFootingType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcFootingTypeEnum)Enum.Parse(typeof(IfcFootingTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFootingType other)
	{
		return this == other;
	}
}
