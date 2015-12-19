using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Infra;

namespace Loja
{
    class Program
    {
        static void Main(string[] args)
        {
            NHibernateHelper.GeraSchema();
        }
    }
}
