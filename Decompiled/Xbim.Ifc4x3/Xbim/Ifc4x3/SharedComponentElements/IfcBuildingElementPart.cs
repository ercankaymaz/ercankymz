using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4x3.SharedComponentElements;

[ExpressType("IfcBuildingElementPart", 220)]
public class IfcBuildingElementPart : IfcElementComponent, IIfcBuildingElementPart, IIfcElementComponent, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcBuildingElementPart>
{
	private IfcBuildingElementPartTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcBuildingElementPart), 9)]
	Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum? IIfcBuildingElementPart.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcBuildingElementPartTypeEnum.APRON => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum>(), 
				IfcBuildingElementPartTypeEnum.ARMOURUNIT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum>(), 
				IfcBuildingElementPartTypeEnum.INSULATION => Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum.INSULATION, 
				IfcBuildingElementPartTypeEnum.PRECASTPANEL => Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum.PRECASTPANEL, 
				IfcBuildingElementPartTypeEnum.SAFETYCAGE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum>(), 
				IfcBuildingElementPartTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum.USERDEFINED, 
				IfcBuildingElementPartTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum.INSULATION:
				PredefinedType = IfcBuildingElementPartTypeEnum.INSULATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum.PRECASTPANEL:
				PredefinedType = IfcBuildingElementPartTypeEnum.PRECASTPANEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum.USERDEFINED:
				PredefinedType = IfcBuildingElementPartTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcBuildingElementPartTypeEnum.NOTDEFINED:
				PredefinedType = IfcBuildingElementPartTypeEnum.NOTDEFINED;
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
	public IfcBuildingElementPartTypeEnum? PredefinedType
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
			SetValue(delegate(IfcBuildingElementPartTypeEnum? v)
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

	internal IfcBuildingElementPart(IModel model, int label, bool activated)
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
			_predefinedType = (IfcBuildingElementPartTypeEnum)Enum.Parse(typeof(IfcBuildingElementPartTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBuildingElementPart other)
	{
		return this == other;
	}
}
