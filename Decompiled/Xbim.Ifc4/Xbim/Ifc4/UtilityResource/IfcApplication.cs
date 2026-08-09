using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.UtilityResource;

[ExpressType("IfcApplication", 627)]
public class IfcApplication : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcApplication, IContainsEntityReferences, IEquatable<IfcApplication>
{
	private IfcOrganization _applicationDeveloper;

	private IfcLabel _version;

	private IfcLabel _applicationFullName;

	private IfcIdentifier _applicationIdentifier;

	IIfcOrganization IIfcApplication.ApplicationDeveloper
	{
		get
		{
			return ApplicationDeveloper;
		}
		set
		{
			ApplicationDeveloper = value as IfcOrganization;
		}
	}

	IfcLabel IIfcApplication.Version
	{
		get
		{
			return Version;
		}
		set
		{
			Version = value;
		}
	}

	IfcLabel IIfcApplication.ApplicationFullName
	{
		get
		{
			return ApplicationFullName;
		}
		set
		{
			ApplicationFullName = value;
		}
	}

	IfcIdentifier IIfcApplication.ApplicationIdentifier
	{
		get
		{
			return ApplicationIdentifier;
		}
		set
		{
			ApplicationIdentifier = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcOrganization ApplicationDeveloper
	{
		get
		{
			if (_activated)
			{
				return _applicationDeveloper;
			}
			Activate();
			return _applicationDeveloper;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcOrganization v)
			{
				_applicationDeveloper = v;
			}, _applicationDeveloper, value, "ApplicationDeveloper", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcLabel Version
	{
		get
		{
			if (_activated)
			{
				return _version;
			}
			Activate();
			return _version;
		}
		set
		{
			SetValue(delegate(IfcLabel v)
			{
				_version = v;
			}, _version, value, "Version", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLabel ApplicationFullName
	{
		get
		{
			if (_activated)
			{
				return _applicationFullName;
			}
			Activate();
			return _applicationFullName;
		}
		set
		{
			SetValue(delegate(IfcLabel v)
			{
				_applicationFullName = v;
			}, _applicationFullName, value, "ApplicationFullName", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcIdentifier ApplicationIdentifier
	{
		get
		{
			if (_activated)
			{
				return _applicationIdentifier;
			}
			Activate();
			return _applicationIdentifier;
		}
		set
		{
			SetValue(delegate(IfcIdentifier v)
			{
				_applicationIdentifier = v;
			}, _applicationIdentifier, value, "ApplicationIdentifier", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (ApplicationDeveloper != null)
			{
				yield return ApplicationDeveloper;
			}
		}
	}

	internal IfcApplication(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_applicationDeveloper = (IfcOrganization)value.EntityVal;
			break;
		case 1:
			_version = value.StringVal;
			break;
		case 2:
			_applicationFullName = value.StringVal;
			break;
		case 3:
			_applicationIdentifier = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcApplication other)
	{
		return this == other;
	}
}
