using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;

namespace devDept.Serialization;

public class BlockReferenceExSurrogate : BlockReferenceSurrogate
{
	public List<KeyValuePair<string, ProtoObject>> CustomProperties;

	public BlockReferenceExSurrogate(BlockReferenceEx blockReferenceEx)
		: base(blockReferenceEx)
	{
	}

	protected override Entity ConvertToObject()
	{
		BlockReferenceEx blockReferenceEx = new BlockReferenceEx(Transformation, BlockName);
		CopyDataToObject(blockReferenceEx);
		return blockReferenceEx;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		BlockReferenceEx blockReferenceEx = entity as BlockReferenceEx;
		if (CustomProperties != null)
		{
			blockReferenceEx.CustomProperties = new List<KeyValuePair<string, object>>();
			foreach (KeyValuePair<string, ProtoObject> customProperty in CustomProperties)
			{
				ProtoObject value = customProperty.Value;
				blockReferenceEx.CustomProperties.Add(new KeyValuePair<string, object>(customProperty.Key, value?.Object));
			}
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		BlockReferenceEx blockReferenceEx = entity as BlockReferenceEx;
		if (blockReferenceEx.CustomProperties != null)
		{
			CustomProperties = new List<KeyValuePair<string, ProtoObject>>();
			foreach (KeyValuePair<string, object> customProperty in blockReferenceEx.CustomProperties)
			{
				CustomProperties.Add(new KeyValuePair<string, ProtoObject>(customProperty.Key, new ProtoObject(customProperty.Value)));
			}
		}
		base.CopyDataFromObject(entity);
	}
}
