using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.PlumbingFireProtectionDomain;

[ExpressType("IfcInterceptorType", 1194)]
public class IfcInterceptorType : IfcFlowTreatmentDeviceType, IIfcInterceptorType, IIfcFlowTreatmentDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcInterceptorType>
{
	private IfcInterceptorTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcInterceptorType), 10)]
	Xbim.Ifc4.Interfaces.IfcInterceptorTypeEnum IIfcInterceptorType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcInterceptorTypeEnum.CYCLONIC => Xbim.Ifc4.Interfaces.IfcInterceptorTypeEnum.CYCLONIC, 
				IfcInterceptorTypeEnum.GREASE => Xbim.Ifc4.Interfaces.IfcInterceptorTypeEnum.GREASE, 
				IfcInterceptorTypeEnum.OIL => Xbim.Ifc4.Interfaces.IfcInterceptorTypeEnum.OIL, 
				IfcInterceptorTypeEnum.PETROL => Xbim.Ifc4.Interfaces.IfcInterceptorTypeEnum.PETROL, 
				IfcInterceptorTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcInterceptorTypeEnum.USERDEFINED, 
				IfcInterceptorTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcInterceptorTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcInterceptorTypeEnum.CYCLONIC:
				PredefinedType = IfcInterceptorTypeEnum.CYCLONIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcInterceptorTypeEnum.GREASE:
				PredefinedType = IfcInterceptorTypeEnum.GREASE;
				break;
			case Xbim.Ifc4.Interfaces.IfcInterceptorTypeEnum.OIL:
				PredefinedType = IfcInterceptorTypeEnum.OIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcInterceptorTypeEnum.PETROL:
				PredefinedType = IfcInterceptorTypeEnum.PETROL;
				break;
			case Xbim.Ifc4.Interfaces.IfcInterceptorTypeEnum.USERDEFINED:
				PredefinedType = IfcInterceptorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcInterceptorTypeEnum.NOTDEFINED:
				PredefinedType = IfcInterceptorTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcInterceptorTypeEnum PredefinedType
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
			SetValue(delegate(IfcInterceptorTypeEnum v)
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

	internal IfcInterceptorType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcInterceptorTypeEnum)Enum.Parse(typeof(IfcInterceptorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcInterceptorType other)
	{
		return this == other;
	}
}
