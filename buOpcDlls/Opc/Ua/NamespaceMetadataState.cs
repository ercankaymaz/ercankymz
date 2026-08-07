// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NamespaceMetadataState
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
public class NamespaceMetadataState(NodeState parent) : BaseObjectState(parent)
{
  private const string NamespaceFile_InitializationString = "//////////8EYIAKAQAAAAAADQAAAE5hbWVzcGFjZUZpbGUBAGgtAC8BAEstaC0AAP////8KAAAAFWCJCgIAAAAAAAQAAABTaXplAQBpLQAuAERpLQAAAAn/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAV3JpdGFibGUBAJIxAC4ARJIxAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABVc2VyV3JpdGFibGUBAJMxAC4ARJMxAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABPcGVuQ291bnQBAGwtAC4ARGwtAAAABf////8BAf////8AAAAABGGCCgQAAAAAAAQAAABPcGVuAQBtLQAvAQA8LW0tAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAbi0ALgBEbi0AAJYBAAAAAQAqAQETAAAABAAAAE1vZGUAA/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAG8tAC4ARG8tAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAFAAAAQ2xvc2UBAHAtAC8BAD8tcC0AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBxLQAuAERxLQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABAAAAFJlYWQBAHItAC8BAEEtci0AAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBzLQAuAERzLQAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEVAAAABgAAAExlbmd0aAAG/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAdC0ALgBEdC0AAJYBAAAAAQAqAQETAAAABAAAAERhdGEAD/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAUAAABXcml0ZQEAdS0ALwEARC11LQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHYtAC4ARHYtAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARMAAAAEAAAARGF0YQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAEdldFBvc2l0aW9uAQB3LQAvAQBGLXctAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAeC0ALgBEeC0AAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAHktAC4ARHktAACWAQAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAFNldFBvc2l0aW9uAQB6LQAvAQBJLXotAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAey0ALgBEey0AAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string DefaultRolePermissions_InitializationString = "//////////8XYIkKAgAAAAAAFgAAAERlZmF1bHRSb2xlUGVybWlzc2lvbnMBAAk/AC4ARAk/AAAAYAEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string DefaultUserRolePermissions_InitializationString = "//////////8XYIkKAgAAAAAAGgAAAERlZmF1bHRVc2VyUm9sZVBlcm1pc3Npb25zAQAKPwAuAEQKPwAAAGABAAAAAQAAAAAAAAABAf////8AAAAA";
  private const string DefaultAccessRestrictions_InitializationString = "//////////8VYIkKAgAAAAAAGQAAAERlZmF1bHRBY2Nlc3NSZXN0cmljdGlvbnMBAAs/AC4ARAs/AAAAX/////8BAf////8AAAAA";
  private const string InitializationString = "//////////8EYIACAQAAAAAAHQAAAE5hbWVzcGFjZU1ldGFkYXRhVHlwZUluc3RhbmNlAQBgLQEAYC1gLQAA/////wsAAAAVYIkKAgAAAAAADAAAAE5hbWVzcGFjZVVyaQEAYS0ALgBEYS0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAE5hbWVzcGFjZVZlcnNpb24BAGItAC4ARGItAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABgAAABOYW1lc3BhY2VQdWJsaWNhdGlvbkRhdGUBAGMtAC4ARGMtAAAADf////8BAf////8AAAAAFWCJCgIAAAAAABEAAABJc05hbWVzcGFjZVN1YnNldAEAZC0ALgBEZC0AAAAB/////wEB/////wAAAAAXYIkKAgAAAAAAEQAAAFN0YXRpY05vZGVJZFR5cGVzAQBlLQAuAERlLQAAAQAAAQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGAAAAFN0YXRpY051bWVyaWNOb2RlSWRSYW5nZQEAZi0ALgBEZi0AAAEAIwEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABkAAABTdGF0aWNTdHJpbmdOb2RlSWRQYXR0ZXJuAQBnLQAuAERnLQAAAAz/////AQH/////AAAAAARggAoBAAAAAAANAAAATmFtZXNwYWNlRmlsZQEAaC0ALwEASy1oLQAA/////woAAAAVYIkKAgAAAAAABAAAAFNpemUBAGktAC4ARGktAAAACf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABXcml0YWJsZQEAkjEALgBEkjEAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFVzZXJXcml0YWJsZQEAkzEALgBEkzEAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAE9wZW5Db3VudAEAbC0ALgBEbC0AAAAF/////wEB/////wAAAAAEYYIKBAAAAAAABAAAAE9wZW4BAG0tAC8BADwtbS0AAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBuLQAuAERuLQAAlgEAAAABACoBARMAAAAEAAAATW9kZQAD/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAby0ALgBEby0AAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAUAAABDbG9zZQEAcC0ALwEAPy1wLQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHEtAC4ARHEtAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAEAAAAUmVhZAEAci0ALwEAQS1yLQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHMtAC4ARHMtAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARUAAAAGAAAATGVuZ3RoAAb/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQB0LQAuAER0LQAAlgEAAAABACoBARMAAAAEAAAARGF0YQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABQAAAFdyaXRlAQB1LQAvAQBELXUtAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAdi0ALgBEdi0AAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBEwAAAAQAAABEYXRhAA//////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAALAAAAR2V0UG9zaXRpb24BAHctAC8BAEYtdy0AAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB4LQAuAER4LQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAeS0ALgBEeS0AAJYBAAAAAQAqAQEXAAAACAAAAFBvc2l0aW9uAAn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAALAAAAU2V0UG9zaXRpb24BAHotAC8BAEktei0AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB7LQAuAER7LQAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEXAAAACAAAAFBvc2l0aW9uAAn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAWAAAARGVmYXVsdFJvbGVQZXJtaXNzaW9ucwEACT8ALgBECT8AAABgAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAaAAAARGVmYXVsdFVzZXJSb2xlUGVybWlzc2lvbnMBAAo/AC4ARAo/AAAAYAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAGQAAAERlZmF1bHRBY2Nlc3NSZXN0cmljdGlvbnMBAAs/AC4ARAs/AAAAX/////8BAf////8AAAAA";
  private PropertyState<string> m_namespaceUri;
  private PropertyState<string> m_namespaceVersion;
  private PropertyState<DateTime> m_namespacePublicationDate;
  private PropertyState<bool> m_isNamespaceSubset;
  private PropertyState<IdType[]> m_staticNodeIdTypes;
  private PropertyState<string[]> m_staticNumericNodeIdRange;
  private PropertyState<string> m_staticStringNodeIdPattern;
  private AddressSpaceFileState m_namespaceFile;
  private PropertyState<RolePermissionType[]> m_defaultRolePermissions;
  private PropertyState<RolePermissionType[]> m_defaultUserRolePermissions;
  private PropertyState<ushort> m_defaultAccessRestrictions;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 11616U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHQAAAE5hbWVzcGFjZU1ldGFkYXRhVHlwZUluc3RhbmNlAQBgLQEAYC1gLQAA/////wsAAAAVYIkKAgAAAAAADAAAAE5hbWVzcGFjZVVyaQEAYS0ALgBEYS0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAE5hbWVzcGFjZVZlcnNpb24BAGItAC4ARGItAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABgAAABOYW1lc3BhY2VQdWJsaWNhdGlvbkRhdGUBAGMtAC4ARGMtAAAADf////8BAf////8AAAAAFWCJCgIAAAAAABEAAABJc05hbWVzcGFjZVN1YnNldAEAZC0ALgBEZC0AAAAB/////wEB/////wAAAAAXYIkKAgAAAAAAEQAAAFN0YXRpY05vZGVJZFR5cGVzAQBlLQAuAERlLQAAAQAAAQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGAAAAFN0YXRpY051bWVyaWNOb2RlSWRSYW5nZQEAZi0ALgBEZi0AAAEAIwEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABkAAABTdGF0aWNTdHJpbmdOb2RlSWRQYXR0ZXJuAQBnLQAuAERnLQAAAAz/////AQH/////AAAAAARggAoBAAAAAAANAAAATmFtZXNwYWNlRmlsZQEAaC0ALwEASy1oLQAA/////woAAAAVYIkKAgAAAAAABAAAAFNpemUBAGktAC4ARGktAAAACf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABXcml0YWJsZQEAkjEALgBEkjEAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFVzZXJXcml0YWJsZQEAkzEALgBEkzEAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAE9wZW5Db3VudAEAbC0ALgBEbC0AAAAF/////wEB/////wAAAAAEYYIKBAAAAAAABAAAAE9wZW4BAG0tAC8BADwtbS0AAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBuLQAuAERuLQAAlgEAAAABACoBARMAAAAEAAAATW9kZQAD/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAby0ALgBEby0AAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAUAAABDbG9zZQEAcC0ALwEAPy1wLQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHEtAC4ARHEtAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAEAAAAUmVhZAEAci0ALwEAQS1yLQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHMtAC4ARHMtAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARUAAAAGAAAATGVuZ3RoAAb/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQB0LQAuAER0LQAAlgEAAAABACoBARMAAAAEAAAARGF0YQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABQAAAFdyaXRlAQB1LQAvAQBELXUtAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAdi0ALgBEdi0AAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBEwAAAAQAAABEYXRhAA//////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAALAAAAR2V0UG9zaXRpb24BAHctAC8BAEYtdy0AAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB4LQAuAER4LQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAeS0ALgBEeS0AAJYBAAAAAQAqAQEXAAAACAAAAFBvc2l0aW9uAAn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAALAAAAU2V0UG9zaXRpb24BAHotAC8BAEktei0AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB7LQAuAER7LQAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEXAAAACAAAAFBvc2l0aW9uAAn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAWAAAARGVmYXVsdFJvbGVQZXJtaXNzaW9ucwEACT8ALgBECT8AAABgAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAaAAAARGVmYXVsdFVzZXJSb2xlUGVybWlzc2lvbnMBAAo/AC4ARAo/AAAAYAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAGQAAAERlZmF1bHRBY2Nlc3NSZXN0cmljdGlvbnMBAAs/AC4ARAs/AAAAX/////8BAf////8AAAAA");
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
    if (this.NamespaceFile != null)
      this.NamespaceFile.Initialize(context, "//////////8EYIAKAQAAAAAADQAAAE5hbWVzcGFjZUZpbGUBAGgtAC8BAEstaC0AAP////8KAAAAFWCJCgIAAAAAAAQAAABTaXplAQBpLQAuAERpLQAAAAn/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAV3JpdGFibGUBAJIxAC4ARJIxAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABVc2VyV3JpdGFibGUBAJMxAC4ARJMxAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABPcGVuQ291bnQBAGwtAC4ARGwtAAAABf////8BAf////8AAAAABGGCCgQAAAAAAAQAAABPcGVuAQBtLQAvAQA8LW0tAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAbi0ALgBEbi0AAJYBAAAAAQAqAQETAAAABAAAAE1vZGUAA/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAG8tAC4ARG8tAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAFAAAAQ2xvc2UBAHAtAC8BAD8tcC0AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBxLQAuAERxLQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABAAAAFJlYWQBAHItAC8BAEEtci0AAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBzLQAuAERzLQAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEVAAAABgAAAExlbmd0aAAG/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAdC0ALgBEdC0AAJYBAAAAAQAqAQETAAAABAAAAERhdGEAD/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAUAAABXcml0ZQEAdS0ALwEARC11LQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHYtAC4ARHYtAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARMAAAAEAAAARGF0YQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAEdldFBvc2l0aW9uAQB3LQAvAQBGLXctAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAeC0ALgBEeC0AAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAHktAC4ARHktAACWAQAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAFNldFBvc2l0aW9uAQB6LQAvAQBJLXotAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAey0ALgBEey0AAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
    if (this.DefaultRolePermissions != null)
      this.DefaultRolePermissions.Initialize(context, "//////////8XYIkKAgAAAAAAFgAAAERlZmF1bHRSb2xlUGVybWlzc2lvbnMBAAk/AC4ARAk/AAAAYAEAAAABAAAAAAAAAAEB/////wAAAAA=");
    if (this.DefaultUserRolePermissions != null)
      this.DefaultUserRolePermissions.Initialize(context, "//////////8XYIkKAgAAAAAAGgAAAERlZmF1bHRVc2VyUm9sZVBlcm1pc3Npb25zAQAKPwAuAEQKPwAAAGABAAAAAQAAAAAAAAABAf////8AAAAA");
    if (this.DefaultAccessRestrictions == null)
      return;
    this.DefaultAccessRestrictions.Initialize(context, "//////////8VYIkKAgAAAAAAGQAAAERlZmF1bHRBY2Nlc3NSZXN0cmljdGlvbnMBAAs/AC4ARAs/AAAAX/////8BAf////8AAAAA");
  }

  public PropertyState<string> NamespaceUri
  {
    get => this.m_namespaceUri;
    set
    {
      if (this.m_namespaceUri != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_namespaceUri = value;
    }
  }

  public PropertyState<string> NamespaceVersion
  {
    get => this.m_namespaceVersion;
    set
    {
      if (this.m_namespaceVersion != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_namespaceVersion = value;
    }
  }

  public PropertyState<DateTime> NamespacePublicationDate
  {
    get => this.m_namespacePublicationDate;
    set
    {
      if (this.m_namespacePublicationDate != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_namespacePublicationDate = value;
    }
  }

  public PropertyState<bool> IsNamespaceSubset
  {
    get => this.m_isNamespaceSubset;
    set
    {
      if (this.m_isNamespaceSubset != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_isNamespaceSubset = value;
    }
  }

  public PropertyState<IdType[]> StaticNodeIdTypes
  {
    get => this.m_staticNodeIdTypes;
    set
    {
      if (this.m_staticNodeIdTypes != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_staticNodeIdTypes = value;
    }
  }

  public PropertyState<string[]> StaticNumericNodeIdRange
  {
    get => this.m_staticNumericNodeIdRange;
    set
    {
      if (this.m_staticNumericNodeIdRange != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_staticNumericNodeIdRange = value;
    }
  }

  public PropertyState<string> StaticStringNodeIdPattern
  {
    get => this.m_staticStringNodeIdPattern;
    set
    {
      if (this.m_staticStringNodeIdPattern != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_staticStringNodeIdPattern = value;
    }
  }

  public AddressSpaceFileState NamespaceFile
  {
    get => this.m_namespaceFile;
    set
    {
      if (this.m_namespaceFile != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_namespaceFile = value;
    }
  }

  public PropertyState<RolePermissionType[]> DefaultRolePermissions
  {
    get => this.m_defaultRolePermissions;
    set
    {
      if (this.m_defaultRolePermissions != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_defaultRolePermissions = value;
    }
  }

  public PropertyState<RolePermissionType[]> DefaultUserRolePermissions
  {
    get => this.m_defaultUserRolePermissions;
    set
    {
      if (this.m_defaultUserRolePermissions != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_defaultUserRolePermissions = value;
    }
  }

  public PropertyState<ushort> DefaultAccessRestrictions
  {
    get => this.m_defaultAccessRestrictions;
    set
    {
      if (this.m_defaultAccessRestrictions != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_defaultAccessRestrictions = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_namespaceUri != null)
      children.Add((BaseInstanceState) this.m_namespaceUri);
    if (this.m_namespaceVersion != null)
      children.Add((BaseInstanceState) this.m_namespaceVersion);
    if (this.m_namespacePublicationDate != null)
      children.Add((BaseInstanceState) this.m_namespacePublicationDate);
    if (this.m_isNamespaceSubset != null)
      children.Add((BaseInstanceState) this.m_isNamespaceSubset);
    if (this.m_staticNodeIdTypes != null)
      children.Add((BaseInstanceState) this.m_staticNodeIdTypes);
    if (this.m_staticNumericNodeIdRange != null)
      children.Add((BaseInstanceState) this.m_staticNumericNodeIdRange);
    if (this.m_staticStringNodeIdPattern != null)
      children.Add((BaseInstanceState) this.m_staticStringNodeIdPattern);
    if (this.m_namespaceFile != null)
      children.Add((BaseInstanceState) this.m_namespaceFile);
    if (this.m_defaultRolePermissions != null)
      children.Add((BaseInstanceState) this.m_defaultRolePermissions);
    if (this.m_defaultUserRolePermissions != null)
      children.Add((BaseInstanceState) this.m_defaultUserRolePermissions);
    if (this.m_defaultAccessRestrictions != null)
      children.Add((BaseInstanceState) this.m_defaultAccessRestrictions);
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
    string name = browseName.Name;
    if (name != null)
    {
      switch (name.Length)
      {
        case 12:
          if (name == "NamespaceUri")
          {
            if (createOrReplace && this.NamespaceUri == null)
              this.NamespaceUri = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.NamespaceUri;
            break;
          }
          break;
        case 13:
          if (name == "NamespaceFile")
          {
            if (createOrReplace && this.NamespaceFile == null)
              this.NamespaceFile = replacement != null ? (AddressSpaceFileState) replacement : new AddressSpaceFileState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.NamespaceFile;
            break;
          }
          break;
        case 16 /*0x10*/:
          if (name == "NamespaceVersion")
          {
            if (createOrReplace && this.NamespaceVersion == null)
              this.NamespaceVersion = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.NamespaceVersion;
            break;
          }
          break;
        case 17:
          switch (name[0])
          {
            case 'I':
              if (name == "IsNamespaceSubset")
              {
                if (createOrReplace && this.IsNamespaceSubset == null)
                  this.IsNamespaceSubset = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.IsNamespaceSubset;
                break;
              }
              break;
            case 'S':
              if (name == "StaticNodeIdTypes")
              {
                if (createOrReplace && this.StaticNodeIdTypes == null)
                  this.StaticNodeIdTypes = replacement != null ? (PropertyState<IdType[]>) replacement : new PropertyState<IdType[]>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.StaticNodeIdTypes;
                break;
              }
              break;
          }
          break;
        case 22:
          if (name == "DefaultRolePermissions")
          {
            if (createOrReplace && this.DefaultRolePermissions == null)
              this.DefaultRolePermissions = replacement != null ? (PropertyState<RolePermissionType[]>) replacement : new PropertyState<RolePermissionType[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.DefaultRolePermissions;
            break;
          }
          break;
        case 24:
          switch (name[0])
          {
            case 'N':
              if (name == "NamespacePublicationDate")
              {
                if (createOrReplace && this.NamespacePublicationDate == null)
                  this.NamespacePublicationDate = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.NamespacePublicationDate;
                break;
              }
              break;
            case 'S':
              if (name == "StaticNumericNodeIdRange")
              {
                if (createOrReplace && this.StaticNumericNodeIdRange == null)
                  this.StaticNumericNodeIdRange = replacement != null ? (PropertyState<string[]>) replacement : new PropertyState<string[]>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.StaticNumericNodeIdRange;
                break;
              }
              break;
          }
          break;
        case 25:
          switch (name[0])
          {
            case 'D':
              if (name == "DefaultAccessRestrictions")
              {
                if (createOrReplace && this.DefaultAccessRestrictions == null)
                  this.DefaultAccessRestrictions = replacement != null ? (PropertyState<ushort>) replacement : new PropertyState<ushort>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DefaultAccessRestrictions;
                break;
              }
              break;
            case 'S':
              if (name == "StaticStringNodeIdPattern")
              {
                if (createOrReplace && this.StaticStringNodeIdPattern == null)
                  this.StaticStringNodeIdPattern = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.StaticStringNodeIdPattern;
                break;
              }
              break;
          }
          break;
        case 26:
          if (name == "DefaultUserRolePermissions")
          {
            if (createOrReplace && this.DefaultUserRolePermissions == null)
              this.DefaultUserRolePermissions = replacement != null ? (PropertyState<RolePermissionType[]>) replacement : new PropertyState<RolePermissionType[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.DefaultUserRolePermissions;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
