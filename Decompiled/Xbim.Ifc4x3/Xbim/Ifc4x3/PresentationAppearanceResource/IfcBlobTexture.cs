using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcBlobTexture", 723)]
public class IfcBlobTexture : IfcSurfaceTexture, IIfcBlobTexture, IIfcSurfaceTexture, IIfcPresentationItem, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcBlobTexture>
{
	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier _rasterFormat;

	private Xbim.Ifc4x3.MeasureResource.IfcBinary _rasterCode;

	[CrossSchemaAttribute(typeof(IIfcBlobTexture), 6)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier IIfcBlobTexture.RasterFormat
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(RasterFormat);
		}
		set
		{
			RasterFormat = new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBlobTexture), 7)]
	Xbim.Ifc4.MeasureResource.IfcBinary IIfcBlobTexture.RasterCode
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcBinary(RasterCode);
		}
		set
		{
			RasterCode = new Xbim.Ifc4x3.MeasureResource.IfcBinary(value);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier RasterFormat
	{
		get
		{
			if (_activated)
			{
				return _rasterFormat;
			}
			Activate();
			return _rasterFormat;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier v)
			{
				_rasterFormat = v;
			}, _rasterFormat, value, "RasterFormat", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc4x3.MeasureResource.IfcBinary RasterCode
	{
		get
		{
			if (_activated)
			{
				return _rasterCode;
			}
			Activate();
			return _rasterCode;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcBinary v)
			{
				_rasterCode = v;
			}, _rasterCode, value, "RasterCode", 7);
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

	internal IfcBlobTexture(IModel model, int label, bool activated)
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
			_rasterFormat = value.StringVal;
			break;
		case 6:
			_rasterCode = value.HexadecimalVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBlobTexture other)
	{
		return this == other;
	}
}
