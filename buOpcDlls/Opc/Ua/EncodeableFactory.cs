// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EncodeableFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class EncodeableFactory : IEncodeableFactory, ICloneable
{
  private readonly ReaderWriterLockSlim m_readerWriterLockSlim = new ReaderWriterLockSlim();
  private Dictionary<ExpandedNodeId, Type> m_encodeableTypes;
  private static EncodeableFactory s_globalFactory = new EncodeableFactory();

  public EncodeableFactory()
  {
    this.m_encodeableTypes = new Dictionary<ExpandedNodeId, Type>();
    this.AddEncodeableTypes(this.GetType().GetTypeInfo().Assembly);
  }

  public EncodeableFactory(bool shared)
  {
    this.m_encodeableTypes = new Dictionary<ExpandedNodeId, Type>();
    this.AddEncodeableTypes(Utils.DefaultOpcUaCoreAssemblyFullName);
  }

  public EncodeableFactory(IEncodeableFactory factory)
  {
    this.m_encodeableTypes = new Dictionary<ExpandedNodeId, Type>();
    if (factory == null)
      return;
    this.m_encodeableTypes = ((EncodeableFactory) factory.Clone()).m_encodeableTypes;
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing)
      return;
    this.m_readerWriterLockSlim?.Dispose();
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  private void AddEncodeableTypes(string assemblyName)
  {
    try
    {
      this.AddEncodeableTypes(Assembly.Load(new AssemblyName(assemblyName)));
    }
    catch (Exception ex)
    {
      Utils.LogError("Could not load encodeable types from assembly: {0}", (object) assemblyName);
    }
  }

  private void AddEncodeableType(Type systemType, Dictionary<string, ExpandedNodeId> unboundTypeIds)
  {
    if (systemType == (Type) null || !typeof (IEncodeable).GetTypeInfo().IsAssignableFrom(systemType.GetTypeInfo()) || !(Activator.CreateInstance(systemType) is IEncodeable instance))
      return;
    ExpandedNodeId expandedNodeId1 = instance.TypeId;
    if (!NodeId.IsNull(expandedNodeId1))
    {
      if (expandedNodeId1.NamespaceUri == "http://opcfoundation.org/UA/")
        expandedNodeId1 = new ExpandedNodeId(expandedNodeId1.InnerNodeId);
      this.m_encodeableTypes[expandedNodeId1] = systemType;
    }
    ExpandedNodeId expandedNodeId2 = instance.BinaryEncodingId;
    if (!NodeId.IsNull(expandedNodeId2))
    {
      if (expandedNodeId2.NamespaceUri == "http://opcfoundation.org/UA/")
        expandedNodeId2 = new ExpandedNodeId(expandedNodeId2.InnerNodeId);
      this.m_encodeableTypes[expandedNodeId2] = systemType;
    }
    ExpandedNodeId expandedNodeId3;
    try
    {
      expandedNodeId3 = instance.XmlEncodingId;
    }
    catch (NotSupportedException ex)
    {
      expandedNodeId3 = (ExpandedNodeId) NodeId.Null;
    }
    if (!NodeId.IsNull(expandedNodeId3))
    {
      if (expandedNodeId3.NamespaceUri == "http://opcfoundation.org/UA/")
        expandedNodeId3 = new ExpandedNodeId(expandedNodeId3.InnerNodeId);
      this.m_encodeableTypes[expandedNodeId3] = systemType;
    }
    if (instance is IJsonEncodeable jsonEncodeable)
    {
      ExpandedNodeId expandedNodeId4;
      try
      {
        expandedNodeId4 = jsonEncodeable.JsonEncodingId;
      }
      catch (NotSupportedException ex)
      {
        expandedNodeId4 = (ExpandedNodeId) NodeId.Null;
      }
      if (NodeId.IsNull(expandedNodeId4))
        return;
      if (expandedNodeId4.NamespaceUri == "http://opcfoundation.org/UA/")
        expandedNodeId4 = new ExpandedNodeId(expandedNodeId4.InnerNodeId);
      this.m_encodeableTypes[expandedNodeId4] = systemType;
    }
    else
    {
      ExpandedNodeId key;
      if (unboundTypeIds == null || !unboundTypeIds.TryGetValue(systemType.Name, out key))
        return;
      this.m_encodeableTypes[key] = systemType;
    }
  }

  public static EncodeableFactory GlobalFactory => EncodeableFactory.s_globalFactory;

  public static XmlQualifiedName GetXmlName(Type systemType)
  {
    if (systemType == (Type) null)
      return (XmlQualifiedName) null;
    object[] array1 = ((IEnumerable<object>) systemType.GetTypeInfo().GetCustomAttributes(typeof (DataContractAttribute), true)).ToArray<object>();
    if (array1 != null)
    {
      for (int index = 0; index < array1.Length; ++index)
      {
        if (array1[index] is DataContractAttribute contractAttribute)
          return string.IsNullOrEmpty(contractAttribute.Name) ? new XmlQualifiedName(systemType.Name, contractAttribute.Namespace) : new XmlQualifiedName(contractAttribute.Name, contractAttribute.Namespace);
      }
    }
    object[] array2 = ((IEnumerable<object>) systemType.GetTypeInfo().GetCustomAttributes(typeof (CollectionDataContractAttribute), true)).ToArray<object>();
    if (array2 != null)
    {
      for (int index = 0; index < array2.Length; ++index)
      {
        if (array2[index] is CollectionDataContractAttribute contractAttribute)
          return string.IsNullOrEmpty(contractAttribute.Name) ? new XmlQualifiedName(systemType.Name, contractAttribute.Namespace) : new XmlQualifiedName(contractAttribute.Name, contractAttribute.Namespace);
      }
    }
    return systemType == typeof (byte[]) ? new XmlQualifiedName("ByteString") : new XmlQualifiedName(systemType.FullName);
  }

  public static XmlQualifiedName GetXmlName(object value, IServiceMessageContext context)
  {
    if (value is IDynamicComplexTypeInstance complexTypeInstance)
    {
      XmlQualifiedName xmlName = complexTypeInstance.GetXmlName(context);
      if (xmlName != (XmlQualifiedName) null)
        return xmlName;
    }
    return EncodeableFactory.GetXmlName(value?.GetType());
  }

  public int InstanceId => 0;

  public void AddEncodeableType(Type systemType)
  {
    try
    {
      this.m_readerWriterLockSlim.EnterWriteLock();
      this.AddEncodeableType(systemType, (Dictionary<string, ExpandedNodeId>) null);
    }
    finally
    {
      this.m_readerWriterLockSlim.ExitWriteLock();
    }
  }

  public void AddEncodeableType(ExpandedNodeId encodingId, Type systemType)
  {
    if (!(systemType != (Type) null))
      return;
    if (NodeId.IsNull(encodingId))
      return;
    try
    {
      this.m_readerWriterLockSlim.EnterWriteLock();
      this.m_encodeableTypes[encodingId] = systemType;
    }
    finally
    {
      this.m_readerWriterLockSlim.ExitWriteLock();
    }
  }

  public void AddEncodeableTypes(Assembly assembly)
  {
    if (!(assembly != (Assembly) null))
      return;
    try
    {
      this.m_readerWriterLockSlim.EnterWriteLock();
      Type[] exportedTypes = assembly.GetExportedTypes();
      Dictionary<string, ExpandedNodeId> unboundTypeIds = new Dictionary<string, ExpandedNodeId>();
      for (int index = 0; index < exportedTypes.Length; ++index)
      {
        if (!(exportedTypes[index].Name != "ObjectIds"))
        {
          foreach (FieldInfo field in exportedTypes[index].GetFields(BindingFlags.Static | BindingFlags.Public))
          {
            if (field.Name.EndsWith("_Encoding_DefaultJson", StringComparison.Ordinal))
            {
              try
              {
                string key = field.Name.Substring(0, field.Name.Length - "_Encoding_DefaultJson".Length);
                object obj = field.GetValue((object) null);
                unboundTypeIds[key] = (object) (obj as NodeId) == null ? (ExpandedNodeId) obj : new ExpandedNodeId((NodeId) obj);
              }
              catch (Exception ex)
              {
              }
            }
          }
        }
      }
      for (int index = 0; index < exportedTypes.Length; ++index)
      {
        if (!exportedTypes[index].GetTypeInfo().IsAbstract)
          this.AddEncodeableType(exportedTypes[index], unboundTypeIds);
      }
      unboundTypeIds.Clear();
    }
    finally
    {
      this.m_readerWriterLockSlim.ExitWriteLock();
    }
  }

  public void AddEncodeableTypes(IEnumerable<Type> systemTypes)
  {
    try
    {
      this.m_readerWriterLockSlim.EnterWriteLock();
      foreach (Type systemType in systemTypes)
      {
        if (!systemType.GetTypeInfo().IsAbstract)
          this.AddEncodeableType(systemType, (Dictionary<string, ExpandedNodeId>) null);
      }
    }
    finally
    {
      this.m_readerWriterLockSlim.ExitWriteLock();
    }
  }

  public Type GetSystemType(ExpandedNodeId typeId)
  {
    try
    {
      this.m_readerWriterLockSlim.EnterReadLock();
      Type type = (Type) null;
      return !NodeId.IsNull(typeId) && this.m_encodeableTypes.TryGetValue(typeId, out type) ? type : (Type) null;
    }
    finally
    {
      this.m_readerWriterLockSlim.ExitReadLock();
    }
  }

  public IReadOnlyDictionary<ExpandedNodeId, Type> EncodeableTypes
  {
    get => (IReadOnlyDictionary<ExpandedNodeId, Type>) this.m_encodeableTypes;
  }

  public object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EncodeableFactory encodeableFactory = new EncodeableFactory((IEncodeableFactory) null);
    try
    {
      this.m_readerWriterLockSlim.EnterReadLock();
      foreach (KeyValuePair<ExpandedNodeId, Type> encodeableType in this.m_encodeableTypes)
        encodeableFactory.m_encodeableTypes.Add(encodeableType.Key, encodeableType.Value);
    }
    finally
    {
      this.m_readerWriterLockSlim.ExitReadLock();
    }
    return (object) encodeableFactory;
  }
}
