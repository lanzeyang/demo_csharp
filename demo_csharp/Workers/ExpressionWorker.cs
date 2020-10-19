using demo_csharp.Workers.IWorkService;
using Model.QuotaAlgorithm;
using System.Collections.Generic;
using System.Linq;

namespace demo_csharp.Workers
{
    public class ExpressionWorker : IMasterWorker
    {
        public void Do()
        {
            List<InfluencedFactors> factors = new List<InfluencedFactors>();

            InfluencedFactors factor1 = new InfluencedFactors
            {
                Name = "天数",
                AlgorithmIndex = 1,
                AlgorithmType = Model.Enum.AlgorithmType.MULTIPLY,
                PrimaryFactorValue = null
            };

            List<InfluencedFactors> childFactors = new List<InfluencedFactors>();
            childFactors.Add(
                new InfluencedFactors
                {
                    Name = "天数",
                    AlgorithmIndex = 1,
                    AlgorithmType = Model.Enum.AlgorithmType.NONE,
                    PrimaryFactorValue = 20
                });

            childFactors.Add(
                new InfluencedFactors
                {
                    Name = "天数",
                    AlgorithmIndex = 2,
                    AlgorithmType = Model.Enum.AlgorithmType.DIVISION,
                    PrimaryFactorValue = 30
                });
        }

        private void CalculateFactorValue(InfluencedFactors factor)
        {
            if (null == factor.Children || factor.Children.Count() == 0)
            {
                return;
            }

            foreach (InfluencedFactors child in factor.Children)
            {
                CalculateFactorValue(child);
            }
        }
    }
}
