namespace Microsoft.Extensions.DependencyInjection;

internal enum ServiceProviderMode
{
	Dynamic,
	Runtime,
	Expressions,
	ILEmit
}
