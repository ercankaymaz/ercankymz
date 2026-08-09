namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal sealed class ILEmitCallSiteAnalyzer : CallSiteVisitor<object, ILEmitCallSiteAnalysisResult>
{
	private const int ConstructorILSize = 6;

	private const int ScopedILSize = 64;

	private const int ConstantILSize = 4;

	private const int ServiceProviderSize = 1;

	private const int FactoryILSize = 16;

	internal static ILEmitCallSiteAnalyzer Instance { get; } = new ILEmitCallSiteAnalyzer();

	protected override ILEmitCallSiteAnalysisResult VisitTransient(TransientCallSite transientCallSite, object argument)
	{
		return VisitCallSite(transientCallSite.ServiceCallSite, argument);
	}

	protected override ILEmitCallSiteAnalysisResult VisitConstructor(ConstructorCallSite constructorCallSite, object argument)
	{
		ILEmitCallSiteAnalysisResult result = new ILEmitCallSiteAnalysisResult(6);
		IServiceCallSite[] parameterCallSites = constructorCallSite.ParameterCallSites;
		foreach (IServiceCallSite callSite in parameterCallSites)
		{
			result = result.Add(VisitCallSite(callSite, argument));
		}
		return result;
	}

	protected override ILEmitCallSiteAnalysisResult VisitSingleton(SingletonCallSite singletonCallSite, object argument)
	{
		return VisitCallSite(singletonCallSite.ServiceCallSite, argument);
	}

	protected override ILEmitCallSiteAnalysisResult VisitScoped(ScopedCallSite scopedCallSite, object argument)
	{
		return new ILEmitCallSiteAnalysisResult(64, hasScope: true).Add(VisitCallSite(scopedCallSite.ServiceCallSite, argument));
	}

	protected override ILEmitCallSiteAnalysisResult VisitConstant(ConstantCallSite constantCallSite, object argument)
	{
		return new ILEmitCallSiteAnalysisResult(4);
	}

	protected override ILEmitCallSiteAnalysisResult VisitCreateInstance(CreateInstanceCallSite createInstanceCallSite, object argument)
	{
		return new ILEmitCallSiteAnalysisResult(6);
	}

	protected override ILEmitCallSiteAnalysisResult VisitServiceProvider(ServiceProviderCallSite serviceProviderCallSite, object argument)
	{
		return new ILEmitCallSiteAnalysisResult(1);
	}

	protected override ILEmitCallSiteAnalysisResult VisitServiceScopeFactory(ServiceScopeFactoryCallSite serviceScopeFactoryCallSite, object argument)
	{
		return new ILEmitCallSiteAnalysisResult(4);
	}

	protected override ILEmitCallSiteAnalysisResult VisitIEnumerable(IEnumerableCallSite enumerableCallSite, object argument)
	{
		ILEmitCallSiteAnalysisResult result = new ILEmitCallSiteAnalysisResult(6);
		IServiceCallSite[] serviceCallSites = enumerableCallSite.ServiceCallSites;
		foreach (IServiceCallSite callSite in serviceCallSites)
		{
			result = result.Add(VisitCallSite(callSite, argument));
		}
		return result;
	}

	protected override ILEmitCallSiteAnalysisResult VisitFactory(FactoryCallSite factoryCallSite, object argument)
	{
		return new ILEmitCallSiteAnalysisResult(16);
	}

	public ILEmitCallSiteAnalysisResult CollectGenerationInfo(IServiceCallSite callSite)
	{
		return VisitCallSite(callSite, null);
	}
}
