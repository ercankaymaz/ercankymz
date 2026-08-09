using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.GeometricConstraintResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcRelInterferesElements", 1252)]
public class IfcRelInterferesElements : IfcRelConnects, IIfcRelInterferesElements, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelInterferesElements>
{
	private IfcInterferenceSelect _relatingElement;

	private IfcInterferenceSelect _relatedElement;

	private IfcConnectionGeometry _interferenceGeometry;

	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _interferenceType;

	private Xbim.Ifc4x3.MeasureResource.IfcLogical _impliedOrder;

	private IfcSpatialZone _interferenceSpace;

	[CrossSchemaAttribute(typeof(IIfcRelInterferesElements), 5)]
	IIfcElement IIfcRelInterferesElements.RelatingElement
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelInterferesElements), 6)]
	IIfcElement IIfcRelInterferesElements.RelatedElement
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelInterferesElements), 7)]
	IIfcConnectionGeometry IIfcRelInterferesElements.InterferenceGeometry
	{
		get
		{
			return InterferenceGeometry;
		}
		set
		{
			InterferenceGeometry = value as IfcConnectionGeometry;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelInterferesElements), 8)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcRelInterferesElements.InterferenceType
	{
		get
		{
			if (!InterferenceType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(InterferenceType.Value);
		}
		set
		{
			InterferenceType = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelInterferesElements), 9)]
	bool? IIfcRelInterferesElements.ImpliedOrder
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			ImpliedOrder = value;
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcInterferenceSelect RelatingElement
	{
		get
		{
			if (_activated)
			{
				return _relatingElement;
			}
			Activate();
			return _relatingElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcInterferenceSelect v)
			{
				_relatingElement = v;
			}, _relatingElement, value, "RelatingElement", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcInterferenceSelect RelatedElement
	{
		get
		{
			if (_activated)
			{
				return _relatedElement;
			}
			Activate();
			return _relatedElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcInterferenceSelect v)
			{
				_relatedElement = v;
			}, _relatedElement, value, "RelatedElement", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcConnectionGeometry InterferenceGeometry
	{
		get
		{
			if (_activated)
			{
				return _interferenceGeometry;
			}
			Activate();
			return _interferenceGeometry;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcConnectionGeometry v)
			{
				_interferenceGeometry = v;
			}, _interferenceGeometry, value, "InterferenceGeometry", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier? InterferenceType
	{
		get
		{
			if (_activated)
			{
				return _interferenceType;
			}
			Activate();
			return _interferenceType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier? v)
			{
				_interferenceType = v;
			}, _interferenceType, value, "InterferenceType", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc4x3.MeasureResource.IfcLogical ImpliedOrder
	{
		get
		{
			if (_activated)
			{
				return _impliedOrder;
			}
			Activate();
			return _impliedOrder;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLogical v)
			{
				_impliedOrder = v;
			}, _impliedOrder, value, "ImpliedOrder", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 10)]
	public IfcSpatialZone InterferenceSpace
	{
		get
		{
			if (_activated)
			{
				return _interferenceSpace;
			}
			Activate();
			return _interferenceSpace;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSpatialZone v)
			{
				_interferenceSpace = v;
			}, _interferenceSpace, value, "InterferenceSpace", 10);
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
			if (RelatingElement != null)
			{
				yield return RelatingElement;
			}
			if (RelatedElement != null)
			{
				yield return RelatedElement;
			}
			if (InterferenceGeometry != null)
			{
				yield return InterferenceGeometry;
			}
			if (InterferenceSpace != null)
			{
				yield return InterferenceSpace;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingElement != null)
			{
				yield return RelatingElement;
			}
			if (RelatedElement != null)
			{
				yield return RelatedElement;
			}
		}
	}

	internal IfcRelInterferesElements(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_relatingElement = (IfcInterferenceSelect)value.EntityVal;
			break;
		case 5:
			_relatedElement = (IfcInterferenceSelect)value.EntityVal;
			break;
		case 6:
			_interferenceGeometry = (IfcConnectionGeometry)value.EntityVal;
			break;
		case 7:
			_interferenceType = value.StringVal;
			break;
		case 8:
			_impliedOrder = value.BooleanVal;
			break;
		case 9:
			_interferenceSpace = (IfcSpatialZone)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelInterferesElements other)
	{
		return this == other;
	}
}
