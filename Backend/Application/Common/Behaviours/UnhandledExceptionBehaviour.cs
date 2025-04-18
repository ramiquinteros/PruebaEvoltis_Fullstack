using Application.Common.Exceptions;
using Application.Common.Models;
using MediatR;
using System.Net;

namespace Application.Common.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        public async Task<TResponse> Handle(
            TRequest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;

                var response = new Result();

                switch (ex)
                {
                    case ValidationException:
                        var validations = ex as ValidationException;

                        response.Code = (int)HttpStatusCode.BadRequest;
                        response.Message = ex.Message;
                        response.Response = validations.Errors;
                        break;
                    case BadRequestException:
                        response.Code = (int)HttpStatusCode.BadRequest;
                        response.Message = ex.Message;
                        break;
                    case NotFoundException:
                        response.Code = (int)HttpStatusCode.NotFound;
                        response.Message = ex.Message;
                        break;
                    default:
                        response.Code = (int)HttpStatusCode.InternalServerError;
                        response.Message = ex.Message;
                        break;
                }

                return (TResponse)Convert.ChangeType(response, typeof(TResponse));
            }
        }
    }
}
