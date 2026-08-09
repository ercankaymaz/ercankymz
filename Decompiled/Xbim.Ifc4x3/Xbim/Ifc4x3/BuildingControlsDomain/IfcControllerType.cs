using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.BuildingControlsDomain;

[ExpressType("IfcControllerType", 484)]
public class IfcControllerType : IfcDistributionControlElementType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcControllerType>, IIfcControllerType, IIfcDistributionControlElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcControllerTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcControllerTypeEnum PredefinedType
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
			SetValue(delegate(IfcControllerTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcControllerType), 10)]
	Xbim.Ifc4.Interfaces.IfcControllerTypeEnum IIfcControllerType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcControllerTypeEnum.FLOATING => Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.FLOATING, 
				IfcControllerTypeEnum.MULTIPOSITION => Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.MULTIPOSITION, 
				IfcControllerTypeEnum.PROGRAMMABLE => Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.PROGRAMMABLE, 
				IfcControllerTypeEnum.PROPORTIONAL => Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.PROPORTIONAL, 
				IfcControllerTypeEnum.TWOPOSITION => Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.TWOPOSITION, 
				IfcControllerTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.USERDEFINED, 
				IfcControllerTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.FLOATING:
				PredefinedType = IfcControllerTypeEnum.FLOATING;
				break;
			case Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.PROGRAMMABLE:
				PredefinedType = IfcControllerTypeEnum.PROGRAMMABLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.PROPORTIONAL:
				PredefinedType = IfcControllerTypeEnum.PROPORTIONAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.MULTIPOSITION:
				PredefinedType = IfcControllerTypeEnum.MULTIPOSITION;
				break;
			case Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.TWOPOSITION:
				PredefinedType = IfcControllerTypeEnum.TWOPOSITION;
				break;
			case Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.USERDEFINED:
				PredefinedType = IfcControllerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.NOTDEFINED:
				PredefinedType = IfcControllerTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcControllerType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcControllerTypeEnum)Enum.Parse(typeof(IfcControllerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcControllerType other)
	{
		return this == other;
	}
}
