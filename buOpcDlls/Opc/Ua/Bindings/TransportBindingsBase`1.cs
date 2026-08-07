// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.TransportBindingsBase`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TransportBindingsBase<T> : ITransportBindings<T> where T : class, ITransportBindingScheme
{
  protected TransportBindingsBase()
  {
    this.Bindings = new Dictionary<string, T>();
    this.AddBindings(typeof (TransportBindingsBase<T>).Assembly);
  }

  protected TransportBindingsBase(Type[] defaultBindings)
  {
    this.Bindings = new Dictionary<string, T>();
    this.AddBindings((IEnumerable<Type>) defaultBindings);
  }

  protected Dictionary<string, T> Bindings { get; private set; }

  public T GetBinding(string uriScheme)
  {
    T binding;
    if (!this.Bindings.TryGetValue(uriScheme, out binding))
    {
      this.TryAddDefaultTransportBindings(uriScheme);
      if (!this.Bindings.TryGetValue(uriScheme, out binding))
        return default (T);
    }
    return binding;
  }

  public bool HasBinding(string uriScheme) => this.Bindings.TryGetValue(uriScheme, out T _);

  public void SetBinding(T binding) => this.Bindings[binding.UriScheme] = binding;

  public IEnumerable<Type> AddBindings(Assembly assembly)
  {
    return this.AddBindings(((IEnumerable<Type>) assembly.GetExportedTypes()).Where<Type>((Func<Type, bool>) (type => TransportBindingsBase<T>.IsBindingType(type))));
  }

  public IEnumerable<Type> AddBindings(IEnumerable<Type> bindings)
  {
    List<Type> typeList = new List<Type>();
    foreach (Type binding in bindings)
    {
      if (Activator.CreateInstance(binding) is T instance)
      {
        this.Bindings[instance.UriScheme] = instance;
        typeList.Add(binding);
      }
    }
    return (IEnumerable<Type>) typeList;
  }

  protected static bool IsBindingType(Type bindingType)
  {
    if (bindingType == (Type) null)
      return false;
    System.Reflection.TypeInfo typeInfo = bindingType.GetTypeInfo();
    return !typeInfo.IsAbstract && typeof (T).GetTypeInfo().IsAssignableFrom(typeInfo) && (object) (Activator.CreateInstance(bindingType) as T) != null;
  }

  private bool TryAddDefaultTransportBindings(string scheme)
  {
    string newValue;
    if (Utils.DefaultBindings.TryGetValue(scheme, out newValue))
    {
      Assembly assembly = (Assembly) null;
      string assemblyString = Utils.DefaultOpcUaCoreAssemblyFullName.Replace(Utils.DefaultOpcUaCoreAssemblyName, newValue);
      try
      {
        assembly = Assembly.Load(assemblyString);
      }
      catch
      {
        Utils.LogError("Failed to load the assembly {0} for transport binding {1}.", (object) assemblyString, (object) scheme);
      }
      if (assembly != (Assembly) null)
        return this.AddBindings(assembly).Any<Type>();
    }
    else
      Utils.LogError("The transport binding {0} is unsupported.", (object) scheme);
    return false;
  }
}
