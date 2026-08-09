using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcOutlet", 1219)]
public class IfcOutlet : IfcFlowTerminal, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcOutlet>, IIfcOutlet, IIfcFlowTerminal, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcOutletTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcOutletTypeEnum? PredefinedType
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
			SetValue(delegate(IfcOutletTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcOutlet), 9)]
	Xbim.Ifc4.Interfaces.IfcOutletTypeEnum? IIfcOutlet.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcOutletTypeEnum.AUDIOVISUALOUTLET => Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.AUDIOVISUALOUTLET, 
				IfcOutletTypeEnum.COMMUNICATIONSOUTLET => Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.COMMUNICATIONSOUTLET, 
				IfcOutletTypeEnum.DATAOUTLET => Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.DATAOUTLET, 
				IfcOutletTypeEnum.POWEROUTLET => Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.POWEROUTLET, 
				IfcOutletTypeEnum.TELEPHONEOUTLET => Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.TELEPHONEOUTLET, 
				IfcOutletTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.USERDEFINED, 
				IfcOutletTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.AUDIOVISUALOUTLET:
				PredefinedType = IfcOutletTypeEnum.AUDIOVISUALOUTLET;
				break;
			case Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.COMMUNICATIONSOUTLET:
				PredefinedType = IfcOutletTypeEnum.COMMUNICATIONSOUTLET;
				break;
			case Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.POWEROUTLET:
				PredefinedType = IfcOutletTypeEnum.POWEROUTLET;
				break;
			case Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.DATAOUTLET:
				PredefinedType = IfcOutletTypeEnum.DATAOUTLET;
				break;
			case Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.TELEPHONEOUTLET:
				PredefinedType = IfcOutletTypeEnum.TELEPHONEOUTLET;
				break;
			case Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.USERDEFINED:
				PredefinedType = IfcOutletTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcOutletTypeEnum.NOTDEFINED:
				PredefinedType = IfcOutletTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcOutlet(IModel model, int label, bool activated)
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
			_predefinedType = (IfcOutletTypeEnum)Enum.Parse(typeof(IfcOutletTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcOutlet other)
	{
		return this == other;
	}
}
