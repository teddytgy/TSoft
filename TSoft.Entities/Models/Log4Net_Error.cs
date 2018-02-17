using System;
using System.Collections.Generic;


namespace TSoft.Entities.Models
{       
    public class Log4Net_Error
    {               
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }        
    }
}