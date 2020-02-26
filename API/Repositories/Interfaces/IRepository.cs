using System.Collections.Generic;

namespace API.Repositories.Interfaces {
    public interface IRepository<T> {
        T Buscar(int id);
        void Adicionar(T obj);
        void Deletar(T obj);
        void Editar(T obj);
        List<T> Listar();
    }
}