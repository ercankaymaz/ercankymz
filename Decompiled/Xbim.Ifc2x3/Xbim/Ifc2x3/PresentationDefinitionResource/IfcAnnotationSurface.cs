using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.PresentationDefinitionResource;

[ExpressType("IfcAnnotationSurface", 731)]
public class IfcAnnotationSurface : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcAnnotationSurface>, IExpressValidatable
{
	public enum IfcAnnotationSurfaceClause
	{
		WR01
	}

	private IfcGeometricRepresentationItem _item;

	private IfcTextureCoordinate _textureCoordinates;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcGeometricRepresentationItem Item
	{
		get
		{
			if (_activated)
			{
				return _item;
			}
			Activate();
			return _item;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcGeometricRepresentationItem v)
			{
				_item = v;
			}, _item, value, "Item", 1);
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcTextureCoordinate TextureCoordinates
	{
		get
		{
			if (_activated)
			{
				return _textureCoordinates;
			}
			Activate();
			return _textureCoordinates;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcTextureCoordinate v)
			{
				_textureCoordinates = v;
			}, _textureCoordinates, value, "TextureCoordinates", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Item != null)
			{
				yield return Item;
			}
			if (TextureCoordinates != null)
			{
				yield return TextureCoordinates;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (TextureCoordinates != null)
			{
				yield return TextureCoordinates;
			}
		}
	}

	internal IfcAnnotationSurface(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_item = (IfcGeometricRepresentationItem)value.EntityVal;
			break;
		case 1:
			_textureCoordinates = (IfcTextureCoordinate)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAnnotationSurface other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcAnnotationSurfaceClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcAnnotationSurfaceClause.WR01)
			{
				result = Functions.SIZEOF(Functions.NewArray<string>("IFC2X3.IFCSURFACE", "IFC2X3.IFCSHELLBASEDSURFACEMODEL", "IFC2X3.IFCFACEBASEDSURFACEMODEL", "IFC2X3.IFCSOLIDMODEL", "IFC2X3.IFCBOOLEANRESULT", "IFC2X3.IFCCSGPRIMITIVE3D") * Functions.TYPEOF(Item)) >= 1;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcAnnotationSurface>()?.LogError($"Exception thrown evaluating where-clause 'IfcAnnotationSurface.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcAnnotationSurfaceClause.WR01))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAnnotationSurface.WR01",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
