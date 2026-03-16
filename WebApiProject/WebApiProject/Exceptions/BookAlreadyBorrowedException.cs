namespace WebApiProject.Exceptions
{
    public class BookAlreadyBorrowedException : Exception
    {
        public override string Message
        {
            get { return "The book is currently borrowed and cannot be deleted or borrowed again."; }
        }
    }
}
