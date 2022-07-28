using AnnuityLoanCalculator.Models;
using System;
using System.Collections.Generic;

namespace AnnuityLoanCalculator.Manager
{
    public class Calculation
    {
        public static TableModel GetTableResults(CalculationModel model)
        {
            List<RowResultModel> rows = new();

            double RemainingDebt = model.LoanAmmount;
            double OverpaymentLoan = 0;

            double incrementDays = Math.Ceiling(model.LoanTerm / model.PaymentStep);

            for (int i = 1; i <= (model.CalculationType == CalculationType.Months ? model.LoanTerm : incrementDays); i++)
            {
                DateTime currentDate = model.CalculationType == CalculationType.Months ? 
                                            model.StartDate.AddMonths(i) : 
                                            model.StartDate.AddDays(i * model.PaymentStep);


                double MountlyRate = model.RateYear / (model.CalculationType == CalculationType.Months ? 12 : model.LoanTerm) / 100;
                double AnnuityRatio = MountlyRate + (MountlyRate / (Math.Pow(1 + MountlyRate, model.CalculationType == CalculationType.Months ? model.LoanTerm : incrementDays) - 1)); // K

                double MonthlyAnnuityPayment = (AnnuityRatio * model.LoanAmmount); // A
                double PrincipalDebt = RemainingDebt * (model.RateYear / 100 / (model.CalculationType == CalculationType.Months ? 12 : model.LoanTerm));

                RemainingDebt -= MonthlyAnnuityPayment - PrincipalDebt;
                OverpaymentLoan += PrincipalDebt;

                rows.Add(
                    new RowResultModel
                    {
                        Id = i,
                        Date = currentDate.ToString("dd MMMM yyyy"),
                        PaymentAmount = MonthlyAnnuityPayment,
                        PrincipalDebt = MonthlyAnnuityPayment - PrincipalDebt,
                        Percent = PrincipalDebt,
                        RemainingDebt = RemainingDebt <= 0 ? 0 : RemainingDebt
                    }
                );
            }

            return new TableModel { OverpaymentLoan = OverpaymentLoan, Rows = rows };
        }
    }
}
