namespace System.ServiceModel.Description;

internal interface IContractResolver
{
	ContractDescription ResolveContract(string contractName);
}
