// Decompiled with JetBrains decompiler
// Type: dummy_ptr.{3e3a94b6-3ce3-4943-9bb0-2439d20be70c}
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

using buClass;
using buComm.FTP;
using SmartAssembly.HouseOfCards;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

#nullable disable
namespace dummy_ptr;

internal abstract class \u007B3e3a94b6\u002D3ce3\u002D4943\u002D9bb0\u002D2439d20be70c\u007D
{
  internal static readonly \u0004.\u0004.\u0002 \u0001;
  internal static readonly \u0004.\u0004.\u0004 \u0001;
  internal static readonly \u0004.\u0004.\u0001 \u0001;
  internal static readonly \u0004.\u0004.\u0002 \u0002;
  internal static readonly \u0004.\u0004.\u0005 \u0001;
  internal static readonly \u0004.\u0004.\u0003 \u0001;
  internal static readonly \u0004.\u0004.\u0002 \u0003;
  internal static readonly \u0004.\u0004.\u0001 \u0002;
  internal static readonly \u0004.\u0004.\u0004 \u0002;
  internal static readonly \u0004.\u0004.\u0005 \u0002;

  static ICryptoTransform \u0001([In] byte[] obj0, [In] byte[] obj1, [In] bool obj2)
  {
    using (AesCryptoServiceProvider cryptoServiceProvider = new AesCryptoServiceProvider())
      return obj2 ? cryptoServiceProvider.CreateDecryptor(obj1, obj0) : cryptoServiceProvider.CreateEncryptor(obj1, obj0);
  }

  static void \u0001([In] FTPControlSocket obj0) => \u0005.\u0004.\u0001("220", \u0005.\u0004.\u0001(obj0), obj0);

  static void \u0001([In] bool obj0, [In] FTPClient obj1, [In] string obj2, [In] string obj3)
  {
    \u0005.\u0004.\u0001((Stream) new FileStream(obj2, FileMode.Open, FileAccess.Read), obj1, obj0, obj3);
  }

  static void \u0001([In] string obj0, [In] string obj1, [In] FTPClient obj2)
  {
    \u0005.\u0004.\u0001(obj0, obj2);
    FileInfo fileInfo = new FileInfo(obj1);
    StreamWriter streamWriter = new StreamWriter(obj1);
    StreamReader streamReader = new StreamReader((Stream) \u0005.\u0004.\u0001(obj2));
    IOException ioException = (IOException) null;
    try
    {
      string format;
      while ((format = streamReader.ReadLine()) != null)
      {
        streamWriter.Write(format, (object) 0, (object) format.Length);
        streamWriter.WriteLine();
      }
    }
    catch (IOException ex)
    {
      ioException = ex;
    }
    finally
    {
      streamWriter.Close();
      if ((ioException == null ? 0 : (System.IO.File.Exists(fileInfo.FullName) ? 1 : 0)) != 0)
        System.IO.File.Delete(fileInfo.FullName);
    }
    try
    {
      streamReader.Close();
    }
    catch (IOException ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException((Exception) ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
    if (ioException != null)
      throw ioException;
  }

  static void \u0001(
    [In] IPAddress obj0,
    [In] int obj1,
    [In] int obj2,
    [In] StreamWriter obj3,
    [In] FTPControlSocket obj4)
  {
    \u0005.\u0004.\u0001(obj3, obj4);
    ((FTPReply) obj4).\u0001 = true;
    IPEndPoint remoteEP = new IPEndPoint(obj0, obj2);
    ((MemberRefsProxy) obj4).\u0001 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    \u0005.\u0004.\u0001(obj1, obj4);
    ((MemberRefsProxy) obj4).\u0001.Connect((EndPoint) remoteEP);
    \u0005.\u0004.\u0001(obj4);
    \u007B3e3a94b6\u002D3ce3\u002D4943\u002D9bb0\u002D2439d20be70c\u007D.\u0001(obj4);
    ((FTPReply) obj4).\u0001 = false;
  }
}
