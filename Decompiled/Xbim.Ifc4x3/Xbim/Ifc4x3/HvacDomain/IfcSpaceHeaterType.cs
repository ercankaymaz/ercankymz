using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcSpaceHeaterType", 59)]
public class IfcSpaceHeaterType : IfcFlowTerminalType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSpaceHeaterType>, IIfcSpaceHeaterType, IIfcFlowTerminalType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcSpaceHeaterTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcSpaceHeaterTypeEnum PredefinedType
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
			SetValue(delegate(IfcSpaceHeaterTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcSpaceHeaterType), 10)]
	Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum IIfcSpaceHeaterType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcSpaceHeaterTypeEnum.CONVECTOR => Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.CONVECTOR, 
				IfcSpaceHeaterTypeEnum.RADIATOR => Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.RADIATOR, 
				IfcSpaceHeaterTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.USERDEFINED, 
				IfcSpaceHeaterTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.CONVECTOR:
				PredefinedType = IfcSpaceHeaterTypeEnum.CONVECTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.RADIATOR:
				PredefinedType = IfcSpaceHeaterTypeEnum.RADIATOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.USERDEFINED:
				PredefinedType = IfcSpaceHeaterTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.NOTDEFINED:
				PredefinedType = IfcSpaceHeaterTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcSpaceHeaterType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSpaceHeaterTypeEnum)Enum.Parse(typeof(IfcSpaceHeaterTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSpaceHeaterType other)
	{
		return this == other;
	}
}
