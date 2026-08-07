// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TrustListState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TrustListState(NodeState parent) : FileState(parent)
{
  private const string UpdateFrequency_InitializationString = "//////////8VYIkKAgAAAAAADwAAAFVwZGF0ZUZyZXF1ZW5jeQEAYEsALgBEYEsAAAEAIgH/////AQH/////AAAAAA==";
  private const string CloseAndUpdate_InitializationString = "//////////8EYYIKBAAAAAAADgAAAENsb3NlQW5kVXBkYXRlAQACMQAvAQACMQIxAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAoTEALgBEoTEAAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAAMxAC4ARAMxAACWAQAAAAEAKgEBIwAAABQAAABBcHBseUNoYW5nZXNSZXF1aXJlZAAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string AddCertificate_InitializationString = "//////////8EYYIKBAAAAAAADgAAAEFkZENlcnRpZmljYXRlAQAEMQAvAQAEMQQxAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEABTEALgBEBTEAAJYCAAAAAQAqAQEaAAAACwAAAENlcnRpZmljYXRlAA//////AAAAAAABACoBASMAAAAUAAAASXNUcnVzdGVkQ2VydGlmaWNhdGUAAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private const string RemoveCertificate_InitializationString = "//////////8EYYIKBAAAAAAAEQAAAFJlbW92ZUNlcnRpZmljYXRlAQAGMQAvAQAGMQYxAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEABzEALgBEBzEAAJYCAAAAAQAqAQEZAAAACgAAAFRodW1icHJpbnQADP////8AAAAAAAEAKgEBIwAAABQAAABJc1RydXN0ZWRDZXJ0aWZpY2F0ZQAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAFQAAAFRydXN0TGlzdFR5cGVJbnN0YW5jZQEA6jABAOow6jAAAP////8QAAAAFWCJCgIAAAAAAAQAAABTaXplAQDrMAAuAETrMAAAAAn/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAV3JpdGFibGUBAJoxAC4ARJoxAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABVc2VyV3JpdGFibGUBAJsxAC4ARJsxAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABPcGVuQ291bnQBAO4wAC4ARO4wAAAABf////8BAf////8AAAAABGGCCgQAAAAAAAQAAABPcGVuAQDvMAAvAQA8Le8wAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA8DAALgBE8DAAAJYBAAAAAQAqAQETAAAABAAAAE1vZGUAA/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAPEwAC4ARPEwAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAFAAAAQ2xvc2UBAPIwAC8BAD8t8jAAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDzMAAuAETzMAAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABAAAAFJlYWQBAPQwAC8BAEEt9DAAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQD1MAAuAET1MAAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEVAAAABgAAAExlbmd0aAAG/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA9jAALgBE9jAAAJYBAAAAAQAqAQETAAAABAAAAERhdGEAD/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAUAAABXcml0ZQEA9zAALwEARC33MAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAPgwAC4ARPgwAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARMAAAAEAAAARGF0YQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAEdldFBvc2l0aW9uAQD5MAAvAQBGLfkwAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA+jAALgBE+jAAAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAPswAC4ARPswAACWAQAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAFNldFBvc2l0aW9uAQD8MAAvAQBJLfwwAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA/TAALgBE/TAAAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RVcGRhdGVUaW1lAQD+MAAuAET+MAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABVcGRhdGVGcmVxdWVuY3kBAGBLAC4ARGBLAAABACIB/////wEB/////wAAAAAEYYIKBAAAAAAADQAAAE9wZW5XaXRoTWFza3MBAP8wAC8BAP8w/zAAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAAMQAuAEQAMQAAlgEAAAABACoBARQAAAAFAAAATWFza3MAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAAExAC4ARAExAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAOAAAAQ2xvc2VBbmRVcGRhdGUBAAIxAC8BAAIxAjEAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQChMQAuAEShMQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAAzEALgBEAzEAAJYBAAAAAQAqAQEjAAAAFAAAAEFwcGx5Q2hhbmdlc1JlcXVpcmVkAAH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAOAAAAQWRkQ2VydGlmaWNhdGUBAAQxAC8BAAQxBDEAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAFMQAuAEQFMQAAlgIAAAABACoBARoAAAALAAAAQ2VydGlmaWNhdGUAD/////8AAAAAAAEAKgEBIwAAABQAAABJc1RydXN0ZWRDZXJ0aWZpY2F0ZQAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAEQAAAFJlbW92ZUNlcnRpZmljYXRlAQAGMQAvAQAGMQYxAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEABzEALgBEBzEAAJYCAAAAAQAqAQEZAAAACgAAAFRodW1icHJpbnQADP////8AAAAAAAEAKgEBIwAAABQAAABJc1RydXN0ZWRDZXJ0aWZpY2F0ZQAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private PropertyState<DateTime> m_lastUpdateTime;
  private PropertyState<double> m_updateFrequency;
  private OpenWithMasksMethodState m_openWithMasksMethod;
  private CloseAndUpdateMethodState m_closeAndUpdateMethod;
  private AddCertificateMethodState m_addCertificateMethod;
  private RemoveCertificateMethodState m_removeCertificateMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 12522U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAFQAAAFRydXN0TGlzdFR5cGVJbnN0YW5jZQEA6jABAOow6jAAAP////8QAAAAFWCJCgIAAAAAAAQAAABTaXplAQDrMAAuAETrMAAAAAn/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAV3JpdGFibGUBAJoxAC4ARJoxAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABVc2VyV3JpdGFibGUBAJsxAC4ARJsxAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABPcGVuQ291bnQBAO4wAC4ARO4wAAAABf////8BAf////8AAAAABGGCCgQAAAAAAAQAAABPcGVuAQDvMAAvAQA8Le8wAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA8DAALgBE8DAAAJYBAAAAAQAqAQETAAAABAAAAE1vZGUAA/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAPEwAC4ARPEwAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAFAAAAQ2xvc2UBAPIwAC8BAD8t8jAAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDzMAAuAETzMAAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABAAAAFJlYWQBAPQwAC8BAEEt9DAAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQD1MAAuAET1MAAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEVAAAABgAAAExlbmd0aAAG/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA9jAALgBE9jAAAJYBAAAAAQAqAQETAAAABAAAAERhdGEAD/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAUAAABXcml0ZQEA9zAALwEARC33MAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAPgwAC4ARPgwAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARMAAAAEAAAARGF0YQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAEdldFBvc2l0aW9uAQD5MAAvAQBGLfkwAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA+jAALgBE+jAAAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAPswAC4ARPswAACWAQAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAFNldFBvc2l0aW9uAQD8MAAvAQBJLfwwAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA/TAALgBE/TAAAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RVcGRhdGVUaW1lAQD+MAAuAET+MAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABVcGRhdGVGcmVxdWVuY3kBAGBLAC4ARGBLAAABACIB/////wEB/////wAAAAAEYYIKBAAAAAAADQAAAE9wZW5XaXRoTWFza3MBAP8wAC8BAP8w/zAAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAAMQAuAEQAMQAAlgEAAAABACoBARQAAAAFAAAATWFza3MAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAAExAC4ARAExAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAOAAAAQ2xvc2VBbmRVcGRhdGUBAAIxAC8BAAIxAjEAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQChMQAuAEShMQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAAzEALgBEAzEAAJYBAAAAAQAqAQEjAAAAFAAAAEFwcGx5Q2hhbmdlc1JlcXVpcmVkAAH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAOAAAAQWRkQ2VydGlmaWNhdGUBAAQxAC8BAAQxBDEAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAFMQAuAEQFMQAAlgIAAAABACoBARoAAAALAAAAQ2VydGlmaWNhdGUAD/////8AAAAAAAEAKgEBIwAAABQAAABJc1RydXN0ZWRDZXJ0aWZpY2F0ZQAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAEQAAAFJlbW92ZUNlcnRpZmljYXRlAQAGMQAvAQAGMQYxAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEABzEALgBEBzEAAJYCAAAAAQAqAQEZAAAACgAAAFRodW1icHJpbnQADP////8AAAAAAAEAKgEBIwAAABQAAABJc1RydXN0ZWRDZXJ0aWZpY2F0ZQAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
    this.InitializeOptionalChildren(context);
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    this.InitializeOptionalChildren(context);
    base.Initialize(context, source);
  }

  protected override void InitializeOptionalChildren(ISystemContext context)
  {
    base.InitializeOptionalChildren(context);
    if (this.UpdateFrequency != null)
      this.UpdateFrequency.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAFVwZGF0ZUZyZXF1ZW5jeQEAYEsALgBEYEsAAAEAIgH/////AQH/////AAAAAA==");
    if (this.CloseAndUpdate != null)
      this.CloseAndUpdate.Initialize(context, "//////////8EYYIKBAAAAAAADgAAAENsb3NlQW5kVXBkYXRlAQACMQAvAQACMQIxAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAoTEALgBEoTEAAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAAMxAC4ARAMxAACWAQAAAAEAKgEBIwAAABQAAABBcHBseUNoYW5nZXNSZXF1aXJlZAAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
    if (this.AddCertificate != null)
      this.AddCertificate.Initialize(context, "//////////8EYYIKBAAAAAAADgAAAEFkZENlcnRpZmljYXRlAQAEMQAvAQAEMQQxAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEABTEALgBEBTEAAJYCAAAAAQAqAQEaAAAACwAAAENlcnRpZmljYXRlAA//////AAAAAAABACoBASMAAAAUAAAASXNUcnVzdGVkQ2VydGlmaWNhdGUAAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
    if (this.RemoveCertificate == null)
      return;
    this.RemoveCertificate.Initialize(context, "//////////8EYYIKBAAAAAAAEQAAAFJlbW92ZUNlcnRpZmljYXRlAQAGMQAvAQAGMQYxAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEABzEALgBEBzEAAJYCAAAAAQAqAQEZAAAACgAAAFRodW1icHJpbnQADP////8AAAAAAAEAKgEBIwAAABQAAABJc1RydXN0ZWRDZXJ0aWZpY2F0ZQAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
  }

  public PropertyState<DateTime> LastUpdateTime
  {
    get => this.m_lastUpdateTime;
    set
    {
      if (this.m_lastUpdateTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastUpdateTime = value;
    }
  }

  public PropertyState<double> UpdateFrequency
  {
    get => this.m_updateFrequency;
    set
    {
      if (this.m_updateFrequency != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_updateFrequency = value;
    }
  }

  public OpenWithMasksMethodState OpenWithMasks
  {
    get => this.m_openWithMasksMethod;
    set
    {
      if (this.m_openWithMasksMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_openWithMasksMethod = value;
    }
  }

  public CloseAndUpdateMethodState CloseAndUpdate
  {
    get => this.m_closeAndUpdateMethod;
    set
    {
      if (this.m_closeAndUpdateMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_closeAndUpdateMethod = value;
    }
  }

  public AddCertificateMethodState AddCertificate
  {
    get => this.m_addCertificateMethod;
    set
    {
      if (this.m_addCertificateMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addCertificateMethod = value;
    }
  }

  public RemoveCertificateMethodState RemoveCertificate
  {
    get => this.m_removeCertificateMethod;
    set
    {
      if (this.m_removeCertificateMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_removeCertificateMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_lastUpdateTime != null)
      children.Add((BaseInstanceState) this.m_lastUpdateTime);
    if (this.m_updateFrequency != null)
      children.Add((BaseInstanceState) this.m_updateFrequency);
    if (this.m_openWithMasksMethod != null)
      children.Add((BaseInstanceState) this.m_openWithMasksMethod);
    if (this.m_closeAndUpdateMethod != null)
      children.Add((BaseInstanceState) this.m_closeAndUpdateMethod);
    if (this.m_addCertificateMethod != null)
      children.Add((BaseInstanceState) this.m_addCertificateMethod);
    if (this.m_removeCertificateMethod != null)
      children.Add((BaseInstanceState) this.m_removeCertificateMethod);
    base.GetChildren(context, children);
  }

  protected override BaseInstanceState FindChild(
    ISystemContext context,
    QualifiedName browseName,
    bool createOrReplace,
    BaseInstanceState replacement)
  {
    if (QualifiedName.IsNull(browseName))
      return (BaseInstanceState) null;
    BaseInstanceState baseInstanceState = (BaseInstanceState) null;
    switch (browseName.Name)
    {
      case "LastUpdateTime":
        if (createOrReplace && this.LastUpdateTime == null)
          this.LastUpdateTime = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.LastUpdateTime;
        break;
      case "UpdateFrequency":
        if (createOrReplace && this.UpdateFrequency == null)
          this.UpdateFrequency = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.UpdateFrequency;
        break;
      case "OpenWithMasks":
        if (createOrReplace && this.OpenWithMasks == null)
          this.OpenWithMasks = replacement != null ? (OpenWithMasksMethodState) replacement : new OpenWithMasksMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.OpenWithMasks;
        break;
      case "CloseAndUpdate":
        if (createOrReplace && this.CloseAndUpdate == null)
          this.CloseAndUpdate = replacement != null ? (CloseAndUpdateMethodState) replacement : new CloseAndUpdateMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.CloseAndUpdate;
        break;
      case "AddCertificate":
        if (createOrReplace && this.AddCertificate == null)
          this.AddCertificate = replacement != null ? (AddCertificateMethodState) replacement : new AddCertificateMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.AddCertificate;
        break;
      case "RemoveCertificate":
        if (createOrReplace && this.RemoveCertificate == null)
          this.RemoveCertificate = replacement != null ? (RemoveCertificateMethodState) replacement : new RemoveCertificateMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.RemoveCertificate;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
