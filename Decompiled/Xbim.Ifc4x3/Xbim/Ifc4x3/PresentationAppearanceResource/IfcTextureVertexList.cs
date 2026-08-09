using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.PresentationDefinitionResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcTextureVertexList", 1301)]
public class IfcTextureVertexList : IfcPresentationItem, IIfcTextureVertexList, IIfcPresentationItem, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcTextureVertexList>
{
	private readonly ItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue>> _texCoordsList;

	[CrossSchemaAttribute(typeof(IIfcTextureVertexList), 1)]
	IItemSet<IItemSet<Xbim.Ifc4.MeasureResource.IfcParameterValue>> IIfcTextureVertexList.TexCoordsList => new ProxyNestedValueSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue, Xbim.Ifc4.MeasureResource.IfcParameterValue>(TexCoordsList, (Xbim.Ifc4x3.MeasureResource.IfcParameterValue s) => new Xbim.Ifc4.MeasureResource.IfcParameterValue(s), (Xbim.Ifc4.MeasureResource.IfcParameterValue t) => new Xbim.Ifc4x3.MeasureResource.IfcParameterValue(t));

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.List, new int[] { 1, 2 }, new int[] { -1, 2 }, 1)]
	public IItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue>> TexCoordsList
	{
		get
		{
			if (_activated)
			{
				return _texCoordsList;
			}
			Activate();
			return _texCoordsList;
		}
	}

	internal IfcTextureVertexList(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_texCoordsList = new ItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue>>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			((ItemSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue>)_texCoordsList.InternalGetAt(nestedIndex[0])).InternalAdd(value.RealVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcTextureVertexList other)
	{
		return this == other;
	}
}
