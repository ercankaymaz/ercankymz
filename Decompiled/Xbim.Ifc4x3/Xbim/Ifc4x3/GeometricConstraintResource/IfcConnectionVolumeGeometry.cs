using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.GeometricModelResource;
using Xbim.Ifc4x3.TopologyResource;

namespace Xbim.Ifc4x3.GeometricConstraintResource;

[ExpressType("IfcConnectionVolumeGeometry", 1133)]
public class IfcConnectionVolumeGeometry : IfcConnectionGeometry, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcConnectionVolumeGeometry>, IIfcConnectionVolumeGeometry, IIfcConnectionGeometry
{
	private IfcSolidOrShell _volumeOnRelatingElement;

	private IfcSolidOrShell _volumeOnRelatedElement;

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

	[CrossSchemaAttribute(typeof(IIfcConnectionVolumeGeometry), 1)]
	IIfcSolidOrShell IIfcConnectionVolumeGeometry.VolumeOnRelatingElement
	{
		get
		{
			if (VolumeOnRelatingElement == null)
			{
				return null;
			}
			IfcClosedShell ifcClosedShell = VolumeOnRelatingElement as IfcClosedShell;
			if (ifcClosedShell != null)
			{
				return ifcClosedShell;
			}
			IfcSolidModel ifcSolidModel = VolumeOnRelatingElement as IfcSolidModel;
			if (ifcSolidModel != null)
			{
				return ifcSolidModel;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				VolumeOnRelatingElement = null;
				return;
			}
			IfcClosedShell ifcClosedShell = value as IfcClosedShell;
			if (ifcClosedShell != null)
			{
				VolumeOnRelatingElement = ifcClosedShell;
				return;
			}
			IfcSolidModel ifcSolidModel = value as IfcSolidModel;
			if (ifcSolidModel != null)
			{
				VolumeOnRelatingElement = ifcSolidModel;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConnectionVolumeGeometry), 2)]
	IIfcSolidOrShell IIfcConnectionVolumeGeometry.VolumeOnRelatedElement
	{
		get
		{
			if (VolumeOnRelatedElement == null)
			{
				return null;
			}
			IfcClosedShell ifcClosedShell = VolumeOnRelatedElement as IfcClosedShell;
			if (ifcClosedShell != null)
			{
				return ifcClosedShell;
			}
			IfcSolidModel ifcSolidModel = VolumeOnRelatedElement as IfcSolidModel;
			if (ifcSolidModel != null)
			{
				return ifcSolidModel;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				VolumeOnRelatedElement = null;
				return;
			}
			IfcClosedShell ifcClosedShell = value as IfcClosedShell;
			if (ifcClosedShell != null)
			{
				VolumeOnRelatedElement = ifcClosedShell;
				return;
			}
			IfcSolidModel ifcSolidModel = value as IfcSolidModel;
			if (ifcSolidModel != null)
			{
				VolumeOnRelatedElement = ifcSolidModel;
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
