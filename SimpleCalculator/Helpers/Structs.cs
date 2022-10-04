namespace bf.api.Helpers
{
    /// <summary>
    /// This Result structure used to return common object result for all API methods
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Rperesents the invoke status where user can validate the true,false value
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Shows the error message in the event of internal errors
        /// </summary>
        public string? ErrorMessage { get; set; }
        /// <summary>
        /// Shows the user friendly error message where user can directly show it in front end applications
        /// </summary>
        public string? UserMessage { get; set; }
        /// <summary>
        /// Returns a single object on the API result
        /// </summary>
        public object? Value { get; set; }
        /// <summary>
        /// Returns object array on the API result
        /// </summary>
        public object[]? Values { get; set; }
        /// <summary>
        /// Generated JWT 
        /// </summary>
        public string? JWT { get; set; }
    }

    /// <summary>
    /// This input structure used to calculate for all calculator API methods
    /// </summary>
    public class CalcIn
    {
        /// <summary>
        /// First value for the arithmetic operations
        /// </summary>
        public decimal Number1 { get; set; }

        /// <summary>
        /// Second value for the arithmetic operations
        /// </summary>
        public decimal Number2 { get; set; }
    }

    /// <summary>
    /// Public structure for authentications
    /// </summary>
    public class AuthObject
    {
        /// <summary>
        /// String user name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// String password
        /// </summary>
        public string Password { get; set; }
    }
}
