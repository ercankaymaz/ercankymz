namespace UglyToad.PdfPig.Encryption;

internal class CryptDictionary
{
	public enum Method
	{
		None,
		V2,
		AesV2,
		AesV3
	}

	public enum TriggerEvent
	{
		DocumentOpen,
		EmbeddedFileOpen
	}

	public static CryptDictionary Identity { get; } = new CryptDictionary();

	public Method Name { get; }

	public TriggerEvent Event { get; }

	public int Length { get; }

	public bool IsIdentity { get; }

	public CryptDictionary(Method name, TriggerEvent @event, int length)
	{
		Name = name;
		Event = @event;
		Length = length;
		IsIdentity = false;
	}

	private CryptDictionary()
	{
		Name = Method.None;
		IsIdentity = true;
	}
}
