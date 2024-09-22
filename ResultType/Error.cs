using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultType;

public record Error(string Code, string Description)
{
    public static Error None => new(string.Empty, string.Empty);
}
