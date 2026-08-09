using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProfilePropertyResource;

[ExpressType("IfcSectionReinforcementProperties", 508)]
public class IfcSectionReinforcementProperties : PersistEntity, IIfcSectionReinforcementProperties, IIfcPreDefinedProperties, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcSectionReinforcementProperties>
{
	private Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum? _role;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure _longitudinalStartPosition;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure _longitudinalEndPosition;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? _transversePosition;

	private IfcReinforcingBarRoleEnum _reinforcementRole;

	private IfcSectionProperties _sectionDefinition;

	private readonly ItemSet<IfcReinforcementBarProperties> _crossSectionReinforcementDefinitions;

	[CrossSchemaAttribute(typeof(IIfcSectionReinforcementProperties), 1)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure IIfcSectionReinforcementProperties.LongitudinalStartPosition
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(LongitudinalStartPosition);
		}
		set
		{
			LongitudinalStartPosition = new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSectionReinforcementProperties), 2)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure IIfcSectionReinforcementProperties.LongitudinalEndPosition
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(LongitudinalEndPosition);
		}
		set
		{
			LongitudinalEndPosition = new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSectionReinforcementProperties), 3)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcSectionReinforcementProperties.TransversePosition
	{
		get
		{
			if (!TransversePosition.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(TransversePosition.Value);
		}
		set
		{
			TransversePosition = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSectionReinforcementProperties), 4)]
	Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum IIfcSectionReinforcementProperties.ReinforcementRole
	{
		get
		{
			if (_role.HasValue)
			{
				return _role.Value;
			}
			return ReinforcementRole switch
			{
				IfcReinforcingBarRoleEnum.MAIN => Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.MAIN, 
				IfcReinforcingBarRoleEnum.SHEAR => Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.SHEAR, 
				IfcReinforcingBarRoleEnum.LIGATURE => Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.LIGATURE, 
				IfcReinforcingBarRoleEnum.STUD => Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.STUD, 
				IfcReinforcingBarRoleEnum.PUNCHING => Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.PUNCHING, 
				IfcReinforcingBarRoleEnum.EDGE => Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.EDGE, 
				IfcReinforcingBarRoleEnum.RING => Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.RING, 
				IfcReinforcingBarRoleEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.USERDEFINED, 
				IfcReinforcingBarRoleEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			if (value != Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.ANCHORING)
			{
				SetValue(delegate(Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum? v)
				{
					_role = v;
				}, _role, null, "ReinforcementRole", -4);
			}
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.MAIN:
				ReinforcementRole = IfcReinforcingBarRoleEnum.MAIN;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.SHEAR:
				ReinforcementRole = IfcReinforcingBarRoleEnum.SHEAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.LIGATURE:
				ReinforcementRole = IfcReinforcingBarRoleEnum.LIGATURE;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.STUD:
				ReinforcementRole = IfcReinforcingBarRoleEnum.STUD;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.PUNCHING:
				ReinforcementRole = IfcReinforcingBarRoleEnum.PUNCHING;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.EDGE:
				ReinforcementRole = IfcReinforcingBarRoleEnum.EDGE;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.RING:
				ReinforcementRole = IfcReinforcingBarRoleEnum.RING;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.ANCHORING:
				ReinforcementRole = IfcReinforcingBarRoleEnum.USERDEFINED;
				SetValue(delegate(Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum? v)
				{
					_role = v;
				}, _role, value, "ReinforcementRole", -4);
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.USERDEFINED:
				ReinforcementRole = IfcReinforcingBarRoleEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarRoleEnum.NOTDEFINED:
				ReinforcementRole = IfcReinforcingBarRoleEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSectionReinforcementProperties), 5)]
	IIfcSectionProperties IIfcSectionReinforcementProperties.SectionDefinition
	{
		get
		{
			return SectionDefinition;
		}
		set
		{
			SectionDefinition = value as IfcSectionProperties;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSectionReinforcementProperties), 6)]
	IItemSet<IIfcReinforcementBarProperties> IIfcSectionReinforcementProperties.CrossSectionReinforcementDefinitions => new ProxyItemSet<IfcReinforcementBarProperties, IIfcReinforcementBarProperties>(CrossSectionReinforcementDefinitions);

	IEnumerable<IIfcExternalReferenceRelationship> IIfcPropertyAbstraction.HasExternalReferences => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure LongitudinalStartPosition
	{
		get
		{
			if (_activated)
			{
				return _longitudinalStartPosition;
			}
			Activate();
			return _longitudinalStartPosition;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure v)
			{
				_longitudinalStartPosition = v;
			}, _longitudinalStartPosition, value, "LongitudinalStartPosition", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure LongitudinalEndPosition
	{
		get
		{
			if (_activated)
			{
				return _longitudinalEndPosition;
			}
			Activate();
			return _longitudinalEndPosition;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure v)
			{
				_longitudinalEndPosition = v;
			}, _longitudinalEndPosition, value, "LongitudinalEndPosition", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? TransversePosition
	{
		get
		{
			if (_activated)
			{
				return _transversePosition;
			}
			Activate();
			return _transversePosition;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? v)
			{
				_transversePosition = v;
			}, _transversePosition, value, "TransversePosition", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 4)]
	public IfcReinforcingBarRoleEnum ReinforcementRole
	{
		get
		{
			if (_activated)
			{
				return _reinforcementRole;
			}
			Activate();
			return _reinforcementRole;
		}
		set
		{
			SetValue(delegate(IfcReinforcingBarRoleEnum v)
			{
				_reinforcementRole = v;
			}, _reinforcementRole, value, "ReinforcementRole", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcSectionProperties SectionDefinition
	{
		get
		{
			if (_activated)
			{
				return _sectionDefinition;
			}
			Activate();
			return _sectionDefinition;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSectionProperties v)
			{
				_sectionDefinition = v;
			}, _sectionDefinition, value, "SectionDefinition", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 6)]
	public IItemSet<IfcReinforcementBarProperties> CrossSectionReinforcementDefinitions
	{
		get
		{
			if (_activated)
			{
				return _crossSectionReinforcementDefinitions;
			}
			Activate();
			return _crossSectionReinforcementDefinitions;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (SectionDefinition != null)
			{
				yield return SectionDefinition;
			}
			foreach (IfcReinforcementBarProperties crossSectionReinforcementDefinition in CrossSectionReinforcementDefinitions)
			{
				yield return crossSectionReinforcementDefinition;
			}
		}
	}

	internal IfcSectionReinforcementProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_crossSectionReinforcementDefinitions = new ItemSet<IfcReinforcementBarProperties>(this, 0, 6);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_longitudinalStartPosition = value.RealVal;
			break;
		case 1:
			_longitudinalEndPosition = value.RealVal;
			break;
		case 2:
			_transversePosition = value.RealVal;
			break;
		case 3:
			_reinforcementRole = (IfcReinforcingBarRoleEnum)Enum.Parse(typeof(IfcReinforcingBarRoleEnum), value.EnumVal, ignoreCase: true);
			break;
		case 4:
			_sectionDefinition = (IfcSectionProperties)value.EntityVal;
			break;
		case 5:
			_crossSectionReinforcementDefinitions.InternalAdd((IfcReinforcementBarProperties)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSectionReinforcementProperties other)
	{
		return this == other;
	}
}
