namespace System.IdentityModel;

internal interface IPrefixGenerator
{
	string GetPrefix(string namespaceUri, int depth, bool isForAttribute);
}
