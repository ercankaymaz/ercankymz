using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcPixelTexture", 728)]
public class IfcPixelTexture : IfcSurfaceTexture, IInstantiableEntity, IPersistEntity, IPersist, IIfcPixelTexture, IIfcSurfaceTexture, IIfcPresentationItem, IContainsEntityReferences, IEquatable<IfcPixelTexture>, IExpressValidatable
{
	public enum IfcPixelTextureClause
	{
		MinPixelInS,
		MinPixelInT,
		NumberOfColours,
		SizeOfPixelList,
		PixelAsByteAndSameLength
	}

	private IfcInteger _width;

	private IfcInteger _height;

	private IfcInteger _colourComponents;

	private readonly ItemSet<IfcBinary> _pixel;

	IfcInteger IIfcPixelTexture.Width
	{
		get
		{
			return Width;
		}
		set
		{
			Width = value;
		}
	}

	IfcInteger IIfcPixelTexture.Height
	{
		get
		{
			return Height;
		}
		set
		{
			Height = value;
		}
	}

	IfcInteger IIfcPixelTexture.ColourComponents
	{
		get
		{
			return ColourComponents;
		}
		set
		{
			ColourComponents = value;
		}
	}

	IItemSet<IfcBinary> IIfcPixelTexture.Pixel => Pixel;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcInteger Width
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
			SetValue(delegate(IfcInteger v)
			{
				_width = v;
			}, _width, value, "Width", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcInteger Height
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
			SetValue(delegate(IfcInteger v)
			{
				_height = v;
			}, _height, value, "Height", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcInteger ColourComponents
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
			SetValue(delegate(IfcInteger v)
			{
				_colourComponents = v;
			}, _colourComponents, value, "ColourComponents", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 11)]
	public IItemSet<IfcBinary> Pixel
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
		_pixel = new ItemSet<IfcBinary>(this, 0, 9);
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
			_width = value.IntegerVal;
			break;
		case 6:
			_height = value.IntegerVal;
			break;
		case 7:
			_colourComponents = value.IntegerVal;
			break;
		case 8:
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
			case IfcPixelTextureClause.MinPixelInS:
				result = (long)Width >= 1;
				break;
			case IfcPixelTextureClause.MinPixelInT:
				result = (long)Height >= 1;
				break;
			case IfcPixelTextureClause.NumberOfColours:
				result = 1 <= (long)ColourComponents && (long)ColourComponents <= 4;
				break;
			case IfcPixelTextureClause.SizeOfPixelList:
				result = Functions.SIZEOF(Pixel) == (long)Width * (long)Height;
				break;
			case IfcPixelTextureClause.PixelAsByteAndSameLength:
				result = Functions.SIZEOF(Enumerable.Where(Pixel, (IfcBinary temp) => Functions.BLENGTH(temp) % 8 == 0 && Functions.BLENGTH(temp) == Functions.BLENGTH(Pixel.ItemAt(0L)))) == Functions.SIZEOF(Pixel);
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
		if (!ValidateClause(IfcPixelTextureClause.MinPixelInS))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPixelTexture.MinPixelInS",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPixelTextureClause.MinPixelInT))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPixelTexture.MinPixelInT",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPixelTextureClause.NumberOfColours))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPixelTexture.NumberOfColours",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPixelTextureClause.SizeOfPixelList))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPixelTexture.SizeOfPixelList",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPixelTextureClause.PixelAsByteAndSameLength))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPixelTexture.PixelAsByteAndSameLength",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
