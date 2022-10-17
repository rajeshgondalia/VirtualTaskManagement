using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;
using JNMTaskManagement_Repository.Data;

namespace JNMTaskManagement_Repository.Data
{
    [MetadataType(typeof(PaymentMasterMetaData))]
    public partial class PaymentMaster
    { 
        public string AccountCode { get; set; }
        public string CompanyCode { get; set; }
        public string PaymentCode { get; set; }
        public string ReceiptCode { get; set; }
        public int RowNumber { get; set; }
    }
    public class PaymentMasterMetaData
    { 
        [Range(1,9999999,ErrorMessage = "AccountCode can not be blank.")]
        [Required(ErrorMessage = "AccountCode can't be blank.")]
        public string AccountId { get; set; }

        [Range(1, 9999999, ErrorMessage = "CompanyCode can not be blank.")]
        [Required(ErrorMessage = "CompanyCode can't be blank.")]
        public string CompanyId { get; set; }

        [Range(1, 9999999, ErrorMessage = "PaymentCode can not be blank.")]
        [Required(ErrorMessage = "PaymentCode can't be blank.")]
        public string PaymentId { get; set; }

        [Range(1, 9999999, ErrorMessage = "ReceiptCode can not be blank.")]
        [Required(ErrorMessage = "ReceiptCode can't be blank.")]
        public string ReceiptId { get; set; }

        [Required(ErrorMessage = "Amount can't be blank.")]
        [Range(1, 9999999, ErrorMessage = "Amount can not be blank.")]
        public decimal Amount { get; set; } 
    }
}
