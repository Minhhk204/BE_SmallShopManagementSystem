namespace BE__Small_Shop_Management_System.Helper
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }  
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public IEnumerable<object>? Errors { get; set; }

        // Success
        public static ApiResponse<T> SuccessResponse(T data, string message = "", int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Data = data,
                Message = message,
                StatusCode = statusCode
            };
        }

        // Error
        public static ApiResponse<T> ErrorResponse(string message, IEnumerable<object>? errors = null, int statusCode = 400)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = errors,
                StatusCode = statusCode
            };
        }
    }
}
