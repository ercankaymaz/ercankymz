using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc4x3.RepresentationResource;

[ExpressType("IfcWellKnownText", 1507)]
public class IfcWellKnownText : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcWellKnownText>
{
	private IfcWellKnownTextLiteral _wellKnownText;

	private IfcCoordinateReferenceSystem _coordinateReferenceSystem;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcWellKnownTextLiteral WellKnownText
	{
		get
		{
			if (_activated)
			{
				return _wellKnownText;
			}
			Activate();
			return _wellKnownText;
		}
		set
		{
			SetValue(delegate(IfcWellKnownTextLiteral v)
			{
				_wellKnownText = v;
			}, _wellKnownText, value, "WellKnownText", 1);
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcCoordinateReferenceSystem CoordinateReferenceSystem
	{
		get
		{
			if (_activated)
			{
				return _coordinateReferenceSystem;
			}
			Activate();
			return _coordinateReferenceSystem;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCoordinateReferenceSystem v)
			{
				_coordinateReferenceSystem = v;
			}, _coordinateReferenceSystem, value, "CoordinateReferenceSystem", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (CoordinateReferenceSystem != null)
			{
				yield return CoordinateReferenceSystem;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (CoordinateReferenceSystem != null)
			{
				yield return CoordinateReferenceSystem;
			}
		}
	}

	internal IfcWellKnownText(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_wellKnownText = value.StringVal;
			break;
		case 1:
			_coordinateReferenceSystem = (IfcCoordinateReferenceSystem)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWellKnownText other)
	{
		return this == other;
	}
}
