using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcSymbolStyle", 729)]
public class IfcSymbolStyle : IfcPresentationStyle, IInstantiableEntity, IPersistEntity, IPersist, IfcPresentationStyleSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcSymbolStyle>
{
	private IfcSymbolStyleSelect _styleOfSymbol;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcSymbolStyleSelect StyleOfSymbol
	{
		get
		{
			if (_activated)
			{
				return _styleOfSymbol;
			}
			Activate();
			return _styleOfSymbol;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSymbolStyleSelect v)
			{
				_styleOfSymbol = v;
			}, _styleOfSymbol, value, "StyleOfSymbol", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (StyleOfSymbol != null)
			{
				yield return StyleOfSymbol;
			}
		}
	}

	internal IfcSymbolStyle(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_styleOfSymbol = (IfcSymbolStyleSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSymbolStyle other)
	{
		return this == other;
	}
}
