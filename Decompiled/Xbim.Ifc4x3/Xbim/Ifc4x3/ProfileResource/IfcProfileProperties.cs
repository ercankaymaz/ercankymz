using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.PropertyResource;

namespace Xbim.Ifc4x3.ProfileResource;

[ExpressType("IfcProfileProperties", 649)]
public class IfcProfileProperties : IfcExtendedProperties, IIfcProfileProperties, IIfcExtendedProperties, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcProfileProperties>
{
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

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
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
			}, _profileDefinition, value, "ProfileDefinition", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcProperty property in base.Properties)
			{
				yield return property;
			}
			if (ProfileDefinition != null)
			{
				yield return ProfileDefinition;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (ProfileDefinition != null)
			{
				yield return ProfileDefinition;
			}
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
		case 1:
		case 2:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
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
