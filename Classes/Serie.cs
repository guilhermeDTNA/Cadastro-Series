namespace Series
{
    public class Serie : EntidadeBase
    {
        private Genero genero { get; set; }
        private string titulo { get; set; }

        private string descricao { get; set; }

        private int ano { get; set; }
        private bool excluido {get; set;}

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
            this.excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";

            retorno += $"\n\n#ID {this.id}"+"\n";
            retorno += "Gênero: " + this.genero + "\n";
            retorno += "Título: " + this.titulo + "\n";
            retorno += "Descrição: " + this.descricao + "\n";
            retorno += "Ano de lançamento: " + this.ano ;

            return retorno;
        }

        public string retornaTitulo(){
            return this.titulo;
        }

        public int retornaId(){
            return this.id;
        }

        public void exclui(){
            this.excluido = true;
        }

        public bool retornaExlcuido(){
            if (this.excluido){
                return true;
            }

            return false;
        }
    }
}