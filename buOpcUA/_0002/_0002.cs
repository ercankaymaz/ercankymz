// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buOpcUA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF9DFBD0-0B81-4B3D-BD5F-1E30872BDC2B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcUA.dll

using dummy_ptr;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

#nullable disable
namespace \u0002;

[AttributeUsage(AttributeTargets.Method)]
internal class \u0002 : Attribute
{
  static \u0002()
  {
    \u0005.\u0002.\u0001 = "1";
    \u0005.\u0002.\u0002 = "97";
    \u0005.\u0003.\u0001 = (byte[]) null;
    \u0005.\u0003.\u0001 = new object();
    \u0005.\u0003.\u0001 = false;
    \u0005.\u0003.\u0001 = 0;
    if (\u0005.\u0002.\u0001 == "1")
    {
      \u0005.\u0003.\u0001 = true;
      \u0005.\u0003.\u0001 = new Dictionary<int, string>();
    }
    \u0005.\u0003.\u0001 = Convert.ToInt32(\u0005.\u0002.\u0002);
    using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("{3bcae739-7deb-435a-9f3e-41ba545ee0c4}"))
    {
      int int32 = Convert.ToInt32(manifestResourceStream.Length);
      byte[] buffer = new byte[int32];
      manifestResourceStream.Read(buffer, 0, int32);
      \u0005.\u0003.\u0001 = \u007Bc4786be5\u002D4d12\u002D491c\u002D8bef\u002D494b08e93552\u007D.\u0001(buffer);
    }
  }
}
