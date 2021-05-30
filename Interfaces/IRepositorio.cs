using System.Collections.Generic;

namespace Series.Interfaces
{
    public interface IRepositorio<T> //Pode-se passar qualquer parâmetro para a interface
    {
         List<T> lista();
         T retornaPorId(int id);
         void insere(T entidade);
         void exclui(int id);
         void atualiza(int id, T entidade);
         int proximoId();
    }
}