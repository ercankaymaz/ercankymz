using devDept.Eyeshot;
using devDept.Eyeshot.Translators;

namespace devDept.Serialization;

internal class BlockExSurrogate : BlockSurrogate
{
	public string XRefName_V12;

	public byte BlockSource_V12;

	public BlockExSurrogate(BlockEx blockEx)
		: base(blockEx)
	{
	}

	protected override Block ConvertToObject()
	{
		Block block = new Block(Name);
		XRefName = XRefName_V12;
		BlockSource = BlockSource_V12;
		CopyDataToObject(block);
		return block;
	}
}
