using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcBuildingElementProxyType", 107)]
public class IfcBuildingElementProxyType : IfcBuiltElementType, IIfcBuildingElementProxyType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcBuildingElementProxyType>
{
	private IfcBuildingElementProxyTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcBuildingElementProxyType), 10)]
	Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum IIfcBuildingElementProxyType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcBuildingElementProxyTypeEnum.COMPLEX => Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum.COMPLEX, 
				IfcBuildingElementProxyTypeEnum.ELEMENT => Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum.ELEMENT, 
				IfcBuildingElementProxyTypeEnum.PARTIAL => Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum.PARTIAL, 
				IfcBuildingElementProxyTypeEnum.PROVISIONFORSPACE => Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum.PROVISIONFORSPACE, 
				IfcBuildingElementProxyTypeEnum.PROVISIONFORVOID => Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum.PROVISIONFORVOID, 
				IfcBuildingElementProxyTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum.USERDEFINED, 
				IfcBuildingElementProxyTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum.COMPLEX:
				PredefinedType = IfcBuildingElementProxyTypeEnum.COMPLEX;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum.ELEMENT:
				PredefinedType = IfcBuildingElementProxyTypeEnum.ELEMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum.PARTIAL:
				PredefinedType = IfcBuildingElementProxyTypeEnum.PARTIAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum.PROVISIONFORVOID:
				PredefinedType = IfcBuildingElementProxyTypeEnum.PROVISIONFORVOID;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum.PROVISIONFORSPACE:
				PredefinedType = IfcBuildingElementProxyTypeEnum.PROVISIONFORSPACE;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum.USERDEFINED:
				PredefinedType = IfcBuildingElementProxyTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingElementProxyTypeEnum.NOTDEFINED:
				PredefinedType = IfcBuildingElementProxyTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcBuildingElementProxyTypeEnum PredefinedType
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
			SetValue(delegate(IfcBuildingElementProxyTypeEnum v)
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

	internal IfcBuildingElementProxyType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcBuildingElementProxyTypeEnum)Enum.Parse(typeof(IfcBuildingElementProxyTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBuildingElementProxyType other)
	{
		return this == other;
	}
}
