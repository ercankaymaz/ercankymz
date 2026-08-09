using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Interfaces.Conversions;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.PresentationDefinitionResource;

[ExpressType("IfcTextureMap", 734)]
public class IfcTextureMap : IfcTextureCoordinate, IIfcTextureMap, IIfcTextureCoordinate, IIfcPresentationItem, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcTextureMap>, IExpressValidatable
{
	public enum IfcTextureMapClause
	{
		WR11
	}

	private IIfcFace _mappedTo;

	private readonly ItemSet<IfcVertexBasedTextureMap> _textureMaps;

	[CrossSchemaAttribute(typeof(IIfcTextureMap), 2)]
	IEnumerable<IIfcTextureVertex> IIfcTextureMap.Vertices
	{
		get
		{
			IfcVertexBasedTextureMap ifcVertexBasedTextureMap = TextureMaps.FirstOrDefault();
			if (!(ifcVertexBasedTextureMap == null))
			{
				return ifcVertexBasedTextureMap.TextureVertices;
			}
			return Enumerable.Empty<IIfcTextureVertex>();
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextureMap), 3)]
	IIfcFace IIfcTextureMap.MappedTo
	{
		get
		{
			return _mappedTo ?? new IfcFaceTransient(TextureMaps.First());
		}
		set
		{
			SetValue(delegate(IIfcFace v)
			{
				_mappedTo = v;
			}, _mappedTo, value, "MappedTo", -3);
			NotifyPropertyChanged("MappedTo");
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcVertexBasedTextureMap> TextureMaps
	{
		get
		{
			if (_activated)
			{
				return _textureMaps;
			}
			Activate();
			return _textureMaps;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcVertexBasedTextureMap textureMap in TextureMaps)
			{
				yield return textureMap;
			}
		}
	}

	internal IfcTextureMap(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_textureMaps = new ItemSet<IfcVertexBasedTextureMap>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_textureMaps.InternalAdd((IfcVertexBasedTextureMap)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcTextureMap other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcTextureMapClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcTextureMapClause.WR11)
			{
				result = Functions.SIZEOF(Functions.NewArray<string>("IFC2X3.IFCSHELLBASEDSURFACEMODEL", "IFC2X3.IFCFACEBASEDSURFACEMODEL", "IFC2X3.IFCFACETEDBREP", "IFC2X3.IFCFACETEDBREPWITHVOIDS") * Functions.TYPEOF(base.AnnotatedSurface.ItemAt(0L).Item)) >= 1;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTextureMap>()?.LogError($"Exception thrown evaluating where-clause 'IfcTextureMap.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcTextureMapClause.WR11))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTextureMap.WR11",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
