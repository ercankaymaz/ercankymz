using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcGeographicElementType", 1186)]
public class IfcGeographicElementType : IfcElementType, IIfcGeographicElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcGeographicElementType>
{
	private IfcGeographicElementTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcGeographicElementType), 10)]
	Xbim.Ifc4.Interfaces.IfcGeographicElementTypeEnum IIfcGeographicElementType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcGeographicElementTypeEnum.SOIL_BORING_POINT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcGeographicElementTypeEnum>(), 
				IfcGeographicElementTypeEnum.TERRAIN => Xbim.Ifc4.Interfaces.IfcGeographicElementTypeEnum.TERRAIN, 
				IfcGeographicElementTypeEnum.VEGETATION => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcGeographicElementTypeEnum>(), 
				IfcGeographicElementTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcGeographicElementTypeEnum.USERDEFINED, 
				IfcGeographicElementTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcGeographicElementTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcGeographicElementTypeEnum.TERRAIN:
				PredefinedType = IfcGeographicElementTypeEnum.TERRAIN;
				break;
			case Xbim.Ifc4.Interfaces.IfcGeographicElementTypeEnum.USERDEFINED:
				PredefinedType = IfcGeographicElementTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcGeographicElementTypeEnum.NOTDEFINED:
				PredefinedType = IfcGeographicElementTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcGeographicElementTypeEnum PredefinedType
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
			SetValue(delegate(IfcGeographicElementTypeEnum v)
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

	internal IfcGeographicElementType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcGeographicElementTypeEnum)Enum.Parse(typeof(IfcGeographicElementTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcGeographicElementType other)
	{
		return this == other;
	}
}
