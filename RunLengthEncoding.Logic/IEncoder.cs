using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunLengthEncoding.Logic
{
    public interface IEncoder
    {
        string Encode(string input);

        string Decode(string input);
    }
}
