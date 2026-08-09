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

[ExpressType("IfcRailingType", 415)]
public class IfcRailingType : IfcBuiltElementType, IIfcRailingType, IIfcBuildingElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRailingType>
{
	private IfcRailingTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcRailingType), 10)]
	Xbim.Ifc4.Interfaces.IfcRailingTypeEnum IIfcRailingType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcRailingTypeEnum.BALUSTRADE => Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.BALUSTRADE, 
				IfcRailingTypeEnum.FENCE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcRailingTypeEnum>(), 
				IfcRailingTypeEnum.GUARDRAIL => Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.GUARDRAIL, 
				IfcRailingTypeEnum.HANDRAIL => Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.HANDRAIL, 
				IfcRailingTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.USERDEFINED, 
				IfcRailingTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.HANDRAIL:
				PredefinedType = IfcRailingTypeEnum.HANDRAIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.GUARDRAIL:
				PredefinedType = IfcRailingTypeEnum.GUARDRAIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.BALUSTRADE:
				PredefinedType = IfcRailingTypeEnum.BALUSTRADE;
				break;
			case Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.USERDEFINED:
				PredefinedType = IfcRailingTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.NOTDEFINED:
				PredefinedType = IfcRailingTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcRailingTypeEnum PredefinedType
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
			SetValue(delegate(IfcRailingTypeEnum v)
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

	internal IfcRailingType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcRailingTypeEnum)Enum.Parse(typeof(IfcRailingTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRailingType other)
	{
		return this == other;
	}
}
