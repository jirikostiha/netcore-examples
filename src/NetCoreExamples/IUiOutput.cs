namespace DotNetCoreExamples
{
    public interface IUiOutput
    {
         void Write(string text);

         void Write(object obj);
    }
}
