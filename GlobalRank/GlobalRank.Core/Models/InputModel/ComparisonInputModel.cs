using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalRank.Core.Models.InputModel
{
    public class ComparisonInputModel
    {
        public string MyGame { get; set; }
        public string MyQueue { get; set; }
        public ICollection<ComparisonGameInputModel> Queues { get; set; }
    }
}
