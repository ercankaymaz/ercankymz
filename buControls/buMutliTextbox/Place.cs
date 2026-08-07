// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.Place
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace buMutliTextbox;

public struct Place(int iChar, int iLine) : IEquatable<Place>
{
  public int iChar = iChar;
  public int iLine = iLine;

  public void Offset(int dx, int dy)
  {
    this.iChar += dx;
    this.iLine += dy;
  }

  public bool Equals(Place other) => this.iChar == other.iChar && this.iLine == other.iLine;

  public override bool Equals(object obj) => obj is Place other && this.Equals(other);

  public override int GetHashCode() => this.iChar.GetHashCode() ^ this.iLine.GetHashCode();

  public static bool operator !=(Place p1, Place p2) => !p1.Equals(p2);

  public static bool operator ==(Place p1, Place p2) => p1.Equals(p2);

  public static bool operator <(Place p1, Place p2)
  {
    return p1.iLine < p2.iLine || p1.iLine <= p2.iLine && p1.iChar < p2.iChar;
  }

  public static bool operator <=(Place p1, Place p2)
  {
    return p1.Equals(p2) || p1.iLine < p2.iLine || p1.iLine <= p2.iLine && p1.iChar < p2.iChar;
  }

  public static bool operator >(Place p1, Place p2)
  {
    return p1.iLine > p2.iLine || p1.iLine >= p2.iLine && p1.iChar > p2.iChar;
  }

  public static bool operator >=(Place p1, Place p2)
  {
    return p1.Equals(p2) || p1.iLine > p2.iLine || p1.iLine >= p2.iLine && p1.iChar > p2.iChar;
  }

  public static Place operator +(Place p1, Place p2)
  {
    return new Place(p1.iChar + p2.iChar, p1.iLine + p2.iLine);
  }

  public static Place Empty => new Place();

  public override string ToString() => $"({this.iChar.ToString()},{this.iLine.ToString()})";
}
