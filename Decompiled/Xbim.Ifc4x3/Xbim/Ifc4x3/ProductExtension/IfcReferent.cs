using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcReferent", 1353)]
public class IfcReferent : IfcPositioningElement, IIfcReferent, IIfcPositioningElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcReferent>
{
	private IfcReferentTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcReferent), 8)]
	Xbim.Ifc4.Interfaces.IfcReferentTypeEnum? IIfcReferent.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcReferentTypeEnum.BOUNDARY => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcReferentTypeEnum>(), 
				IfcReferentTypeEnum.INTERSECTION => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcReferentTypeEnum>(), 
				IfcReferentTypeEnum.KILOPOINT => Xbim.Ifc4.Interfaces.IfcReferentTypeEnum.KILOPOINT, 
				IfcReferentTypeEnum.LANDMARK => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcReferentTypeEnum>(), 
				IfcReferentTypeEnum.MILEPOINT => Xbim.Ifc4.Interfaces.IfcReferentTypeEnum.MILEPOINT, 
				IfcReferentTypeEnum.POSITION => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcReferentTypeEnum>(), 
				IfcReferentTypeEnum.REFERENCEMARKER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcReferentTypeEnum>(), 
				IfcReferentTypeEnum.STATION => Xbim.Ifc4.Interfaces.IfcReferentTypeEnum.STATION, 
				IfcReferentTypeEnum.SUPERELEVATIONEVENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcReferentTypeEnum>(), 
				IfcReferentTypeEnum.WIDTHEVENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcReferentTypeEnum>(), 
				IfcReferentTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcReferentTypeEnum.USERDEFINED, 
				IfcReferentTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcReferentTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcReferentTypeEnum.KILOPOINT:
				PredefinedType = IfcReferentTypeEnum.KILOPOINT;
				break;
			case Xbim.Ifc4.Interfaces.IfcReferentTypeEnum.MILEPOINT:
				PredefinedType = IfcReferentTypeEnum.MILEPOINT;
				break;
			case Xbim.Ifc4.Interfaces.IfcReferentTypeEnum.STATION:
				PredefinedType = IfcReferentTypeEnum.STATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcReferentTypeEnum.USERDEFINED:
				PredefinedType = IfcReferentTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcReferentTypeEnum.NOTDEFINED:
				PredefinedType = IfcReferentTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReferent), 9)]
	IfcLengthMeasure? IIfcReferent.RestartDistance
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 24)]
	public IfcReferentTypeEnum? PredefinedType
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
			SetValue(delegate(IfcReferentTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 8);
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

	internal IfcReferent(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_predefinedType = (IfcReferentTypeEnum)Enum.Parse(typeof(IfcReferentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcReferent other)
	{
		return this == other;
	}
}
