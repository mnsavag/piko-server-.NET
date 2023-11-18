namespace Piko.Exceptions
{
    public class AlreadyExistException: Exception
    {
        public AlreadyExistException(string message) : base(message) { }
    }
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException(string message) : base(message) { }
    }
}