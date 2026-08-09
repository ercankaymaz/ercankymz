using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcJunctionBox", 1195)]
public class IfcJunctionBox : IfcFlowFitting, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcJunctionBox>, IIfcJunctionBox, IIfcFlowFitting, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcJunctionBoxTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcJunctionBoxTypeEnum? PredefinedType
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
			SetValue(delegate(IfcJunctionBoxTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcJunctionBox), 9)]
	Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum? IIfcJunctionBox.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcJunctionBoxTypeEnum.DATA => Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum.DATA, 
				IfcJunctionBoxTypeEnum.POWER => Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum.POWER, 
				IfcJunctionBoxTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum.USERDEFINED, 
				IfcJunctionBoxTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum.DATA:
				PredefinedType = IfcJunctionBoxTypeEnum.DATA;
				break;
			case Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum.POWER:
				PredefinedType = IfcJunctionBoxTypeEnum.POWER;
				break;
			case Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum.USERDEFINED:
				PredefinedType = IfcJunctionBoxTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcJunctionBoxTypeEnum.NOTDEFINED:
				PredefinedType = IfcJunctionBoxTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcJunctionBox(IModel model, int label, bool activated)
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
			_predefinedType = (IfcJunctionBoxTypeEnum)Enum.Parse(typeof(IfcJunctionBoxTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcJunctionBox other)
	{
		return this == other;
	}
}
