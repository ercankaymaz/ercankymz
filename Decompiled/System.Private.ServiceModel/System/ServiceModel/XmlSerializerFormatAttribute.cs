namespace System.ServiceModel;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface, Inherited = false, AllowMultiple = false)]
public sealed class XmlSerializerFormatAttribute : Attribute
{
	private OperationFormatStyle _style;

	private bool _isStyleSet;

	private OperationFormatUse _use;

	public bool SupportFaults { get; set; }

	public OperationFormatStyle Style
	{
		get
		{
			return _style;
		}
		set
		{
			ValidateOperationFormatStyle(value);
			_style = value;
			_isStyleSet = true;
		}
	}

	public OperationFormatUse Use
	{
		get
		{
			return _use;
		}
		set
		{
			ValidateOperationFormatUse(value);
			_use = value;
			if (!_isStyleSet && IsEncoded)
			{
				Style = OperationFormatStyle.Rpc;
			}
		}
	}

	internal bool IsEncoded
	{
		get
		{
			return _use == OperationFormatUse.Encoded;
		}
		set
		{
			_use = (value ? OperationFormatUse.Encoded : OperationFormatUse.Literal);
		}
	}

	internal static void ValidateOperationFormatStyle(OperationFormatStyle value)
	{
		if (!OperationFormatStyleHelper.IsDefined(value))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
		}
	}

	internal static void ValidateOperationFormatUse(OperationFormatUse value)
	{
		if (!OperationFormatUseHelper.IsDefined(value))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
		}
	}
}
