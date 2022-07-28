using System.Collections.Generic;

namespace AnnuityLoanCalculator.Models
{
    public class TableModel
    {
        public double OverpaymentLoan { get; set; }
        public IEnumerable<RowResultModel> Rows { get; set; }
    }

    public class RowResultModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public double PaymentAmount { get; set; }
        public double PrincipalDebt { get; set; }
        public double Percent { get; set; }
        public double RemainingDebt { get; set; }
    }
}
