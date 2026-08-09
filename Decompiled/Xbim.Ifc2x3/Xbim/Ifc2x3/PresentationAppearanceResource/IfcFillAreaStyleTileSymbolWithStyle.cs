using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.PresentationDefinitionResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcFillAreaStyleTileSymbolWithStyle", 726)]
public class IfcFillAreaStyleTileSymbolWithStyle : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IfcFillAreaStyleTileShapeSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcFillAreaStyleTileSymbolWithStyle>
{
	private IfcAnnotationSymbolOccurrence _symbol;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcAnnotationSymbolOccurrence Symbol
	{
		get
		{
			if (_activated)
			{
				return _symbol;
			}
			Activate();
			return _symbol;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAnnotationSymbolOccurrence v)
			{
				_symbol = v;
			}, _symbol, value, "Symbol", 1);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Symbol != null)
			{
				yield return Symbol;
			}
		}
	}

	internal IfcFillAreaStyleTileSymbolWithStyle(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_symbol = (IfcAnnotationSymbolOccurrence)value.EntityVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcFillAreaStyleTileSymbolWithStyle other)
	{
		return this == other;
	}
}
