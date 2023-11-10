namespace Domain.Abstractions
{
    public record DomainError(string Code, string? Description = null)
    {
        public static readonly DomainError None = new(string.Empty);
        public static implicit operator Result(DomainError error) => Result.Failure(error);
    }
}
