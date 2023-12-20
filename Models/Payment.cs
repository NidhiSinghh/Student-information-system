using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis_v2.Models
{
    internal class Payment
    {
        public int PaymentId { get; set; }
        public int StudentId {  get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate {  get; set; }


        //public Payment() { }

        //public Payment(int payId,int stuId,double amount,DateTime payDate) 
        //{ 
        //    PaymentId = payId;
        //    StudentId = stuId;
        //    Amount = amount;
        //    PaymentDate = payDate;
        //}

        public override string ToString()
        {
            return $"PaymentId:{PaymentId},Student Id:{StudentId} ,Amount : {Amount},PaymentDate:{PaymentDate} ";
        }
    }
}
