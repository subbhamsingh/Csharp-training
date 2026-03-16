

namespace LibraryManagementSystem.Exceptions
{
    public class BookNotFoundException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return " Book not found ";
            }
        }

    }
}
