using System.Collections.Generic;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class BlockReferenceSurrogate(BlockReference blockReference) : EntitySurrogate(blockReference)
{
	public string BlockName;

	public Transformation Transformation;

	public Dictionary<string, AttributeReference> Attributes = new Dictionary<string, AttributeReference>();

	public bool IsFixed;

	protected override Entity ConvertToObject()
	{
		return _0023_003DzC3X1_iZp12rj();
	}

	internal BlockReference _0023_003DzC3X1_iZp12rj()
	{
		BlockReference blockReference = new BlockReference(this);
		CopyDataToObject(blockReference);
		return blockReference;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		BlockReference blockReference = entity as BlockReference;
		blockReference.Transformation = Transformation;
		blockReference.localMin = BoxMin;
		blockReference.localMax = BoxMax;
		if (base.Content != contentType.Tessellation && Attributes != null)
		{
			foreach (KeyValuePair<string, AttributeReference> attribute in Attributes)
			{
				blockReference.Attributes.Add(attribute.Key, attribute.Value);
			}
		}
		blockReference.IsFixed = IsFixed;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		BlockReference blockReference = (BlockReference)entity;
		BlockName = ((!string.IsNullOrEmpty(blockReference.blockNameForExport)) ? blockReference.blockNameForExport : blockReference.BlockName);
		blockReference.blockNameForExport = null;
		Transformation = blockReference.Transformation;
		BoxMin = blockReference.BoxMin;
		BoxMax = blockReference.BoxMax;
		if (blockReference.Attributes != null)
		{
			foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
			{
				Attributes.Add(attribute.Key, attribute.Value);
			}
		}
		IsFixed = blockReference.IsFixed;
		base.CopyDataFromObject(entity);
	}
}
