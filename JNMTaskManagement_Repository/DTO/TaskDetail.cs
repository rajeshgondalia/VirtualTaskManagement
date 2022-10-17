using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;
using JNMTaskManagement_Repository.Data;
using System.Web.Mvc;

namespace JNMTaskManagement_Repository.Data
{
    [MetadataType(typeof(TaskDetailsMetaData))]
    public partial class TaskDetail
    {
        public int RowNumber { get; set; }
        public string PriorityName { get; set; }
        public string FrequencyType { get; set; }
        public string DescHdn { get; set; }
        public string AlertDay { get; set; }
        public string AlertDay1 { get; set; }
        public string AlertDay2 { get; set; }
        public string DIvisionName { get; set; }
        public string ClientName { get; set; }
        public string DepartmentName { get; set; }
        public string UserName { get; set; }
        public HttpPostedFileBase AttachmentFile { get; set; }
        public string[] AssignIds { get; set; }
    }
    public class TaskDetailsMetaData
    {
        [Required(ErrorMessage = "Title can't be blank.")]
        public string Title { get; set; }

        [Range(1, 9999999, ErrorMessage = "Please select Priority!")]
        [Required(ErrorMessage = "Please select Priority!")]
        public int PriorityId { get; set; }

        [Required(ErrorMessage = "Description can't be blank.")] 
        [AllowHtml]
        public string Description { get; set; } 

        //[Required(ErrorMessage = "DIvision can't be blank.")]
        //public int DIvisionId { get; set; }  

        [Required(ErrorMessage = "Please select Holiday!")]
        public string Holiday { get; set; } 

        [Required(ErrorMessage = "Time can't be blank.")]
        public string Time { get; set; }

        [Required(ErrorMessage = "Please select Frequency!")]
        public int FrequencyId { get; set; } 

        [Required(ErrorMessage = "Please select Assign!")]
        public string Assign { get; set; }  
    }
}
