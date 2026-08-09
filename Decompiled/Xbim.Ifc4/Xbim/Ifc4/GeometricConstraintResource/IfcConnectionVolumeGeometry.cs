using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.GeometricConstraintResource;

[ExpressType("IfcConnectionVolumeGeometry", 1133)]
public class IfcConnectionVolumeGeometry : IfcConnectionGeometry, IInstantiableEntity, IPersistEntity, IPersist, IIfcConnectionVolumeGeometry, IIfcConnectionGeometry, IContainsEntityReferences, IEquatable<IfcConnectionVolumeGeometry>
{
	private IfcSolidOrShell _volumeOnRelatingElement;

	private IfcSolidOrShell _volumeOnRelatedElement;

	IIfcSolidOrShell IIfcConnectionVolumeGeometry.VolumeOnRelatingElement
	{
		get
		{
			return VolumeOnRelatingElement;
		}
		set
		{
			VolumeOnRelatingElement = value as IfcSolidOrShell;
		}
	}

	IIfcSolidOrShell IIfcConnectionVolumeGeometry.VolumeOnRelatedElement
	{
		get
		{
			return VolumeOnRelatedElement;
		}
		set
		{
			VolumeOnRelatedElement = value as IfcSolidOrShell;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcSolidOrShell VolumeOnRelatingElement
	{
		get
		{
			if (_activated)
			{
				return _volumeOnRelatingElement;
			}
			Activate();
			return _volumeOnRelatingElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSolidOrShell v)
			{
				_volumeOnRelatingElement = v;
			}, _volumeOnRelatingElement, value, "VolumeOnRelatingElement", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcSolidOrShell VolumeOnRelatedElement
	{
		get
		{
			if (_activated)
			{
				return _volumeOnRelatedElement;
			}
			Activate();
			return _volumeOnRelatedElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSolidOrShell v)
			{
				_volumeOnRelatedElement = v;
			}, _volumeOnRelatedElement, value, "VolumeOnRelatedElement", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (VolumeOnRelatingElement != null)
			{
				yield return VolumeOnRelatingElement;
			}
			if (VolumeOnRelatedElement != null)
			{
				yield return VolumeOnRelatedElement;
			}
		}
	}

	internal IfcConnectionVolumeGeometry(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_volumeOnRelatingElement = (IfcSolidOrShell)value.EntityVal;
			break;
		case 1:
			_volumeOnRelatedElement = (IfcSolidOrShell)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConnectionVolumeGeometry other)
	{
		return this == other;
	}
}
