// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.HttpHandlerDiagnosticListener
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

#nullable disable
namespace System.Diagnostics;

internal sealed class HttpHandlerDiagnosticListener : DiagnosticListener
{
  internal static HttpHandlerDiagnosticListener s_instance = new HttpHandlerDiagnosticListener();
  private const string DiagnosticListenerName = "System.Net.Http.Desktop";
  private const string ActivityName = "System.Net.Http.Desktop.HttpRequestOut";
  private const string RequestStartName = "System.Net.Http.Desktop.HttpRequestOut.Start";
  private const string RequestStopName = "System.Net.Http.Desktop.HttpRequestOut.Stop";
  private const string RequestStopExName = "System.Net.Http.Desktop.HttpRequestOut.Ex.Stop";
  private const string InitializationFailed = "System.Net.Http.InitializationFailed";
  private const string RequestIdHeaderName = "Request-Id";
  private const string CorrelationContextHeaderName = "Correlation-Context";
  private const string TraceParentHeaderName = "traceparent";
  private const string TraceStateHeaderName = "tracestate";
  private bool initialized;
  private static FieldInfo s_connectionGroupListField;
  private static Type s_connectionGroupType;
  private static FieldInfo s_connectionListField;
  private static Type s_connectionType;
  private static FieldInfo s_writeListField;
  private static Func<HttpWebRequest, HttpWebResponse> s_httpResponseAccessor;
  private static Func<HttpWebRequest, int> s_autoRedirectsAccessor;
  private static Func<HttpWebRequest, object> s_coreResponseAccessor;
  private static Func<object, HttpStatusCode> s_coreStatusCodeAccessor;
  private static Func<object, WebHeaderCollection> s_coreHeadersAccessor;
  private static Type s_coreResponseDataType;

  public override IDisposable Subscribe(
    IObserver<KeyValuePair<string, object>> observer,
    Predicate<string> isEnabled)
  {
    IDisposable disposable = base.Subscribe(observer, isEnabled);
    this.Initialize();
    return disposable;
  }

  public override IDisposable Subscribe(
    IObserver<KeyValuePair<string, object>> observer,
    Func<string, object, object, bool> isEnabled)
  {
    IDisposable disposable = base.Subscribe(observer, isEnabled);
    this.Initialize();
    return disposable;
  }

  public override IDisposable Subscribe(IObserver<KeyValuePair<string, object>> observer)
  {
    IDisposable disposable = base.Subscribe(observer);
    this.Initialize();
    return disposable;
  }

  private void Initialize()
  {
    lock (this)
    {
      if (this.initialized)
        return;
      try
      {
        this.initialized = true;
        HttpHandlerDiagnosticListener.PrepareReflectionObjects();
        HttpHandlerDiagnosticListener.PerformInjection();
      }
      catch (Exception ex)
      {
        this.Write("System.Net.Http.InitializationFailed", (object) new
        {
          Exception = ex
        });
      }
    }
  }

  private HttpHandlerDiagnosticListener()
    : base("System.Net.Http.Desktop")
  {
  }

  private void RaiseRequestEvent(HttpWebRequest request)
  {
    if (request.Headers.Get("Request-Id") != null || !this.IsEnabled("System.Net.Http.Desktop.HttpRequestOut", (object) request, (object) null))
      return;
    Activity activity = new Activity("System.Net.Http.Desktop.HttpRequestOut");
    if (this.IsEnabled("System.Net.Http.Desktop.HttpRequestOut.Start"))
      this.StartActivity(activity, (object) new
      {
        Request = request
      });
    else
      activity.Start();
    if (activity.IdFormat == ActivityIdFormat.W3C)
    {
      if (request.Headers.Get("traceparent") == null)
      {
        request.Headers.Add("traceparent", activity.Id);
        string traceStateString = activity.TraceStateString;
        if (traceStateString != null)
          request.Headers.Add("tracestate", traceStateString);
      }
    }
    else if (request.Headers.Get("Request-Id") == null)
      request.Headers.Add("Request-Id", activity.Id);
    if (request.Headers.Get("Correlation-Context") == null)
    {
      using (IEnumerator<KeyValuePair<string, string>> enumerator = activity.Baggage.GetEnumerator())
      {
        if (enumerator.MoveNext())
        {
          StringBuilder stringBuilder = new StringBuilder();
          do
          {
            KeyValuePair<string, string> current = enumerator.Current;
            stringBuilder.Append(WebUtility.UrlEncode(current.Key)).Append('=').Append(WebUtility.UrlEncode(current.Value)).Append(',');
          }
          while (enumerator.MoveNext());
          stringBuilder.Remove(stringBuilder.Length - 1, 1);
          request.Headers.Add("Correlation-Context", stringBuilder.ToString());
        }
      }
    }
    activity.Stop();
  }

  private void RaiseResponseEvent(HttpWebRequest request, HttpWebResponse response)
  {
    if ((request.Headers.Get("traceparent") != null ? 1 : (request.Headers.Get("Request-Id") != null ? 1 : 0)) == 0 || !this.IsLastResponse(request, response.StatusCode))
      return;
    this.Write("System.Net.Http.Desktop.HttpRequestOut.Stop", (object) new
    {
      Request = request,
      Response = response
    });
  }

  private void RaiseResponseEvent(
    HttpWebRequest request,
    HttpStatusCode statusCode,
    WebHeaderCollection headers)
  {
    if (request.Headers.Get("Request-Id") == null || !this.IsLastResponse(request, statusCode))
      return;
    this.Write("System.Net.Http.Desktop.HttpRequestOut.Ex.Stop", (object) new
    {
      Request = request,
      StatusCode = statusCode,
      Headers = headers
    });
  }

  private bool IsLastResponse(HttpWebRequest request, HttpStatusCode statusCode)
  {
    return !request.AllowAutoRedirect || statusCode != HttpStatusCode.MultipleChoices && statusCode != HttpStatusCode.MovedPermanently && statusCode != HttpStatusCode.Found && statusCode != HttpStatusCode.SeeOther && statusCode != HttpStatusCode.TemporaryRedirect && statusCode != (HttpStatusCode) 308 || HttpHandlerDiagnosticListener.s_autoRedirectsAccessor(request) >= request.MaximumAutomaticRedirections;
  }

  private static void PrepareReflectionObjects()
  {
    Assembly assembly = typeof (ServicePoint).Assembly;
    HttpHandlerDiagnosticListener.s_connectionGroupListField = typeof (ServicePoint).GetField("m_ConnectionGroupList", BindingFlags.Instance | BindingFlags.NonPublic);
    HttpHandlerDiagnosticListener.s_connectionGroupType = assembly?.GetType("System.Net.ConnectionGroup");
    HttpHandlerDiagnosticListener.s_connectionListField = HttpHandlerDiagnosticListener.s_connectionGroupType?.GetField("m_ConnectionList", BindingFlags.Instance | BindingFlags.NonPublic);
    HttpHandlerDiagnosticListener.s_connectionType = assembly?.GetType("System.Net.Connection");
    HttpHandlerDiagnosticListener.s_writeListField = HttpHandlerDiagnosticListener.s_connectionType?.GetField("m_WriteList", BindingFlags.Instance | BindingFlags.NonPublic);
    HttpHandlerDiagnosticListener.s_httpResponseAccessor = HttpHandlerDiagnosticListener.CreateFieldGetter<HttpWebRequest, HttpWebResponse>("_HttpResponse", BindingFlags.Instance | BindingFlags.NonPublic);
    HttpHandlerDiagnosticListener.s_autoRedirectsAccessor = HttpHandlerDiagnosticListener.CreateFieldGetter<HttpWebRequest, int>("_AutoRedirects", BindingFlags.Instance | BindingFlags.NonPublic);
    HttpHandlerDiagnosticListener.s_coreResponseAccessor = HttpHandlerDiagnosticListener.CreateFieldGetter<HttpWebRequest, object>("_CoreResponse", BindingFlags.Instance | BindingFlags.NonPublic);
    HttpHandlerDiagnosticListener.s_coreResponseDataType = assembly?.GetType("System.Net.CoreResponseData");
    if (HttpHandlerDiagnosticListener.s_coreResponseDataType != (Type) null)
    {
      HttpHandlerDiagnosticListener.s_coreStatusCodeAccessor = HttpHandlerDiagnosticListener.CreateFieldGetter<HttpStatusCode>(HttpHandlerDiagnosticListener.s_coreResponseDataType, "m_StatusCode", BindingFlags.Instance | BindingFlags.Public);
      HttpHandlerDiagnosticListener.s_coreHeadersAccessor = HttpHandlerDiagnosticListener.CreateFieldGetter<WebHeaderCollection>(HttpHandlerDiagnosticListener.s_coreResponseDataType, "m_ResponseHeaders", BindingFlags.Instance | BindingFlags.Public);
    }
    if (HttpHandlerDiagnosticListener.s_connectionGroupListField == (FieldInfo) null || HttpHandlerDiagnosticListener.s_connectionGroupType == (Type) null || HttpHandlerDiagnosticListener.s_connectionListField == (FieldInfo) null || HttpHandlerDiagnosticListener.s_connectionType == (Type) null || HttpHandlerDiagnosticListener.s_writeListField == (FieldInfo) null || HttpHandlerDiagnosticListener.s_httpResponseAccessor == null || HttpHandlerDiagnosticListener.s_autoRedirectsAccessor == null || HttpHandlerDiagnosticListener.s_coreResponseDataType == (Type) null || HttpHandlerDiagnosticListener.s_coreStatusCodeAccessor == null || HttpHandlerDiagnosticListener.s_coreHeadersAccessor == null)
      throw new InvalidOperationException(System.System.Diagnostics.DiagnosticSource3462135.SR.UnableToInitialize);
  }

  private static void PerformInjection()
  {
    FieldInfo field = typeof (ServicePointManager).GetField("s_ServicePointTable", BindingFlags.Static | BindingFlags.NonPublic);
    if (field == (FieldInfo) null)
      throw new InvalidOperationException(System.System.Diagnostics.DiagnosticSource3462135.SR.UnableAccessServicePointTable);
    if (!(field.GetValue((object) null) is Hashtable table))
      table = new Hashtable();
    HttpHandlerDiagnosticListener.ServicePointHashtable servicePointHashtable = new HttpHandlerDiagnosticListener.ServicePointHashtable(table);
    field.SetValue((object) null, (object) servicePointHashtable);
  }

  private static Func<TClass, TField> CreateFieldGetter<TClass, TField>(
    string fieldName,
    BindingFlags flags)
    where TClass : class
  {
    FieldInfo field = typeof (TClass).GetField(fieldName, flags);
    if (!(field != (FieldInfo) null))
      return (Func<TClass, TField>) null;
    DynamicMethod dynamicMethod = new DynamicMethod($"{field.ReflectedType.FullName}.get_{field.Name}", typeof (TField), new Type[1]
    {
      typeof (TClass)
    }, true);
    ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
    ilGenerator.Emit(OpCodes.Ldarg_0);
    ilGenerator.Emit(OpCodes.Ldfld, field);
    ilGenerator.Emit(OpCodes.Ret);
    return (Func<TClass, TField>) dynamicMethod.CreateDelegate(typeof (Func<TClass, TField>));
  }

  private static Func<object, TField> CreateFieldGetter<TField>(
    Type classType,
    string fieldName,
    BindingFlags flags)
  {
    FieldInfo field = classType.GetField(fieldName, flags);
    if (!(field != (FieldInfo) null))
      return (Func<object, TField>) null;
    DynamicMethod dynamicMethod = new DynamicMethod($"{classType.FullName}.get_{field.Name}", typeof (TField), new Type[1]
    {
      typeof (object)
    }, true);
    ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
    ilGenerator.Emit(OpCodes.Ldarg_0);
    ilGenerator.Emit(OpCodes.Castclass, classType);
    ilGenerator.Emit(OpCodes.Ldfld, field);
    ilGenerator.Emit(OpCodes.Ret);
    return (Func<object, TField>) dynamicMethod.CreateDelegate(typeof (Func<object, TField>));
  }

  private class HashtableWrapper : Hashtable, IEnumerable
  {
    protected Hashtable _table;

    public override int Count => this._table.Count;

    public override bool IsReadOnly => this._table.IsReadOnly;

    public override bool IsFixedSize => this._table.IsFixedSize;

    public override bool IsSynchronized => this._table.IsSynchronized;

    public override object this[object key]
    {
      get => this._table[key];
      set => this._table[key] = value;
    }

    public override object SyncRoot => this._table.SyncRoot;

    public override ICollection Keys => this._table.Keys;

    public override ICollection Values => this._table.Values;

    internal HashtableWrapper(Hashtable table) => this._table = table;

    public override void Add(object key, object value) => this._table.Add(key, value);

    public override void Clear() => this._table.Clear();

    public override bool Contains(object key) => this._table.Contains(key);

    public override bool ContainsKey(object key) => this._table.ContainsKey(key);

    public override bool ContainsValue(object key) => this._table.ContainsValue(key);

    public override void CopyTo(Array array, int arrayIndex)
    {
      this._table.CopyTo(array, arrayIndex);
    }

    public override object Clone()
    {
      return (object) new HttpHandlerDiagnosticListener.HashtableWrapper((Hashtable) this._table.Clone());
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this._table.GetEnumerator();

    public override IDictionaryEnumerator GetEnumerator() => this._table.GetEnumerator();

    public override void Remove(object key) => this._table.Remove(key);
  }

  private sealed class ServicePointHashtable(Hashtable table) : 
    HttpHandlerDiagnosticListener.HashtableWrapper(table)
  {
    public override object this[object key]
    {
      get => base[key];
      set
      {
        if (value is WeakReference weakReference && weakReference.IsAlive && weakReference.Target is ServicePoint target)
        {
          if (!(HttpHandlerDiagnosticListener.s_connectionGroupListField.GetValue((object) target) is Hashtable table))
            table = new Hashtable();
          HttpHandlerDiagnosticListener.ConnectionGroupHashtable connectionGroupHashtable = new HttpHandlerDiagnosticListener.ConnectionGroupHashtable(table);
          HttpHandlerDiagnosticListener.s_connectionGroupListField.SetValue((object) target, (object) connectionGroupHashtable);
        }
        base[key] = value;
      }
    }
  }

  private sealed class ConnectionGroupHashtable(Hashtable table) : 
    HttpHandlerDiagnosticListener.HashtableWrapper(table)
  {
    public override object this[object key]
    {
      get => base[key];
      set
      {
        if (HttpHandlerDiagnosticListener.s_connectionGroupType.IsInstanceOfType(value))
        {
          if (!(HttpHandlerDiagnosticListener.s_connectionListField.GetValue(value) is ArrayList list))
            list = new ArrayList();
          HttpHandlerDiagnosticListener.ConnectionArrayList connectionArrayList = new HttpHandlerDiagnosticListener.ConnectionArrayList(list);
          HttpHandlerDiagnosticListener.s_connectionListField.SetValue(value, (object) connectionArrayList);
        }
        base[key] = value;
      }
    }
  }

  private class ArrayListWrapper : ArrayList
  {
    private ArrayList _list;

    public override int Capacity
    {
      get => this._list.Capacity;
      set => this._list.Capacity = value;
    }

    public override int Count => this._list.Count;

    public override bool IsReadOnly => this._list.IsReadOnly;

    public override bool IsFixedSize => this._list.IsFixedSize;

    public override bool IsSynchronized => this._list.IsSynchronized;

    public override object this[int index]
    {
      get => this._list[index];
      set => this._list[index] = value;
    }

    public override object SyncRoot => this._list.SyncRoot;

    internal ArrayListWrapper(ArrayList list) => this._list = list;

    public override int Add(object value) => this._list.Add(value);

    public override void AddRange(ICollection c) => this._list.AddRange(c);

    public override int BinarySearch(object value) => this._list.BinarySearch(value);

    public override int BinarySearch(object value, IComparer comparer)
    {
      return this._list.BinarySearch(value, comparer);
    }

    public override int BinarySearch(int index, int count, object value, IComparer comparer)
    {
      return this._list.BinarySearch(index, count, value, comparer);
    }

    public override void Clear() => this._list.Clear();

    public override object Clone()
    {
      return (object) new HttpHandlerDiagnosticListener.ArrayListWrapper((ArrayList) this._list.Clone());
    }

    public override bool Contains(object item) => this._list.Contains(item);

    public override void CopyTo(Array array) => this._list.CopyTo(array);

    public override void CopyTo(Array array, int index) => this._list.CopyTo(array, index);

    public override void CopyTo(int index, Array array, int arrayIndex, int count)
    {
      this._list.CopyTo(index, array, arrayIndex, count);
    }

    public override IEnumerator GetEnumerator() => this._list.GetEnumerator();

    public override IEnumerator GetEnumerator(int index, int count)
    {
      return this._list.GetEnumerator(index, count);
    }

    public override int IndexOf(object value) => this._list.IndexOf(value);

    public override int IndexOf(object value, int startIndex)
    {
      return this._list.IndexOf(value, startIndex);
    }

    public override int IndexOf(object value, int startIndex, int count)
    {
      return this._list.IndexOf(value, startIndex, count);
    }

    public override void Insert(int index, object value) => this._list.Insert(index, value);

    public override void InsertRange(int index, ICollection c) => this._list.InsertRange(index, c);

    public override int LastIndexOf(object value) => this._list.LastIndexOf(value);

    public override int LastIndexOf(object value, int startIndex)
    {
      return this._list.LastIndexOf(value, startIndex);
    }

    public override int LastIndexOf(object value, int startIndex, int count)
    {
      return this._list.LastIndexOf(value, startIndex, count);
    }

    public override void Remove(object value) => this._list.Remove(value);

    public override void RemoveAt(int index) => this._list.RemoveAt(index);

    public override void RemoveRange(int index, int count) => this._list.RemoveRange(index, count);

    public override void Reverse(int index, int count) => this._list.Reverse(index, count);

    public override void SetRange(int index, ICollection c) => this._list.SetRange(index, c);

    public override ArrayList GetRange(int index, int count) => this._list.GetRange(index, count);

    public override void Sort() => this._list.Sort();

    public override void Sort(IComparer comparer) => this._list.Sort(comparer);

    public override void Sort(int index, int count, IComparer comparer)
    {
      this._list.Sort(index, count, comparer);
    }

    public override object[] ToArray() => this._list.ToArray();

    public override Array ToArray(Type type) => this._list.ToArray(type);

    public override void TrimToSize() => this._list.TrimToSize();
  }

  private sealed class ConnectionArrayList(ArrayList list) : 
    HttpHandlerDiagnosticListener.ArrayListWrapper(list)
  {
    public override int Add(object value)
    {
      if (HttpHandlerDiagnosticListener.s_connectionType.IsInstanceOfType(value))
      {
        if (!(HttpHandlerDiagnosticListener.s_writeListField.GetValue(value) is ArrayList list))
          list = new ArrayList();
        HttpHandlerDiagnosticListener.HttpWebRequestArrayList requestArrayList = new HttpHandlerDiagnosticListener.HttpWebRequestArrayList(list);
        HttpHandlerDiagnosticListener.s_writeListField.SetValue(value, (object) requestArrayList);
      }
      return base.Add(value);
    }
  }

  private sealed class HttpWebRequestArrayList(ArrayList list) : 
    HttpHandlerDiagnosticListener.ArrayListWrapper(list)
  {
    public override int Add(object value)
    {
      if (value is HttpWebRequest request)
        HttpHandlerDiagnosticListener.s_instance.RaiseRequestEvent(request);
      return base.Add(value);
    }

    public override void RemoveAt(int index)
    {
      if (this[index] is HttpWebRequest request)
      {
        HttpWebResponse response = HttpHandlerDiagnosticListener.s_httpResponseAccessor(request);
        if (response != null)
        {
          HttpHandlerDiagnosticListener.s_instance.RaiseResponseEvent(request, response);
        }
        else
        {
          object o = HttpHandlerDiagnosticListener.s_coreResponseAccessor(request);
          if (o != null && HttpHandlerDiagnosticListener.s_coreResponseDataType.IsInstanceOfType(o))
          {
            HttpStatusCode statusCode = HttpHandlerDiagnosticListener.s_coreStatusCodeAccessor(o);
            WebHeaderCollection headers = HttpHandlerDiagnosticListener.s_coreHeadersAccessor(o);
            HttpHandlerDiagnosticListener.s_instance.RaiseResponseEvent(request, statusCode, headers);
          }
        }
      }
      base.RemoveAt(index);
    }
  }
}
