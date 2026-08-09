using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcShadingDevice", 1265)]
public class IfcShadingDevice : IfcBuiltElement, IIfcShadingDevice, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcShadingDevice>
{
	private IfcShadingDeviceTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcShadingDevice), 9)]
	Xbim.Ifc4.Interfaces.IfcShadingDeviceTypeEnum? IIfcShadingDevice.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcShadingDeviceTypeEnum.AWNING => Xbim.Ifc4.Interfaces.IfcShadingDeviceTypeEnum.AWNING, 
				IfcShadingDeviceTypeEnum.JALOUSIE => Xbim.Ifc4.Interfaces.IfcShadingDeviceTypeEnum.JALOUSIE, 
				IfcShadingDeviceTypeEnum.SHUTTER => Xbim.Ifc4.Interfaces.IfcShadingDeviceTypeEnum.SHUTTER, 
				IfcShadingDeviceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcShadingDeviceTypeEnum.USERDEFINED, 
				IfcShadingDeviceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcShadingDeviceTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcShadingDeviceTypeEnum.JALOUSIE:
				PredefinedType = IfcShadingDeviceTypeEnum.JALOUSIE;
				break;
			case Xbim.Ifc4.Interfaces.IfcShadingDeviceTypeEnum.SHUTTER:
				PredefinedType = IfcShadingDeviceTypeEnum.SHUTTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcShadingDeviceTypeEnum.AWNING:
				PredefinedType = IfcShadingDeviceTypeEnum.AWNING;
				break;
			case Xbim.Ifc4.Interfaces.IfcShadingDeviceTypeEnum.USERDEFINED:
				PredefinedType = IfcShadingDeviceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcShadingDeviceTypeEnum.NOTDEFINED:
				PredefinedType = IfcShadingDeviceTypeEnum.NOTDEFINED;
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
	public IfcShadingDeviceTypeEnum? PredefinedType
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
			SetValue(delegate(IfcShadingDeviceTypeEnum? v)
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

	internal IfcShadingDevice(IModel model, int label, bool activated)
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
			_predefinedType = (IfcShadingDeviceTypeEnum)Enum.Parse(typeof(IfcShadingDeviceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcShadingDevice other)
	{
		return this == other;
	}
}
