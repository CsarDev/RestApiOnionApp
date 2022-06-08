namespace Services.Abstractions
{
    public interface IServiceManager
    {
        ITodoItemHomeService TodoItemHomeService { get; }
        ITodoItemWorkService TodoItemWorkService { get; }   
    }
}
