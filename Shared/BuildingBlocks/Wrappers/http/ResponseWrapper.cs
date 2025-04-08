﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Wrappers.http;

public class ResponseWrapper : IResponseWrapper
{
    public List<string> Messages { get; set; } = [];
    public bool ISuccessful { get; set; }

    public ResponseWrapper()
    {

    }

    public static IResponseWrapper Fail()
    {
        return new ResponseWrapper
        {
            ISuccessful = false
        };
    }

    public static IResponseWrapper Fail(string message)
    {
        return new ResponseWrapper
        {
            ISuccessful = false,
            Messages = [message]
        };
    }

    public static IResponseWrapper Fail(List<string> messages)
    {
        return new ResponseWrapper
        {
            ISuccessful = false,
            Messages = messages
        };
    }

    public static Task<IResponseWrapper> FailAsync()
    {
        return Task.FromResult(Fail());
    }

    public static Task<IResponseWrapper> FailAsync(string message)
    {
        return Task.FromResult(Fail(message));
    }

    public static Task<IResponseWrapper> FailAsync(List<string> messages)
    {
        return Task.FromResult(Fail(messages));
    }

    public static IResponseWrapper Success()
    {
        return new ResponseWrapper
        {
            ISuccessful = true
        };
    }

    public static IResponseWrapper Success(string message)
    {
        return new ResponseWrapper
        {
            ISuccessful = true,
            Messages = [message]
        };
    }

    public static IResponseWrapper Success(List<string> messages)
    {
        return new ResponseWrapper
        {
            ISuccessful = true,
            Messages = messages
        };
    }

    public static Task<IResponseWrapper> SuccessAsync()
    {
        return Task.FromResult(Success());
    }

    public static Task<IResponseWrapper> SuccessAsync(string message)
    {
        return Task.FromResult(Success(message));
    }

    public static Task<IResponseWrapper> SuccessAsync(List<string> messages)
    {
        return Task.FromResult(Success(messages));
    }
}

public class ResponseWrapper<T> : ResponseWrapper, IResponseWrapper<T>
{
    public T Data { get; set; } = default!;

    public static new IResponseWrapper<T> Fail()
    {
        return new ResponseWrapper<T>
        {
            ISuccessful = false
        };
    }

    public static new IResponseWrapper<T> Fail(string message)
    {
        return new ResponseWrapper<T>
        {
            ISuccessful = false,
            Messages = [message]
        };
    }

    public static new IResponseWrapper<T> Fail(List<string> messages)
    {
        return new ResponseWrapper<T>
        {
            ISuccessful = false,
            Messages = messages
        };
    }

    public static new Task<IResponseWrapper<T>> FailAsync()
    {
        return Task.FromResult(Fail());
    }

    public static new Task<IResponseWrapper<T>> FailAsync(string message)
    {
        return Task.FromResult(Fail(message));
    }

    public static new Task<IResponseWrapper<T>> FailAsync(List<string> messages)
    {
        return Task.FromResult(Fail(messages));
    }

    public static new IResponseWrapper<T> Success()
    {
        return new ResponseWrapper<T>
        {
            ISuccessful = true
        };
    }

    public static IResponseWrapper<T> Success(T data)
    {
        return new ResponseWrapper<T>
        {
            ISuccessful = true,
            Data = data
        };
    }

    public static IResponseWrapper<T> Success(T data, string message)
    {
        return new ResponseWrapper<T>
        {
            ISuccessful = true,
            Messages = [message],
            Data = data
        };
    }

    public static IResponseWrapper<T> Success(T data, List<string> messages)
    {
        return new ResponseWrapper<T>
        {
            ISuccessful = true,
            Data = data,
            Messages = messages
        };
    }

    public static new Task<IResponseWrapper<T>> SuccessAsync()
    {
        return Task.FromResult(Success());
    }

    public static Task<IResponseWrapper<T>> SuccessAsync(T data)
    {
        return Task.FromResult(Success(data));
    }

    public static Task<IResponseWrapper<T>> SuccessAsync(T data, string message)
    {
        return Task.FromResult(Success(data, message));
    }

    public static Task<IResponseWrapper<T>> SuccessAsync(T data, List<string> messages)
    {
        return Task.FromResult(Success(data, messages));
    }
}
