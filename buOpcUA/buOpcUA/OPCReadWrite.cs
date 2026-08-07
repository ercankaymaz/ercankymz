// Decompiled with JetBrains decompiler
// Type: buOpcUA.OPCReadWrite
// Assembly: buOpcUA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF9DFBD0-0B81-4B3D-BD5F-1E30872BDC2B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcUA.dll

using buClass;
using Opc.Ua;
using Opc.Ua.Client;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace buOpcUA;

public static class OPCReadWrite
{
  private Exception \u0001;
  private TaskAwaiter \u0001;

  private void \u0001()
  {
    // ISSUE: reference to a compiler-generated field
    int num1 = ((OpcUaConnector.\u0001) this).\u0001;
    switch (num1)
    {
      default:
        Session result;
        try
        {
          TaskAwaiter awaiter1;
          int num2;
          TaskAwaiter<Session> awaiter2;
          switch (num1)
          {
            case 0:
              awaiter1 = this.\u0001;
              this.\u0001 = new TaskAwaiter();
              num2 = -1;
              // ISSUE: reference to a compiler-generated field
              ((OpcUaConnector.\u0001) this).\u0001 = -1;
              break;
            case 1:
              awaiter2 = ((MemberRefsProxy) this).\u0001;
              ((MemberRefsProxy) this).\u0001 = new TaskAwaiter<Session>();
              num2 = -1;
              // ISSUE: reference to a compiler-generated field
              ((OpcUaConnector.\u0001) this).\u0001 = -1;
              goto label_9;
            default:
              // ISSUE: reference to a compiler-generated field
              ((OpcUaConnector.\u0001) this).\u0001 = new ApplicationConfiguration()
              {
                ApplicationName = "MyOpcClient",
                ApplicationType = ApplicationType.Client,
                SecurityConfiguration = new SecurityConfiguration()
                {
                  ApplicationCertificate = new CertificateIdentifier(),
                  AutoAcceptUntrustedCertificates = true
                },
                TransportQuotas = new TransportQuotas()
                {
                  OperationTimeout = 15000
                },
                ClientConfiguration = new ClientConfiguration()
                {
                  DefaultSessionTimeout = 60000
                }
              };
              // ISSUE: reference to a compiler-generated field
              awaiter1 = ((OpcUaConnector.\u0001) this).\u0001.Validate(ApplicationType.Client).GetAwaiter();
              if (!awaiter1.IsCompleted)
              {
                num2 = 0;
                // ISSUE: reference to a compiler-generated field
                ((OpcUaConnector.\u0001) this).\u0001 = 0;
                this.\u0001 = awaiter1;
                // ISSUE: variable of a compiler-generated type
                OpcUaConnector.\u0001 stateMachine = (OpcUaConnector.\u0001) this;
                // ISSUE: reference to a compiler-generated field
                ((OpcUaConnector.\u0001) this).\u0001.AwaitUnsafeOnCompleted<TaskAwaiter, OpcUaConnector.\u0001>(ref awaiter1, ref stateMachine);
                return;
              }
              break;
          }
          awaiter1.GetResult();
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          ((OpcUaConnector.\u0001) this).\u0001 = CoreClientUtils.SelectEndpoint(((OpcUaConnector.\u0001) this).\u0001, false);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          ((OpcUaConnector.\u0001) this).\u0001 = EndpointConfiguration.Create(((OpcUaConnector.\u0001) this).\u0001);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          ((OpcUaConnector.\u0001) this).\u0001 = new ConfiguredEndpoint((ConfiguredEndpointCollection) null, ((OpcUaConnector.\u0001) this).\u0001, ((OpcUaConnector.\u0001) this).\u0001);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          awaiter2 = Session.Create(((OpcUaConnector.\u0001) this).\u0001, ((OpcUaConnector.\u0001) this).\u0001, false, "MyOpcSession", 60000U, (IUserIdentity) new UserIdentity((UserIdentityToken) new AnonymousIdentityToken()), (IList<string>) null).GetAwaiter();
          if (!awaiter2.IsCompleted)
          {
            num2 = 1;
            // ISSUE: reference to a compiler-generated field
            ((OpcUaConnector.\u0001) this).\u0001 = 1;
            ((MemberRefsProxy) this).\u0001 = awaiter2;
            // ISSUE: variable of a compiler-generated type
            OpcUaConnector.\u0001 stateMachine = (OpcUaConnector.\u0001) this;
            // ISSUE: reference to a compiler-generated field
            ((OpcUaConnector.\u0001) this).\u0001.AwaitUnsafeOnCompleted<TaskAwaiter<Session>, OpcUaConnector.\u0001>(ref awaiter2, ref stateMachine);
            break;
          }
label_9:
          // ISSUE: reference to a compiler-generated field
          ((OpcUaConnector.\u0001) this).\u0002 = awaiter2.GetResult();
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          ((OpcUaConnector.\u0001) this).\u0001 = ((OpcUaConnector.\u0001) this).\u0002;
          // ISSUE: reference to a compiler-generated field
          ((OpcUaConnector.\u0001) this).\u0002 = (Session) null;
          Console.WriteLine("✅ OPC UA Connected!");
          // ISSUE: reference to a compiler-generated field
          result = ((OpcUaConnector.\u0001) this).\u0001;
        }
        catch (Exception ex)
        {
          this.\u0001 = ex;
          Console.WriteLine("❌ OPC UA Connection Failed: " + this.\u0001.Message);
          result = (Session) null;
        }
        // ISSUE: reference to a compiler-generated field
        ((OpcUaConnector.\u0001) this).\u0001 = -2;
        // ISSUE: reference to a compiler-generated field
        ((OpcUaConnector.\u0001) this).\u0001.SetResult(result);
        break;
    }
  }

  private void \u0001([In] IAsyncStateMachine obj0)
  {
  }

  public abstract void m00001F();

  public static string WriteBOOLValue(bool value, string nodeid, Session session)
  {
    try
    {
      Opc.Ua.Variant variant = new Opc.Ua.Variant(value);
      WriteValue writeValue = new WriteValue()
      {
        NodeId = new NodeId(nodeid),
        AttributeId = 13,
        Value = new DataValue(variant)
      };
      Session session1 = session;
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      nodesToWrite.Add(writeValue);
      StatusCodeCollection statusCodeCollection;
      ref StatusCodeCollection local1 = ref statusCodeCollection;
      DiagnosticInfoCollection diagnosticInfoCollection;
      ref DiagnosticInfoCollection local2 = ref diagnosticInfoCollection;
      session1.Write((RequestHeader) null, nodesToWrite, out local1, out local2);
      return StatusCode.IsBad(statusCodeCollection[0]) ? statusCodeCollection[0].ToString() : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteBOOLValue(Session session, string nodeid, bool value)
  {
    try
    {
      Opc.Ua.Variant variant = new Opc.Ua.Variant(value);
      WriteValue writeValue = new WriteValue()
      {
        NodeId = new NodeId(nodeid),
        AttributeId = 13,
        Value = new DataValue(variant)
      };
      Session session1 = session;
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      nodesToWrite.Add(writeValue);
      StatusCodeCollection statusCodeCollection;
      ref StatusCodeCollection local1 = ref statusCodeCollection;
      DiagnosticInfoCollection diagnosticInfoCollection;
      ref DiagnosticInfoCollection local2 = ref diagnosticInfoCollection;
      session1.Write((RequestHeader) null, nodesToWrite, out local1, out local2);
      return StatusCode.IsBad(statusCodeCollection[0]) ? statusCodeCollection[0].ToString() : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteDINTValue(int value, string nodeid, Session session)
  {
    try
    {
      Opc.Ua.Variant variant = new Opc.Ua.Variant(value);
      WriteValue writeValue = new WriteValue()
      {
        NodeId = new NodeId(nodeid),
        AttributeId = 13,
        Value = new DataValue(variant)
      };
      Session session1 = session;
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      nodesToWrite.Add(writeValue);
      StatusCodeCollection statusCodeCollection;
      ref StatusCodeCollection local1 = ref statusCodeCollection;
      DiagnosticInfoCollection diagnosticInfoCollection;
      ref DiagnosticInfoCollection local2 = ref diagnosticInfoCollection;
      session1.Write((RequestHeader) null, nodesToWrite, out local1, out local2);
      return StatusCode.IsBad(statusCodeCollection[0]) ? statusCodeCollection[0].ToString() : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteINTValue(short value, string nodeid, Session session)
  {
    try
    {
      Opc.Ua.Variant variant = new Opc.Ua.Variant(value);
      WriteValue writeValue = new WriteValue()
      {
        NodeId = new NodeId(nodeid),
        AttributeId = 13,
        Value = new DataValue(variant)
      };
      Session session1 = session;
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      nodesToWrite.Add(writeValue);
      StatusCodeCollection statusCodeCollection;
      ref StatusCodeCollection local1 = ref statusCodeCollection;
      DiagnosticInfoCollection diagnosticInfoCollection;
      ref DiagnosticInfoCollection local2 = ref diagnosticInfoCollection;
      session1.Write((RequestHeader) null, nodesToWrite, out local1, out local2);
      return StatusCode.IsBad(statusCodeCollection[0]) ? statusCodeCollection[0].ToString() : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteLREALValue(double value, string nodeid, Session session)
  {
    try
    {
      Opc.Ua.Variant variant = new Opc.Ua.Variant(value);
      WriteValue writeValue = new WriteValue()
      {
        NodeId = new NodeId(nodeid),
        AttributeId = 13,
        Value = new DataValue(variant)
      };
      Session session1 = session;
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      nodesToWrite.Add(writeValue);
      StatusCodeCollection statusCodeCollection;
      ref StatusCodeCollection local1 = ref statusCodeCollection;
      DiagnosticInfoCollection diagnosticInfoCollection;
      ref DiagnosticInfoCollection local2 = ref diagnosticInfoCollection;
      session1.Write((RequestHeader) null, nodesToWrite, out local1, out local2);
      return StatusCode.IsBad(statusCodeCollection[0]) ? statusCodeCollection[0].ToString() : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteREALValue(float value, string nodeid, Session session)
  {
    try
    {
      Opc.Ua.Variant variant = new Opc.Ua.Variant(value);
      WriteValue writeValue = new WriteValue()
      {
        NodeId = new NodeId(nodeid),
        AttributeId = 13,
        Value = new DataValue(variant)
      };
      Session session1 = session;
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      nodesToWrite.Add(writeValue);
      StatusCodeCollection statusCodeCollection;
      ref StatusCodeCollection local1 = ref statusCodeCollection;
      DiagnosticInfoCollection diagnosticInfoCollection;
      ref DiagnosticInfoCollection local2 = ref diagnosticInfoCollection;
      session1.Write((RequestHeader) null, nodesToWrite, out local1, out local2);
      return StatusCode.IsBad(statusCodeCollection[0]) ? statusCodeCollection[0].ToString() : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteSTRINGValue(string value, string nodeid, Session session)
  {
    try
    {
      Opc.Ua.Variant variant = new Opc.Ua.Variant(value);
      WriteValue writeValue = new WriteValue()
      {
        NodeId = new NodeId(nodeid),
        AttributeId = 13,
        Value = new DataValue(variant)
      };
      Session session1 = session;
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      nodesToWrite.Add(writeValue);
      StatusCodeCollection statusCodeCollection;
      ref StatusCodeCollection local1 = ref statusCodeCollection;
      DiagnosticInfoCollection diagnosticInfoCollection;
      ref DiagnosticInfoCollection local2 = ref diagnosticInfoCollection;
      session1.Write((RequestHeader) null, nodesToWrite, out local1, out local2);
      return StatusCode.IsBad(statusCodeCollection[0]) ? statusCodeCollection[0].ToString() : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteBOOLList(List<bool> values, List<string> nodeidList, Session session)
  {
    try
    {
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      for (int index = 0; index <= nodeidList.Count - 1; ++index)
      {
        Opc.Ua.Variant variant = new Opc.Ua.Variant(values[index]);
        WriteValue writeValue = new WriteValue()
        {
          NodeId = new NodeId(nodeidList[index]),
          AttributeId = 13,
          Value = new DataValue(variant)
        };
        nodesToWrite.Add(writeValue);
      }
      StatusCodeCollection results;
      session.Write((RequestHeader) null, nodesToWrite, out results, out DiagnosticInfoCollection _);
      string str = "";
      for (int index = 0; index <= results.Count - 1; ++index)
      {
        if (StatusCode.IsBad(results[index]))
        {
          str = results[index].ToString();
          index = results.Count;
        }
      }
      return str.Length > 0 ? str : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteBOOLList(List<VariableBOOLDef> VarsStringList, Session session)
  {
    try
    {
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      for (int index = 0; index <= VarsStringList.Count - 1; ++index)
      {
        Opc.Ua.Variant variant = new Opc.Ua.Variant(VarsStringList[index].Value);
        WriteValue writeValue = new WriteValue()
        {
          NodeId = new NodeId(VarsStringList[index].Name),
          AttributeId = 13,
          Value = new DataValue(variant)
        };
        nodesToWrite.Add(writeValue);
      }
      StatusCodeCollection results;
      session.Write((RequestHeader) null, nodesToWrite, out results, out DiagnosticInfoCollection _);
      string str1 = "";
      \u0003.\u0001.ErrorList.Clear();
      for (int index = 0; index <= results.Count - 1; ++index)
      {
        if (StatusCode.IsBad(results[index]))
        {
          StatusCode statusCode;
          if (str1 == "")
          {
            statusCode = results[index];
            str1 = $"{statusCode.ToString()} - {VarsStringList[index].Name}";
          }
          List<string> errorList = \u0003.\u0001.ErrorList;
          statusCode = results[index];
          string str2 = $"{statusCode.ToString()} - {VarsStringList[index].Name}";
          errorList.Add(str2);
        }
      }
      return str1.Length > 0 ? str1 : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteDINTList(List<int> values, List<string> nodeidList, Session session)
  {
    try
    {
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      for (int index = 0; index <= nodeidList.Count - 1; ++index)
      {
        Opc.Ua.Variant variant = new Opc.Ua.Variant(values[index]);
        WriteValue writeValue = new WriteValue()
        {
          NodeId = new NodeId(nodeidList[index]),
          AttributeId = 13,
          Value = new DataValue(variant)
        };
        nodesToWrite.Add(writeValue);
      }
      StatusCodeCollection results;
      session.Write((RequestHeader) null, nodesToWrite, out results, out DiagnosticInfoCollection _);
      string str = "";
      for (int index = 0; index <= results.Count - 1; ++index)
      {
        if (StatusCode.IsBad(results[index]))
        {
          str = results[index].ToString();
          index = results.Count;
        }
      }
      return str.Length > 0 ? str : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteDINTList(List<VariableDINTDef> VarsStringList, Session session)
  {
    try
    {
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      for (int index = 0; index <= VarsStringList.Count - 1; ++index)
      {
        Opc.Ua.Variant variant = new Opc.Ua.Variant(VarsStringList[index].Value);
        WriteValue writeValue = new WriteValue()
        {
          NodeId = new NodeId(VarsStringList[index].Name),
          AttributeId = 13,
          Value = new DataValue(variant)
        };
        nodesToWrite.Add(writeValue);
      }
      StatusCodeCollection results;
      session.Write((RequestHeader) null, nodesToWrite, out results, out DiagnosticInfoCollection _);
      \u0003.\u0001.ErrorList.Clear();
      string str1 = "";
      for (int index = 0; index <= results.Count - 1; ++index)
      {
        if (StatusCode.IsBad(results[index]))
        {
          StatusCode statusCode;
          if (str1 == "")
          {
            statusCode = results[index];
            str1 = $"{statusCode.ToString()} - {VarsStringList[index].Name}";
          }
          List<string> errorList = \u0003.\u0001.ErrorList;
          statusCode = results[index];
          string str2 = $"{statusCode.ToString()} - {VarsStringList[index].Name}";
          errorList.Add(str2);
        }
      }
      return str1.Length > 0 ? str1 : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteINTList(List<short> values, List<string> nodeidList, Session session)
  {
    try
    {
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      for (int index = 0; index <= nodeidList.Count - 1; ++index)
      {
        Opc.Ua.Variant variant = new Opc.Ua.Variant(values[index]);
        WriteValue writeValue = new WriteValue()
        {
          NodeId = new NodeId(nodeidList[index]),
          AttributeId = 13,
          Value = new DataValue(variant)
        };
        nodesToWrite.Add(writeValue);
      }
      StatusCodeCollection results;
      session.Write((RequestHeader) null, nodesToWrite, out results, out DiagnosticInfoCollection _);
      string str = "";
      for (int index = 0; index <= results.Count - 1; ++index)
      {
        if (StatusCode.IsBad(results[index]))
        {
          str = results[index].ToString();
          index = results.Count;
        }
      }
      return str.Length > 0 ? str : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteINTList(List<VariableINTDef> VarsStringList, Session session)
  {
    try
    {
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      for (int index = 0; index <= VarsStringList.Count - 1; ++index)
      {
        Opc.Ua.Variant variant = new Opc.Ua.Variant(VarsStringList[index].Value);
        WriteValue writeValue = new WriteValue()
        {
          NodeId = new NodeId(VarsStringList[index].Name),
          AttributeId = 13,
          Value = new DataValue(variant)
        };
        nodesToWrite.Add(writeValue);
      }
      StatusCodeCollection results;
      session.Write((RequestHeader) null, nodesToWrite, out results, out DiagnosticInfoCollection _);
      \u0003.\u0001.ErrorList.Clear();
      string str1 = "";
      for (int index = 0; index <= results.Count - 1; ++index)
      {
        if (StatusCode.IsBad(results[index]))
        {
          StatusCode statusCode;
          if (str1 == "")
          {
            statusCode = results[index];
            str1 = $"{statusCode.ToString()} - {VarsStringList[index].Name}";
          }
          List<string> errorList = \u0003.\u0001.ErrorList;
          statusCode = results[index];
          string str2 = $"{statusCode.ToString()} - {VarsStringList[index].Name}";
          errorList.Add(str2);
        }
      }
      return str1.Length > 0 ? str1 : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteLREALList(
    List<double> values,
    List<string> nodeidList,
    Session session)
  {
    try
    {
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      for (int index = 0; index <= nodeidList.Count - 1; ++index)
      {
        Opc.Ua.Variant variant = new Opc.Ua.Variant(values[index]);
        WriteValue writeValue = new WriteValue()
        {
          NodeId = new NodeId(nodeidList[index]),
          AttributeId = 13,
          Value = new DataValue(variant)
        };
        nodesToWrite.Add(writeValue);
      }
      StatusCodeCollection results;
      session.Write((RequestHeader) null, nodesToWrite, out results, out DiagnosticInfoCollection _);
      string str = "";
      for (int index = 0; index <= results.Count - 1; ++index)
      {
        if (StatusCode.IsBad(results[index]))
        {
          str = results[index].ToString();
          index = results.Count;
        }
      }
      return str.Length > 0 ? str : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteLREALList(List<VariableLREALDef> VarsStringList, Session session)
  {
    try
    {
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      for (int index = 0; index <= VarsStringList.Count - 1; ++index)
      {
        Opc.Ua.Variant variant = new Opc.Ua.Variant(VarsStringList[index].Value);
        WriteValue writeValue = new WriteValue()
        {
          NodeId = new NodeId(VarsStringList[index].Name),
          AttributeId = 13,
          Value = new DataValue(variant)
        };
        nodesToWrite.Add(writeValue);
      }
      StatusCodeCollection results;
      session.Write((RequestHeader) null, nodesToWrite, out results, out DiagnosticInfoCollection _);
      \u0003.\u0001.ErrorList.Clear();
      string str1 = "";
      for (int index = 0; index <= results.Count - 1; ++index)
      {
        if (StatusCode.IsBad(results[index]))
        {
          StatusCode statusCode;
          if (str1 == "")
          {
            statusCode = results[index];
            str1 = $"{statusCode.ToString()} - {VarsStringList[index].Name}";
          }
          List<string> errorList = \u0003.\u0001.ErrorList;
          statusCode = results[index];
          string str2 = $"{statusCode.ToString()} - {VarsStringList[index].Name}";
          errorList.Add(str2);
        }
      }
      return str1.Length > 0 ? str1 : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteREALList(List<float> values, List<string> nodeidList, Session session)
  {
    try
    {
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      for (int index = 0; index <= nodeidList.Count - 1; ++index)
      {
        Opc.Ua.Variant variant = new Opc.Ua.Variant(values[index]);
        WriteValue writeValue = new WriteValue()
        {
          NodeId = new NodeId(nodeidList[index]),
          AttributeId = 13,
          Value = new DataValue(variant)
        };
        nodesToWrite.Add(writeValue);
      }
      StatusCodeCollection results;
      session.Write((RequestHeader) null, nodesToWrite, out results, out DiagnosticInfoCollection _);
      string str = "";
      for (int index = 0; index <= results.Count - 1; ++index)
      {
        if (StatusCode.IsBad(results[index]))
        {
          str = results[index].ToString();
          index = results.Count;
        }
      }
      return str.Length > 0 ? str : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteREALList(List<VariableREALDef> VarsRealList, Session session)
  {
    try
    {
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      for (int index = 0; index <= VarsRealList.Count - 1; ++index)
      {
        Opc.Ua.Variant variant = new Opc.Ua.Variant(VarsRealList[index].Value);
        WriteValue writeValue = new WriteValue()
        {
          NodeId = new NodeId(VarsRealList[index].Name),
          AttributeId = 13,
          Value = new DataValue(variant)
        };
        nodesToWrite.Add(writeValue);
      }
      StatusCodeCollection results;
      session.Write((RequestHeader) null, nodesToWrite, out results, out DiagnosticInfoCollection _);
      \u0003.\u0001.ErrorList.Clear();
      string str1 = "";
      for (int index = 0; index <= results.Count - 1; ++index)
      {
        if (StatusCode.IsBad(results[index]))
        {
          StatusCode statusCode;
          if (str1 == "")
          {
            statusCode = results[index];
            str1 = $"{statusCode.ToString()} - {VarsRealList[index].Name}";
          }
          List<string> errorList = \u0003.\u0001.ErrorList;
          statusCode = results[index];
          string str2 = $"{statusCode.ToString()} - {VarsRealList[index].Name}";
          errorList.Add(str2);
        }
      }
      return str1.Length > 0 ? str1 : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteSTRINGList(
    List<string> values,
    List<string> nodeidList,
    Session session)
  {
    try
    {
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      for (int index = 0; index <= nodeidList.Count - 1; ++index)
      {
        Opc.Ua.Variant variant = new Opc.Ua.Variant(values[index]);
        WriteValue writeValue = new WriteValue()
        {
          NodeId = new NodeId(nodeidList[index]),
          AttributeId = 13,
          Value = new DataValue(variant)
        };
        nodesToWrite.Add(writeValue);
      }
      StatusCodeCollection results;
      session.Write((RequestHeader) null, nodesToWrite, out results, out DiagnosticInfoCollection _);
      string str = "";
      for (int index = 0; index <= results.Count - 1; ++index)
      {
        if (StatusCode.IsBad(results[index]))
        {
          str = results[index].ToString();
          index = results.Count;
        }
      }
      return str.Length > 0 ? str : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteSTRINGList(List<VariableSTRINGDef> VarsStringList, Session session)
  {
    try
    {
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      for (int index = 0; index <= VarsStringList.Count - 1; ++index)
      {
        Opc.Ua.Variant variant = new Opc.Ua.Variant(VarsStringList[index].Value);
        WriteValue writeValue = new WriteValue()
        {
          NodeId = new NodeId(VarsStringList[index].Name),
          AttributeId = 13,
          Value = new DataValue(variant)
        };
        nodesToWrite.Add(writeValue);
      }
      StatusCodeCollection results;
      session.Write((RequestHeader) null, nodesToWrite, out results, out DiagnosticInfoCollection _);
      \u0003.\u0001.ErrorList.Clear();
      string str1 = "";
      for (int index = 0; index <= results.Count - 1; ++index)
      {
        if (StatusCode.IsBad(results[index]))
        {
          StatusCode statusCode;
          if (str1 == "")
          {
            statusCode = results[index];
            str1 = $"{statusCode.ToString()} - {VarsStringList[index].Name}";
          }
          List<string> errorList = \u0003.\u0001.ErrorList;
          statusCode = results[index];
          string str2 = $"{statusCode.ToString()} - {VarsStringList[index].Name}";
          errorList.Add(str2);
        }
      }
      return str1.Length > 0 ? str1 : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteENUMList(List<VariableENUMDef> VarsStringList, Session session)
  {
    try
    {
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      for (int index = 0; index <= VarsStringList.Count - 1; ++index)
      {
        Opc.Ua.Variant variant = new Opc.Ua.Variant((object) VarsStringList[index].Value);
        WriteValue writeValue = new WriteValue()
        {
          NodeId = new NodeId(VarsStringList[index].Name),
          AttributeId = 13,
          Value = new DataValue(variant)
        };
        nodesToWrite.Add(writeValue);
      }
      StatusCodeCollection results;
      session.Write((RequestHeader) null, nodesToWrite, out results, out DiagnosticInfoCollection _);
      \u0003.\u0001.ErrorList.Clear();
      string str1 = "";
      for (int index = 0; index <= results.Count - 1; ++index)
      {
        if (StatusCode.IsBad(results[index]))
        {
          StatusCode statusCode;
          if (str1 == "")
          {
            statusCode = results[index];
            str1 = $"{statusCode.ToString()} - {VarsStringList[index].Name}";
          }
          List<string> errorList = \u0003.\u0001.ErrorList;
          statusCode = results[index];
          string str2 = $"{statusCode.ToString()} - {VarsStringList[index].Name}";
          errorList.Add(str2);
        }
      }
      return str1.Length > 0 ? str1 : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteDINTArray(int[] list, string nodeid, Session session)
  {
    try
    {
      Opc.Ua.Variant variant = new Opc.Ua.Variant(list);
      WriteValue writeValue = new WriteValue()
      {
        NodeId = new NodeId(nodeid),
        AttributeId = 13,
        Value = new DataValue(variant)
      };
      Session session1 = session;
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      nodesToWrite.Add(writeValue);
      StatusCodeCollection statusCodeCollection;
      ref StatusCodeCollection local1 = ref statusCodeCollection;
      DiagnosticInfoCollection diagnosticInfoCollection;
      ref DiagnosticInfoCollection local2 = ref diagnosticInfoCollection;
      session1.Write((RequestHeader) null, nodesToWrite, out local1, out local2);
      return StatusCode.IsBad(statusCodeCollection[0]) ? statusCodeCollection[0].ToString() : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteINTArray(short[] list, string nodeid, Session session)
  {
    try
    {
      Opc.Ua.Variant variant = new Opc.Ua.Variant(list);
      WriteValue writeValue = new WriteValue()
      {
        NodeId = new NodeId(nodeid),
        AttributeId = 13,
        Value = new DataValue(variant)
      };
      Session session1 = session;
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      nodesToWrite.Add(writeValue);
      StatusCodeCollection statusCodeCollection;
      ref StatusCodeCollection local1 = ref statusCodeCollection;
      DiagnosticInfoCollection diagnosticInfoCollection;
      ref DiagnosticInfoCollection local2 = ref diagnosticInfoCollection;
      session1.Write((RequestHeader) null, nodesToWrite, out local1, out local2);
      return StatusCode.IsBad(statusCodeCollection[0]) ? statusCodeCollection[0].ToString() : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteBOOLArray(bool[] list, string nodeid, Session session)
  {
    try
    {
      Opc.Ua.Variant variant = new Opc.Ua.Variant(list);
      WriteValue writeValue = new WriteValue()
      {
        NodeId = new NodeId(nodeid),
        AttributeId = 13,
        Value = new DataValue(variant)
      };
      Session session1 = session;
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      nodesToWrite.Add(writeValue);
      StatusCodeCollection statusCodeCollection;
      ref StatusCodeCollection local1 = ref statusCodeCollection;
      DiagnosticInfoCollection diagnosticInfoCollection;
      ref DiagnosticInfoCollection local2 = ref diagnosticInfoCollection;
      session1.Write((RequestHeader) null, nodesToWrite, out local1, out local2);
      return StatusCode.IsBad(statusCodeCollection[0]) ? statusCodeCollection[0].ToString() : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteLREALArray(double[] list, string nodeid, Session session)
  {
    try
    {
      Opc.Ua.Variant variant = new Opc.Ua.Variant(list);
      WriteValue writeValue = new WriteValue()
      {
        NodeId = new NodeId(nodeid),
        AttributeId = 13,
        Value = new DataValue(variant)
      };
      Session session1 = session;
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      nodesToWrite.Add(writeValue);
      StatusCodeCollection statusCodeCollection;
      ref StatusCodeCollection local1 = ref statusCodeCollection;
      DiagnosticInfoCollection diagnosticInfoCollection;
      ref DiagnosticInfoCollection local2 = ref diagnosticInfoCollection;
      session1.Write((RequestHeader) null, nodesToWrite, out local1, out local2);
      return StatusCode.IsBad(statusCodeCollection[0]) ? statusCodeCollection[0].ToString() : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteREALArray(float[] list, string nodeid, Session session)
  {
    try
    {
      Opc.Ua.Variant variant = new Opc.Ua.Variant(list);
      WriteValue writeValue = new WriteValue()
      {
        NodeId = new NodeId(nodeid),
        AttributeId = 13,
        Value = new DataValue(variant)
      };
      Session session1 = session;
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      nodesToWrite.Add(writeValue);
      StatusCodeCollection statusCodeCollection;
      ref StatusCodeCollection local1 = ref statusCodeCollection;
      DiagnosticInfoCollection diagnosticInfoCollection;
      ref DiagnosticInfoCollection local2 = ref diagnosticInfoCollection;
      session1.Write((RequestHeader) null, nodesToWrite, out local1, out local2);
      return StatusCode.IsBad(statusCodeCollection[0]) ? statusCodeCollection[0].ToString() : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string WriteSTRINGArray(string[] list, string nodeid, Session session)
  {
    try
    {
      Opc.Ua.Variant variant = new Opc.Ua.Variant(list);
      WriteValue writeValue = new WriteValue()
      {
        NodeId = new NodeId(nodeid),
        AttributeId = 13,
        Value = new DataValue(variant)
      };
      Session session1 = session;
      WriteValueCollection nodesToWrite = new WriteValueCollection();
      nodesToWrite.Add(writeValue);
      StatusCodeCollection statusCodeCollection;
      ref StatusCodeCollection local1 = ref statusCodeCollection;
      DiagnosticInfoCollection diagnosticInfoCollection;
      ref DiagnosticInfoCollection local2 = ref diagnosticInfoCollection;
      session1.Write((RequestHeader) null, nodesToWrite, out local1, out local2);
      return StatusCode.IsBad(statusCodeCollection[0]) ? statusCodeCollection[0].ToString() : "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadBOOLsValueFromVariables(
    Session session,
    List<string> nodeidList,
    ref List<bool> Values)
  {
    List<string> ErrorList = new List<string>();
    try
    {
      return OPCReadWrite.ReadBOOLsValueFromVariables(session, nodeidList, ref Values, ref ErrorList);
    }
    catch (Exception ex)
    {
      ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadBOOLsValueFromVariables(
    Session session,
    List<string> nodeidList,
    ref List<bool> Values,
    ref List<string> ErrorList)
  {
    try
    {
      List<NodeId> nodeIds = new List<NodeId>();
      DataValueCollection values = new DataValueCollection();
      IList<ServiceResult> errors = (IList<ServiceResult>) null;
      for (int index = 0; index <= nodeidList.Count - 1; ++index)
        nodeIds.Add(new NodeId(nodeidList[index]));
      session.ReadValues((IList<NodeId>) nodeIds, out values, out errors);
      if (Values == null)
        Values = new List<bool>();
      Values.Clear();
      for (int index = 0; index <= values.Count - 1; ++index)
      {
        if ((values[index].Value == null ? 0 : (values[index].Value.GetType() == typeof (bool) ? 1 : 0)) != 0)
          Values.Add((bool) values[index].Value);
        else
          Values.Add(false);
      }
      for (int index = 0; index <= errors.Count - 1; ++index)
      {
        if (errors[index].Code > 0U)
          ErrorList.Add($"{errors[index].ToString()} - {nodeidList[index]}");
      }
      return ErrorList.Count == 0 ? "Ok" : ErrorList[0];
    }
    catch (Exception ex)
    {
      ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadBOOLsValueFromVariables(
    Session session,
    ref List<VariableBOOLDef> ReadVarBOOL)
  {
    try
    {
      List<NodeId> nodeIds = new List<NodeId>();
      DataValueCollection values = new DataValueCollection();
      IList<ServiceResult> errors = (IList<ServiceResult>) null;
      for (int index = 0; index <= ReadVarBOOL.Count - 1; ++index)
        nodeIds.Add(new NodeId(ReadVarBOOL[index].Name));
      session.ReadValues((IList<NodeId>) nodeIds, out values, out errors);
      for (int index = 0; index <= values.Count - 1; ++index)
      {
        int num = values[index].Value == null ? 0 : (values[index].Value.GetType() == typeof (bool) ? 1 : 0);
        ReadVarBOOL[index].Value = num != 0 && (bool) values[index].Value;
      }
      \u0003.\u0001.ErrorList.Clear();
      for (int index = 0; index <= errors.Count - 1; ++index)
      {
        if (errors[index].Code > 0U)
          \u0003.\u0001.ErrorList.Add($"{errors[index].ToString()} - {ReadVarBOOL[index].Name}");
      }
      return \u0003.\u0001.ErrorList.Count == 0 ? "Ok" : \u0003.\u0001.ErrorList[0];
    }
    catch (Exception ex)
    {
      \u0003.\u0001.ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadDINTsValueFromVariables(
    Session session,
    List<string> nodeidList,
    ref List<int> Values)
  {
    List<string> ErrorList = new List<string>();
    try
    {
      return OPCReadWrite.ReadDINTsValueFromVariables(session, nodeidList, ref Values, ref ErrorList);
    }
    catch (Exception ex)
    {
      ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadDINTsValueFromVariables(
    Session session,
    List<string> nodeidList,
    ref List<int> Values,
    ref List<string> ErrorList)
  {
    try
    {
      List<NodeId> nodeIds = new List<NodeId>();
      DataValueCollection values = new DataValueCollection();
      IList<ServiceResult> errors = (IList<ServiceResult>) null;
      for (int index = 0; index <= nodeidList.Count - 1; ++index)
        nodeIds.Add(new NodeId(nodeidList[index]));
      session.ReadValues((IList<NodeId>) nodeIds, out values, out errors);
      if (Values == null)
        Values = new List<int>();
      Values.Clear();
      for (int index = 0; index <= values.Count - 1; ++index)
      {
        if ((values[index].Value == null ? 0 : (values[index].Value.GetType() == typeof (int) ? 1 : 0)) != 0)
          Values.Add((int) values[index].Value);
        else
          Values.Add(0);
      }
      for (int index = 0; index <= errors.Count - 1; ++index)
      {
        if (errors[index].Code > 0U)
          ErrorList.Add($"{errors[index].ToString()} - {nodeidList[index]}");
      }
      return ErrorList.Count == 0 ? "Ok" : ErrorList[0];
    }
    catch (Exception ex)
    {
      ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadDINTsValueFromVariables(
    Session session,
    ref List<VariableDINTDef> ReadVarDINT)
  {
    try
    {
      List<NodeId> nodeIds = new List<NodeId>();
      DataValueCollection values = new DataValueCollection();
      IList<ServiceResult> errors = (IList<ServiceResult>) null;
      for (int index = 0; index <= ReadVarDINT.Count - 1; ++index)
        nodeIds.Add(new NodeId(ReadVarDINT[index].Name));
      session.ReadValues((IList<NodeId>) nodeIds, out values, out errors);
      for (int index = 0; index <= values.Count - 1; ++index)
      {
        values[index].Value.GetType().ToString();
        if ((values[index].Value == null ? 0 : (values[index].Value.GetType() == typeof (int) ? 1 : 0)) != 0)
        {
          ReadVarDINT[index].Value = (int) values[index].Value;
        }
        else
        {
          int num = values[index].Value == null ? 0 : (values[index].Value.GetType() == typeof (short) ? 1 : 0);
          ReadVarDINT[index].Value = num == 0 ? 0 : Convert.ToInt32(values[index].Value.ToString());
        }
      }
      \u0003.\u0001.ErrorList.Clear();
      for (int index = 0; index <= errors.Count - 1; ++index)
      {
        if (errors[index].Code > 0U)
          \u0003.\u0001.ErrorList.Add($"{errors[index].ToString()} - {ReadVarDINT[index].Name}");
      }
      return \u0003.\u0001.ErrorList.Count == 0 ? "Ok" : \u0003.\u0001.ErrorList[0];
    }
    catch (Exception ex)
    {
      \u0003.\u0001.ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadINTsValueFromVariables(
    Session session,
    List<string> nodeidList,
    ref List<short> Values)
  {
    List<string> ErrorList = new List<string>();
    try
    {
      return OPCReadWrite.ReadINTsValueFromVariables(session, nodeidList, ref Values, ref ErrorList);
    }
    catch (Exception ex)
    {
      ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadINTsValueFromVariables(
    Session session,
    List<string> nodeidList,
    ref List<short> Values,
    ref List<string> ErrorList)
  {
    try
    {
      List<NodeId> nodeIds = new List<NodeId>();
      DataValueCollection values = new DataValueCollection();
      IList<ServiceResult> errors = (IList<ServiceResult>) null;
      for (int index = 0; index <= nodeidList.Count - 1; ++index)
        nodeIds.Add(new NodeId(nodeidList[index]));
      session.ReadValues((IList<NodeId>) nodeIds, out values, out errors);
      if (Values == null)
        Values = new List<short>();
      Values.Clear();
      for (int index = 0; index <= values.Count - 1; ++index)
      {
        if ((values[index].Value == null ? 0 : (values[index].Value.GetType() == typeof (short) ? 1 : 0)) != 0)
          Values.Add((short) values[index].Value);
        else
          Values.Add((short) 0);
      }
      for (int index = 0; index <= errors.Count - 1; ++index)
      {
        if (errors[index].Code > 0U)
          ErrorList.Add($"{errors[index].ToString()} - {nodeidList[index]}");
      }
      return ErrorList.Count == 0 ? "Ok" : ErrorList[0];
    }
    catch (Exception ex)
    {
      ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadINTsValueFromVariables(
    Session session,
    ref List<VariableINTDef> ReadVarINT)
  {
    try
    {
      List<NodeId> nodeIds = new List<NodeId>();
      DataValueCollection values = new DataValueCollection();
      IList<ServiceResult> errors = (IList<ServiceResult>) null;
      for (int index = 0; index <= ReadVarINT.Count - 1; ++index)
        nodeIds.Add(new NodeId(ReadVarINT[index].Name));
      session.ReadValues((IList<NodeId>) nodeIds, out values, out errors);
      for (int index = 0; index <= values.Count - 1; ++index)
      {
        int num = values[index].Value == null ? 0 : (values[index].Value.GetType() == typeof (short) ? 1 : 0);
        ReadVarINT[index].Value = num == 0 ? (short) 0 : (short) values[index].Value;
      }
      \u0003.\u0001.ErrorList.Clear();
      for (int index = 0; index <= errors.Count - 1; ++index)
      {
        if (errors[index].Code > 0U)
          \u0003.\u0001.ErrorList.Add($"{errors[index].ToString()} - {ReadVarINT[index].Name}");
      }
      return \u0003.\u0001.ErrorList.Count == 0 ? "Ok" : \u0003.\u0001.ErrorList[0];
    }
    catch (Exception ex)
    {
      \u0003.\u0001.ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadLREALsValueFromVariables(
    Session session,
    List<string> nodeidList,
    ref List<double> Values)
  {
    List<string> ErrorList = new List<string>();
    try
    {
      return OPCReadWrite.ReadLREALsValueFromVariables(session, nodeidList, ref Values, ref ErrorList);
    }
    catch (Exception ex)
    {
      ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadLREALsValueFromVariables(
    Session session,
    List<string> nodeidList,
    ref List<double> Values,
    ref List<string> ErrorList)
  {
    try
    {
      List<NodeId> nodeIds = new List<NodeId>();
      DataValueCollection values = new DataValueCollection();
      IList<ServiceResult> errors = (IList<ServiceResult>) null;
      for (int index = 0; index <= nodeidList.Count - 1; ++index)
        nodeIds.Add(new NodeId(nodeidList[index]));
      session.ReadValues((IList<NodeId>) nodeIds, out values, out errors);
      if (Values == null)
        Values = new List<double>();
      Values.Clear();
      for (int index = 0; index <= values.Count - 1; ++index)
      {
        if ((values[index].Value == null ? 0 : (values[index].Value.GetType() == typeof (double) ? 1 : 0)) != 0)
          Values.Add((double) values[index].Value);
        else
          Values.Add(0.0);
      }
      for (int index = 0; index <= errors.Count - 1; ++index)
      {
        if (errors[index].Code > 0U)
          ErrorList.Add($"{errors[index].ToString()} - {nodeidList[index]}");
      }
      return ErrorList.Count == 0 ? "Ok" : ErrorList[0];
    }
    catch (Exception ex)
    {
      ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadLREALsValueFromVariables(
    Session session,
    ref List<VariableLREALDef> ReadVarLREAL)
  {
    try
    {
      List<NodeId> nodeIds = new List<NodeId>();
      DataValueCollection values = new DataValueCollection();
      IList<ServiceResult> errors = (IList<ServiceResult>) null;
      for (int index = 0; index <= ReadVarLREAL.Count - 1; ++index)
        nodeIds.Add(new NodeId(ReadVarLREAL[index].Name));
      session.ReadValues((IList<NodeId>) nodeIds, out values, out errors);
      for (int index = 0; index <= values.Count - 1; ++index)
      {
        int num = values[index].Value == null ? 0 : (values[index].Value.GetType() == typeof (double) ? 1 : 0);
        ReadVarLREAL[index].Value = num == 0 ? 0.0 : (double) values[index].Value;
      }
      \u0003.\u0001.ErrorList.Clear();
      for (int index = 0; index <= errors.Count - 1; ++index)
      {
        if (errors[index].Code > 0U)
          \u0003.\u0001.ErrorList.Add($"{errors[index].ToString()} - {ReadVarLREAL[index].Name}");
      }
      return \u0003.\u0001.ErrorList.Count == 0 ? "Ok" : \u0003.\u0001.ErrorList[0];
    }
    catch (Exception ex)
    {
      \u0003.\u0001.ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadREALsValueFromVariables(
    Session session,
    List<string> nodeidList,
    ref List<float> Values)
  {
    List<string> ErrorList = new List<string>();
    try
    {
      return OPCReadWrite.ReadREALsValueFromVariables(session, nodeidList, ref Values, ref ErrorList);
    }
    catch (Exception ex)
    {
      ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadREALsValueFromVariables(
    Session session,
    List<string> nodeidList,
    ref List<float> Values,
    ref List<string> ErrorList)
  {
    try
    {
      List<NodeId> nodeIds = new List<NodeId>();
      DataValueCollection values = new DataValueCollection();
      IList<ServiceResult> errors = (IList<ServiceResult>) null;
      for (int index = 0; index <= nodeidList.Count - 1; ++index)
        nodeIds.Add(new NodeId(nodeidList[index]));
      session.ReadValues((IList<NodeId>) nodeIds, out values, out errors);
      if (Values == null)
        Values = new List<float>();
      Values.Clear();
      for (int index = 0; index <= values.Count - 1; ++index)
      {
        if ((values[index].Value == null ? 0 : (values[index].Value.GetType() == typeof (float) ? 1 : 0)) != 0)
          Values.Add((float) values[index].Value);
        else
          Values.Add(0.0f);
      }
      for (int index = 0; index <= errors.Count - 1; ++index)
      {
        if (errors[index].Code > 0U)
          ErrorList.Add($"{errors[index].ToString()} - {nodeidList[index]}");
      }
      return ErrorList.Count == 0 ? "Ok" : ErrorList[0];
    }
    catch (Exception ex)
    {
      ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadREALsValueFromVariables(
    Session session,
    ref List<VariableREALDef> ReadVarREAL)
  {
    try
    {
      List<NodeId> nodeIds = new List<NodeId>();
      DataValueCollection values = new DataValueCollection();
      IList<ServiceResult> errors = (IList<ServiceResult>) null;
      for (int index = 0; index <= ReadVarREAL.Count - 1; ++index)
        nodeIds.Add(new NodeId(ReadVarREAL[index].Name));
      session.ReadValues((IList<NodeId>) nodeIds, out values, out errors);
      for (int index = 0; index <= values.Count - 1; ++index)
      {
        int num = values[index].Value == null ? 0 : (values[index].Value.GetType() == typeof (float) ? 1 : 0);
        ReadVarREAL[index].Value = num == 0 ? 0.0f : (float) values[index].Value;
      }
      \u0003.\u0001.ErrorList.Clear();
      for (int index = 0; index <= errors.Count - 1; ++index)
      {
        if (errors[index].Code > 0U)
          \u0003.\u0001.ErrorList.Add($"{errors[index].ToString()} - {ReadVarREAL[index].Name}");
      }
      return \u0003.\u0001.ErrorList.Count == 0 ? "Ok" : \u0003.\u0001.ErrorList[0];
    }
    catch (Exception ex)
    {
      \u0003.\u0001.ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadSTRINGsValueFromVariables(
    Session session,
    List<string> nodeidList,
    ref List<string> Values)
  {
    List<string> ErrorList = new List<string>();
    try
    {
      return OPCReadWrite.ReadSTRINGsValueFromVariables(session, nodeidList, ref Values, ref ErrorList);
    }
    catch (Exception ex)
    {
      ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadSTRINGsValueFromVariables(
    Session session,
    List<string> nodeidList,
    ref List<string> Values,
    ref List<string> ErrorList)
  {
    try
    {
      List<NodeId> nodeIds = new List<NodeId>();
      DataValueCollection values = new DataValueCollection();
      IList<ServiceResult> errors = (IList<ServiceResult>) null;
      for (int index = 0; index <= nodeidList.Count - 1; ++index)
        nodeIds.Add(new NodeId(nodeidList[index]));
      session.ReadValues((IList<NodeId>) nodeIds, out values, out errors);
      if (Values == null)
        Values = new List<string>();
      Values.Clear();
      for (int index = 0; index <= values.Count - 1; ++index)
      {
        if ((values[index].Value == null ? 0 : (values[index].Value.GetType() == typeof (double) ? 1 : 0)) != 0)
          Values.Add((string) values[index].Value);
        else
          Values.Add("");
      }
      for (int index = 0; index <= errors.Count - 1; ++index)
      {
        if (errors[index].Code > 0U)
          ErrorList.Add($"{errors[index].ToString()} - {nodeidList[index]}");
      }
      return ErrorList.Count == 0 ? "Ok" : ErrorList[0];
    }
    catch (Exception ex)
    {
      ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadSTRINGsValueFromVariables(
    Session session,
    ref List<VariableSTRINGDef> ReadVarSTRING)
  {
    try
    {
      List<NodeId> nodeIds = new List<NodeId>();
      DataValueCollection values = new DataValueCollection();
      IList<ServiceResult> errors = (IList<ServiceResult>) null;
      for (int index = 0; index <= ReadVarSTRING.Count - 1; ++index)
        nodeIds.Add(new NodeId(ReadVarSTRING[index].Name));
      session.ReadValues((IList<NodeId>) nodeIds, out values, out errors);
      for (int index = 0; index <= values.Count - 1; ++index)
      {
        int num = values[index].Value == null ? 0 : (values[index].Value.GetType() == typeof (string) ? 1 : 0);
        ReadVarSTRING[index].Value = num == 0 ? "" : (string) values[index].Value;
      }
      \u0003.\u0001.ErrorList.Clear();
      for (int index = 0; index <= errors.Count - 1; ++index)
      {
        if (errors[index].Code > 0U)
          \u0003.\u0001.ErrorList.Add($"{errors[index].ToString()} - {ReadVarSTRING[index].Name}");
      }
      return \u0003.\u0001.ErrorList.Count == 0 ? "Ok" : \u0003.\u0001.ErrorList[0];
    }
    catch (Exception ex)
    {
      \u0003.\u0001.ErrorList.Add("Exception - " + ex.Message);
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadBOOLValue(Session session, string nodeid, ref bool Value)
  {
    try
    {
      object obj = session.ReadValue(new NodeId(nodeid)).Value;
      if ((obj == null ? 0 : (obj.GetType() == typeof (bool) ? 1 : 0)) == 0)
        return "Type Mismatch Bool";
      Value = (bool) obj;
      return "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadDINTValue(Session session, string nodeid, ref int Value)
  {
    try
    {
      object obj = session.ReadValue(new NodeId(nodeid)).Value;
      if ((obj == null ? 0 : (obj.GetType() == typeof (int) ? 1 : 0)) == 0)
        return "Type Mismatch Int";
      Value = (int) obj;
      return "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadINTValue(Session session, string nodeid, ref short Value)
  {
    try
    {
      object obj = session.ReadValue(new NodeId(nodeid)).Value;
      if ((obj == null ? 0 : (obj.GetType() == typeof (short) ? 1 : 0)) == 0)
        return "Type Mismatch short";
      Value = (short) obj;
      return "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadLREALValue(Session session, string nodeid, ref double Value)
  {
    try
    {
      object obj = session.ReadValue(new NodeId(nodeid)).Value;
      if ((obj == null ? 0 : (obj.GetType() == typeof (double) ? 1 : 0)) == 0)
        return "Type Mismatch Double";
      Value = (double) obj;
      return "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadREALValue(Session session, string nodeid, ref float Value)
  {
    try
    {
      object obj = session.ReadValue(new NodeId(nodeid)).Value;
      if ((obj == null ? 0 : (obj.GetType() == typeof (float) ? 1 : 0)) == 0)
        return "Type Mismatch float";
      Value = (float) obj;
      return "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadSTRINGValue(Session session, string nodeid, ref string Value)
  {
    try
    {
      object obj = session.ReadValue(new NodeId(nodeid)).Value;
      if ((obj == null ? 0 : (obj.GetType() == typeof (string) ? 1 : 0)) == 0)
        return "Type Mismatch string";
      Value = (string) obj;
      return "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadDINTArray(Session session, string nodeid, ref int[] Values)
  {
    try
    {
      object obj = session.ReadValue(new NodeId(nodeid)).Value;
      if ((obj == null ? 0 : (obj.GetType() == typeof (int[]) ? 1 : 0)) == 0)
        return "Type Mismatch Int[]";
      Values = (int[]) obj;
      return "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadINTArray(Session session, string nodeid, ref short[] Values)
  {
    try
    {
      object obj = session.ReadValue(new NodeId(nodeid)).Value;
      if ((obj == null ? 0 : (obj.GetType() == typeof (short[]) ? 1 : 0)) == 0)
        return "Type Mismatch short[]";
      Values = (short[]) obj;
      return "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadBOOLArray(Session session, string nodeid, ref bool[] Values)
  {
    try
    {
      object obj = session.ReadValue(new NodeId(nodeid)).Value;
      if ((obj == null ? 0 : (obj.GetType() == typeof (bool[]) ? 1 : 0)) == 0)
        return "Type Mismatch Bool[]";
      Values = (bool[]) obj;
      return "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadLREALArray(Session session, string nodeid, ref double[] Values)
  {
    try
    {
      object obj = session.ReadValue(new NodeId(nodeid)).Value;
      if ((obj == null ? 0 : (obj.GetType() == typeof (double[]) ? 1 : 0)) == 0)
        return "Type Mismatch double[]";
      Values = (double[]) obj;
      return "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string ReadREALArray(Session session, string nodeid, ref float[] Values)
  {
    try
    {
      object obj = session.ReadValue(new NodeId(nodeid)).Value;
      if ((obj == null ? 0 : (obj.GetType() == typeof (float[]) ? 1 : 0)) == 0)
        return "Type Mismatch float[]";
      Values = (float[]) obj;
      return "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }
}
