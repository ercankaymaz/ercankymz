namespace System.ServiceModel.Description;

public class MetadataConversionError
{
	private bool _isWarning;

	public string Message { get; }

	public bool IsWarning => _isWarning;

	public MetadataConversionError(string message)
		: this(message, isWarning: false)
	{
	}

	public MetadataConversionError(string message, bool isWarning)
	{
		Message = message ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
		_isWarning = isWarning;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is MetadataConversionError metadataConversionError))
		{
			return false;
		}
		if (metadataConversionError.IsWarning == IsWarning)
		{
			return metadataConversionError.Message == Message;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Message.GetHashCode();
	}
}
