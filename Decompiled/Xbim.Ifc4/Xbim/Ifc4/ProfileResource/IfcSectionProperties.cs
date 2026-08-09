using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.ProfileResource;

[ExpressType("IfcSectionProperties", 184)]
public class IfcSectionProperties : IfcPreDefinedProperties, IInstantiableEntity, IPersistEntity, IPersist, IIfcSectionProperties, IIfcPreDefinedProperties, IIfcPropertyAbstraction, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcSectionProperties>
{
	private IfcSectionTypeEnum _sectionType;

	private IfcProfileDef _startProfile;

	private IfcProfileDef _endProfile;

	IfcSectionTypeEnum IIfcSectionProperties.SectionType
	{
		get
		{
			return SectionType;
		}
		set
		{
			SectionType = value;
		}
	}

	IIfcProfileDef IIfcSectionProperties.StartProfile
	{
		get
		{
			return StartProfile;
		}
		set
		{
			StartProfile = value as IfcProfileDef;
		}
	}

	IIfcProfileDef IIfcSectionProperties.EndProfile
	{
		get
		{
			return EndProfile;
		}
		set
		{
			EndProfile = value as IfcProfileDef;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 2)]
	public IfcSectionTypeEnum SectionType
	{
		get
		{
			if (_activated)
			{
				return _sectionType;
			}
			Activate();
			return _sectionType;
		}
		set
		{
			SetValue(delegate(IfcSectionTypeEnum v)
			{
				_sectionType = v;
			}, _sectionType, value, "SectionType", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcProfileDef StartProfile
	{
		get
		{
			if (_activated)
			{
				return _startProfile;
			}
			Activate();
			return _startProfile;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProfileDef v)
			{
				_startProfile = v;
			}, _startProfile, value, "StartProfile", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcProfileDef EndProfile
	{
		get
		{
			if (_activated)
			{
				return _endProfile;
			}
			Activate();
			return _endProfile;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProfileDef v)
			{
				_endProfile = v;
			}, _endProfile, value, "EndProfile", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (StartProfile != null)
			{
				yield return StartProfile;
			}
			if (EndProfile != null)
			{
				yield return EndProfile;
			}
		}
	}

	internal IfcSectionProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_sectionType = (IfcSectionTypeEnum)Enum.Parse(typeof(IfcSectionTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 1:
			_startProfile = (IfcProfileDef)value.EntityVal;
			break;
		case 2:
			_endProfile = (IfcProfileDef)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSectionProperties other)
	{
		return this == other;
	}
}
