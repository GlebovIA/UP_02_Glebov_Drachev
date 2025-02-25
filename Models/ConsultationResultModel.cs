using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_02_Glebov_Drachev.Models
{
    public class ConsultationResultsModel
    {
        public int Id { get; set; }
        public int ConsultationId { get; set; }
        public int StudentId { get; set; }
        public bool Presence { get; set; }
        public string SubmittedPractice { get; set; }

    }

}
