namespace devDept.Serialization.ODA;

internal sealed class HandleSurrogate : Surrogate<_0023_003Dztq44kFAgJ0opQGtZaex6wAI_003D>
{
	public long Value { get; set; }

	public HandleSurrogate(_0023_003Dztq44kFAgJ0opQGtZaex6wAI_003D handle)
		: base(handle)
	{
	}

	protected override _0023_003Dztq44kFAgJ0opQGtZaex6wAI_003D ConvertToObject()
	{
		return new _0023_003Dztq44kFAgJ0opQGtZaex6wAI_003D(Value);
	}

	protected override void CopyDataToObject(_0023_003Dztq44kFAgJ0opQGtZaex6wAI_003D obj)
	{
	}

	protected override void CopyDataFromObject(_0023_003Dztq44kFAgJ0opQGtZaex6wAI_003D handle)
	{
		Value = handle._0023_003Dz_AadRvc_003D();
	}

	public static implicit operator _0023_003Dztq44kFAgJ0opQGtZaex6wAI_003D(HandleSurrogate surrogate)
	{
		return surrogate.ConvertToObject();
	}

	public static implicit operator HandleSurrogate(_0023_003Dztq44kFAgJ0opQGtZaex6wAI_003D source)
	{
		return source?._0023_003Dz_0024xHo97pGU7zE();
	}
}
