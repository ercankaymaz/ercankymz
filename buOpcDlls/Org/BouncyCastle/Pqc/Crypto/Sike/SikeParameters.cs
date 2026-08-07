// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.SikeParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

[Obsolete("Will be removed")]
public sealed class SikeParameters
{
  public static readonly SikeParameters sikep434 = new SikeParameters(434, false, nameof (sikep434));
  public static readonly SikeParameters sikep503 = new SikeParameters(503, false, nameof (sikep503));
  public static readonly SikeParameters sikep610 = new SikeParameters(610, false, nameof (sikep610));
  public static readonly SikeParameters sikep751 = new SikeParameters(751, false, nameof (sikep751));
  public static readonly SikeParameters sikep434_compressed = new SikeParameters(434, true, nameof (sikep434_compressed));
  public static readonly SikeParameters sikep503_compressed = new SikeParameters(503, true, nameof (sikep503_compressed));
  public static readonly SikeParameters sikep610_compressed = new SikeParameters(610, true, nameof (sikep610_compressed));
  public static readonly SikeParameters sikep751_compressed = new SikeParameters(751, true, nameof (sikep751_compressed));
  private readonly int ver;
  private readonly bool isCompressed;
  private readonly string name;

  private SikeParameters(int ver, bool isCompressed, string name)
  {
    this.ver = ver;
    this.isCompressed = isCompressed;
    this.name = name;
  }

  internal SikeEngine GetEngine()
  {
    if (this.isCompressed)
    {
      switch (this.ver)
      {
        case 434:
          return SikeParameters.SikeP434CompressedEngine.Instance;
        case 503:
          return SikeParameters.SikeP503CompressedEngine.Instance;
        case 610:
          return SikeParameters.SikeP610CompressedEngine.Instance;
        case 751:
          return SikeParameters.SikeP751CompressedEngine.Instance;
        default:
          throw new InvalidOperationException();
      }
    }
    else
    {
      switch (this.ver)
      {
        case 434:
          return SikeParameters.SikeP434Engine.Instance;
        case 503:
          return SikeParameters.SikeP503Engine.Instance;
        case 610:
          return SikeParameters.SikeP610Engine.Instance;
        case 751:
          return SikeParameters.SikeP751Engine.Instance;
        default:
          throw new InvalidOperationException();
      }
    }
  }

  public string Name => this.name;

  public int DefaultKeySize => (int) this.GetEngine().GetDefaultSessionKeySize();

  private class SikeP434Engine
  {
    internal static readonly SikeEngine Instance = new SikeEngine(434, false, (SecureRandom) null);
  }

  private class SikeP503Engine
  {
    internal static readonly SikeEngine Instance = new SikeEngine(503, false, (SecureRandom) null);
  }

  private class SikeP610Engine
  {
    internal static readonly SikeEngine Instance = new SikeEngine(610, false, (SecureRandom) null);
  }

  private class SikeP751Engine
  {
    internal static readonly SikeEngine Instance = new SikeEngine(751, false, (SecureRandom) null);
  }

  private class SikeP434CompressedEngine
  {
    internal static readonly SikeEngine Instance = new SikeEngine(434, true, (SecureRandom) null);
  }

  private class SikeP503CompressedEngine
  {
    internal static readonly SikeEngine Instance = new SikeEngine(503, true, (SecureRandom) null);
  }

  private class SikeP610CompressedEngine
  {
    internal static readonly SikeEngine Instance = new SikeEngine(610, true, (SecureRandom) null);
  }

  private class SikeP751CompressedEngine
  {
    internal static readonly SikeEngine Instance = new SikeEngine(751, true, (SecureRandom) null);
  }
}
