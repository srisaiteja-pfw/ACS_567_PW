using FinTech.Interfaces;
using FinTech.Models;
using FinTech.Data;
using Microsoft.EntityFrameworkCore;


namespace FinTech.Repositories
{
    public class FinTechRepository : IFinTechRepository
    {
        private DataContext _context;

        public FinTechRepository(DataContext context)
        {
            _context = context;
        }


        /// <summary>
        /// It provides the analysis data, mean , median , max and min

        /// </summary>
        /// <returns></returns>

        public Dictionary<string, dynamic> analyzeBill()
        {
            List<int> numbers = _context.monthly_expenses
                            .Select(num => num.Expense)
                            .ToList();

            Dictionary<string, dynamic> analysis = new();
            // calculate the mean of the numbers
            double mean = numbers.Average();

            // calculate the median of the numbers
            int halfIndex = numbers.Count() / 2;
            var sortedNumbers = numbers.OrderBy(n => n);

            int median;

            if ((numbers.Count() % 2) == 0)
                median = (sortedNumbers.ElementAt(halfIndex) + sortedNumbers.ElementAt(halfIndex - 1)) / 2;
            else
                median = sortedNumbers.ElementAt(halfIndex);


            analysis.Add("Mean", mean);
            analysis.Add("Median", median);
            analysis.Add("Max", numbers.Max());
            analysis.Add("Min", numbers.Min());

            return analysis;
        }

        /// <summary>
        /// saves any changes made to the fintech repository.
        /// </summary>
        /// <returns></returns>
        /// 

        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved == 1;
        }

    }
}
