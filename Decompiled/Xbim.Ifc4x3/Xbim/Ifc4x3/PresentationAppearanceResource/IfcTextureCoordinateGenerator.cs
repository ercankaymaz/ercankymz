using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcTextureCoordinateGenerator", 733)]
public class IfcTextureCoordinateGenerator : IfcTextureCoordinate, IIfcTextureCoordinateGenerator, IIfcTextureCoordinate, IIfcPresentationItem, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTextureCoordinateGenerator>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel _mode;

	private readonly OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcReal> _parameter;

	[CrossSchemaAttribute(typeof(IIfcTextureCoordinateGenerator), 2)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcTextureCoordinateGenerator.Mode
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Mode);
		}
		set
		{
			Mode = new Xbim.Ifc4x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextureCoordinateGenerator), 3)]
	IEnumerable<Xbim.Ifc4.MeasureResource.IfcReal> IIfcTextureCoordinateGenerator.Parameter => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcReal, Xbim.Ifc4.MeasureResource.IfcReal>(Parameter, (Xbim.Ifc4x3.MeasureResource.IfcReal s) => new Xbim.Ifc4.MeasureResource.IfcReal(s), (Xbim.Ifc4.MeasureResource.IfcReal t) => new Xbim.Ifc4x3.MeasureResource.IfcReal(t));

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel Mode
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel v)
			{
				_mode = v;
			}, _mode, value, "Mode", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 3)]
	public IOptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcReal> Parameter
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
		_parameter = new OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcReal>(this, 0, 3);
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
