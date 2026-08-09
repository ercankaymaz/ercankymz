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

[ExpressType("IfcBeamType", 632)]
public class IfcBeamType : IfcBuiltElementType, IIfcBeamType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcBeamType>
{
	private IfcBeamTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcBeamType), 10)]
	Xbim.Ifc4.Interfaces.IfcBeamTypeEnum IIfcBeamType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcBeamTypeEnum.BEAM => Xbim.Ifc4.Interfaces.IfcBeamTypeEnum.BEAM, 
				IfcBeamTypeEnum.CORNICE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcBeamTypeEnum>(), 
				IfcBeamTypeEnum.DIAPHRAGM => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcBeamTypeEnum>(), 
				IfcBeamTypeEnum.EDGEBEAM => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcBeamTypeEnum>(), 
				IfcBeamTypeEnum.GIRDER_SEGMENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcBeamTypeEnum>(), 
				IfcBeamTypeEnum.HATSTONE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcBeamTypeEnum>(), 
				IfcBeamTypeEnum.HOLLOWCORE => Xbim.Ifc4.Interfaces.IfcBeamTypeEnum.HOLLOWCORE, 
				IfcBeamTypeEnum.JOIST => Xbim.Ifc4.Interfaces.IfcBeamTypeEnum.JOIST, 
				IfcBeamTypeEnum.LINTEL => Xbim.Ifc4.Interfaces.IfcBeamTypeEnum.LINTEL, 
				IfcBeamTypeEnum.PIERCAP => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcBeamTypeEnum>(), 
				IfcBeamTypeEnum.SPANDREL => Xbim.Ifc4.Interfaces.IfcBeamTypeEnum.SPANDREL, 
				IfcBeamTypeEnum.T_BEAM => Xbim.Ifc4.Interfaces.IfcBeamTypeEnum.T_BEAM, 
				IfcBeamTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcBeamTypeEnum.USERDEFINED, 
				IfcBeamTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcBeamTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcBeamTypeEnum.BEAM:
				PredefinedType = IfcBeamTypeEnum.BEAM;
				break;
			case Xbim.Ifc4.Interfaces.IfcBeamTypeEnum.JOIST:
				PredefinedType = IfcBeamTypeEnum.JOIST;
				break;
			case Xbim.Ifc4.Interfaces.IfcBeamTypeEnum.HOLLOWCORE:
				PredefinedType = IfcBeamTypeEnum.HOLLOWCORE;
				break;
			case Xbim.Ifc4.Interfaces.IfcBeamTypeEnum.LINTEL:
				PredefinedType = IfcBeamTypeEnum.LINTEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcBeamTypeEnum.SPANDREL:
				PredefinedType = IfcBeamTypeEnum.SPANDREL;
				break;
			case Xbim.Ifc4.Interfaces.IfcBeamTypeEnum.T_BEAM:
				PredefinedType = IfcBeamTypeEnum.T_BEAM;
				break;
			case Xbim.Ifc4.Interfaces.IfcBeamTypeEnum.USERDEFINED:
				PredefinedType = IfcBeamTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcBeamTypeEnum.NOTDEFINED:
				PredefinedType = IfcBeamTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcBeamTypeEnum PredefinedType
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
			SetValue(delegate(IfcBeamTypeEnum v)
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

	internal IfcBeamType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcBeamTypeEnum)Enum.Parse(typeof(IfcBeamTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBeamType other)
	{
		return this == other;
	}
}
