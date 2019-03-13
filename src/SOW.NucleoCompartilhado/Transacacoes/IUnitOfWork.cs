namespace SOW.NucleoCompartilhado.Transacacoes
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        bool Save();
    }
}