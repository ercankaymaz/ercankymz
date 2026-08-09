using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcPixelTexture", 728)]
public class IfcPixelTexture : IfcSurfaceTexture, IIfcPixelTexture, IIfcSurfaceTexture, IIfcPresentationItem, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcPixelTexture>, IExpressValidatable
{
	public enum IfcPixelTextureClause
	{
		WR21,
		WR22,
		WR23,
		WR24
	}

	private Xbim.Ifc2x3.MeasureResource.IfcInteger _width;

	private Xbim.Ifc2x3.MeasureResource.IfcInteger _height;

	private Xbim.Ifc2x3.MeasureResource.IfcInteger _colourComponents;

	private readonly ItemSet<byte[]> _pixel;

	[CrossSchemaAttribute(typeof(IIfcPixelTexture), 6)]
	Xbim.Ifc4.MeasureResource.IfcInteger IIfcPixelTexture.Width
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcInteger(Width);
		}
		set
		{
			Width = new Xbim.Ifc2x3.MeasureResource.IfcInteger(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPixelTexture), 7)]
	Xbim.Ifc4.MeasureResource.IfcInteger IIfcPixelTexture.Height
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcInteger(Height);
		}
		set
		{
			Height = new Xbim.Ifc2x3.MeasureResource.IfcInteger(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPixelTexture), 8)]
	Xbim.Ifc4.MeasureResource.IfcInteger IIfcPixelTexture.ColourComponents
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcInteger(ColourComponents);
		}
		set
		{
			ColourComponents = new Xbim.Ifc2x3.MeasureResource.IfcInteger(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPixelTexture), 9)]
	IItemSet<IfcBinary> IIfcPixelTexture.Pixel => new ProxyValueSet<byte[], IfcBinary>(Pixel, (byte[] s) => s, (IfcBinary t) => t);

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcInteger Width
	{
		get
		{
			if (_activated)
			{
				return _width;
			}
			Activate();
			return _width;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcInteger v)
			{
				_width = v;
			}, _width, value, "Width", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcInteger Height
	{
		get
		{
			if (_activated)
			{
				return _height;
			}
			Activate();
			return _height;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcInteger v)
			{
				_height = v;
			}, _height, value, "Height", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcInteger ColourComponents
	{
		get
		{
			if (_activated)
			{
				return _colourComponents;
			}
			Activate();
			return _colourComponents;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcInteger v)
			{
				_colourComponents = v;
			}, _colourComponents, value, "ColourComponents", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 8)]
	public IItemSet<byte[]> Pixel
	{
		get
		{
			if (_activated)
			{
				return _pixel;
			}
			Activate();
			return _pixel;
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

	internal IfcPixelTexture(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_pixel = new ItemSet<byte[]>(this, 0, 8);
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
			_width = value.IntegerVal;
			break;
		case 5:
			_height = value.IntegerVal;
			break;
		case 6:
			_colourComponents = value.IntegerVal;
			break;
		case 7:
			_pixel.InternalAdd(value.HexadecimalVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPixelTexture other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPixelTextureClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcPixelTextureClause.WR21:
				result = (long)Width >= 1;
				break;
			case IfcPixelTextureClause.WR22:
				result = (long)Height >= 1;
				break;
			case IfcPixelTextureClause.WR23:
				result = 1 <= (long)ColourComponents && (long)ColourComponents <= 4;
				break;
			case IfcPixelTextureClause.WR24:
				result = Functions.SIZEOF(Pixel) == (long)Width * (long)Height;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPixelTexture>()?.LogError($"Exception thrown evaluating where-clause 'IfcPixelTexture.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPixelTextureClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPixelTexture.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPixelTextureClause.WR22))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPixelTexture.WR22",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPixelTextureClause.WR23))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPixelTexture.WR23",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPixelTextureClause.WR24))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPixelTexture.WR24",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
