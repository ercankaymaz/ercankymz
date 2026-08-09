namespace System.ServiceModel;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface, Inherited = false, AllowMultiple = false)]
public sealed class DataContractFormatAttribute : Attribute
{
	private OperationFormatStyle _style;

	public OperationFormatStyle Style
	{
		get
		{
			return _style;
		}
		set
		{
			XmlSerializerFormatAttribute.ValidateOperationFormatStyle(_style);
			_style = value;
		}
	}
}
