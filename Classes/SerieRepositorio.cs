using System;
using System.Collections.Generic;
using Series.Interfaces;

namespace Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public bool exclui(int id)
        {
                try{
                listaSerie[id].exclui();
                } catch(Exception){
                    
                    return false;
                }
            
            return true;
        }

        public void insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> lista()
        {
            return listaSerie;
        }

        public int proximoId()
        {
            return listaSerie.Count;
        }

        public Serie retornaPorId(int id)
        {
            try{
            if(listaSerie.Contains(listaSerie[id]) && String.Compare(listaSerie[id].retornaTitulo(), "") != 0){
                return listaSerie[id];
            }
            } catch(Exception){
                return null;
            }

            return null;
            
        }
    }
}