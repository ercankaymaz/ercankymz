// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.NewSessionTicket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class NewSessionTicket
{
  private readonly long m_ticketLifetimeHint;
  private readonly byte[] m_ticket;

  public NewSessionTicket(long ticketLifetimeHint, byte[] ticket)
  {
    this.m_ticketLifetimeHint = ticketLifetimeHint;
    this.m_ticket = ticket;
  }

  public long TicketLifetimeHint => this.m_ticketLifetimeHint;

  public byte[] Ticket => this.m_ticket;

  public void Encode(Stream output)
  {
    TlsUtilities.WriteUint32(this.TicketLifetimeHint, output);
    TlsUtilities.WriteOpaque16(this.Ticket, output);
  }

  public static NewSessionTicket Parse(Stream input)
  {
    return new NewSessionTicket(TlsUtilities.ReadUint32(input), TlsUtilities.ReadOpaque16(input));
  }
}
