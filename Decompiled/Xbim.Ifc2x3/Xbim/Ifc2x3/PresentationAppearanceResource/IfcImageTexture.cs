using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcImageTexture", 727)]
public class IfcImageTexture : IfcSurfaceTexture, IIfcImageTexture, IIfcSurfaceTexture, IIfcPresentationItem, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcImageTexture>
{
	private IfcIdentifier _urlReference;

	[CrossSchemaAttribute(typeof(IIfcImageTexture), 6)]
	IfcURIReference IIfcImageTexture.URLReference
	{
		get
		{
			return new IfcURIReference(UrlReference);
		}
		set
		{
			UrlReference = new IfcIdentifier(value);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcIdentifier UrlReference
	{
		get
		{
			if (_activated)
			{
				return _urlReference;
			}
			Activate();
			return _urlReference;
		}
		set
		{
			SetValue(delegate(IfcIdentifier v)
			{
				_urlReference = v;
			}, _urlReference, value, "UrlReference", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.TextureTransform != null)
			{
				yield return base.TextureTransform;
			}
		}
	}

	internal IfcImageTexture(IModel model, int label, bool activated)
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
			_urlReference = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcImageTexture other)
	{
		return this == other;
	}
}
