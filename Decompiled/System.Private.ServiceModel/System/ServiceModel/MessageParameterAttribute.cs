namespace System.ServiceModel;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue, Inherited = false)]
public sealed class MessageParameterAttribute : Attribute
{
	private string _name;

	internal const string NamePropertyName = "Name";

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			if (value == string.Empty)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", System.SR.SFxNameCannotBeEmpty));
			}
			_name = value;
			IsNameSetExplicit = true;
		}
	}

	internal bool IsNameSetExplicit { get; private set; }
}
