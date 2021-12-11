using Calabonga.OperationResults;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;

using System.Security.Claims;

using X.PagedList;

namespace TaskTracker.Controllers
{
    public abstract class OperationController : ControllerBase
    {
        private string _userId;
        protected string UserId
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_userId))
                    _userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                return _userId;
            }
        }
        protected OperationResult<TResult> GetResult<TResult>(TResult res, string succsessLog)
        {
            var operation = OperationResult.CreateResult<TResult>();
            if (res == null) operation.AddError(new NullReferenceException());
            else {
                operation.Result = res;
                operation.AddSuccess(succsessLog);
            }
            return operation;
        }

        protected OperationResult<TResult> GetResult<TResult>(Func<TResult> func)
        {
            var operation = OperationResult.CreateResult<TResult>();
            TResult result;
            try
            {
                result = func();
            }
            catch (Exception e)
            {
                operation.AddError(e);
                return operation;
            }
            operation.Result = result;
            return operation;
        }
        //protected OperationResult<TResult> GetResult<TResult>(Exception exception)
        //{
        //    var result = OperationResult.CreateResult<TResult>();
        //    result.AddError(exception);
        //    return result;
        //}

    }
}
