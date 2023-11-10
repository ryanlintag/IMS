namespace Domain.Abstractions
{
    public class Result
    {
        private Result(bool isSuccess, DomainError error)
        {
            if ((isSuccess && error != DomainError.None) ||
                (!isSuccess && error == DomainError.None))
            {
                throw new ArgumentException("Invalid error!", nameof(error));
            }
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public DomainError Error { get; }

        public static Result Success() => new(true, DomainError.None);
        public static Result Failure(DomainError error) => new(false, error);
    }
}
