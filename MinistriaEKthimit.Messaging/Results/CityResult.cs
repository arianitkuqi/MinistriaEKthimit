using MinistriaEKthimit.Messaging.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistriaEKthimit.Messaging.Results
{
    public class CityResult: IResultModel
    {

    }

    public class CityResult2 : IResultModel
    {
        public IEnumerable<CityResult> Cites { get; set; }

        public int Id { get; set; }

        public string Key { get; set; }
    }
}
