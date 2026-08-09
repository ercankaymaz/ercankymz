using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;

namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal class ExpressionResolverBuilder : CallSiteVisitor<CallSiteExpressionBuilderContext, Expression>
{
	internal static readonly MethodInfo InvokeFactoryMethodInfo = GetMethodInfo<Action<Func<IServiceProvider, object>, IServiceProvider>>((Func<IServiceProvider, object> a, IServiceProvider b) => a(b));

	internal static readonly MethodInfo CaptureDisposableMethodInfo = GetMethodInfo<Func<ServiceProviderEngineScope, object, object>>((ServiceProviderEngineScope a, object b) => a.CaptureDisposable(b));

	internal static readonly MethodInfo TryGetValueMethodInfo = GetMethodInfo<Func<IDictionary<object, object>, object, object, bool>>((IDictionary<object, object> a, object b, object c) => a.TryGetValue(b, out c));

	internal static readonly MethodInfo AddMethodInfo = GetMethodInfo<Action<IDictionary<object, object>, object, object>>((IDictionary<object, object> a, object b, object c) => a.Add(b, c));

	internal static readonly MethodInfo MonitorEnterMethodInfo = GetMethodInfo<Action<object, bool>>((object lockObj, bool lockTaken) => Monitor.Enter(lockObj, ref lockTaken));

	internal static readonly MethodInfo MonitorExitMethodInfo = GetMethodInfo<Action<object>>((object lockObj) => Monitor.Exit(lockObj));

	internal static readonly MethodInfo CallSiteRuntimeResolverResolve = GetMethodInfo<Func<CallSiteRuntimeResolver, IServiceCallSite, ServiceProviderEngineScope, object>>((CallSiteRuntimeResolver r, IServiceCallSite c, ServiceProviderEngineScope p) => r.Resolve(c, p));

	internal static readonly MethodInfo ArrayEmptyMethodInfo = typeof(Array).GetMethod("Empty");

	private static readonly ParameterExpression ScopeParameter = Expression.Parameter(typeof(ServiceProviderEngineScope));

	private static readonly ParameterExpression ResolvedServices = Expression.Variable(typeof(IDictionary<object, object>), ScopeParameter.Name + "resolvedServices");

	private static readonly BinaryExpression ResolvedServicesVariableAssignment = Expression.Assign(ResolvedServices, Expression.Property(ScopeParameter, "ResolvedServices"));

	private static readonly ParameterExpression CaptureDisposableParameter = Expression.Parameter(typeof(object));

	private static readonly LambdaExpression CaptureDisposable = Expression.Lambda(Expression.Call(ScopeParameter, CaptureDisposableMethodInfo, CaptureDisposableParameter), CaptureDisposableParameter);

	private readonly CallSiteRuntimeResolver _runtimeResolver;

	private readonly IServiceScopeFactory _serviceScopeFactory;

	private readonly ServiceProviderEngineScope _rootScope;

	public ExpressionResolverBuilder(CallSiteRuntimeResolver runtimeResolver, IServiceScopeFactory serviceScopeFactory, ServiceProviderEngineScope rootScope)
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
		return BuildExpression(callSite).Compile();
	}

	private bool TryResolveSingletonValue(SingletonCallSite singletonCallSite, out object value)
	{
		lock (_rootScope.ResolvedServices)
		{
			return _rootScope.ResolvedServices.TryGetValue(singletonCallSite.CacheKey, out value);
		}
	}

	private Expression<Func<ServiceProviderEngineScope, object>> BuildExpression(IServiceCallSite callSite)
	{
		CallSiteExpressionBuilderContext callSiteExpressionBuilderContext = new CallSiteExpressionBuilderContext
		{
			ScopeParameter = ScopeParameter
		};
		Expression body = VisitCallSite(callSite, callSiteExpressionBuilderContext);
		if (callSiteExpressionBuilderContext.RequiresResolvedServices)
		{
			return Expression.Lambda<Func<ServiceProviderEngineScope, object>>(Expression.Block(new ParameterExpression[1] { ResolvedServices }, ResolvedServicesVariableAssignment, Lock(body, ResolvedServices)), new ParameterExpression[1] { ScopeParameter });
		}
		return Expression.Lambda<Func<ServiceProviderEngineScope, object>>(body, new ParameterExpression[1] { ScopeParameter });
	}

	protected override Expression VisitSingleton(SingletonCallSite singletonCallSite, CallSiteExpressionBuilderContext context)
	{
		if (TryResolveSingletonValue(singletonCallSite, out var value))
		{
			return Expression.Constant(value);
		}
		return Expression.Call(Expression.Constant(_runtimeResolver), CallSiteRuntimeResolverResolve, Expression.Constant(singletonCallSite, typeof(IServiceCallSite)), context.ScopeParameter);
	}

	protected override Expression VisitConstant(ConstantCallSite constantCallSite, CallSiteExpressionBuilderContext context)
	{
		return Expression.Constant(constantCallSite.DefaultValue);
	}

	protected override Expression VisitCreateInstance(CreateInstanceCallSite createInstanceCallSite, CallSiteExpressionBuilderContext context)
	{
		return Expression.New(createInstanceCallSite.ImplementationType);
	}

	protected override Expression VisitServiceProvider(ServiceProviderCallSite serviceProviderCallSite, CallSiteExpressionBuilderContext context)
	{
		return context.ScopeParameter;
	}

	protected override Expression VisitServiceScopeFactory(ServiceScopeFactoryCallSite serviceScopeFactoryCallSite, CallSiteExpressionBuilderContext context)
	{
		return Expression.Constant(_serviceScopeFactory);
	}

	protected override Expression VisitFactory(FactoryCallSite factoryCallSite, CallSiteExpressionBuilderContext context)
	{
		return Expression.Invoke(Expression.Constant(factoryCallSite.Factory), context.ScopeParameter);
	}

	protected override Expression VisitIEnumerable(IEnumerableCallSite callSite, CallSiteExpressionBuilderContext context)
	{
		if (callSite.ServiceCallSites.Length == 0)
		{
			return Expression.Constant(ArrayEmptyMethodInfo.MakeGenericMethod(callSite.ItemType).Invoke(null, Array.Empty<object>()));
		}
		return Expression.NewArrayInit(callSite.ItemType, callSite.ServiceCallSites.Select((IServiceCallSite cs) => Convert(VisitCallSite(cs, context), callSite.ItemType)));
	}

	protected override Expression VisitTransient(TransientCallSite callSite, CallSiteExpressionBuilderContext context)
	{
		Type implementationType = callSite.ServiceCallSite.ImplementationType;
		return TryCaptureDisposible(implementationType, context.ScopeParameter, VisitCallSite(callSite.ServiceCallSite, context));
	}

	private Expression TryCaptureDisposible(Type implType, ParameterExpression scope, Expression service)
	{
		if (implType != null && !typeof(IDisposable).GetTypeInfo().IsAssignableFrom(implType.GetTypeInfo()))
		{
			return service;
		}
		return Expression.Invoke(GetCaptureDisposable(scope), service);
	}

	protected override Expression VisitConstructor(ConstructorCallSite callSite, CallSiteExpressionBuilderContext context)
	{
		ParameterInfo[] parameters = callSite.ConstructorInfo.GetParameters();
		Expression[] array = new Expression[callSite.ParameterCallSites.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Convert(VisitCallSite(callSite.ParameterCallSites[i], context), parameters[i].ParameterType);
		}
		return Expression.New(callSite.ConstructorInfo, array);
	}

	private static Expression Convert(Expression expression, Type type)
	{
		if (type.GetTypeInfo().IsAssignableFrom(expression.Type.GetTypeInfo()))
		{
			return expression;
		}
		return Expression.Convert(expression, type);
	}

	protected override Expression VisitScoped(ScopedCallSite callSite, CallSiteExpressionBuilderContext context)
	{
		return BuildScopedExpression(callSite, context, VisitCallSite(callSite.ServiceCallSite, context));
	}

	private Expression BuildScopedExpression(ScopedCallSite callSite, CallSiteExpressionBuilderContext context, Expression service)
	{
		ConstantExpression arg = Expression.Constant(callSite.CacheKey, typeof(object));
		ParameterExpression parameterExpression = Expression.Variable(typeof(object), "resolved");
		Expression resolvedServices = GetResolvedServices(context);
		MethodCallExpression expression = Expression.Call(resolvedServices, TryGetValueMethodInfo, arg, parameterExpression);
		Expression right = TryCaptureDisposible(callSite.ImplementationType, context.ScopeParameter, service);
		BinaryExpression arg2 = Expression.Assign(parameterExpression, right);
		MethodCallExpression arg3 = Expression.Call(resolvedServices, AddMethodInfo, arg, parameterExpression);
		return Expression.Block(typeof(object), new ParameterExpression[1] { parameterExpression }, Expression.IfThen(Expression.Not(expression), Expression.Block(arg2, arg3)), parameterExpression);
	}

	private static MethodInfo GetMethodInfo<T>(Expression<T> expr)
	{
		return ((MethodCallExpression)expr.Body).Method;
	}

	public Expression GetCaptureDisposable(ParameterExpression scope)
	{
		if (scope != ScopeParameter)
		{
			throw new NotSupportedException("GetCaptureDisposable call is supported only for main scope");
		}
		return CaptureDisposable;
	}

	public Expression GetResolvedServices(CallSiteExpressionBuilderContext context)
	{
		if (context.ScopeParameter != ScopeParameter)
		{
			throw new NotSupportedException("GetResolvedServices call is supported only for main scope");
		}
		context.RequiresResolvedServices = true;
		return ResolvedServices;
	}

	private static Expression Lock(Expression body, Expression syncVariable)
	{
		ParameterExpression parameterExpression = Expression.Variable(typeof(bool), "lockWasTaken");
		MethodCallExpression arg = Expression.Call(MonitorEnterMethodInfo, syncVariable, parameterExpression);
		MethodCallExpression ifTrue = Expression.Call(MonitorExitMethodInfo, syncVariable);
		BlockExpression body2 = Expression.Block(arg, body);
		ConditionalExpression conditionalExpression = Expression.IfThen(parameterExpression, ifTrue);
		return Expression.Block(typeof(object), new ParameterExpression[1] { parameterExpression }, Expression.TryFinally(body2, conditionalExpression));
	}
}
