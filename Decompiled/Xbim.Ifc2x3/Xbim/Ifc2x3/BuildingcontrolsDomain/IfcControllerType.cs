using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.BuildingcontrolsDomain;

[ExpressType("IfcControllerType", 484)]
public class IfcControllerType : IfcDistributionControlElementType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcControllerType>, IIfcControllerType, IIfcDistributionControlElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	private IfcControllerTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
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

	[CrossSchemaAttribute(typeof(IIfcControllerType), 10)]
	Xbim.Ifc4.Interfaces.IfcControllerTypeEnum IIfcControllerType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcControllerTypeEnum.FLOATING:
				return Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.FLOATING;
			case IfcControllerTypeEnum.PROPORTIONAL:
				return Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.PROPORTIONAL;
			case IfcControllerTypeEnum.PROPORTIONALINTEGRAL:
				return Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.USERDEFINED;
			case IfcControllerTypeEnum.PROPORTIONALINTEGRALDERIVATIVE:
				return Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.USERDEFINED;
			case IfcControllerTypeEnum.TIMEDTWOPOSITION:
				return Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.USERDEFINED;
			case IfcControllerTypeEnum.TWOPOSITION:
				return Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.TWOPOSITION;
			case IfcControllerTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcControllerTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.USERDEFINED;
			}
			case IfcControllerTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.FLOATING:
				PredefinedType = IfcControllerTypeEnum.FLOATING;
				break;
			case Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.PROGRAMMABLE:
				base.ElementType = value.ToString();
				PredefinedType = IfcControllerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.PROPORTIONAL:
				PredefinedType = IfcControllerTypeEnum.PROPORTIONAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcControllerTypeEnum.MULTIPOSITION:
				base.ElementType = value.ToString();
				PredefinedType = IfcControllerTypeEnum.USERDEFINED;
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

	IfcLabel? IIfcElementType.ElementType
	{
		get
		{
			return PredefinedType switch
			{
				IfcControllerTypeEnum.PROPORTIONALINTEGRAL => new IfcLabel("PROPORTIONALINTEGRAL"), 
				IfcControllerTypeEnum.PROPORTIONALINTEGRALDERIVATIVE => new IfcLabel("PROPORTIONALINTEGRALDERIVATIVE"), 
				IfcControllerTypeEnum.TIMEDTWOPOSITION => new IfcLabel("TIMEDTWOPOSITION"), 
				_ => (!base.ElementType.HasValue) ? ((IfcLabel)null) : new IfcLabel(base.ElementType.Value), 
			};
		}
		set
		{
			base.ElementType = (value.HasValue ? value.Value.ToString() : null);
			if (value.HasValue && Enum.TryParse<IfcControllerTypeEnum>(value.Value.ToString(), ignoreCase: true, out var result))
			{
				PredefinedType = result;
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
