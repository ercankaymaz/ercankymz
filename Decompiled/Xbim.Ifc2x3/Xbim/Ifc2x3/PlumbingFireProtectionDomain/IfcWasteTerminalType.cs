using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.PlumbingFireProtectionDomain;

[ExpressType("IfcWasteTerminalType", 295)]
public class IfcWasteTerminalType : IfcFlowTerminalType, IIfcWasteTerminalType, IIfcFlowTerminalType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcWasteTerminalType>
{
	private IfcWasteTerminalTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcWasteTerminalType), 10)]
	Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum IIfcWasteTerminalType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcWasteTerminalTypeEnum.FLOORTRAP => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.FLOORTRAP, 
				IfcWasteTerminalTypeEnum.FLOORWASTE => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.FLOORWASTE, 
				IfcWasteTerminalTypeEnum.GULLYSUMP => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.GULLYSUMP, 
				IfcWasteTerminalTypeEnum.GULLYTRAP => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.GULLYTRAP, 
				IfcWasteTerminalTypeEnum.GREASEINTERCEPTOR => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.USERDEFINED, 
				IfcWasteTerminalTypeEnum.OILINTERCEPTOR => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.USERDEFINED, 
				IfcWasteTerminalTypeEnum.PETROLINTERCEPTOR => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.USERDEFINED, 
				IfcWasteTerminalTypeEnum.ROOFDRAIN => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.ROOFDRAIN, 
				IfcWasteTerminalTypeEnum.WASTEDISPOSALUNIT => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.WASTEDISPOSALUNIT, 
				IfcWasteTerminalTypeEnum.WASTETRAP => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.WASTETRAP, 
				IfcWasteTerminalTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.USERDEFINED, 
				IfcWasteTerminalTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.FLOORTRAP:
				PredefinedType = IfcWasteTerminalTypeEnum.FLOORTRAP;
				break;
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.FLOORWASTE:
				PredefinedType = IfcWasteTerminalTypeEnum.FLOORWASTE;
				break;
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.GULLYSUMP:
				PredefinedType = IfcWasteTerminalTypeEnum.GULLYSUMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.GULLYTRAP:
				PredefinedType = IfcWasteTerminalTypeEnum.GULLYTRAP;
				break;
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.ROOFDRAIN:
				PredefinedType = IfcWasteTerminalTypeEnum.ROOFDRAIN;
				break;
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.WASTEDISPOSALUNIT:
				PredefinedType = IfcWasteTerminalTypeEnum.WASTEDISPOSALUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.WASTETRAP:
				PredefinedType = IfcWasteTerminalTypeEnum.WASTETRAP;
				break;
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.USERDEFINED:
				PredefinedType = IfcWasteTerminalTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcWasteTerminalTypeEnum.NOTDEFINED:
				PredefinedType = IfcWasteTerminalTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcElementType.ElementType
	{
		get
		{
			IfcWasteTerminalTypeEnum predefinedType = PredefinedType;
			if (predefinedType - 4 <= IfcWasteTerminalTypeEnum.GULLYSUMP)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLabel(Enum.GetName(typeof(IfcWasteTerminalTypeEnum), PredefinedType));
			}
			Xbim.Ifc4.MeasureResource.IfcLabel value;
			if (!base.ElementType.HasValue)
			{
				value = null;
			}
			else
			{
				Xbim.Ifc2x3.MeasureResource.IfcLabel? elementType = base.ElementType;
				value = new Xbim.Ifc4.MeasureResource.IfcLabel(elementType.HasValue ? ((string)elementType.GetValueOrDefault()) : null);
			}
			return value;
		}
		set
		{
			base.ElementType = (value.HasValue ? value.Value.ToString() : null);
			if (value.HasValue && Enum.TryParse<IfcWasteTerminalTypeEnum>(value.Value.ToString(), ignoreCase: true, out var result))
			{
				PredefinedType = result;
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcWasteTerminalTypeEnum PredefinedType
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
			SetValue(delegate(IfcWasteTerminalTypeEnum v)
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

	internal IfcWasteTerminalType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcWasteTerminalTypeEnum)Enum.Parse(typeof(IfcWasteTerminalTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWasteTerminalType other)
	{
		return this == other;
	}
}
