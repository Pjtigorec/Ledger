using Common.Core;
using System.Collections.Generic;

namespace Ledger.Models
{
    public class Filters
    {
        public int StateId { get; set; }

        public List<State> States { get; set; }
    }
}