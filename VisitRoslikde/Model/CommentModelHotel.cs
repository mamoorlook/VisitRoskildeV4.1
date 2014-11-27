using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VisitRoslikde.Model
{
    [DataContract]
    public class CommentModelHotel
    {
        [DataMember]
        public string writeComment { get; set; }
    }
}
