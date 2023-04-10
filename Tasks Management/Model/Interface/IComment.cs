using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Team.Model.Interface
{
    public interface IComment
    {
        public string Comment { get; }
        public string Author { get; }
    }
}
