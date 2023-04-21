using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zal.Entities
{
    public class CompleteToDoModel
    {
        public string title { get; set; }

        public CompleteToDoModel(string title)
        {
            this.title = title;
        }
    }
}
