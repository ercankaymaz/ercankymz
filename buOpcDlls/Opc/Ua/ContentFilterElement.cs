// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ContentFilterElement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ContentFilterElement : IEncodeable, ICloneable, IJsonEncodeable, IFormattable
{
  private FilterOperator m_filterOperator;
  private ExtensionObjectCollection m_filterOperands;
  private ContentFilter m_parent;

  public ContentFilterElement() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_filterOperator = FilterOperator.Equals;
    this.m_filterOperands = new ExtensionObjectCollection();
  }

  [DataMember(Name = "FilterOperator", IsRequired = false, Order = 1)]
  public FilterOperator FilterOperator
  {
    get => this.m_filterOperator;
    set => this.m_filterOperator = value;
  }

  [DataMember(Name = "FilterOperands", IsRequired = false, Order = 2)]
  public ExtensionObjectCollection FilterOperands
  {
    get => this.m_filterOperands;
    set
    {
      this.m_filterOperands = value;
      if (value != null)
        return;
      this.m_filterOperands = new ExtensionObjectCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ContentFilterElement;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ContentFilterElement_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ContentFilterElement_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ContentFilterElement_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEnumerated("FilterOperator", (Enum) this.FilterOperator);
    encoder.WriteExtensionObjectArray("FilterOperands", (IList<ExtensionObject>) this.FilterOperands);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.FilterOperator = (FilterOperator) decoder.ReadEnumerated("FilterOperator", typeof (FilterOperator));
    this.FilterOperands = decoder.ReadExtensionObjectArray("FilterOperands");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ContentFilterElement contentFilterElement && Utils.IsEqual((object) this.m_filterOperator, (object) contentFilterElement.m_filterOperator) && Utils.IsEqual((object) this.m_filterOperands, (object) contentFilterElement.m_filterOperands);
  }

  public virtual object Clone() => (object) (ContentFilterElement) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ContentFilterElement contentFilterElement = (ContentFilterElement) base.MemberwiseClone();
    contentFilterElement.m_filterOperator = (FilterOperator) Utils.Clone((object) this.m_filterOperator);
    contentFilterElement.m_filterOperands = (ExtensionObjectCollection) Utils.Clone((object) this.m_filterOperands);
    return (object) contentFilterElement;
  }

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format == null)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendFormat(formatProvider, "<{0}", (object) this.FilterOperator);
      for (int index = 0; index < this.FilterOperands.Count; ++index)
      {
        if (this.FilterOperands[index] != null)
          stringBuilder.AppendFormat(formatProvider, ", {0}", this.FilterOperands[index].Body);
        else
          stringBuilder.AppendFormat(formatProvider, ", (null)");
      }
      stringBuilder.AppendFormat(formatProvider, ">");
      return stringBuilder.ToString();
    }
    throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public ContentFilter Parent
  {
    get => this.m_parent;
    internal set => this.m_parent = value;
  }

  public virtual ContentFilter.ElementResult Validate(FilterContext context, int index)
  {
    ContentFilter.ElementResult elementResult = new ContentFilter.ElementResult((ServiceResult) null);
    int num = -1;
    switch (this.m_filterOperator)
    {
      case FilterOperator.Equals:
      case FilterOperator.GreaterThan:
      case FilterOperator.LessThan:
      case FilterOperator.GreaterThanOrEqual:
      case FilterOperator.LessThanOrEqual:
      case FilterOperator.Like:
      case FilterOperator.And:
      case FilterOperator.Or:
      case FilterOperator.Cast:
      case FilterOperator.BitwiseAnd:
      case FilterOperator.BitwiseOr:
        num = 2;
        break;
      case FilterOperator.IsNull:
      case FilterOperator.Not:
      case FilterOperator.InView:
      case FilterOperator.OfType:
        num = 1;
        break;
      case FilterOperator.Between:
        num = 3;
        break;
      case FilterOperator.InList:
        num = -1;
        break;
      case FilterOperator.RelatedTo:
        num = 6;
        break;
    }
    if (num != -1)
    {
      if (num != this.m_filterOperands.Count)
      {
        elementResult.Status = ServiceResult.Create(2152136704U /*0x80470000*/, "ContentFilterElement does not have the correct number of operands (Operator={0} OperandCount={1}).", (object) this.m_filterOperator, (object) num);
        return elementResult;
      }
    }
    else if (this.m_filterOperands.Count < 2)
    {
      elementResult.Status = ServiceResult.Create(2152136704U /*0x80470000*/, "ContentFilterElement does not have the correct number of operands (Operator={0} OperandCount={1}).", (object) this.m_filterOperator, (object) this.m_filterOperands.Count);
      return elementResult;
    }
    bool flag = false;
    for (int index1 = 0; index1 < this.m_filterOperands.Count; ++index1)
    {
      ExtensionObject filterOperand = this.m_filterOperands[index1];
      if (ExtensionObject.IsNull(filterOperand))
      {
        ServiceResult serviceResult = ServiceResult.Create(2152136704U /*0x80470000*/, "The FilterOperand cannot be Null.");
        elementResult.OperandResults.Add(serviceResult);
        flag = true;
      }
      else if (!(filterOperand.Body is FilterOperand body))
      {
        ServiceResult serviceResult = ServiceResult.Create(2152136704U /*0x80470000*/, "The FilterOperand is not a supported type ({0}).", (object) filterOperand.Body.GetType());
        elementResult.OperandResults.Add(serviceResult);
        flag = true;
      }
      else
      {
        body.Parent = this;
        ServiceResult status = body.Validate(context, index);
        if (ServiceResult.IsBad(status))
        {
          elementResult.OperandResults.Add(status);
          flag = true;
        }
        else
          elementResult.OperandResults.Add((ServiceResult) null);
      }
    }
    if (flag)
      elementResult.Status = (ServiceResult) 2152202240U /*0x80480000*/;
    else
      elementResult.OperandResults.Clear();
    return elementResult;
  }

  public List<FilterOperand> GetOperands()
  {
    List<FilterOperand> operands = new List<FilterOperand>(this.FilterOperands.Count);
    foreach (ExtensionObject filterOperand in (List<ExtensionObject>) this.FilterOperands)
    {
      if (!ExtensionObject.IsNull(filterOperand) && filterOperand.Body is FilterOperand body)
        operands.Add(body);
    }
    return operands;
  }

  public void SetOperands(IEnumerable<FilterOperand> operands)
  {
    this.FilterOperands.Clear();
    if (operands == null)
      return;
    foreach (FilterOperand operand in operands)
    {
      if (operand != null)
        this.FilterOperands.Add(new ExtensionObject((object) operand));
    }
  }

  public virtual string ToString(INodeTable nodeTable)
  {
    List<FilterOperand> operands = this.GetOperands();
    string str1 = operands.Count > 0 ? operands[0].ToString(nodeTable) : (string) null;
    string str2 = operands.Count > 1 ? operands[1].ToString(nodeTable) : (string) null;
    string str3 = operands.Count > 2 ? operands[2].ToString(nodeTable) : (string) null;
    StringBuilder stringBuilder = new StringBuilder();
    switch (this.FilterOperator)
    {
      case FilterOperator.Equals:
      case FilterOperator.GreaterThan:
      case FilterOperator.LessThan:
      case FilterOperator.GreaterThanOrEqual:
      case FilterOperator.LessThanOrEqual:
      case FilterOperator.Like:
      case FilterOperator.And:
      case FilterOperator.Or:
      case FilterOperator.BitwiseAnd:
      case FilterOperator.BitwiseOr:
        stringBuilder.AppendFormat("'{1}' {0} '{2}'", (object) this.FilterOperator, (object) str1, (object) str2);
        break;
      case FilterOperator.IsNull:
      case FilterOperator.Not:
      case FilterOperator.InView:
      case FilterOperator.OfType:
        stringBuilder.AppendFormat("{0} '{1}'", (object) this.FilterOperator, (object) str1);
        break;
      case FilterOperator.Between:
        stringBuilder.AppendFormat("'{1}' <= '{0}' <= '{2}'", (object) str1, (object) str2, (object) str3);
        break;
      case FilterOperator.InList:
        stringBuilder.AppendFormat("'{0}' in ", (object) str1);
        stringBuilder.Append('{');
        for (int index = 1; index < operands.Count; ++index)
        {
          stringBuilder.AppendFormat("'{0}'", (object) operands[index].ToString());
          if (index < operands.Count - 1)
            stringBuilder.Append(", ");
        }
        stringBuilder.Append('}');
        break;
      case FilterOperator.Cast:
        stringBuilder.AppendFormat("({1}){0}", (object) str1, (object) str2);
        break;
      case FilterOperator.RelatedTo:
        stringBuilder.AppendFormat("'{0}' ", (object) str1);
        string str4 = str2;
        if (operands.Count > 1 && operands[1] is LiteralOperand literalOperand)
        {
          INode node = nodeTable.Find((ExpandedNodeId) (literalOperand.Value.Value as NodeId));
          if (node != null)
            str4 = Utils.Format("{0}", (object) node);
        }
        stringBuilder.AppendFormat("{0} '{1}'", (object) str4, (object) str2);
        if (str3 != null)
        {
          stringBuilder.AppendFormat("Hops='{0}'", (object) str3);
          break;
        }
        break;
    }
    return stringBuilder.ToString();
  }
}
