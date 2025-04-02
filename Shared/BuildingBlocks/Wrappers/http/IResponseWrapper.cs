using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Wrappers.http;

public interface IResponseWrapper
{
    List<string> Messages { get; set; }
    bool ISuccessful { get; set; }
}

public interface IResponseWrapper<out T> : IResponseWrapper
{
    T Data { get; }
}
