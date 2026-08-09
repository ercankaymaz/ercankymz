namespace System.ServiceModel.Channels;

internal interface IAsyncRequestSessionChannel : IRequestSessionChannel, IRequestChannel, IChannel, ICommunicationObject, ISessionChannel<IOutputSession>, IAsyncRequestChannel, IAsyncCommunicationObject
{
}
