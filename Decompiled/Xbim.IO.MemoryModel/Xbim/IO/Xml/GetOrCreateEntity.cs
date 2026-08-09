using System;
using Xbim.Common;

namespace Xbim.IO.Xml;

public delegate IPersistEntity GetOrCreateEntity(int label, Type type);
