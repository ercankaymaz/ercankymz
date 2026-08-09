using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcActor", 250)]
public class IfcActor : IfcObject, IInstantiableEntity, IPersistEntity, IPersist, IIfcActor, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcActor>
{
	private IfcActorSelect _theActor;

	IIfcActorSelect IIfcActor.TheActor
	{
		get
		{
			return TheActor;
		}
		set
		{
			TheActor = value as IfcActorSelect;
		}
	}

	IEnumerable<IIfcRelAssignsToActor> IIfcActor.IsActingUpon => IsActingUpon;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 17)]
	public IfcActorSelect TheActor
	{
		get
		{
			if (_activated)
			{
				return _theActor;
			}
			Activate();
			return _theActor;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcActorSelect v)
			{
				_theActor = v;
			}, _theActor, value, "TheActor", 6);
		}
	}

	[InverseProperty("RelatingActor")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 18)]
	public IEnumerable<IfcRelAssignsToActor> IsActingUpon => base.Model.Instances.Where((IfcRelAssignsToActor e) => Equals(e.RelatingActor), "RelatingActor", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (TheActor != null)
			{
				yield return TheActor;
			}
		}
	}

	internal IfcActor(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_theActor = (IfcActorSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcActor other)
	{
		return this == other;
	}
}
