// Decompiled with JetBrains decompiler
// Type: SourceGrid.Position
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

[Serializable]
public struct Position(int row, int col)
{
  private int m_Row = row;
  private int m_Col = col;
  public static readonly Position Empty = new Position(-1, -1);
  public const int c_EmptyIndex = -1;

  public int Row => this.m_Row;

  public int Column => this.m_Col;

  public bool IsEmpty() => this.Equals(Position.Empty);

  public override int GetHashCode() => this.Row;

  public bool Equals(Position p_Position)
  {
    return this.m_Col == p_Position.m_Col && this.m_Row == p_Position.m_Row;
  }

  public override bool Equals(object obj) => this.Equals((Position) obj);

  public static bool operator ==(Position Left, Position Right) => Left.Equals(Right);

  public static bool operator !=(Position Left, Position Right) => !Left.Equals(Right);

  public override string ToString()
  {
    int num = this.Row;
    string str1 = num.ToString();
    num = this.Column;
    string str2 = num.ToString();
    return $"{str1};{str2}";
  }

  public static Position Min(Position p_Position1, Position p_Position2)
  {
    return new Position(p_Position1.Row >= p_Position2.Row ? p_Position2.Row : p_Position1.Row, p_Position1.Column >= p_Position2.Column ? p_Position2.Column : p_Position1.Column);
  }

  public static Position Max(Position p_Position1, Position p_Position2)
  {
    return new Position(p_Position1.Row <= p_Position2.Row ? p_Position2.Row : p_Position1.Row, p_Position1.Column <= p_Position2.Column ? p_Position2.Column : p_Position1.Column);
  }
}
