namespace ComponentFactory.Krypton.Toolkit;

internal class ShortTextValue : NullContentValues
{
	private string _shortText;

	public string ShortText
	{
		get
		{
			return _shortText;
		}
		set
		{
			_shortText = value;
		}
	}

	public override string GetShortText()
	{
		return _shortText;
	}
}
