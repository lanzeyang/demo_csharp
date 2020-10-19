using demo_csharp.Workers.IWorkService;
using Model.Enum;
using Model.QuotaAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace demo_csharp.Workers
{
    public class ExpressionWorker : IMasterWorker
    {
        public void Do()
        {
            CalculateFactorValue();
        }

        private void CalculateFactorValue()
        {
            InfluencedFactors factor1 = new InfluencedFactors
            {
                Name = "天数",
                AlgorithmIndex = 1,
                AlgorithmType = AlgorithmType.NONE,
                PrimaryFactorValue = null
            };

            List<InfluencedFactors> childFactors = new List<InfluencedFactors>()
            {
                new InfluencedFactors
                {
                    Name = "天数",
                    AlgorithmIndex = 1,
                    AlgorithmType = AlgorithmType.NONE,
                    PrimaryFactorValue = 0
                },
                new InfluencedFactors
                {
                    Name = "天数",
                    AlgorithmIndex = 2,
                    AlgorithmType = AlgorithmType.ADD,
                    PrimaryFactorValue = 10
                },
                new InfluencedFactors
                {
                    Name = "天数",
                    AlgorithmIndex = 3,
                    AlgorithmType = AlgorithmType.SUBTRACT,
                    PrimaryFactorValue = 5,
                    Children = new List<InfluencedFactors>
                    {
                        new InfluencedFactors
                        {
                            Name = "天数",
                            AlgorithmIndex = 1,
                            AlgorithmType = AlgorithmType.NONE,
                            PrimaryFactorValue = 10
                        },
                        new InfluencedFactors
                        {
                            Name = "天数",
                            AlgorithmIndex = 1,
                            AlgorithmType = AlgorithmType.DIVIDE,
                            PrimaryFactorValue = 0,
                            Children = new List<InfluencedFactors>
                            {
                                new InfluencedFactors
                                {
                                    Name = "天数",
                                    AlgorithmIndex = 1,
                                    AlgorithmType = AlgorithmType.NONE,
                                    PrimaryFactorValue = 3
                                },
                                new InfluencedFactors
                                {
                                    Name = "天数",
                                    AlgorithmIndex = 1,
                                    AlgorithmType = AlgorithmType.SUBTRACT,
                                    PrimaryFactorValue = 0,
                                    Children = new List<InfluencedFactors>
                                    {
                                        new InfluencedFactors
                                        {
                                            Name = "天数",
                                            AlgorithmIndex = 1,
                                            AlgorithmType = AlgorithmType.NONE,
                                            PrimaryFactorValue = 3
                                        },
                                        new InfluencedFactors
                                        {
                                            Name = "天数",
                                            AlgorithmIndex = 1,
                                            AlgorithmType = AlgorithmType.DIVIDE,
                                            PrimaryFactorValue = 0,
                                            Children = new List<InfluencedFactors>
                                            {
                                                new InfluencedFactors
                                                {
                                                    Name = "天数",
                                                    AlgorithmIndex = 1,
                                                    AlgorithmType = AlgorithmType.NONE,
                                                    PrimaryFactorValue = 6
                                                },
                                                new InfluencedFactors
                                                {
                                                    Name = "天数",
                                                    AlgorithmIndex = 1,
                                                    AlgorithmType = AlgorithmType.DIVIDE,
                                                    PrimaryFactorValue = 2
                                                },
                                            }
                                        },
                                    }
                                },
                            }
                        },
                    }
                },
                new InfluencedFactors
                {
                    Name = "天数",
                    AlgorithmIndex = 4,
                    AlgorithmType = AlgorithmType.MULTIPLY,
                    PrimaryFactorValue = null,
                    Children = new List<InfluencedFactors>
                    {
                        new InfluencedFactors
                        {
                            Name = "天数",
                            AlgorithmIndex = 1,
                            AlgorithmType = AlgorithmType.NONE,
                            PrimaryFactorValue = 3
                        },
                        new InfluencedFactors
                        {
                            Name = "天数",
                            AlgorithmIndex = 1,
                            AlgorithmType = AlgorithmType.ADD,
                            PrimaryFactorValue = 0,
                            Children = new List<InfluencedFactors>
                            {
                                new InfluencedFactors
                                {
                                    Name = "天数",
                                    AlgorithmIndex = 1,
                                    AlgorithmType = AlgorithmType.NONE,
                                    PrimaryFactorValue = 3
                                },
                                new InfluencedFactors
                                {
                                    Name = "天数",
                                    AlgorithmIndex = 1,
                                    AlgorithmType = AlgorithmType.DIVIDE,
                                    PrimaryFactorValue = 3
                                }
                            }
                        }
                    }
                }
            };

            factor1.Children.AddRange(childFactors);

            AlgorithmType algorithmType = AlgorithmType.NONE;
            Expression factor = CalculateQuota(factor1, out algorithmType);
            Console.WriteLine(factor);

            Func<decimal> factorAction = Expression.Lambda<Func<decimal>>(factor).Compile();
            Console.WriteLine(factorAction());
        }

        /// <summary>
        /// 通过InfluencedFactors构建表达式
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public Expression ConstructExpression(InfluencedFactors left, InfluencedFactors right)
        {
            Expression expression = null;

            Expression leftExpression = Expression.Constant(left.PrimaryFactorValue);
            Expression rightExpression = Expression.Constant(right.PrimaryFactorValue);

            switch (right.AlgorithmType)
            {
                case AlgorithmType.ADD:
                    expression = Expression.Add(leftExpression, rightExpression);
                    break;
                case AlgorithmType.SUBTRACT:
                    expression = Expression.Subtract(leftExpression, rightExpression);
                    break;
                case AlgorithmType.MULTIPLY:
                    expression = Expression.Multiply(leftExpression, rightExpression);
                    break;
                case AlgorithmType.DIVIDE:
                    expression = Expression.Divide(leftExpression, rightExpression);
                    break;
                default:
                    break;
            }

            return expression;
        }

        public Expression ConstructExpression(Expression left, Expression right, AlgorithmType algorithmType)
        {
            Expression expression = null;

            switch (algorithmType)
            {
                case AlgorithmType.ADD:
                    expression = Expression.Add(left, right);
                    break;
                case AlgorithmType.SUBTRACT:
                    expression = Expression.Subtract(left, right);
                    break;
                case AlgorithmType.MULTIPLY:
                    expression = Expression.Multiply(left, right);
                    break;
                case AlgorithmType.DIVIDE:
                    expression = Expression.Divide(left, right);
                    break;
                default:
                    break;
            }

            return expression;
        }

        public Expression CalculateQuota(InfluencedFactors influencedFactors, out AlgorithmType algorithmType)
        {
            Expression left = null;
            Expression right = null;
            Expression combined = null;

            algorithmType = AlgorithmType.NONE;

            if (null == influencedFactors.Children || influencedFactors.Children.Count().Equals(0))
            {
                algorithmType = influencedFactors.AlgorithmType;
                return Expression.Constant(influencedFactors.PrimaryFactorValue);
            }

            if (influencedFactors.Children.Count().Equals(1))
            {
                algorithmType = influencedFactors.Children.First().AlgorithmType;
                return Expression.Constant(influencedFactors.Children.First().PrimaryFactorValue);
            }

            for (int index = 0; index < influencedFactors.Children.Count; index++)
            {
                if (index == 0)
                {
                    left = CalculateQuota(influencedFactors.Children[index], out algorithmType);
                    continue;
                }

                if (index >= 2)
                {
                    left = combined;
                }

                right = CalculateQuota(influencedFactors.Children[index], out algorithmType);

                combined = ConstructExpression(left, right, algorithmType);

                if (index == influencedFactors.Children.Count - 1)
                {
                    algorithmType = influencedFactors.AlgorithmType;
                }
            }

            return combined;
        }
    }
}
