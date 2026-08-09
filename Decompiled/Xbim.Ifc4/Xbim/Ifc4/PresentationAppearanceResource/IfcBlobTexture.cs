using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcBlobTexture", 723)]
public class IfcBlobTexture : IfcSurfaceTexture, IInstantiableEntity, IPersistEntity, IPersist, IIfcBlobTexture, IIfcSurfaceTexture, IIfcPresentationItem, IContainsEntityReferences, IEquatable<IfcBlobTexture>, IExpressValidatable
{
	public enum IfcBlobTextureClause
	{
		SupportedRasterFormat,
		RasterCodeByteStream
	}

	private IfcIdentifier _rasterFormat;

	private IfcBinary _rasterCode;

	IfcIdentifier IIfcBlobTexture.RasterFormat
	{
		get
		{
			return RasterFormat;
		}
		set
		{
			RasterFormat = value;
		}
	}

	IfcBinary IIfcBlobTexture.RasterCode
	{
		get
		{
			return RasterCode;
		}
		set
		{
			RasterCode = value;
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcIdentifier RasterFormat
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
			SetValue(delegate(IfcIdentifier v)
			{
				_rasterFormat = v;
			}, _rasterFormat, value, "RasterFormat", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcBinary RasterCode
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
			SetValue(delegate(IfcBinary v)
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

	public bool ValidateClause(IfcBlobTextureClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcBlobTextureClause.SupportedRasterFormat:
				result = Functions.NewTypesArray("BMP", "JPG", "GIF", "PNG").Contains(RasterFormat);
				break;
			case IfcBlobTextureClause.RasterCodeByteStream:
				result = Functions.BLENGTH(RasterCode) % 8 == 0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcBlobTexture>()?.LogError($"Exception thrown evaluating where-clause 'IfcBlobTexture.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcBlobTextureClause.SupportedRasterFormat))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBlobTexture.SupportedRasterFormat",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcBlobTextureClause.RasterCodeByteStream))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBlobTexture.RasterCodeByteStream",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
