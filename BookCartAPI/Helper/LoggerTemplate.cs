namespace BookCartAPI.Helper
{
    public static class LoggerTemplate
    {
        public const string Success = "{MethodName}: method successfully called with HttpsSatusCode: {StatusCode}";
        public const string NoContent = "{MethodName}: method successfully called, But no data exists with HttpsSatusCode: {StatusCode}";
        public const string Error = "{MethodName}: method call failed,-{errorMessage} with HttpsSatusCode: {StatusCode}";
       
    }
}
