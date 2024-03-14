namespace PacPay.Dominio.Interfaces
{
    public interface IRepositorioBase<T>
    {
        void Adicionar(T entidade);

        void Atualizar(T entidade);

        void Excluir(T entidade);
    }
}