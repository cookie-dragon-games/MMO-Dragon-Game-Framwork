﻿namespace Mmogf.Core
{

    public interface ICommandBase<TRequest, TResponse> : ICommand where TRequest : struct where TResponse : struct
    {
        TRequest? Request { get; set; }
        TResponse? Response { get; set; }
    }

    /// <summary>
    /// Fires to server and expects a response
    /// </summary>
    public interface ICommand : IMessage
    {
        short GetCommandId();
    }

    /// <summary>
    /// Fires of data to servers and clients
    /// </summary>
    public interface IEvent : IMessage
    {
        short GetEventId();
    }

    public interface IEntityComponent : IMessage
    {
        short GetComponentId();
    }
}
