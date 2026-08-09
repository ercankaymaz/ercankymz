namespace System.ServiceModel;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false)]
public sealed class MessagePropertyAttribute : Attribute
{
	private string _name;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			IsNameSetExplicit = true;
			_name = value;
		}
	}

	internal bool IsNameSetExplicit { get; private set; }
}
