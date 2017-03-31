namespace Team11_2106Project.DomainModel
{
    interface ILogIn<T>
    {
        bool Login(string email, string password);
    }
}
