using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.PlumbingFireProtectionDomain;

[ExpressType("IfcInterceptor", 1193)]
public class IfcInterceptor : IfcFlowTreatmentDevice, IIfcInterceptor, IIfcFlowTreatmentDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcInterceptor>
{
	private IfcInterceptorTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcInterceptor), 9)]
	Xbim.Ifc4.Interfaces.IfcInterceptorTypeEnum? IIfcInterceptor.PredefinedType
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
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcInterceptorTypeEnum? PredefinedType
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
			SetValue(delegate(IfcInterceptorTypeEnum? v)
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

	internal IfcInterceptor(IModel model, int label, bool activated)
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
			_predefinedType = (IfcInterceptorTypeEnum)Enum.Parse(typeof(IfcInterceptorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcInterceptor other)
	{
		return this == other;
	}
}
