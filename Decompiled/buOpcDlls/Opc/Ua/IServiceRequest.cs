using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IServiceRequest : IEncodeable, ICloneable
{
	RequestHeader RequestHeader { get; set; }
}
