using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcTextureCoordinateGenerator", 733)]
public class IfcTextureCoordinateGenerator : IfcTextureCoordinate, IInstantiableEntity, IPersistEntity, IPersist, IIfcTextureCoordinateGenerator, IIfcTextureCoordinate, IIfcPresentationItem, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTextureCoordinateGenerator>
{
	private IfcLabel _mode;

	private readonly OptionalItemSet<IfcReal> _parameter;

	IfcLabel IIfcTextureCoordinateGenerator.Mode
	{
		get
		{
			return Mode;
		}
		set
		{
			Mode = value;
		}
	}

	IEnumerable<IfcReal> IIfcTextureCoordinateGenerator.Parameter => Parameter;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcLabel Mode
	{
		get
		{
			if (_activated)
			{
				return _mode;
			}
			Activate();
			return _mode;
		}
		set
		{
			SetValue(delegate(IfcLabel v)
			{
				_mode = v;
			}, _mode, value, "Mode", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 3)]
	public IOptionalItemSet<IfcReal> Parameter
	{
		get
		{
			if (_activated)
			{
				return _parameter;
			}
			Activate();
			return _parameter;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcSurfaceTexture map in base.Maps)
			{
				yield return map;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcSurfaceTexture map in base.Maps)
			{
				yield return map;
			}
		}
	}

	internal IfcTextureCoordinateGenerator(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_parameter = new OptionalItemSet<IfcReal>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_mode = value.StringVal;
			break;
		case 2:
			_parameter.InternalAdd(value.RealVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTextureCoordinateGenerator other)
	{
		return this == other;
	}
}
