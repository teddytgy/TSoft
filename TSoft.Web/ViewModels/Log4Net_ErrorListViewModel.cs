
using System;
using System.ComponentModel.DataAnnotations;
namespace TSoft.Web.ViewModels
{
    public class Log4Net_ErrorListViewModel
    {        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }

        private string logger;

        public string Logger
        {
            get { return logger; }
            set 
            {
                string[] temp = value.Split('.');
                logger = temp[temp.Length - 1];             
            }
        }
        public string Message { get; set; }   
    }
}