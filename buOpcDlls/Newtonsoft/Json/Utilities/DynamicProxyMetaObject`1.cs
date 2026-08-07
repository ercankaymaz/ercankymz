// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.DynamicProxyMetaObject`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal sealed class DynamicProxyMetaObject<[Nullable(2)] T> : DynamicMetaObject
{
  private readonly DynamicProxy<T> _proxy;

  internal DynamicProxyMetaObject(Expression expression, T value, DynamicProxy<T> proxy)
    : base(expression, BindingRestrictions.Empty, (object) value)
  {
    this._proxy = proxy;
  }

  private bool IsOverridden(string method)
  {
    return ReflectionUtils.IsMethodOverridden(this._proxy.GetType(), typeof (DynamicProxy<T>), method);
  }

  public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
  {
    return !this.IsOverridden("TryGetMember") ? base.BindGetMember(binder) : this.CallMethodWithResult("TryGetMember", (DynamicMetaObjectBinder) binder, (IEnumerable<Expression>) DynamicProxyMetaObject<T>.NoArgs, (DynamicProxyMetaObject<T>.Fallback) (([Nullable(2)] e) => binder.FallbackGetMember((DynamicMetaObject) this, e)));
  }

  public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
  {
    if (!this.IsOverridden("TrySetMember"))
      return base.BindSetMember(binder, value);
    return this.CallMethodReturnLast("TrySetMember", (DynamicMetaObjectBinder) binder, DynamicProxyMetaObject<T>.GetArgs(value), (DynamicProxyMetaObject<T>.Fallback) (([Nullable(2)] e) => binder.FallbackSetMember((DynamicMetaObject) this, value, e)));
  }

  public override DynamicMetaObject BindDeleteMember(DeleteMemberBinder binder)
  {
    return !this.IsOverridden("TryDeleteMember") ? base.BindDeleteMember(binder) : this.CallMethodNoResult("TryDeleteMember", (DynamicMetaObjectBinder) binder, DynamicProxyMetaObject<T>.NoArgs, (DynamicProxyMetaObject<T>.Fallback) (([Nullable(2)] e) => binder.FallbackDeleteMember((DynamicMetaObject) this, e)));
  }

  public override DynamicMetaObject BindConvert(ConvertBinder binder)
  {
    return !this.IsOverridden("TryConvert") ? base.BindConvert(binder) : this.CallMethodWithResult("TryConvert", (DynamicMetaObjectBinder) binder, (IEnumerable<Expression>) DynamicProxyMetaObject<T>.NoArgs, (DynamicProxyMetaObject<T>.Fallback) (([Nullable(2)] e) => binder.FallbackConvert((DynamicMetaObject) this, e)));
  }

  public override DynamicMetaObject BindInvokeMember(
    InvokeMemberBinder binder,
    DynamicMetaObject[] args)
  {
    if (!this.IsOverridden("TryInvokeMember"))
      return base.BindInvokeMember(binder, args);
    DynamicProxyMetaObject<T>.Fallback fallback = (DynamicProxyMetaObject<T>.Fallback) (([Nullable(2)] e) => binder.FallbackInvokeMember((DynamicMetaObject) this, args, e));
    return this.BuildCallMethodWithResult("TryInvokeMember", (DynamicMetaObjectBinder) binder, (IEnumerable<Expression>) DynamicProxyMetaObject<T>.GetArgArray(args), this.BuildCallMethodWithResult("TryGetMember", (DynamicMetaObjectBinder) new DynamicProxyMetaObject<T>.GetBinderAdapter(binder), (IEnumerable<Expression>) DynamicProxyMetaObject<T>.NoArgs, fallback((DynamicMetaObject) null), (DynamicProxyMetaObject<T>.Fallback) (([Nullable(2)] e) => binder.FallbackInvoke(e, args, (DynamicMetaObject) null))), (DynamicProxyMetaObject<T>.Fallback) null);
  }

  public override DynamicMetaObject BindCreateInstance(
    CreateInstanceBinder binder,
    DynamicMetaObject[] args)
  {
    return !this.IsOverridden("TryCreateInstance") ? base.BindCreateInstance(binder, args) : this.CallMethodWithResult("TryCreateInstance", (DynamicMetaObjectBinder) binder, (IEnumerable<Expression>) DynamicProxyMetaObject<T>.GetArgArray(args), (DynamicProxyMetaObject<T>.Fallback) (([Nullable(2)] e) => binder.FallbackCreateInstance((DynamicMetaObject) this, args, e)));
  }

  public override DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args)
  {
    return !this.IsOverridden("TryInvoke") ? base.BindInvoke(binder, args) : this.CallMethodWithResult("TryInvoke", (DynamicMetaObjectBinder) binder, (IEnumerable<Expression>) DynamicProxyMetaObject<T>.GetArgArray(args), (DynamicProxyMetaObject<T>.Fallback) (([Nullable(2)] e) => binder.FallbackInvoke((DynamicMetaObject) this, args, e)));
  }

  public override DynamicMetaObject BindBinaryOperation(
    BinaryOperationBinder binder,
    DynamicMetaObject arg)
  {
    if (!this.IsOverridden("TryBinaryOperation"))
      return base.BindBinaryOperation(binder, arg);
    return this.CallMethodWithResult("TryBinaryOperation", (DynamicMetaObjectBinder) binder, DynamicProxyMetaObject<T>.GetArgs(arg), (DynamicProxyMetaObject<T>.Fallback) (([Nullable(2)] e) => binder.FallbackBinaryOperation((DynamicMetaObject) this, arg, e)));
  }

  public override DynamicMetaObject BindUnaryOperation(UnaryOperationBinder binder)
  {
    return !this.IsOverridden("TryUnaryOperation") ? base.BindUnaryOperation(binder) : this.CallMethodWithResult("TryUnaryOperation", (DynamicMetaObjectBinder) binder, (IEnumerable<Expression>) DynamicProxyMetaObject<T>.NoArgs, (DynamicProxyMetaObject<T>.Fallback) (([Nullable(2)] e) => binder.FallbackUnaryOperation((DynamicMetaObject) this, e)));
  }

  public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes)
  {
    return !this.IsOverridden("TryGetIndex") ? base.BindGetIndex(binder, indexes) : this.CallMethodWithResult("TryGetIndex", (DynamicMetaObjectBinder) binder, (IEnumerable<Expression>) DynamicProxyMetaObject<T>.GetArgArray(indexes), (DynamicProxyMetaObject<T>.Fallback) (([Nullable(2)] e) => binder.FallbackGetIndex((DynamicMetaObject) this, indexes, e)));
  }

  public override DynamicMetaObject BindSetIndex(
    SetIndexBinder binder,
    DynamicMetaObject[] indexes,
    DynamicMetaObject value)
  {
    return !this.IsOverridden("TrySetIndex") ? base.BindSetIndex(binder, indexes, value) : this.CallMethodReturnLast("TrySetIndex", (DynamicMetaObjectBinder) binder, (IEnumerable<Expression>) DynamicProxyMetaObject<T>.GetArgArray(indexes, value), (DynamicProxyMetaObject<T>.Fallback) (([Nullable(2)] e) => binder.FallbackSetIndex((DynamicMetaObject) this, indexes, value, e)));
  }

  public override DynamicMetaObject BindDeleteIndex(
    DeleteIndexBinder binder,
    DynamicMetaObject[] indexes)
  {
    return !this.IsOverridden("TryDeleteIndex") ? base.BindDeleteIndex(binder, indexes) : this.CallMethodNoResult("TryDeleteIndex", (DynamicMetaObjectBinder) binder, DynamicProxyMetaObject<T>.GetArgArray(indexes), (DynamicProxyMetaObject<T>.Fallback) (([Nullable(2)] e) => binder.FallbackDeleteIndex((DynamicMetaObject) this, indexes, e)));
  }

  private static Expression[] NoArgs => CollectionUtils.ArrayEmpty<Expression>();

  private static IEnumerable<Expression> GetArgs(params DynamicMetaObject[] args)
  {
    return ((IEnumerable<DynamicMetaObject>) args).Select<DynamicMetaObject, Expression>((Func<DynamicMetaObject, Expression>) ([NullableContext(0)] (arg) =>
    {
      Expression expression = arg.Expression;
      return !expression.Type.IsValueType() ? expression : (Expression) Expression.Convert(expression, typeof (object));
    }));
  }

  private static Expression[] GetArgArray(DynamicMetaObject[] args)
  {
    return (Expression[]) new NewArrayExpression[1]
    {
      Expression.NewArrayInit(typeof (object), DynamicProxyMetaObject<T>.GetArgs(args))
    };
  }

  private static Expression[] GetArgArray(DynamicMetaObject[] args, DynamicMetaObject value)
  {
    Expression expression = value.Expression;
    return new Expression[2]
    {
      (Expression) Expression.NewArrayInit(typeof (object), DynamicProxyMetaObject<T>.GetArgs(args)),
      expression.Type.IsValueType() ? (Expression) Expression.Convert(expression, typeof (object)) : expression
    };
  }

  private static ConstantExpression Constant(DynamicMetaObjectBinder binder)
  {
    Type type = binder.GetType();
    while (!type.IsVisible())
      type = type.BaseType();
    return Expression.Constant((object) binder, type);
  }

  private DynamicMetaObject CallMethodWithResult(
    string methodName,
    DynamicMetaObjectBinder binder,
    IEnumerable<Expression> args,
    [Nullable(new byte[] {1, 0})] DynamicProxyMetaObject<T>.Fallback fallback,
    [Nullable(new byte[] {2, 0})] DynamicProxyMetaObject<T>.Fallback fallbackInvoke = null)
  {
    DynamicMetaObject fallbackResult = fallback((DynamicMetaObject) null);
    return this.BuildCallMethodWithResult(methodName, binder, args, fallbackResult, fallbackInvoke);
  }

  private DynamicMetaObject BuildCallMethodWithResult(
    string methodName,
    DynamicMetaObjectBinder binder,
    IEnumerable<Expression> args,
    DynamicMetaObject fallbackResult,
    [Nullable(new byte[] {2, 0})] DynamicProxyMetaObject<T>.Fallback fallbackInvoke)
  {
    ParameterExpression parameterExpression = Expression.Parameter(typeof (object), (string) null);
    IList<Expression> expressionList = (IList<Expression>) new List<Expression>();
    expressionList.Add((Expression) Expression.Convert(this.Expression, typeof (T)));
    expressionList.Add((Expression) DynamicProxyMetaObject<T>.Constant(binder));
    expressionList.AddRange<Expression>(args);
    expressionList.Add((Expression) parameterExpression);
    DynamicMetaObject errorSuggestion = new DynamicMetaObject((Expression) parameterExpression, BindingRestrictions.Empty);
    if (binder.ReturnType != typeof (object))
      errorSuggestion = new DynamicMetaObject((Expression) Expression.Convert(errorSuggestion.Expression, binder.ReturnType), errorSuggestion.Restrictions);
    if (fallbackInvoke != null)
      errorSuggestion = fallbackInvoke(errorSuggestion);
    return new DynamicMetaObject((Expression) Expression.Block((IEnumerable<ParameterExpression>) new ParameterExpression[1]
    {
      parameterExpression
    }, (Expression) Expression.Condition((Expression) Expression.Call((Expression) Expression.Constant((object) this._proxy), typeof (DynamicProxy<T>).GetMethod(methodName), (IEnumerable<Expression>) expressionList), errorSuggestion.Expression, fallbackResult.Expression, binder.ReturnType)), this.GetRestrictions().Merge(errorSuggestion.Restrictions).Merge(fallbackResult.Restrictions));
  }

  private DynamicMetaObject CallMethodReturnLast(
    string methodName,
    DynamicMetaObjectBinder binder,
    IEnumerable<Expression> args,
    [Nullable(new byte[] {1, 0})] DynamicProxyMetaObject<T>.Fallback fallback)
  {
    DynamicMetaObject dynamicMetaObject = fallback((DynamicMetaObject) null);
    ParameterExpression parameterExpression = Expression.Parameter(typeof (object), (string) null);
    IList<Expression> expressionList = (IList<Expression>) new List<Expression>();
    expressionList.Add((Expression) Expression.Convert(this.Expression, typeof (T)));
    expressionList.Add((Expression) DynamicProxyMetaObject<T>.Constant(binder));
    expressionList.AddRange<Expression>(args);
    expressionList[expressionList.Count - 1] = (Expression) Expression.Assign((Expression) parameterExpression, expressionList[expressionList.Count - 1]);
    return new DynamicMetaObject((Expression) Expression.Block((IEnumerable<ParameterExpression>) new ParameterExpression[1]
    {
      parameterExpression
    }, (Expression) Expression.Condition((Expression) Expression.Call((Expression) Expression.Constant((object) this._proxy), typeof (DynamicProxy<T>).GetMethod(methodName), (IEnumerable<Expression>) expressionList), (Expression) parameterExpression, dynamicMetaObject.Expression, typeof (object))), this.GetRestrictions().Merge(dynamicMetaObject.Restrictions));
  }

  private DynamicMetaObject CallMethodNoResult(
    string methodName,
    DynamicMetaObjectBinder binder,
    Expression[] args,
    [Nullable(new byte[] {1, 0})] DynamicProxyMetaObject<T>.Fallback fallback)
  {
    DynamicMetaObject dynamicMetaObject = fallback((DynamicMetaObject) null);
    IList<Expression> expressionList = (IList<Expression>) new List<Expression>();
    expressionList.Add((Expression) Expression.Convert(this.Expression, typeof (T)));
    expressionList.Add((Expression) DynamicProxyMetaObject<T>.Constant(binder));
    expressionList.AddRange<Expression>((IEnumerable<Expression>) args);
    return new DynamicMetaObject((Expression) Expression.Condition((Expression) Expression.Call((Expression) Expression.Constant((object) this._proxy), typeof (DynamicProxy<T>).GetMethod(methodName), (IEnumerable<Expression>) expressionList), (Expression) Expression.Empty(), dynamicMetaObject.Expression, typeof (void)), this.GetRestrictions().Merge(dynamicMetaObject.Restrictions));
  }

  private BindingRestrictions GetRestrictions()
  {
    return this.Value == null && this.HasValue ? BindingRestrictions.GetInstanceRestriction(this.Expression, (object) null) : BindingRestrictions.GetTypeRestriction(this.Expression, this.LimitType);
  }

  public override IEnumerable<string> GetDynamicMemberNames()
  {
    return this._proxy.GetDynamicMemberNames((T) this.Value);
  }

  [NullableContext(0)]
  private delegate DynamicMetaObject Fallback([Nullable(2)] DynamicMetaObject errorSuggestion);

  [Nullable(0)]
  private sealed class GetBinderAdapter : GetMemberBinder
  {
    internal GetBinderAdapter(InvokeMemberBinder binder)
      : base(binder.Name, binder.IgnoreCase)
    {
    }

    public override DynamicMetaObject FallbackGetMember(
      DynamicMetaObject target,
      [Nullable(2)] DynamicMetaObject errorSuggestion)
    {
      throw new NotSupportedException();
    }
  }
}
