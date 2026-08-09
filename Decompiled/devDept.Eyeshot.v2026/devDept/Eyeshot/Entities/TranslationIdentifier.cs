using System;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class TranslationIdentifier
{
	public ulong Index { get; }

	public string Name { get; set; }

	internal TranslationIdentifier(ulong _0023_003DzyzK8swU_003D, string _0023_003DzS_00246o7tc_003D)
	{
		Index = _0023_003DzyzK8swU_003D;
		Name = _0023_003DzS_00246o7tc_003D;
	}

	internal TranslationIdentifier(int _0023_003DzyzK8swU_003D, string _0023_003DzS_00246o7tc_003D)
	{
		Index = (ulong)_0023_003DzyzK8swU_003D;
		Name = _0023_003DzS_00246o7tc_003D;
	}

	internal TranslationIdentifier(ulong _0023_003DzyzK8swU_003D)
	{
		Index = _0023_003DzyzK8swU_003D;
	}

	internal TranslationIdentifier(long _0023_003DzyzK8swU_003D)
	{
		Index = (ulong)_0023_003DzyzK8swU_003D;
	}

	internal TranslationIdentifier(int _0023_003DzyzK8swU_003D)
	{
		Index = (ulong)_0023_003DzyzK8swU_003D;
	}

	public TranslationIdentifier(string name)
	{
		Name = name;
	}

	protected TranslationIdentifier(TranslationIdentifier other)
	{
		Index = other.Index;
		Name = other.Name;
	}

	public object Clone()
	{
		return new TranslationIdentifier(Index, Name);
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982525), Index, Name);
	}
}
