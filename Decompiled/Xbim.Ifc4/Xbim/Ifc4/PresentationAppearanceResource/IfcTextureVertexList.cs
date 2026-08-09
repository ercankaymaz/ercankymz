using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationDefinitionResource;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcTextureVertexList", 1301)]
public class IfcTextureVertexList : IfcPresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcTextureVertexList, IIfcPresentationItem, IEquatable<IfcTextureVertexList>
{
	private readonly ItemSet<IItemSet<IfcParameterValue>> _texCoordsList;

	IItemSet<IItemSet<IfcParameterValue>> IIfcTextureVertexList.TexCoordsList => TexCoordsList;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.List, new int[] { 1, 2 }, new int[] { -1, 2 }, 1)]
	public IItemSet<IItemSet<IfcParameterValue>> TexCoordsList
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
		_texCoordsList = new ItemSet<IItemSet<IfcParameterValue>>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			((ItemSet<IfcParameterValue>)_texCoordsList.InternalGetAt(nestedIndex[0])).InternalAdd(value.RealVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcTextureVertexList other)
	{
		return this == other;
	}
}
