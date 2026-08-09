namespace devDept.Serialization.ODA;

internal sealed class OdDbHandleSurrogate : Surrogate<_0023_003DzW6hL6bTkwK95EYu4adlJ5IGajobP>
{
	public string Value { get; set; }

	public OdDbHandleSurrogate(_0023_003DzW6hL6bTkwK95EYu4adlJ5IGajobP OdDbHandle)
		: base(OdDbHandle)
	{
	}

	protected override _0023_003DzW6hL6bTkwK95EYu4adlJ5IGajobP ConvertToObject()
	{
		return new _0023_003DzW6hL6bTkwK95EYu4adlJ5IGajobP(Value);
	}

	protected override void CopyDataToObject(_0023_003DzW6hL6bTkwK95EYu4adlJ5IGajobP obj)
	{
	}

	protected override void CopyDataFromObject(_0023_003DzW6hL6bTkwK95EYu4adlJ5IGajobP OdDbHandle)
	{
		Value = OdDbHandle._0023_003Dz_AadRvc_003D();
	}

	public static implicit operator _0023_003DzW6hL6bTkwK95EYu4adlJ5IGajobP(OdDbHandleSurrogate surrogate)
	{
		return surrogate.ConvertToObject();
	}

	public static implicit operator OdDbHandleSurrogate(_0023_003DzW6hL6bTkwK95EYu4adlJ5IGajobP source)
	{
		return source?._0023_003Dz_0024xHo97pGU7zE();
	}
}
