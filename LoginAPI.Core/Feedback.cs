using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAPI.Core
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public string FeedbackText { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
