using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IServiceResponse : IEncodeable, ICloneable
{
	ResponseHeader ResponseHeader { get; }
}
