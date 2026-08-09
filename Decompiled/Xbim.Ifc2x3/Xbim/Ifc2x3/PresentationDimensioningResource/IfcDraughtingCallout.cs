using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;

namespace Xbim.Ifc2x3.PresentationDimensioningResource;

[ExpressType("IfcDraughtingCallout", 222)]
public class IfcDraughtingCallout : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcDraughtingCallout>
{
	private readonly ItemSet<IfcDraughtingCalloutElement> _contents;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<IfcDraughtingCalloutElement> Contents
	{
		get
		{
			if (_activated)
			{
				return _contents;
			}
			Activate();
			return _contents;
		}
	}

	[InverseProperty("RelatedDraughtingCallout")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 4)]
	public IEnumerable<IfcDraughtingCalloutRelationship> IsRelatedFromCallout => base.Model.Instances.Where((IfcDraughtingCalloutRelationship e) => Equals(e.RelatedDraughtingCallout), "RelatedDraughtingCallout", this);

	[InverseProperty("RelatingDraughtingCallout")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 5)]
	public IEnumerable<IfcDraughtingCalloutRelationship> IsRelatedToCallout => base.Model.Instances.Where((IfcDraughtingCalloutRelationship e) => Equals(e.RelatingDraughtingCallout), "RelatingDraughtingCallout", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcDraughtingCalloutElement content in Contents)
			{
				yield return content;
			}
		}
	}

	internal IfcDraughtingCallout(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_contents = new ItemSet<IfcDraughtingCalloutElement>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_contents.InternalAdd((IfcDraughtingCalloutElement)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcDraughtingCallout other)
	{
		return this == other;
	}
}
