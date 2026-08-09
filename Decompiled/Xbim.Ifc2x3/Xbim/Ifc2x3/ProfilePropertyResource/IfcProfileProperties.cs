using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProfileResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProfilePropertyResource;

[ExpressType("IfcProfileProperties", 649)]
public abstract class IfcProfileProperties : PersistEntity, IIfcProfileProperties, IIfcExtendedProperties, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IEquatable<IfcProfileProperties>
{
	private Xbim.Ifc4.MeasureResource.IfcText? _description;

	private IItemSet<IIfcProperty> _properties;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _profileName;

	private IfcProfileDef _profileDefinition;

	[CrossSchemaAttribute(typeof(IIfcProfileProperties), 4)]
	IIfcProfileDef IIfcProfileProperties.ProfileDefinition
	{
		get
		{
			return ProfileDefinition;
		}
		set
		{
			ProfileDefinition = value as IfcProfileDef;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcProfileProperties), 1)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcExtendedProperties.Name
	{
		get
		{
			if (!ProfileName.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(ProfileName.Value);
		}
		set
		{
			ProfileName = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcProfileProperties), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcExtendedProperties.Description
	{
		get
		{
			return _description;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", -2);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcProfileProperties), 3)]
	IEnumerable<IIfcProperty> IIfcExtendedProperties.Properties => _properties ?? (_properties = new ItemSet<IIfcProperty>(this, 0, -3));

	IEnumerable<IIfcExternalReferenceRelationship> IIfcPropertyAbstraction.HasExternalReferences => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? ProfileName
	{
		get
		{
			if (_activated)
			{
				return _profileName;
			}
			Activate();
			return _profileName;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_profileName = v;
			}, _profileName, value, "ProfileName", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcProfileDef ProfileDefinition
	{
		get
		{
			if (_activated)
			{
				return _profileDefinition;
			}
			Activate();
			return _profileDefinition;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProfileDef v)
			{
				_profileDefinition = v;
			}, _profileDefinition, value, "ProfileDefinition", 2);
		}
	}

	internal IfcProfileProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_profileName = value.StringVal;
			break;
		case 1:
			_profileDefinition = (IfcProfileDef)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProfileProperties other)
	{
		return this == other;
	}
}
