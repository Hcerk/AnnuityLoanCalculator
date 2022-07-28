using System;
using System.ComponentModel.DataAnnotations;

namespace AnnuityLoanCalculator.Models
{
    public class CalculationModel
    {
        public CalculationType CalculationType { get; set; } = CalculationType.Months;

        [Required]
        [Range(1, 10000000, ErrorMessage = "Сумма займа должна быть от 1 до 10.000.000")]
        public int LoanAmmount { get; set; } = 10000;

        [Required]
        [Range(1, 366, ErrorMessage = "Срок займа должен быть от 1 до 366")]
        public int LoanTerm { get; set; } = 12;

        [Required]
        [Range(0.01, 70, ErrorMessage = "Ставка от 0.01 до 70")]
        public double RateYear { get; set; } = 12;

        [Range(1, 30, ErrorMessage = "Шаг платежа от 1 до 30")]
        public double PaymentStep { get; set; } = 1;
        public DateTime StartDate { get; set; } = DateTime.Now;

    }

    public enum CalculationType
    {
        Months,
        Days
    }
}
