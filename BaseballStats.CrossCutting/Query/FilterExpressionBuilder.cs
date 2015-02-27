using BaseballStats.CrossCutting.Query.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseballStats.CrossCutting.Query
{
    public class FilterExpressionBuilder : IBuildFilterExpressions
    {
        public Expression<Func<T, bool>> BuildLambda<T>(List<FilterObject> filter)
        {
            if (filter == null)
                return null;

            Expression finalClause = Expression.Empty();
            Expression tempClause = Expression.Empty();
            ParameterExpression entity = Expression.Parameter(typeof(T), "baseballEntity");
            var filterArray = filter.ToArray();

            for (int i = 0; i < filterArray.Count(); i++)
            {
                try
                {
                    Expression filterExpression = BuildFilterExpression(filterArray[i], entity);
                    var logicalFunc = GetLogicalOperator(filterArray[i].LogicalOperator);

                    if(i==0)
                    {
                        tempClause = filterExpression;
                    }
                    else
                    {
                        tempClause = logicalFunc(tempClause, filterExpression);
                    }

                    if(i == filter.Count() - 1)
                    {
                        finalClause = tempClause;
                    }
                }
                catch(Exception e)
                {
                    throw new Exception("Invalid filter definition");
                }
            }

                return Expression.Lambda<Func<T, bool>>(finalClause, new ParameterExpression[] {entity});
        }

        private Expression BuildFilterExpression(FilterObject filterElement, ParameterExpression entity)
        {
            Expression column = Expression.Property(entity, filterElement.FilterColumn);
            Expression value = Expression.Constant(filterElement.FilterValue, filterElement.FilterValue.GetType());
            return EvaluateFilterOperator(filterElement.FilterOperator, column, value);
        }

        private Expression EvaluateFilterOperator(FilterOperator filterElement, Expression column, Expression value)
        {
            switch(filterElement)
            {
                case FilterOperator.eq:
                    return Expression.Equal(column, value);
                case FilterOperator.gt:
                    return Expression.GreaterThan(column, value);
                case FilterOperator.lt:
                    return Expression.LessThan(column, value);
                case FilterOperator.ctns:
                    var contains = typeof(string).GetMethod("Contains");
                    return Expression.Call(column, contains, value);
                default:
                    return null;
            }
        }

        private Func<Expression, Expression, BinaryExpression> GetLogicalOperator(LogicalOperator logicalOperator)
        {
            switch (logicalOperator)
            {
                case LogicalOperator.And:
                    return Expression.AndAlso;
                case LogicalOperator.Or:
                    return Expression.OrElse;
                default:
                    return null;
            }
        }
    }
}
