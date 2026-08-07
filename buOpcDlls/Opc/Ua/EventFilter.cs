// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EventFilter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

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
public class EventFilter : MonitoringFilter
{
  private SimpleAttributeOperandCollection m_selectClauses;
  private ContentFilter m_whereClause;

  public EventFilter() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_selectClauses = new SimpleAttributeOperandCollection();
    this.m_whereClause = new ContentFilter();
  }

  [DataMember(Name = "SelectClauses", IsRequired = false, Order = 1)]
  public SimpleAttributeOperandCollection SelectClauses
  {
    get => this.m_selectClauses;
    set
    {
      this.m_selectClauses = value;
      if (value != null)
        return;
      this.m_selectClauses = new SimpleAttributeOperandCollection();
    }
  }

  [DataMember(Name = "WhereClause", IsRequired = false, Order = 2)]
  public ContentFilter WhereClause
  {
    get => this.m_whereClause;
    set
    {
      this.m_whereClause = value;
      if (value != null)
        return;
      this.m_whereClause = new ContentFilter();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.EventFilter;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EventFilter_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EventFilter_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EventFilter_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeableArray("SelectClauses", (IList<IEncodeable>) this.SelectClauses.ToArray(), typeof (SimpleAttributeOperand));
    encoder.WriteEncodeable("WhereClause", (IEncodeable) this.WhereClause, typeof (ContentFilter));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.SelectClauses = (SimpleAttributeOperandCollection) (SimpleAttributeOperand[]) decoder.ReadEncodeableArray("SelectClauses", typeof (SimpleAttributeOperand));
    this.WhereClause = (ContentFilter) decoder.ReadEncodeable("WhereClause", typeof (ContentFilter));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is EventFilter eventFilter && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_selectClauses, (object) eventFilter.m_selectClauses) && Utils.IsEqual((object) this.m_whereClause, (object) eventFilter.m_whereClause) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (EventFilter) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EventFilter eventFilter = (EventFilter) base.MemberwiseClone();
    eventFilter.m_selectClauses = (SimpleAttributeOperandCollection) Utils.Clone((object) this.m_selectClauses);
    eventFilter.m_whereClause = (ContentFilter) Utils.Clone((object) this.m_whereClause);
    return (object) eventFilter;
  }

  public void AddSelectClause(NodeId eventTypeId, QualifiedName propertyName)
  {
    SimpleAttributeOperand attributeOperand = new SimpleAttributeOperand();
    attributeOperand.TypeDefinitionId = eventTypeId;
    attributeOperand.AttributeId = 13U;
    attributeOperand.BrowsePath.Add(propertyName);
    this.SelectClauses.Add(attributeOperand);
  }

  public void AddSelectClause(NodeId eventTypeId, string browsePath, uint attributeId)
  {
    SimpleAttributeOperand attributeOperand = new SimpleAttributeOperand();
    attributeOperand.TypeDefinitionId = eventTypeId;
    attributeOperand.AttributeId = attributeId;
    if (!string.IsNullOrEmpty(browsePath))
      attributeOperand.BrowsePath = SimpleAttributeOperand.Parse(browsePath);
    this.SelectClauses.Add(attributeOperand);
  }

  public EventFilter.Result Validate(FilterContext context)
  {
    EventFilter.Result result = new EventFilter.Result();
    if (this.m_selectClauses != null && this.m_selectClauses.Count != 0)
    {
      if (this.m_whereClause == null)
      {
        result.Status = ServiceResult.Create(2152071168U /*0x80460000*/, "EventFilter does not specify any Where Clauses.");
        return result;
      }
      result.Status = ServiceResult.Good;
      bool flag = false;
      foreach (SimpleAttributeOperand selectClause in (List<SimpleAttributeOperand>) this.m_selectClauses)
      {
        if (selectClause == null)
        {
          ServiceResult serviceResult = ServiceResult.Create(2152071168U /*0x80460000*/, "EventFilterSelectClause cannot be null in EventFilter SelectClause.");
          result.SelectClauseResults.Add(serviceResult);
          flag = true;
        }
        else
        {
          ServiceResult status = selectClause.Validate(context, 0);
          if (ServiceResult.IsBad(status))
          {
            result.SelectClauseResults.Add(status);
            flag = true;
          }
          else
            result.SelectClauseResults.Add((ServiceResult) null);
        }
      }
      if (flag)
        result.Status = (ServiceResult) 2152136704U /*0x80470000*/;
      else
        result.SelectClauseResults.Clear();
      result.WhereClauseResult = this.m_whereClause.Validate(context);
      if (ServiceResult.IsBad(result.WhereClauseResult.Status))
        result.Status = (ServiceResult) 2152136704U /*0x80470000*/;
      return result;
    }
    result.Status = ServiceResult.Create(2152071168U /*0x80460000*/, "EventFilter does not specify any Select Clauses.");
    return result;
  }

  public class Result
  {
    private ServiceResult m_status;
    private List<ServiceResult> m_selectClauseResults;
    private ContentFilter.Result m_whereClauseResults;

    public static implicit operator EventFilter.Result(ServiceResult status)
    {
      return new EventFilter.Result() { Status = status };
    }

    public ServiceResult Status
    {
      get => this.m_status;
      set => this.m_status = value;
    }

    public string GetLongString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (ServiceResult selectClauseResult in this.SelectClauseResults)
      {
        if (ServiceResult.IsBad(selectClauseResult))
        {
          stringBuilder.AppendFormat("Select Clause Error: {0}", (object) selectClauseResult.ToString());
          stringBuilder.AppendLine();
        }
      }
      if (ServiceResult.IsBad(this.WhereClauseResult.Status))
      {
        stringBuilder.AppendFormat("Where Clause Error: {0}", (object) this.WhereClauseResult.Status.ToString());
        stringBuilder.AppendLine();
        foreach (ContentFilter.ElementResult elementResult in this.WhereClauseResult.ElementResults)
        {
          if (elementResult != null && ServiceResult.IsBad(elementResult.Status))
          {
            stringBuilder.AppendFormat("Element Error: {0}", (object) elementResult.Status.ToString());
            stringBuilder.AppendLine();
            foreach (ServiceResult operandResult in elementResult.OperandResults)
            {
              if (ServiceResult.IsBad(operandResult))
              {
                stringBuilder.AppendFormat("Operand Error: {0}", (object) operandResult.ToString());
                stringBuilder.AppendLine();
              }
            }
          }
        }
      }
      return stringBuilder.ToString();
    }

    public List<ServiceResult> SelectClauseResults
    {
      get
      {
        if (this.m_selectClauseResults == null)
          this.m_selectClauseResults = new List<ServiceResult>();
        return this.m_selectClauseResults;
      }
    }

    public ContentFilter.Result WhereClauseResult
    {
      get => this.m_whereClauseResults;
      internal set => this.m_whereClauseResults = value;
    }

    public EventFilterResult ToEventFilterResult(
      DiagnosticsMasks diagnosticsMasks,
      StringTable stringTable)
    {
      EventFilterResult eventFilterResult = new EventFilterResult();
      if (this.m_selectClauseResults != null && this.m_selectClauseResults.Count > 0)
      {
        foreach (ServiceResult selectClauseResult in this.m_selectClauseResults)
        {
          if (ServiceResult.IsBad(selectClauseResult))
          {
            eventFilterResult.SelectClauseResults.Add(selectClauseResult.StatusCode);
            eventFilterResult.SelectClauseDiagnosticInfos.Add(new DiagnosticInfo(selectClauseResult, diagnosticsMasks, false, stringTable));
          }
          else
          {
            eventFilterResult.SelectClauseResults.Add((StatusCode) 0U);
            eventFilterResult.SelectClauseDiagnosticInfos.Add((DiagnosticInfo) null);
          }
        }
      }
      if (this.m_whereClauseResults != null)
        eventFilterResult.WhereClauseResult = this.m_whereClauseResults.ToContextFilterResult(diagnosticsMasks, stringTable);
      return eventFilterResult;
    }
  }
}
