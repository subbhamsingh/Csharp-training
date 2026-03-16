namespace WebApiProject.Exceptions
{
    public class NotFoundException : Exception
    {
        public override string Message
        {
            get { return "The requested resource was not found."; }
        }
    }
}
