using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcFan", 1177)]
public class IfcFan : IfcFlowMovingDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFan>, IIfcFan, IIfcFlowMovingDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcFanTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcFanTypeEnum? PredefinedType
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
			SetValue(delegate(IfcFanTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcFan), 9)]
	Xbim.Ifc4.Interfaces.IfcFanTypeEnum? IIfcFan.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcFanTypeEnum.CENTRIFUGALAIRFOIL => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.CENTRIFUGALAIRFOIL, 
				IfcFanTypeEnum.CENTRIFUGALBACKWARDINCLINEDCURVED => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.CENTRIFUGALBACKWARDINCLINEDCURVED, 
				IfcFanTypeEnum.CENTRIFUGALFORWARDCURVED => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.CENTRIFUGALFORWARDCURVED, 
				IfcFanTypeEnum.CENTRIFUGALRADIAL => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.CENTRIFUGALRADIAL, 
				IfcFanTypeEnum.PROPELLORAXIAL => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.PROPELLORAXIAL, 
				IfcFanTypeEnum.TUBEAXIAL => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.TUBEAXIAL, 
				IfcFanTypeEnum.VANEAXIAL => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.VANEAXIAL, 
				IfcFanTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.USERDEFINED, 
				IfcFanTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcFanTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.CENTRIFUGALFORWARDCURVED:
				PredefinedType = IfcFanTypeEnum.CENTRIFUGALFORWARDCURVED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.CENTRIFUGALRADIAL:
				PredefinedType = IfcFanTypeEnum.CENTRIFUGALRADIAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.CENTRIFUGALBACKWARDINCLINEDCURVED:
				PredefinedType = IfcFanTypeEnum.CENTRIFUGALBACKWARDINCLINEDCURVED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.CENTRIFUGALAIRFOIL:
				PredefinedType = IfcFanTypeEnum.CENTRIFUGALAIRFOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.TUBEAXIAL:
				PredefinedType = IfcFanTypeEnum.TUBEAXIAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.VANEAXIAL:
				PredefinedType = IfcFanTypeEnum.VANEAXIAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.PROPELLORAXIAL:
				PredefinedType = IfcFanTypeEnum.PROPELLORAXIAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.USERDEFINED:
				PredefinedType = IfcFanTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFanTypeEnum.NOTDEFINED:
				PredefinedType = IfcFanTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcFan(IModel model, int label, bool activated)
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
			_predefinedType = (IfcFanTypeEnum)Enum.Parse(typeof(IfcFanTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFan other)
	{
		return this == other;
	}
}
