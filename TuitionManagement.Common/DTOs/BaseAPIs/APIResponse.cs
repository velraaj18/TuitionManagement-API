namespace TuitionManagement.Common.DTOs
{
    // The <T> denotes that any datatype can be returned. string, int (or) custom classes
    public class APIResponse<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }
}