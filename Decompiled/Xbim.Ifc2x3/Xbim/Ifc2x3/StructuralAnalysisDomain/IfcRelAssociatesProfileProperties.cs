using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.ProfilePropertyResource;
using Xbim.Ifc2x3.RepresentationResource;

namespace Xbim.Ifc2x3.StructuralAnalysisDomain;

[ExpressType("IfcRelAssociatesProfileProperties", 676)]
public class IfcRelAssociatesProfileProperties : IfcRelAssociates, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssociatesProfileProperties>
{
	private IfcProfileProperties _relatingProfileProperties;

	private IfcShapeAspect _profileSectionLocation;

	private IfcOrientationSelect _profileOrientation;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcProfileProperties RelatingProfileProperties
	{
		get
		{
			if (_activated)
			{
				return _relatingProfileProperties;
			}
			Activate();
			return _relatingProfileProperties;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProfileProperties v)
			{
				_relatingProfileProperties = v;
			}, _relatingProfileProperties, value, "RelatingProfileProperties", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcShapeAspect ProfileSectionLocation
	{
		get
		{
			if (_activated)
			{
				return _profileSectionLocation;
			}
			Activate();
			return _profileSectionLocation;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcShapeAspect v)
			{
				_profileSectionLocation = v;
			}, _profileSectionLocation, value, "ProfileSectionLocation", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcOrientationSelect ProfileOrientation
	{
		get
		{
			if (_activated)
			{
				return _profileOrientation;
			}
			Activate();
			return _profileOrientation;
		}
		set
		{
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcOrientationSelect v)
			{
				_profileOrientation = v;
			}, _profileOrientation, value, "ProfileOrientation", 8);
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
			foreach (IfcRoot relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingProfileProperties != null)
			{
				yield return RelatingProfileProperties;
			}
			if (ProfileSectionLocation != null)
			{
				yield return ProfileSectionLocation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcRoot relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
		}
	}

	internal IfcRelAssociatesProfileProperties(IModel model, int label, bool activated)
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
			_relatingProfileProperties = (IfcProfileProperties)value.EntityVal;
			break;
		case 6:
			_profileSectionLocation = (IfcShapeAspect)value.EntityVal;
			break;
		case 7:
			_profileOrientation = (IfcOrientationSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssociatesProfileProperties other)
	{
		return this == other;
	}
}
