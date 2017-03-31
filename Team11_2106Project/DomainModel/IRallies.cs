namespace Team11_2106Project.DomainModel
{
    interface IRallies
    {
        IRallies ViewRallies(int id);
        void EditRallies(IRallies irally);
        void CreateRallies(IRallies irally);
        void DeleteRallies(int id);
    }
}