namespace System.ServiceModel;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false)]
public class MessageBodyMemberAttribute : MessageContractMemberAttribute
{
	private int _order = -1;

	internal const string OrderPropertyName = "Order";

	public int Order
	{
		get
		{
			return _order;
		}
		set
		{
			if (value < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.ValueMustBeNonNegative));
			}
			_order = value;
		}
	}
}
