// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.IXmlNode
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Xml;

#nullable disable
namespace Newtonsoft.Json.Converters;

[NullableContext(2)]
internal interface IXmlNode
{
  XmlNodeType NodeType { get; }

  string LocalName { get; }

  [Nullable(1)]
  List<IXmlNode> ChildNodes { [NullableContext(1)] get; }

  [Nullable(1)]
  List<IXmlNode> Attributes { [NullableContext(1)] get; }

  IXmlNode ParentNode { get; }

  string Value { get; set; }

  [NullableContext(1)]
  IXmlNode AppendChild(IXmlNode newChild);

  string NamespaceUri { get; }

  object WrappedNode { get; }
}
