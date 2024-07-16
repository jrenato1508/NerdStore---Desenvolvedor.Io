using NerdStore.Core.DomainObjects;


namespace NerdStore.Catalogo.Domain.Entitys
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }

        public int Codigo { get; private set; }

        public IEnumerable<Produto> Produtos { get; set; }


        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
            Validar();
        }

        protected Categoria() { }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Codigo não pode ser 0");
        }
    }
}
