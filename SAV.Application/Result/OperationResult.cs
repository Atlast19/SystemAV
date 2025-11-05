

namespace SAV.Application.Result
{
    public class OperationResult<TModel>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;

        public OperationResult()
        {
            
        }

        public OperationResult(bool issuccess, string message)
        {
            IsSuccess = issuccess;
            Message = message;
        }

        public static OperationResult<TModel> Succes(string Message) 
        {
            return new OperationResult<TModel>(true, Message);
        }

        public static OperationResult<TModel> Failuer(string Message) 
        {
            return new OperationResult<TModel>(false, Message);
        }
    }
}
