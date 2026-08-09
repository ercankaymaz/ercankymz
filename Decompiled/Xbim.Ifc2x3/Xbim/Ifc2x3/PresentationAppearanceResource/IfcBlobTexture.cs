using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcBlobTexture", 723)]
public class IfcBlobTexture : IfcSurfaceTexture, IIfcBlobTexture, IIfcSurfaceTexture, IIfcPresentationItem, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcBlobTexture>, IExpressValidatable
{
	public enum IfcBlobTextureClause
	{
		WR11
	}

	private IfcBinary _rasterCode4;

	private Xbim.Ifc2x3.MeasureResource.IfcIdentifier _rasterFormat;

	private bool _rasterCode;

	[CrossSchemaAttribute(typeof(IIfcBlobTexture), 6)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier IIfcBlobTexture.RasterFormat
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(RasterFormat);
		}
		set
		{
			RasterFormat = new Xbim.Ifc2x3.MeasureResource.IfcIdentifier(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBlobTexture), 7)]
	IfcBinary IIfcBlobTexture.RasterCode
	{
		get
		{
			return _rasterCode4;
		}
		set
		{
			SetValue(delegate(IfcBinary v)
			{
				_rasterCode4 = v;
			}, _rasterCode4, value, "RasterCode", -7);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcIdentifier RasterFormat
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcIdentifier v)
			{
				_rasterFormat = v;
			}, _rasterFormat, value, "RasterFormat", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public bool RasterCode
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
			SetValue(delegate(bool v)
			{
				_rasterCode = v;
			}, _rasterCode, value, "RasterCode", 6);
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_rasterFormat = value.StringVal;
			break;
		case 5:
			_rasterCode = value.BooleanVal;
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
			if (clause == IfcBlobTextureClause.WR11)
			{
				result = Functions.NewArray<string>("BMP", "JPG", "GIF", "PNG").Contains(RasterFormat);
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
		if (!ValidateClause(IfcBlobTextureClause.WR11))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBlobTexture.WR11",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
