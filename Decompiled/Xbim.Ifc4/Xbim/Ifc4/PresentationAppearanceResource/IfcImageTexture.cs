using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcImageTexture", 727)]
public class IfcImageTexture : IfcSurfaceTexture, IInstantiableEntity, IPersistEntity, IPersist, IIfcImageTexture, IIfcSurfaceTexture, IIfcPresentationItem, IContainsEntityReferences, IEquatable<IfcImageTexture>
{
	private IfcURIReference _uRLReference;

	IfcURIReference IIfcImageTexture.URLReference
	{
		get
		{
			return URLReference;
		}
		set
		{
			URLReference = value;
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcURIReference URLReference
	{
		get
		{
			if (_activated)
			{
				return _uRLReference;
			}
			Activate();
			return _uRLReference;
		}
		set
		{
			SetValue(delegate(IfcURIReference v)
			{
				_uRLReference = v;
			}, _uRLReference, value, "URLReference", 6);
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
		case 4:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_uRLReference = value.StringVal;
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
