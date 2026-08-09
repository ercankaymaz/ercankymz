using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.BuildingcontrolsDomain;

[ExpressType("IfcAlarmType", 275)]
public class IfcAlarmType : IfcDistributionControlElementType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcAlarmType>, IIfcAlarmType, IIfcDistributionControlElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	private IfcAlarmTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcAlarmTypeEnum PredefinedType
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
			SetValue(delegate(IfcAlarmTypeEnum v)
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAlarmType), 10)]
	Xbim.Ifc4.Interfaces.IfcAlarmTypeEnum IIfcAlarmType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcAlarmTypeEnum.BELL => Xbim.Ifc4.Interfaces.IfcAlarmTypeEnum.BELL, 
				IfcAlarmTypeEnum.BREAKGLASSBUTTON => Xbim.Ifc4.Interfaces.IfcAlarmTypeEnum.BREAKGLASSBUTTON, 
				IfcAlarmTypeEnum.LIGHT => Xbim.Ifc4.Interfaces.IfcAlarmTypeEnum.LIGHT, 
				IfcAlarmTypeEnum.MANUALPULLBOX => Xbim.Ifc4.Interfaces.IfcAlarmTypeEnum.MANUALPULLBOX, 
				IfcAlarmTypeEnum.SIREN => Xbim.Ifc4.Interfaces.IfcAlarmTypeEnum.SIREN, 
				IfcAlarmTypeEnum.WHISTLE => Xbim.Ifc4.Interfaces.IfcAlarmTypeEnum.WHISTLE, 
				IfcAlarmTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcAlarmTypeEnum.USERDEFINED, 
				IfcAlarmTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcAlarmTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcAlarmTypeEnum.BELL:
				PredefinedType = IfcAlarmTypeEnum.BELL;
				break;
			case Xbim.Ifc4.Interfaces.IfcAlarmTypeEnum.BREAKGLASSBUTTON:
				PredefinedType = IfcAlarmTypeEnum.BREAKGLASSBUTTON;
				break;
			case Xbim.Ifc4.Interfaces.IfcAlarmTypeEnum.LIGHT:
				PredefinedType = IfcAlarmTypeEnum.LIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcAlarmTypeEnum.MANUALPULLBOX:
				PredefinedType = IfcAlarmTypeEnum.MANUALPULLBOX;
				break;
			case Xbim.Ifc4.Interfaces.IfcAlarmTypeEnum.SIREN:
				PredefinedType = IfcAlarmTypeEnum.SIREN;
				break;
			case Xbim.Ifc4.Interfaces.IfcAlarmTypeEnum.WHISTLE:
				PredefinedType = IfcAlarmTypeEnum.WHISTLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcAlarmTypeEnum.USERDEFINED:
				PredefinedType = IfcAlarmTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcAlarmTypeEnum.NOTDEFINED:
				PredefinedType = IfcAlarmTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcAlarmType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcAlarmTypeEnum)Enum.Parse(typeof(IfcAlarmTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAlarmType other)
	{
		return this == other;
	}
}
