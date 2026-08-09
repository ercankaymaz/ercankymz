namespace System.ServiceModel;

internal static class ServiceModelAttributeTargets
{
	public const AttributeTargets ServiceContract = AttributeTargets.Class | AttributeTargets.Interface;

	public const AttributeTargets OperationContract = AttributeTargets.Method;

	public const AttributeTargets MessageContract = AttributeTargets.Class | AttributeTargets.Struct;

	public const AttributeTargets MessageMember = AttributeTargets.Property | AttributeTargets.Field;

	public const AttributeTargets Parameter = AttributeTargets.Parameter | AttributeTargets.ReturnValue;

	public const AttributeTargets ServiceBehavior = AttributeTargets.Class;

	public const AttributeTargets CallbackBehavior = AttributeTargets.Class;

	public const AttributeTargets ClientBehavior = AttributeTargets.Interface;

	public const AttributeTargets ContractBehavior = AttributeTargets.Class | AttributeTargets.Interface;

	public const AttributeTargets OperationBehavior = AttributeTargets.Method;
}
