using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.ProfileResource;

namespace Xbim.Ifc2x3.GeometricConstraintResource;

[ExpressType("IfcConnectionPortGeometry", 713)]
public class IfcConnectionPortGeometry : IfcConnectionGeometry, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcConnectionPortGeometry>
{
	private IfcAxis2Placement _locationAtRelatingElement;

	private IfcAxis2Placement _locationAtRelatedElement;

	private IfcProfileDef _profileOfPort;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcAxis2Placement LocationAtRelatingElement
	{
		get
		{
			if (_activated)
			{
				return _locationAtRelatingElement;
			}
			Activate();
			return _locationAtRelatingElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis2Placement v)
			{
				_locationAtRelatingElement = v;
			}, _locationAtRelatingElement, value, "LocationAtRelatingElement", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcAxis2Placement LocationAtRelatedElement
	{
		get
		{
			if (_activated)
			{
				return _locationAtRelatedElement;
			}
			Activate();
			return _locationAtRelatedElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis2Placement v)
			{
				_locationAtRelatedElement = v;
			}, _locationAtRelatedElement, value, "LocationAtRelatedElement", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcProfileDef ProfileOfPort
	{
		get
		{
			if (_activated)
			{
				return _profileOfPort;
			}
			Activate();
			return _profileOfPort;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProfileDef v)
			{
				_profileOfPort = v;
			}, _profileOfPort, value, "ProfileOfPort", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (LocationAtRelatingElement != null)
			{
				yield return LocationAtRelatingElement;
			}
			if (LocationAtRelatedElement != null)
			{
				yield return LocationAtRelatedElement;
			}
			if (ProfileOfPort != null)
			{
				yield return ProfileOfPort;
			}
		}
	}

	internal IfcConnectionPortGeometry(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_locationAtRelatingElement = (IfcAxis2Placement)value.EntityVal;
			break;
		case 1:
			_locationAtRelatedElement = (IfcAxis2Placement)value.EntityVal;
			break;
		case 2:
			_profileOfPort = (IfcProfileDef)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConnectionPortGeometry other)
	{
		return this == other;
	}
}
