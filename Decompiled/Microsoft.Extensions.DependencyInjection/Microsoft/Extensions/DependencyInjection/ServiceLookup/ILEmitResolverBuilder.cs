using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal sealed class ILEmitResolverBuilder : CallSiteVisitor<ILEmitResolverBuilderContext, Expression>
{
	private class ILEmitResolverBuilderRuntimeContext
	{
		public CallSiteRuntimeResolver RuntimeResolver;

		public IServiceScopeFactory ScopeFactory;

		public ServiceProviderEngineScope Root;

		public object[] Constants;

		public Func<IServiceProvider, object>[] Factories;
	}

	private static readonly MethodInfo ResolvedServicesGetter = typeof(ServiceProviderEngineScope).GetProperty("ResolvedServices", BindingFlags.Instance | BindingFlags.NonPublic).GetMethod;

	private static readonly FieldInfo RuntimeResolverField = typeof(ILEmitResolverBuilderRuntimeContext).GetField("RuntimeResolver");

	private static readonly FieldInfo RootField = typeof(ILEmitResolverBuilderRuntimeContext).GetField("Root");

	private static readonly FieldInfo FactoriesField = typeof(ILEmitResolverBuilderRuntimeContext).GetField("Factories");

	private static readonly FieldInfo ConstantsField = typeof(ILEmitResolverBuilderRuntimeContext).GetField("Constants");

	private readonly CallSiteRuntimeResolver _runtimeResolver;

	private readonly IServiceScopeFactory _serviceScopeFactory;

	private readonly ServiceProviderEngineScope _rootScope;

	public ILEmitResolverBuilder(CallSiteRuntimeResolver runtimeResolver, IServiceScopeFactory serviceScopeFactory, ServiceProviderEngineScope rootScope)
	{
		if (runtimeResolver == null)
		{
			throw new ArgumentNullException("runtimeResolver");
		}
		_runtimeResolver = runtimeResolver;
		_serviceScopeFactory = serviceScopeFactory;
		_rootScope = rootScope;
	}

	public Func<ServiceProviderEngineScope, object> Build(IServiceCallSite callSite)
	{
		if (callSite is SingletonCallSite singletonCallSite)
		{
			if (TryResolveSingletonValue(singletonCallSite, out var value))
			{
				return (ServiceProviderEngineScope scope) => value;
			}
			return (ServiceProviderEngineScope scope) => _runtimeResolver.Resolve(callSite, scope);
		}
		return BuildType(callSite);
	}

	protected override Expression VisitTransient(TransientCallSite transientCallSite, ILEmitResolverBuilderContext argument)
	{
		bool num = BeginCaptureDisposable(transientCallSite.ServiceCallSite.ImplementationType, argument);
		VisitCallSite(transientCallSite.ServiceCallSite, argument);
		if (num)
		{
			EndCaptureDisposable(argument);
		}
		return null;
	}

	protected override Expression VisitConstructor(ConstructorCallSite constructorCallSite, ILEmitResolverBuilderContext argument)
	{
		IServiceCallSite[] parameterCallSites = constructorCallSite.ParameterCallSites;
		foreach (IServiceCallSite callSite in parameterCallSites)
		{
			VisitCallSite(callSite, argument);
		}
		argument.Generator.Emit(OpCodes.Newobj, constructorCallSite.ConstructorInfo);
		return null;
	}

	protected override Expression VisitSingleton(SingletonCallSite singletonCallSite, ILEmitResolverBuilderContext argument)
	{
		if (TryResolveSingletonValue(singletonCallSite, out var value))
		{
			AddConstant(argument, value);
			return null;
		}
		argument.Generator.Emit(OpCodes.Ldarg_0);
		argument.Generator.Emit(OpCodes.Ldfld, RuntimeResolverField);
		AddConstant(argument, singletonCallSite);
		argument.Generator.Emit(OpCodes.Ldarg_0);
		argument.Generator.Emit(OpCodes.Ldfld, RootField);
		argument.Generator.Emit(OpCodes.Callvirt, ExpressionResolverBuilder.CallSiteRuntimeResolverResolve);
		return null;
	}

	protected override Expression VisitScoped(ScopedCallSite scopedCallSite, ILEmitResolverBuilderContext argument)
	{
		LocalBuilder localBuilder = argument.Generator.DeclareLocal(scopedCallSite.ServiceType);
		LocalBuilder localBuilder2 = argument.Generator.DeclareLocal(typeof(object));
		Label label = argument.Generator.DefineLabel();
		argument.Generator.Emit(OpCodes.Ldloc_0);
		AddConstant(argument, scopedCallSite.CacheKey);
		argument.Generator.Emit(OpCodes.Dup);
		Stloc(argument.Generator, localBuilder2.LocalIndex);
		argument.Generator.Emit(OpCodes.Ldloca, localBuilder.LocalIndex);
		argument.Generator.Emit(OpCodes.Callvirt, ExpressionResolverBuilder.TryGetValueMethodInfo);
		argument.Generator.Emit(OpCodes.Brtrue, label);
		bool num = BeginCaptureDisposable(scopedCallSite.ServiceCallSite.ImplementationType, argument);
		VisitCallSite(scopedCallSite.ServiceCallSite, argument);
		if (num)
		{
			EndCaptureDisposable(argument);
		}
		argument.Generator.Emit(OpCodes.Stloc, localBuilder.LocalIndex);
		argument.Generator.Emit(OpCodes.Ldloc_0);
		Ldloc(argument.Generator, localBuilder2.LocalIndex);
		Ldloc(argument.Generator, localBuilder.LocalIndex);
		argument.Generator.Emit(OpCodes.Callvirt, ExpressionResolverBuilder.AddMethodInfo);
		argument.Generator.MarkLabel(label);
		Ldloc(argument.Generator, localBuilder.LocalIndex);
		return null;
	}

	protected override Expression VisitConstant(ConstantCallSite constantCallSite, ILEmitResolverBuilderContext argument)
	{
		AddConstant(argument, constantCallSite.DefaultValue);
		return null;
	}

	protected override Expression VisitCreateInstance(CreateInstanceCallSite createInstanceCallSite, ILEmitResolverBuilderContext argument)
	{
		argument.Generator.Emit(OpCodes.Newobj, createInstanceCallSite.ImplementationType.GetConstructor(Type.EmptyTypes));
		return null;
	}

	protected override Expression VisitServiceProvider(ServiceProviderCallSite serviceProviderCallSite, ILEmitResolverBuilderContext argument)
	{
		argument.Generator.Emit(OpCodes.Ldarg_1);
		return null;
	}

	protected override Expression VisitServiceScopeFactory(ServiceScopeFactoryCallSite serviceScopeFactoryCallSite, ILEmitResolverBuilderContext argument)
	{
		argument.Generator.Emit(OpCodes.Ldarg_0);
		argument.Generator.Emit(OpCodes.Ldfld, typeof(ILEmitResolverBuilderRuntimeContext).GetField("ScopeFactory"));
		return null;
	}

	protected override Expression VisitIEnumerable(IEnumerableCallSite enumerableCallSite, ILEmitResolverBuilderContext argument)
	{
		if (enumerableCallSite.ServiceCallSites.Length == 0)
		{
			argument.Generator.Emit(OpCodes.Call, ExpressionResolverBuilder.ArrayEmptyMethodInfo.MakeGenericMethod(enumerableCallSite.ItemType));
		}
		else
		{
			argument.Generator.Emit(OpCodes.Ldc_I4, enumerableCallSite.ServiceCallSites.Length);
			argument.Generator.Emit(OpCodes.Newarr, enumerableCallSite.ItemType);
			for (int i = 0; i < enumerableCallSite.ServiceCallSites.Length; i++)
			{
				argument.Generator.Emit(OpCodes.Dup);
				argument.Generator.Emit(OpCodes.Ldc_I4, i);
				VisitCallSite(enumerableCallSite.ServiceCallSites[i], argument);
				argument.Generator.Emit(OpCodes.Stelem, enumerableCallSite.ItemType);
			}
		}
		return null;
	}

	protected override Expression VisitFactory(FactoryCallSite factoryCallSite, ILEmitResolverBuilderContext argument)
	{
		if (argument.Factories == null)
		{
			argument.Factories = new List<Func<IServiceProvider, object>>();
		}
		argument.Generator.Emit(OpCodes.Ldarg_0);
		argument.Generator.Emit(OpCodes.Ldfld, FactoriesField);
		argument.Generator.Emit(OpCodes.Ldc_I4, argument.Factories.Count);
		argument.Generator.Emit(OpCodes.Ldelem, typeof(Func<IServiceProvider, object>));
		argument.Generator.Emit(OpCodes.Ldarg_1);
		argument.Generator.Emit(OpCodes.Call, ExpressionResolverBuilder.InvokeFactoryMethodInfo);
		argument.Factories.Add(factoryCallSite.Factory);
		return null;
	}

	private void AddConstant(ILEmitResolverBuilderContext argument, object value)
	{
		if (argument.Constants == null)
		{
			argument.Constants = new List<object>();
		}
		argument.Generator.Emit(OpCodes.Ldarg_0);
		argument.Generator.Emit(OpCodes.Ldfld, ConstantsField);
		argument.Generator.Emit(OpCodes.Ldc_I4, argument.Constants.Count);
		argument.Generator.Emit(OpCodes.Ldelem, typeof(object));
		argument.Constants.Add(value);
	}

	private Func<ServiceProviderEngineScope, object> BuildType(IServiceCallSite callSite)
	{
		DynamicMethod dynamicMethod = new DynamicMethod("ResolveService", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, typeof(object), new Type[2]
		{
			typeof(ILEmitResolverBuilderRuntimeContext),
			typeof(ServiceProviderEngineScope)
		}, GetType(), skipVisibility: true);
		ILEmitCallSiteAnalysisResult info = ILEmitCallSiteAnalyzer.Instance.CollectGenerationInfo(callSite);
		ILEmitResolverBuilderRuntimeContext target = GenerateMethodBody(callSite, dynamicMethod.GetILGenerator(info.Size), info);
		return (Func<ServiceProviderEngineScope, object>)dynamicMethod.CreateDelegate(typeof(Func<ServiceProviderEngineScope, object>), target);
	}

	private ILEmitResolverBuilderRuntimeContext GenerateMethodBody(IServiceCallSite callSite, ILGenerator generator, ILEmitCallSiteAnalysisResult info)
	{
		ILEmitResolverBuilderContext iLEmitResolverBuilderContext = new ILEmitResolverBuilderContext
		{
			Generator = generator,
			Constants = null,
			Factories = null
		};
		bool hasScope = info.HasScope;
		if (hasScope)
		{
			iLEmitResolverBuilderContext.Generator.DeclareLocal(typeof(IDictionary<object, object>));
			iLEmitResolverBuilderContext.Generator.DeclareLocal(typeof(bool));
			iLEmitResolverBuilderContext.Generator.BeginExceptionBlock();
			iLEmitResolverBuilderContext.Generator.Emit(OpCodes.Ldarg_1);
			iLEmitResolverBuilderContext.Generator.Emit(OpCodes.Callvirt, ResolvedServicesGetter);
			iLEmitResolverBuilderContext.Generator.Emit(OpCodes.Dup);
			iLEmitResolverBuilderContext.Generator.Emit(OpCodes.Stloc_0);
			iLEmitResolverBuilderContext.Generator.Emit(OpCodes.Ldloca_S, 1);
			iLEmitResolverBuilderContext.Generator.Emit(OpCodes.Call, ExpressionResolverBuilder.MonitorEnterMethodInfo);
		}
		VisitCallSite(callSite, iLEmitResolverBuilderContext);
		if (hasScope)
		{
			LocalBuilder localBuilder = iLEmitResolverBuilderContext.Generator.DeclareLocal(typeof(object));
			Stloc(iLEmitResolverBuilderContext.Generator, localBuilder.LocalIndex);
			iLEmitResolverBuilderContext.Generator.BeginFinallyBlock();
			Label label = iLEmitResolverBuilderContext.Generator.DefineLabel();
			iLEmitResolverBuilderContext.Generator.Emit(OpCodes.Ldloc_1);
			iLEmitResolverBuilderContext.Generator.Emit(OpCodes.Brfalse, label);
			iLEmitResolverBuilderContext.Generator.Emit(OpCodes.Ldloc, 0);
			iLEmitResolverBuilderContext.Generator.Emit(OpCodes.Call, ExpressionResolverBuilder.MonitorExitMethodInfo);
			iLEmitResolverBuilderContext.Generator.MarkLabel(label);
			iLEmitResolverBuilderContext.Generator.EndExceptionBlock();
			Ldloc(iLEmitResolverBuilderContext.Generator, localBuilder.LocalIndex);
		}
		iLEmitResolverBuilderContext.Generator.Emit(OpCodes.Ret);
		return new ILEmitResolverBuilderRuntimeContext
		{
			Constants = iLEmitResolverBuilderContext.Constants?.ToArray(),
			Factories = iLEmitResolverBuilderContext.Factories?.ToArray(),
			Root = _rootScope,
			RuntimeResolver = _runtimeResolver,
			ScopeFactory = _serviceScopeFactory
		};
	}

	private bool TryResolveSingletonValue(SingletonCallSite singletonCallSite, out object value)
	{
		lock (_rootScope.ResolvedServices)
		{
			return _rootScope.ResolvedServices.TryGetValue(singletonCallSite.CacheKey, out value);
		}
	}

	private static bool BeginCaptureDisposable(Type implType, ILEmitResolverBuilderContext argument)
	{
		int num;
		if (!(implType == null))
		{
			num = (typeof(IDisposable).GetTypeInfo().IsAssignableFrom(implType.GetTypeInfo()) ? 1 : 0);
			if (num == 0)
			{
				goto IL_0039;
			}
		}
		else
		{
			num = 1;
		}
		argument.Generator.Emit(OpCodes.Ldarg_1);
		goto IL_0039;
		IL_0039:
		return (byte)num != 0;
	}

	private static void EndCaptureDisposable(ILEmitResolverBuilderContext argument)
	{
		argument.Generator.Emit(OpCodes.Callvirt, ExpressionResolverBuilder.CaptureDisposableMethodInfo);
	}

	private void Ldloc(ILGenerator generator, int index)
	{
		switch (index)
		{
		case 0:
			generator.Emit(OpCodes.Ldloc_0);
			return;
		case 1:
			generator.Emit(OpCodes.Ldloc_1);
			return;
		case 2:
			generator.Emit(OpCodes.Ldloc_2);
			return;
		case 3:
			generator.Emit(OpCodes.Ldloc_3);
			return;
		}
		if (index < 255)
		{
			generator.Emit(OpCodes.Ldloc_S, (byte)index);
		}
		else
		{
			generator.Emit(OpCodes.Ldloc, index);
		}
	}

	private void Stloc(ILGenerator generator, int index)
	{
		switch (index)
		{
		case 0:
			generator.Emit(OpCodes.Stloc_0);
			return;
		case 1:
			generator.Emit(OpCodes.Stloc_1);
			return;
		case 2:
			generator.Emit(OpCodes.Stloc_2);
			return;
		case 3:
			generator.Emit(OpCodes.Stloc_3);
			return;
		}
		if (index < 255)
		{
			generator.Emit(OpCodes.Stloc_S, (byte)index);
		}
		else
		{
			generator.Emit(OpCodes.Stloc, index);
		}
	}
}
