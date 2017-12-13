using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.Repository
{
    public interface IEntity : IEntity<int> { }

    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}