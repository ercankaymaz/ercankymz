using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProfileResource;

[ExpressType("IfcCompositeProfileDef", 172)]
public class IfcCompositeProfileDef : IfcProfileDef, IIfcCompositeProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcCompositeProfileDef>
{
	private readonly ItemSet<IfcProfileDef> _profiles;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _label;

	[CrossSchemaAttribute(typeof(IIfcCompositeProfileDef), 3)]
	IItemSet<IIfcProfileDef> IIfcCompositeProfileDef.Profiles => new ProxyItemSet<IfcProfileDef, IIfcProfileDef>(Profiles);

	[CrossSchemaAttribute(typeof(IIfcCompositeProfileDef), 4)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcCompositeProfileDef.Label
	{
		get
		{
			if (!Label.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Label.Value);
		}
		set
		{
			Label = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 2 }, new int[] { -1 }, 5)]
	public IItemSet<IfcProfileDef> Profiles
	{
		get
		{
			if (_activated)
			{
				return _profiles;
			}
			Activate();
			return _profiles;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Label
	{
		get
		{
			if (_activated)
			{
				return _label;
			}
			Activate();
			return _label;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_label = v;
			}, _label, value, "Label", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcProfileDef profile in Profiles)
			{
				yield return profile;
			}
		}
	}

	internal IfcCompositeProfileDef(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_profiles = new ItemSet<IfcProfileDef>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_profiles.InternalAdd((IfcProfileDef)value.EntityVal);
			break;
		case 3:
			_label = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCompositeProfileDef other)
	{
		return this == other;
	}
}
