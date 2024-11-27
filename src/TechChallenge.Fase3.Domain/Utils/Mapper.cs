﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Fase3.Domain.Utils
{

    [AttributeUsage(AttributeTargets.All)]
    public class PrimaryKeyAttribute(string field) : Attribute
    {
        public string Description { get; } = field;
    }

    [AttributeUsage(AttributeTargets.All)]
    public class ColumnAttribute(string field) : Attribute
    {
        public string Description { get; } = field;
    }

    [AttributeUsage(AttributeTargets.All)]
    public class TableAttribute(string field) : Attribute
    {
        public string Description { get; } = field;
    }
}
