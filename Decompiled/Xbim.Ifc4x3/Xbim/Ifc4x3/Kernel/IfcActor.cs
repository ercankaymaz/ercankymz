using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.ActorResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcActor", 250)]
public class IfcActor : IfcObject, IIfcActor, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcActor>
{
	private IfcActorSelect _theActor;

	[CrossSchemaAttribute(typeof(IIfcActor), 6)]
	IIfcActorSelect IIfcActor.TheActor
	{
		get
		{
			if (TheActor == null)
			{
				return null;
			}
			IfcOrganization ifcOrganization = TheActor as IfcOrganization;
			if (ifcOrganization != null)
			{
				return ifcOrganization;
			}
			IfcPerson ifcPerson = TheActor as IfcPerson;
			if (ifcPerson != null)
			{
				return ifcPerson;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = TheActor as IfcPersonAndOrganization;
			if (ifcPersonAndOrganization != null)
			{
				return ifcPersonAndOrganization;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				TheActor = null;
				return;
			}
			IfcOrganization ifcOrganization = value as IfcOrganization;
			if (ifcOrganization != null)
			{
				TheActor = ifcOrganization;
				return;
			}
			IfcPerson ifcPerson = value as IfcPerson;
			if (ifcPerson != null)
			{
				TheActor = ifcPerson;
				return;
			}
			IfcPersonAndOrganization ifcPersonAndOrganization = value as IfcPersonAndOrganization;
			if (ifcPersonAndOrganization != null)
			{
				TheActor = ifcPersonAndOrganization;
			}
		}
	}

	IEnumerable<IIfcRelAssignsToActor> IIfcActor.IsActingUpon => base.Model.Instances.Where((IIfcRelAssignsToActor e) => e.RelatingActor as IfcActor == this, "RelatingActor", this);

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
